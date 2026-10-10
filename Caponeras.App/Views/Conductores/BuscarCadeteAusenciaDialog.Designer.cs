#nullable disable

using DevExpress.XtraEditors;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Grid;

namespace Caponeras.App.Views.Conductores;

internal partial class BuscarCadeteAusenciaDialog
{
    private System.ComponentModel.IContainer components = null;
    private TableLayoutPanel rootLayout;
    private LabelControl lblTitulo;
    private TextEdit _buscar;
    private GridControl _grid;
    private GridView _gridView;
    private FlowLayoutPanel actionPanel;
    private SimpleButton _seleccionar;
    private SimpleButton _cancelar;

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
        lblTitulo = new LabelControl();
        _buscar = new TextEdit();
        _grid = new GridControl();
        _gridView = new GridView();
        actionPanel = new FlowLayoutPanel();
        _seleccionar = new SimpleButton();
        _cancelar = new SimpleButton();
        ((System.ComponentModel.ISupportInitialize)_buscar.Properties).BeginInit();
        ((System.ComponentModel.ISupportInitialize)_grid).BeginInit();
        ((System.ComponentModel.ISupportInitialize)_gridView).BeginInit();
        rootLayout.SuspendLayout();
        actionPanel.SuspendLayout();
        SuspendLayout();
        //
        // rootLayout
        //
        rootLayout.BackColor = Color.FromArgb(245, 247, 250);
        rootLayout.ColumnCount = 1;
        rootLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
        rootLayout.Controls.Add(lblTitulo, 0, 0);
        rootLayout.Controls.Add(_buscar, 0, 1);
        rootLayout.Controls.Add(_grid, 0, 2);
        rootLayout.Controls.Add(actionPanel, 0, 3);
        rootLayout.Dock = DockStyle.Fill;
        rootLayout.Padding = new Padding(18);
        rootLayout.RowCount = 4;
        rootLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 58F));
        rootLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 44F));
        rootLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
        rootLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 50F));
        rootLayout.Name = "rootLayout";
        //
        // lblTitulo
        //
        lblTitulo.Appearance.Font = new Font("Segoe UI Semibold", 18F);
        lblTitulo.Appearance.ForeColor = Color.FromArgb(15, 23, 42);
        lblTitulo.Appearance.Options.UseFont = true;
        lblTitulo.Appearance.Options.UseForeColor = true;
        lblTitulo.Dock = DockStyle.Fill;
        lblTitulo.Name = "lblTitulo";
        lblTitulo.Text = "Buscar cadete";
        //
        // _buscar
        //
        _buscar.Dock = DockStyle.Fill;
        _buscar.Name = "_buscar";
        _buscar.Properties.NullValuePrompt = "Escriba un nombre para filtrar la lista";
        //
        // _grid
        //
        _grid.Dock = DockStyle.Fill;
        _grid.Name = "_grid";
        _grid.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] { _gridView });
        _gridView.GridControl = _grid;
        _gridView.Name = "_gridView";
        //
        // actionPanel
        //
        actionPanel.Controls.Add(_seleccionar);
        actionPanel.Controls.Add(_cancelar);
        actionPanel.Dock = DockStyle.Fill;
        actionPanel.FlowDirection = FlowDirection.RightToLeft;
        actionPanel.Name = "actionPanel";
        actionPanel.WrapContents = false;
        //
        // _seleccionar
        //
        _seleccionar.DialogResult = DialogResult.OK;
        _seleccionar.Name = "_seleccionar";
        _seleccionar.Size = new Size(150, 36);
        _seleccionar.Text = "Seleccionar cadete";
        //
        // _cancelar
        //
        _cancelar.DialogResult = DialogResult.Cancel;
        _cancelar.Name = "_cancelar";
        _cancelar.Size = new Size(96, 36);
        _cancelar.Text = "Cancelar";
        //
        // BuscarCadeteAusenciaDialog
        //
        AcceptButton = _seleccionar;
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        CancelButton = _cancelar;
        ClientSize = new Size(650, 540);
        Controls.Add(rootLayout);
        FormBorderStyle = FormBorderStyle.FixedDialog;
        MaximizeBox = false;
        MinimizeBox = false;
        Name = "BuscarCadeteAusenciaDialog";
        StartPosition = FormStartPosition.CenterParent;
        Text = "Seleccionar cadete";
        ((System.ComponentModel.ISupportInitialize)_buscar.Properties).EndInit();
        ((System.ComponentModel.ISupportInitialize)_grid).EndInit();
        ((System.ComponentModel.ISupportInitialize)_gridView).EndInit();
        rootLayout.ResumeLayout(false);
        actionPanel.ResumeLayout(false);
        ResumeLayout(false);
    }
}
