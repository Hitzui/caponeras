using Caponeras.App.Dto;
using Caponeras.App.Services;

namespace Caponeras.App.ViewModels.Caja;

public class CajaViewModel
{
    private readonly CajaService _cajaService;

    public CajaViewModel(CajaService cajaService)
    {
        _cajaService = cajaService;
    }   

    public async Task<List<CajaDto>> GetAll()
    {
        return await _cajaService.GetAllTask();
    }
}