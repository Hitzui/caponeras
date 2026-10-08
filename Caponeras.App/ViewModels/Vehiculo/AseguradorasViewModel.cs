using System.ComponentModel;
using Caponeras.App.Dto;
using Caponeras.App.Helpers;
using Caponeras.App.Services;

namespace Caponeras.App.ViewModels.Vehiculo;

public class AseguradorasViewModel : BaseViewModel
{
    private readonly AseguradorasService _service;
    private readonly INavigationService _navigationService;

    public AseguradorasViewModel(AseguradorasService service, INavigationService navigationService)
    {
        _service = service;
        _navigationService = navigationService;
    }

    public BindingList<AseguradorasDto> AseguradorasBindingList { get; } = new();
    public string ErrorMessage => _service.ErrorMessage;

    public async Task Load()
    {
        var items = await _service.GetAseguradoras();
        AseguradorasBindingList.Clear();
        foreach (var item in items)
            AseguradorasBindingList.Add(item);
    }

    public Task<int> Save(AseguradorasDto dto) => _service.Save(dto);

    public void ShowMessage(TypeAlert type, string title, string body) =>
        GetMessageAlert(type, title, body, _navigationService.MainView);

    public async Task Delete(AseguradorasDto dto)
    {
        if (dto.Idaseguradora <= 0)
            return;

        var result = await _service.Delete(dto.Idaseguradora);
        if (result > 0)
        {
            await Load();
            ShowMessage(TypeAlert.Success, "Agencias de seguros",
                "La agencia se eliminó o se desactivó si tenía pólizas registradas.");
        }
        else
        {
            ShowMessage(TypeAlert.Error, "Agencias de seguros",
                string.IsNullOrWhiteSpace(ErrorMessage) ? "No fue posible eliminar la agencia." : ErrorMessage);
        }
    }
}
