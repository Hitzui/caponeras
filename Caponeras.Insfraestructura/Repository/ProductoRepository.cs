using Caponeras.Data.Models;

namespace Caponeras.Insfraestructura.Repository;

public class ProductoRepository : Repository<Productos>,IProductoRepository
{
    public ProductoRepository(DataContextCaponeras context) : base(context)
    {
    }
}