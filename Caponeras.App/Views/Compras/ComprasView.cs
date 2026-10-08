using Caponeras.App.Dto;
using Caponeras.App.ViewModels.Compras;
using DevExpress.XtraEditors;
using NLog;
using System;
using System.Linq;
using Caponeras.Data.Models;

namespace Caponeras.App.Views.Compras
{
    public partial class ComprasView : XtraForm
    {
        private readonly ILogger _logger = LogManager.GetCurrentClassLogger();

        private ComprasViewModel _viewModel;

        public ComprasView(ComprasViewModel viewModel)
        {
            _viewModel = viewModel;
            DataContext = _viewModel;
            InitializeComponent();
        }

        private async void ComprasView_Load(object sender, EventArgs e)
        {
            try
            {
                await _viewModel.Load();
                comprasDtoBindingSource.DataSource = _viewModel.ComprasBindingList;
            }
            catch (Exception ex)
            {
                _logger.Error(ex, "Error al cargar las compras");
            }
        }

        private void gridViewCompras_SelectionChanged(object sender, DevExpress.Data.SelectionChangedEventArgs e)
        {
            if (gridViewCompras.FocusedRowObject is not ComprasDto current)
            {
                return;
            }

            _viewModel.SelectedCompra(current);
        }

        private void gridViewCompras_PopupMenuShowing(object sender,
            DevExpress.XtraGrid.Views.Grid.PopupMenuShowingEventArgs e)
        {
            if (e.HitInfo.InRow)
            {
                e.ShowCustomMenu(popupMenuCompras);
            }
        }

        private void barButtonItemAgregar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            _viewModel.AddAsync();
        }

        private void barButtonItemEditar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            _viewModel.EditAsync(gridViewCompras.GetRow(gridViewCompras.FocusedRowHandle) as ComprasDto);
        }

        private async void barButtonItemDelete_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                if (gridViewCompras.GetRow(gridViewCompras.FocusedRowHandle) is not ComprasDto compra)
                    return;

                if (compra.Estado is EstadoCompra.Parcial or EstadoCompra.Pagada)
                {
                    XtraMessageBox.Show(
                        "La compra tiene pagos registrados y no se puede anular.",
                        "Anular compra", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var confirmacion = XtraMessageBox.Show(
                    compra.Estado == EstadoCompra.Aprobada
                        ? "¿Desea anular esta compra? Se revertirán las entradas de inventario; la operación no se realizará si el stock ya fue consumido o si hay pagos."
                        : "¿Desea anular esta cotización?",
                    "Anular compra", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (confirmacion != DialogResult.Yes)
                    return;

                await _viewModel.DeleteAsync(compra);
            }
            catch (Exception ex)
            {
                _logger.Error(ex, "Error al eliminar la compra");
            }
        }

        private void barButtonItemPayment_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (gridViewCompras.GetRow(gridViewCompras.FocusedRowHandle) is not ComprasDto current)
            {
                return;
            }

            switch (current.Estado)
            {
                case EstadoCompra.Proforma:
                    XtraMessageBox.Show(
                        "Debe aprobar la compra para procesar pagos",
                        "Pagar",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                    break;
                case EstadoCompra.Pagada:
                    XtraMessageBox.Show(
                        "La compra seleccionada ya ha sido pagada.",
                        "Pagar",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                    break;
                case EstadoCompra.Anulada:
                    XtraMessageBox.Show(
                        "La compra esta anulada, no puede realizar pagos.",
                        "Pagar",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                    break;
                case EstadoCompra.Parcial:
                case EstadoCompra.Aprobada:
                    _viewModel.ProcessPaymentAsync(current);
                    break;
                default:
                    XtraMessageBox.Show(
                        "No existe el estado de la compra.",
                        "Pagar",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                    break;
            }
        }

        private void gridViewCompras_FocusedRowChanged(object sender,
            DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (gridViewCompras.GetRow(e.FocusedRowHandle) is not ComprasDto current)
            {
                return;
            }

            _viewModel.SelectedCompra(current);
        }
    }
}
