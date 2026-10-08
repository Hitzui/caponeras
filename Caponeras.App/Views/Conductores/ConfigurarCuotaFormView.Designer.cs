namespace Caponeras.App.Views.Conductores
{
    sealed partial class ConfigurarCuotaFormView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ConfigurarCuotaFormView));
            groupControl1 = new DevExpress.XtraEditors.GroupControl();
            txtIdentificacion = new DevExpress.XtraEditors.TextEdit();
            labelControl3 = new DevExpress.XtraEditors.LabelControl();
            txtNombreCadete = new DevExpress.XtraEditors.TextEdit();
            labelControl2 = new DevExpress.XtraEditors.LabelControl();
            groupControl2 = new DevExpress.XtraEditors.GroupControl();
            txtObservaciones = new DevExpress.XtraEditors.TextEdit();
            labelControl5 = new DevExpress.XtraEditors.LabelControl();
            txtCuota = new DevExpress.XtraEditors.TextEdit();
            labelControl4 = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)tablePanel1).BeginInit();
            tablePanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)groupControl1).BeginInit();
            groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)txtIdentificacion.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)txtNombreCadete.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)groupControl2).BeginInit();
            groupControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)txtObservaciones.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)txtCuota.Properties).BeginInit();
            SuspendLayout();
            // 
            // btnCancelar
            // 
            btnCancelar.Appearance.BackColor = Color.Red;
            btnCancelar.Appearance.ForeColor = Color.White;
            btnCancelar.Appearance.Options.UseBackColor = true;
            btnCancelar.Appearance.Options.UseForeColor = true;
            tablePanel1.SetColumn(btnCancelar, 0);
            btnCancelar.ImageOptions.AllowGlyphSkinning = DevExpress.Utils.DefaultBoolean.True;
            btnCancelar.ImageOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("btnCancelar.ImageOptions.SvgImage");
            btnCancelar.ImageOptions.SvgImageSize = new Size(32, 32);
            tablePanel1.SetRow(btnCancelar, 0);
            btnCancelar.Click += btnCancelar_Click;
            // 
            // labelControl1
            // 
            labelControl1.Appearance.BackColor = Color.FromArgb(64, 64, 64);
            labelControl1.Appearance.Font = new Font("Tahoma", 12F, FontStyle.Bold);
            labelControl1.Appearance.ForeColor = Color.White;
            labelControl1.Appearance.Options.UseBackColor = true;
            labelControl1.Appearance.Options.UseFont = true;
            labelControl1.Appearance.Options.UseForeColor = true;
            labelControl1.Appearance.Options.UseTextOptions = true;
            labelControl1.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            labelControl1.Text = "Confgurar Cuota Cadete";
            // 
            // btnAceptar
            // 
            btnAceptar.Appearance.BackColor = Color.ForestGreen;
            btnAceptar.Appearance.ForeColor = Color.White;
            btnAceptar.Appearance.Options.UseBackColor = true;
            btnAceptar.Appearance.Options.UseFont = true;
            btnAceptar.Appearance.Options.UseForeColor = true;
            tablePanel1.SetColumn(btnAceptar, 1);
            btnAceptar.ImageOptions.AllowGlyphSkinning = DevExpress.Utils.DefaultBoolean.True;
            btnAceptar.ImageOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("btnAceptar.ImageOptions.SvgImage");
            btnAceptar.ImageOptions.SvgImageSize = new Size(32, 32);
            tablePanel1.SetRow(btnAceptar, 0);
            btnAceptar.Click += btnAceptar_Click;
            // 
            // tablePanel1
            // 
            tablePanel1.Location = new Point(0, 262);
            // 
            // groupControl1
            // 
            groupControl1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            groupControl1.Controls.Add(txtIdentificacion);
            groupControl1.Controls.Add(labelControl3);
            groupControl1.Controls.Add(txtNombreCadete);
            groupControl1.Controls.Add(labelControl2);
            groupControl1.Location = new Point(12, 36);
            groupControl1.Name = "groupControl1";
            groupControl1.Size = new Size(477, 100);
            groupControl1.TabIndex = 7;
            groupControl1.Text = "Datos del Cadete";
            // 
            // txtIdentificacion
            // 
            txtIdentificacion.Location = new Point(88, 56);
            txtIdentificacion.Name = "txtIdentificacion";
            txtIdentificacion.Properties.ReadOnly = true;
            txtIdentificacion.Size = new Size(318, 20);
            txtIdentificacion.TabIndex = 3;
            // 
            // labelControl3
            // 
            labelControl3.Location = new Point(14, 59);
            labelControl3.Name = "labelControl3";
            labelControl3.Size = new Size(68, 13);
            labelControl3.TabIndex = 2;
            labelControl3.Text = "Identificación:";
            // 
            // txtNombreCadete
            // 
            txtNombreCadete.Location = new Point(88, 24);
            txtNombreCadete.Name = "txtNombreCadete";
            txtNombreCadete.Properties.ReadOnly = true;
            txtNombreCadete.Size = new Size(318, 20);
            txtNombreCadete.TabIndex = 1;
            // 
            // labelControl2
            // 
            labelControl2.Location = new Point(41, 27);
            labelControl2.Name = "labelControl2";
            labelControl2.Size = new Size(41, 13);
            labelControl2.TabIndex = 0;
            labelControl2.Text = "Nombre:";
            // 
            // groupControl2
            // 
            groupControl2.Controls.Add(txtObservaciones);
            groupControl2.Controls.Add(labelControl5);
            groupControl2.Controls.Add(txtCuota);
            groupControl2.Controls.Add(labelControl4);
            groupControl2.Location = new Point(12, 142);
            groupControl2.Name = "groupControl2";
            groupControl2.Size = new Size(476, 100);
            groupControl2.TabIndex = 8;
            groupControl2.Text = "Establecer monto";
            // 
            // txtObservaciones
            // 
            txtObservaciones.Location = new Point(88, 37);
            txtObservaciones.Name = "txtObservaciones";
            txtObservaciones.Properties.BeepOnError = true;
            txtObservaciones.Properties.UseMaskAsDisplayFormat = true;
            txtObservaciones.Size = new Size(318, 20);
            txtObservaciones.TabIndex = 6;
            // 
            // labelControl5
            // 
            labelControl5.Location = new Point(7, 40);
            labelControl5.Name = "labelControl5";
            labelControl5.Size = new Size(75, 13);
            labelControl5.TabIndex = 5;
            labelControl5.Text = "Observaciones:";
            // 
            // txtCuota
            // 
            txtCuota.Location = new Point(88, 75);
            txtCuota.Name = "txtCuota";
            txtCuota.Properties.BeepOnError = true;
            txtCuota.Properties.MaskSettings.Set("MaskManagerType", typeof(DevExpress.Data.Mask.NumericMaskManager));
            txtCuota.Properties.MaskSettings.Set("MaskManagerSignature", "allowNull=False");
            txtCuota.Properties.MaskSettings.Set("mask", "n");
            txtCuota.Properties.UseMaskAsDisplayFormat = true;
            txtCuota.Size = new Size(133, 20);
            txtCuota.TabIndex = 4;
            // 
            // labelControl4
            // 
            labelControl4.Location = new Point(49, 78);
            labelControl4.Name = "labelControl4";
            labelControl4.Size = new Size(33, 13);
            labelControl4.TabIndex = 3;
            labelControl4.Text = "Cuota:";
            // 
            // ConfigurarCuotaFormView
            // 
            AutoScaleDimensions = new SizeF(6F, 13F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(500, 341);
            Controls.Add(groupControl2);
            Controls.Add(groupControl1);
            Name = "ConfigurarCuotaFormView";
            Text = "ConfigurarCuotaFormView";
            Load += ConfigurarCuotaFormView_Load;
            Controls.SetChildIndex(labelControl1, 0);
            Controls.SetChildIndex(tablePanel1, 0);
            Controls.SetChildIndex(groupControl1, 0);
            Controls.SetChildIndex(groupControl2, 0);
            ((System.ComponentModel.ISupportInitialize)tablePanel1).EndInit();
            tablePanel1.ResumeLayout(false);
            tablePanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)groupControl1).EndInit();
            groupControl1.ResumeLayout(false);
            groupControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)txtIdentificacion.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)txtNombreCadete.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)groupControl2).EndInit();
            groupControl2.ResumeLayout(false);
            groupControl2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)txtObservaciones.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)txtCuota.Properties).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.TextEdit txtIdentificacion;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.TextEdit txtNombreCadete;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.GroupControl groupControl2;
        private DevExpress.XtraEditors.TextEdit txtCuota;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.TextEdit txtObservaciones;
        private DevExpress.XtraEditors.LabelControl labelControl5;
    }
}