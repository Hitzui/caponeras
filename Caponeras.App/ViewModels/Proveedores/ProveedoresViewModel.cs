using Caponeras.App.Dto;
using Caponeras.App.Helpers;
using Caponeras.App.Services;
using Caponeras.App.Views.Proveedores;
using DevExpress.Mvvm;
using NLog;
using System.ComponentModel;
using static Caponeras.App.ViewModels.Proveedores.ProveedoresFormViewModel;

namespace Caponeras.App.ViewModels.Proveedores;

public class ProveedoresViewModel : BaseViewModel, ICrudViewModel
{
    private ProveedoresService _proveedoresService;
    private Helpers.INavigationService _navigationService;
    private readonly ILogger _logger = LogManager.GetCurrentClassLogger();

    public BindingList<ProveedoresDto> ProveedoresBindingList { get; } = new();
    public ProveedoresViewModel(ProveedoresService proveedoresService, Helpers.INavigationService navigationService)
    {
        _proveedoresService = proveedoresService;
        _navigationService = navigationService;
        Messenger.Default.Register<ProveedoresFormViewModel.ProveedorGuardadoMessage>(
            this,
            async void (_) =>
            {
                try
                {
                    await LoadData();
                }
                catch (Exception e)
                {
                    _logger.Error(e);
                }
            }
        );
    }

    public async Task LoadData()
    {
        var data = await _proveedoresService.GetAllAsync();
        ProveedoresBindingList.Clear();
        foreach (var item in data)
        {
            ProveedoresBindingList.Add(item);
        }
    }

    public async Task DeleteAsync<TDto>(TDto? dto)
    {
        if (_navigationService.Query is not ProveedoresDto proveedorDto) return;
        var delete = await _proveedoresService.Delete(proveedorDto);
        if (delete > 0)
        {
            Messenger.Default.Send(new ProveedorGuardadoMessage());
            GetMessageAlert(TypeAlert.Informacion, "Eliminar", "Se ha eliminado el proveedor de forma correcta", _navigationService.MainView);
        }
        else
        {
            GetMessageAlert(TypeAlert.Error, "Error", "No fue posible eliminar el proveedor", _navigationService.MainView);
        }
    }

    public Task SaveAsync<TDto>(TDto? dto)
    {
        return SaveProveedorAsync(dto);
    }

    private async Task SaveProveedorAsync<TDto>(TDto? dto)
    {
        if (dto is not ProveedoresDto proveedorDto)
        {
            GetMessageAlert(TypeAlert.Warning, "Guardar proveedor", "Seleccione o ingrese un proveedor válido.",
                _navigationService.MainView);
            return;
        }

        var resultado = await _proveedoresService.Save(proveedorDto);
        if (resultado > 0)
        {
            Messenger.Default.Send(new ProveedorGuardadoMessage());
            GetMessageAlert(TypeAlert.Success, "Guardar proveedor", "El proveedor se guardó correctamente.",
                _navigationService.MainView);
        }
        else
        {
            GetMessageAlert(TypeAlert.Error, "Guardar proveedor",
                string.IsNullOrWhiteSpace(_proveedoresService.Message)
                    ? "No fue posible guardar el proveedor."
                    : _proveedoresService.Message,
                _navigationService.MainView);
        }
    }

    public void EditAsync<TDto>(TDto? dto)
    {
        if (dto is not ProveedoresDto proveedorDto)
            return;

        _navigationService.Query = proveedorDto;
        _navigationService.ShowDialog<ProveedoresFormView>(query: proveedorDto);
    }

    public void AddAsync()
    {
        _navigationService.Query = null;
        _navigationService.ShowDialog<ProveedoresFormView>();
    }

    public void SetSelectedProveedor(ProveedoresDto? current)
    {
        _navigationService.Query = current;
    }
}
