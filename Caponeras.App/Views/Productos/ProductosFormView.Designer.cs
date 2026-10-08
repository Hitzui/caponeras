namespace Caponeras.App.Views.Productos
{
    partial class ProductosFormView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ProductosFormView));
            layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            txtCodigo = new DevExpress.XtraEditors.TextEdit();
            txtNombre = new DevExpress.XtraEditors.TextEdit();
            txtStockMinimo = new DevExpress.XtraEditors.TextEdit();
            txtPrecio = new DevExpress.XtraEditors.TextEdit();
            txtDescripcion = new DevExpress.XtraEditors.MemoEdit();
            cmbUnidadMedida = new DevExpress.XtraEditors.ComboBoxEdit();
            cmbCategoria = new DevExpress.XtraEditors.ComboBoxEdit();
            txtImagen = new DevExpress.XtraEditors.PictureEdit();
            chkInventariable = new DevExpress.XtraEditors.CheckEdit();
            Root = new DevExpress.XtraLayout.LayoutControlGroup();
            layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            layoutControlItem5 = new DevExpress.XtraLayout.LayoutControlItem();
            layoutControlItem6 = new DevExpress.XtraLayout.LayoutControlItem();
            layoutControlItem7 = new DevExpress.XtraLayout.LayoutControlItem();
            layoutControlItem8 = new DevExpress.XtraLayout.LayoutControlItem();
            layoutControlItem9 = new DevExpress.XtraLayout.LayoutControlItem();
            errorProvider1 = new System.Windows.Forms.ErrorProvider(components);
            txtStockActual = new DevExpress.XtraEditors.TextEdit();
            layoutControlItem10 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)tablePanel1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)layoutControl1).BeginInit();
            layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)txtCodigo.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)txtNombre.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)txtStockMinimo.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)txtPrecio.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)txtDescripcion.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)cmbUnidadMedida.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)cmbCategoria.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)txtImagen.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)chkInventariable.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)Root).BeginInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem4).BeginInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem5).BeginInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem6).BeginInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem7).BeginInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem8).BeginInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem9).BeginInit();
            ((System.ComponentModel.ISupportInitialize)errorProvider1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)txtStockActual.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem10).BeginInit();
            SuspendLayout();
            // 
            // btnCancelar
            // 
            btnCancelar.Appearance.BackColor = System.Drawing.Color.Red;
            btnCancelar.Appearance.ForeColor = System.Drawing.Color.White;
            btnCancelar.Appearance.Options.UseBackColor = true;
            btnCancelar.Appearance.Options.UseForeColor = true;
            tablePanel1.SetColumn(btnCancelar, 0);
            btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            btnCancelar.ImageOptions.AllowGlyphSkinning = DevExpress.Utils.DefaultBoolean.True;
            btnCancelar.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)resources.GetObject("btnCancelar.ImageOptions.SvgImage"));
            btnCancelar.ImageOptions.SvgImageSize = new System.Drawing.Size(32, 32);
            btnCancelar.Location = new System.Drawing.Point(161, 21);
            btnCancelar.Margin = new System.Windows.Forms.Padding(150, 3, 3, 3);
            tablePanel1.SetRow(btnCancelar, 0);
            // 
            // btnAceptar
            // 
            btnAceptar.Appearance.BackColor = System.Drawing.Color.ForestGreen;
            btnAceptar.Appearance.ForeColor = System.Drawing.Color.White;
            btnAceptar.Appearance.Options.UseBackColor = true;
            btnAceptar.Appearance.Options.UseFont = true;
            btnAceptar.Appearance.Options.UseForeColor = true;
            tablePanel1.SetColumn(btnAceptar, 1);
            btnAceptar.ImageOptions.AllowGlyphSkinning = DevExpress.Utils.DefaultBoolean.True;
            btnAceptar.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)resources.GetObject("btnAceptar.ImageOptions.SvgImage"));
            btnAceptar.ImageOptions.SvgImageSize = new System.Drawing.Size(32, 32);
            btnAceptar.Location = new System.Drawing.Point(533, 21);
            btnAceptar.Margin = new System.Windows.Forms.Padding(150, 3, 3, 3);
            tablePanel1.SetRow(btnAceptar, 0);
            btnAceptar.Click += btnAceptar_Click;
            // 
            // tablePanel1
            // 
            tablePanel1.Location = new System.Drawing.Point(0, 424);
            tablePanel1.Size = new System.Drawing.Size(766, 79);
            // 
            // labelControl1
            // 
            labelControl1.Appearance.BackColor = System.Drawing.Color.Gray;
            labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            labelControl1.Appearance.ForeColor = System.Drawing.Color.White;
            labelControl1.Appearance.Options.UseBackColor = true;
            labelControl1.Appearance.Options.UseFont = true;
            labelControl1.Appearance.Options.UseForeColor = true;
            labelControl1.Appearance.Options.UseTextOptions = true;
            labelControl1.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            labelControl1.Size = new System.Drawing.Size(766, 30);
            labelControl1.Text = "Datos del Repuesto";
            // 
            // layoutControl1
            // 
            layoutControl1.Controls.Add(txtCodigo);
            layoutControl1.Controls.Add(txtNombre);
            layoutControl1.Controls.Add(txtStockMinimo);
            layoutControl1.Controls.Add(txtPrecio);
            layoutControl1.Controls.Add(txtDescripcion);
            layoutControl1.Controls.Add(cmbUnidadMedida);
            layoutControl1.Controls.Add(cmbCategoria);
            layoutControl1.Controls.Add(txtImagen);
            layoutControl1.Controls.Add(chkInventariable);
            layoutControl1.Controls.Add(txtStockActual);
            layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            layoutControl1.Location = new System.Drawing.Point(0, 30);
            layoutControl1.Name = "layoutControl1";
            layoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(1139, 224, 650, 400);
            layoutControl1.Root = Root;
            layoutControl1.Size = new System.Drawing.Size(766, 394);
            layoutControl1.TabIndex = 6;
            // 
            // txtCodigo
            // 
            txtCodigo.EnterMoveNextControl = true;
            txtCodigo.Location = new System.Drawing.Point(93, 12);
            txtCodigo.Name = "txtCodigo";
            txtCodigo.Size = new System.Drawing.Size(288, 20);
            txtCodigo.StyleController = layoutControl1;
            txtCodigo.TabIndex = 0;
            // 
            // txtNombre
            // 
            txtNombre.EnterMoveNextControl = true;
            txtNombre.Location = new System.Drawing.Point(466, 12);
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new System.Drawing.Size(288, 20);
            txtNombre.StyleController = layoutControl1;
            txtNombre.TabIndex = 2;
            // 
            // txtStockMinimo
            // 
            txtStockMinimo.EnterMoveNextControl = true;
            txtStockMinimo.Location = new System.Drawing.Point(93, 36);
            txtStockMinimo.Name = "txtStockMinimo";
            txtStockMinimo.Properties.MaskSettings.Set("MaskManagerType", typeof(DevExpress.Data.Mask.NumericMaskManager));
            txtStockMinimo.Properties.MaskSettings.Set("MaskManagerSignature", "allowNull=False");
            txtStockMinimo.Properties.MaskSettings.Set("mask", "d");
            txtStockMinimo.Size = new System.Drawing.Size(288, 20);
            txtStockMinimo.StyleController = layoutControl1;
            txtStockMinimo.TabIndex = 3;
            // 
            // txtPrecio
            // 
            txtPrecio.EnterMoveNextControl = true;
            txtPrecio.Location = new System.Drawing.Point(466, 36);
            txtPrecio.Name = "txtPrecio";
            txtPrecio.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            txtPrecio.Properties.MaskSettings.Set("MaskManagerType", typeof(DevExpress.Data.Mask.NumericMaskManager));
            txtPrecio.Properties.MaskSettings.Set("MaskManagerSignature", "allowNull=False");
            txtPrecio.Properties.MaskSettings.Set("mask", "n");
            txtPrecio.Size = new System.Drawing.Size(288, 20);
            txtPrecio.StyleController = layoutControl1;
            txtPrecio.TabIndex = 4;
            // 
            // txtDescripcion
            // 
            txtDescripcion.Location = new System.Drawing.Point(93, 108);
            txtDescripcion.Name = "txtDescripcion";
            txtDescripcion.Size = new System.Drawing.Size(288, 250);
            txtDescripcion.StyleController = layoutControl1;
            txtDescripcion.TabIndex = 7;
            // 
            // cmbUnidadMedida
            // 
            cmbUnidadMedida.EnterMoveNextControl = true;
            cmbUnidadMedida.Location = new System.Drawing.Point(466, 84);
            cmbUnidadMedida.Name = "cmbUnidadMedida";
            cmbUnidadMedida.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo) });
            cmbUnidadMedida.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            cmbUnidadMedida.Size = new System.Drawing.Size(288, 20);
            cmbUnidadMedida.StyleController = layoutControl1;
            cmbUnidadMedida.TabIndex = 6;
            // 
            // cmbCategoria
            // 
            cmbCategoria.EnterMoveNextControl = true;
            cmbCategoria.Location = new System.Drawing.Point(93, 84);
            cmbCategoria.Name = "cmbCategoria";
            cmbCategoria.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo) });
            cmbCategoria.Properties.PopupSizeable = true;
            cmbCategoria.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            cmbCategoria.Size = new System.Drawing.Size(288, 20);
            cmbCategoria.StyleController = layoutControl1;
            cmbCategoria.TabIndex = 5;
            // 
            // txtImagen
            // 
            txtImagen.Location = new System.Drawing.Point(466, 108);
            txtImagen.Name = "txtImagen";
            txtImagen.Properties.ShowCameraMenuItem = DevExpress.XtraEditors.Controls.CameraMenuItemVisibility.Auto;
            txtImagen.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Stretch;
            txtImagen.Size = new System.Drawing.Size(288, 250);
            txtImagen.StyleController = layoutControl1;
            txtImagen.TabIndex = 8;
            // 
            // chkInventariable
            // 
            chkInventariable.EditValue = true;
            chkInventariable.Location = new System.Drawing.Point(12, 362);
            chkInventariable.Name = "chkInventariable";
            chkInventariable.Properties.Caption = "Es inventariable?";
            chkInventariable.Size = new System.Drawing.Size(742, 20);
            chkInventariable.StyleController = layoutControl1;
            chkInventariable.TabIndex = 9;
            // 
            // Root
            // 
            Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            Root.GroupBordersVisible = false;
            Root.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] { layoutControlItem1, layoutControlItem2, layoutControlItem3, layoutControlItem4, layoutControlItem5, layoutControlItem6, layoutControlItem7, layoutControlItem8, layoutControlItem9, layoutControlItem10 });
            Root.Name = "Root";
            Root.Size = new System.Drawing.Size(766, 394);
            Root.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            layoutControlItem1.AppearanceItemCaption.Options.UseTextOptions = true;
            layoutControlItem1.AppearanceItemCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            layoutControlItem1.Control = txtCodigo;
            layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            layoutControlItem1.Name = "layoutControlItem1";
            layoutControlItem1.Size = new System.Drawing.Size(373, 24);
            layoutControlItem1.Text = "Código";
            layoutControlItem1.TextSize = new System.Drawing.Size(69, 13);
            // 
            // layoutControlItem2
            // 
            layoutControlItem2.AppearanceItemCaption.Options.UseTextOptions = true;
            layoutControlItem2.AppearanceItemCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            layoutControlItem2.Control = txtNombre;
            layoutControlItem2.Location = new System.Drawing.Point(373, 0);
            layoutControlItem2.Name = "layoutControlItem2";
            layoutControlItem2.Size = new System.Drawing.Size(373, 24);
            layoutControlItem2.Text = "Nombre";
            layoutControlItem2.TextSize = new System.Drawing.Size(69, 13);
            // 
            // layoutControlItem3
            // 
            layoutControlItem3.AppearanceItemCaption.Options.UseTextOptions = true;
            layoutControlItem3.AppearanceItemCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            layoutControlItem3.Control = txtStockMinimo;
            layoutControlItem3.Location = new System.Drawing.Point(0, 24);
            layoutControlItem3.Name = "layoutControlItem3";
            layoutControlItem3.Size = new System.Drawing.Size(373, 24);
            layoutControlItem3.Text = "Stock Mínimo";
            layoutControlItem3.TextSize = new System.Drawing.Size(69, 13);
            // 
            // layoutControlItem4
            // 
            layoutControlItem4.AppearanceItemCaption.Options.UseTextOptions = true;
            layoutControlItem4.AppearanceItemCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            layoutControlItem4.Control = txtPrecio;
            layoutControlItem4.Location = new System.Drawing.Point(373, 24);
            layoutControlItem4.Name = "layoutControlItem4";
            layoutControlItem4.Size = new System.Drawing.Size(373, 48);
            layoutControlItem4.Text = "Precio Compra";
            layoutControlItem4.TextSize = new System.Drawing.Size(69, 13);
            // 
            // layoutControlItem5
            // 
            layoutControlItem5.AppearanceItemCaption.Options.UseTextOptions = true;
            layoutControlItem5.AppearanceItemCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            layoutControlItem5.Control = cmbCategoria;
            layoutControlItem5.Location = new System.Drawing.Point(0, 72);
            layoutControlItem5.Name = "layoutControlItem5";
            layoutControlItem5.Size = new System.Drawing.Size(373, 24);
            layoutControlItem5.Text = "Categoría";
            layoutControlItem5.TextSize = new System.Drawing.Size(69, 13);
            // 
            // layoutControlItem6
            // 
            layoutControlItem6.AppearanceItemCaption.Options.UseTextOptions = true;
            layoutControlItem6.AppearanceItemCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            layoutControlItem6.Control = cmbUnidadMedida;
            layoutControlItem6.Location = new System.Drawing.Point(373, 72);
            layoutControlItem6.Name = "layoutControlItem6";
            layoutControlItem6.Size = new System.Drawing.Size(373, 24);
            layoutControlItem6.Text = "U/M";
            layoutControlItem6.TextSize = new System.Drawing.Size(69, 13);
            // 
            // layoutControlItem7
            // 
            layoutControlItem7.AppearanceItemCaption.Options.UseTextOptions = true;
            layoutControlItem7.AppearanceItemCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            layoutControlItem7.AppearanceItemCaption.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Top;
            layoutControlItem7.Control = txtDescripcion;
            layoutControlItem7.Location = new System.Drawing.Point(0, 96);
            layoutControlItem7.Name = "layoutControlItem7";
            layoutControlItem7.Size = new System.Drawing.Size(373, 254);
            layoutControlItem7.Text = "Descripción";
            layoutControlItem7.TextSize = new System.Drawing.Size(69, 13);
            // 
            // layoutControlItem8
            // 
            layoutControlItem8.AppearanceItemCaption.Options.UseTextOptions = true;
            layoutControlItem8.AppearanceItemCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            layoutControlItem8.AppearanceItemCaption.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Top;
            layoutControlItem8.Control = txtImagen;
            layoutControlItem8.Location = new System.Drawing.Point(373, 96);
            layoutControlItem8.Name = "layoutControlItem8";
            layoutControlItem8.Size = new System.Drawing.Size(373, 254);
            layoutControlItem8.Text = "Imagen";
            layoutControlItem8.TextSize = new System.Drawing.Size(69, 13);
            // 
            // layoutControlItem9
            // 
            layoutControlItem9.Control = chkInventariable;
            layoutControlItem9.Location = new System.Drawing.Point(0, 350);
            layoutControlItem9.Name = "layoutControlItem9";
            layoutControlItem9.Size = new System.Drawing.Size(746, 24);
            layoutControlItem9.Text = "Es inventariable?";
            layoutControlItem9.TextVisible = false;
            // 
            // errorProvider1
            // 
            errorProvider1.ContainerControl = this;
            // 
            // txtStockActual
            // 
            txtStockActual.Location = new System.Drawing.Point(93, 60);
            txtStockActual.Name = "txtStockActual";
            txtStockActual.Properties.EditFormat.FormatString = "N2";
            txtStockActual.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            txtStockActual.Properties.NullText = "0";
            txtStockActual.Properties.NullValuePrompt = "Stock Actual";
            txtStockActual.Size = new System.Drawing.Size(288, 20);
            txtStockActual.StyleController = layoutControl1;
            txtStockActual.TabIndex = 10;
            // 
            // layoutControlItem10
            // 
            layoutControlItem10.Control = txtStockActual;
            layoutControlItem10.Location = new System.Drawing.Point(0, 48);
            layoutControlItem10.Name = "layoutControlItem10";
            layoutControlItem10.Size = new System.Drawing.Size(373, 24);
            layoutControlItem10.Text = "Stock Actual";
            layoutControlItem10.TextSize = new System.Drawing.Size(69, 13);
            // 
            // ProductosFormView
            // 
            Appearance.BorderColor = System.Drawing.Color.Black;
            Appearance.Options.UseBorderColor = true;
            AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            CancelButton = btnCancelar;
            ClientSize = new System.Drawing.Size(766, 503);
            Controls.Add(layoutControl1);
            FormBorderEffect = DevExpress.XtraEditors.FormBorderEffect.Glow;
            Text = "ProductosFormView";
            Load += ProductosFormView_Load;
            Controls.SetChildIndex(labelControl1, 0);
            Controls.SetChildIndex(tablePanel1, 0);
            Controls.SetChildIndex(layoutControl1, 0);
            ((System.ComponentModel.ISupportInitialize)tablePanel1).EndInit();
            ((System.ComponentModel.ISupportInitialize)layoutControl1).EndInit();
            layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)txtCodigo.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)txtNombre.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)txtStockMinimo.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)txtPrecio.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)txtDescripcion.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)cmbUnidadMedida.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)cmbCategoria.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)txtImagen.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)chkInventariable.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)Root).EndInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem1).EndInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem2).EndInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem3).EndInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem4).EndInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem5).EndInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem6).EndInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem7).EndInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem8).EndInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem9).EndInit();
            ((System.ComponentModel.ISupportInitialize)errorProvider1).EndInit();
            ((System.ComponentModel.ISupportInitialize)txtStockActual.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem10).EndInit();
            ResumeLayout(false);
        }

        private DevExpress.XtraEditors.TextEdit txtStockActual;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem10;

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraEditors.TextEdit txtCodigo;
        private DevExpress.XtraEditors.TextEdit txtNombre;
        private DevExpress.XtraEditors.TextEdit txtStockMinimo;
        private DevExpress.XtraEditors.TextEdit txtPrecio;
        private DevExpress.XtraLayout.LayoutControlGroup Root;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraEditors.MemoEdit txtDescripcion;
        private DevExpress.XtraEditors.ComboBoxEdit cmbUnidadMedida;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem5;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem6;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem7;
        private DevExpress.XtraEditors.ComboBoxEdit cmbCategoria;
        private ErrorProvider errorProvider1;
        private DevExpress.XtraEditors.PictureEdit txtImagen;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem8;
        private DevExpress.XtraEditors.CheckEdit chkInventariable;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem9;
    }
}