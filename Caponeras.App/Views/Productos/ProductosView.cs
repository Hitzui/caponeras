using Caponeras.App.Dto;
using Caponeras.App.ViewModels.Productos;
using DevExpress.XtraEditors;
using System;
using System.Diagnostics;
using System.Linq;

namespace Caponeras.App.Views.Productos
{
    public sealed partial class ProductosView : XtraForm
    {
        private ProductosViewModel _viewModel;
        public ProductosView(ProductosViewModel viewModel)
        {
            _viewModel = viewModel;
            DataContext = _viewModel;
            InitializeComponent();
        }

        private async void ProductosView_Load(object sender, EventArgs e)
        {
            try
            {
                await _viewModel.Load();
                productoDtoBindingSource.DataSource = _viewModel.ProdctoBindingList;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
        }

        private void barButtonItemAdd_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            _viewModel.ItemAddClick(null);
        }

        private void barButtonItemEdit_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var producto = productoDtoBindingSource.Current as ProductoDto;
            _viewModel.ItemAddClick(producto);
        }

        private async void barButtonItemDelete_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var result = XtraMessageBox.Show("¿Eliminar el producto seleccionado?", "Eliminar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result != DialogResult.Yes)
            {
                return;
            }
            var producto = productoDtoBindingSource.Current as ProductoDto;
            await _viewModel.DeleteAsync(producto);
        }

        private void cardViewProductos_SelectionChanged(object sender, DevExpress.Data.SelectionChangedEventArgs e)
        {
            _viewModel.SetSelectedItem(productoDtoBindingSource.Current as ProductoDto);
        }

        private void cardViewProductos_CustomDrawCardCaption(object sender, DevExpress.XtraGrid.Views.Card.CardCaptionCustomDrawEventArgs e)
        {
            var data = cardViewProductos.GetRow(e.RowHandle) as ProductoDto;
            e.CardCaption = data.Nombre;
            cardViewProductos.Appearance.CardCaption.Options.UseBackColor = true;
            cardViewProductos.Appearance.CardCaption.Options.UseForeColor = true;
            if (data.StockMinimo > data.StockActual)
            {
                e.Appearance.BackColor = ColorTranslator.FromHtml("#873D48");
                e.Appearance.BorderColor = ColorTranslator.FromHtml("#873D48");
                e.Appearance.ForeColor = ColorTranslator.FromHtml("#B0D7FF");
            }
            else
            {
                cardViewProductos.Appearance.CardCaption.BackColor = ColorTranslator.FromHtml("#1E2019");
                e.Appearance.ForeColor = Color.White;
            }

        }

        private void cardViewProductos_CustomDrawCardFieldCaption(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            if (cardViewProductos.GetRow(e.RowHandle) is not ProductoDto data)
            {
                return;
            }
            if (data.StockMinimo < data.StockActual)
            {
                return;
            }

            if (e.Column == colStockActual)
            {
                e.Appearance.BackColor = ColorTranslator.FromHtml("#873D48");
                e.Appearance.ForeColor = Color.White;
            }
        }
    }
}