using Caponeras.App.Dto;
using Caponeras.Data.Models;
using Microsoft.EntityFrameworkCore;
using NLog;

namespace Caponeras.App.Services;

public class SegurosVehicularesService
{
    private readonly DataContextCaponeras _context;
    private readonly ILogger _logger = LogManager.GetCurrentClassLogger();

    public SegurosVehicularesService(DataContextCaponeras context)
    {
        _context = context;
    }

    public string ErrorMessage { get; private set; } = string.Empty;

    public async Task<List<SeguroVehicularDto>> GetAll()
    {
        var policies = await _context.SeguroVehiculars.AsNoTracking()
            .Include(s => s.Vehiculos)
            .Include(s => s.Aseguradoras)
            .Include(s => s.TipoSeguros)
            .OrderByDescending(s => s.FechaInicio)
            .ToListAsync();
        return policies.Select(s => new SeguroVehicularDto(s)).ToList();
    }

    public async Task<List<SeguroVehicularDto>> GetExpiringWithinDays(int days)
    {
        var today = DateTime.Today;
        var throughDate = today.AddDays(days);
        var policies = await _context.SeguroVehiculars.AsNoTracking()
            .Include(s => s.Vehiculos)
            .Include(s => s.Aseguradoras)
            .Include(s => s.TipoSeguros)
            .Where(s => s.Estado == 1 &&
                        s.FechaVencimiento >= today &&
                        s.FechaVencimiento < throughDate.AddDays(1))
            .OrderBy(s => s.FechaVencimiento)
            .ToListAsync();

        return policies.Select(s => new SeguroVehicularDto(s)).ToList();
    }

    public Task<List<VehiculosDto>> GetVehiculos(int? includeId = null)
    {
        return _context.Vehiculos.AsNoTracking()
            .Where(v => v.Estado == "ACTIVO" || (includeId.HasValue && v.Idvehiculo == includeId.Value))
            .OrderBy(v => v.Codigo)
            .Select(v => new VehiculosDto(v))
            .ToListAsync();
    }

    public Task<List<AseguradorasDto>> GetAseguradoras(int? includeId = null)
    {
        return _context.Aseguradoras.AsNoTracking()
            .Where(a => a.Activo || (includeId.HasValue && a.Idaseguradora == includeId.Value))
            .OrderBy(a => a.Nombre)
            .Select(a => new AseguradorasDto(a))
            .ToListAsync();
    }

    public async Task<List<TipoSeguroDto>> GetTiposSeguro(int? includeId = null)
    {
        var types = await _context.TipoSeguros.AsNoTracking()
            .Where(t => t.Activo == true || (includeId.HasValue && t.Idtiposeguro == includeId.Value))
            .OrderBy(t => t.Nombre)
            .Select(t => new TipoSeguroDto(t))
            .ToListAsync();

        // La tabla de tipos ya existe en el modelo. Si está vacía, inicializar su opción legal básica.
        if (types.Count == 0 && !includeId.HasValue)
        {
            var soa = await _context.TipoSeguros.FirstOrDefaultAsync(t => t.Codigo == "SOA");
            if (soa is null)
            {
                soa = new TipoSeguros
                {
                    Codigo = "SOA",
                    Nombre = "SOA - Responsabilidad civil por daños a terceros",
                    Descripcion = "Seguro obligatorio de responsabilidad civil vehicular establecido en la Ley 431 de Nicaragua.",
                    Activo = true
                };
                await _context.TipoSeguros.AddAsync(soa);
                await _context.SaveChangesAsync();
            }
            else
            {
                soa.Activo = true;
                await _context.SaveChangesAsync();
            }

            types.Add(new TipoSeguroDto(soa));
        }

        return types;
    }

