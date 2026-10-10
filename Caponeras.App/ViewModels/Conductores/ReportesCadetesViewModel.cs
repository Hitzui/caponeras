using Caponeras.App.Dto;
using Caponeras.App.Helpers;
using Caponeras.App.Services;
using Caponeras.Data.Models;

namespace Caponeras.App.ViewModels.Conductores;

public class ReportesCadetesViewModel : BaseViewModel
{
    private INavigationService _navigationService;
    private CadetesReportesService _cadetesReportesServices;
    public List<ReporteCuotaDto> ListaCuotaDiarias { get; } = [];
    public List<ReporteCuotaDto> ListaCuotaResumen { get; } = [];
    public List<ReporteAsignacionCadeteDto> ListaAsignaciones { get; } = [];
    public List<AusenciaCadeteDto> ListaAusencias { get; } = [];
    public List<ReporteLicenciaCadeteDto> ListaLicenciasCadetes { get; } = [];
    public ReportesCadetesViewModel(INavigationService navigationService, CadetesReportesService cadetesReportesServices)
    {
        _navigationService = navigationService;
        _cadetesReportesServices = cadetesReportesServices;
    }

    public async Task ObtenerReporteCuotaDiariasAsync(DateTime fecha)
    {
        var data = await _cadetesReportesServices.ObtenerReporteCuotaDiariasAsync(fecha);
        ListaCuotaDiarias.Clear();
        ListaCuotaDiarias.AddRange(data);
    }

    public async Task ObtenerReporteAsignacionesAsync(DateTime fechaInicio, DateTime fechaFin)
    {
        var data = await _cadetesReportesServices.ObtenerReporteAsignacionesAsync(fechaInicio, fechaFin);
        ListaAsignaciones.Clear();
        ListaAsignaciones.AddRange(data);
    }

    public async Task ObtenerReporteAusenciasAsync(DateTime fechaInicio, DateTime fechaFin)
    {
        var data = await _cadetesReportesServices.ObtenerReporteAusenciasAsync(fechaInicio, fechaFin);
        ListaAusencias.Clear();
        ListaAusencias.AddRange(data);
    }

    public async Task ObtenerReporteLicenciasCadetesAsync()
    {
        var data = await _cadetesReportesServices.ObtenerReporteLicenciasCadetesAsync();
        ListaLicenciasCadetes.Clear();
        ListaLicenciasCadetes.AddRange(data);
    }

    public async Task ObtenerReporteCuotaRangoAsync(DateTime fechaInicio, DateTime fechaFin)
    {
        var data = await _cadetesReportesServices.ObtenerReporteCuotaRangoAsync(fechaInicio, fechaFin);
        ListaCuotaResumen.Clear();
        ListaCuotaResumen.AddRange(data);
    }
}
