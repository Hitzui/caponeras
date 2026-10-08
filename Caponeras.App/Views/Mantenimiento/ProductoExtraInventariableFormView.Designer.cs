namespace Caponeras.App.Views.Mantenimiento
{
    sealed partial class ProductoExtraInventariableFormView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ProductoExtraInventariableFormView));
            layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            cmbProveedor = new DevExpress.XtraEditors.LookUpEdit();
            proveedoresDtoBindingSource = new BindingSource(components);
            txtPrecio = new DevExpress.XtraEditors.TextEdit();
            txtCantidad = new DevExpress.XtraEditors.TextEdit();
            Root = new DevExpress.XtraLayout.LayoutControlGroup();
            layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)tablePanel1).BeginInit();
            tablePanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)layoutControl1).BeginInit();
            layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)cmbProveedor.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)proveedoresDtoBindingSource).BeginInit();
            ((System.ComponentModel.ISupportInitialize)txtPrecio.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)txtCantidad.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)Root).BeginInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem3).BeginInit();
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
            labelControl1.Size = new Size(531, 30);
            labelControl1.Text = "Producto no inventariable";
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
            btnAceptar.Location = new Point(366, 21);
            tablePanel1.SetRow(btnAceptar, 0);
            btnAceptar.Click += btnAceptar_Click;
            // 
            // tablePanel1
            // 
            tablePanel1.Location = new Point(0, 178);
            tablePanel1.Size = new Size(531, 79);
            // 
            // layoutControl1
            // 
            layoutControl1.Controls.Add(cmbProveedor);
            layoutControl1.Controls.Add(txtPrecio);
            layoutControl1.Controls.Add(txtCantidad);
            layoutControl1.Dock = DockStyle.Fill;
            layoutControl1.Location = new Point(0, 30);
            layoutControl1.Name = "layoutControl1";
            layoutControl1.Root = Root;
            layoutControl1.Size = new Size(531, 148);
            layoutControl1.TabIndex = 0;
            layoutControl1.Text = "layoutControl1";
            // 
            // cmbProveedor
            // 
            cmbProveedor.Location = new Point(70, 12);
            cmbProveedor.Name = "cmbProveedor";
            cmbProveedor.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo) });
            cmbProveedor.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] { new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Nombre", "Nombre", 46, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Near, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default), new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Ruc", "Ruc", 27, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Near, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default), new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Telefono", "Telefono", 51, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Near, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default), new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Email", "Email", 33, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Near, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default), new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Contacto", "Contacto", 53, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Near, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default) });
            cmbProveedor.Properties.DataSource = proveedoresDtoBindingSource;
            cmbProveedor.Properties.DisplayMember = "Nombre";
            cmbProveedor.Properties.NullText = "";
            cmbProveedor.Properties.PopupSizeable = false;
            cmbProveedor.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            cmbProveedor.Properties.ValueMember = "IdProveedor";
            cmbProveedor.Size = new Size(449, 20);
            cmbProveedor.StyleController = layoutControl1;
            cmbProveedor.TabIndex = 4;
            // 
            // proveedoresDtoBindingSource
            // 
            proveedoresDtoBindingSource.DataSource = typeof(Dto.ProveedoresDto);
            // 
            // txtPrecio
            // 
            txtPrecio.Location = new Point(70, 46);
            txtPrecio.Name = "txtPrecio";
            txtPrecio.Properties.BeepOnError = true;
            txtPrecio.Properties.MaskSettings.Set("MaskManagerType", typeof(DevExpress.Data.Mask.NumericMaskManager));
            txtPrecio.Properties.MaskSettings.Set("MaskManagerSignature", "allowNull=False");
            txtPrecio.Properties.MaskSettings.Set("mask", "n");
            txtPrecio.Properties.UseMaskAsDisplayFormat = true;
            txtPrecio.Size = new Size(449, 20);
            txtPrecio.StyleController = layoutControl1;
            txtPrecio.TabIndex = 5;
            // 
            // txtCantidad
            // 
            txtCantidad.Location = new Point(70, 80);
            txtCantidad.Name = "txtCantidad";
            txtCantidad.Properties.BeepOnError = true;
            txtCantidad.Properties.MaskSettings.Set("MaskManagerType", typeof(DevExpress.Data.Mask.NumericMaskManager));
            txtCantidad.Properties.MaskSettings.Set("MaskManagerSignature", "allowNull=False");
            txtCantidad.Properties.MaskSettings.Set("mask", "n");
            txtCantidad.Properties.UseMaskAsDisplayFormat = true;
            txtCantidad.Size = new Size(449, 20);
            txtCantidad.StyleController = layoutControl1;
            txtCantidad.TabIndex = 6;
            // 
            // Root
            // 
            Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            Root.GroupBordersVisible = false;
            Root.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] { layoutControlItem1, layoutControlItem2, layoutControlItem3 });
            Root.Name = "Root";
            Root.Size = new Size(531, 148);
            Root.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            layoutControlItem1.Control = cmbProveedor;
            layoutControlItem1.Location = new Point(0, 0);
            layoutControlItem1.Name = "layoutControlItem1";
            layoutControlItem1.Size = new Size(511, 24);
            layoutControlItem1.Text = "Proveedor:";
            layoutControlItem1.TextSize = new Size(54, 13);
            // 
            // layoutControlItem2
            // 
            layoutControlItem2.Control = txtPrecio;
            layoutControlItem2.Location = new Point(0, 24);
            layoutControlItem2.Name = "layoutControlItem2";
            layoutControlItem2.Size = new Size(511, 34);
            layoutControlItem2.Spacing = new DevExpress.XtraLayout.Utils.Padding(0, 0, 10, 0);
            layoutControlItem2.Text = "Precio:";
            layoutControlItem2.TextSize = new Size(54, 13);
            // 
            // layoutControlItem3
            // 
            layoutControlItem3.Control = txtCantidad;
            layoutControlItem3.Location = new Point(0, 58);
            layoutControlItem3.Name = "layoutControlItem3";
            layoutControlItem3.Size = new Size(511, 70);
            layoutControlItem3.Spacing = new DevExpress.XtraLayout.Utils.Padding(0, 0, 10, 0);
            layoutControlItem3.Text = "Cantidad:";
            layoutControlItem3.TextSize = new Size(54, 13);
            // 
            // ProductoExtraInventariableFormView
            // 
            AutoScaleDimensions = new SizeF(6F, 13F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(531, 257);
            Controls.Add(layoutControl1);
            Name = "ProductoExtraInventariableFormView";
            Text = "Producto No Inventariable";
            Load += ProductoExtraInventariableForm_Load;
            Controls.SetChildIndex(labelControl1, 0);
            Controls.SetChildIndex(tablePanel1, 0);
            Controls.SetChildIndex(layoutControl1, 0);
            ((System.ComponentModel.ISupportInitialize)tablePanel1).EndInit();
            tablePanel1.ResumeLayout(false);
            tablePanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)layoutControl1).EndInit();
            layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)cmbProveedor.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)proveedoresDtoBindingSource).EndInit();
            ((System.ComponentModel.ISupportInitialize)txtPrecio.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)txtCantidad.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)Root).EndInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem1).EndInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem2).EndInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem3).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraEditors.LookUpEdit cmbProveedor;
        private DevExpress.XtraLayout.LayoutControlGroup Root;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraEditors.TextEdit txtPrecio;
        private DevExpress.XtraEditors.TextEdit txtCantidad;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private BindingSource proveedoresDtoBindingSource;
    }
}