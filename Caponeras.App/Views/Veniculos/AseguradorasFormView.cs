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

        private void gridViewAseguradoras_EditFormHidden(object sender,
            DevExpress.XtraGrid.Views.Grid.EditFormHiddenEventArgs e)
        {
            if (e.Result == DevExpress.XtraGrid.Views.Grid.EditFormResult.Cancel)
                return;

            _ = SaveFromEditFormAsync(e);
        }

        private async Task SaveFromEditFormAsync(DevExpress.XtraGrid.Views.Grid.EditFormHiddenEventArgs e)
        {
            try
            {
                AseguradorasDto dto;
                if (e.RowHandle < 0)
                {
                    dto = new AseguradorasDto { Activo = true };
                }
                else if (gridViewAseguradoras.GetRow(e.RowHandle) is AseguradorasDto selected)
                {
                    dto = selected;
                }
                else
                {
                    return;
                }

                string ReadValue(string field, string current)
                {
                    try
                    {
                        return e.BindableControls[field].Text.Trim();
                    }
                    catch (KeyNotFoundException)
                    {
                        return current;
                    }
                }

                dto.Nombre = ReadValue(nameof(AseguradorasDto.Nombre), dto.Nombre);
                dto.NombreCorto = ReadValue(nameof(AseguradorasDto.NombreCorto), dto.NombreCorto);
                dto.Telefono = ReadValue(nameof(AseguradorasDto.Telefono), dto.Telefono);
                dto.Correo = ReadValue(nameof(AseguradorasDto.Correo), dto.Correo);
                dto.SitioWeb = ReadValue(nameof(AseguradorasDto.SitioWeb), dto.SitioWeb);
                dto.Direccion = ReadValue(nameof(AseguradorasDto.Direccion), dto.Direccion);
                try
                {
                    if (bool.TryParse(e.BindableControls[nameof(AseguradorasDto.Activo)].Text, out var activo))
                        dto.Activo = activo;
                }
                catch (KeyNotFoundException)
                {
                    // The new-row edit form initializes new agencies as active.
                }

                var saved = await _viewModel.Save(dto);
                if (saved > 0)
                {
                    await _viewModel.Load();
                    _viewModel.ShowMessage(TypeAlert.Success, "Agencias de seguros", "Los datos se guardaron correctamente.");
                }
                else
                {
                    _viewModel.ShowMessage(TypeAlert.Error, "Agencias de seguros",
                        string.IsNullOrWhiteSpace(_viewModel.ErrorMessage)
                            ? "No fue posible guardar la agencia."
                            : _viewModel.ErrorMessage);
                }
            }
            catch (Exception ex)
            {
                _viewModel.ShowMessage(TypeAlert.Error, "Agencias de seguros", ex.GetBaseException().Message);
            }
        }

        public void AddAseguradora()
        {
            gridViewAseguradoras.AddNewRow();
            gridViewAseguradoras.ShowEditForm();
        }

        public void EditarAseguradoraSeleccionada()
        {
            if (gridViewAseguradoras.GetFocusedRow() is not AseguradorasDto)
            {
                _viewModel.ShowMessage(TypeAlert.Warning, "Agencias de seguros", "Seleccione una agencia para editar.");
                return;
            }

            gridViewAseguradoras.ShowEditForm();
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
