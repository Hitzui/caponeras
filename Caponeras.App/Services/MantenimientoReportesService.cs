using Caponeras.App.Dto;
using Caponeras.App.Helpers;
using Caponeras.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Caponeras.App.Services;

public sealed class MantenimientoReportesService(DataContextCaponeras context)
{
    public async Task<List<ReporteMantenimientoDto>> ObtenerRealizadosAsync(DateTime fechaInicio, DateTime fechaFin)
    {
        fechaInicio = fechaInicio.Date;
        fechaFin = fechaFin.Date;
        if (fechaFin < fechaInicio)
            throw new ArgumentException("La fecha final no puede ser anterior a la fecha inicial.");

        var fechaFinExclusiva = fechaFin.AddDays(1);
        return await context.Mantenimientos.AsNoTracking()
            .Where(m => m.FechaFin >= fechaInicio && m.FechaFin < fechaFinExclusiva &&
                        m.MantenimientoStatuses != null && !m.MantenimientoStatuses.AllowDrag)
            .OrderBy(m => m.FechaFin)
            .ThenBy(m => m.Vehiculos.Codigo)
            .Select(m => new ReporteMantenimientoDto
            {
                Id = m.Idmantenimineto,
                Caponera = m.Vehiculos.Codigo,
                Placa = m.Vehiculos.Placa,
                TipoMantenimiento = m.TipoMantenimientos.Nombre,
                Titulo = m.Titulo,
                FechaInicio = m.FechaInicio,
                FechaFin = m.FechaFin,
                Descripcion = m.Descripcion,
                Observaciones = m.Observaciones,
                Estado = m.MantenimientoStatuses.DisplayName
            }).ToListAsync();
    }

    public async Task<List<ReporteEstadoMantenimientoDto>> ObtenerEstadoMantenimientosAsync(
        DateTime fechaInicio, DateTime fechaFin)
    {
        (fechaInicio, fechaFin) = ValidarRango(fechaInicio, fechaFin);
        var finExclusivo = fechaFin.AddDays(1);
        return await context.Mantenimientos.AsNoTracking()
            .Where(m => m.FechaInicio < finExclusivo && m.FechaFin >= fechaInicio)
            .OrderBy(m => m.FechaInicio)
            .ThenBy(m => m.Vehiculos.Codigo)
            .Select(m => new ReporteEstadoMantenimientoDto
            {
                Caponera = m.Vehiculos.Codigo,
                Placa = m.Vehiculos.Placa,
                TipoMantenimiento = m.TipoMantenimientos.Nombre,
                Trabajo = m.Titulo,
                FechaInicio = m.FechaInicio,
                FechaFin = m.FechaFin,
                Estado = m.MantenimientoStatuses == null
                    ? "Sin estado"
                    : m.MantenimientoStatuses.DisplayName,
                Descripcion = m.Descripcion,
                Observaciones = m.Observaciones
            }).ToListAsync();
    }

    public async Task<List<ReporteManoObraPagadaDto>> ObtenerManoObraPagadaAsync(
        DateTime fechaInicio, DateTime fechaFin)
    {
        (fechaInicio, fechaFin) = ValidarRango(fechaInicio, fechaFin);
        var finExclusivo = fechaFin.AddDays(1);

        return await (
            from pago in context.TransactionDetailCxps.AsNoTracking()
            join cxp in context.TransactionCxps.AsNoTracking()
                on pago.IdtrasactionCxp equals (int?)cxp.IdtransactionCxp
            join manoObra in context.ManoObras.AsNoTracking()
                on cxp.IdOrigen equals manoObra.IdManoObra
            join proveedorMantenimiento in context.MantenimientoProveedors.AsNoTracking()
                on manoObra.IdmantenimientoProveedor equals (int?)proveedorMantenimiento.IdmantenimientoProveedor
            join mantenimiento in context.Mantenimientos.AsNoTracking()
                on proveedorMantenimiento.Idmantenimiento equals mantenimiento.Idmantenimineto
            join vehiculo in context.Vehiculos.AsNoTracking()
                on mantenimiento.Idvehiculo equals vehiculo.Idvehiculo
            join proveedor in context.Proveedores.AsNoTracking()
                on proveedorMantenimiento.Idproveedor equals proveedor.Idproveedor
            where pago.Fecha >= fechaInicio && pago.Fecha < finExclusivo &&
                  cxp.TipoOrigen == (int)EnumTipoCxp.ManoObra && cxp.Estado != EstadoCxp.ANULADA &&
                  manoObra.Estado != TipoManoObra.Anulada
            orderby pago.Fecha, vehiculo.Codigo, proveedor.Nombre
            select new ReporteManoObraPagadaDto
            {
                FechaPago = pago.Fecha!.Value,
                Caponera = vehiculo.Codigo,
                Placa = vehiculo.Placa,
                Trabajo = manoObra.DescripcionTrabajo,
                Proveedor = proveedor.Nombre,
                MontoPagado = pago.Monto
            }).ToListAsync();
    }

