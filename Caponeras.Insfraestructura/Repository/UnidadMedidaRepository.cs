using Caponeras.Data.Models;

namespace Caponeras.Insfraestructura.Repository;

public class UnidadMedidaRepository : Repository<UnidadesMedidas>, IUnidadMedidaRepository
{
    public UnidadMedidaRepository(DataContextCaponeras context) : base(context)
    {
    }
}