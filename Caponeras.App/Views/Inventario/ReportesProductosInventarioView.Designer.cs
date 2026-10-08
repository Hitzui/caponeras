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
            groupControl1 = new DevExpress.XtraEditors.GroupControl();
            radioGroupOpciones = new DevExpress.XtraEditors.RadioGroup();
            groupControl2 = new DevExpress.XtraEditors.GroupControl();
            btnVerReporte = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)groupControl1).BeginInit();
            groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)radioGroupOpciones.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)groupControl2).BeginInit();
            groupControl2.SuspendLayout();
            SuspendLayout();
            // 
            // groupControl1
            // 
            groupControl1.Controls.Add(radioGroupOpciones);
            groupControl1.Location = new Point(12, 12);
            groupControl1.Name = "groupControl1";
            groupControl1.Size = new Size(321, 228);
            groupControl1.TabIndex = 0;
            groupControl1.Text = "Opciones";
            // 
            // radioGroupOpciones
            // 
            radioGroupOpciones.Dock = DockStyle.Fill;
            radioGroupOpciones.Location = new Point(2, 22);
            radioGroupOpciones.Name = "radioGroupOpciones";
            radioGroupOpciones.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.RadioGroupItem[] { new DevExpress.XtraEditors.Controls.RadioGroupItem(0, "Todos los productos") });
            radioGroupOpciones.Properties.ItemVertAlignment = DevExpress.XtraEditors.RadioItemVertAlignment.Top;
            radioGroupOpciones.Size = new Size(317, 204);
            radioGroupOpciones.TabIndex = 0;
            // 
            // groupControl2
            // 
            groupControl2.Controls.Add(btnVerReporte);
            groupControl2.Location = new Point(339, 12);
            groupControl2.Name = "groupControl2";
            groupControl2.Size = new Size(320, 226);
            groupControl2.TabIndex = 1;
            groupControl2.Text = "Filtrar";
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
            btnVerReporte.Location = new Point(186, 191);
            btnVerReporte.Name = "btnVerReporte";
            btnVerReporte.Size = new Size(129, 30);
            btnVerReporte.TabIndex = 0;
            btnVerReporte.Text = "Ver Reporte";
            btnVerReporte.Click += btnVerReporte_Click;
            // 
            // ReportesProductosInventarioView
            // 
            AutoScaleDimensions = new SizeF(6F, 13F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(847, 392);
            Controls.Add(groupControl2);
            Controls.Add(groupControl1);
            IconOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("ReportesProductosInventarioView.IconOptions.SvgImage");
            Name = "ReportesProductosInventarioView";
            Text = "Reportes";
            ((System.ComponentModel.ISupportInitialize)groupControl1).EndInit();
            groupControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)radioGroupOpciones.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)groupControl2).EndInit();
            groupControl2.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.RadioGroup radioGroupOpciones;
        private DevExpress.XtraEditors.GroupControl groupControl2;
        private DevExpress.XtraEditors.SimpleButton btnVerReporte;
    }
}