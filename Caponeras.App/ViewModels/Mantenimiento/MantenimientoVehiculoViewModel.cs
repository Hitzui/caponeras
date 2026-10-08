using Caponeras.App.Dto;
using Caponeras.App.Helpers;
using Caponeras.App.Services;
using Caponeras.App.Views.Mantenimiento;
using DevExpress.XtraScheduler;
using NLog;
using System.ComponentModel;

namespace Caponeras.App.ViewModels.Mantenimiento;

public class MantenimientoVehiculoViewModel : BaseViewModel
{
    private readonly INavigationService _navigationService;
    private MantenimientoService _mantenimientoService;
    private readonly VehiculoService _vehiculoService;
    private readonly ILogger _logger = LogManager.GetCurrentClassLogger();

    private VehiculosDto? _vehiculoDto;
    public BindingList<MantenimientoDto> BindingMantenimientoDtos { get; } = [];
    public BindingList<TipoMantenimientoDto> BindingTipoMantenimientoDtos { get; } = [];
    public BindingList<MantenimientoLabelDto> BindingMantenimientoLabelDtos { get; } = [];
    public BindingList<MantenimientoStatusDto> BindingMantenimienStatusDtos { get; } = [];

    public MantenimientoVehiculoViewModel(
        MantenimientoService mantenimientoService,
        VehiculoService vehiculoService,
        INavigationService navigationService
    )
    {
        _mantenimientoService = mantenimientoService;
        _vehiculoService = vehiculoService;
        _navigationService = navigationService;
    }

    public async Task GetAllMantenimientoStatus()
    {
        var data = await _mantenimientoService.GetMantenimientoStatus();
        SetBinding(BindingMantenimienStatusDtos, data);
    }

    public async Task GetAllMantenimientoLabel()
    {
        var data = await _mantenimientoService.GetMantenimientoLabel();
        SetBinding(BindingMantenimientoLabelDtos, data);
    }

    public async Task GetAllTipoMantenimiento()
    {
        var data = await _mantenimientoService.GetAllTipoMantenimiento();
        BindingTipoMantenimientoDtos.Clear();
        SetBinding(BindingTipoMantenimientoDtos, data);
    }

    public async Task GetAllMantenimientos()
    {
        var data = await _mantenimientoService.GetAllMantenimientos();
        SetBinding(BindingMantenimientoDtos, data);
    }

    public Task<List<VehiculosDto>> GetVehiculos()
    {
        return _vehiculoService.GetAll();
    }

    public async Task<bool> Save(Appointment? apt)
    {
        try
        {
            if (apt is null)
            {
                return false;
            }

            var id = (int)apt.Id;
            var mantenimiento = new MantenimientoDto
            {
                Idmantenimiento = id,
                Titulo = apt.Subject,
                FechaFin = apt.End,
                FechaInicio = apt.Start,
                Descripcion = apt.Location,
                Observaciones = apt.Description,
                Idtipomantenimiento = (int)apt.ResourceId,
                Idlabel = (int)apt.LabelKey,
                Idstatus = (int)apt.StatusKey,
                Color = "",
                Idusuario = _navigationService.CurrentUser.Idusuario
            };

            var save = await _mantenimientoService.Save(mantenimiento, _vehiculoDto);
            if (save > 0)
            {
                GetMessageAlert(TypeAlert.Success, "Guardar", "Se ha ingresado el mantenimiento de forma correcta",
                    _navigationService.MainView);
            }
            else
            {
                GetMessageAlert(TypeAlert.Error, "Error", $"Error: {_mantenimientoService.ErrorMessage}",
                    _navigationService.MainView);
                return false;
            }

            return true;
        }
        catch (Exception e)
        {
            _logger.Error(e);
            return false;
        }
    }

    private static void SetBinding<T>(BindingList<T> bindingList, List<T> data)
    {
        bindingList.Clear();
        foreach (var item in data)
        {
            bindingList.Add(item);
        }
    }

    public void SetSelectedVehiculo(VehiculosDto? getFocusedValue)
    {
        _vehiculoDto = getFocusedValue;
    }

    public bool AllowDragAndDrop(Appointment eAppointment)
    {
        if (Convert.ToInt32(eAppointment.Id) == 0) return true;
        var mantenimiento = BindingMantenimientoDtos.FirstOrDefault(x => x.Idmantenimiento == Convert.ToInt32(eAppointment.Id));
        return mantenimiento?.MantenimientoStatusDto?.AllowDrag ?? false;
    }

    public async Task<VehiculosDto> FindVehiculo(int appointmentId)
    {
        var findM = await _mantenimientoService.FindMantenimiento(appointmentId);
        if (findM is null)
        {
            return new VehiculosDto();
        }

        return findM.VehiculoDto ?? new VehiculosDto();
    }

    public void ShowFormRepuestos(Appointment appointment)
    {
        _navigationService.Query = appointment;
        _navigationService.ShowDialog<RepuestosFormView>(query: appointment);
    }

    public async Task<bool> Delete(Appointment? apt)
    {
        try
        {
            if (apt is null)
            {
                return false;
            }

            var delete = await _mantenimientoService.DeleteCita(apt);
            if (delete > 0)
            {
                GetMessageAlert(
                    TypeAlert.Success,
                    "Eliminar",
                    "se ha eliminado el mantenimiento de forma correcta",
                    _navigationService.MainView);
                return true;
            }
            else
            {
                GetMessageAlert(
                    TypeAlert.Error,
                    "Error",
                    string.IsNullOrWhiteSpace(_mantenimientoService.ErrorMessage)
                        ? "No fue posible eliminar el mantenimiento programado"
                        : _mantenimientoService.ErrorMessage,
                    _navigationService.MainView);
                return false;
            }
        }
        catch (Exception e)
        {
            _logger.Error(e);
            return false;
        }
    }

    public void ShowFormProveedores(Appointment appointment)
    {
        _navigationService.Query = appointment;
        _navigationService.ShowDialog<PaymentProveedorFormView>(query: appointment);
    }
}
