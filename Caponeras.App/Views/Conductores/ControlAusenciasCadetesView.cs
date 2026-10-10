using Caponeras.App.Dto;
using Caponeras.App.Services;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Grid;

namespace Caponeras.App.Views.Conductores;

public partial class ControlAusenciasCadetesView : XtraForm
{
    private AusenciaCadeteService? _service;
    private readonly List<CadeteAusenciaOpcionDto> _cadetes = [];
    private AusenciaCadeteDto? _seleccion;
    private int? _idCadete;
    private bool _cargando;
    private bool _actualizandoGrid;

    // Used by the Visual Studio WinForms Designer.
    public ControlAusenciasCadetesView()
    {
        InitializeComponent();
        ConfigureControls();
        WireEvents();
    }

    public ControlAusenciasCadetesView(AusenciaCadeteService service) : this()
    {
        _service = service;
    }

    private void ConfigureControls()
    {
        _fecha.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.False;
        _fecha.Properties.Mask.EditMask = "d";
        _fecha.DateTime = DateTime.Today;

        //_motivo.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
        _motivo.Properties.MaxLength = 100;
        _motivo.Properties.Items.AddRange(new object[]
        {
            "Permiso autorizado", "Ausencia justificada", "Ausencia injustificada",
            "Incapacidad", "Trámite de licencia", "Otro"
        });

        gridView1.Columns.AddVisible(nameof(AusenciaCadeteDto.Cadete), "Cadete").Width = 230;
        gridView1.Columns.AddVisible(nameof(AusenciaCadeteDto.Motivo), "Motivo").Width = 180;
        gridView1.Columns.AddVisible(nameof(AusenciaCadeteDto.Vehiculo), "Vehículo").Width = 140;
        gridView1.Columns.AddVisible(nameof(AusenciaCadeteDto.Zona), "Zona").Width = 180;
        gridView1.Columns.AddVisible(nameof(AusenciaCadeteDto.Detalle), "Detalle");
        gridView1.OptionsBehavior.Editable = false;
        gridView1.OptionsView.ShowGroupPanel = false;
        gridView1.OptionsView.ShowIndicator = false;
        gridView1.OptionsView.ShowVerticalLines = DevExpress.Utils.DefaultBoolean.False;
        gridView1.OptionsView.EnableAppearanceEvenRow = true;
        gridView1.OptionsView.EnableAppearanceOddRow = true;
        gridView1.OptionsSelection.MultiSelect = false;
        gridView1.OptionsSelection.MultiSelectMode = GridMultiSelectMode.RowSelect;
        gridView1.OptionsSelection.EnableAppearanceFocusedRow = true;
        gridView1.OptionsSelection.EnableAppearanceFocusedCell = false;
        gridView1.FocusRectStyle = DrawFocusRectStyle.RowFocus;
        gridView1.RowHeight = 36;
        gridView1.Appearance.HeaderPanel.Font = new Font("Segoe UI Semibold", 9F);
        gridView1.Appearance.HeaderPanel.ForeColor = Color.FromArgb(51, 65, 85);
        gridView1.Appearance.HeaderPanel.BackColor = Color.FromArgb(241, 245, 249);
        gridView1.Appearance.Row.Font = new Font("Segoe UI", 9F);
        gridView1.Appearance.Row.ForeColor = Color.FromArgb(30, 41, 59);
        gridView1.Appearance.EvenRow.BackColor = Color.FromArgb(248, 250, 252);
        gridView1.Appearance.FocusedRow.BackColor = Color.FromArgb(219, 234, 254);
        gridView1.Appearance.FocusedRow.ForeColor = Color.FromArgb(30, 41, 59);

        _guardar.Appearance.BackColor = Color.FromArgb(37, 99, 235);
        _guardar.Appearance.ForeColor = Color.White;
        _guardar.Appearance.Options.UseBackColor = true;
        _guardar.Appearance.Options.UseForeColor = true;
        _eliminar.Appearance.ForeColor = Color.FromArgb(185, 28, 28);
        _eliminar.Appearance.Options.UseForeColor = true;
    }

    private void WireEvents()
    {
        Load += async (_, _) => await CargarInicialAsync();
        _fecha.EditValueChanged += async (_, _) =>
        {
            if (!_cargando && _fecha.EditValue is not null && _service is not null)
                await CargarRegistrosAsync();
        };
        gridView1.FocusedRowChanged += (_, _) => SeleccionarRegistro();
        gridView1.RowClick += (_, e) =>
        {
            if (e.RowHandle >= 0)
            {
                gridView1.FocusedRowHandle = e.RowHandle;
                SeleccionarRegistro();
            }
        };
        _nuevo.Click += (_, _) => LimpiarFormulario();
        _guardar.Click += async (_, _) => await GuardarAsync();
        _eliminar.Click += async (_, _) => await EliminarAsync();
        _buscarCadete.Click += (_, _) => BuscarCadete();
    }

