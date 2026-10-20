namespace Caponeras.App.Views.Inventario
{
    partial class ReportesProductosInventarioView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ReportesProductosInventarioView));
            groupControl1 = new Panel();
            radioGroupOpciones = new DevExpress.XtraEditors.RadioGroup();
            groupControl2 = new Panel();
            btnVerReporte = new DevExpress.XtraEditors.SimpleButton();
            lblTituloReporte = new DevExpress.XtraEditors.LabelControl();
            lblDescripcionReporte = new DevExpress.XtraEditors.LabelControl();
            lblTituloSidebar = new DevExpress.XtraEditors.LabelControl();
            lblDescripcionSidebar = new DevExpress.XtraEditors.LabelControl();
            groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)radioGroupOpciones.Properties).BeginInit();
            groupControl2.SuspendLayout();
            SuspendLayout();
            // 
            // groupControl1
            // 
            groupControl1.Controls.Add(radioGroupOpciones);
            groupControl1.Controls.Add(lblDescripcionSidebar);
            groupControl1.Controls.Add(lblTituloSidebar);
            groupControl1.BackColor = Color.FromArgb(18, 59, 69);
            groupControl1.Dock = DockStyle.Left;
            groupControl1.Location = new Point(0, 0);
            groupControl1.Name = "groupControl1";
            groupControl1.Size = new Size(300, 600);
            groupControl1.TabIndex = 0;
            // 
            // radioGroupOpciones
            // 
            radioGroupOpciones.Location = new Point(16, 125);
            radioGroupOpciones.Name = "radioGroupOpciones";
            radioGroupOpciones.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.RadioGroupItem[] { new DevExpress.XtraEditors.Controls.RadioGroupItem(0, "Todos los productos") });
            radioGroupOpciones.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            radioGroupOpciones.Properties.Columns = 1;
            radioGroupOpciones.Properties.ItemVertAlignment = DevExpress.XtraEditors.RadioItemVertAlignment.Top;
            radioGroupOpciones.Properties.Appearance.BackColor = Color.FromArgb(18, 59, 69);
            radioGroupOpciones.Properties.Appearance.ForeColor = Color.White;
            radioGroupOpciones.Properties.Appearance.Options.UseBackColor = true;
            radioGroupOpciones.Properties.Appearance.Options.UseForeColor = true;
            radioGroupOpciones.BackColor = Color.FromArgb(18, 59, 69);
            radioGroupOpciones.Size = new Size(270, 60);
            radioGroupOpciones.TabIndex = 0;
            // 
            // lblTituloSidebar
            // 
            lblTituloSidebar.Appearance.Font = new Font("Segoe UI", 17F, FontStyle.Bold);
            lblTituloSidebar.Appearance.ForeColor = Color.White;
            lblTituloSidebar.Appearance.Options.UseFont = true;
            lblTituloSidebar.Appearance.Options.UseForeColor = true;
            lblTituloSidebar.Location = new Point(24, 31);
            lblTituloSidebar.Name = "lblTituloSidebar";
            lblTituloSidebar.Size = new Size(110, 31);
            lblTituloSidebar.TabIndex = 1;
            lblTituloSidebar.Text = "Inventario";
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
            lblDescripcionSidebar.TabIndex = 2;
            lblDescripcionSidebar.Text = "Selecciona el informe de inventario.";
            // 
            // groupControl2
            // 
            groupControl2.Controls.Add(btnVerReporte);
            groupControl2.BackColor = Color.White;
            groupControl2.Dock = DockStyle.Fill;
            groupControl2.Location = new Point(300, 0);
            groupControl2.Name = "groupControl2";
            groupControl2.Size = new Size(600, 600);
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
            btnVerReporte.ImageOptions.SvgImageSize = new Size(28, 28);
            btnVerReporte.Location = new Point(350, 150);
            btnVerReporte.Name = "btnVerReporte";
            btnVerReporte.Size = new Size(120, 40);
            btnVerReporte.TabIndex = 0;
            btnVerReporte.Text = "Ver Reporte";
            btnVerReporte.Click += btnVerReporte_Click;
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
            lblTituloReporte.TabIndex = 1;
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
            lblDescripcionReporte.TabIndex = 2;
            lblDescripcionReporte.Text = "Genera un listado de todos los productos del inventario.";
            // 
            // ReportesProductosInventarioView
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(900, 600);
            Controls.Add(groupControl2);
            Controls.Add(groupControl1);
            IconOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("ReportesProductosInventarioView.IconOptions.SvgImage");
            Name = "ReportesProductosInventarioView";
            Text = "Reportes";
            groupControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)radioGroupOpciones.Properties).EndInit();
            groupControl2.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel groupControl1;
        private DevExpress.XtraEditors.RadioGroup radioGroupOpciones;
        private Panel groupControl2;
        private DevExpress.XtraEditors.SimpleButton btnVerReporte;
        private DevExpress.XtraEditors.LabelControl lblTituloReporte;
        private DevExpress.XtraEditors.LabelControl lblDescripcionReporte;
        private DevExpress.XtraEditors.LabelControl lblTituloSidebar;
        private DevExpress.XtraEditors.LabelControl lblDescripcionSidebar;
    }
}
