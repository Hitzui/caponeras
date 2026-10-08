using Caponeras.Data.Models;

namespace Caponeras.Insfraestructura.Repository;

public class MantenimientoStatusRepository : Repository<MantenimientoStatuses>, IMantenimientoStatusRepository
{
    public MantenimientoStatusRepository(DataContextCaponeras context) : base(context)
    {
    }
}