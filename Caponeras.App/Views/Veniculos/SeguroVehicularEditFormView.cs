using Caponeras.App.Dto;
using Caponeras.App.ViewModels.Vehiculo;
using DevExpress.XtraEditors;
using ComboBox = System.Windows.Forms.ComboBox;

namespace Caponeras.App.Views.Veniculos;

public sealed class SeguroVehicularEditFormView : XtraForm
{
    private readonly SegurosVehicularesViewModel _viewModel;
    private readonly SeguroVehicularDto _source;
    private readonly ComboBox _cmbVehiculo = CreateComboBox();
    private readonly ComboBox _cmbAseguradora = CreateComboBox();
    private readonly ComboBox _cmbTipoSeguro = CreateComboBox();
    private readonly ComboBox _cmbMoneda = CreateComboBox();
    private readonly TextBox _txtPoliza = CreateTextBox();
    private readonly TextBox _txtCertificado = CreateTextBox();
    private readonly TextBox _txtArchivo = CreateTextBox();
    private readonly TextBox _txtObservaciones = CreateTextBox();
    private readonly DateTimePicker _fechaInicio = new();
    private readonly DateTimePicker _fechaVencimiento = new();
    private readonly NumericUpDown _prima = new();
    private readonly NumericUpDown _deducible = new();
    private readonly CheckBox _chkActiva = new();
    private readonly SimpleButton _btnGuardar = new();
    private readonly SimpleButton _btnCancelar = new();
    private readonly SimpleButton _btnExaminar = new();

    public SeguroVehicularEditFormView(SegurosVehicularesViewModel viewModel, SeguroVehicularDto source)
    {
        _viewModel = viewModel;
        _source = source;
        InitializeForm();
        Load += Form_Load;
    }

    private void InitializeForm()
    {
        var isNew = _source.Idseguro == 0;
        var title = isNew ? "Registrar seguro vehicular" : "Editar seguro vehicular";
        Text = title;
        StartPosition = FormStartPosition.CenterParent;
        FormBorderStyle = FormBorderStyle.FixedDialog;
        MaximizeBox = false;
        MinimizeBox = false;
        ShowInTaskbar = false;
        ClientSize = new Size(740, 740);
        BackColor = Color.FromArgb(244, 247, 250);
        Font = new Font("Segoe UI", 9F);

        var header = new Panel
        {
            BackColor = Color.FromArgb(27, 72, 91),
            Location = Point.Empty,
            Size = new Size(ClientSize.Width, 92)
        };
        header.Controls.Add(new Label
        {
            Text = "▣",
            Font = new Font("Segoe UI Symbol", 22F, FontStyle.Bold),
            ForeColor = Color.White,
            BackColor = Color.FromArgb(42, 130, 151),
            TextAlign = ContentAlignment.MiddleCenter,
            Location = new Point(25, 20),
            Size = new Size(52, 52)
        });
        header.Controls.Add(new Label
        {
            Text = title,
            Font = new Font("Segoe UI", 17F, FontStyle.Bold),
            ForeColor = Color.White,
            AutoSize = true,
            Location = new Point(94, 18)
        });
        header.Controls.Add(new Label
        {
            Text = "Póliza, cobertura obligatoria y vigencia del vehículo.",
            Font = new Font("Segoe UI", 9F),
            ForeColor = Color.FromArgb(218, 231, 237),
            AutoSize = true,
            Location = new Point(96, 54)
        });

        StyleDate(_fechaInicio);
        StyleDate(_fechaVencimiento);
        StyleAmount(_prima);
        StyleAmount(_deducible);
        _txtObservaciones.Multiline = true;
        _txtObservaciones.ScrollBars = ScrollBars.Vertical;

        var card = new Panel
        {
            BackColor = Color.White,
            Location = new Point(22, 108),
            Size = new Size(696, 566),
            BorderStyle = BorderStyle.FixedSingle
        };
        card.Controls.Add(CreateField("Vehículo *", _cmbVehiculo, 20, 15, 654, 58));
        card.Controls.Add(CreateField("Agencia / Aseguradora *", _cmbAseguradora, 20, 81, 315, 58));
        card.Controls.Add(CreateField("Tipo de seguro *", _cmbTipoSeguro, 359, 81, 315, 58));
        card.Controls.Add(CreateField("Número de póliza *", _txtPoliza, 20, 147, 315, 58));
        card.Controls.Add(CreateField("Número de certificado", _txtCertificado, 359, 147, 315, 58));
        card.Controls.Add(CreateField("Inicio de vigencia *", _fechaInicio, 20, 213, 315, 58));
        card.Controls.Add(CreateField("Vencimiento *", _fechaVencimiento, 359, 213, 315, 58));
        card.Controls.Add(CreateField("Prima anual *", _prima, 20, 279, 220, 58));
        card.Controls.Add(CreateField("Moneda", _cmbMoneda, 260, 279, 150, 58));
        card.Controls.Add(CreateField("Deducible (opcional)", _deducible, 430, 279, 244, 58));

        var fileField = CreateField("Archivo de póliza (opcional)", _txtArchivo, 20, 345, 558, 58);
        _btnExaminar.Text = "Examinar...";
        _btnExaminar.Location = new Point(584, 369);
        _btnExaminar.Size = new Size(90, 32);
        _btnExaminar.Click += Examinar_Click;
        card.Controls.Add(fileField);
        card.Controls.Add(_btnExaminar);
        card.Controls.Add(CreateField("Observaciones", _txtObservaciones, 20, 411, 654, 100));

        _chkActiva.Text = "Póliza vigente / activa";
        _chkActiva.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
        _chkActiva.ForeColor = Color.FromArgb(46, 68, 80);
        _chkActiva.Location = new Point(24, 526);
        _chkActiva.AutoSize = true;
        card.Controls.Add(_chkActiva);

        var buttons = new FlowLayoutPanel
        {
            Location = new Point(22, 684),
            Size = new Size(696, 42),
            FlowDirection = FlowDirection.RightToLeft,
            WrapContents = false,
            BackColor = BackColor
        };
        _btnGuardar.Text = "Guardar póliza";
        _btnGuardar.Size = new Size(145, 38);
        _btnGuardar.Appearance.BackColor = Color.FromArgb(24, 126, 151);
        _btnGuardar.Appearance.ForeColor = Color.White;
        _btnGuardar.Appearance.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
        _btnGuardar.Appearance.Options.UseBackColor = true;
        _btnGuardar.Appearance.Options.UseForeColor = true;
        _btnGuardar.Appearance.Options.UseFont = true;
        _btnGuardar.Click += Guardar_Click;
        _btnCancelar.Text = "Cancelar";
        _btnCancelar.Size = new Size(120, 38);
        _btnCancelar.DialogResult = DialogResult.Cancel;
        buttons.Controls.Add(_btnGuardar);
        buttons.Controls.Add(_btnCancelar);

        Controls.Add(card);
        Controls.Add(buttons);
        Controls.Add(header);
        AcceptButton = _btnGuardar;
        CancelButton = _btnCancelar;
    }