    private async Task CargarInicialAsync()
    {
        if (_service is null || _cargando)
            return;
        _cargando = true;
        try
        {
            _cadetes.Clear();
            _cadetes.AddRange(await _service.ObtenerCadetesAsync());
            await CargarRegistrosInternoAsync();
        }
        catch (Exception ex)
        {
            MostrarError(ex);
        }
        finally
        {
            _cargando = false;
        }
    }

    private async Task CargarRegistrosAsync()
    {
        if (_service is null || _cargando)
            return;
        _cargando = true;
        try
        {
            await CargarRegistrosInternoAsync();
        }
        catch (Exception ex)
        {
            MostrarError(ex);
        }
        finally
        {
            _cargando = false;
        }
    }

    private async Task CargarRegistrosInternoAsync()
    {
        if (_service is null)
            return;
        _actualizandoGrid = true;
        try
        {
            var registros = await _service.ObtenerAsync(_fecha.DateTime.Date);
            _grid.DataSource = registros;
            gridView1.ClearSelection();
            _estado.Text = registros.Count == 1 ? "1 registro" : $"{registros.Count} registros";
            LimpiarFormulario();
        }
        finally
        {
            _actualizandoGrid = false;
        }
    }

    private void SeleccionarRegistro()
    {
        if (_actualizandoGrid || gridView1.GetFocusedRow() is not AusenciaCadeteDto dto)
            return;
        _seleccion = dto;
        _idCadete = dto.Idconductor;
        _cadete.Text = dto.Cadete;
        _motivo.EditValue = dto.Motivo;
        _detalle.Text = dto.Detalle ?? string.Empty;
        _guardar.Text = "Actualizar";
    }

    private void BuscarCadete()
    {
        using var dialogo = new BuscarCadeteAusenciaDialog(_cadetes);
        if (dialogo.ShowDialog(this) != DialogResult.OK || dialogo.CadeteSeleccionado is null)
            return;
        _idCadete = dialogo.CadeteSeleccionado.Id;
        _cadete.Text = dialogo.CadeteSeleccionado.Nombre;
    }

    private void LimpiarFormulario()
    {
        _seleccion = null;
        _idCadete = null;
        gridView1.ClearSelection();
        gridView1.FocusedRowHandle = GridControl.InvalidRowHandle;
        _cadete.Text = string.Empty;
        _motivo.EditValue = null;
        _detalle.Text = string.Empty;
        _guardar.Text = "Guardar";
    }

    private async Task GuardarAsync()
    {
        if (_service is null || _cargando)
            return;
        try
        {
            if (_idCadete is null)
                throw new InvalidOperationException("Busque y seleccione un cadete.");
            var dto = new AusenciaCadeteDto
            {
                Id = _seleccion?.Id ?? 0,
                Idconductor = _idCadete.Value,
                Fecha = _fecha.DateTime.Date,
                Motivo = _motivo.Text,
                Detalle = _detalle.Text
            };
            var accion = dto.Id == 0 ? "guardar" : "actualizar";
            if (XtraMessageBox.Show(this,
                    $"¿Confirma {accion} la ausencia de {_cadete.Text} para el {dto.Fecha:dd/MM/yyyy}?",
                    "Confirmar guardado",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question) != DialogResult.Yes)
                return;

            _cargando = true;
            await _service.GuardarAsync(dto);
            await CargarRegistrosInternoAsync();
            XtraMessageBox.Show(this,
                dto.Id == 0 ? "La ausencia se guardó correctamente." : "La ausencia se actualizó correctamente.",
                "Control de ausencias",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }
        catch (Exception ex)
        {
            MostrarError(ex);
        }
        finally
        {
            _cargando = false;
        }
    }

    private async Task EliminarAsync()
    {
        if (_service is null || _cargando)
            return;

        var registro = ObtenerRegistroSeleccionado();
        if (registro is null)
        {
            XtraMessageBox.Show(this, "Seleccione un registro para eliminarlo.", Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
            return;
        }
        if (XtraMessageBox.Show(this, "¿Desea eliminar la ausencia seleccionada?", Text,
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
            return;
        try
        {
            _cargando = true;
            await _service.EliminarAsync(registro.Id);
            await CargarRegistrosInternoAsync();
            XtraMessageBox.Show(this, "La ausencia se eliminó correctamente.", "Control de ausencias",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        catch (Exception ex)
        {
            MostrarError(ex);
        }
        finally
        {
            _cargando = false;
        }
    }

    private AusenciaCadeteDto? ObtenerRegistroSeleccionado()
    {
        if (gridView1.GetFocusedRow() is AusenciaCadeteDto enfocado)
            return enfocado;

        foreach (var rowHandle in gridView1.GetSelectedRows())
        {
            if (gridView1.GetRow(rowHandle) is AusenciaCadeteDto seleccionado)
                return seleccionado;
        }

        return _seleccion;
    }

    private void MostrarError(Exception ex)
    {
        XtraMessageBox.Show(this, ex.Message, "Control de ausencias", MessageBoxButtons.OK, MessageBoxIcon.Error);
    }
}
