using Caponeras.App.Dto;
using Caponeras.App.Helpers;
using Caponeras.App.Services;
using System.ComponentModel;

namespace Caponeras.App.ViewModels.Mantenimiento;

public class ProveedoreFormViewModel : BaseViewModel
{
    private MantenimientoService _mantenimientoService;
    private readonly INavigationService _navigationService;
    public BindingList<ProveedoresDto> ProveedoresBindingList { get; } = new();
    public BindingList<ProveedoresDto> SelectedProveedoresBindingList { get; } = new();
    private int _idMantenimiento;
    public int IdMantenimiento
    {
        get => _idMantenimiento;
        set => SetValue(ref _idMantenimiento, value);
    }

    public ProveedoreFormViewModel(MantenimientoService mantenimientoService, INavigationService navigationService)
    {
        _mantenimientoService = mantenimientoService;
        _navigationService = navigationService;
    }

    public async Task LoadData()
    {
        var data = await _mantenimientoService.GetProveedoresAll();
        ProveedoresBindingList.Clear();
        foreach (var item in data)
        {
            ProveedoresBindingList.Add(item);
        }
    }

    public async Task LoadDataSelectedProveedores()
    {
        var data = await _mantenimientoService.GetProveedoresMantenimiento(IdMantenimiento);
        SelectedProveedoresBindingList.Clear();
        foreach (var item in data)
        {
            SelectedProveedoresBindingList.Add(item);
        }
    }

    public async Task Save(List<ProveedoresDto>? proveedoresSeleccionados)
    {
        if (proveedoresSeleccionados is null)
        {
            return;
        }

        if (proveedoresSeleccionados.Count <= 0)
        {
            return;
        }

        var save = await _mantenimientoService.SaveMantenimientoProveedores(proveedoresSeleccionados, IdMantenimiento);
        if (save > 0)
        {
            GetMessageAlert(TypeAlert.Success, "Guardar", "Se han ingresado los datos de forma correcta", _navigationService.MainView);
        }
        else
        {
            GetMessageAlert(TypeAlert.Error, "Error", $"No fue posible guardar los datos: {_mantenimientoService.ErrorMessage}", _navigationService.MainView);
        }
    }
}