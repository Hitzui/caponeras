using Caponeras.App.Dto;
using Caponeras.Data.Models;
using DevExpress.XtraScheduler;
using Microsoft.EntityFrameworkCore;
using NLog;

namespace Caponeras.App.Services;

public class VehiculoService
{
    private DataContextCaponeras _context;
    private readonly ILogger _logger = LogManager.GetCurrentClassLogger();
    public string ErrorMessage { get; private set; } = string.Empty;

    public VehiculoService(DataContextCaponeras context)
    {
        _context = context;
    }

    public Task<List<VehiculoConductorDto>> GetAllVehiculoConductores()
    {
        return _context.VehiculoConductors
            .Include(vc => vc.Vehiculos)
            .Include(vc => vc.Conductors)
            .Include(vc => vc.Zonas)
            .AsNoTracking()
            .Where(vc => vc.Activo == 1 && vc.DeletedAt == null)
            .Select(vc => new VehiculoConductorDto
            {
                IdvehiculoConductor = vc.Id,
                IdVehiculo = vc.Idvehiculo,
                IdConductor = vc.Idconductor,
                Codigo = vc.Vehiculos.Codigo,
                Placa = vc.Vehiculos.Placa,
                Conductor = vc.Conductors.Nombre,
                Identificacion = vc.Conductors.Identificacion,
                FechaInicio = vc.FechaInicio,
                // El Scheduler requiere un fin concreto; los registros sin fin se
                // muestran hasta un horizonte de cinco años.
                FechaFin = vc.FechaFin ?? DateTime.Today.AddYears(5),
                Zonas = new ZonasDto(vc.Zonas)
            })
            .ToListAsync();
    }

    public Task<List<VehiculosDto>> GetAll()
    {
        return _context.Vehiculos.AsNoTracking()
            .Where(v => v.Estado.ToLower().Contains("activo"))
            .Select(v => new VehiculosDto(v))
            .ToListAsync();
    }

    public async Task<int> GuardarVehiculo(VehiculosDto vehiculoDto)
    {
        if (vehiculoDto.Idvehiculo <= 0)
        {
            var vehiculos = vehiculoDto.GetVehiclo();
            vehiculos.Estado = "ACTIVO";
            vehiculos.CreatedAt = DateTime.Now;
            vehiculos.UpdatedAt = DateTime.Now;
            await _context.AddAsync(vehiculos);
        }
        else
        {
            var find = await _context.Vehiculos.FindAsync(vehiculoDto.Idvehiculo);
            if (find is null) return -1;
            find.Codigo = vehiculoDto.Codigo ?? "";
            find.Descripcion = vehiculoDto.Descripcion ?? "";
            find.Anio = vehiculoDto.Anio;
            find.Idagencia = vehiculoDto.Idagencia;
            find.Marca = vehiculoDto.Marca ?? "";
            find.Modelo = vehiculoDto.Modelo ?? "";
            find.Observaciones = vehiculoDto.Observaciones ?? "";
            find.Placa = vehiculoDto.Placa ?? "";
            find.Tipo = vehiculoDto.Tipo ?? "";
            _context.Update(find);
        }

        return await _context.SaveChangesAsync();
    }

