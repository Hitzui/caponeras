using Caponeras.App.Dto;
using Caponeras.App.Helpers;
using Caponeras.App.ViewModels.Inventario;
using Caponeras.Data.Models;
using DevExpress.Data;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid;
using DevExpress.XtraVerticalGrid;
using System.Collections;
using System.ComponentModel;

namespace Caponeras.App.Views.Inventario
{
    public sealed partial class MovimientoIventarioView : XtraForm
    {
        private MovimientoIventarioViewModel _viewModel;

        public MovimientoIventarioView(MovimientoIventarioViewModel viewModel)
        {
            _viewModel = viewModel;
            InitializeComponent();
            movimientoInventarioGridDtoBindingSource.DataSource = _viewModel.Items;
        }

        private void UpdateNavigatorText()
        {
            lblNavigator.Text =
                @$"Página {_viewModel.CurrentPage + 1} de {_viewModel.TotalPages}  |  Registros: {_viewModel.TotalRecords}";
        }


        private void MovimientoIventarioView_Load(object sender, EventArgs e)
        {
            LoadDefaultValues();
        }

        private void LoadDefaultValues()
        {
            txtDesde.DateTime = DateTime.Now;
            txtHasta.DateTime = DateTime.Now;

            cmbReferencia.Properties.Items.Clear();
            cmbReferencia.Properties.Items.AddRange(Enum.GetValues<ReferenciaInventario>());
            cmbReferencia.EditValue = null;

            cmbTipo.Properties.Items.Clear();
            cmbTipo.Properties.Items.AddRange(Enum.GetValues<TipoMovimiento>());
            cmbTipo.EditValue = null;

            txtProducto.Clear();
            _viewModel.Items.Clear();
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            LoadDefaultValues();
        }

        private async void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                _viewModel.Desde = txtDesde.DateTime;
                _viewModel.Hasta = txtHasta.DateTime;
                _viewModel.Referencia = cmbReferencia.EditValue;
                _viewModel.Tipo = cmbTipo.EditValue;
                _viewModel.SearchProducto = txtProducto.Text;
                await _viewModel.FirstPageAsync();
                UpdateNavigatorText();
            }
            catch (Exception ex)
            {
                await XtraMessageBox.ShowAsync(
                    $"Error: {ex.Message}");
            }
        }

        private async void btnFirstPage_Click(object sender, EventArgs e)
        {
            try
            {
                await _viewModel.FirstPageAsync();
                UpdateNavigatorText();
            }
            catch (Exception ex)
            {
                await XtraMessageBox.ShowAsync(ex.Message);
            }
        }

        private async void btnPrev_Click(object sender, EventArgs e)
        {
            try
            {
                await _viewModel.PreviousPageAsync();
                UpdateNavigatorText();
            }
            catch (Exception ex)
            {
                await XtraMessageBox.ShowAsync(ex.Message);
            }
        }

        private async void btnNext_Click(object sender, EventArgs e)
        {
            try
            {
                await _viewModel.NextPageAsync();
                UpdateNavigatorText();
            }
            catch (Exception ex)
            {
                await XtraMessageBox.ShowAsync(ex.Message);
            }
        }

        private async void btnLastPage_Click(object sender, EventArgs e)
        {
            try
            {
                await _viewModel.LastPageAsync();
                UpdateNavigatorText();
            }
            catch (Exception ex)
            {
                await XtraMessageBox.ShowAsync(ex.Message);
            }
        }

        private async void btnVerReporte_Click(object sender, EventArgs e)
        {
            try
            {
                await _viewModel.ShowReporteInventario(txtDesde.DateTime, txtHasta.DateTime);
            }
            catch (Exception exception)
            {
                await XtraMessageBox.ShowAsync(exception.Message);
            }
        }
    }
}