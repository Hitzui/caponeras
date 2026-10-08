using Caponeras.Data.Models;

namespace Caponeras.Insfraestructura.Repository;

public class AgenciaRepository : Repository<Agencias>,IAgenciaRepository
{
    public AgenciaRepository(DataContextCaponeras context) : base(context)
    {
    }
}