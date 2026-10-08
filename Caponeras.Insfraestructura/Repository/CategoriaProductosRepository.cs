using Caponeras.Data.Models;

namespace Caponeras.Insfraestructura.Repository;

public class CategoriaProductosRepository : Repository<CategoriasProductos>,ICategoriaProductosRepository
{
    public CategoriaProductosRepository(DataContextCaponeras context) : base(context)
    {
    }
}