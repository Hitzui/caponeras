using Caponeras.App.Dto;
using Caponeras.Data.Models;
using Caponeras.Insfraestructura.Repository;
using Microsoft.EntityFrameworkCore;
using NLog;

namespace Caponeras.App.Services;

public class UnidadMedidaService
{
    private readonly IUnidadMedidaRepository _unidadMedidaRepository;
    private readonly DataContextCaponeras _context;
    private readonly ILogger _logger = LogManager.GetCurrentClassLogger();

    public UnidadMedidaService(IUnidadMedidaRepository unidadMedidaRepository, DataContextCaponeras context)
    {
        _unidadMedidaRepository = unidadMedidaRepository;
        _context = context;
    }

    public string ErrorMessage { get; private set; } = string.Empty;

    public Task<List<UnidadMedidaDto>> GetAll()
    {
        return _unidadMedidaRepository.Query()
            .Select(um => UnidadMedidaDto.FromModel(um))
            .ToListAsync();
    }

    public Task Add(UnidadMedidaDto unidadMedida)
    {
        var um = unidadMedida.ToModel();
        return _unidadMedidaRepository.AddAsync(um);
    }

    public async Task Update(UnidadMedidaDto unidadMedida)
    {
        var um = unidadMedida.ToModel();
        var find = await _unidadMedidaRepository.GetByIdAsync(unidadMedida.IdUnidad);
        if (find is null)
        {
            return;
        }
        find.Nombre = um.Nombre;
        find.Simbolo = um.Simbolo;
        _unidadMedidaRepository.Update(find);
    }

    public async Task<int> SaveAsync(UnidadMedidaDto dto)
    {
        ErrorMessage = string.Empty;
        if (dto is null)
        {
            ErrorMessage = "No se recibieron datos de la unidad de medida.";
            return -1;
        }

        dto.Nombre = dto.Nombre?.Trim() ?? string.Empty;
        dto.Simbolo = dto.Simbolo?.Trim() ?? string.Empty;
        if (string.IsNullOrWhiteSpace(dto.Nombre) || string.IsNullOrWhiteSpace(dto.Simbolo))
        {
            ErrorMessage = "El nombre y el símbolo son obligatorios.";
            return -1;
        }
        if (dto.Nombre.Length > 50 || dto.Simbolo.Length > 10)
        {
            ErrorMessage = "El nombre admite hasta 50 caracteres y el símbolo hasta 10.";
            return -1;
        }

        try
        {
            UnidadesMedidas? existente = null;
            if (dto.IdUnidad > 0)
            {
                existente = await _unidadMedidaRepository.GetByIdAsync(dto.IdUnidad);
                if (existente is null)
                {
                    ErrorMessage = "No se encontró la unidad de medida que se desea actualizar.";
                    return -1;
                }
            }

            var otrasUnidades = await _unidadMedidaRepository.Query()
                .Where(x => x.IdUnidad != dto.IdUnidad)
                .Select(x => new { x.Nombre, x.Simbolo })
                .ToListAsync();

            // La base ya contiene duplicados históricos. Al editar se permite conservar
            // un valor conflictivo existente, pero no introducir uno nuevo.
            var cambioNombre = existente is null ||
                               !string.Equals(existente.Nombre, dto.Nombre, StringComparison.OrdinalIgnoreCase);
            var cambioSimbolo = existente is null ||
                                !string.Equals(existente.Simbolo, dto.Simbolo, StringComparison.OrdinalIgnoreCase);
            if (cambioNombre && otrasUnidades.Any(x =>
                    string.Equals(x.Nombre?.Trim(), dto.Nombre, StringComparison.OrdinalIgnoreCase)))
            {
                ErrorMessage = "Ya existe otra unidad de medida con ese nombre.";
                return -1;
            }
            if (cambioSimbolo && otrasUnidades.Any(x =>
                    string.Equals(x.Simbolo?.Trim(), dto.Simbolo, StringComparison.OrdinalIgnoreCase)))
            {
                ErrorMessage = "Ya existe otra unidad de medida con ese símbolo.";
                return -1;
            }

            if (existente is null)
            {
                dto.Activo = true;
                await Add(dto);
            }
            else
            {
                await Update(dto);
            }

            return await _unidadMedidaRepository.SaveChangeAsync();
        }
        catch (Exception e)
        {
            _logger.Error(e, "Error al guardar la unidad de medida {IdUnidad}", dto.IdUnidad);
            ErrorMessage = e.GetBaseException().Message;
            return -1;
        }
    }

    public async Task<int> Delete(int id)
    {
        ErrorMessage = string.Empty;
        try
        {
            var find = await _unidadMedidaRepository.GetByIdAsync(id);
            if (find is null)
            {
                ErrorMessage = "No se encontró la unidad de medida que se desea eliminar.";
                return -1;
            }

            var tieneReferencias = await _context.Productos.AnyAsync(x => x.IdUnidadMedida == id) ||
                                   await _context.MovimientoInventarios.AnyAsync(x => x.IdUnidadMedida == id) ||
                                   await _context.MantenimientoRepuestos.AnyAsync(x => x.IdUnidadMedida == id);
            if (tieneReferencias)
            {
                ErrorMessage = "No se puede eliminar la unidad porque está utilizada por productos o movimientos.";
                return -1;
            }

            _unidadMedidaRepository.Remove(find);
            return await _unidadMedidaRepository.SaveChangeAsync();
        }
        catch (Exception e)
        {
            _logger.Error(e, "Error al eliminar la unidad de medida {IdUnidad}", id);
            ErrorMessage = e.GetBaseException().Message;
            return -1;
        }
    }
}
