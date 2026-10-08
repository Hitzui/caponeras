using Caponeras.App.Dto;
using Caponeras.App.Helpers;
using Caponeras.App.Services;
using Caponeras.App.Views.Mcaja;
using DevExpress.Mvvm;
using NLog;
using System.ComponentModel;
using System.Diagnostics;

namespace Caponeras.App.ViewModels.Mcaja;

public class MovCajaViewModel : BaseViewModel, ICrudViewModel
{
    private readonly ILogger _logger = LogManager.GetCurrentClassLogger();
    private readonly MovCajaService _service;
    private Helpers.INavigationService _navigationService;
    public bool Success { get; private set; }
    public BindingList<MovCajasDto> MovCajasBindingList { get; } = new();
    public BindingList<RubrosDto> RubrosBindingList { get; } = new();

    private MovCajasDto? _selectedMovCaja;

    public MovCajasDto? SelectedMovCaja
    {
        get => _selectedMovCaja;
        set
        {
            if (SetProperty(ref _selectedMovCaja, value, nameof(SelectedMovCaja)))
            {
                _navigationService.Query = _selectedMovCaja;
            }
        }
    }

    public MovCajaViewModel(MovCajaService service, Helpers.INavigationService navigationService)
    {
        _service = service;
        _navigationService = navigationService;
        Messenger.Default.Register<MovCajaGuardadoMessage>(
            this,
            async void (_) =>
            {
                try
                {
                    await LoadData();
                }
                catch (Exception e)
                {
                    Debug.WriteLine(e);
                }
            }
        );
    }

    public async Task LoadData()
    {
        var data = await _service.GetData();
        MovCajasBindingList.Clear();
        foreach (var item in data)
        {
            MovCajasBindingList.Add(item);
        }
    }

    public async Task LoadRubrosTask()
    {
        var rubros = await _service.GetRubros();
        RubrosBindingList.Clear();
        foreach (var item in rubros)
        {
            RubrosBindingList.Add(item);
        }
    }

    public async Task DeleteAsync<TDto>(TDto? dto)
    {
        if (dto is not MovCajasDto movCajas)
        {
            return;
        }
        var delete = await _service.DeleteMovCaja(movCajas.Idmovcaja);
        if (delete)
        {
            Messenger.Default.Send(new MovCajaGuardadoMessage());
            GetMessageAlert(TypeAlert.Success, "Eliminar", "Se ha eliminado el movimiento de caja correctamente",
                _navigationService.MainView);
        }
        else
        {
            GetMessageAlert(TypeAlert.Error, "Error", "No fue posible eliminar el movimiento de caja",
                _navigationService.MainView);
        }
    }

    public async Task SaveAsync<TDto>(TDto? dto)
    {
        try
        {
            if (dto is not MovCajasDto movCajaDto) return;
            var movCaja = movCajaDto.ToModel();
            var save = await _service.SaveMovCaja(movCaja);
            if (save > 0)
            {
                Messenger.Default.Send(new MovCajaGuardadoMessage());
                GetMessageAlert(TypeAlert.Success, "Guardar", "Se ha ingresado el movimiento de caja correctamente",
                    _navigationService.MainView);
            }
            else
            {
                GetMessageAlert(TypeAlert.Error, "Error", "No fue posible ingresar el movimiento de caja",
                    _navigationService.MainView);
            }
            Success = save > 0;
        }
        catch (Exception e)
        {
            _logger.Error(e);
            GetMessageAlert(TypeAlert.Error, "Error", $"Error: {e.Message}",
                _navigationService.MainView);
        }
    }

    public void EditAsync<TDto>(TDto? dto)
    {
        _navigationService.ShowDialog<MovCajaFormView>(query: _navigationService.Query);
    }

    public void AddAsync()
    {
        _navigationService.ShowDialog<MovCajaFormView>();
    }

    public class MovCajaGuardadoMessage
    {
    }

    public void GetSelectedMovCaja()
    {
        SelectedMovCaja = _navigationService.Query as MovCajasDto;
    }
}