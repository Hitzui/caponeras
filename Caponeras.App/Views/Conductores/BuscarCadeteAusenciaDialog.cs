using Caponeras.App.Services;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;

namespace Caponeras.App.Views.Conductores;

internal partial class BuscarCadeteAusenciaDialog : XtraForm
{
    private List<CadeteAusenciaOpcionDto> _cadetes = [];

    public CadeteAusenciaOpcionDto? CadeteSeleccionado { get; private set; }

    // Used by the Visual Studio WinForms Designer.
    public BuscarCadeteAusenciaDialog()
    {
        InitializeComponent();
        ConfigureControls();
        _buscar.EditValueChanged += (_, _) => Filtrar();
        _gridView.DoubleClick += (_, _) => AceptarSeleccion();
        _seleccionar.Click += (_, _) => AceptarSeleccion();
        AcceptButton = _seleccionar;
        CancelButton = _cancelar;
    }

    public BuscarCadeteAusenciaDialog(List<CadeteAusenciaOpcionDto> cadetes) : this()
    {
        _cadetes = cadetes;
        Filtrar();
    }

    private void ConfigureControls()
    {
        _grid.MainView = _gridView;
        _gridView.Columns.AddVisible(nameof(CadeteAusenciaOpcionDto.Nombre), "Cadetes activos");
        _gridView.OptionsBehavior.Editable = false;
        _gridView.OptionsView.ShowGroupPanel = false;
        _gridView.OptionsView.ShowIndicator = false;
        _gridView.OptionsSelection.EnableAppearanceFocusedCell = false;
        _gridView.FocusRectStyle = DrawFocusRectStyle.RowFocus;
        _gridView.RowHeight = 36;
        _gridView.Appearance.HeaderPanel.Font = new Font("Segoe UI Semibold", 9F);
        _gridView.Appearance.Row.Font = new Font("Segoe UI", 9.5F);
        _gridView.Appearance.FocusedRow.BackColor = Color.FromArgb(219, 234, 254);
        _gridView.Appearance.FocusedRow.ForeColor = Color.FromArgb(30, 41, 59);
        _seleccionar.Appearance.BackColor = Color.FromArgb(37, 99, 235);
        _seleccionar.Appearance.ForeColor = Color.White;
        _seleccionar.Appearance.Options.UseBackColor = true;
        _seleccionar.Appearance.Options.UseForeColor = true;
    }

    private void Filtrar()
    {
        var termino = _buscar.Text.Trim();
        _grid.DataSource = _cadetes
            .Where(x => x.Nombre.Contains(termino, StringComparison.CurrentCultureIgnoreCase))
            .ToList();
    }

    private void AceptarSeleccion()
    {
        if (_gridView.GetFocusedRow() is not CadeteAusenciaOpcionDto cadete)
        {
            DialogResult = DialogResult.None;
            return;
        }
        CadeteSeleccionado = cadete;
        DialogResult = DialogResult.OK;
        Close();
    }
}
