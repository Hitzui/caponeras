using System.ComponentModel;
using Caponeras.App.Dto;
using Caponeras.App.Helpers;
using Caponeras.App.Services;
using Caponeras.Data.Models;

namespace Caponeras.App.ViewModels.Conductores;

public class AsignarVehiculoViewModel : BaseViewModel
{
    private VehiculoService _vehiculoService;
    private INavigationService _navigationService;
    private ConductoresDto? _conductoresDto;
    public BindingList<VehiculosDto> Vehiculos { get; } = new();
    public BindingList<ZonasDto> Zonas { get; } = new();

    public ConductoresDto? ConductoresDto
    {
        get => _conductoresDto;
        set => SetProperty(ref _conductoresDto, value, "ConductoresDto");
    }

    public AsignarVehiculoViewModel(INavigationService navigationService, VehiculoService vehiculoService)
    {
        _navigationService = navigationService;
        _vehiculoService = vehiculoService;
    }

    public void LoadCadete()
    {
        ConductoresDto = _navigationService.Query as ConductoresDto;
    }

    public async Task LoadVehiculos()
    {
        var getAll = await _vehiculoService.GetAll();
        Vehiculos.Clear();
        foreach (var item in getAll)
        {
            Vehiculos.Add(item);
        }
    }

    public async Task LoadZonas()
    {
        var getAllZons = await _vehiculoService.GetAllZonas();
        Zonas.Clear();
        foreach (var zona in getAllZons)
        {
            Zonas.Add(zona);
        }
    }

    public async Task<bool> AsignarVehiculoCadete(int idvehiculo, int idzonas, DateTime inicio, DateTime fin)
    {
        if (ConductoresDto is null)
        {
            GetMessageAlert(TypeAlert.Warning, "Asignar Vehiculo", "No se ha seleccionado un cadete.",
                _navigationService.MainView);
            return false;
        }

        if (ConductoresDto.Estado == EstadoCadete.INACTIVO)
        {
            GetMessageAlert(TypeAlert.Warning, "Asignar Vehiculo", "No puede asignar un vehiculo a un cadete inactivo.",
                _navigationService.MainView);
            return false;
        }
        var asignasion = new VehiculoConductors
        {
            Idvehiculo = idvehiculo,
            Idconductor = ConductoresDto.Idconductor,
            Idzona = idzonas,
            FechaInicio = inicio,
            FechaFin = fin,
            Activo = 1,
        };
        var result = await _vehiculoService.AsignarVehiculoCadete(asignasion);
        if (result)
        {
            GetMessageAlert(TypeAlert.Success, "Asignar", "Se ha asignado el vehiculo en las fechas indicadas",
                _navigationService.MainView);
        }
        else
        {
            GetMessageAlert(TypeAlert.Warning, "Asignación no realizada",
                string.IsNullOrWhiteSpace(_vehiculoService.ErrorMessage)
                    ? "No fue posible asignar el vehículo. Revise el registro de errores."
                    : _vehiculoService.ErrorMessage,
                _navigationService.MainView);
        }

        return result;
    }
}
