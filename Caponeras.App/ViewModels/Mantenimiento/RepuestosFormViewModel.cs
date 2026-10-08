using System.ComponentModel;
using Caponeras.App.Dto;
using Caponeras.App.Helpers;
using Caponeras.App.Services;
using DevExpress.XtraScheduler;

namespace Caponeras.App.ViewModels.Mantenimiento;

public class RepuestosFormViewModel : BaseViewModel
{
    private INavigationService _navigationService;
    private ProductosService _productosService;
    private MantenimientoService _mantenimientoService;
    public BindingList<ProductoDto> ProductosBindingList { get; set; } = new();
    public BindingList<MantenimientoRepuestoDto> RepuestosBindingList { get; set; } = new();

    public RepuestosFormViewModel(INavigationService navigationService, ProductosService productosService,
        MantenimientoService mantenimientoService)
    {
        _navigationService = navigationService;
        _productosService = productosService;
        _mantenimientoService = mantenimientoService;
    }

    public void Load()
    {
        Query = _navigationService.Query;
    }

    public async Task LoadProductos()
    {
        var productos = await _productosService.GetAll();
        ProductosBindingList.Clear();
        foreach (var producto in productos)
        {
            ProductosBindingList.Add(producto);
        }
    }

    public async Task LoadRepuestos(int idmantenimiento)
    {
        var list = await _mantenimientoService.GetRepuestosByMantenimientoId(idmantenimiento);
        RepuestosBindingList.Clear();
        foreach (var repuesto in list)
        {
            RepuestosBindingList.Add(repuesto);
        }
    }

    public async Task<bool> Save(Appointment appointment)
    {
        try
        {
            var save = await _mantenimientoService.SaveRepuestos(appointment, RepuestosBindingList.ToList());
            if (save > 0)
            {
                GetMessageAlert(TypeAlert.Success, "Guardar", "Repuestos guardados correctamente",
                    _navigationService.MainView);
                return true;
            }
            else
            {
                GetMessageAlert(TypeAlert.Error, "Error", $"No se pudieron guardar los repuestos. {_mantenimientoService.ErrorMessage}",
                    _navigationService.MainView);
                return false;
            }
        }
        catch (Exception e)
        {
            GetMessageAlert(TypeAlert.Error, "Error", $"Se produjo un error al aplicar los cambios {e.Message}",
                _navigationService.MainView);
            return false;
        }
    }
}
