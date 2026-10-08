using Caponeras.App.Dto;
using Caponeras.App.ViewModels.Compras;
using Caponeras.Data.Models;
using DevExpress.XtraEditors;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;

namespace Caponeras.App.Views.Compras
{
    public partial class ComprasFormView : XtraForm
    {
        private ComprasFormViewModel _viewModel;

        public ComprasFormView(ComprasFormViewModel viewModel)
        {
            _viewModel = viewModel;
            DataContext = _viewModel;
            InitializeComponent();
            _viewModel.Importes = new TotalesCompras();
            detalleCompraDtoBindingSource.DataSource = _viewModel.DetalleCompraBindingList;
            _viewModel.DetalleCompraBindingList.ListChanged += DetalleCompraBindingList_ListChanged;
            _viewModel.AplicaIva = true;
        }

        private void DetalleCompraBindingList_ListChanged(object? sender, ListChangedEventArgs e)
        {
            txtSubtotal.EditValue = _viewModel.Importes.SubTotal;
            txtIva.EditValue = _viewModel.Importes.Iva;
            txtTotal.EditValue = _viewModel.Importes.Total;
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (_viewModel.SelectedProductoDto is null)
            {
                _viewModel.ShowAlertProducto();
                return;
            }

            if (string.IsNullOrEmpty(txtPrecio.Text) || txtPrecio.EditValue is null)
            {
                txtPrecio.Focus();
                return;
            }

            if (string.IsNullOrEmpty(txtCantdiad.Text) || txtCantdiad.EditValue is null)
            {
                txtCantdiad.Focus();
                return;
            }

            var cantidad = Convert.ToDecimal(txtCantdiad.EditValue);
            var precio = Convert.ToDecimal(txtPrecio.EditValue);
            var importe = Convert.ToDecimal(txtImporte.EditValue);
            var importeDto = new ImporteCompraDto(cantidad, precio, importe);
            _viewModel.AgregarProducto(importeDto);
            LimpiarSeleccionProducto();
        }

        private void btnBuscarProducto_Click(object sender, EventArgs e)
        {
            if (!_viewModel.ShowProductoDialog()) return;
            if (_viewModel.SelectedProductoDto is null) return;
            txtNombreProducto.Text = _viewModel.SelectedProductoDto.Nombre;
            txtPrecio.EditValue = _viewModel.SelectedProductoDto.PrecioCosto;
            txtPrecio.Focus();
        }

        private void txtPrecio_EditValueChanged(object sender, EventArgs e)
        {
            CaluclarImporte();
        }

        private void txtCantdiad_EditValueChanged(object sender, EventArgs e)
        {
            CaluclarImporte();
        }

        private void CaluclarImporte()
        {
            if (string.IsNullOrEmpty(txtPrecio.Text))
            {
                txtPrecio.Focus();
                return;
            }

            if (string.IsNullOrEmpty(txtCantdiad.Text))
            {
                txtCantdiad.Focus();
                return;
            }

            var cantidad = Convert.ToDecimal(txtCantdiad.EditValue);
            var precio = Convert.ToDecimal(txtPrecio.EditValue);
            var importe = 0m;
            if (precio > 0 && cantidad > 0) importe = cantidad * precio;
            txtImporte.EditValue = importe;
        }

        private void LimpiarSeleccionProducto()
        {
            txtPrecio.Clear();
            txtCantdiad.Clear();
            txtImporte.Clear();
            _viewModel.SelectedProductoDto = null;
            txtNombreProducto.Clear();
        }

        private void btnLimpiarProducto_Click(object sender, EventArgs e)
        {
            LimpiarSeleccionProducto();
        }

        private void btnQuitar_Click(object sender, EventArgs e)
        {
            if (detalleCompraDtoBindingSource.Current is not DetalleCompraDto selectedValue)
            {
                _viewModel.ShowAlertProducto();
                return;
            }

            _viewModel.QuitarItem(selectedValue);
        }

        private void toggleIva_Toggled(object sender, EventArgs e)
        {
            _viewModel.AplicaIva = toggleIva.IsOn;
            txtSubtotal.EditValue = _viewModel.Importes.SubTotal;
            txtIva.EditValue = _viewModel.Importes.Iva;
            txtTotal.EditValue = _viewModel.Importes.Total;
        }

