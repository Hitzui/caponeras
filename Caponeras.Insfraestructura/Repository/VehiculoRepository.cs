using Caponeras.Data.Models;

namespace Caponeras.Insfraestructura.Repository;

public class VehiculoRepository : Repository<Vehiculos>, IVehiculoRepository
{
    public VehiculoRepository(DataContextCaponeras context) : base(context)
    {
    }
}