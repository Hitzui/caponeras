namespace Caponeras.App.Views.Proveedores
{
    sealed partial class ProveedoresFormView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ProveedoresFormView));
            layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            txtNombre = new DevExpress.XtraEditors.TextEdit();
            txtRuc = new DevExpress.XtraEditors.TextEdit();
            txtTelefono = new DevExpress.XtraEditors.TextEdit();
            txtEmail = new DevExpress.XtraEditors.TextEdit();
            txtContacto = new DevExpress.XtraEditors.TextEdit();
            txtDirecicón = new DevExpress.XtraEditors.MemoEdit();
            Root = new DevExpress.XtraLayout.LayoutControlGroup();
            layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            labelRuc = new DevExpress.XtraLayout.LayoutControlItem();
            labelTelefono = new DevExpress.XtraLayout.LayoutControlItem();
            labelEmail = new DevExpress.XtraLayout.LayoutControlItem();
            labelContacto = new DevExpress.XtraLayout.LayoutControlItem();
            labelDireccion = new DevExpress.XtraLayout.LayoutControlItem();
            dxErrorProvider1 = new DevExpress.XtraEditors.DXErrorProvider.DXErrorProvider(components);
            errorProvider = new ErrorProvider(components);
            ((System.ComponentModel.ISupportInitialize)layoutControl1).BeginInit();
            layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)txtNombre.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)txtRuc.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)txtTelefono.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)txtEmail.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)txtContacto.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)txtDirecicón.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)Root).BeginInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)labelRuc).BeginInit();
            ((System.ComponentModel.ISupportInitialize)labelTelefono).BeginInit();
            ((System.ComponentModel.ISupportInitialize)labelEmail).BeginInit();
            ((System.ComponentModel.ISupportInitialize)labelContacto).BeginInit();
            ((System.ComponentModel.ISupportInitialize)labelDireccion).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dxErrorProvider1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)errorProvider).BeginInit();
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
            labelControl1.Size = new Size(792, 30);
            labelControl1.Text = "Datos del proveedor";
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
            btnAceptar.Location = new Point(496, 21);
            tablePanel1.SetRow(btnAceptar, 0);
            btnAceptar.Click += btnAceptar_Click;
            // 
            // tablePanel1
            // 
            tablePanel1.Location = new Point(0, 425);
            tablePanel1.Size = new Size(792, 79);
            // 
            // layoutControl1
            // 
            layoutControl1.Controls.Add(txtNombre);
            layoutControl1.Controls.Add(txtRuc);
            layoutControl1.Controls.Add(txtTelefono);
            layoutControl1.Controls.Add(txtEmail);
            layoutControl1.Controls.Add(txtContacto);
            layoutControl1.Controls.Add(txtDirecicón);
            layoutControl1.Dock = DockStyle.Fill;
            layoutControl1.Location = new Point(0, 30);
            layoutControl1.Name = "layoutControl1";
            layoutControl1.Root = Root;
            layoutControl1.Size = new Size(792, 395);
            layoutControl1.TabIndex = 6;
            layoutControl1.Text = "layoutControl1";
            // 
            // txtNombre
            // 
            txtNombre.Location = new Point(64, 12);
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(330, 20);
            txtNombre.StyleController = layoutControl1;
            txtNombre.TabIndex = 0;
            // 
            // txtRuc
            // 
            txtRuc.Location = new Point(450, 12);
            txtRuc.Name = "txtRuc";
            txtRuc.Size = new Size(330, 20);
            txtRuc.StyleController = layoutControl1;
            txtRuc.TabIndex = 2;
            // 
            // txtTelefono
            // 
            txtTelefono.Location = new Point(64, 36);
            txtTelefono.Name = "txtTelefono";
            txtTelefono.Size = new Size(330, 20);
            txtTelefono.StyleController = layoutControl1;
            txtTelefono.TabIndex = 3;
            // 
            // txtEmail
            // 
            txtEmail.Location = new Point(450, 36);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(330, 20);
            txtEmail.StyleController = layoutControl1;
            txtEmail.TabIndex = 4;
            // 
            // txtContacto
            // 
            txtContacto.Location = new Point(64, 60);
            txtContacto.Name = "txtContacto";
            txtContacto.Size = new Size(716, 20);
            txtContacto.StyleController = layoutControl1;
            txtContacto.TabIndex = 5;
            // 
            // txtDirecicón
            // 
            txtDirecicón.Location = new Point(64, 84);
            txtDirecicón.Name = "txtDirecicón";
            txtDirecicón.Size = new Size(716, 299);
            txtDirecicón.StyleController = layoutControl1;
            txtDirecicón.TabIndex = 6;
            // 
            // Root
            // 
            Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            Root.GroupBordersVisible = false;
            Root.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] { layoutControlItem1, labelRuc, labelTelefono, labelEmail, labelContacto, labelDireccion });
            Root.Name = "Root";
            Root.Size = new Size(792, 395);
            Root.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            layoutControlItem1.AppearanceItemCaption.Options.UseTextOptions = true;
            layoutControlItem1.AppearanceItemCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            layoutControlItem1.Control = txtNombre;
            layoutControlItem1.Location = new Point(0, 0);
            layoutControlItem1.Name = "layoutControlItem1";
            layoutControlItem1.Size = new Size(386, 24);
            layoutControlItem1.Text = "Nombre:";
            layoutControlItem1.TextSize = new Size(48, 13);
            // 
            // labelRuc
            // 
            labelRuc.AppearanceItemCaption.Options.UseTextOptions = true;
            labelRuc.AppearanceItemCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            labelRuc.Control = txtRuc;
            labelRuc.Location = new Point(386, 0);
            labelRuc.Name = "labelRuc";
            labelRuc.Size = new Size(386, 24);
            labelRuc.Text = "RUC:";
            labelRuc.TextSize = new Size(48, 13);
            // 
            // labelTelefono
            // 
            labelTelefono.AppearanceItemCaption.Options.UseTextOptions = true;
            labelTelefono.AppearanceItemCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            labelTelefono.Control = txtTelefono;
            labelTelefono.Location = new Point(0, 24);
            labelTelefono.Name = "labelTelefono";
            labelTelefono.Size = new Size(386, 24);
            labelTelefono.Text = "Teléfono:";
            labelTelefono.TextSize = new Size(48, 13);
            // 
            // labelEmail
            // 
            labelEmail.AppearanceItemCaption.Options.UseTextOptions = true;
            labelEmail.AppearanceItemCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            labelEmail.Control = txtEmail;
            labelEmail.Location = new Point(386, 24);
            labelEmail.Name = "labelEmail";
            labelEmail.Size = new Size(386, 24);
            labelEmail.Text = "E-mail:";
            labelEmail.TextSize = new Size(48, 13);
            // 
            // labelContacto
            // 
            labelContacto.AppearanceItemCaption.Options.UseTextOptions = true;
            labelContacto.AppearanceItemCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            labelContacto.Control = txtContacto;
            labelContacto.Location = new Point(0, 48);
            labelContacto.Name = "labelContacto";
            labelContacto.Size = new Size(772, 24);
            labelContacto.Text = "Contacto:";
            labelContacto.TextSize = new Size(48, 13);
            // 
            // labelDireccion
            // 
            labelDireccion.AppearanceItemCaption.Options.UseTextOptions = true;
            labelDireccion.AppearanceItemCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            labelDireccion.AppearanceItemCaption.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Top;
            labelDireccion.Control = txtDirecicón;
            labelDireccion.Location = new Point(0, 72);
            labelDireccion.Name = "labelDireccion";
            labelDireccion.Size = new Size(772, 303);
            labelDireccion.Text = "Dirección:";
            labelDireccion.TextSize = new Size(48, 13);
            // 
            // dxErrorProvider1
            // 
            dxErrorProvider1.ContainerControl = this;
            // 
            // errorProvider
            // 
            errorProvider.ContainerControl = this;
            // 
            // ProveedoresFormView
            // 
            AutoScaleDimensions = new SizeF(6F, 13F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(792, 504);
            Controls.Add(layoutControl1);
            FormBorderEffect = DevExpress.XtraEditors.FormBorderEffect.Shadow;
            FormBorderStyle = FormBorderStyle.None;
            IconOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("ProveedoresFormView.IconOptions.SvgImage");
            Name = "ProveedoresFormView";
            Text = "ProveedoresFormView";
            Load += ProveedoresFormView_Load;
            Controls.SetChildIndex(labelControl1, 0);
            Controls.SetChildIndex(tablePanel1, 0);
            Controls.SetChildIndex(layoutControl1, 0);
            ((System.ComponentModel.ISupportInitialize)tablePanel1).EndInit();
            tablePanel1.ResumeLayout(false);
            tablePanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)layoutControl1).EndInit();
            layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)txtNombre.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)txtRuc.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)txtTelefono.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)txtEmail.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)txtContacto.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)txtDirecicón.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)Root).EndInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem1).EndInit();
            ((System.ComponentModel.ISupportInitialize)labelRuc).EndInit();
            ((System.ComponentModel.ISupportInitialize)labelTelefono).EndInit();
            ((System.ComponentModel.ISupportInitialize)labelEmail).EndInit();
            ((System.ComponentModel.ISupportInitialize)labelContacto).EndInit();
            ((System.ComponentModel.ISupportInitialize)labelDireccion).EndInit();
            ((System.ComponentModel.ISupportInitialize)dxErrorProvider1).EndInit();
            ((System.ComponentModel.ISupportInitialize)errorProvider).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup Root;
        private DevExpress.XtraEditors.TextEdit txtNombre;
        private DevExpress.XtraEditors.TextEdit txtRuc;
        private DevExpress.XtraEditors.TextEdit txtTelefono;
        private DevExpress.XtraEditors.TextEdit txtEmail;
        private DevExpress.XtraEditors.TextEdit txtContacto;
        private DevExpress.XtraEditors.MemoEdit txtDirecicón;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.LayoutControlItem labelRuc;
        private DevExpress.XtraLayout.LayoutControlItem labelTelefono;
        private DevExpress.XtraLayout.LayoutControlItem labelEmail;
        private DevExpress.XtraLayout.LayoutControlItem labelContacto;
        private DevExpress.XtraLayout.LayoutControlItem labelDireccion;
        private DevExpress.XtraEditors.DXErrorProvider.DXErrorProvider dxErrorProvider1;
        private ErrorProvider errorProvider;
    }
}