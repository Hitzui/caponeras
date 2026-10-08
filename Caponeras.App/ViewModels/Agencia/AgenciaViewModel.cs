using Caponeras.App.Dto;
using Caponeras.App.Services;
using Caponeras.Insfraestructura;
using Caponeras.Insfraestructura.Repository;

namespace Caponeras.App.ViewModels.Agencia;

public class AgenciaViewModel
{
    private readonly AgenciaService _service;

    public AgenciaViewModel(AgenciaService service)
    {
        _service = service;
    }

    public Task<List<AgenciaDto>> GetAllTask()
    {
        return _service.GetAllTask();
    }
}