namespace Caponeras.App.Views.Conductores
{
    partial class ReportesCadetesView
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ReportesCadetesView));
            groupControl1 = new Panel();
            radioGroup = new DevExpress.XtraEditors.RadioGroup();
            groupControl2 = new Panel();
            btnVerReporte = new DevExpress.XtraEditors.SimpleButton();
            txtFechaHasta = new DevExpress.XtraEditors.DateEdit();
            txtFechaDesde = new DevExpress.XtraEditors.DateEdit();
            lblfechaHasta = new DevExpress.XtraEditors.LabelControl();
            labelControl1 = new DevExpress.XtraEditors.LabelControl();
            lblTituloReporte = new DevExpress.XtraEditors.LabelControl();
            lblDescripcionReporte = new DevExpress.XtraEditors.LabelControl();
            lblTituloSidebar = new DevExpress.XtraEditors.LabelControl();
            lblDescripcionSidebar = new DevExpress.XtraEditors.LabelControl();
            groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)radioGroup.Properties).BeginInit();
            groupControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)txtFechaHasta.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)txtFechaHasta.Properties.CalendarTimeProperties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)txtFechaDesde.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)txtFechaDesde.Properties.CalendarTimeProperties).BeginInit();
            SuspendLayout();
            // 
            // groupControl1
            // 
            groupControl1.Controls.Add(radioGroup);
            groupControl1.Controls.Add(lblDescripcionSidebar);
            groupControl1.Controls.Add(lblTituloSidebar);
            groupControl1.BackColor = Color.FromArgb(18, 59, 69);
            groupControl1.Dock = DockStyle.Left;
            groupControl1.Location = new Point(0, 0);
            groupControl1.Name = "groupControl1";
            groupControl1.Size = new Size(300, 600);
            groupControl1.TabIndex = 0;
            // 
            // radioGroup
            // 
            radioGroup.Location = new Point(16, 125);
            radioGroup.Name = "radioGroup";
            radioGroup.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.RadioGroupItem[] { new DevExpress.XtraEditors.Controls.RadioGroupItem(0, "Vehículos asignados"), new DevExpress.XtraEditors.Controls.RadioGroupItem(1, "Consolidado de cuotas"), new DevExpress.XtraEditors.Controls.RadioGroupItem(2, "Recaudación diaria"), new DevExpress.XtraEditors.Controls.RadioGroupItem(3, "Ausencias de cadetes"), new DevExpress.XtraEditors.Controls.RadioGroupItem(4, "Cadetes y licencias") });
            radioGroup.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            radioGroup.Properties.Columns = 1;
            radioGroup.Properties.ItemVertAlignment = DevExpress.XtraEditors.RadioItemVertAlignment.Top;
            radioGroup.Properties.Appearance.BackColor = Color.FromArgb(18, 59, 69);
            radioGroup.Properties.Appearance.ForeColor = Color.White;
            radioGroup.Properties.Appearance.Options.UseBackColor = true;
            radioGroup.Properties.Appearance.Options.UseForeColor = true;
            radioGroup.BackColor = Color.FromArgb(18, 59, 69);
            radioGroup.Location = new Point(16, 125);
            radioGroup.Size = new Size(270, 285);
            radioGroup.TabIndex = 0;
            // 
            // lblTituloSidebar
            // 
            lblTituloSidebar.Appearance.Font = new Font("Segoe UI", 17F, FontStyle.Bold);
            lblTituloSidebar.Appearance.ForeColor = Color.White;
            lblTituloSidebar.Appearance.Options.UseFont = true;
            lblTituloSidebar.Appearance.Options.UseForeColor = true;
            lblTituloSidebar.Location = new Point(24, 31);
            lblTituloSidebar.Name = "lblTituloSidebar";
            lblTituloSidebar.Size = new Size(100, 31);
            lblTituloSidebar.TabIndex = 7;
            lblTituloSidebar.Text = "Cadetes";
            // 
            // lblDescripcionSidebar
            // 
            lblDescripcionSidebar.Appearance.Font = new Font("Segoe UI", 9F);
            lblDescripcionSidebar.Appearance.ForeColor = Color.FromArgb(196, 218, 219);
            lblDescripcionSidebar.Appearance.Options.UseFont = true;
            lblDescripcionSidebar.Appearance.Options.UseForeColor = true;
            lblDescripcionSidebar.Appearance.Options.UseTextOptions = true;
            lblDescripcionSidebar.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            lblDescripcionSidebar.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            lblDescripcionSidebar.Location = new Point(26, 72);
            lblDescripcionSidebar.Name = "lblDescripcionSidebar";
            lblDescripcionSidebar.Size = new Size(246, 42);
            lblDescripcionSidebar.TabIndex = 8;
            lblDescripcionSidebar.Text = "Selecciona el reporte de cadetes que necesitas consultar.";
            // 
            // groupControl2
            // 
            groupControl2.Controls.Add(btnVerReporte);
            groupControl2.Controls.Add(txtFechaHasta);
            groupControl2.Controls.Add(txtFechaDesde);
            groupControl2.Controls.Add(lblfechaHasta);
            groupControl2.Controls.Add(labelControl1);
            groupControl2.BackColor = Color.White;
            groupControl2.Dock = DockStyle.Fill;
            groupControl2.Location = new Point(300, 0);
            groupControl2.Name = "groupControl2";
            groupControl2.Size = new Size(480, 600);
            groupControl2.TabIndex = 1;
            groupControl2.Controls.Add(lblDescripcionReporte);
            groupControl2.Controls.Add(lblTituloReporte);
            // 
            // btnVerReporte
            // 
            btnVerReporte.Appearance.BackColor = DevExpress.LookAndFeel.DXSkinColors.FillColors.Success;
            btnVerReporte.Appearance.ForeColor = Color.White;
            btnVerReporte.Appearance.Options.UseBackColor = true;
            btnVerReporte.Appearance.Options.UseForeColor = true;
            btnVerReporte.ImageOptions.AllowGlyphSkinning = DevExpress.Utils.DefaultBoolean.True;
            btnVerReporte.ImageOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("btnVerReporte.ImageOptions.SvgImage");
            btnVerReporte.Location = new Point(350, 182);
            btnVerReporte.Name = "btnVerReporte";
            btnVerReporte.Size = new Size(120, 40);
            btnVerReporte.TabIndex = 4;
            btnVerReporte.Text = "Ver Reporte";
            btnVerReporte.Click += btnVerReporte_Click;
            // 
            // txtFechaHasta
            // 
            txtFechaHasta.EditValue = null;
            txtFechaHasta.Anchor = AnchorStyles.Top | AnchorStyles.Left;
            txtFechaHasta.Location = new Point(200, 182);
            txtFechaHasta.Name = "txtFechaHasta";
            txtFechaHasta.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo) });
            txtFechaHasta.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo) });
            txtFechaHasta.Size = new Size(135, 28);
            txtFechaHasta.TabIndex = 3;
            // 
            // txtFechaDesde
            // 
            txtFechaDesde.EditValue = null;
            txtFechaDesde.Location = new Point(35, 182);
            txtFechaDesde.Name = "txtFechaDesde";
            txtFechaDesde.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo) });
            txtFechaDesde.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo) });
            txtFechaDesde.Size = new Size(150, 28);
            txtFechaDesde.TabIndex = 2;
            // 
            // lblfechaHasta
            // 
            lblfechaHasta.Location = new Point(200, 158);
            lblfechaHasta.Name = "lblfechaHasta";
            lblfechaHasta.Size = new Size(32, 13);
            lblfechaHasta.TabIndex = 1;
            lblfechaHasta.Text = "Hasta:";
            // 
            // labelControl1
            // 
            labelControl1.Location = new Point(35, 158);
            labelControl1.Name = "labelControl1";
            labelControl1.Size = new Size(34, 13);
            labelControl1.TabIndex = 0;
            labelControl1.Text = "Desde:";
            // 
            // lblTituloReporte
            // 
            lblTituloReporte.Appearance.Font = new Font("Segoe UI", 17F, FontStyle.Bold);
            lblTituloReporte.Appearance.ForeColor = Color.FromArgb(35, 47, 52);
            lblTituloReporte.Appearance.Options.UseFont = true;
            lblTituloReporte.Appearance.Options.UseForeColor = true;
            lblTituloReporte.Location = new Point(35, 32);
            lblTituloReporte.Name = "lblTituloReporte";
            lblTituloReporte.Size = new Size(246, 31);
            lblTituloReporte.TabIndex = 5;
            lblTituloReporte.Text = "Parámetros del reporte";
            // 
            // lblDescripcionReporte
            // 
            lblDescripcionReporte.Appearance.Font = new Font("Segoe UI", 9.5F);
            lblDescripcionReporte.Appearance.ForeColor = Color.FromArgb(112, 124, 129);
            lblDescripcionReporte.Appearance.Options.UseFont = true;
            lblDescripcionReporte.Appearance.Options.UseForeColor = true;
            lblDescripcionReporte.Location = new Point(38, 78);
            lblDescripcionReporte.Name = "lblDescripcionReporte";
            lblDescripcionReporte.Size = new Size(420, 17);
            lblDescripcionReporte.TabIndex = 6;
            lblDescripcionReporte.Text = "Define las fechas del reporte seleccionado.";
            // 
            // ReportesCadetesView
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(900, 600);
            Controls.Add(groupControl2);
            Controls.Add(groupControl1);
            IconOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("ReportesCadetesView.IconOptions.SvgImage");
            Name = "ReportesCadetesView";
            Text = "Reporte de Cadetes";
            groupControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)radioGroup.Properties).EndInit();
            groupControl2.ResumeLayout(false);
            groupControl2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)txtFechaHasta.Properties.CalendarTimeProperties).EndInit();
            ((System.ComponentModel.ISupportInitialize)txtFechaHasta.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)txtFechaDesde.Properties.CalendarTimeProperties).EndInit();
            ((System.ComponentModel.ISupportInitialize)txtFechaDesde.Properties).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel groupControl1;
        private DevExpress.XtraEditors.RadioGroup radioGroup;
        private Panel groupControl2;
        private DevExpress.XtraEditors.DateEdit txtFechaHasta;
        private DevExpress.XtraEditors.DateEdit txtFechaDesde;
        private DevExpress.XtraEditors.LabelControl lblfechaHasta;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.SimpleButton btnVerReporte;
        private DevExpress.XtraEditors.LabelControl lblTituloReporte;
        private DevExpress.XtraEditors.LabelControl lblDescripcionReporte;
        private DevExpress.XtraEditors.LabelControl lblTituloSidebar;
        private DevExpress.XtraEditors.LabelControl lblDescripcionSidebar;
    }
}
