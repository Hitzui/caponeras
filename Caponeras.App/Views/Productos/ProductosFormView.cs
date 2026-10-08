using Caponeras.App.Dto;
using Caponeras.App.Helpers;
using Caponeras.App.ViewModels.Productos;
using Caponeras.App.Views.Layouts;
using DevExpress.XtraEditors;
using System;
using System.Globalization;
using System.Linq;

namespace Caponeras.App.Views.Productos;

public partial class ProductosFormView : FormLayout
{
    private ProductosFormViewModel _viewModel;
    private int _idproducto = 0;

    public ProductosFormView(ProductosFormViewModel viewModel)
    {
        _viewModel = viewModel;
        InitializeComponent();
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

            if (cmbCategoria.SelectedItem is not CategoriaProductoDto selectedCategoria)
            {
                _viewModel.MensajeAlerta(TypeAlert.Warning, "Guardar", "Seleccionar categoria");
                return;
            }

            if (cmbUnidadMedida.SelectedItem is not UnidadMedidaDto selectedUnidadMedida)
            {
                _viewModel.MensajeAlerta(TypeAlert.Warning, "Guardar", "Seleccionar unidad medida");
                return;
            }

            if (!TryReadDecimal(txtPrecio, required: true, out var precio) ||
                !TryReadDecimal(txtStockMinimo, required: false, out var stockMinimo) ||
                !TryReadDecimal(txtStockActual, required: false, out var stockActual))
            {
                return;
            }

            var producto = new ProductoDto
            {
                IdProducto = _idproducto,
                Codigo = txtCodigo.Text.Trim(),
                Nombre = txtNombre.Text.Trim(),
                Descripcion = txtDescripcion.Text.Trim(),
                IdCategoria = selectedCategoria.IdCategoria,
                IdUnidadMedida = selectedUnidadMedida.IdUnidad,
                StockMinimo = stockMinimo,
                StockActual = stockActual,
                PrecioCosto = precio,
                PrecioVenta = _viewModel.SelectedProducto?.PrecioVenta ?? precio,
                UrlImage = _viewModel.SelectedProducto?.UrlImage,
                Activo = true,
                Inventariable = chkInventariable.Checked
            };
            // Obtiene la ruta del archivo que el usuario cargó.
            var filePath = txtImagen.GetLoadedImageLocation();

            if (!string.IsNullOrEmpty(filePath))
            {
                producto.Imagen = txtImagen.Image;
            }

            var save = await _viewModel.Save(producto);
            if (save)
            {
                Close();
            }
        }
        catch (Exception ex)
        {
            _viewModel.MensajeAlerta(TypeAlert.Error, "Error", $"Error al guardar el producto {ex.Message}");
        }
    }

    private bool ValidateForm()
    {
        var result = true;

        result &= HelperMethods.ValidateRequired(cmbCategoria, "Seleccionar categoria", errorProvider1);
        result &= HelperMethods.ValidateRequired(cmbUnidadMedida, "Seleccionar unidad de medida", errorProvider1);
        result &= HelperMethods.ValidateRequired(txtCodigo, "El código es requerido", errorProvider1);
        result &= HelperMethods.ValidateRequired(txtNombre, "Nombre del repuesto requerido", errorProvider1);
        result &= TryReadDecimal(txtPrecio, required: true, out _);
        result &= TryReadDecimal(txtStockMinimo, required: false, out _);
        result &= TryReadDecimal(txtStockActual, required: false, out _);

        return result;
    }

    private bool TryReadDecimal(Control control, bool required, out decimal value)
    {
        var text = control.Text?.Trim();
        if (string.IsNullOrEmpty(text) && !required)
        {
            errorProvider1.SetError(control, string.Empty);
            value = 0m;
            return true;
        }

        if (decimal.TryParse(text, NumberStyles.Number, CultureInfo.CurrentCulture, out value) && value >= 0m)
        {
            errorProvider1.SetError(control, string.Empty);
            return true;
        }

        errorProvider1.SetError(control,
            required ? "Ingrese un precio numérico igual o mayor a cero." : "Ingrese una cantidad numérica igual o mayor a cero.");
        control.Focus();
        return false;
    }


    private void ProductosFormView_Load(object sender, EventArgs e)
    {
        txtCodigo.Focus();
        LoadProductoData();
        LoadCategorias();
        LoadUnidadesMedida();
    }

    private void LoadProductoData()
    {
        _viewModel.LoadSelected();
        if (_viewModel.SelectedProducto is null) return;
        _idproducto = _viewModel.SelectedProducto.IdProducto;
        txtCodigo.Text = _viewModel.SelectedProducto.Codigo;
        txtNombre.Text = _viewModel.SelectedProducto.Nombre;
        txtDescripcion.Text = _viewModel.SelectedProducto.Descripcion;
        txtPrecio.EditValue = _viewModel.SelectedProducto.PrecioVenta;
        txtStockMinimo.EditValue = _viewModel.SelectedProducto.StockMinimo;
        txtStockActual.EditValue = _viewModel.SelectedProducto.StockActual;
        cmbCategoria.SelectedItem = _viewModel.SelectedProducto.CategoriasProductos;
        txtImagen.Image = _viewModel.SelectedProducto.Imagen;
        chkInventariable.Checked = _viewModel.SelectedProducto.Inventariable;
    }

    private void LoadCategorias()
    {
        var categorias = _viewModel.GetCategorias();
        cmbCategoria.Properties.Items.Clear();
        foreach (var dto in categorias)
        {
            cmbCategoria.Properties.Items.Add(dto);
            if (_viewModel.SelectedProducto is null) continue;
            if (_viewModel.SelectedProducto.IdCategoria == dto.IdCategoria)
            {
                cmbCategoria.SelectedItem = dto;
            }
        }
    }

    private void LoadUnidadesMedida()
    {
        var unidades = _viewModel.GetUnidadesMedida();
        cmbUnidadMedida.Properties.Items.Clear();
        foreach (var dto in unidades)
        {
            cmbUnidadMedida.Properties.Items.Add(dto);
            if (_viewModel.SelectedProducto is null) continue;
            if (_viewModel.SelectedProducto.IdUnidadMedida == dto.IdUnidad)
            {
                cmbUnidadMedida.SelectedItem = dto;
            }
        }
    }
}
