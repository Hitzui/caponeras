using Caponeras.App.ViewModels.Mantenimiento;
using Caponeras.App.Views.Layouts;
using System;
using System.Linq;
using Caponeras.App.Helpers;
using DevExpress.XtraGrid.Views.Grid;

namespace Caponeras.App.Views.Mantenimiento
{
    public partial class PaymentProveedorFormView : FormLayout
    {
        private PaymentProveedorFormViewModel _viewModel;

        public PaymentProveedorFormView(PaymentProveedorFormViewModel viewModel)
        {
            _viewModel = viewModel;
            DataContext = _viewModel;
            InitializeComponent();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private async void PaymentProveedorFormView_Load(object sender, EventArgs e)
        {
            await _viewModel.LoadData();
            manoObraProveedorDtoBindingSource.DataSource = _viewModel.ManoObraProveedorBindingList;
        }

        private async void btnAceptar_Click(object sender, EventArgs e)
        {
            btnAceptar.Enabled = false;
            try
            {
                if (await _viewModel.SaveManoObras())
                    await _viewModel.LoadData();
            }
            finally
            {
                btnAceptar.Enabled = true;
            }
        }

        private void gridViewPagoManoObra_ValidateRow(object sender,
            DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs e)
        {
            if (sender is not GridView view) return;

            // Limpiar errores previos
            view.ClearColumnErrors();

            var montoAplicar = HelperMethods.ToDecimal(view.GetRowCellValue(e.RowHandle, colMontoAplicar));
            var saldoPendiente = HelperMethods.ToDecimal(view.GetRowCellValue(e.RowHandle, colSaldoPendiente));

            if (montoAplicar < 0)
            {
                e.Valid = false;
                view.SetColumnError(colMontoAplicar, "El monto a pagar no puede ser negativo.");
            }
            else if (montoAplicar > saldoPendiente)
            {
                e.Valid = false;
                view.SetColumnError(colMontoAplicar, "El monto a aplicar no puede ser mayor que el saldo pendiente.");
            }
            else
            {
                e.Valid = true;
                view.ClearColumnErrors();
            }
        }
    }
}
