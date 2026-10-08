using Caponeras.App.Dto;
using Caponeras.App.ViewModels.Compras;
using Caponeras.App.Views.Layouts;
using System;
using System.Diagnostics;
using System.Linq;

namespace Caponeras.App.Views.Compras
{
    public partial class ProductoDialogView : FormLayout
    {
        private ProductoDialogViewModel _viewModel;
        public ProductoDto? SelectedProductoDto { get; private set; }
        public ProductoDialogView(ProductoDialogViewModel viewModel)
        {
            _viewModel = viewModel;
            DataContext = _viewModel;
            InitializeComponent();
        }

        private async void ProductoDialogView_Load(object sender, EventArgs e)
        {
            try
            {
                await _viewModel.LoadProductos();
                productoDtoBindingSource.DataSource = _viewModel.ProductosBindingList;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            SelectedProductoDto = productoDtoBindingSource.Current as ProductoDto;
            DialogResult = DialogResult.OK;
            Close();
        }
    }
}