namespace Caponeras.App.Views.Compras
{
    sealed partial class ProductoDialogView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ProductoDialogView));
            gridControl1 = new DevExpress.XtraGrid.GridControl();
            productoDtoBindingSource = new BindingSource(components);
            gridViewProductos = new DevExpress.XtraGrid.Views.Grid.GridView();
            colCodigo = new DevExpress.XtraGrid.Columns.GridColumn();
            colNombre = new DevExpress.XtraGrid.Columns.GridColumn();
            colStockActual = new DevExpress.XtraGrid.Columns.GridColumn();
            colPrecioVenta = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)tablePanel1).BeginInit();
            tablePanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)gridControl1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)productoDtoBindingSource).BeginInit();
            ((System.ComponentModel.ISupportInitialize)gridViewProductos).BeginInit();
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
            labelControl1.Appearance.BackColor = Color.FromArgb(64, 64, 64);
            labelControl1.Appearance.Font = new Font("Tahoma", 12F, FontStyle.Bold);
            labelControl1.Appearance.ForeColor = Color.White;
            labelControl1.Appearance.Options.UseBackColor = true;
            labelControl1.Appearance.Options.UseFont = true;
            labelControl1.Appearance.Options.UseForeColor = true;
            labelControl1.Appearance.Options.UseTextOptions = true;
            labelControl1.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            labelControl1.Size = new Size(675, 30);
            labelControl1.Text = "Seleccionar Producto";
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
            btnAceptar.Location = new Point(463, 21);
            btnAceptar.Margin = new Padding(125, 3, 3, 3);
            tablePanel1.SetRow(btnAceptar, 0);
            btnAceptar.Click += btnAceptar_Click;
            // 
            // tablePanel1
            // 
            tablePanel1.Location = new Point(0, 360);
            tablePanel1.Size = new Size(675, 79);
            // 
            // gridControl1
            // 
            gridControl1.DataSource = productoDtoBindingSource;
            gridControl1.Dock = DockStyle.Fill;
            gridControl1.Location = new Point(0, 30);
            gridControl1.MainView = gridViewProductos;
            gridControl1.Name = "gridControl1";
            gridControl1.Size = new Size(675, 330);
            gridControl1.TabIndex = 6;
            gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] { gridViewProductos });
            // 
            // productoDtoBindingSource
            // 
            productoDtoBindingSource.DataSource = typeof(Dto.ProductoDto);
            // 
            // gridViewProductos
            // 
            gridViewProductos.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] { colCodigo, colNombre, colStockActual, colPrecioVenta });
            gridViewProductos.GridControl = gridControl1;
            gridViewProductos.Name = "gridViewProductos";
            gridViewProductos.OptionsBehavior.ReadOnly = true;
            // 
            // colCodigo
            // 
            colCodigo.FieldName = "Codigo";
            colCodigo.Name = "colCodigo";
            colCodigo.Visible = true;
            colCodigo.VisibleIndex = 0;
            // 
            // colNombre
            // 
            colNombre.FieldName = "Nombre";
            colNombre.Name = "colNombre";
            colNombre.Visible = true;
            colNombre.VisibleIndex = 1;
            // 
            // colStockActual
            // 
            colStockActual.FieldName = "StockActual";
            colStockActual.Name = "colStockActual";
            colStockActual.Visible = true;
            colStockActual.VisibleIndex = 2;
            // 
            // colPrecioVenta
            // 
            colPrecioVenta.Caption = "Costo unitario";
            colPrecioVenta.FieldName = "PrecioCosto";
            colPrecioVenta.Name = "colPrecioVenta";
            colPrecioVenta.Visible = true;
            colPrecioVenta.VisibleIndex = 3;
            // 
            // ProductoDialogView
            // 
            AutoScaleDimensions = new SizeF(6F, 13F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(675, 439);
            Controls.Add(gridControl1);
            Name = "ProductoDialogView";
            Text = "ProductoDialogView";
            Load += ProductoDialogView_Load;
            Controls.SetChildIndex(labelControl1, 0);
            Controls.SetChildIndex(tablePanel1, 0);
            Controls.SetChildIndex(gridControl1, 0);
            ((System.ComponentModel.ISupportInitialize)tablePanel1).EndInit();
            tablePanel1.ResumeLayout(false);
            tablePanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)gridControl1).EndInit();
            ((System.ComponentModel.ISupportInitialize)productoDtoBindingSource).EndInit();
            ((System.ComponentModel.ISupportInitialize)gridViewProductos).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DevExpress.XtraGrid.GridControl gridControl1;
        private BindingSource productoDtoBindingSource;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewProductos;
        private DevExpress.XtraGrid.Columns.GridColumn colCodigo;
        private DevExpress.XtraGrid.Columns.GridColumn colNombre;
        private DevExpress.XtraGrid.Columns.GridColumn colStockActual;
        private DevExpress.XtraGrid.Columns.GridColumn colPrecioVenta;
    }
}
