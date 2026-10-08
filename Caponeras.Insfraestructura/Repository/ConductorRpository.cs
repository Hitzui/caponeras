using Caponeras.Data.Models;

namespace Caponeras.Insfraestructura.Repository;

public class ConductorRpository : Repository<Conductors>, IConductorRpository
{
    public ConductorRpository(DataContextCaponeras context) : base(context)
    {
    }
}