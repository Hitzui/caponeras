using Caponeras.App.Dto;
using Caponeras.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Caponeras.App.Services;

public sealed class CuotasDiariasService
{
    private readonly DataContextCaponeras _context;

    public CuotasDiariasService(DataContextCaponeras context)
    {
        _context = context;
    }

    public async Task<List<CuotaDiariaGestionDto>> ObtenerCuotasPorFechaAsync(DateTime fecha)
    {
        var inicio = fecha.Date;
        var fin = inicio.AddDays(1);

        var asignaciones = await _context.VehiculoConductors
            .AsNoTracking()
            .Where(a => a.Activo == 1 && a.DeletedAt == null &&
                        a.FechaInicio < fin && (a.FechaFin == null || a.FechaFin >= inicio) &&
                        a.Conductors.Estado == EstadoCadete.ACTIVO)
            .Select(a => new
            {
                a.Idconductor,
                a.Idvehiculo,
                a.FechaInicio,
                a.FechaFin,
                Nombre = a.Conductors.Nombre,
                Identificacion = a.Conductors.Identificacion,
                Placa = a.Vehiculos.Placa,
                Zona = a.Zonas == null ? null : a.Zonas.Nombre
            })
            .ToListAsync();

        var asignacionesPorConductor = asignaciones
            .GroupBy(a => a.Idconductor)
            .SelectMany(grupo => grupo
                .OrderByDescending(a => a.FechaInicio.Date == inicio && a.FechaFin.HasValue && a.FechaFin.Value.Date == inicio)
                .ThenByDescending(a => a.FechaInicio)
                .Take(1))
            .ToList();

        var idsConductores = asignacionesPorConductor.Select(a => a.Idconductor).ToList();
        if (idsConductores.Count == 0)
            return [];

        var cuotas = await _context.CuotaDiarias.AsNoTracking()
            .Where(c => idsConductores.Contains(c.Idconductor) && c.Fecha >= inicio && c.Fecha < fin)
            .ToListAsync();
        var cuotasPorConductor = cuotas
            .GroupBy(c => c.Idconductor)
            .ToDictionary(g => g.Key, g => g.OrderByDescending(c => c.IdCuotaDiaria).First());

        var configuraciones = await _context.CuotaConfiguracions.AsNoTracking()
            .Where(c => idsConductores.Contains(c.Idconductor) && c.Activo)
            .ToDictionaryAsync(c => c.Idconductor);

        return asignacionesPorConductor
            .Select(asignacion =>
            {
                cuotasPorConductor.TryGetValue(asignacion.Idconductor, out var cuota);
                configuraciones.TryGetValue(asignacion.Idconductor, out var configuracion);
                return new CuotaDiariaGestionDto
                {
                    IdConductor = asignacion.Idconductor,
                    Nombre = asignacion.Nombre,
                    Identificacion = asignacion.Identificacion,
                    Placa = asignacion.Placa,
                    Zona = asignacion.Zona,
                    IdVehiculo = asignacion.Idvehiculo,
                    IdCuotaDiaria = cuota?.IdCuotaDiaria,
                    MontoCuota = cuota?.MontoCuota ?? configuracion?.MontoDiario ?? 0m,
                    MontoEntregado = cuota?.MontoEntregado ?? 0m
                };
            })
            .OrderBy(x => x.Nombre)
            .ToList();
    }

}
