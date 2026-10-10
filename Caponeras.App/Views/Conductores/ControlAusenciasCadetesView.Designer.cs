#nullable disable

using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Grid;

namespace Caponeras.App.Views.Conductores;

public partial class ControlAusenciasCadetesView
{
    private System.ComponentModel.IContainer components = null;
    private TableLayoutPanel rootLayout;
    private TableLayoutPanel headerLayout;
    private TableLayoutPanel titleLayout;
    private TableLayoutPanel toolbarLayout;
    private TableLayoutPanel editorLayout;
    private TableLayoutPanel listLayout;
    private TableLayoutPanel listHeaderLayout;
    private TableLayoutPanel cadetePickerLayout;
    private LabelControl lblTitulo;
    private LabelControl lblSubtitulo;
    private LabelControl lblFecha;
    private LabelControl lblFechaAyuda;
    private LabelControl lblCadete;
    private LabelControl lblMotivo;
    private LabelControl lblDetalle;
    private LabelControl lblDetalleAyuda;
    private LabelControl lblLista;
    private DateEdit _fecha;
    private TextEdit _cadete;
    private ComboBoxEdit _motivo;
    private MemoEdit _detalle;
    private GridControl _grid;
    private SimpleButton _nuevo;
    private SimpleButton _guardar;
    private SimpleButton _eliminar;
    private SimpleButton _buscarCadete;
    private LabelControl _estado;

