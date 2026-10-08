using Caponeras.App.Dto;
using Caponeras.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Caponeras.App.Services;

public class MovimientoInventarioService
{
    private DataContextCaponeras _context;

    public MovimientoInventarioService(DataContextCaponeras context)
    {
        _context = context;
    }

    public async Task<(List<MovimientoInventarioGridDto> Data, int Total)> Search(
        DateTime desde,
        DateTime hasta,
        object? tipo,
        object? referencia,
        string? searchProducto,
        int startRowIndex,
        int pageSize = 5)
    {
        var query = _context.MovimientoInventarios
            .AsNoTracking()
            .Where(x => x.Fecha.Date >= desde.Date && x.Fecha < hasta.AddDays(1));

        if (tipo is TipoMovimiento tipoMovimiento)
            query = query.Where(x => x.TipoMovimiento == tipoMovimiento);

        if (referencia is ReferenciaInventario referenciaInventario)
            query = query.Where(x => x.ReferenciaTipo == referenciaInventario);

        if (!string.IsNullOrWhiteSpace(searchProducto))
        {
            searchProducto = searchProducto.Trim();
            query = query.Where(x =>
                x.Productos.Nombre.Contains(searchProducto) ||
                x.Productos.Codigo.Contains(searchProducto));
        }

        var total = await query.CountAsync();

        var data = await query
            .OrderByDescending(x => x.IdMovimiento)
            .Select(x => new MovimientoInventarioGridDto(
                x.IdMovimiento,
                x.Fecha,
                x.Productos.Nombre,
                x.TipoMovimiento,
                x.Entrada,
                x.Salida,
                x.StockAnterior,
                x.StockNuevo,
                $"{x.ReferenciaTipo} #{x.ReferenciaId}",
                x.ReferenciaTipo,
                x.Usuarios.Nombre,
                x.Observaciones
            ))
            .Skip(startRowIndex)
            .Take(pageSize)
            .ToListAsync();

        return (data, total);
    }

    public async Task<List<MovimientoInventarioGridDto>> GetReporteInventario(DateTime desde, DateTime hasta)
    {
        return await _context.MovimientoInventarios
            .AsNoTracking()
            .Where(x =>
                x.Fecha.Date >= desde.Date &&
                x.Fecha < hasta.AddDays(1))
            .OrderBy(x => x.Fecha)
            .ThenBy(x => x.Productos.Nombre)
            .ThenBy(x => x.IdMovimiento)
            .Select(x => new MovimientoInventarioGridDto(
                x.IdMovimiento,
                x.Fecha,
                x.Productos.Nombre,
                x.TipoMovimiento,
                x.Entrada,
                x.Salida,
                x.StockAnterior,
                x.StockNuevo,
                $"{x.ReferenciaTipo} #{x.ReferenciaId}",
                x.ReferenciaTipo,
                x.Usuarios.Nombre,
                x.Observaciones
            ))
            .ToListAsync();
    }

}