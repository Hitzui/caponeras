using Caponeras.App.Dto;
using Caponeras.App.Helpers;
using Caponeras.Data.Models;
using Microsoft.EntityFrameworkCore;
using NLog;
using INavigationService = Caponeras.App.Helpers.INavigationService;

namespace Caponeras.App.Services;

public class ComprasService
{
    private readonly DataContextCaponeras _context;
    private INavigationService _navigationService;
    private MaestroCajaService _maestroCajaService;
    private readonly ILogger _logger = LogManager.GetCurrentClassLogger();

    public ComprasService(DataContextCaponeras context, INavigationService navigationService,
        MaestroCajaService maestroCajaService)
    {
        _context = context;
        _navigationService = navigationService;
        _maestroCajaService = maestroCajaService;
    }

    public Task<List<ComprasDto>> Load()
    {
        return _context.Compras.AsNoTracking()
            .Include(c => c.Proveedores)
            .Where(c => c.Estado != EstadoCompra.Anulada)
            .OrderByDescending(c => c.Idcompra)
            .Select(c => new ComprasDto(c))
            .ToListAsync();
    }

    public Task<List<ProductoDto>> GetAllProductos()
    {
        return _context.Productos.AsNoTracking()
            .Include(p => p.UnidadesMedidas)
            .Include(p => p.CategoriasProductos)
            .Where(p => p.Activo == true)
            .Select(p => new ProductoDto(p))
            .ToListAsync();
    }

    public async Task<bool> SaveCompra(
        ComprasDto compraDto,
        ProveedoresDto selectedProveedor,
        List<DetalleCompraDto> detalleCompraDtos,
        TotalesCompras importes)
    {
        ErrorMessage = string.Empty;
        await using var transaction = await _context.Database.BeginTransactionAsync();

        try
        {
            ValidarCompra(compraDto, selectedProveedor, detalleCompraDtos, importes);
            if (compraDto.Idcompra <= 0 && compraDto.Estado != EstadoCompra.Proforma)
                throw new InvalidOperationException("Primero guarde la compra como cotización; luego podrá aprobarla.");
            compraDto.NumeroDocumento = compraDto.NumeroDocumento?.Trim() ?? string.Empty;
            var proveedorValido = await _context.Proveedores
                .AnyAsync(x => x.Idproveedor == selectedProveedor.IdProveedor && x.Activo == true);
            if (!proveedorValido)
                throw new InvalidOperationException("El proveedor seleccionado no existe o está inactivo.");

            var idsProductos = detalleCompraDtos.Select(x => x.Idproducto).Distinct().ToList();
            var productosValidos = await _context.Productos
                .Where(x => idsProductos.Contains(x.IdProducto) && x.Activo == true)
                .Select(x => x.IdProducto)
                .ToListAsync();
            if (productosValidos.Count != idsProductos.Count)
                throw new InvalidOperationException("Uno o más productos no existen o están inactivos.");

            if (compraDto.Idcompra > 0)
            {
                await UpdateCompra(compraDto, selectedProveedor, detalleCompraDtos, importes, _context);
            }
            else
            {
                await AgregarCompra(compraDto, selectedProveedor, detalleCompraDtos, importes, _context);
            }

            await _context.SaveChangesAsync();
            await transaction.CommitAsync();
            return true;
        }
        catch (Exception e)
        {
            await transaction.RollbackAsync();
            _logger.Error(e);
            ErrorMessage = e.GetBaseException().Message;
            return false;
        }
    }

