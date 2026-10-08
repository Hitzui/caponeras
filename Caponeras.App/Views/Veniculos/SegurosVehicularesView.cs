using Caponeras.App.Dto;
using Caponeras.App.Helpers;
using Caponeras.App.ViewModels.Vehiculo;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Grid;

namespace Caponeras.App.Views.Veniculos;

public sealed class SegurosVehicularesView : XtraForm
{
    private readonly SegurosVehicularesViewModel _viewModel;
    private readonly GridControl _grid = new();
    private readonly GridView _gridView = new();
    private readonly BindingSource _source = new();

    public SegurosVehicularesView(SegurosVehicularesViewModel viewModel)
    {
        _viewModel = viewModel;
        InitializeForm();
    }

    private void InitializeForm()
    {
        Text = "Seguros vehiculares";
        StartPosition = FormStartPosition.CenterParent;
        WindowState = FormWindowState.Maximized;
        ShowInTaskbar = false;
        _grid.Dock = DockStyle.Fill;
        _grid.DataSource = _source;
        _grid.MainView = _gridView;
        _grid.ViewCollection.Add(_gridView);

        _gridView.GridControl = _grid;
        _gridView.OptionsBehavior.Editable = false;
        _gridView.OptionsSelection.EnableAppearanceFocusedCell = false;
        _gridView.OptionsView.ShowGroupPanel = false;
        _gridView.OptionsView.ShowAutoFilterRow = true;
        _gridView.OptionsView.ColumnAutoWidth = false;
        _gridView.KeyDown += GridView_KeyDown;
        AddColumn(nameof(SeguroVehicularDto.VehiculoDescripcion), "Vehículo", 250);
        AddColumn(nameof(SeguroVehicularDto.AseguradoraNombre), "Aseguradora", 190);
        AddColumn(nameof(SeguroVehicularDto.TipoSeguroNombre), "Tipo de seguro", 250);
        AddColumn(nameof(SeguroVehicularDto.NumeroPoliza), "N.º de póliza", 140);
        AddColumn(nameof(SeguroVehicularDto.NumeroCertificado), "N.º certificado", 130);
        AddColumn(nameof(SeguroVehicularDto.FechaInicio), "Vigente desde", 115, "d");
        AddColumn(nameof(SeguroVehicularDto.FechaVencimiento), "Vence", 115, "d");
        AddColumn(nameof(SeguroVehicularDto.PrimaAnual), "Prima", 110, "n2");
        AddColumn(nameof(SeguroVehicularDto.Moneda), "Moneda", 75);
        AddColumn(nameof(SeguroVehicularDto.EstadoDescripcion), "Estado", 90);

        Controls.Add(_grid);
        Load += SegurosVehicularesView_Load;
    }

    private GridColumn AddColumn(string field, string caption, int width, string? format = null)
    {
        var column = _gridView.Columns.AddField(field);
        column.Caption = caption;
        column.Visible = true;
        column.Width = width;
        if (format is not null)
        {
            column.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            if (field == nameof(SeguroVehicularDto.PrimaAnual))
                column.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            column.DisplayFormat.FormatString = format;
        }
        return column;
    }

    private async void SegurosVehicularesView_Load(object? sender, EventArgs e) => await LoadAsync();

    private async Task LoadAsync()
    {
        try
        {
            await _viewModel.Load();
            _source.DataSource = _viewModel.SegurosBindingList;
        }
        catch (Exception ex)
        {
            XtraMessageBox.Show(ex.GetBaseException().Message, "Seguros vehiculares",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    public async Task AgregarSeguroAsync()
    {
        using var form = new SeguroVehicularEditFormView(_viewModel, new SeguroVehicularDto());
        if (form.ShowDialog(this) == DialogResult.OK)
            await LoadAsync();
    }

    public async Task EditarSeguroSeleccionadoAsync()
    {
        if (_gridView.GetFocusedRow() is not SeguroVehicularDto selected)
        {
            _viewModel.ShowMessage(TypeAlert.Warning, "Seguros vehiculares", "Seleccione una póliza para editar.");
            return;
        }

        using var form = new SeguroVehicularEditFormView(_viewModel, selected);
        if (form.ShowDialog(this) == DialogResult.OK)
            await LoadAsync();
    }

    public async Task EliminarSeguroSeleccionadoAsync()
    {
        if (_gridView.GetFocusedRow() is not SeguroVehicularDto selected)
        {
            _viewModel.ShowMessage(TypeAlert.Warning, "Seguros vehiculares", "Seleccione una póliza para eliminar.");
            return;
        }

        if (XtraMessageBox.Show(
                "¿Desea marcar esta póliza como inactiva? Se conservará en el historial del vehículo.",
                "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
            return;

        await _viewModel.Deactivate(selected);
    }

    private async void GridView_KeyDown(object? sender, KeyEventArgs e)
    {
        if (e.KeyCode != Keys.Delete)
            return;
        e.Handled = true;
        e.SuppressKeyPress = true;
        await EliminarSeguroSeleccionadoAsync();
    }
}
