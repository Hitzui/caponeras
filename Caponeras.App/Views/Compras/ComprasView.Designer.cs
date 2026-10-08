namespace Caponeras.App.Views.Compras
{
    sealed partial class ComprasView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ComprasView));
            gridControlCompras = new DevExpress.XtraGrid.GridControl();
            comprasDtoBindingSource = new BindingSource(components);
            gridViewCompras = new DevExpress.XtraGrid.Views.Grid.GridView();
            colNombreProveedor = new DevExpress.XtraGrid.Columns.GridColumn();
            colFecha = new DevExpress.XtraGrid.Columns.GridColumn();
            colNumeroDocumento = new DevExpress.XtraGrid.Columns.GridColumn();
            colTotal = new DevExpress.XtraGrid.Columns.GridColumn();
            colSubtotal = new DevExpress.XtraGrid.Columns.GridColumn();
            colIva = new DevExpress.XtraGrid.Columns.GridColumn();
            colEstado = new DevExpress.XtraGrid.Columns.GridColumn();
            popupMenuCompras = new DevExpress.XtraBars.PopupMenu(components);
            barButtonItemAgregar = new DevExpress.XtraBars.BarButtonItem();
            barButtonItemEditar = new DevExpress.XtraBars.BarButtonItem();
            barButtonItemDelete = new DevExpress.XtraBars.BarButtonItem();
            barButtonItemPayment = new DevExpress.XtraBars.BarButtonItem();
            barManager1 = new DevExpress.XtraBars.BarManager(components);
            barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            ((System.ComponentModel.ISupportInitialize)gridControlCompras).BeginInit();
            ((System.ComponentModel.ISupportInitialize)comprasDtoBindingSource).BeginInit();
            ((System.ComponentModel.ISupportInitialize)gridViewCompras).BeginInit();
            ((System.ComponentModel.ISupportInitialize)popupMenuCompras).BeginInit();
            ((System.ComponentModel.ISupportInitialize)barManager1).BeginInit();
            SuspendLayout();
            // 
            // gridControlCompras
            // 
            gridControlCompras.DataSource = comprasDtoBindingSource;
            gridControlCompras.Dock = DockStyle.Fill;
            gridControlCompras.Location = new Point(0, 0);
            gridControlCompras.MainView = gridViewCompras;
            gridControlCompras.Name = "gridControlCompras";
            gridControlCompras.Size = new Size(832, 527);
            gridControlCompras.TabIndex = 0;
            gridControlCompras.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] { gridViewCompras });
            // 
            // comprasDtoBindingSource
            // 
            comprasDtoBindingSource.DataSource = typeof(Dto.ComprasDto);
            // 
            // gridViewCompras
            // 
            gridViewCompras.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] { colNombreProveedor, colFecha, colNumeroDocumento, colTotal, colSubtotal, colIva, colEstado });
            gridViewCompras.GridControl = gridControlCompras;
            gridViewCompras.Name = "gridViewCompras";
            gridViewCompras.OptionsBehavior.Editable = false;
            gridViewCompras.OptionsBehavior.ReadOnly = true;
            gridViewCompras.PopupMenuShowing += gridViewCompras_PopupMenuShowing;
            gridViewCompras.SelectionChanged += gridViewCompras_SelectionChanged;
            gridViewCompras.FocusedRowChanged += gridViewCompras_FocusedRowChanged;
            // 
            // colNombreProveedor
            // 
            colNombreProveedor.FieldName = "NombreProveedor";
            colNombreProveedor.Name = "colNombreProveedor";
            colNombreProveedor.Visible = true;
            colNombreProveedor.VisibleIndex = 0;
            // 
            // colFecha
            // 
            colFecha.FieldName = "Fecha";
            colFecha.Name = "colFecha";
            colFecha.Visible = true;
            colFecha.VisibleIndex = 1;
            // 
            // colNumeroDocumento
            // 
            colNumeroDocumento.FieldName = "NumeroDocumento";
            colNumeroDocumento.Name = "colNumeroDocumento";
            colNumeroDocumento.Visible = true;
            colNumeroDocumento.VisibleIndex = 2;
            // 
            // colTotal
            // 
            colTotal.FieldName = "Total";
            colTotal.Name = "colTotal";
            colTotal.Visible = true;
            colTotal.VisibleIndex = 3;
            // 
            // colSubtotal
            // 
            colSubtotal.FieldName = "Subtotal";
            colSubtotal.Name = "colSubtotal";
            colSubtotal.Visible = true;
            colSubtotal.VisibleIndex = 4;
            // 
            // colIva
            // 
            colIva.FieldName = "Iva";
            colIva.Name = "colIva";
            colIva.Visible = true;
            colIva.VisibleIndex = 5;
            // 
            // colEstado
            // 
            colEstado.FieldName = "Estado";
            colEstado.Name = "colEstado";
            colEstado.Visible = true;
            colEstado.VisibleIndex = 6;
            // 
            // popupMenuCompras
            // 
            popupMenuCompras.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] { new DevExpress.XtraBars.LinkPersistInfo(barButtonItemAgregar), new DevExpress.XtraBars.LinkPersistInfo(barButtonItemEditar), new DevExpress.XtraBars.LinkPersistInfo(barButtonItemDelete), new DevExpress.XtraBars.LinkPersistInfo(barButtonItemPayment) });
            popupMenuCompras.Manager = barManager1;
            popupMenuCompras.Name = "popupMenuCompras";
            // 
            // barButtonItemAgregar
            // 
            barButtonItemAgregar.Caption = "Ingresar";
            barButtonItemAgregar.Id = 0;
            barButtonItemAgregar.ImageOptions.AllowGlyphSkinning = DevExpress.Utils.DefaultBoolean.True;
            barButtonItemAgregar.ImageOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("barButtonItemAgregar.ImageOptions.SvgImage");
            barButtonItemAgregar.Name = "barButtonItemAgregar";
            barButtonItemAgregar.ItemClick += barButtonItemAgregar_ItemClick;
            // 
            // barButtonItemEditar
            // 
            barButtonItemEditar.Caption = "Editar";
            barButtonItemEditar.Id = 1;
            barButtonItemEditar.ImageOptions.AllowGlyphSkinning = DevExpress.Utils.DefaultBoolean.True;
            barButtonItemEditar.ImageOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("barButtonItemEditar.ImageOptions.SvgImage");
            barButtonItemEditar.Name = "barButtonItemEditar";
            barButtonItemEditar.ItemClick += barButtonItemEditar_ItemClick;
            // 
            // barButtonItemDelete
            // 
            barButtonItemDelete.Caption = "Eliminar";
            barButtonItemDelete.Id = 2;
            barButtonItemDelete.ImageOptions.AllowGlyphSkinning = DevExpress.Utils.DefaultBoolean.True;
            barButtonItemDelete.ImageOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("barButtonItemDelete.ImageOptions.SvgImage");
            barButtonItemDelete.Name = "barButtonItemDelete";
            barButtonItemDelete.ItemClick += barButtonItemDelete_ItemClick;
            // 
            // barButtonItemPayment
            // 
            barButtonItemPayment.Caption = "Pagar";
            barButtonItemPayment.Id = 3;
            barButtonItemPayment.ImageOptions.AllowGlyphSkinning = DevExpress.Utils.DefaultBoolean.True;
            barButtonItemPayment.ImageOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("barButtonItemPayment.ImageOptions.SvgImage");
            barButtonItemPayment.Name = "barButtonItemPayment";
            barButtonItemPayment.ItemClick += barButtonItemPayment_ItemClick;
            // 
            // barManager1
            // 
            barManager1.DockControls.Add(barDockControlTop);
            barManager1.DockControls.Add(barDockControlBottom);
            barManager1.DockControls.Add(barDockControlLeft);
            barManager1.DockControls.Add(barDockControlRight);
            barManager1.Form = this;
            barManager1.Items.AddRange(new DevExpress.XtraBars.BarItem[] { barButtonItemAgregar, barButtonItemEditar, barButtonItemDelete, barButtonItemPayment });
            barManager1.MaxItemId = 4;
            // 
            // barDockControlTop
            // 
            barDockControlTop.CausesValidation = false;
            barDockControlTop.Dock = DockStyle.Top;
            barDockControlTop.Location = new Point(0, 0);
            barDockControlTop.Manager = barManager1;
            barDockControlTop.Size = new Size(832, 0);
            // 
            // barDockControlBottom
            // 
            barDockControlBottom.CausesValidation = false;
            barDockControlBottom.Dock = DockStyle.Bottom;
            barDockControlBottom.Location = new Point(0, 527);
            barDockControlBottom.Manager = barManager1;
            barDockControlBottom.Size = new Size(832, 0);
            // 
            // barDockControlLeft
            // 
            barDockControlLeft.CausesValidation = false;
            barDockControlLeft.Dock = DockStyle.Left;
            barDockControlLeft.Location = new Point(0, 0);
            barDockControlLeft.Manager = barManager1;
            barDockControlLeft.Size = new Size(0, 527);
            // 
            // barDockControlRight
            // 
            barDockControlRight.CausesValidation = false;
            barDockControlRight.Dock = DockStyle.Right;
            barDockControlRight.Location = new Point(832, 0);
            barDockControlRight.Manager = barManager1;
            barDockControlRight.Size = new Size(0, 527);
            // 
            // ComprasView
            // 
            AutoScaleDimensions = new SizeF(6F, 13F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(832, 527);
            Controls.Add(gridControlCompras);
            Controls.Add(barDockControlLeft);
            Controls.Add(barDockControlRight);
            Controls.Add(barDockControlBottom);
            Controls.Add(barDockControlTop);
            IconOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("ComprasView.IconOptions.SvgImage");
            Name = "ComprasView";
            Text = "Compras";
            Load += ComprasView_Load;
            ((System.ComponentModel.ISupportInitialize)gridControlCompras).EndInit();
            ((System.ComponentModel.ISupportInitialize)comprasDtoBindingSource).EndInit();
            ((System.ComponentModel.ISupportInitialize)gridViewCompras).EndInit();
            ((System.ComponentModel.ISupportInitialize)popupMenuCompras).EndInit();
            ((System.ComponentModel.ISupportInitialize)barManager1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DevExpress.XtraGrid.GridControl gridControlCompras;
        private BindingSource comprasDtoBindingSource;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewCompras;
        private DevExpress.XtraGrid.Columns.GridColumn colNombreProveedor;
        private DevExpress.XtraGrid.Columns.GridColumn colFecha;
        private DevExpress.XtraGrid.Columns.GridColumn colNumeroDocumento;
        private DevExpress.XtraGrid.Columns.GridColumn colTotal;
        private DevExpress.XtraGrid.Columns.GridColumn colSubtotal;
        private DevExpress.XtraGrid.Columns.GridColumn colIva;
        private DevExpress.XtraGrid.Columns.GridColumn colEstado;
        private DevExpress.XtraBars.PopupMenu popupMenuCompras;
        private DevExpress.XtraBars.BarButtonItem barButtonItemAgregar;
        private DevExpress.XtraBars.BarButtonItem barButtonItemEditar;
        private DevExpress.XtraBars.BarButtonItem barButtonItemDelete;
        private DevExpress.XtraBars.BarButtonItem barButtonItemPayment;
        private DevExpress.XtraBars.BarManager barManager1;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
    }
}