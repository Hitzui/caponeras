using System.ComponentModel;
using Caponeras.App.Dto;
using Caponeras.App.Helpers;
using Caponeras.App.Services;

namespace Caponeras.App.ViewModels.UnidadMedida;

public class UnidadMedidaViewModel : BaseViewModel
{
    private readonly UnidadMedidaService _unidadMedidaService;
    private readonly INavigationService _navigationService;

    public UnidadMedidaViewModel(UnidadMedidaService unidadMedidaService, INavigationService navigationService)
    {
        _unidadMedidaService = unidadMedidaService;
        _navigationService = navigationService;
    }

    public BindingList<UnidadMedidaDto> UnidadMedidaBindingList { get; } = new();
    public string ErrorMessage => _unidadMedidaService.ErrorMessage;

    public async Task Load()
    {
        var getAll = await _unidadMedidaService.GetAll();
        UnidadMedidaBindingList.Clear();
        foreach (var item in getAll)
        {
            UnidadMedidaBindingList.Add(item);
        }
    }

    public Task<int> Save(UnidadMedidaDto unidadMedida)
    {
        return _unidadMedidaService.SaveAsync(unidadMedida);
    }

    public void ShowMessage(TypeAlert type, string title, string body)
    {
        GetMessageAlert(type, title, body, _navigationService.MainView);
    }

    public async Task Delete(UnidadMedidaDto unidadMedidaDto)
    {
        try
        {
            if (unidadMedidaDto is null || unidadMedidaDto.IdUnidad <= 0)
            {
                ShowMessage(TypeAlert.Warning, "Eliminar", "Seleccione una unidad de medida válida.");
                return;
            }

            var delete = await _unidadMedidaService.Delete(unidadMedidaDto.IdUnidad);
            if (delete > 0)
            {
                UnidadMedidaBindingList.Remove(unidadMedidaDto);
                ShowMessage(TypeAlert.Success, "Eliminar", "Se eliminó la unidad de medida correctamente.");
            }
            else
            {
                ShowMessage(TypeAlert.Error, "Eliminar",
                    string.IsNullOrWhiteSpace(_unidadMedidaService.ErrorMessage)
                        ? "No fue posible eliminar la unidad de medida."
                        : _unidadMedidaService.ErrorMessage);
            }
        }
        catch (Exception e)
        {
            ShowMessage(TypeAlert.Error, "Eliminar",
                $"No fue posible eliminar la unidad de medida: {e.GetBaseException().Message}");
        }
    }
}