        private void btnBuscarProveedor_Click(object sender, EventArgs e)
        {
            _viewModel.ShowProveedorDialog();
            if (_viewModel.SelectedProveedor is not null)
            {
                txtNombreProveedor.Text = _viewModel.SelectedProveedor.Nombre;
            }
        }

        private void btnLimpiarProveedor_Click(object sender, EventArgs e)
        {
            txtNombreProveedor.Clear();
            _viewModel.SelectedProveedor = null;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtNumeroDocumento.Text))
                {
                    txtNumeroDocumento.Focus();
                    txtNumeroDocumento.ErrorText = "Debe indicar un valor para continuar";
                    return;
                }

                var result = XtraMessageBox.Show("¿Desea guardar los datos de la compra en el sistema?", "Guardar",
                    MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (result != DialogResult.OK)
                {
                    return;
                }

                if (_viewModel.SelectedCompra.Idcompra <= 0)
                {
                    _viewModel.SelectedCompra.Estado = EstadoCompra.Proforma;
                }
                else if (_viewModel.SelectedCompra.Estado == EstadoCompra.Proforma)
                {
                    _viewModel.SelectedCompra.Estado = toggleAprobar.IsOn
                        ? EstadoCompra.Aprobada
                        : EstadoCompra.Proforma;
                }

                _viewModel.SelectedCompra.Fecha = txtFecha.DateTime;
                _viewModel.SelectedCompra.NumeroDocumento = txtNumeroDocumento.Text;
                var save = await _viewModel.Save();
                if (save)
                {
                    DialogResult = DialogResult.OK;
                    Close();
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
        }

        private async void ComprasFormView_Load(object sender, EventArgs e)
        {
            _viewModel.SelectedCompra ??= new ComprasDto
            {
                Fecha = DateTime.Now,
            };

            if (_viewModel.SelectedCompra.Idcompra > 0)
            {
                await SetValueCompra();
            }
            else
            {
                txtFecha.DateTime = _viewModel.SelectedCompra.Fecha;
                lblCompraAprobada.Text = "Nueva cotización";
                toggleAprobar.IsOn = false;
                toggleAprobar.Enabled = false;
            }
        }

        private async Task SetValueCompra()
        {
            try
            {
                if (_viewModel.SelectedCompra is null) return;
                txtNumeroDocumento.Text = _viewModel.SelectedCompra.NumeroDocumento;
                txtFecha.DateTime = _viewModel.SelectedCompra.Fecha;
                txtNombreProveedor.Text = _viewModel.SelectedCompra.Proveedores.Nombre;
                _viewModel.SelectedProveedor = _viewModel.SelectedCompra.Proveedores;
                await _viewModel.LoadDetalleCompra();
                txtSubtotal.EditValue = _viewModel.SelectedCompra.Subtotal;
                txtIva.EditValue = _viewModel.SelectedCompra.Iva;
                if (_viewModel.SelectedCompra.Iva == 0m)
                {
                    _viewModel.AplicaIva = false;
                    toggleIva.IsOn = false;
                }

                txtTotal.EditValue = _viewModel.SelectedCompra.Total;
                switch (_viewModel.SelectedCompra.Estado)
                {
                    case EstadoCompra.Parcial:
                        lblCompraAprobada.Text = @"PARCIAL";
                        btnSave.Enabled = false;
                        toggleAprobar.IsOn = true;
                        toggleAprobar.Enabled = false;
                        break;
                    case EstadoCompra.Pagada:
                        lblCompraAprobada.Text = @"PAGADA";
                        btnSave.Enabled = false;
                        toggleAprobar.IsOn = true;
                        toggleAprobar.Enabled = false;
                        break;
                    case EstadoCompra.Aprobada:
                        lblCompraAprobada.Text = @"APROBADA";
                        toggleAprobar.IsOn = true;
                        toggleAprobar.Enabled = false;
                        btnSave.Enabled = false;
                        break;
                    case EstadoCompra.Anulada:
                        break;
                    case EstadoCompra.Proforma:
                        lblCompraAprobada.Text = @"Aprobar?";
                        toggleAprobar.IsOn = false;
                        toggleAprobar.Enabled = true;
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
            }
        }
    }
}
