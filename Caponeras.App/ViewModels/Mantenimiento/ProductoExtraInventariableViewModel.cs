using System.ComponentModel;
using Caponeras.App.Dto;
using Caponeras.App.Helpers;
using Caponeras.App.Services;
using Caponeras.Data.Models;
using Microsoft.EntityFrameworkCore;
using NLog;

namespace Caponeras.App.ViewModels.Mantenimiento;

public class ProductoExtraInventariableViewModel : BaseViewModel
{
    private MaestroCajaService _maestroCajaService;
    private INavigationService _navigationService;
    private ProveedoresService _proveedoresService;
    private ProductoDto? _productoDto;
    private ILogger _logger = LogManager.GetCurrentClassLogger();
    public BindingList<ProveedoresDto> ProveedoresBindingList { get; private set; } = new();

    public ProductoDto? ProductoDto
    {
        get => _productoDto;
        set => SetProperty(ref _productoDto, value, "ProductoDto");
    }

    public ProductoExtraInventariableViewModel(ProveedoresService proveedoresService,
        INavigationService navigationService, MaestroCajaService maestroCajaService)
    {
        _proveedoresService = proveedoresService;
        _navigationService = navigationService;
        _maestroCajaService = maestroCajaService;
    }

    public async Task LoadProveedores()
    {
        var proveedores = await _proveedoresService.GetAllAsync();
        ProveedoresBindingList.Clear();
        foreach (var proveedor in proveedores)
        {
            ProveedoresBindingList.Add(proveedor);
        }
    }

    public void SetProducto(ProductoDto row)
    {
        ProductoDto = row;
    }

    public async Task<bool> SaveProductoExtraInventariable(decimal cantidad, decimal precio, int idProveedor)
    {
        await using var ctx = new DataContextCaponeras();
        await using var tx = await ctx.Database.BeginTransactionAsync();
        try
        {
            var query = _navigationService.Query;
            var idMantenimiento = 0;
            if (query is ValueTuple<ProductoDto, int> context)
            {
                ProductoDto = context.Item1;
                idMantenimiento = context.Item2;
            }
            else
            {
                ProductoDto = query as ProductoDto;
            }
            if (ProductoDto is null)
            {
                throw new Exception("No se seleccionó el producto a usar");
            }
            var param = await ctx.Parametros.FirstOrDefaultAsync();
            if (param is null) throw new Exception("No existen los parametros en sistema");

            var proveedor = await ctx.Proveedores.AsNoTracking()
                .FirstOrDefaultAsync(p => p.Idproveedor == idProveedor && p.Activo == true);
            if (proveedor is null) throw new Exception("Proveedor no encontrado");


            var findProducto = await ctx.Productos.FindAsync(ProductoDto.IdProducto);
            if (findProducto is null)
            {
                throw new Exception("No se encontró el producto a usar");
            }
            if(findProducto.Inventariable)
            {
                throw new Exception("El producto es inventariable");
            }
            var importe = precio * cantidad;
            var compra = new Data.Models.Compras
            {
                Frecha = DateTime.Now,
                NumeroDocumento = $"MANT-{idMantenimiento}-{DateTime.Now:yyyyMMddHHmmssfff}",
                Idproveedor = idProveedor,
                Total = importe,
                Subtotal = importe,
                Iva = 0,
                CreatedBy = _navigationService.CurrentUser.Idusuario,
                CreatedAt = DateTime.Now,
                UpdatedBy = _navigationService.CurrentUser.Idusuario,
                UpdatedAt = DateTime.Now,
                Estado = EstadoCompra.Aprobada
            };

            await ctx.Compras.AddAsync(compra);
            await ctx.SaveChangesAsync();

            var detalleCompra = new DetalleCompras
            {
                Idproducto = ProductoDto.IdProducto,
                Cantidad = cantidad,
                PrecioUnitario = precio,
                Importe = importe,
                Idcompra = compra.Idcompra
            };
            await ctx.AddAsync(detalleCompra);

            var cxp = new TransactionCxps
            {
                TipoOrigen = (int)Helpers.EnumTipoCxp.Compras, // catálogo
                IdOrigen = compra.Idcompra,
                IdTercero = idProveedor,
                FechaEmision = compra.Frecha,
                FechaVencimiento = compra.Frecha.AddDays(30),
                MontoTotal = importe,
                SaldoPendiente = importe,
                Estado = EstadoCxp.PARCIAL,
                CreatedAt = DateTime.Now,
                CreatedBy = _navigationService.CurrentUser.Idusuario,
                UpdatedAt = DateTime.Now,
                UpdatedBy = _navigationService.CurrentUser.Idusuario
            };
            await ctx.TransactionCxps.AddAsync(cxp);

            await ctx.SaveChangesAsync();
            await tx.CommitAsync();
            return true;
        }
        catch (Exception e)
        {
            await tx.RollbackAsync();
            _logger.Error(e);
            GetMessageAlert(TypeAlert.Error, "Error", e.Message, _navigationService.MainView);
            return false;
        }
    }
}
