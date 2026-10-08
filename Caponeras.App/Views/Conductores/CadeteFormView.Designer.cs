namespace Caponeras.App.Views.Conductores
{
    partial class CadeteFormView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CadeteFormView));
            layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            txtNombre = new DevExpress.XtraEditors.TextEdit();
            txtIdentificacion = new DevExpress.XtraEditors.TextEdit();
            txtCelular = new DevExpress.XtraEditors.TextEdit();
            txtObservaciones = new DevExpress.XtraEditors.MemoEdit();
            txtDireccion = new DevExpress.XtraEditors.TextEdit();
            chkActivo = new DevExpress.XtraEditors.CheckEdit();
            Root = new DevExpress.XtraLayout.LayoutControlGroup();
            layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            layoutControlItem5 = new DevExpress.XtraLayout.LayoutControlItem();
            layoutControlItem6 = new DevExpress.XtraLayout.LayoutControlItem();
            errorProvider = new ErrorProvider(components);
            ((System.ComponentModel.ISupportInitialize)tablePanel1).BeginInit();
            tablePanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)layoutControl1).BeginInit();
            layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)txtNombre.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)txtIdentificacion.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)txtCelular.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)txtObservaciones.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)txtDireccion.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)chkActivo.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)Root).BeginInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem4).BeginInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem5).BeginInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem6).BeginInit();
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
            btnAceptar.Location = new Point(361, 21);
            tablePanel1.SetRow(btnAceptar, 0);
            // 
            // tablePanel1
            // 
            tablePanel1.Location = new Point(0, 333);
            tablePanel1.Size = new Size(522, 79);
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
            labelControl1.Size = new Size(522, 30);
            labelControl1.Text = "Datos del Cadete";
            // 
            // layoutControl1
            // 
            layoutControl1.Controls.Add(txtNombre);
            layoutControl1.Controls.Add(txtIdentificacion);
            layoutControl1.Controls.Add(txtCelular);
            layoutControl1.Controls.Add(txtObservaciones);
            layoutControl1.Controls.Add(txtDireccion);
            layoutControl1.Controls.Add(chkActivo);
            layoutControl1.Dock = DockStyle.Fill;
            layoutControl1.Location = new Point(0, 30);
            layoutControl1.Name = "layoutControl1";
            layoutControl1.Root = Root;
            layoutControl1.Size = new Size(522, 303);
            layoutControl1.TabIndex = 4;
            layoutControl1.Text = "layoutControl1";
            // 
            // txtNombre
            // 
            txtNombre.EnterMoveNextControl = true;
            txtNombre.Location = new Point(108, 17);
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(397, 20);
            txtNombre.StyleController = layoutControl1;
            txtNombre.TabIndex = 0;
            // 
            // txtIdentificacion
            // 
            txtIdentificacion.EnterMoveNextControl = true;
            txtIdentificacion.Location = new Point(108, 51);
            txtIdentificacion.Name = "txtIdentificacion";
            txtIdentificacion.Size = new Size(397, 20);
            txtIdentificacion.StyleController = layoutControl1;
            txtIdentificacion.TabIndex = 2;
            // 
            // txtCelular
            // 
            txtCelular.EnterMoveNextControl = true;
            txtCelular.Location = new Point(108, 85);
            txtCelular.Name = "txtCelular";
            txtCelular.Size = new Size(397, 20);
            txtCelular.StyleController = layoutControl1;
            txtCelular.TabIndex = 3;
            // 
            // txtObservaciones
            // 
            txtObservaciones.Location = new Point(17, 192);
            txtObservaciones.Name = "txtObservaciones";
            txtObservaciones.Size = new Size(488, 94);
            txtObservaciones.StyleController = layoutControl1;
            txtObservaciones.TabIndex = 5;
            // 
            // txtDireccion
            // 
            txtDireccion.Location = new Point(108, 119);
            txtDireccion.Name = "txtDireccion";
            txtDireccion.Size = new Size(397, 20);
            txtDireccion.StyleController = layoutControl1;
            txtDireccion.TabIndex = 4;
            // 
            // chkActivo
            // 
            chkActivo.EnterMoveNextControl = true;
            chkActivo.Location = new Point(12, 148);
            chkActivo.Name = "chkActivo";
            chkActivo.Properties.Caption = "Estado del cadete";
            chkActivo.Size = new Size(498, 19);
            chkActivo.StyleController = layoutControl1;
            chkActivo.TabIndex = 6;
            // 
            // Root
            // 
            Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            Root.GroupBordersVisible = false;
            Root.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] { layoutControlItem1, layoutControlItem2, layoutControlItem3, layoutControlItem4, layoutControlItem5, layoutControlItem6 });
            Root.Name = "Root";
            Root.Size = new Size(522, 303);
            Root.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            layoutControlItem1.AppearanceItemCaption.Options.UseTextOptions = true;
            layoutControlItem1.AppearanceItemCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            layoutControlItem1.Control = txtNombre;
            layoutControlItem1.Location = new Point(0, 0);
            layoutControlItem1.Name = "layoutControlItem1";
            layoutControlItem1.Size = new Size(502, 34);
            layoutControlItem1.Spacing = new DevExpress.XtraLayout.Utils.Padding(5, 5, 5, 5);
            layoutControlItem1.Text = "Nombre completo:";
            layoutControlItem1.TextSize = new Size(87, 13);
            // 
            // layoutControlItem2
            // 
            layoutControlItem2.AppearanceItemCaption.Options.UseTextOptions = true;
            layoutControlItem2.AppearanceItemCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            layoutControlItem2.Control = txtIdentificacion;
            layoutControlItem2.Location = new Point(0, 34);
            layoutControlItem2.Name = "layoutControlItem2";
            layoutControlItem2.Size = new Size(502, 34);
            layoutControlItem2.Spacing = new DevExpress.XtraLayout.Utils.Padding(5, 5, 5, 5);
            layoutControlItem2.Text = "Identificación:";
            layoutControlItem2.TextSize = new Size(87, 13);
            // 
            // layoutControlItem3
            // 
            layoutControlItem3.AppearanceItemCaption.Options.UseTextOptions = true;
            layoutControlItem3.AppearanceItemCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            layoutControlItem3.Control = txtCelular;
            layoutControlItem3.Location = new Point(0, 68);
            layoutControlItem3.Name = "layoutControlItem3";
            layoutControlItem3.Size = new Size(502, 34);
            layoutControlItem3.Spacing = new DevExpress.XtraLayout.Utils.Padding(5, 5, 5, 5);
            layoutControlItem3.Text = "Celular:";
            layoutControlItem3.TextSize = new Size(87, 13);
            // 
            // layoutControlItem4
            // 
            layoutControlItem4.Control = txtObservaciones;
            layoutControlItem4.Location = new Point(0, 159);
            layoutControlItem4.Name = "layoutControlItem4";
            layoutControlItem4.Size = new Size(502, 124);
            layoutControlItem4.Spacing = new DevExpress.XtraLayout.Utils.Padding(5, 5, 5, 5);
            layoutControlItem4.Text = "Observaciones";
            layoutControlItem4.TextLocation = DevExpress.Utils.Locations.Top;
            layoutControlItem4.TextSize = new Size(87, 13);
            // 
            // layoutControlItem5
            // 
            layoutControlItem5.AppearanceItemCaption.Options.UseTextOptions = true;
            layoutControlItem5.AppearanceItemCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            layoutControlItem5.Control = txtDireccion;
            layoutControlItem5.Location = new Point(0, 102);
            layoutControlItem5.Name = "layoutControlItem5";
            layoutControlItem5.Size = new Size(502, 34);
            layoutControlItem5.Spacing = new DevExpress.XtraLayout.Utils.Padding(5, 5, 5, 5);
            layoutControlItem5.Text = "Dirección:";
            layoutControlItem5.TextSize = new Size(87, 13);
            // 
            // layoutControlItem6
            // 
            layoutControlItem6.Control = chkActivo;
            layoutControlItem6.Location = new Point(0, 136);
            layoutControlItem6.Name = "layoutControlItem6";
            layoutControlItem6.Size = new Size(502, 23);
            layoutControlItem6.TextVisible = false;
            // 
            // errorProvider
            // 
            errorProvider.ContainerControl = this;
            // 
            // CadeteFormView
            // 
            AutoScaleDimensions = new SizeF(6F, 13F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(522, 412);
            Controls.Add(layoutControl1);
            IconOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("CadeteFormView.IconOptions.SvgImage");
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "CadeteFormView";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Info Cadetes";
            Load += CadeteFormView_Load;
            Controls.SetChildIndex(tablePanel1, 0);
            Controls.SetChildIndex(labelControl1, 0);
            Controls.SetChildIndex(layoutControl1, 0);
            ((System.ComponentModel.ISupportInitialize)tablePanel1).EndInit();
            tablePanel1.ResumeLayout(false);
            tablePanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)layoutControl1).EndInit();
            layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)txtNombre.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)txtIdentificacion.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)txtCelular.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)txtObservaciones.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)txtDireccion.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)chkActivo.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)Root).EndInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem1).EndInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem2).EndInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem3).EndInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem4).EndInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem5).EndInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem6).EndInit();
            ((System.ComponentModel.ISupportInitialize)errorProvider).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraEditors.TextEdit txtNombre;
        private DevExpress.XtraLayout.LayoutControlGroup Root;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraEditors.TextEdit txtIdentificacion;
        private DevExpress.XtraEditors.TextEdit txtCelular;
        private DevExpress.XtraEditors.MemoEdit txtObservaciones;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
        private ErrorProvider errorProvider;
        private DevExpress.XtraEditors.TextEdit txtDireccion;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem5;
        private DevExpress.XtraEditors.CheckEdit chkActivo;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem6;
    }
}