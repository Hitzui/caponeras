using Caponeras.App.Dto;
using Caponeras.App.Helpers;
using Caponeras.App.ViewModels.Vehiculo;
using DevExpress.XtraEditors;

namespace Caponeras.App.Views.Veniculos
{
    public partial class AseguradorasFormView : XtraForm
    {
        private readonly AseguradorasViewModel _viewModel;

        public AseguradorasFormView(AseguradorasViewModel viewModel)
        {
            _viewModel = viewModel;
            InitializeComponent();
        }

        private async void AseguradorasFormView_Load(object sender, EventArgs e)
        {
            await LoadAgenciasAsync();
        }

        private async Task LoadAgenciasAsync()
        {
            try
            {
                await _viewModel.Load();
                aseguradorasDtoBindingSource.DataSource = _viewModel.AseguradorasBindingList;
            }
            catch (Exception ex)
            {
                _viewModel.ShowMessage(TypeAlert.Error, "Agencias de seguros", ex.GetBaseException().Message);
            }
        }

        public async Task AddAseguradoraAsync()
        {
            using var form = new AseguradoraEditFormView(_viewModel, new AseguradorasDto { Activo = true });
            if (form.ShowDialog(this) == DialogResult.OK)
                await LoadAgenciasAsync();
        }

        public async Task EditarAseguradoraSeleccionadaAsync()
        {
            if (gridViewAseguradoras.GetFocusedRow() is not AseguradorasDto)
            {
                _viewModel.ShowMessage(TypeAlert.Warning, "Agencias de seguros", "Seleccione una agencia para editar.");
                return;
            }

            using var form = new AseguradoraEditFormView(_viewModel, (AseguradorasDto)gridViewAseguradoras.GetFocusedRow());
            if (form.ShowDialog(this) == DialogResult.OK)
                await LoadAgenciasAsync();
        }

        public async Task EliminarAseguradoraSeleccionadaAsync()
        {
            if (gridViewAseguradoras.GetFocusedRow() is not AseguradorasDto selected)
            {
                _viewModel.ShowMessage(TypeAlert.Warning, "Agencias de seguros", "Seleccione una agencia para eliminar.");
                return;
            }

            if (XtraMessageBox.Show("¿Desea eliminar esta agencia? Si tiene pólizas, se conservará desactivada.",
                    "Confirmar eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                return;

            await _viewModel.Delete(selected);
        }

        private async void gridViewAseguradoras_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Delete)
                return;

            e.Handled = true;
            e.SuppressKeyPress = true;
            await EliminarAseguradoraSeleccionadaAsync();
        }
    }
}
