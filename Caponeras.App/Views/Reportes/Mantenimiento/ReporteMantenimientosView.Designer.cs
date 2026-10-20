using DevExpress.XtraEditors;

namespace Caponeras.App.Views.Reportes;

partial class ReporteMantenimientosView
{
    private DateEdit _fechaDesde = null!;
    private DateEdit _fechaHasta = null!;
    private RadioGroup _radioReporte = null!;
    private LabelControl _subtitle = null!;
    private Panel _panelSidebar = null!;

    private void InitializeComponent()
    {
        System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ReporteMantenimientosView));
        titleSidebar = new LabelControl();
        descriptionSidebar = new LabelControl();
        titleContent = new LabelControl();
        datesLayout = new TableLayoutPanel();
        labelDesde = new LabelControl();
        labelHasta = new LabelControl();
        _fechaDesde = new DateEdit();
        _fechaHasta = new DateEdit();
        _panelSidebar = new Panel();
        _radioReporte = new RadioGroup();
        panelContent = new Panel();
        _btnGenerar = new SimpleButton();
        _subtitle = new LabelControl();
        datesLayout.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)_fechaDesde.Properties).BeginInit();
        ((System.ComponentModel.ISupportInitialize)_fechaDesde.Properties.CalendarTimeProperties).BeginInit();
        ((System.ComponentModel.ISupportInitialize)_fechaHasta.Properties).BeginInit();
        ((System.ComponentModel.ISupportInitialize)_fechaHasta.Properties.CalendarTimeProperties).BeginInit();
        _panelSidebar.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)_radioReporte.Properties).BeginInit();
        panelContent.SuspendLayout();
        SuspendLayout();
        // 
        // titleSidebar
        // 
        titleSidebar.Appearance.Font = new Font("Segoe UI", 17F, FontStyle.Bold);
        titleSidebar.Appearance.ForeColor = Color.White;
        titleSidebar.Appearance.Options.UseFont = true;
        titleSidebar.Appearance.Options.UseForeColor = true;
        titleSidebar.Location = new Point(21, 26);
        titleSidebar.Name = "titleSidebar";
        titleSidebar.Size = new Size(167, 31);
        titleSidebar.TabIndex = 3;
        titleSidebar.Text = "Mantenimiento";
        // 
        // descriptionSidebar
        // 
        descriptionSidebar.Appearance.Font = new Font("Segoe UI", 9F);
        descriptionSidebar.Appearance.ForeColor = Color.FromArgb(196, 218, 219);
        descriptionSidebar.Appearance.Options.UseFont = true;
        descriptionSidebar.Appearance.Options.UseForeColor = true;
        descriptionSidebar.Appearance.Options.UseTextOptions = true;
        descriptionSidebar.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
        descriptionSidebar.AutoSizeMode = LabelAutoSizeMode.None;
        descriptionSidebar.Location = new Point(22, 62);
        descriptionSidebar.Name = "descriptionSidebar";
        descriptionSidebar.Size = new Size(211, 36);
        descriptionSidebar.TabIndex = 2;
        descriptionSidebar.Text = "Selecciona el reporte que necesitas consultar.";
        // 
        // titleContent
        // 
        titleContent.Appearance.Font = new Font("Segoe UI", 17F, FontStyle.Bold);
        titleContent.Appearance.ForeColor = Color.FromArgb(35, 47, 52);
        titleContent.Appearance.Options.UseFont = true;
        titleContent.Appearance.Options.UseForeColor = true;
        titleContent.Location = new Point(36, 33);
        titleContent.Name = "titleContent";
        titleContent.Size = new Size(246, 31);
        titleContent.TabIndex = 4;
        titleContent.Text = "Parámetros del reporte";
        // 
        // datesLayout
        // 
        datesLayout.ColumnCount = 2;
        datesLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 41F));
        datesLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 41F));
        datesLayout.Controls.Add(labelDesde, 0, 0);
        datesLayout.Controls.Add(labelHasta, 1, 0);
        datesLayout.Controls.Add(_fechaDesde, 0, 1);
        datesLayout.Controls.Add(_fechaHasta, 1, 1);
        datesLayout.Location = new Point(6, 114);
        datesLayout.Name = "datesLayout";
        datesLayout.RowCount = 2;
        datesLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 24F));
        datesLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 40F));
        datesLayout.Size = new Size(496, 64);
        datesLayout.TabIndex = 2;
        // 
        // labelDesde
        // 
        labelDesde.Appearance.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
        labelDesde.Appearance.ForeColor = Color.FromArgb(55, 66, 71);
        labelDesde.Appearance.Options.UseFont = true;
        labelDesde.Appearance.Options.UseForeColor = true;
        labelDesde.Dock = DockStyle.Fill;
        labelDesde.Location = new Point(3, 3);
        labelDesde.Name = "labelDesde";
        labelDesde.Size = new Size(242, 18);
        labelDesde.TabIndex = 0;
        labelDesde.Text = "Desde";
        // 
        // labelHasta
        // 
        labelHasta.Appearance.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
        labelHasta.Appearance.ForeColor = Color.FromArgb(55, 66, 71);
        labelHasta.Appearance.Options.UseFont = true;
        labelHasta.Appearance.Options.UseForeColor = true;
        labelHasta.Dock = DockStyle.Fill;
        labelHasta.Location = new Point(251, 3);
        labelHasta.Name = "labelHasta";
        labelHasta.Size = new Size(242, 18);
        labelHasta.TabIndex = 1;
        labelHasta.Text = "Hasta";
        // 
        // _fechaDesde
        // 
        _fechaDesde.Dock = DockStyle.Fill;
        _fechaDesde.EditValue = new DateTime(2026, 10, 10, 0, 0, 0, 0);
        _fechaDesde.Location = new Point(3, 27);
        _fechaDesde.Name = "_fechaDesde";
        _fechaDesde.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo) });
        _fechaDesde.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo) });
        _fechaDesde.Properties.Mask.EditMask = "dd/MM/yyyy";
        _fechaDesde.Size = new Size(242, 22);
        _fechaDesde.TabIndex = 2;
        // 
        // _fechaHasta
        // 
        _fechaHasta.Dock = DockStyle.Fill;
        _fechaHasta.EditValue = new DateTime(2026, 10, 10, 0, 0, 0, 0);
        _fechaHasta.Location = new Point(251, 27);
        _fechaHasta.Name = "_fechaHasta";
        _fechaHasta.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo) });
        _fechaHasta.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo) });
        _fechaHasta.Properties.Mask.EditMask = "dd/MM/yyyy";
        _fechaHasta.Size = new Size(242, 22);
        _fechaHasta.TabIndex = 3;
        // 
        // _panelSidebar
        // 
        _panelSidebar.BackColor = Color.FromArgb(18, 59, 69);
        _panelSidebar.Controls.Add(_radioReporte);
        _panelSidebar.Controls.Add(descriptionSidebar);
        _panelSidebar.Controls.Add(titleSidebar);
        _panelSidebar.Dock = DockStyle.Left;
        _panelSidebar.Location = new Point(0, 0);
        _panelSidebar.Name = "_panelSidebar";
        _panelSidebar.Size = new Size(257, 524);
        _panelSidebar.TabIndex = 0;
        // 
        // _radioReporte
        // 
        _radioReporte.EditValue = 0;
        _radioReporte.Location = new Point(14, 115);
        _radioReporte.Name = "_radioReporte";
        _radioReporte.Properties.Appearance.BackColor = Color.FromArgb(18, 59, 69);
        _radioReporte.Properties.Appearance.Font = new Font("Segoe UI", 9.5F);
        _radioReporte.Properties.Appearance.ForeColor = Color.White;
        _radioReporte.Properties.Appearance.Options.UseBackColor = true;
        _radioReporte.Properties.Appearance.Options.UseFont = true;
        _radioReporte.Properties.Appearance.Options.UseForeColor = true;
        _radioReporte.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
        _radioReporte.Properties.Columns = 1;
        _radioReporte.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.RadioGroupItem[] { new DevExpress.XtraEditors.Controls.RadioGroupItem(0, "Mantenimientos realizados"), new DevExpress.XtraEditors.Controls.RadioGroupItem(1, "Mano de obra pagada"), new DevExpress.XtraEditors.Controls.RadioGroupItem(2, "Costo de repuestos"), new DevExpress.XtraEditors.Controls.RadioGroupItem(3, "Estado / proceso actual") });
        _radioReporte.Size = new Size(231, 180);
        _radioReporte.TabIndex = 1;
        // 
        // panelContent
        // 
        panelContent.BackColor = Color.White;
        panelContent.Controls.Add(_btnGenerar);
        panelContent.Controls.Add(datesLayout);
        panelContent.Controls.Add(_subtitle);
        panelContent.Controls.Add(titleContent);
        panelContent.Dock = DockStyle.Fill;
        panelContent.Location = new Point(257, 0);
        panelContent.Name = "panelContent";
        panelContent.Size = new Size(514, 524);
        panelContent.TabIndex = 1;
        // 
        // _btnGenerar
        // 
        _btnGenerar.Appearance.BackColor = Color.FromArgb(14, 145, 125);
        _btnGenerar.Appearance.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
        _btnGenerar.Appearance.ForeColor = Color.White;
        _btnGenerar.Appearance.Options.UseBackColor = true;
        _btnGenerar.Appearance.Options.UseFont = true;
        _btnGenerar.Appearance.Options.UseForeColor = true;
        _btnGenerar.AppearanceHovered.BackColor = Color.FromArgb(11, 121, 105);
        _btnGenerar.AppearanceHovered.Options.UseBackColor = true;
        _btnGenerar.Location = new Point(347, 181);
        _btnGenerar.Margin = new Padding(7, 0, 0, 0);
        _btnGenerar.Name = "_btnGenerar";
        _btnGenerar.Size = new Size(155, 35);
        _btnGenerar.TabIndex = 5;
        _btnGenerar.Text = "Ver reporte";
        // 
        // _subtitle
        // 
        _subtitle.Appearance.Font = new Font("Segoe UI", 9.5F);
        _subtitle.Appearance.ForeColor = Color.FromArgb(112, 124, 129);
        _subtitle.Appearance.Options.UseFont = true;
        _subtitle.Appearance.Options.UseForeColor = true;
        _subtitle.AutoSizeMode = LabelAutoSizeMode.None;
        _subtitle.Location = new Point(38, 69);
        _subtitle.Name = "_subtitle";
        _subtitle.Size = new Size(489, 31);
        _subtitle.TabIndex = 3;
        _subtitle.Text = "Rango de fecha de finalización de los mantenimientos.";
        // 
        // ReporteMantenimientosView
        // 
        AutoScaleDimensions = new SizeF(6F, 13F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(771, 524);
        Controls.Add(panelContent);
        Controls.Add(_panelSidebar);
        IconOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("ReporteMantenimientosView.IconOptions.SvgImage");
        Name = "ReporteMantenimientosView";
        Text = "Reportes de mantenimiento";
        datesLayout.ResumeLayout(false);
        datesLayout.PerformLayout();
        ((System.ComponentModel.ISupportInitialize)_fechaDesde.Properties.CalendarTimeProperties).EndInit();
        ((System.ComponentModel.ISupportInitialize)_fechaDesde.Properties).EndInit();
        ((System.ComponentModel.ISupportInitialize)_fechaHasta.Properties.CalendarTimeProperties).EndInit();
        ((System.ComponentModel.ISupportInitialize)_fechaHasta.Properties).EndInit();
        _panelSidebar.ResumeLayout(false);
        _panelSidebar.PerformLayout();
        ((System.ComponentModel.ISupportInitialize)_radioReporte.Properties).EndInit();
        panelContent.ResumeLayout(false);
        panelContent.PerformLayout();
        ResumeLayout(false);
    }

    private LabelControl titleSidebar;
    private LabelControl descriptionSidebar;
    private LabelControl titleContent;
    private TableLayoutPanel datesLayout;
    private LabelControl labelDesde;
    private LabelControl labelHasta;
    private Panel panelContent;
    private SimpleButton _btnGenerar;
}
