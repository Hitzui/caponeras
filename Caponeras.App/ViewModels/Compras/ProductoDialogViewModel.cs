using Caponeras.App.Dto;
using Caponeras.App.Services;
using System.ComponentModel;

namespace Caponeras.App.ViewModels.Compras;

public class ProductoDialogViewModel : BaseViewModel
{
    private ComprasService _comprasService;
    public BindingList<ProductoDto> ProductosBindingList { get; } = new();
    public ProductoDialogViewModel(ComprasService comprasService)
    {
        _comprasService = comprasService;
    }

    public async Task LoadProductos()
    {
        var data = await _comprasService.GetAllProductos();
        ProductosBindingList.Clear();
        foreach (var item in data)
        {
            ProductosBindingList.Add(item);
        }
    }
}