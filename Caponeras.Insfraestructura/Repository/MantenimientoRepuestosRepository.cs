using Caponeras.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Caponeras.Insfraestructura.Repository;

public class MantenimientoRepuestosRepository : Repository<MantenimientoRepuestos>,IMantenimientoRepuestosRepository
{
    public MantenimientoRepuestosRepository(DataContextCaponeras context) : base(context)
    {
    }

    public Task<List<MantenimientoRepuestos>> GetByMantenimientoId(int mantenimientoId)
    {
        return Context.MantenimientoRepuestos.Where(mr => mr.Idmantenimiento == mantenimientoId).ToListAsync();
    }

    public void RemoveRange(List<MantenimientoRepuestos> data)
    {
        Context.MantenimientoRepuestos.RemoveRange(data);
    }

    public Task AddRange(List<MantenimientoRepuestos> data)
    {
        return Context.MantenimientoRepuestos.AddRangeAsync(data);
    }
}