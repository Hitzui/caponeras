using System.ComponentModel;
using System.Diagnostics;
using Caponeras.App.Dto;
using Caponeras.App.Helpers;
using Caponeras.App.Services;
using Caponeras.App.ViewModels.UnidadMedida;
using DevExpress.XtraBars.ToastNotifications;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;


namespace Caponeras.App.Views.UnidadMedida
{
    public partial class UnidadMedidaView : XtraForm
    {
        private UnidadMedidaViewModel _viewModel;

        public UnidadMedidaView(UnidadMedidaViewModel viewModel)
        {
            _viewModel = viewModel;
            InitializeComponent();
        }

        private async void UnidadMedidaView_Load(object sender, EventArgs e)
        {
            try
            {
                await _viewModel.Load();
                unidadMedidaDtoBindingSource.DataSource = _viewModel.UnidadMedidaBindingList;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
        }

        private void gridViewUnidadMedida_EditFormPrepared(object sender, EditFormPreparedEventArgs e)
        {
        }

        private async void gridViewUnidadMedida_EditFormHidden(object sender, EditFormHiddenEventArgs e)
        {
            if (e.Result == EditFormResult.Cancel)
            {
                return;
            }

            UnidadMedidaDto unidadMedida;
            if (e.RowHandle < 0)
            {
                unidadMedida = new UnidadMedidaDto
                {
                    IdUnidad = 0,
                    Nombre = e.BindableControls["Nombre"].Text,
                    Simbolo = e.BindableControls["Simbolo"].Text,
                    Activo = true
                };
            }
            else
            {
                if (gridViewUnidadMedida.GetRow(e.RowHandle) is not UnidadMedidaDto selected)
                    return;

                unidadMedida = selected;
                unidadMedida.Nombre = e.BindableControls["Nombre"].Text;
                unidadMedida.Simbolo = e.BindableControls["Simbolo"].Text;
            }

            var save = await _viewModel.Save(unidadMedida);
            if (save > 0)
            {
                await _viewModel.Load();
                _viewModel.ShowMessage(TypeAlert.Success, "Guardar", "Se han guardado los datos de forma correcta");
            }
            else
            {
                _viewModel.ShowMessage(TypeAlert.Error, "Guardar",
                    string.IsNullOrWhiteSpace(_viewModel.ErrorMessage)
                        ? "No fue posible guardar la unidad de medida."
                        : _viewModel.ErrorMessage);
            }
        }

        private async void gridViewUnidadMedida_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                e.Handled = true;
                e.SuppressKeyPress = true;
                await EliminarFilaSeleccionadaAsync();
            }
        }

        private async Task EliminarFilaSeleccionadaAsync()
        {
            if (gridViewUnidadMedida.GetFocusedRow() is not UnidadMedidaDto row) return;

            var confirm = XtraMessageBox.Show(
                "¿Desea eliminar el registro?",
                "Confirmar",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (confirm != DialogResult.Yes)
                return;

            await _viewModel.Delete(row);
        }

    }
}
