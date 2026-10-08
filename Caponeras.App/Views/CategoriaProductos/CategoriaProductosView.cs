using Caponeras.App.Dto;
using Caponeras.App.Helpers;
using Caponeras.App.ViewModels.CategoriaProductos;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;
using System;
using System.Linq;

namespace Caponeras.App.Views.CategoriaProductos
{
    public partial class CategoriaProductosView : DevExpress.XtraEditors.XtraForm
    {
        private CategoriaProductosViewModel _viewModel;
        private INavigationService _navigationService;

        public CategoriaProductosView(CategoriaProductosViewModel viewModel, INavigationService navigationService)
        {
            _viewModel = viewModel;
            _navigationService = navigationService;
            InitializeComponent();
        }

        private async void CategoriaProductosView_Load(object sender, EventArgs e)
        {
            await _viewModel.Load();
            categoriaProductoDtoBindingSource.DataSource = _viewModel.CategoriaProductoBindingList;
        }

        private async void gridViewCategoriaProductos_EditFormHidden(object sender, EditFormHiddenEventArgs e)
        {
            if (e.Result == EditFormResult.Cancel)
            {
                return;
            }

            CategoriaProductoDto dto;
            if (e.RowHandle >= 0)
            {
                if (gridViewCategoriaProductos.GetRow(e.RowHandle) is not CategoriaProductoDto selected)
                    return;

                dto = selected;
            }
            else
            {
                dto = new CategoriaProductoDto();
            }

            dto.Descripcion = e.BindableControls["Descripcion"].Text;
            dto.Nombre = e.BindableControls["Nombre"].Text;

            var save = await _viewModel.Save(dto);
            if (save > 0)
            {
                _viewModel.GetMessageAlert(TypeAlert.Success, "Guardar", "Se han guardado los datos de forma correcta", _navigationService.MainView);
                await _viewModel.Load();
            }
            else
            {
                _viewModel.GetMessageAlert(TypeAlert.Error, "Guardar",
                    string.IsNullOrWhiteSpace(_viewModel.ErrorMessage)
                        ? "No fue posible guardar la categoría."
                        : _viewModel.ErrorMessage,
                    _navigationService.MainView);
            }
        }

        private async void gridViewCategoriaProductos_KeyDown(object sender, KeyEventArgs e)
        {
            if (gridViewCategoriaProductos.GetFocusedRow() is not CategoriaProductoDto row)
            {
                return;
            }

            if (e.KeyCode != Keys.Delete) return;
            e.Handled = true;
            e.SuppressKeyPress = true;
            var result = XtraMessageBox.Show("¿Seguro desea eliminar el registro?", "Eliminar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result != DialogResult.Yes)
            {
                return;
            }
            await _viewModel.Delete(row);
        }
    }
}
