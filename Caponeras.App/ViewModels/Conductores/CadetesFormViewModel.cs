using Caponeras.App.Dto;
using Caponeras.App.Helpers;
using Caponeras.App.Services;
using DevExpress.Mvvm;
using NLog;
using INavigationService = Caponeras.App.Helpers.INavigationService;

namespace Caponeras.App.ViewModels.Conductores;

public class CadetesFormViewModel : BaseViewModel
{
    private ILogger _logger = LogManager.GetCurrentClassLogger();
    private readonly ConductoresService _conductoresService;
    private readonly INavigationService _navigationService;
    public ConductoresDto? ConductorDto { get; set; }

    public CadetesFormViewModel(ConductoresService conductoresService, INavigationService navigationService)
    {
        _conductoresService = conductoresService;
        _navigationService = navigationService;
    }

    public void Load()
    {
        ConductorDto = _navigationService.Query as ConductoresDto;
    }

    public async Task<int> GuardarCadete()
    {
        try
        {
            if (ConductorDto == null) return -1;
            int result;
            if (ConductorDto.Idconductor <= 0)
            {
                result = await _conductoresService.Add(ConductorDto);
            }
            else
            {
                result = await _conductoresService.Edit(ConductorDto);
            }

            if (result > 0)
            {
                Messenger.Default.Send(new CadeteAgregadoMessage());
                GetMessageAlert(TypeAlert.Success, "Cadete", "Se han guardado los datos de forma correcta", _navigationService.MainView);
            }
            else
            {
                GetMessageAlert(TypeAlert.Error, "Error", "No fue posbile guardar los datos.", _navigationService.MainView);
            }

            return result;
        }
        catch (Exception e)
        {
            GetMessageAlert(TypeAlert.Error, "Error", $"No fue posible guardar los datos: {e.GetBaseException().Message}", _navigationService.MainView);
            _logger.Error(e);
            return -1;
        }
    }

    public class CadeteAgregadoMessage
    {
    }

    public Task<bool> ValidarIdentificacion(string query, int excluirId = 0)
    {
        return _conductoresService.ExisteIdentificacion(query, excluirId);
    }
}
