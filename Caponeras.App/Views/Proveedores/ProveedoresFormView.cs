using Caponeras.App.Dto;
using Caponeras.App.Helpers;
using Caponeras.App.ViewModels.Proveedores;
using Caponeras.App.Views.Layouts;
using DevExpress.XtraEditors;
using System;
using System.Diagnostics;
using System.Linq;

namespace Caponeras.App.Views.Proveedores
{
    public partial class ProveedoresFormView : FormLayout
    {
        private ProveedoresFormViewModel _viewModel;
        private ProveedoresDto _proveedor = new();

        public ProveedoresFormView(ProveedoresFormViewModel viewModel)
        {
            _viewModel = viewModel;
            DataContext = _viewModel;
            InitializeComponent();
        }

        private void ProveedoresFormView_Load(object sender, EventArgs e)
        {
            LoadProveedor();
            txtNombre.Focus();
        }

        private void LoadProveedor()
        {
            _viewModel.Load();
            if (_viewModel.SelectedProveedor is null) return;
            txtNombre.Text = _viewModel.SelectedProveedor.Nombre;
            txtRuc.Text = _viewModel.SelectedProveedor.Ruc;
            txtTelefono.Text = _viewModel.SelectedProveedor.Telefono;
            txtEmail.Text = _viewModel.SelectedProveedor.Email;
            txtContacto.Text = _viewModel.SelectedProveedor.Contacto;
            txtDirecicón.Text = _viewModel.SelectedProveedor.Direccion;
        }

        private void SetData()
        {
            if (_viewModel.SelectedProveedor is null) _proveedor.IdProveedor = 0;
            else _proveedor = _viewModel.SelectedProveedor;
            _proveedor.Nombre = txtNombre.Text;
            _proveedor.Ruc = txtRuc.Text;
            _proveedor.Email = txtEmail.Text;
            _proveedor.Contacto = txtContacto.Text;
            _proveedor.Telefono = txtTelefono.Text;
            _proveedor.Direccion = txtDirecicón.Text;
        }

        private async void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                var validate = ValidateForm();
                if (!validate)
                {
                    return;
                }

                SetData();
                var save = await _viewModel.Save(_proveedor);
                if (save > 0)
                {
                    DialogResult = DialogResult.OK;
                    Close();
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                XtraMessageBox.Show(
                    $"No fue posible guardar el proveedor. {ex.GetBaseException().Message}",
                    "Error al guardar",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private bool ValidateForm()
        {
            var result = true;

            result &= HelperMethods.ValidateRequired(txtNombre, "Indicar nombre del proveedor", errorProvider);
            result &= HelperMethods.ValidateRequired(txtRuc, "Indicar RUC del proveedor", errorProvider);
            result &= HelperMethods.ValidateRequired(txtEmail, "Indicar correo del proveedor", errorProvider);
            result &= HelperMethods.ValidateRequired(txtContacto, "Indicar nombre de contacto del proveedor", errorProvider);
            result &= HelperMethods.ValidateRequired(txtTelefono, "Indicar telefono de contacto del proveedor",
                errorProvider);
            result &= HelperMethods.ValidateRequired(txtDirecicón, "Indicar dirección del proveedor", errorProvider);

            return result;
        }
    }
}
