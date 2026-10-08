using Caponeras.App.Dto;
using Caponeras.App.Helpers;
using Caponeras.App.Services;
using DevExpress.Mvvm;
using INavigationService = Caponeras.App.Helpers.INavigationService;

namespace Caponeras.App.ViewModels.Vehiculo;

public class VehiculoFormViewModel : BaseViewModel
{
    private readonly VehiculoService _service;
    private readonly INavigationService _navigationService;

    private VehiculosDto? _vehiculosDto;
    public VehiculosDto? VehiculosDto
    {
        get => _vehiculosDto;
        set => SetValue(ref _vehiculosDto, value);
    }

    public VehiculoFormViewModel(VehiculoService vehiculoService, INavigationService navigationService)
    {
        _vehiculosDto = new VehiculosDto();
        _service = vehiculoService;
        _navigationService = navigationService;
    }

    public async Task<int> GuardarVehiculo()
    {
        if (VehiculosDto is null)
        {
            return -1;
        }
        var result = await _service.GuardarVehiculo(VehiculosDto);
        if (result > 0)
        {
            Messenger.Default.Send(new VehiculoAgregadoMessage());
        }

        return result;
    }

    public void Load()
    {
        VehiculosDto = _navigationService.Query as VehiculosDto;
    }

    public class VehiculoAgregadoMessage
    {
    }
}