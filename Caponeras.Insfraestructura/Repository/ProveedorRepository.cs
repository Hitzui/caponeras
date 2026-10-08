using Caponeras.Data.Models;

namespace Caponeras.Insfraestructura.Repository;

public class ProveedorRepository : Repository<Proveedores>,IProveedorRepository
{
    public ProveedorRepository(DataContextCaponeras context) : base(context)
    {
    }
}