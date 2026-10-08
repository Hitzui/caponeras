using System.Diagnostics;
using Caponeras.App.Helpers;
using Caponeras.App.Services;

namespace Caponeras.App.ViewModels.Mcaja;

public class AperturaCajaViewModel : BaseViewModel
{
    private MaestroCajaService _maestroCajaService;
    private INavigationService _navigationService;

    public AperturaCajaViewModel(MaestroCajaService maestroCajaService, INavigationService navigationService)
    {
        _maestroCajaService = maestroCajaService;
        _navigationService = navigationService;
    }

    public async Task<bool> AperturarCaja()
    {
        try
        {
            var aperturar = await _maestroCajaService.AperturarCaja();
            if (aperturar)
            {
                GetMessageAlert(TypeAlert.Success, "Aperturar Caja","Apertura de caja de forma correcta", _navigationService.MainView);
            }
            else
            {
                GetMessageAlert(TypeAlert.Error, "Aperturar Caja","No fue posible aperturar caja", _navigationService.MainView);
            }
            return aperturar;
        }
        catch (Exception e)
        {
            Debug.WriteLine(e);
            return false;
        }
    }
}