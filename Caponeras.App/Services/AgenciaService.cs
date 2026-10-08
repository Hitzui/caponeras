using Caponeras.App.Dto;
using Caponeras.Insfraestructura.Repository;
using Microsoft.EntityFrameworkCore;

namespace Caponeras.App.Services;

public class AgenciaService
{
    private readonly IAgenciaRepository _agenciaRepository;

    public AgenciaService(IAgenciaRepository agenciaRepository)
    {
        _agenciaRepository = agenciaRepository;
    }

    public Task<List<AgenciaDto>> GetAllTask()
    {
        return _agenciaRepository.Query()
            .Select(a => new AgenciaDto(a))
            .ToListAsync();
    }
}