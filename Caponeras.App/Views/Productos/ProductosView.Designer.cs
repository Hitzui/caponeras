namespace Caponeras.App.Views.Productos
{
    sealed partial class ProductosView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ProductosView));
            gridControlProductos = new DevExpress.XtraGrid.GridControl();
            productoDtoBindingSource = new BindingSource(components);
            cardViewProductos = new DevExpress.XtraGrid.Views.Card.CardView();
            colCodigo = new DevExpress.XtraGrid.Columns.GridColumn();
            colNombre = new DevExpress.XtraGrid.Columns.GridColumn();
            colDescripcion = new DevExpress.XtraGrid.Columns.GridColumn();
            colStockMinimo = new DevExpress.XtraGrid.Columns.GridColumn();
            colStockActual = new DevExpress.XtraGrid.Columns.GridColumn();
            colPrecioCosto = new DevExpress.XtraGrid.Columns.GridColumn();
            colPrecioVenta = new DevExpress.XtraGrid.Columns.GridColumn();
            colUnidadesMedidas = new DevExpress.XtraGrid.Columns.GridColumn();
            colCategoriasProductos = new DevExpress.XtraGrid.Columns.GridColumn();
            colImagen = new DevExpress.XtraGrid.Columns.GridColumn();
            popupMenu1 = new DevExpress.XtraBars.PopupMenu(components);
            barButtonItemAdd = new DevExpress.XtraBars.BarButtonItem();
            barButtonItemEdit = new DevExpress.XtraBars.BarButtonItem();
            barButtonItemDelete = new DevExpress.XtraBars.BarButtonItem();
            barManager1 = new DevExpress.XtraBars.BarManager(components);
            barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            ((System.ComponentModel.ISupportInitialize)gridControlProductos).BeginInit();
            ((System.ComponentModel.ISupportInitialize)productoDtoBindingSource).BeginInit();
            ((System.ComponentModel.ISupportInitialize)cardViewProductos).BeginInit();
            ((System.ComponentModel.ISupportInitialize)popupMenu1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)barManager1).BeginInit();
            SuspendLayout();
            // 
            // gridControlProductos
            // 
            gridControlProductos.DataSource = productoDtoBindingSource;
            gridControlProductos.Dock = DockStyle.Fill;
            gridControlProductos.Location = new Point(0, 0);
            gridControlProductos.MainView = cardViewProductos;
            gridControlProductos.Name = "gridControlProductos";
            gridControlProductos.Size = new Size(681, 444);
            gridControlProductos.TabIndex = 0;
            gridControlProductos.UseEmbeddedNavigator = true;
            gridControlProductos.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] { cardViewProductos });
            // 
            // productoDtoBindingSource
            // 
            productoDtoBindingSource.DataSource = typeof(Dto.ProductoDto);
            // 
            // cardViewProductos
            // 
            cardViewProductos.Appearance.Card.BorderColor = Color.Gray;
            cardViewProductos.Appearance.Card.Options.UseBorderColor = true;
            cardViewProductos.Appearance.CardCaption.BackColor = Color.FromArgb(57, 62, 65);
            cardViewProductos.Appearance.CardCaption.ForeColor = Color.White;
            cardViewProductos.Appearance.CardCaption.Options.UseBackColor = true;
            cardViewProductos.Appearance.CardCaption.Options.UseForeColor = true;
            cardViewProductos.Appearance.FocusedCardCaption.BackColor = Color.FromArgb(88, 123, 127);
            cardViewProductos.Appearance.FocusedCardCaption.ForeColor = Color.White;
            cardViewProductos.Appearance.FocusedCardCaption.Options.UseBackColor = true;
            cardViewProductos.Appearance.FocusedCardCaption.Options.UseForeColor = true;
            cardViewProductos.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            cardViewProductos.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] { colCodigo, colNombre, colDescripcion, colStockMinimo, colStockActual, colPrecioCosto, colPrecioVenta, colUnidadesMedidas, colCategoriasProductos, colImagen });
            cardViewProductos.GridControl = gridControlProductos;
            cardViewProductos.Name = "cardViewProductos";
            cardViewProductos.OptionsBehavior.Editable = false;
            cardViewProductos.OptionsBehavior.FieldAutoHeight = true;
            cardViewProductos.OptionsBehavior.ReadOnly = true;
            cardViewProductos.OptionsFind.AlwaysVisible = true;
            cardViewProductos.OptionsView.ShowCardExpandButton = false;
            cardViewProductos.PaintStyleName = "UltraFlat";
            cardViewProductos.CustomDrawCardCaption += cardViewProductos_CustomDrawCardCaption;
            cardViewProductos.CustomDrawCardFieldCaption += cardViewProductos_CustomDrawCardFieldCaption;
            cardViewProductos.SelectionChanged += cardViewProductos_SelectionChanged;
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
            // colDescripcion
            // 
            colDescripcion.FieldName = "Descripcion";
            colDescripcion.Name = "colDescripcion";
            colDescripcion.Visible = true;
            colDescripcion.VisibleIndex = 2;
            // 
            // colStockMinimo
            // 
            colStockMinimo.FieldName = "StockMinimo";
            colStockMinimo.Name = "colStockMinimo";
            colStockMinimo.Visible = true;
            colStockMinimo.VisibleIndex = 4;
            // 
            // colStockActual
            // 
            colStockActual.FieldName = "StockActual";
            colStockActual.Name = "colStockActual";
            colStockActual.Visible = true;
            colStockActual.VisibleIndex = 3;
            // 
            // colPrecioCosto
            // 
            colPrecioCosto.FieldName = "PrecioCosto";
            colPrecioCosto.Name = "colPrecioCosto";
            colPrecioCosto.Visible = true;
            colPrecioCosto.VisibleIndex = 5;
            // 
            // colPrecioVenta
            // 
            colPrecioVenta.FieldName = "PrecioVenta";
            colPrecioVenta.Name = "colPrecioVenta";
            colPrecioVenta.Visible = true;
            colPrecioVenta.VisibleIndex = 6;
            // 
            // colUnidadesMedidas
            // 
            colUnidadesMedidas.Caption = "UM";
            colUnidadesMedidas.FieldName = "UnidadesMedidas";
            colUnidadesMedidas.Name = "colUnidadesMedidas";
            colUnidadesMedidas.Visible = true;
            colUnidadesMedidas.VisibleIndex = 7;
            // 
            // colCategoriasProductos
            // 
            colCategoriasProductos.Caption = "Categoria";
            colCategoriasProductos.FieldName = "CategoriasProductos";
            colCategoriasProductos.Name = "colCategoriasProductos";
            colCategoriasProductos.Visible = true;
            colCategoriasProductos.VisibleIndex = 8;
            // 
            // colImagen
            // 
            colImagen.FieldName = "Imagen";
            colImagen.Name = "colImagen";
            colImagen.OptionsColumn.FixedWidth = true;
            colImagen.Visible = true;
            colImagen.VisibleIndex = 9;
            colImagen.Width = 150;
            // 
            // popupMenu1
            // 
            popupMenu1.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] { new DevExpress.XtraBars.LinkPersistInfo(barButtonItemAdd), new DevExpress.XtraBars.LinkPersistInfo(barButtonItemEdit), new DevExpress.XtraBars.LinkPersistInfo(barButtonItemDelete) });
            popupMenu1.Manager = barManager1;
            popupMenu1.Name = "popupMenu1";
            // 
            // barButtonItemAdd
            // 
            barButtonItemAdd.Caption = "Agregar";
            barButtonItemAdd.Id = 0;
            barButtonItemAdd.ImageOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("barButtonItemAdd.ImageOptions.SvgImage");
            barButtonItemAdd.Name = "barButtonItemAdd";
            barButtonItemAdd.ItemClick += barButtonItemAdd_ItemClick;
            // 
            // barButtonItemEdit
            // 
            barButtonItemEdit.Caption = "Editar";
            barButtonItemEdit.Id = 1;
            barButtonItemEdit.ImageOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("barButtonItemEdit.ImageOptions.SvgImage");
            barButtonItemEdit.Name = "barButtonItemEdit";
            barButtonItemEdit.ItemClick += barButtonItemEdit_ItemClick;
            // 
            // barButtonItemDelete
            // 
            barButtonItemDelete.Caption = "Eliminar";
            barButtonItemDelete.Id = 2;
            barButtonItemDelete.ImageOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("barButtonItemDelete.ImageOptions.SvgImage");
            barButtonItemDelete.Name = "barButtonItemDelete";
            barButtonItemDelete.ItemClick += barButtonItemDelete_ItemClick;
            // 
            // barManager1
            // 
            barManager1.DockControls.Add(barDockControlTop);
            barManager1.DockControls.Add(barDockControlBottom);
            barManager1.DockControls.Add(barDockControlLeft);
            barManager1.DockControls.Add(barDockControlRight);
            barManager1.Form = this;
            barManager1.Items.AddRange(new DevExpress.XtraBars.BarItem[] { barButtonItemAdd, barButtonItemEdit, barButtonItemDelete });
            barManager1.MaxItemId = 3;
            // 
            // barDockControlTop
            // 
            barDockControlTop.CausesValidation = false;
            barDockControlTop.Dock = DockStyle.Top;
            barDockControlTop.Location = new Point(0, 0);
            barDockControlTop.Manager = barManager1;
            barDockControlTop.Size = new Size(681, 0);
            // 
            // barDockControlBottom
            // 
            barDockControlBottom.CausesValidation = false;
            barDockControlBottom.Dock = DockStyle.Bottom;
            barDockControlBottom.Location = new Point(0, 444);
            barDockControlBottom.Manager = barManager1;
            barDockControlBottom.Size = new Size(681, 0);
            // 
            // barDockControlLeft
            // 
            barDockControlLeft.CausesValidation = false;
            barDockControlLeft.Dock = DockStyle.Left;
            barDockControlLeft.Location = new Point(0, 0);
            barDockControlLeft.Manager = barManager1;
            barDockControlLeft.Size = new Size(0, 444);
            // 
            // barDockControlRight
            // 
            barDockControlRight.CausesValidation = false;
            barDockControlRight.Dock = DockStyle.Right;
            barDockControlRight.Location = new Point(681, 0);
            barDockControlRight.Manager = barManager1;
            barDockControlRight.Size = new Size(0, 444);
            // 
            // ProductosView
            // 
            AutoScaleDimensions = new SizeF(6F, 13F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(681, 444);
            Controls.Add(gridControlProductos);
            Controls.Add(barDockControlLeft);
            Controls.Add(barDockControlRight);
            Controls.Add(barDockControlBottom);
            Controls.Add(barDockControlTop);
            IconOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("ProductosView.IconOptions.SvgImage");
            LookAndFeel.SkinName = "WXI";
            LookAndFeel.UseDefaultLookAndFeel = false;
            Name = "ProductosView";
            Text = "Productos";
            Load += ProductosView_Load;
            ((System.ComponentModel.ISupportInitialize)gridControlProductos).EndInit();
            ((System.ComponentModel.ISupportInitialize)productoDtoBindingSource).EndInit();
            ((System.ComponentModel.ISupportInitialize)cardViewProductos).EndInit();
            ((System.ComponentModel.ISupportInitialize)popupMenu1).EndInit();
            ((System.ComponentModel.ISupportInitialize)barManager1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DevExpress.XtraGrid.GridControl gridControlProductos;
        private BindingSource productoDtoBindingSource;
        private DevExpress.XtraBars.PopupMenu popupMenu1;
        private DevExpress.XtraBars.BarButtonItem barButtonItemAdd;
        private DevExpress.XtraBars.BarButtonItem barButtonItemEdit;
        private DevExpress.XtraBars.BarButtonItem barButtonItemDelete;
        private DevExpress.XtraBars.BarManager barManager1;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraGrid.Views.Card.CardView cardViewProductos;
        private DevExpress.XtraGrid.Columns.GridColumn colCodigo;
        private DevExpress.XtraGrid.Columns.GridColumn colNombre;
        private DevExpress.XtraGrid.Columns.GridColumn colDescripcion;
        private DevExpress.XtraGrid.Columns.GridColumn colStockMinimo;
        private DevExpress.XtraGrid.Columns.GridColumn colStockActual;
        private DevExpress.XtraGrid.Columns.GridColumn colPrecioCosto;
        private DevExpress.XtraGrid.Columns.GridColumn colPrecioVenta;
        private DevExpress.XtraGrid.Columns.GridColumn colUnidadesMedidas;
        private DevExpress.XtraGrid.Columns.GridColumn colCategoriasProductos;
        private DevExpress.XtraGrid.Columns.GridColumn colImagen;
    }
}