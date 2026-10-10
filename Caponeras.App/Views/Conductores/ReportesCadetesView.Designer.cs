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
            groupControl1 = new DevExpress.XtraEditors.GroupControl();
            radioGroup = new DevExpress.XtraEditors.RadioGroup();
            groupControl2 = new DevExpress.XtraEditors.GroupControl();
            btnVerReporte = new DevExpress.XtraEditors.SimpleButton();
            txtFechaHasta = new DevExpress.XtraEditors.DateEdit();
            txtFechaDesde = new DevExpress.XtraEditors.DateEdit();
            lblfechaHasta = new DevExpress.XtraEditors.LabelControl();
            labelControl1 = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)groupControl1).BeginInit();
            groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)radioGroup.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)groupControl2).BeginInit();
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
            groupControl1.Location = new Point(12, 12);
            groupControl1.Name = "groupControl1";
            groupControl1.Size = new Size(318, 272);
            groupControl1.TabIndex = 0;
            groupControl1.Text = "Seleccionar Opción";
            // 
            // radioGroup
            // 
            radioGroup.Location = new Point(5, 24);
            radioGroup.Name = "radioGroup";
            radioGroup.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.RadioGroupItem[] { new DevExpress.XtraEditors.Controls.RadioGroupItem(0, "Vehículos asignados (rango)"), new DevExpress.XtraEditors.Controls.RadioGroupItem(1, "Consolidado cuotas, cadetes y turnos (rango)"), new DevExpress.XtraEditors.Controls.RadioGroupItem(2, "Resumen diario de recaudación"), new DevExpress.XtraEditors.Controls.RadioGroupItem(3, "Ausencias de cadetes (rango)"), new DevExpress.XtraEditors.Controls.RadioGroupItem(4, "Cadetes y licencias") });
            radioGroup.Properties.ItemVertAlignment = DevExpress.XtraEditors.RadioItemVertAlignment.Top;
            radioGroup.Size = new Size(308, 243);
            radioGroup.TabIndex = 0;
            // 
            // groupControl2
            // 
            groupControl2.Controls.Add(btnVerReporte);
            groupControl2.Controls.Add(txtFechaHasta);
            groupControl2.Controls.Add(txtFechaDesde);
            groupControl2.Controls.Add(lblfechaHasta);
            groupControl2.Controls.Add(labelControl1);
            groupControl2.Location = new Point(336, 12);
            groupControl2.Name = "groupControl2";
            groupControl2.Size = new Size(376, 272);
            groupControl2.TabIndex = 1;
            groupControl2.Text = "Rango de Fechas";
            // 
            // btnVerReporte
            // 
            btnVerReporte.Appearance.BackColor = DevExpress.LookAndFeel.DXSkinColors.FillColors.Success;
            btnVerReporte.Appearance.ForeColor = Color.White;
            btnVerReporte.Appearance.Options.UseBackColor = true;
            btnVerReporte.Appearance.Options.UseForeColor = true;
            btnVerReporte.ImageOptions.AllowGlyphSkinning = DevExpress.Utils.DefaultBoolean.True;
            btnVerReporte.ImageOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("btnVerReporte.ImageOptions.SvgImage");
            btnVerReporte.Location = new Point(246, 233);
            btnVerReporte.Name = "btnVerReporte";
            btnVerReporte.Size = new Size(125, 34);
            btnVerReporte.TabIndex = 4;
            btnVerReporte.Text = "Ver Reporte";
            btnVerReporte.Click += btnVerReporte_Click;
            // 
            // txtFechaHasta
            // 
            txtFechaHasta.EditValue = null;
            txtFechaHasta.Location = new Point(35, 117);
            txtFechaHasta.Name = "txtFechaHasta";
            txtFechaHasta.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo) });
            txtFechaHasta.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo) });
            txtFechaHasta.Size = new Size(147, 20);
            txtFechaHasta.TabIndex = 3;
            // 
            // txtFechaDesde
            // 
            txtFechaDesde.EditValue = null;
            txtFechaDesde.Location = new Point(35, 58);
            txtFechaDesde.Name = "txtFechaDesde";
            txtFechaDesde.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo) });
            txtFechaDesde.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo) });
            txtFechaDesde.Size = new Size(147, 20);
            txtFechaDesde.TabIndex = 2;
            // 
            // lblfechaHasta
            // 
            lblfechaHasta.Location = new Point(35, 98);
            lblfechaHasta.Name = "lblfechaHasta";
            lblfechaHasta.Size = new Size(32, 13);
            lblfechaHasta.TabIndex = 1;
            lblfechaHasta.Text = "Hasta:";
            // 
            // labelControl1
            // 
            labelControl1.Location = new Point(35, 39);
            labelControl1.Name = "labelControl1";
            labelControl1.Size = new Size(34, 13);
            labelControl1.TabIndex = 0;
            labelControl1.Text = "Desde:";
            // 
            // ReportesCadetesView
            // 
            AutoScaleDimensions = new SizeF(6F, 13F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(780, 434);
            Controls.Add(groupControl2);
            Controls.Add(groupControl1);
            IconOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("ReportesCadetesView.IconOptions.SvgImage");
            Name = "ReportesCadetesView";
            Text = "Reporte de Cadetes";
            ((System.ComponentModel.ISupportInitialize)groupControl1).EndInit();
            groupControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)radioGroup.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)groupControl2).EndInit();
            groupControl2.ResumeLayout(false);
            groupControl2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)txtFechaHasta.Properties.CalendarTimeProperties).EndInit();
            ((System.ComponentModel.ISupportInitialize)txtFechaHasta.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)txtFechaDesde.Properties.CalendarTimeProperties).EndInit();
            ((System.ComponentModel.ISupportInitialize)txtFechaDesde.Properties).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.RadioGroup radioGroup;
        private DevExpress.XtraEditors.GroupControl groupControl2;
        private DevExpress.XtraEditors.DateEdit txtFechaHasta;
        private DevExpress.XtraEditors.DateEdit txtFechaDesde;
        private DevExpress.XtraEditors.LabelControl lblfechaHasta;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.SimpleButton btnVerReporte;
    }
}
