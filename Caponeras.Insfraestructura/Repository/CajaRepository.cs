using Caponeras.Data.Models;

namespace Caponeras.Insfraestructura.Repository;

public class CajaRepository : Repository<Cajas>,ICajaRepository
{
    public CajaRepository(DataContextCaponeras context) : base(context)
    {
    }
}