    public async Task<bool> AsignarVehiculoCadete(VehiculoConductors nueva, int? asignacionOriginalId = null)
    {
        ErrorMessage = string.Empty;
        if (nueva.Idconductor <= 0 || nueva.Idvehiculo <= 0 || nueva.Idzona is null or <= 0)
        {
            ErrorMessage = "Debe seleccionar un cadete, un vehículo y una zona válidos.";
            return false;
        }

        nueva.FechaInicio = nueva.FechaInicio.Date;
        if (nueva.FechaFin.HasValue)
            nueva.FechaFin = nueva.FechaFin.Value.Date;

        if (nueva.FechaFin.HasValue && nueva.FechaInicio > nueva.FechaFin.Value)
        {
            ErrorMessage = "La fecha final no puede ser anterior a la fecha inicial.";
            return false;
        }
        if (!nueva.FechaFin.HasValue)
        {
            ErrorMessage = "Debe especificar la fecha final de la asignación.";
            return false;
        }

        try
        {
            await using var transaction = await _context.Database.BeginTransactionAsync();

            var conductorActivo = await _context.Conductors.AnyAsync(x =>
                x.Idconductor == nueva.Idconductor && x.Estado == EstadoCadete.ACTIVO);
            if (!conductorActivo)
            {
                ErrorMessage = "Solo se puede asignar un vehículo a un cadete activo.";
                await transaction.RollbackAsync();
                return false;
            }

            var vehiculoActivo = await _context.Vehiculos.AnyAsync(x =>
                x.Idvehiculo == nueva.Idvehiculo && x.Estado == "ACTIVO");
            if (!vehiculoActivo)
            {
                ErrorMessage = "El vehículo seleccionado no existe o está inactivo.";
                await transaction.RollbackAsync();
                return false;
            }

            var zonaExiste = await _context.Zonas.AnyAsync(x => x.Idzonas == nueva.Idzona);
            if (!zonaExiste)
            {
                ErrorMessage = "La zona seleccionada no existe.";
                await transaction.RollbackAsync();
                return false;
            }

            VehiculoConductors? asignacionOriginal = null;
            if (asignacionOriginalId.HasValue)
            {
                asignacionOriginal = await _context.VehiculoConductors.FirstOrDefaultAsync(x =>
                    x.Id == asignacionOriginalId.Value && x.Activo == 1 && x.DeletedAt == null);
                if (asignacionOriginal is null)
                {
                    ErrorMessage = "La asignación que intenta editar ya no existe o fue eliminada.";
                    await transaction.RollbackAsync();
                    return false;
                }
            }

            var fechaFin = nueva.FechaFin ?? DateTime.MaxValue.Date;
            var asignacionesCadete = await _context.VehiculoConductors
                .Where(x => x.Activo == 1 && x.DeletedAt == null &&
                            (!asignacionOriginalId.HasValue || x.Id != asignacionOriginalId.Value) &&
                            x.Idconductor == nueva.Idconductor &&
                            x.FechaInicio <= fechaFin &&
                            (x.FechaFin == null || x.FechaFin >= nueva.FechaInicio))
                .ToListAsync();

            for (var i = 0; i < asignacionesCadete.Count; i++)
            {
                for (var j = i + 1; j < asignacionesCadete.Count; j++)
                {
                    if (SeTraslapan(asignacionesCadete[i], asignacionesCadete[j]))
                    {
                        ErrorMessage = "El cadete ya tiene asignaciones superpuestas. Corrija el calendario existente antes de continuar.";
                        await transaction.RollbackAsync();
                        return false;
                    }
                }
            }

            // La sustitución se realiza sobre el mismo vehículo. Se conserva el
            // tramo anterior/posterior de cada asignación que el rango nuevo cruza.
            var asignacionesVehiculo = await _context.VehiculoConductors
                .Where(x => x.Idvehiculo == nueva.Idvehiculo &&
                            x.Activo == 1 && x.DeletedAt == null &&
                            (!asignacionOriginalId.HasValue || x.Id != asignacionOriginalId.Value) &&
                            x.FechaInicio <= fechaFin &&
                            (x.FechaFin == null || x.FechaFin >= nueva.FechaInicio))
                .ToListAsync();

            for (var i = 0; i < asignacionesVehiculo.Count; i++)
            {
                for (var j = i + 1; j < asignacionesVehiculo.Count; j++)
                {
                    if (SeTraslapan(asignacionesVehiculo[i], asignacionesVehiculo[j]))
                    {
                        ErrorMessage = "El vehículo ya tiene asignaciones superpuestas en ese rango. " +
                                       "Corrija las asignaciones existentes antes de continuar.";
                        await transaction.RollbackAsync();
                        return false;
                    }
                }
            }

            var asignacionesAReemplazar = asignacionesCadete
                .Concat(asignacionesVehiculo)
                .DistinctBy(x => x.Id)
                .ToList();

            if (asignacionOriginal is not null)
            {
                asignacionOriginal.Activo = 0;
                asignacionOriginal.DeletedAt = DateTime.Now;
            }

            foreach (var existente in asignacionesAReemplazar)
                await ReemplazarTramoAsync(existente, nueva.FechaInicio, fechaFin);

            nueva.Id = 0;
            nueva.Activo = 1;
            nueva.DeletedAt = null;
            await _context.VehiculoConductors.AddAsync(nueva);

            await _context.SaveChangesAsync();
            await transaction.CommitAsync();

            return true;
        }
        catch (Exception ex)
        {
            _logger.Error(ex);
            ErrorMessage = ex.Message;
            return false;
        }
    }

