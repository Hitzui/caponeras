using Caponeras.App.Views.Layouts;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using Caponeras.App.ViewModels.Conductores;

namespace Caponeras.App.Views.Conductores
{
    public partial class AsignarVehiculoFormView : FormLayout
    {
        private AsignarVehiculoViewModel _viewModel;

        public AsignarVehiculoFormView(AsignarVehiculoViewModel viewModel)
        {
            _viewModel = viewModel;
            InitializeComponent();
        }

        private async void AsignarVehiculoForm_Load(object sender, EventArgs e)
        {
            try
            {
                _viewModel.LoadCadete();
                await _viewModel.LoadZonas();
                await _viewModel.LoadVehiculos();
                vehiculosDtoBindingSource.DataSource = _viewModel.Vehiculos;
                zonasDtoBindingSource.DataSource = _viewModel.Zonas;
                if (_viewModel.ConductoresDto is null) return;
                var cadete = _viewModel.ConductoresDto;
                txtNombreCadete.Text = cadete.Nombre;
                txtIdentificacion.Text = cadete.Identificacion;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private async void btnAceptar_Click(object sender, EventArgs e)
        {
            if (cmbVeniculo.EditValue == null)
            {
                cmbVeniculo.ErrorText = "Seleccione un vehículo";
                return;
            }

            if (cmbZonas.EditValue == null)
            {
                cmbZonas.ErrorText = "Seleccione una zona";
                return;
            }

            var idvehiculo = (int)cmbVeniculo.EditValue;
            var idzonas = (int)cmbZonas.EditValue;
            // Validar fechas (sin CancelEventArgs porque no estamos en Validating)
            if (!FechasValidas())
                return;

            var inicio = txtFechaInicio.DateTime.Date;
            var fin = txtFechaFin.DateTime.Date;
            var save = await _viewModel.AsignarVehiculoCadete(idvehiculo, idzonas, inicio, fin);
            if (save) btnAceptar.Enabled = false;
        }

        private bool FechasValidas()
        {
            // Validar que ambos tengan fecha
            if (txtFechaInicio.EditValue == null)
            {
                txtFechaInicio.ErrorText = "Seleccione una fecha";
                //dxErrorProvider1.SetError(txtFechaInicio, "Seleccione una fecha");
                return false;
            }

            if (txtFechaFin.EditValue == null)
            {
                txtFechaFin.ErrorText = "Seleccione una fecha";
                //dxErrorProvider1.SetError(txtFechaFin, "Seleccione una fecha");
                return false;
            }

            var inicio = txtFechaInicio.DateTime.Date;
            var fin = txtFechaFin.DateTime.Date;

            // Validar rango
            if (inicio > fin)
            {
                txtFechaInicio.EditValue = null;
                dxErrorProvider1.SetError(txtFechaFin, "La fecha fin no puede ser menor que la fecha inicio");
                return false;
            }

            dxErrorProvider1.ClearErrors();
            return true;
        }

        private void ValidarRangoFechas(CancelEventArgs? e = null)
        {
            var inicio = txtFechaInicio.DateTime;
            var fin = txtFechaFin.DateTime;

            // Validar que ambos tengan fecha
            if (txtFechaInicio.EditValue == null)
            {
                txtFechaInicio.ErrorText = "Seleccione una fecha";
                //dxErrorProvider1.SetError(txtFechaInicio, "Seleccione una fecha");
                e?.Cancel = true;
                return;
            }

            if (txtFechaFin.EditValue == null)
            {
                txtFechaFin.ErrorText = "Seleccione una fecha";
                //dxErrorProvider1.SetError(txtFechaFin, "Seleccione una fecha");
                e?.Cancel = true;
                return;
            }

            // Validar rango
            if (inicio > fin)
            {
                txtFechaInicio.EditValue = null;
                txtFechaFin.EditValue = null;
                dxErrorProvider1.SetError(txtFechaFin, "La fecha fin no puede ser menor que la fecha inicio");
                e?.Cancel = true;
            }
            else
            {
                dxErrorProvider1.ClearErrors();
            }
        }

        private void txtFechaInicio_EditValueChanged(object sender, EventArgs e)
        {
            ValidarRangoFechas();
        }

        private void txtFechaFin_EditValueChanged(object sender, EventArgs e)
        {
            ValidarRangoFechas();
        }

        private void txtFechaInicio_Validating(object sender, CancelEventArgs e)
        {
            ValidarRangoFechas();
        }

        private void txtFechaFin_Validating(object sender, CancelEventArgs e)
        {
            ValidarRangoFechas();
        }
    }
}