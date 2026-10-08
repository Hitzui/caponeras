using Caponeras.App.ViewModels.Mcaja;
using Caponeras.App.Views.Layouts;
using System;
using System.Diagnostics;
using System.Linq;
using Caponeras.App.Helpers;

namespace Caponeras.App.Views.Mcaja
{
    public partial class RealizarMovimientoCajaFormView : FormLayout
    {
        private RealizarMovimientoCajaViewModel _viewModel;

        public RealizarMovimientoCajaFormView(RealizarMovimientoCajaViewModel viewModel)
        {
            _viewModel = viewModel;
            DataContext = _viewModel;
            InitializeComponent();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtConcepto.Text))
            {
                txtConcepto.ErrorText = "Debe indicar un concepto del movimiento a realizar";
                return;
            }

            var monto = HelperMethods.ToDecimal(txtMonto.EditValue);
            if (monto <= 0)
            {
                txtMonto.ErrorText = "Debe indicar el monto a debitar o acreditar de caja";
                return;
            }

            if (cmbMovcaja.EditValue is null)
            {
                cmbMovcaja.ErrorText = "Debe seleccionar el movimiento a usar";
                return;
            }

            var idMovcaja = (int)cmbMovcaja.EditValue;
            _viewModel.RealizarMovimiento(txtConcepto.Text, idMovcaja, monto);
        }

        private async void RealizarMovimientoCajaForm_Load(object sender, EventArgs e)
        {
            try
            {
                var cajaAperturada = await _viewModel.VerificarCajaAperturada();
                if (!cajaAperturada)
                {
                    btnAceptar.Enabled = false;
                }

                await _viewModel.LoadMovimientos();
                movCajasDtoBindingSource.DataSource = _viewModel.MovCajasBindingList;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
        }
    }
}