    private static void ValidarCompra(
        ComprasDto compraDto,
        ProveedoresDto selectedProveedor,
        List<DetalleCompraDto> detalleCompraDtos,
        TotalesCompras importes)
    {
        if (compraDto is null || selectedProveedor is null || selectedProveedor.IdProveedor <= 0)
            throw new InvalidOperationException("Seleccione un proveedor para la compra.");
        if (string.IsNullOrWhiteSpace(compraDto.NumeroDocumento) || compraDto.Fecha == default)
            throw new InvalidOperationException("Indique el número de documento y la fecha de la compra.");
        if (detalleCompraDtos is null || detalleCompraDtos.Count == 0)
            throw new InvalidOperationException("La compra debe incluir al menos un producto.");
        if (importes is null || importes.Total <= 0 || importes.SubTotal < 0 || importes.Iva < 0)
            throw new InvalidOperationException("Los totales de la compra no son válidos.");
        if (compraDto.Estado is not (EstadoCompra.Proforma or EstadoCompra.Aprobada))
            throw new InvalidOperationException("Una compra solo puede guardarse como cotización o aprobarse.");
        if (detalleCompraDtos.Any(x => x.Idproducto <= 0 || x.Cantidad <= 0 || x.PrecioUnitario < 0))
            throw new InvalidOperationException("Cada producto debe tener cantidad mayor a cero y precio no negativo.");
        if (detalleCompraDtos.GroupBy(x => x.Idproducto).Any(x => x.Count() > 1))
            throw new InvalidOperationException("No agregue el mismo producto más de una vez; ajuste su cantidad en una sola línea.");

        var subtotalCalculado = detalleCompraDtos.Sum(x => x.Cantidad * x.PrecioUnitario);
        if (Math.Abs(subtotalCalculado - importes.SubTotal) > 0.02m ||
            Math.Abs(importes.SubTotal + importes.Iva - importes.Total) > 0.02m)
            throw new InvalidOperationException("Los totales no coinciden con el detalle de productos.");
    }

    private async Task AgregarCompra(
        ComprasDto compraDto,
        ProveedoresDto selectedProveedor,
        List<DetalleCompraDto> detalleCompraDtos,
        TotalesCompras importes,
        DataContextCaponeras ctx)
    {
        // 1️ Preparar datos de la compra
        var idusuario = _navigationService.CurrentUser.Idusuario;
        var compra = new Compras
        {
            Idproveedor = selectedProveedor.IdProveedor,
            Estado = compraDto.Estado,
            CreatedBy = idusuario,
            CreatedAt = DateTime.Now,
            Iva = importes.Iva,
            Subtotal = importes.SubTotal,
            Total = importes.Total,
            UpdatedBy = idusuario,
            UpdatedAt = DateTime.Now,
            NumeroDocumento = compraDto.NumeroDocumento,
            Frecha = compraDto.Fecha,
        };

        // 2️ Guardar compra primero
        await ctx.Compras.AddAsync(compra);
        // 3 Guardar detalles con FK explícita
        foreach (var detalle in detalleCompraDtos.Select(detalleDto => new DetalleCompras
        {
            Compras = compra,
            Idproducto = detalleDto.Idproducto,
            Cantidad = detalleDto.Cantidad,
            PrecioUnitario = detalleDto.PrecioUnitario,
            Importe = detalleDto.Cantidad * detalleDto.PrecioUnitario
        }))
        {
            await ctx.DetalleCompras.AddAsync(detalle);
        }

        await ctx.SaveChangesAsync();

        if (compraDto.Estado == EstadoCompra.Aprobada)
        {
            await UpsertCuentaPorPagar(compra, selectedProveedor.IdProveedor, importes.Total, ctx);
            await IngresarInventario(detalleCompraDtos, compra.Idcompra, ctx);
        }
    }

