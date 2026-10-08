using Caponeras.Data.Models;

namespace Caponeras.Insfraestructura.Repository;

public class MovimientoInventarioRepository : Repository<MovimientoInventarios>,IMovimientoInventarioRepository
{
    public MovimientoInventarioRepository(DataContextCaponeras context) : base(context)
    {
    }
}