    private async void Form_Load(object? sender, EventArgs e)
    {
        try
        {
            var vehicles = await _viewModel.GetVehiculos(_source.Idvehiculo > 0 ? _source.Idvehiculo : null);
            var agencies = await _viewModel.GetAseguradoras(_source.Idaseguradora > 0 ? _source.Idaseguradora : null);
            var types = await _viewModel.GetTiposSeguro(_source.TipoSeguro > 0 ? _source.TipoSeguro : null);

            SetOptions(_cmbVehiculo, vehicles.Select(v => new Option(v.Idvehiculo,
                $"{v.Codigo} · {v.Placa} · {v.Marca} {v.Modelo}")));
            SetOptions(_cmbAseguradora, agencies.Select(a => new Option(a.Idaseguradora, a.Nombre)));
            SetOptions(_cmbTipoSeguro, types.Select(t => new Option(t.Idtiposeguro, t.Nombre)));
            _cmbMoneda.Items.AddRange(new object[] { "C$", "US$" });

            SelectOption(_cmbVehiculo, _source.Idvehiculo);
            SelectOption(_cmbAseguradora, _source.Idaseguradora);
            SelectOption(_cmbTipoSeguro, _source.TipoSeguro);
            _cmbMoneda.SelectedItem = string.IsNullOrWhiteSpace(_source.Moneda) ? "C$" : _source.Moneda;
            if (_cmbMoneda.SelectedIndex < 0)
                _cmbMoneda.SelectedItem = "C$";

            _txtPoliza.Text = _source.NumeroPoliza;
            _txtCertificado.Text = _source.NumeroCertificado;
            _txtArchivo.Text = _source.ArchivoPoliza;
            _txtObservaciones.Text = _source.Observaciones;
            _fechaInicio.Value = _source.FechaInicio == DateTime.MinValue ? DateTime.Today : _source.FechaInicio.Date;
            _fechaVencimiento.Value = _source.FechaVencimiento == DateTime.MinValue
                ? DateTime.Today.AddYears(1)
                : _source.FechaVencimiento.Date;
            _prima.Value = ClampAmount(_source.PrimaAnual);
            _deducible.Value = ClampAmount(_source.Deducible ?? 0m);
            _chkActiva.Checked = _source.Estado != 0;
        }
        catch (Exception ex)
        {
            XtraMessageBox.Show(ex.GetBaseException().Message, "Cargar póliza",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }

    private async void Guardar_Click(object? sender, EventArgs e)
    {
        if (_cmbVehiculo.SelectedValue is not int vehicleId ||
            _cmbAseguradora.SelectedValue is not int insurerId ||
            _cmbTipoSeguro.SelectedValue is not int typeId)
        {
            XtraMessageBox.Show("Seleccione vehículo, agencia y tipo de seguro.", "Datos requeridos",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }
        if (_fechaVencimiento.Value.Date < _fechaInicio.Value.Date)
        {
            XtraMessageBox.Show("La fecha de vencimiento debe ser igual o posterior al inicio de vigencia.",
                "Rango de fechas", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }
        if (_prima.Value <= 0)
        {
            XtraMessageBox.Show("Indique una prima anual mayor que cero.", "Prima anual",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        _btnGuardar.Enabled = false;
        try
        {
            var dto = new SeguroVehicularDto
            {
                Idseguro = _source.Idseguro,
                Idvehiculo = vehicleId,
                Idaseguradora = insurerId,
                TipoSeguro = typeId,
                NumeroPoliza = _txtPoliza.Text.Trim(),
                NumeroCertificado = _txtCertificado.Text.Trim(),
                FechaInicio = _fechaInicio.Value.Date,
                FechaVencimiento = _fechaVencimiento.Value.Date,
                PrimaAnual = _prima.Value,
                Moneda = _cmbMoneda.SelectedItem?.ToString() ?? "C$",
                Deducible = _deducible.Value > 0 ? _deducible.Value : null,
                ArchivoPoliza = _txtArchivo.Text.Trim(),
                Observaciones = _txtObservaciones.Text.Trim(),
                Estado = _chkActiva.Checked ? 1 : 0
            };

            var result = await _viewModel.Save(dto);
            if (result > 0)
            {
                DialogResult = DialogResult.OK;
                Close();
                return;
            }

            XtraMessageBox.Show(
                string.IsNullOrWhiteSpace(_viewModel.ErrorMessage)
                    ? "No fue posible guardar la póliza."
                    : _viewModel.ErrorMessage,
                "Seguros vehiculares", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
        catch (Exception ex)
        {
            XtraMessageBox.Show(ex.GetBaseException().Message, "Seguros vehiculares",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        finally
        {
            _btnGuardar.Enabled = true;
        }
    }

    private void Examinar_Click(object? sender, EventArgs e)
    {
        using var dialog = new OpenFileDialog
        {
            Title = "Seleccionar archivo de póliza",
            Filter = "Documentos y archivos|*.pdf;*.jpg;*.jpeg;*.png|Todos los archivos|*.*",
            CheckFileExists = true
        };
        if (dialog.ShowDialog(this) == DialogResult.OK)
            _txtArchivo.Text = dialog.FileName;
    }

    private static void SetOptions(ComboBox combo, IEnumerable<Option> options)
    {
        combo.DisplayMember = nameof(Option.Label);
        combo.ValueMember = nameof(Option.Id);
        combo.DataSource = options.ToList();
        combo.SelectedIndex = -1;
    }

    private static void SelectOption(ComboBox combo, int id)
    {
        if (id > 0)
            combo.SelectedValue = id;
    }

    private static ComboBox CreateComboBox() => new()
    {
        DropDownStyle = ComboBoxStyle.DropDownList,
        Font = new Font("Segoe UI", 10F),
        BackColor = Color.White,
        ForeColor = Color.FromArgb(39, 55, 65)
    };

    private static TextBox CreateTextBox() => new()
    {
        Font = new Font("Segoe UI", 10F),
        BackColor = Color.White,
        ForeColor = Color.FromArgb(39, 55, 65),
        BorderStyle = BorderStyle.FixedSingle
    };

    private static void StyleDate(DateTimePicker picker)
    {
        picker.Font = new Font("Segoe UI", 10F);
        picker.Format = DateTimePickerFormat.Short;
    }

    private static void StyleAmount(NumericUpDown amount)
    {
        amount.Font = new Font("Segoe UI", 10F);
        amount.DecimalPlaces = 2;
        amount.Maximum = 999999999m;
        amount.Minimum = 0m;
        amount.ThousandsSeparator = true;
        amount.TextAlign = HorizontalAlignment.Right;
    }

    private static decimal ClampAmount(decimal? value) =>
        Math.Clamp(value ?? 0m, 0m, 999999999m);

    private static Panel CreateField(string caption, Control editor, int x, int y, int width, int height)
    {
        var field = new Panel
        {
            Location = new Point(x, y),
            Size = new Size(width, height),
            BackColor = Color.White
        };
        field.Controls.Add(new Label
        {
            Text = caption,
            Font = new Font("Segoe UI", 8.5F, FontStyle.Bold),
            ForeColor = Color.FromArgb(74, 95, 107),
            Location = new Point(0, 0),
            Size = new Size(width, 20),
            TextAlign = ContentAlignment.MiddleLeft
        });
        editor.Location = new Point(0, 24);
        editor.Size = new Size(width, height - 24);
        if (editor is TextBox textBox)
            textBox.Margin = Padding.Empty;
        field.Controls.Add(editor);
        return field;
    }

    private sealed record Option(int Id, string Label);
}