    private async Task IngresarInventario(
        List<DetalleCompraDto> detalleCompraDtos,
        int idcompra,
        DataContextCaponeras ctx
    )
    {
        var idusuario = _navigationService.CurrentUser.Idusuario;
        /*
         * nuevo costo = (existencia_actual*costo_actual)+(cantidad_entrada*costo_entrada) / (existencia_actual + cantidad_entrada)
         */
        var idproductos = detalleCompraDtos
            .Select(c => c.Idproducto)
            .Distinct()
            .ToList();

        var productos = await ctx.Productos
            .Where(p => idproductos.Contains(p.IdProducto))
            .ToDictionaryAsync(p => p.IdProducto);

        foreach (var detalle in detalleCompraDtos)
        {
            if (!productos.TryGetValue(detalle.Idproducto, out var producto))
            {
                throw new InvalidOperationException($"No existe el producto con id {detalle.Idproducto}.");
            }

            if (!producto.Inventariable)
                continue;

            if (producto.IdUnidadMedida is null or <= 0)
                throw new InvalidOperationException($"El producto {producto.Nombre} no tiene unidad de medida para registrar inventario.");

            var stockAnterior = producto.StockActual ?? 0m;
            var costoAnterior = producto.PrecioCosto ?? 0m;
            var stockNuevo = stockAnterior + detalle.Cantidad;
            if (stockNuevo <= 0)
                throw new InvalidOperationException($"La cantidad de compra para {producto.Nombre} no es válida.");

            producto.PrecioCosto =
                ((stockAnterior * costoAnterior) + (detalle.Cantidad * detalle.PrecioUnitario)) / stockNuevo;
            producto.StockActual = stockNuevo;

            var movimiento = new MovimientoInventarios
            {
                IdProducto = producto.IdProducto,
                Fecha = DateTime.Now,

                TipoMovimiento = TipoMovimiento.ENTRADA,

                Entrada = detalle.Cantidad,
                Salida = 0,

                StockAnterior = stockAnterior,
                StockNuevo = stockNuevo,

                IdUnidadMedida = producto.IdUnidadMedida.Value,

                ReferenciaTipo = ReferenciaInventario.Compra,
                ReferenciaId = idcompra,
                Observaciones = $"Entrada por compra #{idcompra}",

                CreatedBy = idusuario,
                CreatedAt = DateTime.Now
            };

            await ctx.AddAsync(movimiento);
        }
    }

    private async Task UpsertCuentaPorPagar(
        Compras compra,
        int idProveedor,
        decimal total,
        DataContextCaponeras ctx)
    {
        var idusuario = _navigationService.CurrentUser.Idusuario;
        var cxp = await ctx.TransactionCxps.SingleOrDefaultAsync(x =>
            x.TipoOrigen == (int)EnumTipoCxp.Compras && x.IdOrigen == compra.Idcompra);
        var now = DateTime.Now;

        if (cxp is null)
        {
            cxp = new TransactionCxps
            {
                TipoOrigen = (int)EnumTipoCxp.Compras,
                IdOrigen = compra.Idcompra,
                CreatedAt = now,
                CreatedBy = idusuario
            };
            await ctx.TransactionCxps.AddAsync(cxp);
        }
        else if (await ctx.TransactionDetailCxps.AnyAsync(x => x.IdtrasactionCxp == cxp.IdtransactionCxp))
        {
            throw new InvalidOperationException("La cotización ya tiene pagos registrados y no se puede aprobar desde este flujo.");
        }

        cxp.IdTercero = idProveedor;
        cxp.FechaEmision = compra.Frecha;
        cxp.FechaVencimiento = compra.Frecha.AddDays(30);
        cxp.MontoTotal = total;
        cxp.SaldoPendiente = total;
        cxp.Estado = EstadoCxp.PARCIAL;
        cxp.UpdatedAt = now;
        cxp.UpdatedBy = idusuario;
    }

    private async Task UpdateCompra(
        ComprasDto compraDto,
        ProveedoresDto selectedProveedor,
        List<DetalleCompraDto> detalleCompraDtos,
        TotalesCompras importes,
        DataContextCaponeras ctx)
    {
        var idusuario = _navigationService.CurrentUser.Idusuario;
        var findCompra = await ctx.Compras.Include(c => c.DetalleCompras)
            .SingleOrDefaultAsync(c => c.Idcompra == compraDto.Idcompra);
        if (findCompra == null)
        {
            throw new Exception("No existe la compra a actualziar");
        }

        if (findCompra.Estado != EstadoCompra.Proforma)
        {
            throw new Exception("No se puede modificar una compra que ya ha sido pagada");
        }

        findCompra.Idproveedor = selectedProveedor.IdProveedor;
        findCompra.Iva = importes.Iva;
        findCompra.Subtotal = importes.SubTotal;
        findCompra.Total = importes.Total;
        findCompra.UpdatedAt = DateTime.Now;
        findCompra.UpdatedBy = idusuario;
        findCompra.NumeroDocumento = compraDto.NumeroDocumento;
        findCompra.Frecha = compraDto.Fecha;
        findCompra.Estado = compraDto.Estado;

        // Eliminar detalles removidos
        ctx.RemoveRange(findCompra.DetalleCompras);
        await ctx.AddRangeAsync(detalleCompraDtos.Select(detalleDto => new DetalleCompras
        {
            Idcompra = findCompra.Idcompra,
            Idproducto = detalleDto.Idproducto,
            Cantidad = detalleDto.Cantidad,
            PrecioUnitario = detalleDto.PrecioUnitario,
            Importe = detalleDto.Cantidad * detalleDto.PrecioUnitario
        }));

        if (compraDto.Estado == EstadoCompra.Aprobada)
        {
            await UpsertCuentaPorPagar(findCompra, selectedProveedor.IdProveedor, importes.Total, ctx);
            await IngresarInventario(detalleCompraDtos, compraDto.Idcompra, ctx);
        }
        else
        {
            var cxp = await ctx.TransactionCxps.SingleOrDefaultAsync(c =>
                c.TipoOrigen == (int)EnumTipoCxp.Compras && c.IdOrigen == findCompra.Idcompra);
            if (cxp is not null)
            {
                if (await ctx.TransactionDetailCxps.AnyAsync(x => x.IdtrasactionCxp == cxp.IdtransactionCxp))
                    throw new InvalidOperationException("No se puede volver a cotización una compra con pagos registrados.");
                ctx.TransactionCxps.Remove(cxp);
            }
        }
    }

