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

                if (radioGroup.SelectedIndex != 4 &&
                    (txtFechaDesde.EditValue is null || txtFechaHasta.EditValue is null))
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
                if ((radioGroup.SelectedIndex is 0 or 1 or 3) && fechaFin.Date < fechaInicio.Date)
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
                        await _viewModel.ObtenerReporteAsignacionesAsync(fechaInicio, fechaFin);
                        if (_viewModel.ListaAsignaciones.Count == 0)
                        {
                            XtraMessageBox.Show(
                                "No hay asignaciones de vehículos para el rango seleccionado.",
                                "Sin datos para el reporte",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
                            return;
                        }

                        var reporteAsignaciones = new ReportAsignacionesCadetes();
                        reporteAsignaciones.DataSource = _viewModel.ListaAsignaciones;
                        reporteAsignaciones.Parameters[0].Value = fechaInicio.Date;
                        reporteAsignaciones.Parameters[1].Value = fechaFin.Date;
                        HelperMethods.LoadReport(reporteAsignaciones);
                        break;
                    case 1:
                        // Cuotas esperadas y pagos por cadete, vehículo y zona durante el rango.
                        await _viewModel.ObtenerReporteCuotaRangoAsync(fechaInicio, fechaFin);
                        if (_viewModel.ListaCuotaResumen.Count == 0)
                        {
                            XtraMessageBox.Show(
                                "No hay asignaciones con cuota configurada ni pagos registrados en el rango seleccionado.",
                                "Sin datos para el reporte",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
                            return;
                        }

                        var reporteRango = new ReportCuotaPorRango();
                        reporteRango.CargarDatos(_viewModel.ListaCuotaResumen);
                        reporteRango.Parameters[0].Value = fechaInicio.Date;
                        reporteRango.Parameters[1].Value = fechaFin.Date;
                        HelperMethods.LoadReport(reporteRango);
                        break;
                    case 2:
                        // Recaudación del día y cuotas programadas para las unidades asignadas.
                        await _viewModel.ObtenerReporteCuotaDiariasAsync(fechaInicio);
                        if (_viewModel.ListaCuotaDiarias.Count == 0)
                        {
                            XtraMessageBox.Show(
                                "No hay cuotas registradas ni unidades asignadas con cuota configurada para la fecha seleccionada.",
                                "Sin datos para el reporte",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
                            return;
                        }

                        var reporte = new ReportCuotaPorDia();
                        reporte.DataSource = _viewModel.ListaCuotaDiarias;
                        reporte.Parameters[0].Value = fechaInicio;
                        HelperMethods.LoadReport(reporte);
                        break;
                    case 3:
                        await _viewModel.ObtenerReporteAusenciasAsync(fechaInicio, fechaFin);
                        if (_viewModel.ListaAusencias.Count == 0)
                        {
                            XtraMessageBox.Show(
                                "No hay ausencias registradas en el rango seleccionado.",
                                "Sin datos para el reporte",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
                            return;
                        }

                        var reporteAusencias = new ReportAusenciasCadetes();
                        reporteAusencias.DataSource = _viewModel.ListaAusencias;
                        reporteAusencias.Parameters[0].Value = fechaInicio.Date;
                        reporteAusencias.Parameters[1].Value = fechaFin.Date;
                        HelperMethods.LoadReport(reporteAusencias);
                        break;
                    case 4:
                        await _viewModel.ObtenerReporteLicenciasCadetesAsync();
                        if (_viewModel.ListaLicenciasCadetes.Count == 0)
                        {
                            XtraMessageBox.Show(
                                "No hay cadetes registrados para mostrar.",
                                "Sin datos para el reporte",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
                            return;
                        }

                        var reporteLicencias = new ReportLicenciasCadetes();
                        reporteLicencias.DataSource = _viewModel.ListaLicenciasCadetes;
                        HelperMethods.LoadReport(reporteLicencias);
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
