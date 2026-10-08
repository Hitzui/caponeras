using Caponeras.App.Dto;
using Caponeras.App.Helpers;
using Caponeras.App.Services;
using Caponeras.App.Views;
using Caponeras.App.Views.Veniculos;
using DevExpress.Mvvm;
using DevExpress.XtraSplashScreen;
using NLog;
using System.ComponentModel;
using INavigationService = Caponeras.App.Helpers.INavigationService;

namespace Caponeras.App.ViewModels.Vehiculo;

public class VehiculosViewModel : BaseViewModel
{
    private VehiculoService _vehiculoService;
    private ILogger _logger = LogManager.GetCurrentClassLogger();
    private readonly INavigationService _navigationService;
    private VehiculosDto? _selectedVehiculo;

    public VehiculosViewModel(VehiculoService vehiculoService, INavigationService navigationService)
    {
        _vehiculoService = vehiculoService;
        _navigationService = navigationService;
        Messenger.Default.Register<VehiculoFormViewModel.VehiculoAgregadoMessage>(
            this,
            async void (_) =>
            {
                try
                {
                    await LoadTask();
                }
                catch (Exception e)
                {
                    _logger.Error(e);
                }
            }
        );
    }

    public BindingList<VehiculosDto> VehiculosBindingList { get; } = new();

    public async Task LoadTask()
    {
        var getAll = await _vehiculoService.GetAll();
        VehiculosBindingList.Clear();
        foreach (var vehiculo in getAll)
        {
            VehiculosBindingList.Add(vehiculo);
        }
    }

    public void SelectedVehiculo(VehiculosDto vehiculoDto)
    {
        _navigationService.Query = vehiculoDto;
        _selectedVehiculo = vehiculoDto;
    }

    public void ShowForm()
    {
        _navigationService.ShowDialog<VehiculosFormView>(query: _selectedVehiculo);
    }
}