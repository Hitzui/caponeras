using Caponeras.App.Dto;
using Caponeras.App.Helpers;
using Caponeras.App.ViewModels.Mantenimiento;
using DevExpress.XtraEditors;
using System;
using System.ComponentModel;
using System.Linq;
using Caponeras.App.Views.Layouts;

namespace Caponeras.App.Views.Mantenimiento
{
    public partial class ProductoExtraInventariableFormView : FormLayout
    {
        private ProductoExtraInventariableViewModel _viewModel;
        private decimal _cantidad;
        public int IdProveedorSeleccionado { get; private set; }
        public decimal PrecioUnitarioSeleccionado { get; private set; }

        [DefaultValue(0)]
        public decimal Cantidad
        {
            get => _cantidad;
            set => _cantidad = value;
        }

        public ProductoExtraInventariableFormView(ProductoExtraInventariableViewModel viewModel)
        {
            _viewModel = viewModel;
            DataContext = _viewModel;
            InitializeComponent();
        }

        public void SetProducto(ProductoDto row)
        {
            _viewModel.SetProducto(row);
        }

        private async void ProductoExtraInventariableForm_Load(object sender, EventArgs e)
        {
            try
            {
                await _viewModel.LoadProveedores();
                proveedoresDtoBindingSource.DataSource = _viewModel.ProveedoresBindingList;
            }
            catch (Exception ex)
            {
                await XtraMessageBox.ShowAsync(ex.Message);
            }
        }

        private async void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {

                if (cmbProveedor.EditValue is not int idproveedor)
                {
                    cmbProveedor.ErrorText = "Debe seleccionar un proveedor.";
                    return;
                }

                if (string.IsNullOrEmpty(txtCantidad.Text))
                {
                    txtCantidad.ErrorText = "Debe ingresar una cantidad.";
                    return;
                }

                if (string.IsNullOrEmpty(txtPrecio.Text))
                {
                    txtPrecio.ErrorText = "Debe ingresar un precio.";
                    return;
                }

                var cantidad = HelperMethods.ToDecimal(txtCantidad.EditValue);
                var precio = HelperMethods.ToDecimal(txtPrecio.EditValue);
                if (cantidad <= 0)
                {
                    txtCantidad.ErrorText = "La cantidad debe ser mayor a cero.";
                    return;
                }

                if (precio <= 0)
                {
                    txtPrecio.ErrorText = "El precio debe ser mayor a cero.";
                    return;
                }

                var save = await _viewModel.SaveProductoExtraInventariable(cantidad, precio, idproveedor);
                if (!save) return;
                DialogResult = DialogResult.OK;
                Cantidad = cantidad;
                IdProveedorSeleccionado = idproveedor;
                PrecioUnitarioSeleccionado = precio;
                Close();
            }
            catch (Exception ex)
            {
                await XtraMessageBox.ShowAsync(ex.Message);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
