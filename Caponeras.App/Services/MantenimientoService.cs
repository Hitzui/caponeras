using Caponeras.App.Dto;
using Caponeras.App.Helpers;
using Caponeras.Data.Models;
using DevExpress.XtraScheduler;
using Microsoft.EntityFrameworkCore;
using NLog;
using System.Data;

namespace Caponeras.App.Services;

public class MantenimientoService
{
    private readonly ILogger _logger = LogManager.GetCurrentClassLogger();
    private INavigationService _navigationService;
    private DataContextCaponeras _context;
    private MaestroCajaService _maestroCajaService;

    public string ErrorMessage { get; private set; } = string.Empty;

    public MantenimientoService(
        DataContextCaponeras context,
        INavigationService navigationService,
        MaestroCajaService maestroCajaService)
    {
        _context = context;
        _navigationService = navigationService;
        _maestroCajaService = maestroCajaService;
    }

    public Task<List<ManoObraProveedorDto>> GetManoObraProveedoresTask(int idmantenimiento)
    {
        return _context.ManoObras.AsNoTracking()
            .Include(mp => mp.MantenimientoProveedors)
            .Join(_context.TransactionCxps, mp => mp.IdManoObra, cxp => cxp.IdOrigen, (mp, cxp) => new { mp, cxp })
            .Where(x => x.mp.MantenimientoProveedors.Idmantenimiento == idmantenimiento &&
                        x.cxp.TipoOrigen == (int)EnumTipoCxp.ManoObra && x.cxp.Estado == EstadoCxp.PARCIAL)
            .Select(x => new ManoObraProveedorDto(
                x.mp.IdManoObra,
                x.mp.MantenimientoProveedors.Idproveedor,
                x.mp.MantenimientoProveedors.Proveedores.Nombre,
                x.mp.DescripcionTrabajo,
                x.mp.Estado,
                x.mp.Monto,
                x.mp.Observaciones,
                x.mp.Fecha,
                x.cxp.SaldoPendiente,
                x.cxp.IdtransactionCxp
            ))
            .ToListAsync();
    }

    public Task<List<ProveedoresDto>> GetProveedoresMantenimiento(int idmantenimiento)
    {
        return _context.ProveedoresManoObras.AsNoTracking()
            .Where(mp => mp.Idmantenimiento == idmantenimiento)
            .Select(mp => ProveedoresDto.FromView(mp))
            .ToListAsync();
    }

    public Task<List<ProveedoresDto>> GetProveedoresAll()
    {
        return _context.Proveedores.AsNoTracking()
            .Where(p => p.Activo == true)
            .Select(p => ProveedoresDto.FromEntity(p))
            .ToListAsync();
    }


    public Task<List<MantenimientoLabelDto>> GetMantenimientoLabel()
    {
        return _context.MantenimientoLabels.AsNoTracking()
            .Select(ml =>
                new MantenimientoLabelDto(ml.Id, ColorTranslator.FromHtml(ml.Color), ml.DisplayName, ml.MenuCaption))
            .ToListAsync();
    }

    public Task<List<MantenimientoStatusDto>> GetMantenimientoStatus()
    {
        return _context.MantenimientoStatuses.AsNoTracking()
            .Select(ms => new MantenimientoStatusDto(ms.Id, ms.DisplayName, ColorTranslator.FromHtml(ms.Brush),
                ms.MenuCaption, ms.AllowDrag))
            .ToListAsync();
    }

    public Task<List<TipoMantenimientoDto>> GetAllTipoMantenimiento()
    {
        return _context.TipoMantenimientos.AsNoTracking()
            .Select(tm => new TipoMantenimientoDto
            {
                Idtipomantenimiento = tm.IdtipoMantenimiento,
                Nombre = tm.Nombre,
                Tipo = tm.Tipo,
                FrecuenciaKm = tm.FrecuenciaKm,
                FrecuenciaMeses = tm.FrecuenciaMeses,
                Descripcion = tm.Descripcion
            }).ToListAsync();
    }

    public Task<List<MantenimientoDto>> GetAllMantenimientos()
    {
        return _context.Mantenimientos.AsNoTracking()
            .Include(m => m.TipoMantenimientos)
            .Include(m => m.MantenimientoLabels)
            .Include(m => m.MantenimientoStatuses)
            .Select(m => new MantenimientoDto(m)).ToListAsync();
    }

