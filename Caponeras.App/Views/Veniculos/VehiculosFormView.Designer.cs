namespace Caponeras.App.Views.Veniculos
{
    partial class VehiculosFormView
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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(VehiculosFormView));
            layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            txtCodigo = new DevExpress.XtraEditors.TextEdit();
            txtPlaca = new DevExpress.XtraEditors.TextEdit();
            txtTipo = new DevExpress.XtraEditors.TextEdit();
            txtMarca = new DevExpress.XtraEditors.TextEdit();
            txtAnio = new DevExpress.XtraEditors.TextEdit();
            txtModelo = new DevExpress.XtraEditors.TextEdit();
            txtDescripcion = new DevExpress.XtraEditors.TextEdit();
            txtObservaciones = new DevExpress.XtraEditors.MemoEdit();
            Root = new DevExpress.XtraLayout.LayoutControlGroup();
            layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            layoutControlItem5 = new DevExpress.XtraLayout.LayoutControlItem();
            layoutControlItem6 = new DevExpress.XtraLayout.LayoutControlItem();
            layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            layoutControlItem8 = new DevExpress.XtraLayout.LayoutControlItem();
            layoutControlItem9 = new DevExpress.XtraLayout.LayoutControlItem();
            errorProvider = new ErrorProvider(components);
            ((System.ComponentModel.ISupportInitialize)layoutControl1).BeginInit();
            layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)txtCodigo.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)txtPlaca.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)txtTipo.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)txtMarca.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)txtAnio.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)txtModelo.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)txtDescripcion.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)txtObservaciones.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)Root).BeginInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem4).BeginInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem5).BeginInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem6).BeginInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem8).BeginInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem9).BeginInit();
            ((System.ComponentModel.ISupportInitialize)errorProvider).BeginInit();
            SuspendLayout();
            // 
            // btnCancelar
            // 
            btnCancelar.Appearance.BackColor = Color.Red;
            btnCancelar.Appearance.ForeColor = Color.White;
            btnCancelar.Appearance.Options.UseBackColor = true;
            btnCancelar.Appearance.Options.UseForeColor = true;
            btnCancelar.ImageOptions.AllowGlyphSkinning = DevExpress.Utils.DefaultBoolean.True;
            btnCancelar.ImageOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("btnCancelar.ImageOptions.SvgImage");
            btnCancelar.ImageOptions.SvgImageSize = new Size(32, 32);
            tablePanel1.SetRow(btnCancelar, 0);
            // 
            // labelControl1
            // 
            labelControl1.Appearance.BackColor = Color.Gray;
            labelControl1.Appearance.Font = new Font("Tahoma", 12F, FontStyle.Bold);
            labelControl1.Appearance.ForeColor = Color.White;
            labelControl1.Appearance.Options.UseBackColor = true;
            labelControl1.Appearance.Options.UseFont = true;
            labelControl1.Appearance.Options.UseForeColor = true;
            labelControl1.Appearance.Options.UseTextOptions = true;
            labelControl1.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            labelControl1.Size = new Size(633, 30);
            labelControl1.Text = "Datos del Vehiculo";
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
            btnAceptar.Location = new Point(417, 21);
            tablePanel1.SetRow(btnAceptar, 0);
            // 
            // layoutControl1
            // 
            layoutControl1.Controls.Add(txtCodigo);
            layoutControl1.Controls.Add(txtPlaca);
            layoutControl1.Controls.Add(txtTipo);
            layoutControl1.Controls.Add(txtMarca);
            layoutControl1.Controls.Add(txtAnio);
            layoutControl1.Controls.Add(txtModelo);
            layoutControl1.Controls.Add(txtDescripcion);
            layoutControl1.Controls.Add(txtObservaciones);
            layoutControl1.Dock = DockStyle.Fill;
            layoutControl1.Location = new Point(0, 30);
            layoutControl1.Name = "layoutControl1";
            layoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new Rectangle(903, 499, 650, 400);
            layoutControl1.Root = Root;
            layoutControl1.Size = new Size(633, 354);
            layoutControl1.TabIndex = 4;
            // 
            // txtCodigo
            // 
            txtCodigo.EnterMoveNextControl = true;
            txtCodigo.Location = new Point(106, 12);
            txtCodigo.Name = "txtCodigo";
            txtCodigo.Size = new Size(208, 20);
            txtCodigo.StyleController = layoutControl1;
            txtCodigo.TabIndex = 0;
            // 
            // txtPlaca
            // 
            txtPlaca.EnterMoveNextControl = true;
            txtPlaca.Location = new Point(412, 12);
            txtPlaca.Name = "txtPlaca";
            txtPlaca.Size = new Size(209, 20);
            txtPlaca.StyleController = layoutControl1;
            txtPlaca.TabIndex = 2;
            // 
            // txtTipo
            // 
            txtTipo.EnterMoveNextControl = true;
            txtTipo.Location = new Point(106, 36);
            txtTipo.Name = "txtTipo";
            txtTipo.Size = new Size(208, 20);
            txtTipo.StyleController = layoutControl1;
            txtTipo.TabIndex = 3;
            // 
            // txtMarca
            // 
            txtMarca.EnterMoveNextControl = true;
            txtMarca.Location = new Point(412, 36);
            txtMarca.Name = "txtMarca";
            txtMarca.Size = new Size(209, 20);
            txtMarca.StyleController = layoutControl1;
            txtMarca.TabIndex = 4;
            // 
            // txtAnio
            // 
            txtAnio.EnterMoveNextControl = true;
            txtAnio.Location = new Point(412, 60);
            txtAnio.Name = "txtAnio";
            txtAnio.Properties.MaskSettings.Set("MaskManagerType", typeof(DevExpress.Data.Mask.NumericMaskManager));
            txtAnio.Properties.MaskSettings.Set("MaskManagerSignature", "allowNull=False");
            txtAnio.Properties.MaskSettings.Set("mask", "###0");
            txtAnio.Size = new Size(209, 20);
            txtAnio.StyleController = layoutControl1;
            txtAnio.TabIndex = 6;
            // 
            // txtModelo
            // 
            txtModelo.EnterMoveNextControl = true;
            txtModelo.Location = new Point(106, 60);
            txtModelo.Name = "txtModelo";
            txtModelo.Size = new Size(208, 20);
            txtModelo.StyleController = layoutControl1;
            txtModelo.TabIndex = 5;
            // 
            // txtDescripcion
            // 
            txtDescripcion.EnterMoveNextControl = true;
            txtDescripcion.Location = new Point(106, 84);
            txtDescripcion.Name = "txtDescripcion";
            txtDescripcion.Size = new Size(515, 20);
            txtDescripcion.StyleController = layoutControl1;
            txtDescripcion.TabIndex = 8;
            // 
            // txtObservaciones
            // 
            txtObservaciones.Location = new Point(12, 125);
            txtObservaciones.Name = "txtObservaciones";
            txtObservaciones.Size = new Size(609, 217);
            txtObservaciones.StyleController = layoutControl1;
            txtObservaciones.TabIndex = 9;
            // 
            // Root
            // 
            Root.AppearanceItemCaption.Font = new Font("Tahoma", 9F);
            Root.AppearanceItemCaption.Options.UseFont = true;
            Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            Root.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] { layoutControlItem1, layoutControlItem3, layoutControlItem4, layoutControlItem5, layoutControlItem6, layoutControlItem2, layoutControlItem8, layoutControlItem9 });
            Root.Name = "Root";
            Root.Size = new Size(633, 354);
            Root.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            layoutControlItem1.AppearanceItemCaption.Options.UseTextOptions = true;
            layoutControlItem1.AppearanceItemCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            layoutControlItem1.Control = txtCodigo;
            layoutControlItem1.Location = new Point(0, 0);
            layoutControlItem1.Name = "layoutControlItem1";
            layoutControlItem1.Size = new Size(306, 24);
            layoutControlItem1.Text = "Código:";
            layoutControlItem1.TextSize = new Size(82, 14);
            // 
            // layoutControlItem3
            // 
            layoutControlItem3.AppearanceItemCaption.Options.UseTextOptions = true;
            layoutControlItem3.AppearanceItemCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            layoutControlItem3.Control = txtTipo;
            layoutControlItem3.Location = new Point(0, 24);
            layoutControlItem3.Name = "layoutControlItem3";
            layoutControlItem3.Size = new Size(306, 24);
            layoutControlItem3.Text = "Tipo:";
            layoutControlItem3.TextSize = new Size(82, 14);
            // 
            // layoutControlItem4
            // 
            layoutControlItem4.AppearanceItemCaption.Options.UseTextOptions = true;
            layoutControlItem4.AppearanceItemCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            layoutControlItem4.Control = txtMarca;
            layoutControlItem4.Location = new Point(306, 24);
            layoutControlItem4.Name = "layoutControlItem4";
            layoutControlItem4.Size = new Size(307, 24);
            layoutControlItem4.Text = "Marca:";
            layoutControlItem4.TextSize = new Size(82, 14);
            // 
            // layoutControlItem5
            // 
            layoutControlItem5.AppearanceItemCaption.Options.UseTextOptions = true;
            layoutControlItem5.AppearanceItemCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            layoutControlItem5.Control = txtAnio;
            layoutControlItem5.Location = new Point(306, 48);
            layoutControlItem5.Name = "layoutControlItem5";
            layoutControlItem5.Size = new Size(307, 24);
            layoutControlItem5.Text = "Año:";
            layoutControlItem5.TextSize = new Size(82, 14);
            // 
            // layoutControlItem6
            // 
            layoutControlItem6.AppearanceItemCaption.Options.UseTextOptions = true;
            layoutControlItem6.AppearanceItemCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            layoutControlItem6.Control = txtModelo;
            layoutControlItem6.Location = new Point(0, 48);
            layoutControlItem6.Name = "layoutControlItem6";
            layoutControlItem6.Size = new Size(306, 24);
            layoutControlItem6.Text = "Modelo:";
            layoutControlItem6.TextSize = new Size(82, 14);
            // 
            // layoutControlItem2
            // 
            layoutControlItem2.AppearanceItemCaption.Options.UseTextOptions = true;
            layoutControlItem2.AppearanceItemCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            layoutControlItem2.Control = txtPlaca;
            layoutControlItem2.Location = new Point(306, 0);
            layoutControlItem2.Name = "layoutControlItem2";
            layoutControlItem2.Size = new Size(307, 24);
            layoutControlItem2.Text = "Placa:";
            layoutControlItem2.TextSize = new Size(82, 14);
            // 
            // layoutControlItem8
            // 
            layoutControlItem8.AppearanceItemCaption.Options.UseTextOptions = true;
            layoutControlItem8.AppearanceItemCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            layoutControlItem8.Control = txtDescripcion;
            layoutControlItem8.Location = new Point(0, 72);
            layoutControlItem8.Name = "layoutControlItem8";
            layoutControlItem8.Size = new Size(613, 24);
            layoutControlItem8.Text = "Descripción:";
            layoutControlItem8.TextSize = new Size(82, 14);
            // 
            // layoutControlItem9
            // 
            layoutControlItem9.Control = txtObservaciones;
            layoutControlItem9.Location = new Point(0, 96);
            layoutControlItem9.Name = "layoutControlItem9";
            layoutControlItem9.Size = new Size(613, 238);
            layoutControlItem9.Text = "Observaciones:";
            layoutControlItem9.TextLocation = DevExpress.Utils.Locations.Top;
            layoutControlItem9.TextSize = new Size(82, 14);
            // 
            // errorProvider
            // 
            errorProvider.ContainerControl = this;
            // 
            // VehiculosFormView
            // 
            AutoScaleDimensions = new SizeF(6F, 13F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(633, 463);
            Controls.Add(layoutControl1);
            FormBorderEffect = DevExpress.XtraEditors.FormBorderEffect.Shadow;
            FormBorderStyle = FormBorderStyle.None;
            IconOptions.Image = Properties.Resources.tuk_tuk_32x32;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "VehiculosFormView";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Datos de Caponera";
            Load += VehiculosFormView_Load;
            Controls.SetChildIndex(labelControl1, 0);
            Controls.SetChildIndex(layoutControl1, 0);
            ((System.ComponentModel.ISupportInitialize)layoutControl1).EndInit();
            layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)txtCodigo.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)txtPlaca.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)txtTipo.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)txtMarca.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)txtAnio.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)txtModelo.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)txtDescripcion.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)txtObservaciones.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)Root).EndInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem1).EndInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem3).EndInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem4).EndInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem5).EndInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem6).EndInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem2).EndInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem8).EndInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem9).EndInit();
            ((System.ComponentModel.ISupportInitialize)errorProvider).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraEditors.TextEdit txtCodigo;
        private DevExpress.XtraEditors.TextEdit txtPlaca;
        private DevExpress.XtraEditors.TextEdit txtTipo;
        private DevExpress.XtraEditors.TextEdit txtMarca;
        private DevExpress.XtraEditors.TextEdit txtAnio;
        private DevExpress.XtraEditors.TextEdit txtModelo;
        private DevExpress.XtraEditors.TextEdit txtDescripcion;
        private DevExpress.XtraLayout.LayoutControlGroup Root;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem5;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem6;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem8;
        private DevExpress.XtraEditors.MemoEdit txtObservaciones;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem9;
        private ErrorProvider errorProvider;
    }
}