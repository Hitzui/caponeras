using Caponeras.App.Dto;
using Caponeras.Insfraestructura.Repository;
using Microsoft.EntityFrameworkCore;

namespace Caponeras.App.Services;

public class CajaService
{
    private readonly ICajaRepository _cajaRepository;
    public CajaService(ICajaRepository cajaRepository)
    {
        _cajaRepository = cajaRepository;
    }

    public Task<List<CajaDto>> GetAllTask()
    {
        return _cajaRepository.Query().Include(c => c.Agencias)
            .Select(c => new CajaDto(c.Idcaja, c.Codcaja, c.Descripcion, c.Idagencia!.Value, new AgenciaDto(c.Agencias)))
            .ToListAsync<CajaDto>();
    }
}