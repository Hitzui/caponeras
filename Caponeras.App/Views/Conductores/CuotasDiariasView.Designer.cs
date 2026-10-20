#nullable disable

using Caponeras.App.Dto;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Grid;

namespace Caponeras.App.Views.Conductores;

public partial class CuotasDiariasView
{
    private System.ComponentModel.IContainer components = null;
    private TableLayoutPanel rootLayout;
    private PanelControl toolbar;
    private FlowLayoutPanel controlsLayout;
    private LabelControl lblFecha;
    private LabelControl lblAyuda;
    private DateEdit _fecha;
    private SimpleButton _filtrar;
    private SimpleButton _registrarPagos;
    private GridControl _grid;
    private GridView _gridView;
    private BindingSource _source;
    private RepositoryItemSpinEdit editorMonto;

    protected override void Dispose(bool disposing)
    {
        if (disposing)
            components?.Dispose();
        base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
        components = new System.ComponentModel.Container();
        rootLayout = new TableLayoutPanel();
        toolbar = new PanelControl();
        controlsLayout = new FlowLayoutPanel();
        lblFecha = new LabelControl();
        _fecha = new DateEdit();
        _filtrar = new SimpleButton();
        _registrarPagos = new SimpleButton();
        lblAyuda = new LabelControl();
        _grid = new GridControl();
        _gridView = new GridView();
        _source = new BindingSource(components);
        editorMonto = new RepositoryItemSpinEdit();

        rootLayout.SuspendLayout();
        toolbar.SuspendLayout();
        controlsLayout.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)_fecha.Properties).BeginInit();
        ((System.ComponentModel.ISupportInitialize)_grid).BeginInit();
        ((System.ComponentModel.ISupportInitialize)_gridView).BeginInit();
        ((System.ComponentModel.ISupportInitialize)_source).BeginInit();
        ((System.ComponentModel.ISupportInitialize)editorMonto).BeginInit();
        SuspendLayout();

        // rootLayout
        rootLayout.ColumnCount = 1;
        rootLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
        rootLayout.Controls.Add(toolbar, 0, 0);
        rootLayout.Controls.Add(_grid, 0, 1);
        rootLayout.Dock = DockStyle.Fill;
        rootLayout.Margin = new Padding(0);
        rootLayout.Padding = new Padding(12);
        rootLayout.RowCount = 2;
        rootLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 88F));
        rootLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
        rootLayout.Size = new Size(1050, 650);

        // toolbar
        toolbar.Controls.Add(controlsLayout);
        toolbar.Controls.Add(lblAyuda);
        toolbar.Dock = DockStyle.Fill;
        toolbar.Padding = new Padding(10, 8, 10, 6);

        // controlsLayout
        controlsLayout.Controls.AddRange(new Control[]
        {
            lblFecha, _fecha, _filtrar, _registrarPagos
        });
        controlsLayout.Dock = DockStyle.Top;
        controlsLayout.FlowDirection = FlowDirection.LeftToRight;
        controlsLayout.Height = 38;
        controlsLayout.Margin = new Padding(0);
        controlsLayout.Padding = new Padding(0);
        controlsLayout.WrapContents = false;

        // lblFecha
        lblFecha.Appearance.Options.UseTextOptions = true;
        lblFecha.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
        lblFecha.AutoSizeMode = LabelAutoSizeMode.None;
        lblFecha.Margin = new Padding(0, 0, 4, 0);
        lblFecha.Size = new Size(48, 28);
        lblFecha.Text = "Fecha:";

        // _fecha
        _fecha.DateTime = DateTime.Today;
        _fecha.Margin = new Padding(0, 0, 12, 0);
        _fecha.Size = new Size(155, 28);
        _fecha.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[]
        {
            new(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)
        });

        // _filtrar
        _filtrar.Margin = new Padding(0, 0, 10, 0);
        _filtrar.Size = new Size(100, 30);
        _filtrar.Text = "Filtrar";

        // _registrarPagos
        _registrarPagos.Appearance.BackColor = Color.FromArgb(0, 150, 105);
        _registrarPagos.Appearance.Options.UseBackColor = true;
        _registrarPagos.Appearance.Options.UseForeColor = true;
        _registrarPagos.Appearance.ForeColor = Color.White;
        _registrarPagos.Margin = new Padding(0);
        _registrarPagos.Size = new Size(145, 30);
        _registrarPagos.Text = "Registrar pagos";

        // lblAyuda
        lblAyuda.Appearance.ForeColor = Color.DimGray;
        lblAyuda.Appearance.Options.UseForeColor = true;
        lblAyuda.Dock = DockStyle.Bottom;
        lblAyuda.Padding = new Padding(0, 3, 0, 0);
        lblAyuda.Size = new Size(1000, 24);
        lblAyuda.Text = "Ingrese el monto en cada cadete que paga y luego seleccione «Registrar pagos».";

        // _grid
        _grid.DataSource = _source;
        _grid.Dock = DockStyle.Fill;
        _grid.MainView = _gridView;
        _grid.RepositoryItems.AddRange(new RepositoryItem[] { editorMonto });
        _grid.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] { _gridView });

        // _gridView
        _gridView.GridControl = _grid;
        _gridView.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False;
        _gridView.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.False;
        _gridView.OptionsView.ColumnAutoWidth = true;
        _gridView.OptionsView.RowAutoHeight = true;
        _gridView.OptionsView.ShowGroupPanel = false;
        _gridView.OptionsView.ShowIndicator = false;
        _gridView.Columns.AddRange(new GridColumn[]
        {
            CreateColumn("Conductor", nameof(CuotaDiariaGestionDto.Nombre), 190, true),
            CreateColumn("Identificación", nameof(CuotaDiariaGestionDto.Identificacion), 130, true),
            CreateColumn("Vehículo", nameof(CuotaDiariaGestionDto.Placa), 100, true),
            CreateColumn("Zona", nameof(CuotaDiariaGestionDto.Zona), 140, true),
            CreateCurrencyColumn("Cuota configurada", nameof(CuotaDiariaGestionDto.MontoCuota), 140, true),
            CreateCurrencyColumn("Pagado", nameof(CuotaDiariaGestionDto.MontoEntregado), 110, true),
            CreateCurrencyColumn("Pendiente", nameof(CuotaDiariaGestionDto.Diferencia), 115, true),
            CreateCurrencyColumn("Monto a pagar", nameof(CuotaDiariaGestionDto.MontoPago), 140, false, editorMonto)
        });

        // editorMonto
        editorMonto.IsFloatValue = true;
        editorMonto.Mask.EditMask = "c2";
        editorMonto.Mask.UseMaskAsDisplayFormat = true;
        editorMonto.MinValue = 0M;
        editorMonto.MaxValue = 100000000M;

        // CuotasDiariasView
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(1050, 650);
        Controls.Add(rootLayout);
        MinimumSize = new Size(900, 500);
        StartPosition = FormStartPosition.CenterParent;
        MinimizeBox = false;
        Name = "CuotasDiariasView";
        Text = "Pagos de cuotas por fecha";

        ((System.ComponentModel.ISupportInitialize)_fecha.Properties).EndInit();
        ((System.ComponentModel.ISupportInitialize)_grid).EndInit();
        ((System.ComponentModel.ISupportInitialize)_gridView).EndInit();
        ((System.ComponentModel.ISupportInitialize)_source).EndInit();
        ((System.ComponentModel.ISupportInitialize)editorMonto).EndInit();
        controlsLayout.ResumeLayout(false);
        toolbar.ResumeLayout(false);
        rootLayout.ResumeLayout(false);
        ResumeLayout(false);
    }

    private static GridColumn CreateColumn(string caption, string fieldName, int width, bool readOnly)
    {
        var column = new GridColumn
        {
            Caption = caption,
            FieldName = fieldName,
            Width = width,
            Visible = true
        };
        column.OptionsColumn.AllowEdit = !readOnly;
        column.OptionsColumn.ReadOnly = readOnly;
        return column;
    }

    private static GridColumn CreateCurrencyColumn(
        string caption,
        string fieldName,
        int width,
        bool readOnly,
        RepositoryItemSpinEdit editor = null)
    {
        var column = CreateColumn(caption, fieldName, width, readOnly);
        column.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
        column.DisplayFormat.FormatString = "c2";
        if (editor != null)
            column.ColumnEdit = editor;
        return column;
    }
}
