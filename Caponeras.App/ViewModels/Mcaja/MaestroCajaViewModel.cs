using System.ComponentModel;
using Caponeras.App.Dto;
using Caponeras.App.Helpers;
using Caponeras.App.Services;
using Caponeras.App.Views.Reportes.MaestroCaja;

namespace Caponeras.App.ViewModels.Mcaja;

public class MaestroCajaViewModel : BaseViewModel
{
    private MaestroCajaService _service;
    public BindingList<DetaMovimientosDto> DetaMovimientosBindingList { get; } = new();

    public MaestroCajaViewModel(MaestroCajaService service)
    {
        _service = service;
    }

    public MaestroCajaDto? MaestroCaja { get; private set; }

    public async Task LoadMaestroCaja()
    {
        MaestroCaja = await _service.GetMaestroCaja();
        var movimientos = await _service.GetMovimientosCaja(MaestroCaja.IdMaestroCaja);
        DetaMovimientosBindingList.Clear();
        foreach (var mov in movimientos)
        {
            DetaMovimientosBindingList.Add(mov);
        }
    }

    public void ReporteDiarioCaja()
    {
        var reporte = new ReportCajaDiario();
        reporte.Parameters[0].Value = DateTime.Today;
        HelperMethods.LoadReport(reporte);
    }
}