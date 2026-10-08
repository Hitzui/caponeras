using System.ComponentModel;
using Caponeras.App.Dto;
using Caponeras.App.Services;

namespace Caponeras.App.ViewModels.Compras;

public class ProveedorDialogViewModel : BaseViewModel
{
    private ProveedoresService _proveedoresService;

    public BindingList<ProveedoresDto> ProveedoresBindingList { get; } = new();

    public ProveedorDialogViewModel(ProveedoresService proveedoresService)
    {
        _proveedoresService = proveedoresService;
    }

    public async Task Load()
    {
        var data = await _proveedoresService.GetAllAsync();
        ProveedoresBindingList.Clear();
        foreach (var item in data)
        {
            ProveedoresBindingList.Add(item);
        }
    }
}