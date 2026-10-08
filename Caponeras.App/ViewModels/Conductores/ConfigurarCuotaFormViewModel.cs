using Caponeras.App.Dto;
using Caponeras.App.Helpers;
using Caponeras.App.Services;
using Caponeras.Data.Models;

namespace Caponeras.App.ViewModels.Conductores;

public class ConfigurarCuotaFormViewModel : BaseViewModel
{
    private INavigationService _navigationService;
    private ConductoresService _conductoresService;

    private ConductoresDto? _conductoresDto;

    public ConfigurarCuotaFormViewModel(INavigationService navigationService, ConductoresService conductoresService)
    {
        _navigationService = navigationService;
        _conductoresService = conductoresService;
    }

    public ConductoresDto? ConductoresDto
    {
        get => _conductoresDto;
        set => SetValue(ref _conductoresDto, value);
    }

    public async Task LoadCadete()
    {
        if (_navigationService.Query is not ConductoresDto seleccionado || seleccionado.Idconductor <= 0)
        {
            ConductoresDto = null;
            return;
        }

        ConductoresDto = await _conductoresService.FindById(seleccionado.Idconductor);
        if (ConductoresDto is null)
        {
            GetMessageAlert(TypeAlert.Warning, "Cuota",
                "El cadete seleccionado está inactivo o ya no existe. Solo se puede configurar la cuota de cadetes activos.",
                _navigationService.MainView);
        }
    }

    public async Task ConfigurarCuota(decimal cuota, string observaciones)
    {
        if (cuota <= 0)
        {
            GetMessageAlert(TypeAlert.Warning, "Cuota", "No puede configurar una cuota menor o igual a 0",
                _navigationService.MainView);
            return;
        }

        if (ConductoresDto is null)
        {
            GetMessageAlert(TypeAlert.Warning, "Cuota", "No se ha seleccionado un cadete", _navigationService.MainView);
            return;
        }

        if (ConductoresDto.Estado != EstadoCadete.ACTIVO)
        {
            GetMessageAlert(TypeAlert.Warning, "Cuota", "Solo se puede configurar la cuota de un cadete activo.",
                _navigationService.MainView);
            return;
        }

        var cuotaConfiguracion = new CuotaConfiguracions
        {
            MontoDiario = cuota,
            Idconductor = ConductoresDto.Idconductor,
            Observaciones = observaciones,
            Activo = true,
            CreatedBy = _navigationService.CurrentUser.Idusuario,
            CreatedAt = DateTime.Now
        };
        var save = await _conductoresService.ConfigurarCuota(cuotaConfiguracion);
        if (save)
        {
            GetMessageAlert(TypeAlert.Success, "Cuota", "Se ha configurado la cuota del cadete de forma correcta",
                _navigationService.MainView);
        }
        else
        {
            GetMessageAlert(TypeAlert.Error, "Error",
                $"No fue posible realizar la acción. {_conductoresService.ErrorMessage}",
                _navigationService.MainView);
        }
    }
}