    public Task<List<DetalleCompraDto>> LoadDetalleCompra(int selectedCompraIdcompra)
    {
        return _context.DetalleCompras.AsNoTracking()
            .Where(dc => dc.Idcompra == selectedCompraIdcompra)
            .Include(dc => dc.Productos)
            .Select(dc => new DetalleCompraDto(dc)).ToListAsync();
    }

    public async Task<bool> Delete(int idcompra)
    {
        ErrorMessage = string.Empty;
        await using var tx = await _context.Database.BeginTransactionAsync();

        try
        {
            var compra = await _context.Compras
                .Include(c => c.DetalleCompras)
                .SingleOrDefaultAsync(c => c.Idcompra == idcompra);

            if (compra is null)
            {
                ErrorMessage = "Compra no encontrada.";
                return false;
            }

            switch (compra.Estado)
            {
                case EstadoCompra.Anulada:
                    ErrorMessage = "La compra ya está anulada.";
                    return false;
                case EstadoCompra.Parcial:
                case EstadoCompra.Pagada:
                    ErrorMessage = "No se puede eliminar una compra que tiene pagos parciales o está pagada.";
                    return false;
                case EstadoCompra.Proforma:
                case EstadoCompra.Aprobada:
                    break;
                default:
                    ErrorMessage = "El estado de la compra no permite anularla.";
                    return false;
            }

            var cxp = await _context.TransactionCxps.SingleOrDefaultAsync(x =>
                x.TipoOrigen == (int)EnumTipoCxp.Compras && x.IdOrigen == compra.Idcompra);
            if (cxp is not null && await _context.TransactionDetailCxps
                    .AnyAsync(x => x.IdtrasactionCxp == cxp.IdtransactionCxp))
            {
                ErrorMessage = "La compra tiene pagos registrados y no puede eliminarse ni revertirse.";
                return false;
            }

            if (compra.Estado == EstadoCompra.Aprobada)
                await RevertirInventarioCompra(compra, _context);

            if (cxp is not null)
            {
                cxp.Estado = EstadoCxp.ANULADA;
                cxp.SaldoPendiente = 0m;
                cxp.UpdatedAt = DateTime.Now;
                cxp.UpdatedBy = _navigationService.CurrentUser.Idusuario;
            }

            compra.Estado = EstadoCompra.Anulada;
            compra.UpdatedAt = DateTime.Now;
            compra.UpdatedBy = _navigationService.CurrentUser.Idusuario;

            await _context.SaveChangesAsync();

            await tx.CommitAsync();

            return true;
        }
        catch (Exception e)
        {
            await tx.RollbackAsync();

            _logger.Error(e);

            ErrorMessage = e.GetBaseException().Message;

            return false;
        }
    }

