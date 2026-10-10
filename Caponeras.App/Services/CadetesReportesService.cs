using Caponeras.App.Dto;
using Caponeras.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Caponeras.App.Services;

public class CadetesReportesService
{
    private sealed record AsignacionReporte(
        int Id,
        int Idconductor,
        int Idvehiculo,
        int? Idzona,
        DateTime FechaInicio,
        DateTime? FechaFin,
        string? Zona,
        string Cadete,
        string Codigo,
        string? Placa);

    public async Task<List<ReporteAsignacionCadeteDto>> ObtenerReporteAsignacionesAsync(
        DateTime fechaInicio,
        DateTime fechaFin)
    {
        fechaInicio = fechaInicio.Date;
        fechaFin = fechaFin.Date;
        if (fechaFin < fechaInicio)
            throw new ArgumentException("La fecha final no puede ser anterior a la fecha inicial.");

        await using var context = new DataContextCaponeras();
        return await context.VehiculoConductors.AsNoTracking()
            .Where(x => x.Activo == 1 && x.DeletedAt == null &&
                        x.FechaInicio < fechaFin.AddDays(1) &&
                        (x.FechaFin == null || x.FechaFin >= fechaInicio))
            .OrderBy(x => x.Zonas.Nombre)
            .ThenBy(x => x.Conductors.Nombre)
            .ThenBy(x => x.Idconductor)
            .ThenBy(x => x.Idvehiculo)
            .ThenBy(x => x.FechaInicio)
            .Select(x => new ReporteAsignacionCadeteDto
            {
                IdConductor = x.Idconductor,
                IdVehiculo = x.Idvehiculo,
                Zona = x.Zonas.Nombre ?? "Sin zona",
                Cadete = x.Conductors.Nombre,
                Identificacion = x.Conductors.Identificacion,
                Codigo = x.Vehiculos.Codigo,
                Placa = x.Vehiculos.Placa,
                FechaInicio = x.FechaInicio,
                FechaFin = x.FechaFin
            })
            .ToListAsync();
    }

    public async Task<List<AusenciaCadeteDto>> ObtenerReporteAusenciasAsync(
        DateTime fechaInicio,
        DateTime fechaFin)
    {
        fechaInicio = fechaInicio.Date;
        fechaFin = fechaFin.Date;
        if (fechaFin < fechaInicio)
            throw new ArgumentException("La fecha final no puede ser anterior a la fecha inicial.");

        await using var context = new DataContextCaponeras();
        return await (
            from ausencia in context.AusenciasCadetes.AsNoTracking()
            join cadete in context.Conductors.AsNoTracking()
                on ausencia.Idconductor equals cadete.Idconductor
            where ausencia.Fecha >= fechaInicio && ausencia.Fecha < fechaFin.AddDays(1)
            orderby ausencia.Fecha, ausencia.Zona, cadete.Nombre
            select new AusenciaCadeteDto
            {
                Id = ausencia.Id,
                Idconductor = ausencia.Idconductor,
                Cadete = cadete.Nombre,
                Fecha = ausencia.Fecha,
                Motivo = ausencia.Motivo,
                Detalle = ausencia.Detalle,
                Idvehiculo = ausencia.Idvehiculo,
                Idzona = ausencia.Idzona,
                CodigoVehiculo = ausencia.CodigoVehiculo,
                Placa = ausencia.Placa,
                Zona = ausencia.Zona
            }).ToListAsync();
    }

    public async Task<List<ReporteLicenciaCadeteDto>> ObtenerReporteLicenciasCadetesAsync()
    {
        await using var context = new DataContextCaponeras();
        var cadetes = await context.Conductors.AsNoTracking()
            .Where(x => x.Estado == EstadoCadete.ACTIVO)
            .OrderBy(x => x.Nombre)
            .Select(x => new { x.Idconductor, x.Nombre })
            .ToListAsync();

        var cadeteIds = cadetes.Select(x => x.Idconductor).ToList();
        var licencias = await context.ConductorLicencias.AsNoTracking()
            .Where(x => cadeteIds.Contains(x.Idconductor) && x.Activa)
            .OrderByDescending(x => x.UpdatedAt)
            .ThenByDescending(x => x.CreatedAt)
            .ThenByDescending(x => x.Idlicencia)
            .ToListAsync();
        var licenciaActualPorCadete = licencias
            .GroupBy(x => x.Idconductor)
            .ToDictionary(x => x.Key, x => x.First());

        return cadetes.Select(cadete =>
        {
            if (!licenciaActualPorCadete.TryGetValue(cadete.Idconductor, out var licencia))
                return new ReporteLicenciaCadeteDto { Cadete = cadete.Nombre };

            return new ReporteLicenciaCadeteDto
            {
                Cadete = cadete.Nombre,
                Categoria = licencia.Categoria,
                NumeroLicencia = licencia.NumeroLicencia,
                FechaEmision = licencia.FechaEmision,
                FechaVencimiento = licencia.FechaVencimiento,
                EstadoLicencia = "Registrada"
            };
        }).ToList();
    }

