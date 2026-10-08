using Caponeras.App.Dto;
using Caponeras.Data.Models;
using Caponeras.Insfraestructura.Repository;
using Microsoft.EntityFrameworkCore;
using NLog;

namespace Caponeras.App.Services;

public class CategoriaProductosService
{
    private readonly ICategoriaProductosRepository _categoriaProductosRepository;
    private readonly DataContextCaponeras _context;
    private readonly ILogger _logger = LogManager.GetCurrentClassLogger();

    public CategoriaProductosService(
        ICategoriaProductosRepository categoriaProductosRepository,
        DataContextCaponeras context)
    {
        _categoriaProductosRepository = categoriaProductosRepository;
        _context = context;
    }

    public string ErrorMessage { get; private set; } = string.Empty;

    public Task<List<CategoriaProductoDto>> GetAllAsync()
    {
        return _categoriaProductosRepository.Query()
            .Select(cp => CategoriaProductoDto.FromModel(cp))
            .ToListAsync();
    }

    public async Task<int> Save(CategoriaProductoDto categoriaProductoDto)
    {
        ErrorMessage = string.Empty;
        if (categoriaProductoDto is null)
        {
            ErrorMessage = "No se recibieron los datos de la categoría.";
            return -1;
        }

        categoriaProductoDto.Nombre = categoriaProductoDto.Nombre?.Trim() ?? string.Empty;
        categoriaProductoDto.Descripcion = categoriaProductoDto.Descripcion?.Trim() ?? string.Empty;
        if (string.IsNullOrWhiteSpace(categoriaProductoDto.Nombre))
        {
            ErrorMessage = "El nombre de la categoría es obligatorio.";
            return -1;
        }
        if (categoriaProductoDto.Nombre.Length > 100 || categoriaProductoDto.Descripcion.Length > 255)
        {
            ErrorMessage = "El nombre admite hasta 100 caracteres y la descripción hasta 255.";
            return -1;
        }

        try
        {
            CategoriasProductos? existente = null;
            if (categoriaProductoDto.IdCategoria > 0)
            {
                existente = await _categoriaProductosRepository.GetByIdAsync(categoriaProductoDto.IdCategoria);
                if (existente is null)
                {
                    ErrorMessage = "No se encontró la categoría que se desea actualizar.";
                    return -1;
                }
            }

            var nombreCambio = existente is null ||
                               !string.Equals(existente.Nombre, categoriaProductoDto.Nombre,
                                   StringComparison.OrdinalIgnoreCase);
            if (nombreCambio)
            {
                var nombreEnUso = await _categoriaProductosRepository.Query()
                    .AnyAsync(x => x.IdCategoria != categoriaProductoDto.IdCategoria &&
                                   x.Nombre.ToUpper() == categoriaProductoDto.Nombre.ToUpper());
                if (nombreEnUso)
                {
                    ErrorMessage = "Ya existe otra categoría con ese nombre.";
                    return -1;
                }
            }

            if (existente is null)
            {
                categoriaProductoDto.Activo = true;
                await _categoriaProductosRepository.AddAsync(categoriaProductoDto.ToModel());
            }
            else
            {
                existente.Descripcion = categoriaProductoDto.Descripcion;
                existente.Nombre = categoriaProductoDto.Nombre;
                _categoriaProductosRepository.Update(existente);
            }

            return await _categoriaProductosRepository.SaveChangeAsync();
        }
        catch (Exception e)
        {
            _logger.Error(e, "Error al guardar la categoría {IdCategoria}", categoriaProductoDto.IdCategoria);
            ErrorMessage = e.GetBaseException().Message;
            return -1;
        }
    }

    public async Task<int> Delete(CategoriaProductoDto? row)
    {
        ErrorMessage = string.Empty;
        if (row is null || row.IdCategoria <= 0)
        {
            ErrorMessage = "Seleccione una categoría válida para eliminar.";
            return -1;
        }

        try
        {
            var find = await _categoriaProductosRepository.GetByIdAsync(row.IdCategoria);
            if (find is null)
            {
                ErrorMessage = "No se encontró la categoría que se desea eliminar.";
                return -1;
            }

            var tieneProductos = await _context.Productos.AnyAsync(x => x.IdCategoria == row.IdCategoria);
            var tieneSubcategorias = await _context.CategoriasProductos
                .AnyAsync(x => x.IdCategoriaPadre == row.IdCategoria);
            if (tieneProductos || tieneSubcategorias)
            {
                ErrorMessage = "No se puede eliminar la categoría porque tiene productos o subcategorías asociadas.";
                return -1;
            }

            _categoriaProductosRepository.Remove(find);
            return await _categoriaProductosRepository.SaveChangeAsync();
        }
        catch (Exception e)
        {
            _logger.Error(e, "Error al eliminar la categoria de producto con id {IdCategoria}", row.IdCategoria);
            ErrorMessage = e.GetBaseException().Message;
            return -1;
        }
    }
}
