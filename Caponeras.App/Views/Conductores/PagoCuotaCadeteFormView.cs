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
                txtPlaca.Text = conductor.VehiculosDto?.Placa ?? string.Empty;
                txtCodigo.Text = conductor.VehiculosDto?.Codigo ?? string.Empty;
                if (conductor.CuotaConfiguracions is not null)
                {
                    txtCuota.Text = conductor.CuotaConfiguracions.MontoDiario.ToString("C");
                }

                if (conductor.Estado == EstadoCadete.INACTIVO)
                {
                    btnAceptar.Enabled = false;
                }

                txtFecha.DateTime = DateTime.Now;
            }
            catch (Exception ex)
            {
                await XtraMessageBox.ShowAsync(ex.Message);
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
                    await _viewModel.LoadCuotaDiaria(txtFecha.DateTime);
                    MostrarCuotaDiaria();
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
                btnAceptar.Enabled = _viewModel.ConductorDto is { Estado: not EstadoCadete.INACTIVO };
            }
        }

        private async void txtFecha_DateTimeChanged(object sender, EventArgs e)
        {
            try
            {
                await _viewModel.LoadCuotaDiaria(txtFecha.DateTime);
                MostrarCuotaDiaria();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show($"Error: {ex.Message}");
            }
        }

        private void MostrarCuotaDiaria()
        {
            var cuotaDiaria = _viewModel.CuotaDiariasDto;
            txtMontoPagado.EditValue = cuotaDiaria?.MontoEntregado ?? 0m;
            arcScaleComponent1.Value = cuotaDiaria is null ? 0f : (float)cuotaDiaria.Porcentaje;
        }
    }
}
