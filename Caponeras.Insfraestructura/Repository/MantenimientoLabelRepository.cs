using Caponeras.Data.Models;

namespace Caponeras.Insfraestructura.Repository;

public class MantenimientoLabelRepository : Repository<MantenimientoLabels>,IMantenimientoLabelRepository
{
    public MantenimientoLabelRepository(DataContextCaponeras context) : base(context)
    {
    }
}