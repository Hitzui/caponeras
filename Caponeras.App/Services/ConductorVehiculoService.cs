using Caponeras.App.Dto;
using Caponeras.App.Helpers;
using Caponeras.Data.Models;
using Microsoft.EntityFrameworkCore;
using NLog;
using System.Windows;

namespace Caponeras.App.Services;

public class ConductorVehiculoService
{
    private ILogger _logger = LogManager.GetCurrentClassLogger();
    private readonly DataContextCaponeras _context;
    public string ErrorSms { get; private set; }

    public ConductorVehiculoService(DataContextCaponeras context)
    {
        _context = context;
        ErrorSms = string.Empty;
    }

    public Task<List<ConductorVehiculoDto>> GetConductoresVehiculosAsync(DateTime fecha)
    {
        var fechaInicio = fecha.Date;
        var fechaFin = fechaInicio.AddDays(1);

        var query =
            from c in _context.Conductors
            where c.Estado == EstadoCadete.ACTIVO
            join vc in _context.VehiculoConductors
                on c.Idconductor equals vc.Idconductor into vcGroup
            from vc in vcGroup
                .Where(vc =>
                    vc.Activo == 1 &&
                    vc.DeletedAt == null &&
                    vc.FechaInicio < fechaFin &&
                    (vc.FechaFin == null || vc.FechaFin >= fechaInicio)
                )
                .OrderByDescending(vc => vc.FechaInicio)
                .Take(1)
                .DefaultIfEmpty()
            join z in _context.Zonas
                on vc.Idzona equals z.Idzonas into zGroup
            from z in zGroup.DefaultIfEmpty()
            select new ConductorVehiculoDto
            {
                IdConductor = c.Idconductor,
                Nombre = c.Nombre,
                Telefono = c.Telefono,
                Identificacion = c.Identificacion,
                Estado = c.Estado,
                Observaciones = c.Observaciones,
                CreatedAt = c.CreatedAt,
                Direccion = c.Direccion,
                IdVehiculoConductor = vc != null ? vc.Id : null,
                IdVehiculo = vc != null ? vc.Idvehiculo : null,
                CodigoVehiculo = vc != null ? vc.Vehiculos.Codigo : null,
                Placa = vc != null ? vc.Vehiculos.Placa : null,
                FechaInicio = vc != null ? vc.FechaInicio : null,
                FechaFin = vc != null ? vc.FechaFin : null,
                IdZona = vc != null ? vc.Idzona : null,
                Zona = z != null ? z.Nombre : null
            };

        return query.ToListAsync();
    }

    public Task<List<VehiculosDto>> GetVehiculosAsync(string? filter)
    {
        filter ??= string.Empty;

        var query =
            from v in _context.Vehiculos
            where v.Estado == "ACTIVO"
                  && (
                      string.IsNullOrEmpty(filter)
                      || v.Codigo.Contains(filter)
                      || v.Placa.Contains(filter)
                  )
            select new VehiculosDto(v);

        return query.ToListAsync();
    }

    public Task<List<ZonasDto>> GetZonasASync()
    {
        return _context.Zonas.AsNoTracking().Select(z => new ZonasDto(z)).ToListAsync();
    }