    private static bool SeTraslapan(VehiculoConductors primera, VehiculoConductors segunda)
    {
        var primeraFin = primera.FechaFin?.Date ?? DateTime.MaxValue.Date;
        var segundaFin = segunda.FechaFin?.Date ?? DateTime.MaxValue.Date;
        return primera.FechaInicio.Date <= segundaFin && segunda.FechaInicio.Date <= primeraFin;
    }

    private async Task ReemplazarTramoAsync(VehiculoConductors existente, DateTime fechaInicio, DateTime fechaFin)
    {
        var inicioOriginal = existente.FechaInicio.Date;
        var finOriginal = existente.FechaFin?.Date;
        var conservarAnterior = inicioOriginal < fechaInicio;
        var conservarPosterior = !finOriginal.HasValue || finOriginal.Value > fechaFin;

        if (conservarAnterior)
            existente.FechaFin = fechaInicio.AddDays(-1);

        if (conservarPosterior)
        {
            var posterior = new VehiculoConductors
            {
                Idvehiculo = existente.Idvehiculo,
                Idconductor = existente.Idconductor,
                Idzona = existente.Idzona,
                FechaInicio = fechaFin.AddDays(1),
                FechaFin = finOriginal,
                Activo = existente.Activo,
                DeletedAt = null
            };

            if (!conservarAnterior)
            {
                existente.FechaInicio = posterior.FechaInicio;
            }
            else
            {
                await _context.VehiculoConductors.AddAsync(posterior);
            }
        }
        else if (!conservarAnterior)
        {
            existente.Activo = 0;
            existente.DeletedAt = DateTime.Now;
        }
    }

    public async Task<bool> UpdateVehiculoConductor(Appointment appointment)
    {
        ErrorMessage = string.Empty;
        if (appointment is null)
        {
            ErrorMessage = "No se recibió la asignación que se desea actualizar.";
            return false;
        }

        var fechaInicial = appointment.Start.Date;
        // Los eventos AllDay del Scheduler terminan de forma exclusiva.
        var fechaFinal = appointment.End.Date.AddDays(-1);
        var id = (int)appointment.Id;
        var vehiculoConductor = await _context.VehiculoConductors
            .AsNoTracking().SingleOrDefaultAsync(x => x.Id == id && x.Activo == 1 && x.DeletedAt == null);
        if (vehiculoConductor == null)
        {
            ErrorMessage = "La asignación ya no existe o fue eliminada.";
            return false;
        }

        vehiculoConductor.Id = 0;
        vehiculoConductor.FechaInicio = fechaInicial;
        vehiculoConductor.FechaFin = fechaFinal;
        return await this.AsignarVehiculoCadete(vehiculoConductor, id);
    }

    public async Task<bool> DeleteVehiculoConductor(int idasignacion)
    {
        ErrorMessage = string.Empty;
        try
        {
            var find = await _context.VehiculoConductors.FindAsync(idasignacion);
            if (find is null || find.Activo != 1 || find.DeletedAt is not null) return false;
            find.Activo = 0;
            find.DeletedAt = DateTime.Now;
            await _context.SaveChangesAsync();
            return true;
        }
        catch (Exception e)
        {
            _logger.Error(e);
            ErrorMessage = e.GetBaseException().Message;
            return false;
        }
    }

    public Task<List<ZonasDto>> GetAllZonas()
    {
        return _context.Zonas.Select(z => new ZonasDto(z)).ToListAsync();
    }
}
