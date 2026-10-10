using Caponeras.App.Helpers;
using Caponeras.App.ViewModels.Conductores;
using System;
using System.Linq;
using Caponeras.Data.Models;
using DevExpress.Mvvm.POCO;
using DevExpress.XtraEditors;

namespace Caponeras.App.Views.Conductores
{
    public partial class PagoCuotaCadeteFormView : DevExpress.XtraEditors.XtraForm
    {
        private PagoCuotaCadeteFormViewModel _viewModel;
        private bool _initializing;
        private bool _readyForDateChange;

        public PagoCuotaCadeteFormView(PagoCuotaCadeteFormViewModel viewModel)
        {
            _viewModel = viewModel;
            InitializeComponent();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private async void PagoCuotaCadeteFormView_Load(object sender, EventArgs e)
        {
            _initializing = true;
            btnAceptar.Enabled = false;
            try
            {
                await _viewModel.LoadConductor();
                var conductor = _viewModel.ConductorDto;
                if (conductor == null)
                {
                    btnAceptar.Enabled = false;
                    return;
                }

                txtNombre.Text = conductor.Nombre;
                txtIdentificacion.Text = conductor.Identificacion;
                if (conductor.CuotaConfiguracions is not null)
                {
                    txtCuota.Text = conductor.CuotaConfiguracions.MontoDiario.ToString("C");
                }

                if (conductor.Estado == EstadoCadete.INACTIVO)
                {
                    btnAceptar.Enabled = false;
                }

                txtFecha.DateTime = DateTime.Today;
                await LoadDataForDateAsync(txtFecha.DateTime);
                _readyForDateChange = true;
            }
            catch (Exception ex)
            {
                btnAceptar.Enabled = false;
                await XtraMessageBox.ShowAsync(ex.Message);
            }
            finally
            {
                _initializing = false;
            }
        }

        private async void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtFecha.EditValue is null)
                {
                    txtFecha.ErrorText = "Debe seleccionar una fecha para continuar";
                    return;
                }
                if (_viewModel.AsignacionVehiculoDto is null)
                {
                    txtFecha.ErrorText = "El cadete no tiene una asignación de vehículo para esa fecha.";
                    return;
                }
                var monto = HelperMethods.ToDecimal(txtMonto.EditValue);
                if (monto <= 0)
                {
                    txtMonto.ErrorText = "El monto debe ser mayor a cero.";
                    return;
                }

                btnAceptar.Enabled = false;
                var guardado = await _viewModel.RegistrarPago(monto, txtObservaciones.Text, txtFecha.DateTime);
                if (guardado)
                {
                    await LoadDataForDateAsync(txtFecha.DateTime);
                    txtMonto.EditValue = null;
                    txtObservaciones.Text = string.Empty;
                }
            }
            catch (Exception ex)
            {
                await XtraMessageBox.ShowAsync($"Error: {ex.Message}");
            }
            finally
            {
                btnAceptar.Enabled = _viewModel.ConductorDto is { Estado: not EstadoCadete.INACTIVO } &&
                                     _viewModel.AsignacionVehiculoDto is not null;
            }
        }

        private async void txtFecha_DateTimeChanged(object sender, EventArgs e)
        {
            if (_initializing || !_readyForDateChange || txtFecha.EditValue is null)
                return;

            btnAceptar.Enabled = false;
            try
            {
                await LoadDataForDateAsync(txtFecha.DateTime);
            }
            catch (Exception ex)
            {
                lblAsignacion.Text = "No se pudo determinar la asignación";
                XtraMessageBox.Show($"Error: {ex.Message}");
            }
            finally
            {
                btnAceptar.Enabled = _viewModel.ConductorDto is { Estado: not EstadoCadete.INACTIVO } &&
                                     _viewModel.AsignacionVehiculoDto is not null;
            }
        }

        private async Task LoadDataForDateAsync(DateTime fecha)
        {
            txtCodigo.Text = string.Empty;
            txtPlaca.Text = string.Empty;
            txtZona.Text = string.Empty;
            lblAsignacion.Text = "Buscando asignación para la fecha...";

            await _viewModel.LoadAsignacionVehiculo(fecha);
            await _viewModel.LoadCuotaDiaria(fecha);

            var asignacion = _viewModel.AsignacionVehiculoDto;
            if (asignacion is null)
            {
                lblAsignacion.Text = "Sin vehículo asignado para esta fecha";
            }
            else
            {
                txtCodigo.Text = asignacion.CodigoVehiculo ?? string.Empty;
                txtPlaca.Text = asignacion.Placa ?? string.Empty;
                txtZona.Text = asignacion.Zona ?? "(sin zona asignada)";
                var asignacionDelDia = asignacion.FechaInicio?.Date == fecha.Date &&
                                       asignacion.FechaFin?.Date == fecha.Date;
                lblAsignacion.Text = asignacionDelDia
                    ? "Asignación específica para este día"
                    : "Asignación según rango de fechas";
            }

            MostrarCuotaDiaria();
            btnAceptar.Enabled = _viewModel.ConductorDto is { Estado: not EstadoCadete.INACTIVO } &&
                                 asignacion is not null;
        }

        private void MostrarCuotaDiaria()
        {
            var cuotaDiaria = _viewModel.CuotaDiariasDto;
            txtMontoPagado.EditValue = cuotaDiaria?.MontoEntregado ?? 0m;
            arcScaleComponent1.Value = cuotaDiaria is null ? 0f : (float)cuotaDiaria.Porcentaje;
        }
    }
}
