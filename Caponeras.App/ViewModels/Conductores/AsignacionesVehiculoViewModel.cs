using System.ComponentModel;
using Caponeras.App.Dto;
using Caponeras.App.Helpers;
using Caponeras.App.Services;
using DevExpress.XtraScheduler;

namespace Caponeras.App.ViewModels.Conductores;

public class AsignacionesVehiculoViewModel : BaseViewModel
{
    private VehiculoService _vehiculoService;
    private INavigationService _navigationService;

    public BindingList<VehiculoConductorDto> VehiculoConductoresBindingList { get; private set; } = [];

    public AsignacionesVehiculoViewModel(VehiculoService vehiculoService, INavigationService navigationService)
    {
        _vehiculoService = vehiculoService;
        _navigationService = navigationService;
    }

    public async Task LoadData()
    {
        var data = await _vehiculoService.GetAllVehiculoConductores();
        VehiculoConductoresBindingList = new BindingList<VehiculoConductorDto>(data);
    }

    public async Task<bool> UpdateAsignacionVehiculo(Appointment appointment)
    {
        var save = await _vehiculoService.UpdateVehiculoConductor(appointment);
        if (save)
        {
            GetMessageAlert(TypeAlert.Success, "Guardar", "Se ha actualizado los datos de forma correcta",
                _navigationService.MainView);
        }
        else
        {
            GetMessageAlert(TypeAlert.Error, "Error",
                string.IsNullOrWhiteSpace(_vehiculoService.ErrorMessage)
                    ? "No fue posible guardar los datos"
                    : _vehiculoService.ErrorMessage,
                _navigationService.MainView);
        }

        return save;
    }

    public async Task<bool> DeleteAsignacionVehiculo(int? idasignacion)
    {
        if (idasignacion is null or <= 0) return false;
        var delete = await _vehiculoService.DeleteVehiculoConductor(idasignacion.Value);
        if (delete)
        {
            GetMessageAlert(TypeAlert.Success, "Eliminar", "Se ha eliminado la asignación de forma correcta",
                _navigationService.MainView);
        }
        else
        {
            GetMessageAlert(TypeAlert.Error, "Error",
                string.IsNullOrWhiteSpace(_vehiculoService.ErrorMessage)
                    ? "No fue posible eliminar la asignación"
                    : _vehiculoService.ErrorMessage,
                _navigationService.MainView);
        }

        return delete;
    }
}