    public async Task<AsignacionVehiculoResultado> AsignarVehiculosPorDiaAsync(
        DateTime fecha,
        List<ConductorVehiculoDto> asignaciones)
    {
        ErrorSms = string.Empty;
        var resultado = new AsignacionVehiculoResultado();
        var fechaAsignacion = fecha.Date;
        if (asignaciones is null || asignaciones.Count == 0)
        {
            resultado.Conflictos.Add("No hay asignaciones para guardar.");
            return resultado;
        }

        if (asignaciones.Any(x => x.IdConductor <= 0 || x.IdVehiculo is null or <= 0 || x.IdZona is null or <= 0))
        {
            resultado.Conflictos.Add("Cada asignación debe tener un cadete, vehículo y zona válidos.");
            return resultado;
        }

        var conductoresDuplicados = asignaciones.GroupBy(x => x.IdConductor).Where(g => g.Count() > 1);
        foreach (var grupo in conductoresDuplicados)
            resultado.Conflictos.Add($"El cadete {grupo.First().Nombre} aparece más de una vez para el {fechaAsignacion:dd/MM/yyyy}.");

        var vehiculosDuplicados = asignaciones.GroupBy(x => x.IdVehiculo!.Value).Where(g => g.Count() > 1);
        foreach (var grupo in vehiculosDuplicados)
            resultado.Conflictos.Add($"El vehículo {grupo.First().Placa} está seleccionado para más de un cadete el {fechaAsignacion:dd/MM/yyyy}.");

        if (resultado.Conflictos.Count > 0)
            return resultado;

        await using var transaction = await _context.Database.BeginTransactionAsync();
        try
        {
            var asignacionesAReemplazar = new Dictionary<int, VehiculoConductors>();
            var asignacionesNuevas = new List<ConductorVehiculoDto>();
            foreach (var asignacion in asignaciones)
            {
                var idVehiculo = asignacion.IdVehiculo!.Value;
                var idConductor = asignacion.IdConductor;
                var idZona = asignacion.IdZona!.Value;
                var conductorActivo = await _context.Conductors.AnyAsync(x =>
                    x.Idconductor == idConductor && x.Estado == EstadoCadete.ACTIVO);
                if (!conductorActivo)
                {
                    resultado.Conflictos.Add($"El cadete {asignacion.Nombre} está inactivo o ya no existe.");
                    continue;
                }

                var vehiculoActivo = await _context.Vehiculos.AnyAsync(x =>
                    x.Idvehiculo == idVehiculo && x.Estado == "ACTIVO");
                if (!vehiculoActivo || !await _context.Zonas.AnyAsync(x => x.Idzonas == idZona))
                {
                    resultado.Conflictos.Add($"El vehículo o la zona de la asignación de {asignacion.Nombre} ya no existe o está inactivo.");
                    continue;
                }

                var fechaLimite = fechaAsignacion.AddDays(1);
                var conflictosCadete = await _context.VehiculoConductors
                    .Where(x => x.Idconductor == idConductor && x.Activo == 1 && x.DeletedAt == null &&
                                x.FechaInicio < fechaLimite && (x.FechaFin == null || x.FechaFin >= fechaAsignacion))
                    .ToListAsync();
                var conflictosVehiculo = await _context.VehiculoConductors
                    .Where(x => x.Idvehiculo == idVehiculo && x.Activo == 1 && x.DeletedAt == null &&
                                x.FechaInicio < fechaLimite && (x.FechaFin == null || x.FechaFin >= fechaAsignacion))
                    .ToListAsync();

                if (HayCrucesInternos(conflictosCadete) || HayCrucesInternos(conflictosVehiculo))
                {
                    resultado.Conflictos.Add($"Hay asignaciones superpuestas existentes para {asignacion.Nombre} o para el vehículo {asignacion.Placa}. Corrija el calendario antes de continuar.");
                    continue;
                }

                var conflictos = conflictosCadete.Concat(conflictosVehiculo).DistinctBy(x => x.Id).ToList();
                if (conflictos.Count == 1 &&
                    conflictos[0].Idconductor == idConductor &&
                    conflictos[0].Idvehiculo == idVehiculo &&
                    conflictos[0].Idzona == idZona)
                {
                    continue;
                }

                foreach (var existente in conflictos)
                    asignacionesAReemplazar[existente.Id] = existente;
                asignacionesNuevas.Add(asignacion);
            }

            /*
             * Si encontramos conflictos en cualquiera de las filas,
             * NO guardamos parcialmente.
             */
            if (resultado.Conflictos.Count > 0)
            {
                await transaction.RollbackAsync();
                resultado.Exitoso = false;
                return resultado;
            }

            // Planificamos todos los cambios contra el mismo estado inicial antes de
            // partir tramos; así también se pueden intercambiar vehículos en un día.
            foreach (var existente in asignacionesAReemplazar.Values)
                await ReemplazarDiaAsync(existente, fechaAsignacion);

            foreach (var asignacion in asignacionesNuevas)
            {
                await _context.VehiculoConductors.AddAsync(new VehiculoConductors
                {
                    Idvehiculo = asignacion.IdVehiculo!.Value,
                    Idconductor = asignacion.IdConductor,
                    Idzona = asignacion.IdZona!.Value,
                    FechaInicio = fechaAsignacion,
                    FechaFin = fechaAsignacion,
                    Activo = 1,
                    DeletedAt = null
                });
            }

            var save = await _context.SaveChangesAsync();
            _logger.Info($"Se guardaron {save} asignaciones de forma correcta.");
            await transaction.CommitAsync();
            resultado.Exitoso = true;
            return resultado;
        }
        catch (Exception ex)
        {
            await transaction.RollbackAsync();
            _logger.Error(ex);
            ErrorSms = ex.Message;
            resultado.Exitoso = false;
            resultado.Conflictos.Add("Ocurrió un error al guardar las asignaciones.");
            return resultado;
        }
    }

