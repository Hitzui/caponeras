using Caponeras.App.ViewModels.Compras;
using System;
using System.Linq;

namespace Caponeras.App.Views.Compras
{
    public partial class PaymentCompraView : DevExpress.XtraEditors.XtraForm
    {
        private PaymentCompraViewModel _viewModel;

        public PaymentCompraView(PaymentCompraViewModel viewModel)
        {
            _viewModel = viewModel;
            DataContext = _viewModel;
            InitializeComponent();
        }

        private void PaymentCompraView_Load(object sender, EventArgs e)
        {
            txtMontoPagar.Focus();
            _viewModel.LoadCompra();
            if (_viewModel.ComprasDto is null) return;
            txtNumeroDocumento.Text = _viewModel.ComprasDto.NumeroDocumento;
            txtFechaCompra.DateTime = _viewModel.ComprasDto.Fecha;
            txtProveedor.Text = _viewModel.ComprasDto.Proveedores.Nombre;
            txtMontoOriginal.Text = _viewModel.ComprasDto.Total.ToString("N2");
            if (_viewModel.TransactionCxpsDto is null) return;
            txtSaldo.Text = _viewModel.TransactionCxpsDto.SaldoPendiente.ToString("N2");
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private async void btnAplicar_Click(object sender, EventArgs e)
        {
            btnAplicar.Enabled = false;
            try
            {
                var pagoRealizado = await _viewModel.ProcesarPagoCompra(txtMontoPagar.EditValue as decimal?);
                if (pagoRealizado)
                {
                    DialogResult = DialogResult.OK;
                    Close();
                }
            }
            finally
            {
                btnAplicar.Enabled = true;
            }
        }
    }
}
