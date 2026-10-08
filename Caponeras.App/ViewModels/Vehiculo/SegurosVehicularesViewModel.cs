using System.ComponentModel;
using Caponeras.App.Dto;
using Caponeras.App.Helpers;
using Caponeras.App.Services;

namespace Caponeras.App.ViewModels.Vehiculo;

public class SegurosVehicularesViewModel : BaseViewModel
{
    private readonly SegurosVehicularesService _service;
    private readonly INavigationService _navigationService;

    public SegurosVehicularesViewModel(SegurosVehicularesService service, INavigationService navigationService)
    {
        _service = service;
        _navigationService = navigationService;
    }

    public BindingList<SeguroVehicularDto> SegurosBindingList { get; } = new();
    public string ErrorMessage => _service.ErrorMessage;

    public async Task Load()
    {
        var items = await _service.GetAll();
        SegurosBindingList.Clear();
        foreach (var item in items)
            SegurosBindingList.Add(item);
    }

    public Task<List<VehiculosDto>> GetVehiculos(int? includeId = null) => _service.GetVehiculos(includeId);
    public Task<List<AseguradorasDto>> GetAseguradoras(int? includeId = null) => _service.GetAseguradoras(includeId);
    public Task<List<TipoSeguroDto>> GetTiposSeguro(int? includeId = null) => _service.GetTiposSeguro(includeId);
    public Task<int> Save(SeguroVehicularDto dto) => _service.Save(dto);

    public void ShowMessage(TypeAlert type, string title, string body) =>
        GetMessageAlert(type, title, body, _navigationService.MainView);

    public async Task Deactivate(SeguroVehicularDto dto)
    {
        if (dto.Idseguro <= 0)
            return;

        var result = await _service.Deactivate(dto.Idseguro);
        if (result > 0)
        {
            await Load();
            ShowMessage(TypeAlert.Success, "Seguros vehiculares", "La póliza se marcó como inactiva y se conservó en el historial.");
        }
        else
        {
            ShowMessage(TypeAlert.Error, "Seguros vehiculares",
                string.IsNullOrWhiteSpace(ErrorMessage) ? "No fue posible desactivar la póliza." : ErrorMessage);
        }
    }
}
