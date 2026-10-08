using Caponeras.Data.Models;

namespace Caponeras.Insfraestructura.Repository;

public class TipoMantenimientoRepository : Repository<TipoMantenimientos>,ITipoMantenimientoRepository
{
    public TipoMantenimientoRepository(DataContextCaponeras context) : base(context)
    {
    }
}