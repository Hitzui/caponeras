using Caponeras.App.Dto;
using Caponeras.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Caponeras.App.Services;

public class CadetesReportesService
{
    private DataContextCaponeras _context;

    public CadetesReportesService(DataContextCaponeras context)
    {
        _context = context;
    }

    public Task<List<VwReporteCuotaDiarias>> ObtenerReporteCuotaDiariasAsync(DateTime fecha)
    {
        var fechaInicio = fecha.Date;
        var fechaFin = fechaInicio.AddDays(1);

        return _context.VwReporteCuotaDiarias
            .AsNoTracking()
            .Where(r => r.Fecha >= fechaInicio && r.Fecha < fechaFin)
            .ToListAsync();
    }

    public Task<List<ReporteCuotaDto>> ObtenerReporteCuotaRangoAsync(
        DateTime fechaInicio,
        DateTime fechaFin)
    {
        fechaInicio = fechaInicio.Date;
        fechaFin = fechaFin.Date;
        if (fechaFin < fechaInicio)
        {
            throw new ArgumentException("La fecha final no puede ser anterior a la fecha inicial.");
        }

        return ObtenerResumenCuotasAsync(fechaInicio, fechaFin);
    }

    private async Task<List<ReporteCuotaDto>> ObtenerResumenCuotasAsync(DateTime fechaInicio, DateTime fechaFin)
    {
        var fechaFinExclusiva = fechaFin.AddDays(1);
        var asignaciones = await _context.VehiculoConductors
            .AsNoTracking()
            .Where(x => x.Activo == 1 && x.DeletedAt == null &&
                        x.FechaInicio < fechaFinExclusiva &&
                        (x.FechaFin == null || x.FechaFin >= fechaInicio))
            .Select(x => new
            {
                x.Idconductor,
                x.Idvehiculo,
                x.Idzona,
                x.FechaInicio,
                x.FechaFin,
                Zona = x.Zonas.Nombre,
                Cadete = x.Conductors.Nombre,
                Codigo = x.Vehiculos.Codigo,
                Placa = x.Vehiculos.Placa
            })
            .ToListAsync();

        var conductorIds = asignaciones.Select(x => x.Idconductor).Distinct().ToList();
        var cuotasDiarias = await _context.CuotaDiarias
            .AsNoTracking()
            .Include(x => x.Conductors)
            .Include(x => x.Vehiculos)
            .Where(x => x.Fecha >= fechaInicio && x.Fecha < fechaFinExclusiva)
            .ToListAsync();

        // Incluye conductores con pagos registrados aunque su asignación ya no esté activa.
        conductorIds.AddRange(cuotasDiarias.Select(x => x.Idconductor));
        conductorIds = conductorIds.Distinct().ToList();
        var configuraciones = await _context.CuotaConfiguracions
            .AsNoTracking()
            .Where(x => conductorIds.Contains(x.Idconductor) && x.Activo)
            .ToDictionaryAsync(x => x.Idconductor);

        var resumen = new Dictionary<(int Conductor, int Vehiculo, int? Zona), ReporteCuotaDto>();
        var registrosCuota = cuotasDiarias
            .GroupBy(x => (x.Idconductor, x.IdVehiculo, Fecha: x.Fecha.Date))
            .ToDictionary(x => x.Key, x => x.First());
        var cuotasIncluidas = new HashSet<int>();

        for (var fecha = fechaInicio; fecha <= fechaFin; fecha = fecha.AddDays(1))
        {
            // El domingo es el día de descanso semanal: no genera cuota esperada
            // ni se contabiliza como día trabajado en el reporte de cumplimiento.
            if (fecha.DayOfWeek == DayOfWeek.Sunday)
                continue;

            var asignacionesDelDia = asignaciones
                .Where(x => x.FechaInicio.Date <= fecha &&
                            (x.FechaFin == null || x.FechaFin.Value.Date >= fecha))
                .GroupBy(x => x.Idconductor)
                // Si hay datos históricos superpuestos, se usa la asignación más reciente,
                // evitando duplicar la cuota de un mismo conductor en un día.
                .Select(x => x.OrderByDescending(a => a.FechaInicio).First());

            foreach (var asignacion in asignacionesDelDia)
            {
                registrosCuota.TryGetValue((asignacion.Idconductor, asignacion.Idvehiculo, fecha),
                    out var cuotaDiaria);
                configuraciones.TryGetValue(asignacion.Idconductor, out var configuracion);

                // No inventar un importe si no hay ni registro diario ni cuota configurada.
                if (cuotaDiaria is null && configuracion is null)
                    continue;

                var clave = (asignacion.Idconductor, asignacion.Idvehiculo, asignacion.Idzona);
                if (!resumen.TryGetValue(clave, out var fila))
                {
                    fila = new ReporteCuotaDto
                    {
                        Zona = asignacion.Zona ?? "Sin zona",
                        Cadete = asignacion.Cadete,
                        Codigo = asignacion.Codigo,
                        Placa = asignacion.Placa
                    };
                    resumen.Add(clave, fila);
                }

                fila.Dias++;
                fila.CuotaEsperada += cuotaDiaria?.MontoCuota ?? configuracion!.MontoDiario;
                fila.TotalEntregado += cuotaDiaria?.MontoEntregado ?? 0m;
                if (cuotaDiaria is not null)
                    cuotasIncluidas.Add(cuotaDiaria.IdCuotaDiaria);
            }
        }

        // Conserva pagos históricos sin una asignación vigente asociada para esa fecha.
        foreach (var cuotaDiaria in cuotasDiarias.Where(x =>
                     !cuotasIncluidas.Contains(x.IdCuotaDiaria) &&
                     x.Fecha.DayOfWeek != DayOfWeek.Sunday))
        {
            var clave = (cuotaDiaria.Idconductor, cuotaDiaria.IdVehiculo, (int?)null);
            if (!resumen.TryGetValue(clave, out var fila))
            {
                fila = new ReporteCuotaDto
                {
                    Zona = "Sin zona (asignación no encontrada)",
                    Cadete = cuotaDiaria.Conductors.Nombre,
                    Codigo = cuotaDiaria.Vehiculos.Codigo,
                    Placa = cuotaDiaria.Vehiculos.Placa
                };
                resumen.Add(clave, fila);
            }

            fila.Dias++;
            fila.CuotaEsperada += cuotaDiaria.MontoCuota;
            fila.TotalEntregado += cuotaDiaria.MontoEntregado;
        }

        return resumen.Values
            .OrderBy(x => x.Zona)
            .ThenBy(x => x.Cadete)
            .ThenBy(x => x.Codigo)
            .ToList();
    }
}
