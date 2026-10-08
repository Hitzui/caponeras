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
        var isNew = _agencia.Idaseguradora == 0;
        var title = isNew ? "Nueva agencia de seguros" : "Editar agencia de seguros";
        Text = title;
        StartPosition = FormStartPosition.CenterParent;
        FormBorderStyle = FormBorderStyle.FixedDialog;
        MaximizeBox = false;
        MinimizeBox = false;
        ShowInTaskbar = false;
        ClientSize = new Size(700, 590);
        BackColor = Color.FromArgb(244, 247, 250);
        Font = new Font("Segoe UI", 9F);

        var header = new Panel
        {
            BackColor = Color.FromArgb(27, 72, 91),
            Location = new Point(0, 0),
            Size = new Size(ClientSize.Width, 104),
            Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right
        };
        var badge = new Label
        {
            Text = "✓",
            Font = new Font("Segoe UI", 19F, FontStyle.Bold),
            ForeColor = Color.White,
            BackColor = Color.FromArgb(42, 130, 151),
            TextAlign = ContentAlignment.MiddleCenter,
            Location = new Point(26, 25),
            Size = new Size(52, 52)
        };
        var titleLabel = new Label
        {
            Text = title,
            Font = new Font("Segoe UI", 17F, FontStyle.Bold),
            ForeColor = Color.White,
            AutoSize = true,
            Location = new Point(94, 23)
        };
        var subtitle = new Label
        {
            Text = "Registre la agencia que comercializa las pólizas de los vehículos.",
            Font = new Font("Segoe UI", 9F),
            ForeColor = Color.FromArgb(218, 231, 237),
            AutoSize = true,
            Location = new Point(96, 57)
        };
        header.Controls.AddRange(new Control[] { badge, titleLabel, subtitle });

        StyleInput(_txtNombre);
        StyleInput(_txtNombreCorto);
        StyleInput(_txtTelefono);
        StyleInput(_txtCorreo);
        StyleInput(_txtSitioWeb);
        _txtDireccion.Multiline = true;
        _txtDireccion.ScrollBars = ScrollBars.Vertical;
        StyleInput(_txtDireccion);

        var card = new Panel
        {
            BackColor = Color.White,
            Location = new Point(24, 124),
            Size = new Size(652, 390),
            BorderStyle = BorderStyle.FixedSingle
        };
        card.Controls.Add(CreateField("Agencia / Aseguradora *", _txtNombre, 22, 17, 606, 63));
        card.Controls.Add(CreateField("Nombre corto", _txtNombreCorto, 22, 90, 292, 63));
        card.Controls.Add(CreateField("Teléfono", _txtTelefono, 336, 90, 292, 63));
        card.Controls.Add(CreateField("Correo", _txtCorreo, 22, 163, 292, 63));
        card.Controls.Add(CreateField("Sitio web", _txtSitioWeb, 336, 163, 292, 63));
        card.Controls.Add(CreateField("Dirección", _txtDireccion, 22, 236, 606, 91));

        _chkActiva.Text = "Agencia activa";
        _chkActiva.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
        _chkActiva.ForeColor = Color.FromArgb(46, 68, 80);
        _chkActiva.Location = new Point(25, 342);
        _chkActiva.AutoSize = true;
        card.Controls.Add(_chkActiva);

        var buttons = new FlowLayoutPanel
        {
            Location = new Point(24, 527),
            Size = new Size(652, 45),
            FlowDirection = FlowDirection.RightToLeft,
            WrapContents = false,
            BackColor = BackColor
        };
        _btnGuardar.Text = "Guardar";
        _btnGuardar.Size = new Size(132, 40);
        _btnGuardar.DialogResult = DialogResult.None;
        _btnGuardar.Appearance.BackColor = Color.FromArgb(24, 126, 151);
        _btnGuardar.Appearance.ForeColor = Color.White;
        _btnGuardar.Appearance.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
        _btnGuardar.Appearance.Options.UseBackColor = true;
        _btnGuardar.Appearance.Options.UseForeColor = true;
        _btnGuardar.Appearance.Options.UseFont = true;
        _btnGuardar.Click += Guardar_Click;
        _btnCancelar.Text = "Cancelar";
        _btnCancelar.Size = new Size(120, 40);
        _btnCancelar.DialogResult = DialogResult.Cancel;
        _btnCancelar.Appearance.BackColor = Color.White;
        _btnCancelar.Appearance.ForeColor = Color.FromArgb(62, 81, 91);
        _btnCancelar.Appearance.Options.UseBackColor = true;
        _btnCancelar.Appearance.Options.UseForeColor = true;
        buttons.Controls.Add(_btnGuardar);
        buttons.Controls.Add(_btnCancelar);

        Controls.Add(card);
        Controls.Add(buttons);
        Controls.Add(header);
        AcceptButton = _btnGuardar;
        CancelButton = _btnCancelar;
    }

    private static void StyleInput(TextBox editor)
    {
        editor.Font = new Font("Segoe UI", 10F);
        editor.ForeColor = Color.FromArgb(39, 55, 65);
        editor.BackColor = Color.White;
        editor.BorderStyle = BorderStyle.FixedSingle;
        editor.Margin = Padding.Empty;
    }

    private static Panel CreateField(string caption, Control editor, int x, int y, int width, int height)
    {
        var field = new Panel
        {
            Location = new Point(x, y),
            Size = new Size(width, height),
            BackColor = Color.White
        };
        var label = new Label
        {
            Text = caption,
            Font = new Font("Segoe UI", 8.5F, FontStyle.Bold),
            ForeColor = Color.FromArgb(74, 95, 107),
            Location = new Point(0, 0),
            Size = new Size(width, 20),
            TextAlign = ContentAlignment.MiddleLeft
        };
        editor.Location = new Point(0, 24);
        editor.Size = new Size(width, height - 24);
        field.Controls.Add(label);
        field.Controls.Add(editor);
        return field;
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