    private async Task RevertirInventarioCompra(Compras compra, DataContextCaponeras ctx)
    {
        var movimientosEntrada = await ctx.MovimientoInventarios
            .Where(x => x.ReferenciaTipo == ReferenciaInventario.Compra &&
                        x.ReferenciaId == compra.Idcompra &&
                        x.TipoMovimiento == TipoMovimiento.ENTRADA && x.Entrada > 0)
            .ToListAsync();

        if (movimientosEntrada.Count == 0)
        {
            var idsProductos = compra.DetalleCompras.Select(d => d.Idproducto).Distinct().ToList();
            var tieneProductosInventariables = await ctx.Productos
                .Where(p => idsProductos.Contains(p.IdProducto) && p.Inventariable)
                .AnyAsync();
            if (tieneProductosInventariables)
                throw new InvalidOperationException("No se encontró el movimiento de entrada de inventario de esta compra; no se anuló para evitar descuadrar las existencias.");
            return;
        }

        var cantidadesPorProducto = movimientosEntrada
            .GroupBy(x => x.IdProducto)
            .ToDictionary(x => x.Key, x => x.Sum(m => m.Entrada));
        var cantidadesDetalle = compra.DetalleCompras
            .GroupBy(x => x.Idproducto)
            .ToDictionary(x => x.Key, x => x.Sum(d => d.Cantidad));
        var idsDetalle = cantidadesDetalle.Keys.ToList();
        var productosInventariables = await ctx.Productos
            .Where(x => idsDetalle.Contains(x.IdProducto) && x.Inventariable)
            .Select(x => x.IdProducto)
            .ToListAsync();
        foreach (var idProducto in productosInventariables)
        {
            if (!cantidadesPorProducto.TryGetValue(idProducto, out var cantidadEntrada) ||
                !cantidadesDetalle.TryGetValue(idProducto, out var cantidadCompra) ||
                Math.Abs(cantidadEntrada - cantidadCompra) > 0.001m)
                throw new InvalidOperationException($"Los movimientos de inventario de la compra no coinciden con el detalle del producto {idProducto}; no se anuló la compra.");
        }

        var productos = await ctx.Productos
            .Where(x => cantidadesPorProducto.Keys.Contains(x.IdProducto))
            .ToDictionaryAsync(x => x.IdProducto);

        foreach (var (idProducto, cantidad) in cantidadesPorProducto)
        {
            if (!productos.TryGetValue(idProducto, out var producto))
                throw new InvalidOperationException($"No se encontró el producto {idProducto} para revertir el inventario.");

            var stockAnterior = producto.StockActual ?? 0m;
            if (stockAnterior < cantidad)
                throw new InvalidOperationException(
                    $"No se puede revertir la compra: el stock de {producto.Nombre} es {stockAnterior:N2} y la compra aportó {cantidad:N2}. Ajuste primero las existencias.");

            var stockNuevo = stockAnterior - cantidad;
            producto.StockActual = stockNuevo;
            var movimientoOriginal = movimientosEntrada.First(x => x.IdProducto == idProducto);
            await ctx.MovimientoInventarios.AddAsync(new MovimientoInventarios
            {
                IdProducto = idProducto,
                Fecha = DateTime.Now,
                TipoMovimiento = TipoMovimiento.SALIDA,
                Entrada = 0m,
                Salida = cantidad,
                StockAnterior = stockAnterior,
                StockNuevo = stockNuevo,
                IdUnidadMedida = movimientoOriginal.IdUnidadMedida,
                ReferenciaTipo = ReferenciaInventario.Compra,
                ReferenciaId = compra.Idcompra,
                Observaciones = $"Reversión de inventario por anulación de compra #{compra.Idcompra}",
                CreatedBy = _navigationService.CurrentUser.Idusuario,
                CreatedAt = DateTime.Now
            });
        }
    }

    public ComprasDto? PaymentCompra()
    {
        return _navigationService.Query as ComprasDto;
    }

    public TransactionCxpsDto? FindTransactionCxpsByCompra(int comprasDtoIdcompra)
    {
        return _context.TransactionCxps.AsNoTracking()
            .Where(c => c.TipoOrigen == (int)EnumTipoCxp.Compras && c.IdOrigen == comprasDtoIdcompra)
            .Select(c => new TransactionCxpsDto(c)).FirstOrDefault();
    }

