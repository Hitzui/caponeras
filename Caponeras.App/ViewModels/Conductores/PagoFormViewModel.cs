using System.ComponentModel;
using Caponeras.App.Dto;
using Caponeras.App.Services;

namespace Caponeras.App.ViewModels.Conductores;

public class PagoFormViewModel : BaseViewModel
{
    private ConductoresService _conductoresService;

    public PagoFormViewModel(ConductoresService conductoresService)
    {
        _conductoresService = conductoresService;
    }

    public BindingList<CuotaDetalleDto> ListaCuotasBindingList { get; private set; }

    public async Task GetAll(DateTime fecha)
    {
        var data = await _conductoresService.GetDetalleCuotas(fecha);
        ListaCuotasBindingList = new BindingList<CuotaDetalleDto>(data);
    }
}