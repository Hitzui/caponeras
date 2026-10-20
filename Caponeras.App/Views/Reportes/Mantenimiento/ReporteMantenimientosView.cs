using Caponeras.App.Helpers;
using Caponeras.App.Services;
using Caponeras.App.Views.Reportes.Mantenimiento;
using DevExpress.XtraEditors;

namespace Caponeras.App.Views.Reportes;

public partial class ReporteMantenimientosView : XtraForm
{
    private readonly MantenimientoReportesService? _service;

    public ReporteMantenimientosView()
    {
        InitializeComponent();
        _fechaDesde.DateTime = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1);
        _fechaHasta.DateTime = DateTime.Today;
        _radioReporte.SelectedIndexChanged += (_, _) =>
        {
            _subtitle.Text = _radioReporte.SelectedIndex switch
            {
                1 => "Rango de fechas de los pagos registrados de mano de obra.",
                2 => "Costo de repuestos usados en mantenimientos finalizados en el rango.",
                3 => "Mantenimientos que coinciden con el rango y su estado actual en la agenda.",
                _ => "Rango de fecha de finalización de los mantenimientos."
            };
        };
        _btnGenerar.Click += async (_, _) => await GenerarReporteAsync();
    }

    public ReporteMantenimientosView(MantenimientoReportesService service) : this()
    {
        _service = service;
    }

    private async Task GenerarReporteAsync()
    {
        if (_fechaHasta.DateTime.Date < _fechaDesde.DateTime.Date)
        {
            XtraMessageBox.Show(this, "La fecha final no puede ser anterior a la fecha inicial.",
                "Rango de fechas", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        try
        {
            _btnGenerar.Enabled = false;
            var fechaDesde = _fechaDesde.DateTime.Date;
            var fechaHasta = _fechaHasta.DateTime.Date;
            switch (_radioReporte.SelectedIndex)
            {
                case 0:
                {
                    var resultados = await Servicio.ObtenerRealizadosAsync(fechaDesde, fechaHasta);
                    if (!MostrarSinDatos(resultados.Count, "mantenimientos realizados")) return;
                    var reporte = new ReportMantenimientosRealizados { DataSource = resultados };
                    ConfigurarRango(reporte, fechaDesde, fechaHasta);
                    HelperMethods.LoadReport(reporte, "Mantenimientos realizados");
                    break;
                }
                case 1:
                {
                    var resultados = await Servicio.ObtenerManoObraPagadaAsync(fechaDesde, fechaHasta);
                    if (!MostrarSinDatos(resultados.Count, "pagos de mano de obra")) return;
                    var reporte = new ReportManoObraPagada { DataSource = resultados };
                    ConfigurarRango(reporte, fechaDesde, fechaHasta);
                    HelperMethods.LoadReport(reporte, "Mano de obra pagada");
                    break;
                }
                case 2:
                {
                    var resultados = await Servicio.ObtenerCostosRepuestosAsync(fechaDesde, fechaHasta);
                    if (!MostrarSinDatos(resultados.Count, "repuestos de mantenimiento")) return;
                    var reporte = new ReportCostoRepuestos { DataSource = resultados };
                    ConfigurarRango(reporte, fechaDesde, fechaHasta);
                    HelperMethods.LoadReport(reporte, "Costo de repuestos");
                    break;
                }
                case 3:
                {
                    var resultados = await Servicio.ObtenerEstadoMantenimientosAsync(fechaDesde, fechaHasta);
                    if (!MostrarSinDatos(resultados.Count, "mantenimientos en el rango")) return;
                    var reporte = new ReportEstadoMantenimientos { DataSource = resultados };
                    ConfigurarRango(reporte, fechaDesde, fechaHasta);
                    HelperMethods.LoadReport(reporte, "Estado de mantenimientos");
                    break;
                }
            }
        }
        catch (Exception ex)
        {
            XtraMessageBox.Show(this, $"No fue posible generar el reporte: {ex.Message}",
                "Reporte de mantenimiento", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        finally
        {
            _btnGenerar.Enabled = true;
        }
    }

    private MantenimientoReportesService Servicio => _service ??
        throw new InvalidOperationException("El servicio de reportes no está disponible.");

    private bool MostrarSinDatos(int cantidad, string concepto)
    {
        if (cantidad > 0) return true;
        XtraMessageBox.Show(this, $"No hay {concepto} en el rango seleccionado.",
            "Sin datos", MessageBoxButtons.OK, MessageBoxIcon.Information);
        return false;
    }

    private static void ConfigurarRango(DevExpress.XtraReports.UI.XtraReport reporte,
        DateTime fechaDesde, DateTime fechaHasta)
    {
        reporte.Parameters[0].Value = fechaDesde;
        reporte.Parameters[1].Value = fechaHasta;
    }
}