    public async Task<bool> ProcesarPagoCompra(ComprasDto comprasDto, TransactionCxpsDto transactionCxpsDto,
        decimal monto)
    {
        ErrorMessage = string.Empty;
        if (monto <= 0m)
        {
            ErrorMessage = "El monto a pagar debe ser mayor a cero.";
            return false;
        }

        await using var tx = await _context.Database.BeginTransactionAsync();
        try
        {
            var param = await _context.Parametros.AsNoTracking().FirstOrDefaultAsync();
            if (param is null)
            {
                ErrorMessage = "No se encontraron los parámetros del sistema. Contacte al administrador.";
                throw new Exception(ErrorMessage);
            }

            var cxpFind = await _context.TransactionCxps
                .SingleOrDefaultAsync(c =>
                    c.IdtransactionCxp == transactionCxpsDto.IdtransactionCxp
                );
            var compra = await _context.Compras.SingleOrDefaultAsync(c => c.Idcompra == comprasDto.Idcompra);
            if (compra is null)
            {
                ErrorMessage = "No se encontró la compra asociada a esta transacción.";
                throw new Exception(ErrorMessage);
            }

            if (compra.Estado == EstadoCompra.Anulada)
            {
                ErrorMessage = "No se puede pagar una compra anulada.";
                throw new Exception(ErrorMessage);
            }

            if (compra.Estado is not (EstadoCompra.Aprobada or EstadoCompra.Parcial))
            {
                ErrorMessage = "Solo se pueden pagar compras aprobadas.";
                throw new Exception(ErrorMessage);
            }

            if (cxpFind is null)
            {
                ErrorMessage = "No se encontró la cuenta por pagar asociada a esta compra.";
                throw new Exception(ErrorMessage);
            }

            if (cxpFind.TipoOrigen != (int)EnumTipoCxp.Compras || cxpFind.IdOrigen != compra.Idcompra)
            {
                ErrorMessage = "La cuenta por pagar seleccionada no corresponde a esta compra.";
                throw new Exception(ErrorMessage);
            }

            if (cxpFind.Estado == EstadoCxp.ANULADA || cxpFind.SaldoPendiente <= 0m)
            {
                ErrorMessage = "La cuenta por pagar está anulada o ya fue pagada completamente.";
                throw new Exception(ErrorMessage);
            }

            var saldoAntesPago = cxpFind.SaldoPendiente;
            if (monto > saldoAntesPago)
            {
                ErrorMessage = "El monto a pagar no puede ser mayor al saldo pendiente.";
                throw new Exception(ErrorMessage);
            }

            cxpFind.SaldoPendiente -= monto;
            if (cxpFind.SaldoPendiente == 0)
            {
                cxpFind.Estado = EstadoCxp.PAGADA;
                compra.Estado = EstadoCompra.Pagada;
            }
            else
            {
                compra.Estado = EstadoCompra.Parcial;
                cxpFind.Estado = EstadoCxp.PARCIAL;
            }

            var now = DateTime.Now;
            var deta = new DetaMovimientosDto
            {
                Fecha = now,
                Concepto = $"Pago a compra con #: {comprasDto.Idcompra}",
                Idmovimiento = param.Compra,
                ReferenciaTipo = "compra",
                ReferenciaId = comprasDto.Idcompra,
                Efectivo = monto
            };
            var detaMovimiento = await _maestroCajaService.RealizarMovimientoAndGetDetaMovimiento(deta, _context, false);
            if (detaMovimiento is null)
            {
                ErrorMessage = _maestroCajaService.ErrorMessage;
                throw new Exception(ErrorMessage);
            }

            var detailTransaction = new TransactionDetailCxps
            {
                IdtrasactionCxp = cxpFind.IdtransactionCxp,
                Fecha = now,
                Monto = monto,
                Saldo = saldoAntesPago,
                DetaMovimientos = detaMovimiento,
            };

            await _context.AddAsync(detailTransaction);

            await _context.SaveChangesAsync();
            await tx.CommitAsync();
            return true;
        }
        catch (Exception e)
        {
            ErrorMessage = e.GetBaseException().Message;
            _logger.Error(e);
            await tx.RollbackAsync();
            return false;
        }
    }

    public string ErrorMessage { get; private set; } = string.Empty;
}
