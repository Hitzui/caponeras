using Caponeras.App.Dto;
using Caponeras.App.Helpers;
using Caponeras.App.Services;
using Caponeras.Data.Models;

namespace Caponeras.App.ViewModels.Conductores;

public class PagoCuotaCadeteFormViewModel : BaseViewModel
{
    private INavigationService _navigationService;
    private ConductoresService _conductoresService;
    private ConductoresDto? _conductor;
    private CuotaDiariasDto? _cuotaDiaria;

    public PagoCuotaCadeteFormViewModel(ConductoresService conductoresService, INavigationService navigationService)
    {
        _conductoresService = conductoresService;
        _navigationService = navigationService;
    }

    public CuotaDiariasDto? CuotaDiariasDto
    {
        get => _cuotaDiaria;
        set => SetProperty(ref _cuotaDiaria, value, nameof(CuotaDiariasDto));
    }

    public ConductoresDto? ConductorDto
    {
        get => _conductor;
        set => SetProperty(ref _conductor, value, nameof(ConductoresDto));
    }

    public async Task LoadConductor()
    {
        if (_navigationService.Query is not ConductoresDto conductor)
        {
            GetMessageAlert(TypeAlert.Warning,
                "Cargar Conductor",
                "No se ha seleccionado un conductor.",
                _navigationService.MainView);
            return;
        }

        ConductorDto = await _conductoresService.FindById(conductor.Idconductor);
        if (ConductorDto is null)
        {
            GetMessageAlert(TypeAlert.Warning, "Cuota",
                "El cadete seleccionado está inactivo o ya no existe. Solo se puede registrar cuotas para cadetes activos.",
                _navigationService.MainView);
            return;
        }

        CuotaDiariasDto =
            await _conductoresService.GetCuotaDiariaByConductor(ConductorDto.Idconductor, DateTime.Now);
    }

    public async Task LoadCuotaDiaria(DateTime fecha)
    {
        if (ConductorDto is null)
        {
            GetMessageAlert(TypeAlert.Warning,
                "Cargar Cuota Diaria",
                "No se ha seleccionado un conductor.",
                _navigationService.MainView);
            return;
        }

        CuotaDiariasDto =
            await _conductoresService.GetCuotaDiariaByConductor(ConductorDto.Idconductor, fecha);
    }

    public async Task<bool> RegistrarPago(decimal monto, string observaciones, DateTime fecha)
    {
        var mainView = _navigationService.MainView;
        if (ConductorDto is null)
        {
            GetMessageAlert(TypeAlert.Warning, "Cuota", "No se ha seleccioando un cadete", mainView);
            return false;
        }

        if (ConductorDto.Estado != EstadoCadete.ACTIVO)
        {
            GetMessageAlert(TypeAlert.Warning, "Cuota", "Solo se puede registrar cuotas para cadetes activos.", mainView);
            return false;
        }

        var save = await _conductoresService.RegistrarPagoCuotaDiaria(
            ConductorDto.Idconductor, monto, observaciones, fecha,
            _navigationService.CurrentUser);
        if (save)
        {
            GetMessageAlert(TypeAlert.Success, "Registrar Cuota", "Se ha registrado la cuota de forma correcta",
                mainView);
            return true;
        }

        GetMessageAlert(TypeAlert.Error,
            "Error", $"No fue posible registrar la cuota. {_conductoresService.ErrorMessage}", mainView);
        return false;
    }
}
