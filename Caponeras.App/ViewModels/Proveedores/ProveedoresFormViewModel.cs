using Caponeras.App.Dto;
using Caponeras.App.Helpers;
using Caponeras.App.Services;
using DevExpress.Mvvm;

namespace Caponeras.App.ViewModels.Proveedores;

public class ProveedoresFormViewModel : BaseViewModel
{
    private ProveedoresService _proveedoresService;
    private Helpers.INavigationService _navigationService;

    public ProveedoresFormViewModel(ProveedoresService proveedoresService, Helpers.INavigationService navigationService)
    {
        _proveedoresService = proveedoresService;
        _navigationService = navigationService;
    }

    private ProveedoresDto? _selectedProveedor;

    public ProveedoresDto? SelectedProveedor
    {
        get => _selectedProveedor;
        set => SetValue(ref _selectedProveedor, value);
    }

    public void Load()
    {
        SelectedProveedor = _navigationService.Query as ProveedoresDto;
    }

    public async Task<int> Save(ProveedoresDto proveedor)
    {
        var save = await _proveedoresService.Save(proveedor);
        if (save > 0)
        {
            Messenger.Default.Send(new ProveedorGuardadoMessage());
            GetMessageAlert(TypeAlert.Success, 
                "Guardar", 
                "Se han guardado los datos de forma correcta",
                _navigationService.MainView);
        }
        else
        {
            GetMessageAlert(TypeAlert.Error, 
                "Error", 
                $"No fue posible guardar los datos del proveedor {_proveedoresService.Message}",
                _navigationService.MainView);
        }

        return save;
    }

    public class ProveedorGuardadoMessage
    {
    }
}