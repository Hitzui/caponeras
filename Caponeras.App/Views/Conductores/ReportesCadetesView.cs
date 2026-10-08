using DevExpress.XtraEditors;
using System;
using System.Diagnostics;
using System.Linq;
using Caponeras.App.Helpers;
using Caponeras.App.ViewModels.Conductores;
using Caponeras.App.Views.Reportes.Cadetes;

namespace Caponeras.App.Views.Conductores
{
    public partial class ReportesCadetesView : DevExpress.XtraEditors.XtraForm
    {
        private ReportesCadetesViewModel _viewModel;
        public ReportesCadetesView(ReportesCadetesViewModel viewModel)
        {
            this._viewModel = viewModel;
            InitializeComponent();
            txtFechaHasta.DateTime = DateTime.Today;
            txtFechaDesde.DateTime = DateTime.Today.AddDays(-6);
            radioGroup.SelectedIndex = 1;
        }

        private async void btnVerReporte_Click(object sender, EventArgs e)
        {
            try
            {
                if (radioGroup.SelectedIndex < 0)
                {
                    XtraMessageBox.Show(
                        "Debe seleccionar un tipo de reporte.",
                        "Reporte",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                    return;
                }

                if (txtFechaDesde.EditValue is null || txtFechaHasta.EditValue is null)
                {
                    XtraMessageBox.Show(
                        "Debe seleccionar las fechas del reporte.",
                        "Rango de fechas",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                    return;
                }

                var fechaInicio = txtFechaDesde.DateTime;
                var fechaFin = txtFechaHasta.DateTime;
                if (radioGroup.SelectedIndex == 1 && fechaFin.Date < fechaInicio.Date)
                {
                    XtraMessageBox.Show(
                        "La fecha 'Hasta' no puede ser anterior a la fecha 'Desde'.",
                        "Rango de fechas",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                    return;
                }

                switch (radioGroup.SelectedIndex)
                {
                    case 0:
                        XtraMessageBox.Show(
                            "El reporte de vehículos asignados todavía no está implementado.",
                            "Reporte",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
                        break;
                    case 1:
                        //pagos realizados por rango de fecha, acumulados por cadete
                        await _viewModel.ObtenerReporteCuotaRangoAsync(fechaInicio, fechaFin);
                        var reporteRango = new ReportCuotaPorRango();
                        reporteRango.DataSource = _viewModel.ListaCuotaResumen;
                        reporteRango.Parameters[0].Value = fechaInicio;
                        reporteRango.Parameters[1].Value = fechaFin;
                        HelperMethods.LoadReport(reporteRango);
                        break;
                    case 2:
                        //pagos realizados por día
                        await _viewModel.ObtenerReporteCuotaDiariasAsync(fechaInicio);
                        var reporte = new ReportCuotaPorDia();
                        reporte.DataSource = _viewModel.ListaCuotaDiarias;
                        reporte.Parameters[0].Value = fechaInicio;
                        HelperMethods.LoadReport(reporte);
                        break;
                    default:
                        XtraMessageBox.Show(
                            "Debe seleccionar un tipo de reporte.",
                            "Reporte",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Warning);
                        break;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                XtraMessageBox.Show(
                    $"No fue posible generar el reporte. {ex.Message}",
                    "Error de reporte",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }
    }
}