    private static bool HayCrucesInternos(IReadOnlyList<VehiculoConductors> asignaciones)
    {
        for (var i = 0; i < asignaciones.Count; i++)
        for (var j = i + 1; j < asignaciones.Count; j++)
        {
            var finA = asignaciones[i].FechaFin?.Date ?? DateTime.MaxValue.Date;
            var finB = asignaciones[j].FechaFin?.Date ?? DateTime.MaxValue.Date;
            if (asignaciones[i].FechaInicio.Date <= finB && asignaciones[j].FechaInicio.Date <= finA)
                return true;
        }

        return false;
    }

    private async Task ReemplazarDiaAsync(VehiculoConductors existente, DateTime fecha)
    {
        var inicio = existente.FechaInicio.Date;
        var fin = existente.FechaFin?.Date;
        var conservarAnterior = inicio < fecha;
        var conservarPosterior = !fin.HasValue || fin.Value > fecha;

        if (conservarAnterior)
            existente.FechaFin = fecha.AddDays(-1);

        if (conservarPosterior)
        {
            var posterior = new VehiculoConductors
            {
                Idvehiculo = existente.Idvehiculo,
                Idconductor = existente.Idconductor,
                Idzona = existente.Idzona,
                FechaInicio = fecha.AddDays(1),
                FechaFin = fin,
                Activo = 1,
                DeletedAt = null
            };

            if (conservarAnterior)
                await _context.VehiculoConductors.AddAsync(posterior);
            else
                existente.FechaInicio = posterior.FechaInicio;
        }
        else if (!conservarAnterior)
        {
            existente.Activo = 0;
            existente.DeletedAt = DateTime.Now;
        }
    }

    public async Task<bool> QuitarAsignacionVehiculoPorDia(DateTime fecha, ConductorVehiculoDto fila)
    {
        ErrorSms = string.Empty;
        await using var transaction = await _context.Database.BeginTransactionAsync();

        try
        {
            if (!fila.IdVehiculoConductor.HasValue ||
                fila.IdVehiculoConductor <= 0)
            {
                return false;
            }

            var fechaAsignacion = fecha.Date;

            var registro = await _context.VehiculoConductors
                .FirstOrDefaultAsync(x =>
                    x.Id == fila.IdVehiculoConductor.Value &&
                    x.Activo == 1 &&
                    x.DeletedAt == null &&
                    x.FechaInicio <= fechaAsignacion &&
                    (x.FechaFin == null || x.FechaFin >= fechaAsignacion));

            if (registro == null)
            {
                return false;
            }

            await ReemplazarDiaAsync(registro, fechaAsignacion);

            await _context.SaveChangesAsync();
            await transaction.CommitAsync();
            return true;
        }
        catch (Exception ex)
        {
            _logger.Error(ex);

            ErrorSms = ex.Message;

            await transaction.RollbackAsync();

            return false;
        }
    }
}
