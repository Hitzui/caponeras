using Caponeras.App.Dto;
using Caponeras.Data.Models;
using Microsoft.EntityFrameworkCore;
using NLog;

namespace Caponeras.App.Services;

public class AseguradorasService
{
    private readonly DataContextCaponeras _context;
    private readonly ILogger _logger = LogManager.GetCurrentClassLogger();

    public AseguradorasService(DataContextCaponeras context)
    {
        _context = context;
    }

    public string ErrorMessage { get; private set; } = string.Empty;

    public Task<List<AseguradorasDto>> GetAseguradoras()
    {
        return _context.Aseguradoras.AsNoTracking()
            .OrderByDescending(a => a.Activo)
            .ThenBy(a => a.Nombre)
            .Select(a => new AseguradorasDto(a))
            .ToListAsync();
    }

    public async Task<int> Save(AseguradorasDto dto)
    {
        ErrorMessage = string.Empty;
        if (dto is null)
        {
            ErrorMessage = "No se recibieron los datos de la aseguradora.";
            return -1;
        }

        dto.Nombre = dto.Nombre?.Trim() ?? string.Empty;
        dto.NombreCorto = dto.NombreCorto?.Trim() ?? string.Empty;
        dto.Telefono = dto.Telefono?.Trim() ?? string.Empty;
        dto.Correo = dto.Correo?.Trim() ?? string.Empty;
        dto.SitioWeb = dto.SitioWeb?.Trim() ?? string.Empty;
        dto.Direccion = dto.Direccion?.Trim() ?? string.Empty;

        if (string.IsNullOrWhiteSpace(dto.Nombre))
        {
            ErrorMessage = "El nombre de la agencia es obligatorio.";
            return -1;
        }
        if (dto.Nombre.Length > 100 || dto.NombreCorto.Length > 30 || dto.Telefono.Length > 30 ||
            dto.Correo.Length > 100 || dto.SitioWeb.Length > 150 || dto.Direccion.Length > 255)
        {
            ErrorMessage = "Se excedió la longitud permitida en uno o más campos.";
            return -1;
        }

        try
        {
            var entity = dto.Idaseguradora > 0
                ? await _context.Aseguradoras.FirstOrDefaultAsync(a => a.Idaseguradora == dto.Idaseguradora)
                : null;
            if (dto.Idaseguradora > 0 && entity is null)
            {
                ErrorMessage = "No se encontró la agencia que desea actualizar.";
                return -1;
            }

            var duplicate = await _context.Aseguradoras.AsNoTracking()
                .AnyAsync(a => a.Idaseguradora != dto.Idaseguradora &&
                               a.Nombre.ToLower() == dto.Nombre.ToLower());
            if (duplicate)
            {
                ErrorMessage = "Ya existe una agencia con ese nombre.";
                return -1;
            }

            if (entity is null)
            {
                entity = new Aseguradoras
                {
                    Nombre = dto.Nombre,
                    Activo = dto.Activo,
                    CreatedAt = DateTime.Now
                };
                await _context.Aseguradoras.AddAsync(entity);
            }
            else
            {
                entity.Nombre = dto.Nombre;
                entity.Activo = dto.Activo;
            }

            entity.NombreCorto = EmptyToNull(dto.NombreCorto);
            entity.Telefono = EmptyToNull(dto.Telefono);
            entity.Correo = EmptyToNull(dto.Correo);
            entity.SitioWeb = EmptyToNull(dto.SitioWeb);
            entity.Direccion = EmptyToNull(dto.Direccion);
            entity.UpdatedAt = DateTime.Now;

            return await _context.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            _logger.Error(ex, "Error al guardar la agencia aseguradora {IdAseguradora}", dto.Idaseguradora);
            ErrorMessage = ex.GetBaseException().Message;
            return -1;
        }
    }

    public async Task<int> Delete(int id)
    {
        ErrorMessage = string.Empty;
        try
        {
            var insurer = await _context.Aseguradoras.FirstOrDefaultAsync(a => a.Idaseguradora == id);
            if (insurer is null)
            {
                ErrorMessage = "No se encontró la agencia que desea eliminar.";
                return -1;
            }

            var hasPolicies = await _context.SeguroVehiculars.AnyAsync(s => s.Idaseguradora == id);
            if (hasPolicies)
            {
                insurer.Activo = false;
                insurer.UpdatedAt = DateTime.Now;
            }
            else
            {
                _context.Aseguradoras.Remove(insurer);
            }

            return await _context.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            _logger.Error(ex, "Error al eliminar la agencia aseguradora {IdAseguradora}", id);
            ErrorMessage = ex.GetBaseException().Message;
            return -1;
        }
    }

    private static string? EmptyToNull(string value) => string.IsNullOrWhiteSpace(value) ? null : value;
}
