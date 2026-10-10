using Caponeras.App.Dto;
using Caponeras.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Caponeras.App.Services;

public sealed class AusenciaCadeteService(DataContextCaponeras context)
{
    public async Task<List<AusenciaCadeteDto>> ObtenerAsync(DateTime fecha)
    {
        return await (
            from ausencia in context.AusenciasCadetes.AsNoTracking()
            join cadete in context.Conductors.AsNoTracking() on ausencia.Idconductor equals cadete.Idconductor
            where ausencia.Fecha == fecha.Date
            orderby cadete.Nombre
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

    public Task<List<CadeteAusenciaOpcionDto>> ObtenerCadetesAsync()
    {
        return context.Conductors.AsNoTracking()
            .Where(x => x.Estado == EstadoCadete.ACTIVO)
            .OrderBy(x => x.Nombre)
            .Select(x => new CadeteAusenciaOpcionDto { Id = x.Idconductor, Nombre = x.Nombre })
            .ToListAsync();
    }

    public async Task GuardarAsync(AusenciaCadeteDto dto)
    {
        var motivo = dto.Motivo.Trim();
        if (dto.Idconductor <= 0 || string.IsNullOrWhiteSpace(motivo))
            throw new InvalidOperationException("Seleccione un cadete e indique el motivo de la ausencia.");
        if (motivo.Length > 100)
            throw new InvalidOperationException("El motivo no puede superar 100 caracteres.");

        var fecha = dto.Fecha.Date;
        var duplicado = await context.AusenciasCadetes.AnyAsync(x =>
            x.Idconductor == dto.Idconductor && x.Fecha == fecha && x.Id != dto.Id);
        if (duplicado)
            throw new InvalidOperationException("Ya existe una ausencia registrada para este cadete en esa fecha.");

        var entidad = dto.Id == 0
            ? new AusenciaCadete()
            : await context.AusenciasCadetes.SingleOrDefaultAsync(x => x.Id == dto.Id)
              ?? throw new InvalidOperationException("El registro de ausencia ya no existe.");

        var asignacion = await ObtenerAsignacionAsync(dto.Idconductor, fecha);
        entidad.Idconductor = dto.Idconductor;
        entidad.Fecha = fecha;
        entidad.Motivo = motivo;
        entidad.Detalle = string.IsNullOrWhiteSpace(dto.Detalle) ? null : dto.Detalle.Trim();
        entidad.Idvehiculo = asignacion?.Idvehiculo;
        entidad.Idzona = asignacion?.Idzona;
        entidad.CodigoVehiculo = asignacion?.Codigo;
        entidad.Placa = asignacion?.Placa;
        entidad.Zona = asignacion?.Zona;
        if (dto.Id == 0)
            context.AusenciasCadetes.Add(entidad);

        await context.SaveChangesAsync();
    }

    public async Task EliminarAsync(int id)
    {
        var ausencia = await context.AusenciasCadetes.SingleOrDefaultAsync(x => x.Id == id);
        if (ausencia is null)
            throw new InvalidOperationException("El registro de ausencia ya no existe.");
        context.AusenciasCadetes.Remove(ausencia);
        await context.SaveChangesAsync();
    }

    private async Task<AsignacionDia?> ObtenerAsignacionAsync(int idConductor, DateTime fecha)
    {
        var asignaciones = await context.VehiculoConductors.AsNoTracking()
            .Where(x => x.Idconductor == idConductor && x.Activo == 1 && x.DeletedAt == null &&
                        x.FechaInicio <= fecha && (x.FechaFin == null || x.FechaFin >= fecha))
            .Select(x => new AsignacionDia(
                x.Id, x.Idvehiculo, x.Idzona, x.FechaInicio, x.FechaFin,
                x.Vehiculos.Codigo, x.Vehiculos.Placa, x.Zonas.Nombre))
            .ToListAsync();

        var exactas = asignaciones.Where(x => x.FechaInicio.Date == fecha &&
                                               x.FechaFin.HasValue && x.FechaFin.Value.Date == fecha).ToList();
        var candidatas = exactas.Count > 0
            ? exactas
            : asignaciones.Where(x => x.FechaInicio.Date != fecha || !x.FechaFin.HasValue || x.FechaFin.Value.Date != fecha).ToList();
        if (candidatas.Count > 1)
            throw new InvalidOperationException("Hay varias asignaciones vigentes para el cadete en esa fecha. Corrija las asignaciones antes de guardar la ausencia.");

        return candidatas.SingleOrDefault();
    }

    private sealed record AsignacionDia(
        int Id, int Idvehiculo, int? Idzona, DateTime FechaInicio, DateTime? FechaFin,
        string Codigo, string? Placa, string? Zona);
}

public sealed class CadeteAusenciaOpcionDto
{
    public int Id { get; set; }
    public string Nombre { get; set; } = string.Empty;
    public override string ToString() => Nombre;
}