    protected override void Dispose(bool disposing)
    {
        if (disposing)
            components?.Dispose();
        base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
        System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ControlAusenciasCadetesView));
        rootLayout = new TableLayoutPanel();
        headerLayout = new TableLayoutPanel();
        titleLayout = new TableLayoutPanel();
        lblTitulo = new LabelControl();
        lblSubtitulo = new LabelControl();
        toolbarLayout = new TableLayoutPanel();
        lblFecha = new LabelControl();
        _fecha = new DateEdit();
        _nuevo = new SimpleButton();
        _guardar = new SimpleButton();
        _eliminar = new SimpleButton();
        lblFechaAyuda = new LabelControl();
        editorLayout = new TableLayoutPanel();
        lblCadete = new LabelControl();
        cadetePickerLayout = new TableLayoutPanel();
        _cadete = new TextEdit();
        _buscarCadete = new SimpleButton();
        lblMotivo = new LabelControl();
        _motivo = new ComboBoxEdit();
        lblDetalle = new LabelControl();
        _detalle = new MemoEdit();
        lblDetalleAyuda = new LabelControl();
        listLayout = new TableLayoutPanel();
        listHeaderLayout = new TableLayoutPanel();
        lblLista = new LabelControl();
        _estado = new LabelControl();
        _grid = new GridControl();
        gridView1 = new GridView();
        rootLayout.SuspendLayout();
        headerLayout.SuspendLayout();
        titleLayout.SuspendLayout();
        toolbarLayout.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)_fecha.Properties).BeginInit();
        ((System.ComponentModel.ISupportInitialize)_fecha.Properties.CalendarTimeProperties).BeginInit();
        editorLayout.SuspendLayout();
        cadetePickerLayout.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)_cadete.Properties).BeginInit();
        ((System.ComponentModel.ISupportInitialize)_motivo.Properties).BeginInit();
        ((System.ComponentModel.ISupportInitialize)_detalle.Properties).BeginInit();
        listLayout.SuspendLayout();
        listHeaderLayout.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)_grid).BeginInit();
        ((System.ComponentModel.ISupportInitialize)gridView1).BeginInit();
        SuspendLayout();
        // 
        // rootLayout
        // 
        rootLayout.BackColor = Color.FromArgb(245, 247, 250);
        rootLayout.ColumnCount = 1;
        rootLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
        rootLayout.Controls.Add(headerLayout, 0, 0);
        rootLayout.Controls.Add(editorLayout, 0, 1);
        rootLayout.Controls.Add(listLayout, 0, 2);
        rootLayout.Dock = DockStyle.Fill;
        rootLayout.Location = new Point(0, 0);
        rootLayout.Name = "rootLayout";
        rootLayout.Padding = new Padding(15, 16, 15, 16);
        rootLayout.RowCount = 3;
        rootLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 73F));
        rootLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 165F));
        rootLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
        rootLayout.Size = new Size(1108, 713);
        rootLayout.TabIndex = 0;
        // 
        // headerLayout
        // 
        headerLayout.BackColor = Color.White;
        headerLayout.ColumnCount = 2;
        headerLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
        headerLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 576F));
        headerLayout.Controls.Add(titleLayout, 0, 0);
        headerLayout.Controls.Add(toolbarLayout, 1, 0);
        headerLayout.Dock = DockStyle.Fill;
        headerLayout.Location = new Point(18, 19);
        headerLayout.Name = "headerLayout";
        headerLayout.Padding = new Padding(14, 7, 10, 7);
        headerLayout.RowCount = 1;
        headerLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
        headerLayout.Size = new Size(1072, 67);
        headerLayout.TabIndex = 0;
        // 
        // titleLayout
        // 
        titleLayout.BackColor = Color.White;
        titleLayout.ColumnCount = 1;
        titleLayout.ColumnStyles.Add(new ColumnStyle());
        titleLayout.Controls.Add(lblTitulo, 0, 0);
        titleLayout.Controls.Add(lblSubtitulo, 0, 1);
        titleLayout.Dock = DockStyle.Fill;
        titleLayout.Location = new Point(17, 10);
        titleLayout.Name = "titleLayout";
        titleLayout.RowCount = 2;
        titleLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 58F));
        titleLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 42F));
        titleLayout.Size = new Size(466, 47);
        titleLayout.TabIndex = 0;
        // 
        // lblTitulo
        // 
        lblTitulo.Appearance.Font = new Font("Segoe UI Semibold", 17F);
        lblTitulo.Appearance.ForeColor = Color.FromArgb(15, 23, 42);
        lblTitulo.Appearance.Options.UseFont = true;
        lblTitulo.Appearance.Options.UseForeColor = true;
        lblTitulo.Dock = DockStyle.Fill;
        lblTitulo.Location = new Point(3, 3);
        lblTitulo.Name = "lblTitulo";
        lblTitulo.Size = new Size(460, 21);
        lblTitulo.TabIndex = 0;
        lblTitulo.Text = "Control operativo de ausencias";
        // 
        // lblSubtitulo
        // 
        lblSubtitulo.Appearance.Font = new Font("Segoe UI", 9F);
        lblSubtitulo.Appearance.ForeColor = Color.FromArgb(100, 116, 139);
        lblSubtitulo.Appearance.Options.UseFont = true;
        lblSubtitulo.Appearance.Options.UseForeColor = true;
        lblSubtitulo.Dock = DockStyle.Fill;
        lblSubtitulo.Location = new Point(3, 30);
        lblSubtitulo.Name = "lblSubtitulo";
        lblSubtitulo.Size = new Size(460, 14);
        lblSubtitulo.TabIndex = 1;
        lblSubtitulo.Text = "Registre la novedad del cadete y consulte las ausencias por día.";
        // 
        // toolbarLayout
        // 
        toolbarLayout.BackColor = Color.White;
        toolbarLayout.ColumnCount = 6;
        toolbarLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 36F));
        toolbarLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 122F));
        toolbarLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 86F));
        toolbarLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 89F));
        toolbarLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 84F));
        toolbarLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
        toolbarLayout.Controls.Add(lblFecha, 0, 0);
        toolbarLayout.Controls.Add(_fecha, 1, 0);
        toolbarLayout.Controls.Add(_nuevo, 2, 0);
        toolbarLayout.Controls.Add(_guardar, 3, 0);
        toolbarLayout.Controls.Add(_eliminar, 4, 0);
        toolbarLayout.Controls.Add(lblFechaAyuda, 5, 0);
        toolbarLayout.Dock = DockStyle.Fill;
        toolbarLayout.Location = new Point(489, 10);
        toolbarLayout.Name = "toolbarLayout";
        toolbarLayout.RowCount = 1;
        toolbarLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
        toolbarLayout.Size = new Size(570, 47);
        toolbarLayout.TabIndex = 1;
        // 
        // lblFecha
        // 
        lblFecha.Appearance.Font = new Font("Segoe UI Semibold", 9F);
        lblFecha.Appearance.ForeColor = Color.FromArgb(71, 85, 105);
        lblFecha.Appearance.Options.UseFont = true;
        lblFecha.Appearance.Options.UseForeColor = true;
        lblFecha.Dock = DockStyle.Fill;
        lblFecha.Location = new Point(3, 3);
        lblFecha.Name = "lblFecha";
        lblFecha.Size = new Size(30, 41);
        lblFecha.TabIndex = 0;
        lblFecha.Text = "Fecha";
        // 
        // _fecha
        // 
        _fecha.Anchor = AnchorStyles.Left;
        _fecha.EditValue = new DateTime(2026, 10, 10, 0, 0, 0, 0);
        _fecha.Location = new Point(39, 12);
        _fecha.Name = "_fecha";
        _fecha.Properties.Buttons.AddRange(new EditorButton[] { new EditorButton(ButtonPredefines.Combo) });
        _fecha.Properties.CalendarTimeProperties.Buttons.AddRange(new EditorButton[] { new EditorButton(ButtonPredefines.Combo) });
        _fecha.Properties.NullDate = new DateTime(2026, 1, 1, 0, 0, 0, 0);
        _fecha.Size = new Size(116, 22);
        _fecha.TabIndex = 1;
        // 
        // _nuevo
        // 
        _nuevo.Appearance.BackColor = DevExpress.LookAndFeel.DXSkinColors.FillColors.Primary;
        _nuevo.Appearance.Options.UseBackColor = true;
        _nuevo.Dock = DockStyle.Fill;
        _nuevo.Location = new Point(161, 5);
        _nuevo.Margin = new Padding(3, 5, 3, 5);
        _nuevo.Name = "_nuevo";
        _nuevo.Size = new Size(80, 37);
        _nuevo.TabIndex = 2;
        _nuevo.Text = "Nuevo";
        // 
        // _guardar
        // 
        _guardar.Appearance.BackColor = DevExpress.LookAndFeel.DXSkinColors.FillColors.Success;
        _guardar.Appearance.Options.UseBackColor = true;
        _guardar.Dock = DockStyle.Fill;
        _guardar.Location = new Point(247, 5);
        _guardar.Margin = new Padding(3, 5, 3, 5);
        _guardar.Name = "_guardar";
        _guardar.Size = new Size(83, 37);
        _guardar.TabIndex = 3;
        _guardar.Text = "Guardar";
        // 
        // _eliminar
        // 
        _eliminar.Appearance.BackColor = DevExpress.LookAndFeel.DXSkinColors.FillColors.Danger;
        _eliminar.Appearance.Options.UseBackColor = true;
        _eliminar.Dock = DockStyle.Fill;
        _eliminar.Location = new Point(336, 5);
        _eliminar.Margin = new Padding(3, 5, 3, 5);
        _eliminar.Name = "_eliminar";
        _eliminar.Size = new Size(78, 37);
        _eliminar.TabIndex = 4;
        _eliminar.Text = "Eliminar";
        // 
        // lblFechaAyuda
        // 
        lblFechaAyuda.Appearance.Font = new Font("Segoe UI", 7.5F);
        lblFechaAyuda.Appearance.ForeColor = Color.FromArgb(100, 116, 139);
        lblFechaAyuda.Appearance.Options.UseFont = true;
        lblFechaAyuda.Appearance.Options.UseForeColor = true;
        lblFechaAyuda.AutoSizeMode = LabelAutoSizeMode.Vertical;
        lblFechaAyuda.Dock = DockStyle.Fill;
        lblFechaAyuda.Location = new Point(420, 3);
        lblFechaAyuda.Name = "lblFechaAyuda";
        lblFechaAyuda.Size = new Size(147, 41);
        lblFechaAyuda.TabIndex = 5;
        lblFechaAyuda.Text = "La fecha filtra la tabla y se usa al guardar.";
        // 
        // editorLayout
        // 
        editorLayout.BackColor = Color.White;
        editorLayout.ColumnCount = 4;
        editorLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 90F));
        editorLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 48F));
        editorLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 81F));
        editorLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 52F));
        editorLayout.Controls.Add(lblCadete, 0, 0);
        editorLayout.Controls.Add(cadetePickerLayout, 1, 0);
        editorLayout.Controls.Add(lblMotivo, 2, 0);
        editorLayout.Controls.Add(_motivo, 3, 0);
        editorLayout.Controls.Add(lblDetalle, 0, 1);
        editorLayout.Controls.Add(_detalle, 1, 1);
        editorLayout.Controls.Add(lblDetalleAyuda, 1, 3);
        editorLayout.Dock = DockStyle.Fill;
        editorLayout.Location = new Point(18, 92);
        editorLayout.Name = "editorLayout";
        editorLayout.Padding = new Padding(14, 10, 14, 10);
        editorLayout.RowCount = 4;
        editorLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 35F));
        editorLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 31F));
        editorLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 57F));
        editorLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
        editorLayout.Size = new Size(1072, 159);
        editorLayout.TabIndex = 1;
        // 
        // lblCadete
        // 
        lblCadete.Appearance.Font = new Font("Segoe UI Semibold", 9F);
        lblCadete.Appearance.ForeColor = Color.FromArgb(51, 65, 85);
        lblCadete.Appearance.Options.UseFont = true;
        lblCadete.Appearance.Options.UseForeColor = true;
        lblCadete.Dock = DockStyle.Fill;
        lblCadete.Location = new Point(17, 13);
        lblCadete.Name = "lblCadete";
        lblCadete.Size = new Size(84, 29);
        lblCadete.TabIndex = 0;
        lblCadete.Text = "Cadete";
        // 
        // cadetePickerLayout
        // 
        cadetePickerLayout.ColumnCount = 2;
        cadetePickerLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
        cadetePickerLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 108F));
        cadetePickerLayout.Controls.Add(_cadete, 0, 0);
        cadetePickerLayout.Controls.Add(_buscarCadete, 1, 0);
        cadetePickerLayout.Dock = DockStyle.Fill;
        cadetePickerLayout.Location = new Point(107, 13);
        cadetePickerLayout.Name = "cadetePickerLayout";
        cadetePickerLayout.RowCount = 1;
        cadetePickerLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
        cadetePickerLayout.Size = new Size(413, 29);
        cadetePickerLayout.TabIndex = 1;
        // 
        // _cadete
        // 
        _cadete.Dock = DockStyle.Fill;
        _cadete.Location = new Point(3, 3);
        _cadete.Name = "_cadete";
        _cadete.Properties.ReadOnly = true;
        _cadete.Size = new Size(299, 22);
        _cadete.TabIndex = 0;
        // 
        // _buscarCadete
        // 
        _buscarCadete.Dock = DockStyle.Fill;
        _buscarCadete.Location = new Point(308, 3);
        _buscarCadete.Name = "_buscarCadete";
        _buscarCadete.Size = new Size(102, 23);
        _buscarCadete.TabIndex = 1;
        _buscarCadete.Text = "Buscar cadete";
        // 
        // lblMotivo
        // 
        lblMotivo.Appearance.Font = new Font("Segoe UI Semibold", 9F);
        lblMotivo.Appearance.ForeColor = Color.FromArgb(51, 65, 85);
        lblMotivo.Appearance.Options.UseFont = true;
        lblMotivo.Appearance.Options.UseForeColor = true;
        lblMotivo.Dock = DockStyle.Fill;
        lblMotivo.Location = new Point(526, 13);
        lblMotivo.Name = "lblMotivo";
        lblMotivo.Size = new Size(75, 29);
        lblMotivo.TabIndex = 2;
        lblMotivo.Text = "Motivo";
        // 
        // _motivo
        // 
        _motivo.Dock = DockStyle.Fill;
        _motivo.Location = new Point(607, 13);
        _motivo.Name = "_motivo";
        _motivo.Properties.TextEditStyle = TextEditStyles.DisableTextEditor;
        _motivo.Size = new Size(448, 22);
        _motivo.TabIndex = 3;
        // 
        // lblDetalle
        // 
        lblDetalle.Appearance.Font = new Font("Segoe UI Semibold", 9F);
        lblDetalle.Appearance.ForeColor = Color.FromArgb(51, 65, 85);
        lblDetalle.Appearance.Options.UseFont = true;
        lblDetalle.Appearance.Options.UseForeColor = true;
        lblDetalle.Dock = DockStyle.Fill;
        lblDetalle.Location = new Point(17, 48);
        lblDetalle.Name = "lblDetalle";
        lblDetalle.Size = new Size(84, 25);
        lblDetalle.TabIndex = 4;
        lblDetalle.Text = "Detalle";
        // 
        // _detalle
        // 
        editorLayout.SetColumnSpan(_detalle, 3);
        _detalle.Dock = DockStyle.Fill;
        _detalle.Location = new Point(107, 48);
        _detalle.Name = "_detalle";
        editorLayout.SetRowSpan(_detalle, 2);
        _detalle.Size = new Size(948, 82);
        _detalle.TabIndex = 5;
        // 
        // lblDetalleAyuda
        // 
        lblDetalleAyuda.Appearance.Font = new Font("Segoe UI", 8.5F);
        lblDetalleAyuda.Appearance.ForeColor = Color.FromArgb(100, 116, 139);
        lblDetalleAyuda.Appearance.Options.UseFont = true;
        lblDetalleAyuda.Appearance.Options.UseForeColor = true;
        editorLayout.SetColumnSpan(lblDetalleAyuda, 3);
        lblDetalleAyuda.Dock = DockStyle.Fill;
        lblDetalleAyuda.Location = new Point(107, 136);
        lblDetalleAyuda.Name = "lblDetalleAyuda";
        lblDetalleAyuda.Size = new Size(948, 10);
        lblDetalleAyuda.TabIndex = 6;
        lblDetalleAyuda.Text = "Agregue información útil para explicar la novedad operativa.";
        // 
        // listLayout
        // 
        listLayout.BackColor = Color.White;
        listLayout.ColumnCount = 1;
        listLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
        listLayout.Controls.Add(listHeaderLayout, 0, 0);
        listLayout.Controls.Add(_grid, 0, 1);
        listLayout.Dock = DockStyle.Fill;
        listLayout.Location = new Point(18, 257);
        listLayout.Name = "listLayout";
        listLayout.Padding = new Padding(10);
        listLayout.RowCount = 2;
        listLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 33F));
        listLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
        listLayout.Size = new Size(1072, 437);
        listLayout.TabIndex = 2;
        // 
        // listHeaderLayout
        // 
        listHeaderLayout.ColumnCount = 2;
        listHeaderLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
        listHeaderLayout.ColumnStyles.Add(new ColumnStyle());
        listHeaderLayout.Controls.Add(lblLista, 0, 0);
        listHeaderLayout.Controls.Add(_estado, 1, 0);
        listHeaderLayout.Dock = DockStyle.Fill;
        listHeaderLayout.Location = new Point(13, 13);
        listHeaderLayout.Name = "listHeaderLayout";
        listHeaderLayout.RowCount = 1;
        listHeaderLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
        listHeaderLayout.Size = new Size(1046, 27);
        listHeaderLayout.TabIndex = 0;
        // 
        // lblLista
        // 
        lblLista.Appearance.Font = new Font("Segoe UI Semibold", 11F);
        lblLista.Appearance.ForeColor = Color.FromArgb(30, 41, 59);
        lblLista.Appearance.Options.UseFont = true;
        lblLista.Appearance.Options.UseForeColor = true;
        lblLista.Dock = DockStyle.Fill;
        lblLista.Location = new Point(3, 3);
        lblLista.Name = "lblLista";
        lblLista.Size = new Size(983, 21);
        lblLista.TabIndex = 0;
        lblLista.Text = "Ausencias registradas";
        // 
        // _estado
        // 
        _estado.Appearance.ForeColor = Color.FromArgb(100, 116, 139);
        _estado.Appearance.Options.UseForeColor = true;
        _estado.Dock = DockStyle.Fill;
        _estado.Location = new Point(992, 3);
        _estado.Name = "_estado";
        _estado.Size = new Size(51, 21);
        _estado.TabIndex = 1;
        _estado.Text = "0 registros";
        // 
        // _grid
        // 
        _grid.Dock = DockStyle.Fill;
        _grid.Location = new Point(13, 46);
        _grid.MainView = gridView1;
        _grid.Name = "_grid";
        _grid.Size = new Size(1046, 378);
        _grid.TabIndex = 1;
        _grid.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] { gridView1 });
        // 
        // gridView1
        // 
        gridView1.DetailHeight = 303;
        gridView1.GridControl = _grid;
        gridView1.Name = "gridView1";
        gridView1.OptionsEditForm.PopupEditFormWidth = 686;
        // 
        // ControlAusenciasCadetesView
        // 
        AutoScaleDimensions = new SizeF(6F, 13F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(1108, 713);
        Controls.Add(rootLayout);
        IconOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("ControlAusenciasCadetesView.IconOptions.SvgImage");
        Name = "ControlAusenciasCadetesView";
        Text = "Control operativo de ausencias";
        rootLayout.ResumeLayout(false);
        headerLayout.ResumeLayout(false);
        titleLayout.ResumeLayout(false);
        titleLayout.PerformLayout();
        toolbarLayout.ResumeLayout(false);
        toolbarLayout.PerformLayout();
        ((System.ComponentModel.ISupportInitialize)_fecha.Properties.CalendarTimeProperties).EndInit();
        ((System.ComponentModel.ISupportInitialize)_fecha.Properties).EndInit();
        editorLayout.ResumeLayout(false);
        editorLayout.PerformLayout();
        cadetePickerLayout.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)_cadete.Properties).EndInit();
        ((System.ComponentModel.ISupportInitialize)_motivo.Properties).EndInit();
        ((System.ComponentModel.ISupportInitialize)_detalle.Properties).EndInit();
        listLayout.ResumeLayout(false);
        listHeaderLayout.ResumeLayout(false);
        listHeaderLayout.PerformLayout();
        ((System.ComponentModel.ISupportInitialize)_grid).EndInit();
        ((System.ComponentModel.ISupportInitialize)gridView1).EndInit();
        ResumeLayout(false);
    }

    private GridView gridView1;
}