    public async Task<int> Save(SeguroVehicularDto dto)
    {
        ErrorMessage = string.Empty;
        if (dto is null)
        {
            ErrorMessage = "No se recibieron los datos de la póliza.";
            return -1;
        }

        dto.NumeroPoliza = dto.NumeroPoliza?.Trim() ?? string.Empty;
        dto.NumeroCertificado = dto.NumeroCertificado?.Trim() ?? string.Empty;
        dto.Moneda = string.IsNullOrWhiteSpace(dto.Moneda) ? "C$" : dto.Moneda.Trim();
        dto.ArchivoPoliza = dto.ArchivoPoliza?.Trim() ?? string.Empty;
        dto.Observaciones = dto.Observaciones?.Trim() ?? string.Empty;

        if (dto.Idvehiculo <= 0 || dto.Idaseguradora <= 0 || dto.TipoSeguro <= 0)
        {
            ErrorMessage = "Seleccione el vehículo, la agencia y el tipo de seguro.";
            return -1;
        }
        if (string.IsNullOrWhiteSpace(dto.NumeroPoliza) || dto.NumeroPoliza.Length > 50 ||
            dto.NumeroCertificado.Length > 50 || dto.ArchivoPoliza.Length > 255)
        {
            ErrorMessage = "El número de póliza es obligatorio (máximo 50 caracteres); certificado y archivo admiten hasta 50 y 255 caracteres.";
            return -1;
        }
        if (dto.FechaInicio == DateTime.MinValue || dto.FechaVencimiento == DateTime.MinValue ||
            dto.FechaVencimiento.Date < dto.FechaInicio.Date)
        {
            ErrorMessage = "La fecha de vencimiento debe ser igual o posterior a la fecha de inicio.";
            return -1;
        }
        if (dto.PrimaAnual <= 0 || dto.Deducible < 0)
        {
            ErrorMessage = "La prima debe ser mayor que cero y el deducible no puede ser negativo.";
            return -1;
        }

        try
        {
            var current = dto.Idseguro > 0
                ? await _context.SeguroVehiculars.FirstOrDefaultAsync(s => s.Idseguro == dto.Idseguro)
                : null;
            if (dto.Idseguro > 0 && current is null)
            {
                ErrorMessage = "No se encontró la póliza que desea actualizar.";
                return -1;
            }

            var vehicle = await _context.Vehiculos.AsNoTracking()
                .FirstOrDefaultAsync(v => v.Idvehiculo == dto.Idvehiculo);
            if (vehicle is null || (current is null || current.Idvehiculo != dto.Idvehiculo) && vehicle.Estado != "ACTIVO")
            {
                ErrorMessage = "Seleccione un vehículo activo existente.";
                return -1;
            }

            var insurer = await _context.Aseguradoras.AsNoTracking()
                .FirstOrDefaultAsync(a => a.Idaseguradora == dto.Idaseguradora);
            if (insurer is null || (current is null || current.Idaseguradora != dto.Idaseguradora) && !insurer.Activo)
            {
                ErrorMessage = "Seleccione una agencia de seguros activa.";
                return -1;
            }

            var typeIsActive = await _context.TipoSeguros.AnyAsync(t =>
                t.Idtiposeguro == dto.TipoSeguro && t.Activo == true);
            if (!typeIsActive && (current is null || current.TipoSeguro != dto.TipoSeguro))
            {
                ErrorMessage = "Seleccione un tipo de seguro activo.";
                return -1;
            }

            var duplicatePolicy = await _context.SeguroVehiculars.AsNoTracking()
                .AnyAsync(s => s.Idseguro != dto.Idseguro &&
                               s.NumeroPoliza.ToLower() == dto.NumeroPoliza.ToLower());
            if (duplicatePolicy)
            {
                ErrorMessage = "Ya existe una póliza registrada con ese número.";
                return -1;
            }

            var entity = current ?? new SeguroVehiculars();
            entity.Idvehiculo = dto.Idvehiculo;
            entity.Idaseguradora = dto.Idaseguradora;
            entity.NumeroPoliza = dto.NumeroPoliza;
            entity.NumeroCertificado = EmptyToNull(dto.NumeroCertificado)!;
            entity.TipoSeguro = dto.TipoSeguro;
            entity.FechaInicio = dto.FechaInicio.Date;
            entity.FechaVencimiento = dto.FechaVencimiento.Date;
            entity.PrimaAnual = dto.PrimaAnual;
            entity.Moneda = dto.Moneda;
            entity.Deducible = dto.Deducible;
            entity.ArchivoPoliza = EmptyToNull(dto.ArchivoPoliza)!;
            entity.Observaciones = EmptyToNull(dto.Observaciones)!;
            entity.Estado = dto.Estado ?? 1;
            entity.UpdatedAt = DateTime.Now;
            if (current is null)
            {
                entity.CreatedAt = DateTime.Now;
                await _context.SeguroVehiculars.AddAsync(entity);
            }

            var changes = await _context.SaveChangesAsync();
            return changes == 0 && current is not null ? 1 : changes;
        }
        catch (Exception ex)
        {
            _logger.Error(ex, "Error al guardar póliza vehicular {IdSeguro}", dto.Idseguro);
            ErrorMessage = ex.GetBaseException().Message;
            return -1;
        }
    }

    public async Task<int> Deactivate(int id)
    {
        ErrorMessage = string.Empty;
        try
        {
            var policy = await _context.SeguroVehiculars.FirstOrDefaultAsync(s => s.Idseguro == id);
            if (policy is null)
            {
                ErrorMessage = "No se encontró la póliza que desea eliminar.";
                return -1;
            }

            policy.Estado = 0;
            policy.UpdatedAt = DateTime.Now;
            return await _context.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            _logger.Error(ex, "Error al desactivar póliza vehicular {IdSeguro}", id);
            ErrorMessage = ex.GetBaseException().Message;
            return -1;
        }
    }

    private static string? EmptyToNull(string value) => string.IsNullOrWhiteSpace(value) ? null : value;
}
