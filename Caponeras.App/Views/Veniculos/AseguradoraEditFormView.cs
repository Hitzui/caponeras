using Caponeras.App.Dto;
using Caponeras.App.ViewModels.Vehiculo;
using DevExpress.XtraEditors;

namespace Caponeras.App.Views.Veniculos;

public sealed class AseguradoraEditFormView : XtraForm
{
    private readonly AseguradorasViewModel _viewModel;
    private readonly AseguradorasDto _agencia;
    private readonly TextBox _txtNombre = new();
    private readonly TextBox _txtNombreCorto = new();
    private readonly TextBox _txtTelefono = new();
    private readonly TextBox _txtCorreo = new();
    private readonly TextBox _txtSitioWeb = new();
    private readonly TextBox _txtDireccion = new();
    private readonly CheckBox _chkActiva = new();
    private readonly SimpleButton _btnGuardar = new();
    private readonly SimpleButton _btnCancelar = new();

    public AseguradoraEditFormView(AseguradorasViewModel viewModel, AseguradorasDto agencia)
    {
        _viewModel = viewModel;
        _agencia = agencia;
        InitializeForm();
        LoadAgency();
    }

    private void InitializeForm()
    {
        Text = _agencia.Idaseguradora == 0 ? "Agregar agencia de seguros" : "Editar agencia de seguros";
        StartPosition = FormStartPosition.CenterParent;
        FormBorderStyle = FormBorderStyle.FixedDialog;
        MaximizeBox = false;
        MinimizeBox = false;
        ShowInTaskbar = false;
        ClientSize = new Size(620, 410);

        var layout = new TableLayoutPanel
        {
            Dock = DockStyle.Fill,
            Padding = new Padding(20),
            ColumnCount = 2,
            RowCount = 8,
            AutoSize = false
        };
        layout.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 130));
        layout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100));
        for (var row = 0; row < 6; row++)
            layout.RowStyles.Add(new RowStyle(SizeType.Absolute, row == 5 ? 72 : 38));
        layout.RowStyles.Add(new RowStyle(SizeType.Absolute, 34));
        layout.RowStyles.Add(new RowStyle(SizeType.Percent, 100));

        AddField(layout, "Agencia / Aseguradora *", _txtNombre, 0);
        AddField(layout, "Nombre corto", _txtNombreCorto, 1);
        AddField(layout, "Teléfono", _txtTelefono, 2);
        AddField(layout, "Correo", _txtCorreo, 3);
        AddField(layout, "Sitio web", _txtSitioWeb, 4);
        _txtDireccion.Multiline = true;
        _txtDireccion.ScrollBars = ScrollBars.Vertical;
        AddField(layout, "Dirección", _txtDireccion, 5);

        _chkActiva.Text = "Agencia activa";
        _chkActiva.Anchor = AnchorStyles.Left;
        layout.Controls.Add(_chkActiva, 1, 6);

        var buttons = new FlowLayoutPanel
        {
            Dock = DockStyle.Fill,
            FlowDirection = FlowDirection.RightToLeft,
            WrapContents = false,
            Padding = new Padding(0, 8, 0, 0)
        };
        _btnGuardar.Text = "Guardar";
        _btnGuardar.Width = 110;
        _btnGuardar.DialogResult = DialogResult.None;
        _btnGuardar.Click += Guardar_Click;
        _btnCancelar.Text = "Cancelar";
        _btnCancelar.Width = 110;
        _btnCancelar.DialogResult = DialogResult.Cancel;
        buttons.Controls.Add(_btnGuardar);
        buttons.Controls.Add(_btnCancelar);
        layout.Controls.Add(buttons, 0, 7);
        layout.SetColumnSpan(buttons, 2);

        Controls.Add(layout);
        AcceptButton = _btnGuardar;
        CancelButton = _btnCancelar;
    }

    private static void AddField(TableLayoutPanel layout, string caption, Control editor, int row)
    {
        var label = new Label
        {
            Text = caption,
            Dock = DockStyle.Fill,
            TextAlign = ContentAlignment.MiddleRight,
            AutoEllipsis = true,
            Padding = new Padding(0, 0, 8, 0)
        };
        editor.Dock = DockStyle.Fill;
        if (editor is TextBox textBox)
            textBox.Margin = new Padding(3, 6, 3, 6);
        layout.Controls.Add(label, 0, row);
        layout.Controls.Add(editor, 1, row);
    }

    private void LoadAgency()
    {
        _txtNombre.Text = _agencia.Nombre;
        _txtNombreCorto.Text = _agencia.NombreCorto;
        _txtTelefono.Text = _agencia.Telefono;
        _txtCorreo.Text = _agencia.Correo;
        _txtSitioWeb.Text = _agencia.SitioWeb;
        _txtDireccion.Text = _agencia.Direccion;
        _chkActiva.Checked = _agencia.Activo;
        _txtNombre.Focus();
    }

    private async void Guardar_Click(object? sender, EventArgs e)
    {
        _btnGuardar.Enabled = false;
        try
        {
            var dto = new AseguradorasDto
            {
                Idaseguradora = _agencia.Idaseguradora,
                Nombre = _txtNombre.Text.Trim(),
                NombreCorto = _txtNombreCorto.Text.Trim(),
                Telefono = _txtTelefono.Text.Trim(),
                Correo = _txtCorreo.Text.Trim(),
                SitioWeb = _txtSitioWeb.Text.Trim(),
                Direccion = _txtDireccion.Text.Trim(),
                Activo = _chkActiva.Checked
            };

            var saved = await _viewModel.Save(dto);
            if (saved > 0)
            {
                DialogResult = DialogResult.OK;
                Close();
                return;
            }

            XtraMessageBox.Show(
                string.IsNullOrWhiteSpace(_viewModel.ErrorMessage)
                    ? "No fue posible guardar la agencia."
                    : _viewModel.ErrorMessage,
                "Agencias de seguros",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning);
        }
        catch (Exception ex)
        {
            XtraMessageBox.Show(ex.GetBaseException().Message, "Agencias de seguros",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        finally
        {
            _btnGuardar.Enabled = true;
        }
    }
}
