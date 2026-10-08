using Caponeras.App.Dto;
using Caponeras.App.Helpers;
using Caponeras.App.Services;
using DevExpress.XtraScheduler.Internal.Implementations;
using NLog;
using System.ComponentModel;

namespace Caponeras.App.ViewModels.Mantenimiento;

public class PaymentProveedorFormViewModel : BaseViewModel
{
    private MantenimientoService _mantenimientoService;
    private INavigationService _navigationService;
    private readonly ILogger _logger = LogManager.GetCurrentClassLogger();

    public BindingList<ManoObraProveedorDto> ManoObraProveedorBindingList { get; } = new();

    public PaymentProveedorFormViewModel(MantenimientoService mantenimientoService, INavigationService navigationService)
    {
        _mantenimientoService = mantenimientoService;
        _navigationService = navigationService;
    }

    public async Task LoadData()
    {
        try
        {
            if (_navigationService.Query == null) return;
            var appointmentItem = (AppointmentItem)_navigationService.Query;
            var manoObra = await _mantenimientoService.GetManoObraProveedoresTask((int)appointmentItem.Id);
            ManoObraProveedorBindingList.Clear();
            if (manoObra.Count <= 0) return;
            foreach (var mo in manoObra)
            {
                ManoObraProveedorBindingList.Add(mo);
            }
        }
        catch (Exception e)
        {
            _logger.Error(e);
        }
    }

    public async Task<bool> SaveManoObras()
    {
        try
        {
            var save = await _mantenimientoService.SaveManoObra(ManoObraProveedorBindingList.ToList());
            if (save > 0)
            {
                GetMessageAlert(TypeAlert.Success, "Guardar", "Se han guardado los datos de forma correcta", _navigationService.MainView);
                return true;
            }
            else
            {
                GetMessageAlert(TypeAlert.Error, "Error", $"No fue posible guardar los datos. {_mantenimientoService.ErrorMessage}", _navigationService.MainView);
                return false;
            }
        }
        catch (Exception e)
        {
            _logger.Error(e);
            GetMessageAlert(TypeAlert.Error, "Error", $"No fue posible guardar los datos {e.Message}", _navigationService.MainView);
            return false;
        }
    }
}
