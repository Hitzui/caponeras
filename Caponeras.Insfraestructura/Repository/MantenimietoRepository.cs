using Caponeras.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Caponeras.Insfraestructura.Repository;

public class MantenimientoRepository : Repository<Mantenimientos>,IMantenimietoRepository
{
    public MantenimientoRepository(DataContextCaponeras context) : base(context)
    {
    }

    public Task<Mantenimientos?> GetMantenimientoById(int id)
    {
        return Context.Mantenimientos
            .Include(m => m.MantenimientoStatuses)
            .Include(m => m.MantenimientoLabels)
            .Include(m=>m.Vehiculos)
            .Include(m=>m.TipoMantenimientos)
            .SingleOrDefaultAsync(m => m.Idmantenimineto == id);
    }
}