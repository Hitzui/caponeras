namespace Caponeras.App.Views.Mcaja
{
    sealed partial class AperturaCajaView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AperturaCajaView));
            labelControl1 = new DevExpress.XtraEditors.LabelControl();
            labelControl2 = new DevExpress.XtraEditors.LabelControl();
            btnAperturar = new DevExpress.XtraEditors.SimpleButton();
            btnCancelar = new DevExpress.XtraEditors.SimpleButton();
            SuspendLayout();
            // 
            // labelControl1
            // 
            labelControl1.Appearance.BackColor = Color.FromArgb(64, 64, 64);
            labelControl1.Appearance.Font = new Font("Tahoma", 14F);
            labelControl1.Appearance.ForeColor = Color.White;
            labelControl1.Appearance.Options.UseBackColor = true;
            labelControl1.Appearance.Options.UseFont = true;
            labelControl1.Appearance.Options.UseForeColor = true;
            labelControl1.Appearance.Options.UseTextOptions = true;
            labelControl1.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            labelControl1.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            labelControl1.Dock = DockStyle.Top;
            labelControl1.Location = new Point(0, 0);
            labelControl1.Name = "labelControl1";
            labelControl1.Size = new Size(627, 38);
            labelControl1.TabIndex = 0;
            labelControl1.Text = "Aperturar Caja";
            // 
            // labelControl2
            // 
            labelControl2.Appearance.Font = new Font("Tahoma", 14F);
            labelControl2.Appearance.Options.UseFont = true;
            labelControl2.Location = new Point(176, 84);
            labelControl2.Name = "labelControl2";
            labelControl2.Size = new Size(296, 23);
            labelControl2.TabIndex = 1;
            labelControl2.Text = "¿Aperturar caja para el día de hoy?";
            // 
            // btnAperturar
            // 
            btnAperturar.Appearance.BackColor = Color.FromArgb(0, 192, 0);
            btnAperturar.Appearance.ForeColor = Color.White;
            btnAperturar.Appearance.Options.UseBackColor = true;
            btnAperturar.Appearance.Options.UseForeColor = true;
            btnAperturar.ImageOptions.AllowGlyphSkinning = DevExpress.Utils.DefaultBoolean.True;
            btnAperturar.ImageOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("btnAperturar.ImageOptions.SvgImage");
            btnAperturar.ImageOptions.SvgImageSize = new Size(24, 24);
            btnAperturar.Location = new Point(104, 147);
            btnAperturar.Name = "btnAperturar";
            btnAperturar.Size = new Size(120, 31);
            btnAperturar.TabIndex = 2;
            btnAperturar.Text = "Aperturar";
            btnAperturar.Click += btnAperturar_Click;
            // 
            // btnCancelar
            // 
            btnCancelar.Appearance.BackColor = Color.FromArgb(192, 0, 0);
            btnCancelar.Appearance.ForeColor = Color.White;
            btnCancelar.Appearance.Options.UseBackColor = true;
            btnCancelar.Appearance.Options.UseForeColor = true;
            btnCancelar.ImageOptions.AllowGlyphSkinning = DevExpress.Utils.DefaultBoolean.True;
            btnCancelar.ImageOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("btnCancelar.ImageOptions.SvgImage");
            btnCancelar.ImageOptions.SvgImageSize = new Size(24, 24);
            btnCancelar.Location = new Point(454, 147);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(120, 31);
            btnCancelar.TabIndex = 3;
            btnCancelar.Text = "Cancelar";
            btnCancelar.Click += btnCancelar_Click;
            // 
            // AperturaCajaView
            // 
            AutoScaleDimensions = new SizeF(6F, 13F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(627, 207);
            Controls.Add(btnCancelar);
            Controls.Add(btnAperturar);
            Controls.Add(labelControl2);
            Controls.Add(labelControl1);
            FormBorderEffect = DevExpress.XtraEditors.FormBorderEffect.Shadow;
            FormBorderStyle = FormBorderStyle.None;
            IconOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("AperturaCajaView.IconOptions.SvgImage");
            Name = "AperturaCajaView";
            Text = "Aperturar Caja";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.SimpleButton btnAperturar;
        private DevExpress.XtraEditors.SimpleButton btnCancelar;
    }
}