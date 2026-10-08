using Caponeras.App.Dto;
using Caponeras.App.ViewModels.Proveedores;

namespace Caponeras.App.Views.Proveedores
{
    public sealed partial class ProveedoresView : DevExpress.XtraEditors.XtraForm
    {
        private ProveedoresViewModel _viewModel;

        public ProveedoresView(ProveedoresViewModel viewModel)
        {
            _viewModel = viewModel;
            DataContext = _viewModel;
            InitializeComponent();
        }

        private void ProveedoresView_Load(object sender, EventArgs e)
        {
            _ = LoadData();
        }

        private async Task LoadData()
        {
            await _viewModel.LoadData();
            proveedoresDtoBindingSource.DataSource = _viewModel.ProveedoresBindingList;
        }

        private void gridViewProveedores_SelectionChanged(object sender, DevExpress.Data.SelectionChangedEventArgs e)
        {
            if (gridViewProveedores.GetRow(gridViewProveedores.FocusedRowHandle) is ProveedoresDto proveedor)
            {
                _viewModel.SetSelectedProveedor(proveedor);
            }
        }

        private void gridViewProveedores_FocusedRowChanged(object sender,
            DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (gridViewProveedores.GetRow(e.FocusedRowHandle) is ProveedoresDto proveedor)
            {
                _viewModel.SetSelectedProveedor(proveedor);
            }
        }
    }
}