    public async Task<List<ReporteCuotaDto>> ObtenerReporteCuotaDiariasAsync(DateTime fecha)
    {
        await using var context = new DataContextCaponeras();
        fecha = fecha.Date;
        var fechaFin = fecha.AddDays(1);
        var asignaciones = await context.VehiculoConductors.AsNoTracking()
            .Where(x => x.Activo == 1 && x.DeletedAt == null &&
                        x.FechaInicio <= fecha && (x.FechaFin == null || x.FechaFin >= fecha))
            .Select(x => new AsignacionReporte(
                x.Id,
                x.Idconductor,
                x.Idvehiculo,
                x.Idzona,
                x.FechaInicio,
                x.FechaFin,
                x.Zonas.Nombre,
                x.Conductors.Nombre,
                x.Vehiculos.Codigo,
                x.Vehiculos.Placa))
            .ToListAsync();

        var asignacionesDelDia = new List<AsignacionReporte>();
        foreach (var grupo in asignaciones.GroupBy(x => x.Idconductor))
        {
            var especificas = grupo.Where(x => x.FechaInicio.Date == fecha &&
                                                x.FechaFin.HasValue && x.FechaFin.Value.Date == fecha)
                .ToList();
            if (especificas.Count > 1)
                throw new InvalidOperationException($"El cadete {grupo.First().Cadete} tiene varias asignaciones específicas para {fecha:dd/MM/yyyy}.");

            var seleccionada = especificas.SingleOrDefault();
            if (seleccionada is null)
            {
                var porRango = grupo.OrderByDescending(x => x.FechaInicio).ThenByDescending(x => x.Id).ToList();
                if (porRango.Count > 1)
                    throw new InvalidOperationException($"El cadete {grupo.First().Cadete} tiene más de una asignación vigente para {fecha:dd/MM/yyyy}.");
                seleccionada = porRango.SingleOrDefault();
            }

            if (seleccionada is not null)
                asignacionesDelDia.Add(seleccionada);
        }

        var cuotas = await context.CuotaDiarias.AsNoTracking()
            .Include(x => x.Conductors)
            .Include(x => x.Vehiculos)
            .Where(x => x.Fecha >= fecha && x.Fecha < fechaFin)
            .ToListAsync();

        var ausencias = await context.AusenciasCadetes.AsNoTracking()
            .Where(x => x.Fecha == fecha)
            .ToDictionaryAsync(x => x.Idconductor);

        var conductorIds = asignacionesDelDia.Select(x => (int)x.Idconductor)
            .Concat(cuotas.Select(x => x.Idconductor))
            .Concat(ausencias.Keys)
            .Distinct()
            .ToList();
        var configuraciones = await context.CuotaConfiguracions.AsNoTracking()
            .Where(x => conductorIds.Contains(x.Idconductor) && x.Activo)
            .ToDictionaryAsync(x => x.Idconductor);
        var nombresAusentes = await context.Conductors.AsNoTracking()
            .Where(x => ausencias.Keys.Contains(x.Idconductor))
            .ToDictionaryAsync(x => x.Idconductor, x => x.Nombre);

        var filas = new List<ReporteCuotaDto>();
        var cuotasIncluidas = new HashSet<int>();
        var ausenciasIncluidas = new HashSet<int>();
        foreach (var asignacion in asignacionesDelDia)
        {
            var cuota = cuotas.FirstOrDefault(x => x.Idconductor == (int)asignacion.Idconductor);
            ausencias.TryGetValue(asignacion.Idconductor, out var ausencia);
            // Domingos no generan meta de cuota, pero los pagos efectivamente registrados sí se reportan.
            if (fecha.DayOfWeek == DayOfWeek.Sunday && cuota is null && ausencia is null)
                continue;

            configuraciones.TryGetValue((int)asignacion.Idconductor, out var configuracion);
            filas.Add(new ReporteCuotaDto
            {
                IdZona = asignacion.Idzona,
                Zona = asignacion.Zona ?? "Sin zona",
                Cadete = asignacion.Cadete,
                Codigo = asignacion.Codigo,
                Placa = asignacion.Placa ?? string.Empty,
                Dias = ausencia is null && fecha.DayOfWeek != DayOfWeek.Sunday ? 1 : 0,
                CuotaEsperada = ausencia is null
                    ? cuota?.MontoCuota ?? (fecha.DayOfWeek == DayOfWeek.Sunday ? 0m : configuracion?.MontoDiario ?? 0m)
                    : 0m,
                TotalEntregado = cuota?.MontoEntregado ?? 0m,
                MotivoAusencia = ausencia?.Motivo,
                DetalleAusencia = ausencia?.Detalle
            });

            if (cuota is not null)
                cuotasIncluidas.Add(cuota.IdCuotaDiaria);
            if (ausencia is not null)
                ausenciasIncluidas.Add(asignacion.Idconductor);
        }

        // Conserva pagos del día aunque su asignación haya sido retirada o no exista.
        foreach (var cuota in cuotas.Where(x => !cuotasIncluidas.Contains(x.IdCuotaDiaria)))
        {
            ausencias.TryGetValue(cuota.Idconductor, out var ausencia);
            filas.Add(new ReporteCuotaDto
            {
                IdZona = null,
                Zona = "Sin zona asignada",
                Cadete = cuota.Conductors.Nombre,
                Codigo = cuota.Vehiculos.Codigo,
                Placa = cuota.Vehiculos.Placa,
                Dias = ausencia is null && fecha.DayOfWeek != DayOfWeek.Sunday ? 1 : 0,
                CuotaEsperada = ausencia is null && fecha.DayOfWeek != DayOfWeek.Sunday ? cuota.MontoCuota : 0m,
                TotalEntregado = cuota.MontoEntregado,
                MotivoAusencia = ausencia?.Motivo,
                DetalleAusencia = ausencia?.Detalle
            });
            if (ausencia is not null)
                ausenciasIncluidas.Add(cuota.Idconductor);
        }

        foreach (var ausencia in ausencias.Values.Where(x => !ausenciasIncluidas.Contains(x.Idconductor)))
        {
            filas.Add(new ReporteCuotaDto
            {
                IdZona = ausencia.Idzona,
                Zona = ausencia.Zona ?? "Sin zona asignada",
                Cadete = nombresAusentes.GetValueOrDefault(ausencia.Idconductor) ?? "Cadete no encontrado",
                Codigo = ausencia.CodigoVehiculo ?? string.Empty,
                Placa = ausencia.Placa ?? string.Empty,
                MotivoAusencia = ausencia.Motivo,
                DetalleAusencia = ausencia.Detalle
            });
        }

        foreach (var grupo in filas.GroupBy(x => x.Zona))
        {
            var unidades = grupo.Select(x => (x.Codigo, x.Placa)).Distinct().Count();
            foreach (var fila in grupo)
                fila.UnidadesZona = unidades;
        }

        return filas.OrderBy(x => x.Zona).ThenBy(x => x.Cadete).ThenBy(x => x.Codigo).ToList();
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
        await using var context = new DataContextCaponeras();
        var fechaFinExclusiva = fechaFin.AddDays(1);
        var asignaciones = await context.VehiculoConductors
            .AsNoTracking()
            .Where(x => x.Activo == 1 && x.DeletedAt == null &&
                        x.FechaInicio < fechaFinExclusiva &&
                        (x.FechaFin == null || x.FechaFin >= fechaInicio))
            .Select(x => new AsignacionReporte(
                x.Id,
                x.Idconductor,
                x.Idvehiculo,
                x.Idzona,
                x.FechaInicio,
                x.FechaFin,
                x.Zonas.Nombre,
                x.Conductors.Nombre,
                x.Vehiculos.Codigo,
                x.Vehiculos.Placa))
            .ToListAsync();

        var conductorIds = asignaciones.Select(x => x.Idconductor).Distinct().ToList();
        var cuotasDiarias = await context.CuotaDiarias
            .AsNoTracking()
            .Include(x => x.Conductors)
            .Include(x => x.Vehiculos)
            .Where(x => x.Fecha >= fechaInicio && x.Fecha < fechaFinExclusiva)
            .ToListAsync();
        var ausencias = await context.AusenciasCadetes.AsNoTracking()
            .Where(x => x.Fecha >= fechaInicio && x.Fecha < fechaFinExclusiva)
            .Select(x => new { x.Idconductor, x.Fecha })
            .ToListAsync();
        var fechasAusencia = ausencias
            .Select(x => (x.Idconductor, Fecha: x.Fecha.Date))
            .ToHashSet();

        // Incluye conductores con pagos registrados aunque su asignación ya no esté activa.
        conductorIds.AddRange(cuotasDiarias.Select(x => x.Idconductor));
        conductorIds = conductorIds.Distinct().ToList();
        var configuraciones = await context.CuotaConfiguracions
            .AsNoTracking()
            .Where(x => conductorIds.Contains(x.Idconductor) && x.Activo)
            .ToDictionaryAsync(x => x.Idconductor);

        var resumen = new Dictionary<(int Conductor, int Vehiculo, int? Zona), ReporteCuotaDto>();
        var registrosCuota = cuotasDiarias
            .GroupBy(x => (x.Idconductor, x.IdVehiculo, Fecha: x.Fecha.Date))
            .ToDictionary(x => x.Key, x => x.OrderBy(q => q.IdCuotaDiaria).First());
        var cuotasIncluidas = new HashSet<int>();

        for (var fecha = fechaInicio; fecha <= fechaFin; fecha = fecha.AddDays(1))
        {
            var esDomingo = fecha.DayOfWeek == DayOfWeek.Sunday;

            var asignacionesDelDia = asignaciones
                .Where(x => x.FechaInicio.Date <= fecha &&
                            (x.FechaFin == null || x.FechaFin.Value.Date >= fecha))
                .GroupBy(x => x.Idconductor)
                .Select(grupo =>
                {
                    var especificas = grupo.Where(x => x.FechaInicio.Date == fecha &&
                                                        x.FechaFin?.Date == fecha)
                        .OrderByDescending(x => x.Id)
                        .ToList();
                    // Las asignaciones de un solo día tienen prioridad sobre los rangos.
                    return especificas.FirstOrDefault() ?? grupo
                        .OrderByDescending(x => x.FechaInicio)
                        .ThenByDescending(x => x.Id)
                        .First();
                });

            foreach (var asignacion in asignacionesDelDia)
            {
                var ausente = fechasAusencia.Contains((asignacion.Idconductor, fecha));
                registrosCuota.TryGetValue((asignacion.Idconductor, asignacion.Idvehiculo, fecha),
                    out var cuotaDiaria);
                configuraciones.TryGetValue(asignacion.Idconductor, out var configuracion);

                // En domingos solo mostrar pagos que realmente se registraron;
                // no sumar meta ni días trabajados.
                if (esDomingo && cuotaDiaria is null && !ausente)
                    continue;

                // No inventar un importe si no hay ni registro diario ni cuota configurada.
                if (!esDomingo && cuotaDiaria is null && configuracion is null && !ausente)
                    continue;

                var clave = (asignacion.Idconductor, asignacion.Idvehiculo, asignacion.Idzona);
                if (!resumen.TryGetValue(clave, out var fila))
                {
                    fila = new ReporteCuotaDto
                    {
                        IdZona = asignacion.Idzona,
                        Zona = asignacion.Zona ?? "Sin zona",
                        Cadete = asignacion.Cadete,
                        Codigo = asignacion.Codigo,
                        Placa = asignacion.Placa
                    };
                    resumen.Add(clave, fila);
                }

                if (!esDomingo && !ausente)
                {
                    fila.Dias++;
                    fila.CuotaEsperada += cuotaDiaria?.MontoCuota ?? configuracion!.MontoDiario;
                }
                fila.TotalEntregado += cuotaDiaria?.MontoEntregado ?? 0m;
                if (cuotaDiaria is not null)
                    cuotasIncluidas.Add(cuotaDiaria.IdCuotaDiaria);
            }
        }

        // Conserva pagos registrados sin asignación vigente asociada, incluidos domingos.
        foreach (var cuotaDiaria in cuotasDiarias.Where(x => !cuotasIncluidas.Contains(x.IdCuotaDiaria)))
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

            if (cuotaDiaria.Fecha.DayOfWeek != DayOfWeek.Sunday)
            {
                fila.Dias++;
                fila.CuotaEsperada += cuotaDiaria.MontoCuota;
            }
            fila.TotalEntregado += cuotaDiaria.MontoEntregado;
        }

        foreach (var grupo in resumen.Values.GroupBy(x => x.Zona))
        {
            var unidades = grupo.Select(x => (x.Codigo, x.Placa)).Distinct().Count();
            foreach (var fila in grupo)
                fila.UnidadesZona = unidades;
        }

        return resumen.Values
            .OrderBy(x => x.Zona)
            .ThenBy(x => x.Cadete)
            .ThenBy(x => x.Codigo)
            .ToList();
    }
}