    public async Task<List<ReporteCostoRepuestoDto>> ObtenerCostosRepuestosAsync(
        DateTime fechaInicio, DateTime fechaFin)
    {
        (fechaInicio, fechaFin) = ValidarRango(fechaInicio, fechaFin);
        var finExclusivo = fechaFin.AddDays(1);
        var mantenimientos = await context.Mantenimientos.AsNoTracking()
            .Where(m => m.FechaFin >= fechaInicio && m.FechaFin < finExclusivo &&
                        m.MantenimientoStatuses != null && !m.MantenimientoStatuses.AllowDrag)
            .Select(m => new
            {
                m.Idmantenimineto,
                m.FechaFin,
                m.Titulo,
                Caponera = m.Vehiculos.Codigo,
                Placa = m.Vehiculos.Placa
            }).ToListAsync();
        if (mantenimientos.Count == 0)
            return [];

        var idsMantenimiento = mantenimientos.Select(m => m.Idmantenimineto).ToList();
        var porId = mantenimientos.ToDictionary(m => m.Idmantenimineto);
        var repuestosInventario = await context.MantenimientoRepuestos.AsNoTracking()
            .Where(r => idsMantenimiento.Contains(r.Idmantenimiento))
            .Select(r => new
            {
                r.Idmantenimiento,
                Repuesto = r.Productos.Nombre,
                r.Cantidad,
                CostoUnitario = r.Productos.PrecioCosto ?? 0m
            }).ToListAsync();

        var resultado = repuestosInventario.Select(r =>
        {
            var mantenimiento = porId[r.Idmantenimiento];
            return new ReporteCostoRepuestoDto
            {
                FechaMantenimiento = mantenimiento.FechaFin,
                Caponera = mantenimiento.Caponera,
                Placa = mantenimiento.Placa,
                Trabajo = mantenimiento.Titulo,
                Repuesto = r.Repuesto,
                Origen = "Inventario (costo actual)",
                Cantidad = r.Cantidad,
                CostoUnitario = r.CostoUnitario,
                CostoTotal = r.Cantidad * r.CostoUnitario
            };
        }).ToList();

        // Filtrar el prefijo en memoria evita que el proveedor MySQL genere una
        // expresión COLLATE sin type mapping al traducir StartsWith.
        var encabezadosCompra = await context.Compras.AsNoTracking()
            .Select(c => new { c.Idcompra, c.NumeroDocumento })
            .ToListAsync();
        var comprasRelacionadas = encabezadosCompra
            .Select(c => new
            {
                c.Idcompra,
                c.NumeroDocumento,
                Partes = (c.NumeroDocumento ?? string.Empty).Split('-')
            })
            .Where(c => c.NumeroDocumento?.StartsWith("MANT-", StringComparison.OrdinalIgnoreCase) == true &&
                        c.Partes.Length >= 3 && int.TryParse(c.Partes[1], out var id) && porId.ContainsKey(id))
            .Select(c => new { c.Idcompra, IdMantenimiento = int.Parse(c.Partes[1]) })
            .ToList();
        var idsCompra = comprasRelacionadas.Select(c => c.Idcompra).ToList();
        var detallesCompra = await context.DetalleCompras.AsNoTracking()
            .Where(d => d.Idcompra != null && idsCompra.Contains(d.Idcompra.Value))
            .Select(d => new
            {
                IdCompra = d.Idcompra!.Value,
                Producto = d.Productos.Nombre,
                d.Cantidad,
                d.PrecioUnitario,
                d.Importe
            }).ToListAsync();
        var mantenimientoPorCompra = comprasRelacionadas.ToDictionary(c => c.Idcompra, c => c.IdMantenimiento);

        foreach (var detalle in detallesCompra)
        {
            if (!mantenimientoPorCompra.TryGetValue(detalle.IdCompra, out var idMantenimiento) ||
                !porId.TryGetValue(idMantenimiento, out var mantenimiento))
                continue;

            resultado.Add(new ReporteCostoRepuestoDto
            {
                FechaMantenimiento = mantenimiento.FechaFin,
                Caponera = mantenimiento.Caponera,
                Placa = mantenimiento.Placa,
                Trabajo = mantenimiento.Titulo,
                Repuesto = detalle.Producto,
                Origen = "Compra directa",
                Cantidad = detalle.Cantidad,
                CostoUnitario = detalle.PrecioUnitario,
                CostoTotal = detalle.Importe
            });
        }

        return resultado.OrderBy(r => r.FechaMantenimiento)
            .ThenBy(r => r.Caponera)
            .ThenBy(r => r.Repuesto)
            .ToList();
    }

    private static (DateTime Inicio, DateTime Fin) ValidarRango(DateTime fechaInicio, DateTime fechaFin)
    {
        fechaInicio = fechaInicio.Date;
        fechaFin = fechaFin.Date;
        if (fechaFin < fechaInicio)
            throw new ArgumentException("La fecha final no puede ser anterior a la fecha inicial.");
        return (fechaInicio, fechaFin);
    }
}