    public async Task<int> Save(MantenimientoDto mantenimiento, VehiculosDto? vehiculoDto)
    {
        ErrorMessage = string.Empty;
        try
        {
            if (string.IsNullOrWhiteSpace(mantenimiento.Titulo) || mantenimiento.Idtipomantenimiento <= 0 ||
                mantenimiento.FechaFin <= mantenimiento.FechaInicio)
            {
                ErrorMessage = "Indique el tipo, título y un intervalo de fechas válido para el mantenimiento.";
                return -1;
            }

            var estadoSolicitado = await _context.MantenimientoStatuses
                .AsNoTracking()
                .SingleOrDefaultAsync(s => s.Id == mantenimiento.Idstatus);
            if (estadoSolicitado is { AllowDrag: false })
            {
                if (mantenimiento.Idmantenimiento <= 0)
                {
                    ErrorMessage = "Primero programe el mantenimiento y asígnele un proveedor antes de marcarlo como completado.";
                    return -1;
                }

                var tieneProveedorActivo = await _context.MantenimientoProveedors
                    .AnyAsync(mp => mp.Idmantenimiento == mantenimiento.Idmantenimiento &&
                                    mp.ManoObras.Any(mo => mo.Estado != TipoManoObra.Anulada));
                if (!tieneProveedorActivo)
                {
                    ErrorMessage = "Asigne un proveedor y registre la mano de obra antes de completar el mantenimiento.";
                    return -1;
                }
            }

            if (mantenimiento.Idmantenimiento <= 0)
            {
                if (vehiculoDto is null || vehiculoDto.Idvehiculo <= 0)
                {
                    ErrorMessage = "No se puede crear un mantenimiento sin un vehículo asociado.";
                    return -1;
                }

                mantenimiento.Idvehiculo = vehiculoDto.Idvehiculo;
                mantenimiento.Titulo = mantenimiento.Titulo.Trim();
                mantenimiento.Descripcion ??= string.Empty;
                mantenimiento.Observaciones ??= string.Empty;
                mantenimiento.CreatedAt = DateTime.Now;
                mantenimiento.UpdatedAt = DateTime.Now;
                await _context.AddAsync(mantenimiento.Model());
            }
            else
            {
                var find = await _context.Mantenimientos
                    .Include(m => m.MantenimientoStatuses)
                    .SingleOrDefaultAsync(m => m.Idmantenimineto == mantenimiento.Idmantenimiento);
                if (find is null)
                {
                    ErrorMessage = "No se encontró el mantenimiento.";
                    return -1;
                }

                if (find.MantenimientoStatuses is { AllowDrag: false })
                {
                    ErrorMessage = "No se puede editar un mantenimiento completado.";
                    return -1;
                }

                find.Titulo = mantenimiento.Titulo.Trim();
                find.Descripcion = mantenimiento.Descripcion ?? string.Empty;
                find.Idlabel = mantenimiento.Idlabel;
                find.Idstatus = mantenimiento.Idstatus;
                find.FechaFin = mantenimiento.FechaFin;
                find.FechaInicio = mantenimiento.FechaInicio;
                find.Observaciones = mantenimiento.Observaciones ?? string.Empty;
                find.Idtipomantenimiento = mantenimiento.Idtipomantenimiento;
                find.UpdatedAt = DateTime.Now;
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

    public async Task<bool> AllowDragAndDrop(Appointment eAppointment)
    {
        await using var ctx = new DataContextCaponeras();
        var find = await ctx.Mantenimientos.AsNoTracking()
            .Include(m => m.MantenimientoStatuses)
            .SingleOrDefaultAsync(m => m.Idmantenimineto == (int)eAppointment.Id);
        return find is not null && find.MantenimientoStatuses.AllowDrag;
    }

    public async Task<MantenimientoStatusDto?> FindStatus(int aptStatusKey)
    {
        var find = await _context.MantenimientoStatuses.FindAsync(aptStatusKey);
        if (find is null)
        {
            return null;
        }

        return new MantenimientoStatusDto(find.Id, find.DisplayName, ColorTranslator.FromHtml(find.Brush),
            find.MenuCaption, find.AllowDrag);
    }

    public async Task<MantenimientoDto?> FindMantenimiento(int id)
    {
        try
        {
            var find = await _context.Mantenimientos
                .Include(m => m.Vehiculos)
                .Include(m => m.MantenimientoStatuses)
                .Include(m => m.MantenimientoLabels)
                .SingleOrDefaultAsync(m => m.Idmantenimineto == id);
            return find is null ? null : new MantenimientoDto(find);
        }
        catch (Exception e)
        {
            _logger.Error(e);
            return null;
        }
    }

    public async Task<int> DeleteCita(Appointment apt)
    {
        ErrorMessage = string.Empty;
        await using var transaction = await _context.Database.BeginTransactionAsync(IsolationLevel.Serializable);

        try
        {
            var mantenimiento = await _context.Mantenimientos
                .Include(m => m.MantenimientoStatuses)
                .SingleOrDefaultAsync(m => m.Idmantenimineto == (int)apt.Id);

            if (mantenimiento is null)
            {
                ErrorMessage = "No se encontró el mantenimiento.";
                return -1;
            }

            if (mantenimiento.MantenimientoStatuses is { AllowDrag: false })
                throw new InvalidOperationException("No se puede eliminar un mantenimiento completado.");

            var idProveedores = await _context.MantenimientoProveedors
                .Where(mp => mp.Idmantenimiento == mantenimiento.Idmantenimineto)
                .Select(mp => mp.IdmantenimientoProveedor)
                .ToListAsync();
            var manoObra = await _context.ManoObras
                .Where(mo => mo.IdmantenimientoProveedor != null && idProveedores.Contains(mo.IdmantenimientoProveedor.Value))
                .ToListAsync();
            var idManoObra = manoObra.Select(mo => mo.IdManoObra).ToList();
            var cxps = await _context.TransactionCxps
                .Where(cxp => cxp.TipoOrigen == (int)EnumTipoCxp.ManoObra && idManoObra.Contains(cxp.IdOrigen))
                .ToListAsync();
            var comprasExternas = await _context.Compras
                .Include(c => c.DetalleCompras)
                .Where(c => c.NumeroDocumento.StartsWith($"MANT-{mantenimiento.Idmantenimineto}-"))
                .ToListAsync();
            var idsComprasExternas = comprasExternas.Select(c => c.Idcompra).ToList();
            var cxpsComprasExternas = await _context.TransactionCxps
                .Where(cxp => cxp.TipoOrigen == (int)EnumTipoCxp.Compras && idsComprasExternas.Contains(cxp.IdOrigen))
                .ToListAsync();
            var idCxp = cxps.Select(cxp => cxp.IdtransactionCxp)
                .Concat(cxpsComprasExternas.Select(cxp => cxp.IdtransactionCxp))
                .ToList();
            if (await _context.TransactionDetailCxps.AnyAsync(detail =>
                    detail.IdtrasactionCxp != null && idCxp.Contains(detail.IdtrasactionCxp.Value)))
                throw new InvalidOperationException("No se puede eliminar el mantenimiento porque ya se pagó mano de obra o un producto suministrado por el proveedor.");

            var repuestos = await _context.MantenimientoRepuestos
                .Where(mr => mr.Idmantenimiento == mantenimiento.Idmantenimineto)
                .ToListAsync();

            foreach (var item in repuestos)
            {
                var inventariable = await _context.Productos
                    .AnyAsync(p => p.IdProducto == item.Idproducto && p.Inventariable);
                if (!inventariable) continue;

                await RegistrarMovimientoAsync(
                    item.Idproducto,
                    TipoMovimiento.ENTRADA,
                    item.Cantidad,
                    item.IdUnidadMedida,
                    ReferenciaInventario.Mantenimiento,
                    mantenimiento.Idmantenimineto,
                    $"Reversión de repuesto por eliminación del mantenimiento #{mantenimiento.Idmantenimineto}");
            }

            _context.RemoveRange(repuestos);
            _context.RemoveRange(cxps);
            _context.RemoveRange(cxpsComprasExternas);
            foreach (var compraExterna in comprasExternas)
                _context.RemoveRange(compraExterna.DetalleCompras);
            _context.RemoveRange(comprasExternas);
            _context.RemoveRange(manoObra);
            var proveedoresMantenimiento = await _context.MantenimientoProveedors
                .Where(mp => mp.Idmantenimiento == mantenimiento.Idmantenimineto)
                .ToListAsync();
            _context.RemoveRange(proveedoresMantenimiento);
            _context.Remove(mantenimiento);

            await _context.SaveChangesAsync();
            await transaction.CommitAsync();

            return 1;
        }
        catch (Exception ex)
        {
            await transaction.RollbackAsync();
            _logger.Error(ex);
            ErrorMessage = ex.GetBaseException().Message;
            return -99;
        }
    }


    public Task<List<MantenimientoRepuestoDto>> GetRepuestosByMantenimientoId(int idmantenimiento)
    {
        return _context.MantenimientoRepuestos
            .Include(mr => mr.Productos)
            .Include(mr => mr.UnidadesMedidas)
            .Where(mr => mr.Idmantenimiento == idmantenimiento)
            .Select(mr => new MantenimientoRepuestoDto
            {
                IdMantenimientoRepuestos = mr.Idmantenimientorepuestos,
                IdMantenimiento = mr.Idmantenimiento,
                IdProducto = mr.Idproducto,
                Cantidad = mr.Cantidad,
                IdUnidadMedida = mr.IdUnidadMedida,
                Observaciones = mr.Observaciones,
                ProductoNombre = mr.Productos.Nombre,
                UnidadMedidaNombre = mr.UnidadesMedidas.Nombre,
                UnidadMedidaSimbolo = mr.UnidadesMedidas.Simbolo,
                StockDisponible = mr.Productos.StockActual
            })
            .ToListAsync();
    }

    /// <summary>
    /// Este metodo registra el movimiento de invetario conforme el mantenimiento, dando salida a los <b>productos</b>
    /// </summary>
    /// <param name="appointment">Mantenimiento</param>
    /// <param name="repuestos">Lista de repuestos asociados al mantenimiento</param>
    /// <returns>Retorna un entero indicando el resultado de la operación</returns>
    public async Task<int> SaveRepuestos(Appointment appointment, List<MantenimientoRepuestoDto> repuestos)
    {
        ErrorMessage = string.Empty;
        await using var transaction = await _context.Database.BeginTransactionAsync(IsolationLevel.Serializable);

        try
        {
            var mantenimiento = await _context.Mantenimientos.FindAsync((int)appointment.Id);

            if (mantenimiento is null)
            {
                ErrorMessage = "No se encontró el mantenimiento.";
                return -1;
            }

            var status = await _context.MantenimientoStatuses
                .AsNoTracking()
                .SingleOrDefaultAsync(s => s.Id == mantenimiento.Idstatus);
            if (status is { AllowDrag: false })
                throw new InvalidOperationException("No se pueden modificar los repuestos de un mantenimiento completado.");

            if (repuestos.Any(x => x.Cantidad <= 0 || x.IdProducto <= 0 || x.IdUnidadMedida <= 0))
                throw new InvalidOperationException("Cada repuesto debe tener producto, unidad de medida y cantidad mayor a cero.");
            if (repuestos.GroupBy(x => x.IdProducto).Any(x => x.Count() > 1))
                throw new InvalidOperationException("No agregue el mismo producto más de una vez.");

            var idsProductos = repuestos.Select(x => x.IdProducto).Distinct().ToList();
            var productos = await _context.Productos
                .Where(p => idsProductos.Contains(p.IdProducto) && p.Activo == true)
                .ToDictionaryAsync(p => p.IdProducto);
            if (productos.Count != idsProductos.Count)
                throw new InvalidOperationException("Uno o más productos del detalle no existen o están inactivos.");

            var repuestosAnteriores = await _context.MantenimientoRepuestos
                .Where(mr => mr.Idmantenimiento == mantenimiento.Idmantenimineto)
                .ToListAsync();
            foreach (var item in repuestosAnteriores)
            {
                var producto = await _context.Productos.FindAsync(item.Idproducto);
                if (producto?.Inventariable != true) continue;

                await RegistrarMovimientoAsync(item.Idproducto, TipoMovimiento.ENTRADA, item.Cantidad,
                    item.IdUnidadMedida, ReferenciaInventario.Mantenimiento, mantenimiento.Idmantenimineto,
                    $"Reversión por actualización de repuestos del mantenimiento #{mantenimiento.Idmantenimineto}");
            }

            _context.RemoveRange(repuestosAnteriores);

            foreach (var dto in repuestos)
            {
                var producto = productos[dto.IdProducto];
                dto.IdMantenimiento = mantenimiento.Idmantenimineto;
                if (producto.Inventariable)
                {
                    if (producto.IdUnidadMedida != dto.IdUnidadMedida)
                        throw new InvalidOperationException($"La unidad de medida no corresponde al producto {producto.Nombre}.");

                    await RegistrarMovimientoAsync(dto.IdProducto, TipoMovimiento.SALIDA, dto.Cantidad,
                        dto.IdUnidadMedida, ReferenciaInventario.Mantenimiento, mantenimiento.Idmantenimineto,
                        $"Salida por mantenimiento #{mantenimiento.Idmantenimineto}");
                }

                await _context.AddAsync(dto.ToModel());
            }

            await _context.SaveChangesAsync();
            await transaction.CommitAsync();

            return 1;
        }
        catch (Exception ex)
        {
            await transaction.RollbackAsync();
            _logger.Error(ex);
            ErrorMessage = ex.GetBaseException().Message;
            return -99;
        }
    }

    public async Task RegistrarMovimientoAsync(
        int idProducto,
        TipoMovimiento tipo,
        decimal cantidad,
        int idUnidadMedida,
        ReferenciaInventario referenciaTipo,
        int? referenciaId,
        string? observaciones = null)
    {
        var producto = await _context.Productos.FindAsync(idProducto);

        if (producto is null)
            throw new Exception("Producto no encontrado");
        if (!producto.Inventariable)
            throw new InvalidOperationException($"El producto {producto.Nombre} no controla existencias; no se debe registrar un movimiento de bodega.");
        if (cantidad <= 0 || idUnidadMedida <= 0)
            throw new InvalidOperationException("La cantidad y unidad de medida del movimiento deben ser válidas.");

        var entrada = 0m;
        var salida = 0m;
        var stockAnterior = 0m;
        var stockNuevo = 0m;
        switch (tipo)
        {
            case TipoMovimiento.SALIDA:
                {
                    if (producto.Inventariable)
                    {
                        if (producto.StockActual < cantidad)
                            throw new Exception("Stock insuficiente");

                        stockAnterior = producto.StockActual ?? 0m;
                        producto.StockActual -= cantidad;
                        stockNuevo = producto.StockActual ?? 0m;
                        salida = cantidad;
                    }

                    break;
                }
            case TipoMovimiento.ENTRADA:
                stockAnterior = producto.StockActual ?? 0m;
                producto.StockActual += cantidad;
                stockNuevo = producto.StockActual ?? 0m;
                entrada = cantidad;
                break;
            case TipoMovimiento.AJUSTE:
                break;
            default:
                throw new Exception("No existe el tipo de de movimiento en inventario, indicar si es salida o entrada");
        }

        var movimientoDto = new MovimientoInventarioDto
        {
            IdProducto = idProducto,
            Fecha = DateTime.Now,
            TipoMovimiento = tipo,
            Entrada = entrada,
            Salida = salida,
            IdUnidadMedida = idUnidadMedida,
            ReferenciaTipo = referenciaTipo,
            ReferenciaId = referenciaId,
            Observaciones = observaciones ?? string.Empty,
            StockAnterior = stockAnterior,
            StockNuevo = stockNuevo,
            CreatedAt = DateTime.Now,
            CreatedBy = _navigationService.CurrentUser.Idusuario
        };

        await _context.AddAsync(movimientoDto.ToModel());
    }

    public async Task<int> SaveMantenimientoProveedores(
        List<ProveedoresDto> proveedoresSeleccionados,
        int idMantenimiento)
    {
        ErrorMessage = string.Empty;
        await using var tx = await _context.Database.BeginTransactionAsync();
        try
        {
            if (proveedoresSeleccionados.Any(p => p.IdProveedor <= 0 || p.MontoManoObra <= 0))
                throw new InvalidOperationException("Seleccione proveedores válidos e indique un monto de mano de obra mayor a cero.");
            if (proveedoresSeleccionados.GroupBy(p => p.IdProveedor).Any(g => g.Count() > 1))
                throw new InvalidOperationException("No se puede asignar dos veces el mismo proveedor al mantenimiento.");

            var mantenimiento = await _context.Mantenimientos
                .FirstOrDefaultAsync(m => m.Idmantenimineto == idMantenimiento);

            if (mantenimiento is null)
                throw new Exception("Mantenimiento no encontrado");

            var idsProveedores = proveedoresSeleccionados.Select(p => p.IdProveedor).Distinct().ToList();
            var proveedoresActivos = await _context.Proveedores
                .Where(p => idsProveedores.Contains(p.Idproveedor) && p.Activo == true)
                .Select(p => p.Idproveedor)
                .ToListAsync();
            if (proveedoresActivos.Count != idsProveedores.Count)
                throw new InvalidOperationException("Uno o más proveedores no existen o están inactivos.");

            var parametros = await _context.Parametros.AsNoTracking().FirstOrDefaultAsync();
            if (parametros is null) throw new Exception("Parámetros no encontrados");

            var idMantenimientoProveedores = proveedoresSeleccionados.Select(p => p.IdMantenimientoProveedor);
            var mantenimientoProveedoresExistentes = await _context.Manoobraproveedorcxpviews
                .Where(mp =>
                    mp.Idmantenimiento == idMantenimiento &&
                    !idMantenimientoProveedores.Contains(mp.IdmantenimientoProveedor))
                .ToListAsync();

            foreach (var existente in mantenimientoProveedoresExistentes)
            {
                var mo = await _context.ManoObras.FindAsync(existente.IdManoObra);
                if (mo is null) continue;
                mo.Estado = TipoManoObra.Anulada;
                _context.ManoObras.Update(mo);
                var cxp = await _context.TransactionCxps
                    .FirstOrDefaultAsync(x => x.IdtransactionCxp == existente.IdtransactionCxp);

                if (cxp != null)
                {
                    cxp.Estado = EstadoCxp.ANULADA;
                    cxp.SaldoPendiente = 0;
                    cxp.UpdatedAt = DateTime.Now;
                    cxp.UpdatedBy = _navigationService.CurrentUser.Idusuario;
                    _context.TransactionCxps.Update(cxp);
                }

                //si la diferencia entre el monto y el saldo es distinto regresar el dinero a caja
                if (existente.MontoTotal == existente.SaldoPendiente) continue;
                var deta = new DetaMovimientosDto
                {
                    Fecha = DateTime.Now,
                    Concepto = "Devolución de dinero por mano de obra anulada",
                    Idmovimiento = parametros.AnulacionManoObra,
                    ReferenciaTipo = ReferenciaMovimiento.ManoObra,
                    ReferenciaId = mo.IdManoObra,
                    Efectivo = existente.MontoTotal - existente.SaldoPendiente,
                    Transferencia = 0,
                    Tipocambio = 1,
                    CreatedBy = _navigationService.CurrentUser.Idusuario,
                    CreatedAt = DateTime.Now,
                    UpdatedBy = _navigationService.CurrentUser.Idusuario,
                    UpdatedAt = DateTime.Now
                };
                var movimiento = await _maestroCajaService.RealizarMovimientoAndGetDetaMovimiento(deta, _context);
                if (movimiento is null) throw new Exception(_maestroCajaService.ErrorMessage);
            }

            foreach (var proveedorDto in proveedoresSeleccionados)
            {
                if (proveedorDto.IdMantenimientoProveedor == 0)
                {
                    var mantenimientoProveedor = new MantenimientoProveedors
                    {
                        IdmantenimientoProveedor = 0,
                        Idmantenimiento = idMantenimiento,
                        Idproveedor = proveedorDto.IdProveedor,
                        FechaInicio = DateTime.Now,
                        FechaFin = mantenimiento.FechaFin,
                        Observaciones = string.Empty,
                    };
                    _context.MantenimientoProveedors.Add(mantenimientoProveedor);
                    //await _context.SaveChangesAsync();
                    var manoObraNueva = new ManoObras
                    {
                        IdManoObra = 0,
                        DescripcionTrabajo = "Mano de obra",
                        Estado = TipoManoObra.Pendiente,
                        Observaciones = string.Empty,
                        Monto = proveedorDto.MontoManoObra,
                        Fecha = DateTime.Now,
                        IdUsuario = _navigationService.CurrentUser.Idusuario,
                        MantenimientoProveedors = mantenimientoProveedor,
                        CreatedAt = DateTime.Now,
                    };
                    _context.ManoObras.Add(manoObraNueva);
                    await _context.SaveChangesAsync();
                    var cxpNew = new TransactionCxps
                    {
                        IdtransactionCxp = 0,
                        IdOrigen = manoObraNueva.IdManoObra,
                        IdTercero = proveedorDto.IdProveedor,
                        TipoOrigen = (int)EnumTipoCxp.ManoObra,
                        MontoTotal = manoObraNueva.Monto,
                        SaldoPendiente = manoObraNueva.Monto,
                        Estado = EstadoCxp.PARCIAL,
                        FechaEmision = DateTime.Now,
                        FechaVencimiento = mantenimiento.FechaFin,
                        CreatedAt = DateTime.Now,
                        UpdatedAt = DateTime.Now,
                        CreatedBy = _navigationService.CurrentUser.Idusuario,
                        UpdatedBy = _navigationService.CurrentUser.Idusuario
                    };
                    _context.TransactionCxps.Add(cxpNew);
                }
                else
                {
                    var findCxp = await _context.Manoobraproveedorcxpviews
                        .SingleOrDefaultAsync(c => c.IdmantenimientoProveedor == proveedorDto.IdMantenimientoProveedor);
                    if (findCxp is null) continue;
                    var findManoObras = await _context.ManoObras.FindAsync(findCxp.IdManoObra);
                    if (findManoObras is null) continue;
                    if (proveedorDto.MontoManoObra == findCxp.MontoTotal) continue;
                    var cxp = await _context.TransactionCxps
                        .FirstOrDefaultAsync(x => x.IdtransactionCxp == findCxp.IdtransactionCxp);
                    if (cxp is null) continue;
                    if (cxp.Estado != EstadoCxp.PARCIAL)
                        throw new InvalidOperationException("No se puede modificar el monto de una mano de obra que ya está pagada o anulada.");
                    var nuevoMonto = proveedorDto.MontoManoObra;
                    var diferencia = nuevoMonto - cxp.MontoTotal;
                    var montoPagado = cxp.MontoTotal - cxp.SaldoPendiente;
                    findManoObras.Monto = nuevoMonto;
                    if (diferencia > 0)
                    {
                        cxp.SaldoPendiente += diferencia;
                    }
                    else
                    {
                        var montoADevolver = Math.Max(0m, montoPagado - nuevoMonto);
                        if (montoADevolver > 0m)
                        {
                            var deta = new DetaMovimientosDto
                            {
                                Fecha = DateTime.Now,
                                Concepto = "Devolución por ajuste de mano de obra",
                                Idmovimiento = parametros.AnulacionManoObra,
                                ReferenciaTipo = ReferenciaMovimiento.ManoObra,
                                ReferenciaId = findCxp.IdManoObra,
                                Efectivo = montoADevolver,
                                Transferencia = 0,
                                Tipocambio = 1,
                                CreatedBy = _navigationService.CurrentUser.Idusuario,
                                CreatedAt = DateTime.Now,
                                UpdatedBy = _navigationService.CurrentUser.Idusuario,
                                UpdatedAt = DateTime.Now
                            };

                            var devolucion = await _maestroCajaService.RealizarMovimientoAndGetDetaMovimiento(deta, _context);
                            if (devolucion is null)
                                throw new InvalidOperationException(_maestroCajaService.ErrorMessage);
                        }
                        cxp.SaldoPendiente = Math.Max(0m, nuevoMonto - (montoPagado - montoADevolver));
                    }

                    cxp.MontoTotal = nuevoMonto;
                    cxp.Estado = cxp.SaldoPendiente == 0m ? EstadoCxp.PAGADA : EstadoCxp.PARCIAL;
                    findManoObras.Estado = cxp.SaldoPendiente == 0m ? TipoManoObra.Pagada : TipoManoObra.Pendiente;
                    cxp.UpdatedAt = DateTime.Now;
                    cxp.UpdatedBy = _navigationService.CurrentUser.Idusuario;
                }
            }

            var result = await _context.SaveChangesAsync();

            await tx.CommitAsync();

            return result;
        }
        catch (Exception ex)
        {
            ErrorMessage = ex.GetBaseException().Message;
            await tx.RollbackAsync();
            _logger.Error(ex);
            return -1;
        }
    }

    public async Task<int> SaveManoObra(List<ManoObraProveedorDto> manoObraDtos)
    {
        ErrorMessage = string.Empty;
        await using var tx = await _context.Database.BeginTransactionAsync(IsolationLevel.Serializable);

        try
        {
            if (manoObraDtos.Any(x => x.MontoAplicar < 0))
                throw new InvalidOperationException("El monto del pago no puede ser negativo.");
            if (manoObraDtos.Where(x => x.MontoAplicar > 0).GroupBy(x => x.IdTransactionCxp).Any(g => g.Count() > 1))
                throw new InvalidOperationException("La misma cuenta por pagar aparece más de una vez en el pago.");

            var param = await _context.Parametros.FirstOrDefaultAsync();
            if (param is null)
                throw new Exception("Parámetros no encontrados");

            var cxpIds = manoObraDtos.Select(x => x.IdTransactionCxp).Distinct();
            var moIds = manoObraDtos.Select(x => x.IdManoObra).Distinct();

            var cxps = await _context.TransactionCxps
                .Where(x => cxpIds.Contains(x.IdtransactionCxp))
                .ToDictionaryAsync(x => x.IdtransactionCxp);

            var manosObra = await _context.ManoObras
                .Where(x => moIds.Contains(x.IdManoObra))
                .ToDictionaryAsync(x => x.IdManoObra);

            foreach (var dto in manoObraDtos.Where(dto => dto.MontoAplicar > 0))
            {
                if (!cxps.TryGetValue(dto.IdTransactionCxp, out var cxp))
                    throw new Exception("CXP no encontrado");

                if (!manosObra.TryGetValue(dto.IdManoObra, out var mo))
                    throw new Exception("Mano de obra no encontrada");

                var montoAplicar = dto.MontoAplicar;
                if (montoAplicar <= 0)
                    throw new InvalidOperationException("El monto a pagar debe ser mayor a cero.");

                if (cxp.TipoOrigen != (int)EnumTipoCxp.ManoObra || cxp.IdOrigen != mo.IdManoObra ||
                    cxp.Estado == EstadoCxp.ANULADA || mo.Estado == TipoManoObra.Anulada)
                    throw new InvalidOperationException("La cuenta por pagar no corresponde a una mano de obra vigente.");
                if (cxp.SaldoPendiente <= 0)
                    throw new InvalidOperationException("La mano de obra ya está pagada completamente.");

                if (montoAplicar > cxp.SaldoPendiente)
                    throw new InvalidOperationException("El monto a aplicar no puede ser mayor al saldo pendiente.");

                var saldoAntesPago = cxp.SaldoPendiente;
                var saldoDespuesPago = saldoAntesPago - montoAplicar;
                var concepto = saldoDespuesPago <= 0
                    ? $"Cancelación a mano de obra: #{mo.IdManoObra}"
                    : $"Abono a mano de obra: #{mo.IdManoObra}";

                var detaMovimiento = new DetaMovimientosDto
                {
                    Fecha = DateTime.Now,
                    Concepto = concepto,
                    Idmovimiento = param.AjusteManoObra,
                    ReferenciaTipo = ReferenciaMovimiento.ManoObra,
                    ReferenciaId = mo.IdManoObra,
                    Efectivo = montoAplicar,
                    Transferencia = 0,
                    Tipocambio = 1,
                    CreatedBy = _navigationService.CurrentUser.Idusuario,
                    CreatedAt = DateTime.Now,
                    UpdatedBy = _navigationService.CurrentUser.Idusuario,
                    UpdatedAt = DateTime.Now
                };

                var detaMovimientoIngresado =
                    await _maestroCajaService.RealizarMovimientoAndGetDetaMovimiento(detaMovimiento, _context, false)
                    ?? throw new Exception(_maestroCajaService.ErrorMessage);

                // La CxP solo se modifica después de confirmar que la caja aceptó el movimiento.
                cxp.SaldoPendiente = saldoDespuesPago;
                cxp.Estado = saldoDespuesPago == 0m ? EstadoCxp.PAGADA : EstadoCxp.PARCIAL;
                cxp.UpdatedAt = DateTime.Now;
                cxp.UpdatedBy = _navigationService.CurrentUser.Idusuario;
                if (saldoDespuesPago == 0m)
                    mo.Estado = TipoManoObra.Pagada;

                var detailCxp = new TransactionDetailCxps
                {
                    IdtrasactionCxp = cxp.IdtransactionCxp,
                    Fecha = DateTime.Now,
                    Monto = montoAplicar,
                    DetaMovimientos = detaMovimientoIngresado,
                    MetodoPago = "Efectivo",
                    Saldo = saldoAntesPago
                };

                await _context.AddAsync(detailCxp);
            }

            var save = await _context.SaveChangesAsync();
            await tx.CommitAsync();

            return save;
        }
        catch (Exception e)
        {
            await tx.RollbackAsync();
            // EF conserva en memoria cambios que la transacción ya revirtió en MySQL.
            // Limpiar el seguimiento evita que un nuevo intento lea el saldo fallido.
            _context.ChangeTracker.Clear();
            ErrorMessage = e.GetBaseException().Message;
            _logger.Error(e);
            return -1;
        }
    }
}
