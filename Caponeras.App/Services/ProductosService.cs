using Caponeras.App.Dto;
using Caponeras.Insfraestructura.Repository;
using Microsoft.EntityFrameworkCore;
using NLog;
using System.Net.Http;
using Caponeras.Data.Models;

namespace Caponeras.App.Services;

public class ProductosService
{
    private static readonly HttpClient _httpClient = new HttpClient();
    private DataContextCaponeras _context;
    private readonly ILogger _logger = LogManager.GetCurrentClassLogger();

    public ProductosService(DataContextCaponeras context)
    {
        _context = context;
        ErrorMessage = string.Empty;
    }

    public string ErrorMessage { get; private set; }

    public List<CategoriaProductoDto> GetCategorias()
    {
        return _context.CategoriasProductos
            .Select(c => CategoriaProductoDto.FromModel(c))
            .ToList();
    }

    public List<UnidadMedidaDto> GetUnidadesMedida()
    {
        return _context.UnidadesMedidas
            .Select(u => UnidadMedidaDto.FromModel(u))
            .ToList();
    }

    public Task<List<ProductoDto>> GetAll()
    {
        return _context.Productos
            .AsNoTracking()
            .Include(p => p.UnidadesMedidas)
            .Include(p => p.CategoriasProductos)
            .Select(p => new ProductoDto().FromModel(p))
            .ToListAsync();
    }

    public async Task<Image> DescargarImagenAsync(string? url)
    {
        if (string.IsNullOrEmpty(url))
        {
            return Properties.Resources.motorcycle_1227030;
        }

        try
        {
            var stream = await _httpClient.GetStreamAsync(url);
            return Image.FromStream(stream);
        }
        catch
        {
            return Properties.Resources.motorcycle_1227030;
        }
    }

    public async Task<int> Save(ProductoDto producto)
    {
        ErrorMessage = string.Empty;

        try
        {
            producto.Codigo = producto.Codigo?.Trim().ToUpperInvariant();
            producto.Nombre = producto.Nombre?.Trim();
            producto.Descripcion = producto.Descripcion?.Trim();

            if (string.IsNullOrWhiteSpace(producto.Codigo) || string.IsNullOrWhiteSpace(producto.Nombre))
            {
                ErrorMessage = "El código y el nombre del producto son obligatorios.";
                return -1;
            }

            if (producto.Codigo.Length > 50)
            {
                ErrorMessage = "El código no puede exceder 50 caracteres.";
                return -1;
            }

            var codigoEnUso = await _context.Productos
                .AsNoTracking()
                .AnyAsync(p => p.Codigo == producto.Codigo && p.IdProducto != producto.IdProducto);
            if (codigoEnUso)
            {
                ErrorMessage = $"Ya existe un producto con el código {producto.Codigo}.";
                return -1;
            }

            if (producto.IdCategoria is null || producto.IdUnidadMedida is null)
            {
                ErrorMessage = "Seleccione una categoría y una unidad de medida.";
                return -1;
            }

            if (producto.PrecioCosto < 0 || producto.PrecioVenta < 0 ||
                producto.StockActual < 0 || producto.StockMinimo < 0)
            {
                ErrorMessage = "Los precios y las cantidades no pueden ser negativos.";
                return -1;
            }

            if (producto.IdProducto <= 0)
            {
                var nuevo = producto.ToModel();
                nuevo.Activo = true;
                await _context.Productos.AddAsync(nuevo);
            }
            else
            {
                var find = await _context.Productos.FindAsync(producto.IdProducto);
                if (find is null)
                {
                    ErrorMessage = "NO existe el producto con el Id especificado.";
                    return -1;
                }

                find.Nombre = producto.Nombre ?? "";
                find.Codigo = producto.Codigo ?? "";
                find.Descripcion = producto.Descripcion ?? "";
                find.PrecioVenta = producto.PrecioVenta;
                find.PrecioCosto = producto.PrecioCosto;
                find.IdCategoria = producto.IdCategoria;
                find.IdUnidadMedida = producto.IdUnidadMedida;
                find.Inventariable = producto.Inventariable;
                find.StockActual = producto.StockActual;
                find.StockMinimo = producto.StockMinimo;
                find.Activo = producto.Activo ?? find.Activo;
                if (producto.UrlImage is not null)
                    find.UrlImage = producto.UrlImage;

                _context.Productos.Update(find);
            }

            return await _context.SaveChangesAsync();
        }
        catch (Exception e)
        {
            ErrorMessage = e.GetBaseException().Message;
            _logger.Error(e);
            return -1;
        }
    }

    public async Task<int> Delete(ProductoDto? producto)
    {
        ErrorMessage = string.Empty;
        try
        {
            if (producto is null)
            {
                ErrorMessage = "No se puede eliminar un producto nulo";
                return -1;
            }
            var find = await _context.Productos.FindAsync(producto.IdProducto);
            if (find is null)
            {
                ErrorMessage = "No se encontró el producto que se desea eliminar.";
                return -1;
            }
            _context.Productos.Remove(find);
            return await _context.SaveChangesAsync();
        }
        catch (Exception e)
        {
            _logger.Error(e);
            ErrorMessage = e.GetBaseException().Message;
            return -1;
        }
    }

    public async Task<bool> VerificarCodigoAsync(ProductoDto producto)
    {
        var codigo = producto.Codigo?.Trim();
        if (string.IsNullOrWhiteSpace(codigo))
        {
            return false;
        }

        var codigoNormalizado = codigo.ToUpperInvariant();

        return await _context.Productos
            .AsNoTracking()
            .AnyAsync(p => p.Codigo == codigoNormalizado && p.IdProducto != producto.IdProducto);
    }
}
