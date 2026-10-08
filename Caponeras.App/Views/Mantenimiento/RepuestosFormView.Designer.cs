namespace Caponeras.App.Views.Mantenimiento
{
    partial class RepuestosFormView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RepuestosFormView));
            stackPanel1 = new DevExpress.Utils.Layout.StackPanel();
            lblTitulo = new Label();
            stackPanel2 = new DevExpress.Utils.Layout.StackPanel();
            btnAplicar = new DevExpress.XtraEditors.SimpleButton();
            btnCancelar = new DevExpress.XtraEditors.SimpleButton();
            tablePanel1 = new DevExpress.Utils.Layout.TablePanel();
            gridControlRepuestos = new DevExpress.XtraGrid.GridControl();
            mantenimientoRepuestoDtoBindingSource = new BindingSource(components);
            gridViewRepuestos = new DevExpress.XtraGrid.Views.Grid.GridView();
            colProductoNombre = new DevExpress.XtraGrid.Columns.GridColumn();
            colCantidad = new DevExpress.XtraGrid.Columns.GridColumn();
            colObservaciones = new DevExpress.XtraGrid.Columns.GridColumn();
            gridControlProductos = new DevExpress.XtraGrid.GridControl();
            productoDtoBindingSource = new BindingSource(components);
            gridViewProductos = new DevExpress.XtraGrid.Views.Grid.GridView();
            colCodigo = new DevExpress.XtraGrid.Columns.GridColumn();
            colNombre = new DevExpress.XtraGrid.Columns.GridColumn();
            colStockActual = new DevExpress.XtraGrid.Columns.GridColumn();
            colPrecioVenta = new DevExpress.XtraGrid.Columns.GridColumn();
            behaviorManager1 = new DevExpress.Utils.Behaviors.BehaviorManager(components);
            dragDropEventsRepuestos = new DevExpress.Utils.DragDrop.DragDropEvents(components);
            dragDropEventsProductos = new DevExpress.Utils.DragDrop.DragDropEvents(components);
            popupMenu1 = new DevExpress.XtraBars.PopupMenu(components);
            barButtonItemDeleteRepuesto = new DevExpress.XtraBars.BarButtonItem();
            barManager1 = new DevExpress.XtraBars.BarManager(components);
            barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            ((System.ComponentModel.ISupportInitialize)stackPanel1).BeginInit();
            stackPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)stackPanel2).BeginInit();
            stackPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)tablePanel1).BeginInit();
            tablePanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)gridControlRepuestos).BeginInit();
            ((System.ComponentModel.ISupportInitialize)mantenimientoRepuestoDtoBindingSource).BeginInit();
            ((System.ComponentModel.ISupportInitialize)gridViewRepuestos).BeginInit();
            ((System.ComponentModel.ISupportInitialize)gridControlProductos).BeginInit();
            ((System.ComponentModel.ISupportInitialize)productoDtoBindingSource).BeginInit();
            ((System.ComponentModel.ISupportInitialize)gridViewProductos).BeginInit();
            ((System.ComponentModel.ISupportInitialize)behaviorManager1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)popupMenu1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)barManager1).BeginInit();
            SuspendLayout();
            // 
            // stackPanel1
            // 
            stackPanel1.Controls.Add(lblTitulo);
            stackPanel1.Dock = DockStyle.Top;
            stackPanel1.Location = new Point(0, 0);
            stackPanel1.Name = "stackPanel1";
            stackPanel1.Size = new Size(1121, 89);
            stackPanel1.TabIndex = 0;
            stackPanel1.UseSkinIndents = true;
            // 
            // lblTitulo
            // 
            lblTitulo.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            lblTitulo.BackColor = Color.FromArgb(64, 64, 64);
            lblTitulo.FlatStyle = FlatStyle.Flat;
            lblTitulo.Font = new Font("Tahoma", 11F, FontStyle.Bold);
            lblTitulo.ForeColor = Color.White;
            lblTitulo.Location = new Point(14, 23);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(1093, 42);
            stackPanel1.SetStretched(lblTitulo, true);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "Repuestos sobre Mantenimiento";
            lblTitulo.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // stackPanel2
            // 
            stackPanel2.Controls.Add(btnAplicar);
            stackPanel2.Controls.Add(btnCancelar);
            stackPanel2.Dock = DockStyle.Bottom;
            stackPanel2.LayoutDirection = DevExpress.Utils.Layout.StackPanelLayoutDirection.RightToLeft;
            stackPanel2.Location = new Point(0, 562);
            stackPanel2.Name = "stackPanel2";
            stackPanel2.Size = new Size(1121, 101);
            stackPanel2.TabIndex = 1;
            stackPanel2.UseSkinIndents = true;
            // 
            // btnAplicar
            // 
            btnAplicar.Appearance.BackColor = Color.Green;
            btnAplicar.Appearance.ForeColor = Color.White;
            btnAplicar.Appearance.Options.UseBackColor = true;
            btnAplicar.Appearance.Options.UseForeColor = true;
            btnAplicar.ImageOptions.AllowGlyphSkinning = DevExpress.Utils.DefaultBoolean.True;
            btnAplicar.ImageOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("btnAplicar.ImageOptions.SvgImage");
            btnAplicar.Location = new Point(882, 28);
            btnAplicar.Margin = new Padding(3, 3, 100, 3);
            btnAplicar.Name = "btnAplicar";
            btnAplicar.Size = new Size(128, 44);
            btnAplicar.TabIndex = 0;
            btnAplicar.Text = "Aplicar";
            btnAplicar.Click += btnAplicar_Click;
            // 
            // btnCancelar
            // 
            btnCancelar.Appearance.BackColor = Color.FromArgb(192, 0, 0);
            btnCancelar.Appearance.ForeColor = Color.White;
            btnCancelar.Appearance.Options.UseBackColor = true;
            btnCancelar.Appearance.Options.UseForeColor = true;
            btnCancelar.ImageOptions.AllowGlyphSkinning = DevExpress.Utils.DefaultBoolean.True;
            btnCancelar.ImageOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("btnCancelar.ImageOptions.SvgImage");
            btnCancelar.Location = new Point(351, 28);
            btnCancelar.Margin = new Padding(3, 3, 400, 3);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(128, 44);
            btnCancelar.TabIndex = 1;
            btnCancelar.Text = "Cancelar";
            btnCancelar.Click += btnCancelar_Click;
            // 
            // tablePanel1
            // 
            tablePanel1.AutoScroll = true;
            tablePanel1.Columns.AddRange(new DevExpress.Utils.Layout.TablePanelColumn[] { new DevExpress.Utils.Layout.TablePanelColumn(DevExpress.Utils.Layout.TablePanelEntityStyle.Relative, 50F), new DevExpress.Utils.Layout.TablePanelColumn(DevExpress.Utils.Layout.TablePanelEntityStyle.Relative, 50F) });
            tablePanel1.Controls.Add(gridControlRepuestos);
            tablePanel1.Controls.Add(gridControlProductos);
            tablePanel1.Dock = DockStyle.Fill;
            tablePanel1.Location = new Point(0, 89);
            tablePanel1.Name = "tablePanel1";
            tablePanel1.Rows.AddRange(new DevExpress.Utils.Layout.TablePanelRow[] { new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.Absolute, 21F), new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.Absolute, 26F) });
            tablePanel1.Size = new Size(1121, 473);
            tablePanel1.TabIndex = 2;
            tablePanel1.UseSkinIndents = true;
            // 
            // gridControlRepuestos
            // 
            tablePanel1.SetColumn(gridControlRepuestos, 1);
            gridControlRepuestos.DataSource = mantenimientoRepuestoDtoBindingSource;
            gridControlRepuestos.Dock = DockStyle.Fill;
            gridControlRepuestos.Location = new Point(563, 33);
            gridControlRepuestos.MainView = gridViewRepuestos;
            gridControlRepuestos.Name = "gridControlRepuestos";
            tablePanel1.SetRow(gridControlRepuestos, 1);
            gridControlRepuestos.Size = new Size(546, 427);
            gridControlRepuestos.TabIndex = 1;
            gridControlRepuestos.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] { gridViewRepuestos });
            // 
            // mantenimientoRepuestoDtoBindingSource
            // 
            mantenimientoRepuestoDtoBindingSource.DataSource = typeof(Dto.MantenimientoRepuestoDto);
            // 
            // gridViewRepuestos
            // 
            behaviorManager1.SetBehaviors(gridViewRepuestos, new DevExpress.Utils.Behaviors.Behavior[] { DevExpress.Utils.DragDrop.DragDropBehavior.Create(typeof(DevExpress.XtraGrid.Extensions.ColumnViewDragDropSource), true, true, true, true, dragDropEventsRepuestos) });
            gridViewRepuestos.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] { colProductoNombre, colCantidad, colObservaciones });
            gridViewRepuestos.GridControl = gridControlRepuestos;
            gridViewRepuestos.Name = "gridViewRepuestos";
            gridViewRepuestos.PopupMenuShowing += gridViewRepuestos_PopupMenuShowing;
            gridViewRepuestos.ShowingEditor += gridViewRepuestos_ShowingEditor;
            gridViewRepuestos.KeyDown += gridViewRepuestos_KeyDown;
            gridViewRepuestos.ValidatingEditor += gridViewRepuestos_ValidatingEditor;
            // 
            // colProductoNombre
            // 
            colProductoNombre.FieldName = "ProductoNombre";
            colProductoNombre.Name = "colProductoNombre";
            colProductoNombre.OptionsColumn.AllowEdit = false;
            colProductoNombre.Visible = true;
            colProductoNombre.VisibleIndex = 2;
            // 
            // colCantidad
            // 
            colCantidad.FieldName = "Cantidad";
            colCantidad.Name = "colCantidad";
            colCantidad.Visible = true;
            colCantidad.VisibleIndex = 0;
            // 
            // colObservaciones
            // 
            colObservaciones.FieldName = "Observaciones";
            colObservaciones.Name = "colObservaciones";
            colObservaciones.Visible = true;
            colObservaciones.VisibleIndex = 1;
            // 
            // gridControlProductos
            // 
            tablePanel1.SetColumn(gridControlProductos, 0);
            gridControlProductos.DataSource = productoDtoBindingSource;
            gridControlProductos.Dock = DockStyle.Fill;
            gridControlProductos.Location = new Point(13, 33);
            gridControlProductos.MainView = gridViewProductos;
            gridControlProductos.Name = "gridControlProductos";
            tablePanel1.SetRow(gridControlProductos, 1);
            gridControlProductos.Size = new Size(546, 427);
            gridControlProductos.TabIndex = 0;
            gridControlProductos.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] { gridViewProductos });
            // 
            // productoDtoBindingSource
            // 
            productoDtoBindingSource.DataSource = typeof(Dto.ProductoDto);
            // 
            // gridViewProductos
            // 
            behaviorManager1.SetBehaviors(gridViewProductos, new DevExpress.Utils.Behaviors.Behavior[] { DevExpress.Utils.DragDrop.DragDropBehavior.Create(typeof(DevExpress.XtraGrid.Extensions.ColumnViewDragDropSource), true, false, false, true, dragDropEventsProductos) });
            gridViewProductos.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] { colCodigo, colNombre, colStockActual, colPrecioVenta });
            gridViewProductos.GridControl = gridControlProductos;
            gridViewProductos.Name = "gridViewProductos";
            gridViewProductos.OptionsBehavior.Editable = false;
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
            colPrecioVenta.FieldName = "PrecioVenta";
            colPrecioVenta.Name = "colPrecioVenta";
            colPrecioVenta.Visible = true;
            colPrecioVenta.VisibleIndex = 3;
            // 
            // popupMenu1
            // 
            popupMenu1.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] { new DevExpress.XtraBars.LinkPersistInfo(barButtonItemDeleteRepuesto) });
            popupMenu1.Manager = barManager1;
            popupMenu1.Name = "popupMenu1";
            // 
            // barButtonItemDeleteRepuesto
            // 
            barButtonItemDeleteRepuesto.Caption = "Eliminar";
            barButtonItemDeleteRepuesto.Id = 0;
            barButtonItemDeleteRepuesto.ImageOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("barButtonItemDeleteRepuesto.ImageOptions.SvgImage");
            barButtonItemDeleteRepuesto.Name = "barButtonItemDeleteRepuesto";
            barButtonItemDeleteRepuesto.ItemClick += barButtonItemDeleteRepuesto_ItemClick;
            // 
            // barManager1
            // 
            barManager1.DockControls.Add(barDockControlTop);
            barManager1.DockControls.Add(barDockControlBottom);
            barManager1.DockControls.Add(barDockControlLeft);
            barManager1.DockControls.Add(barDockControlRight);
            barManager1.Form = this;
            barManager1.Items.AddRange(new DevExpress.XtraBars.BarItem[] { barButtonItemDeleteRepuesto });
            barManager1.MaxItemId = 1;
            // 
            // barDockControlTop
            // 
            barDockControlTop.CausesValidation = false;
            barDockControlTop.Dock = DockStyle.Top;
            barDockControlTop.Location = new Point(0, 0);
            barDockControlTop.Manager = barManager1;
            barDockControlTop.Size = new Size(1121, 0);
            // 
            // barDockControlBottom
            // 
            barDockControlBottom.CausesValidation = false;
            barDockControlBottom.Dock = DockStyle.Bottom;
            barDockControlBottom.Location = new Point(0, 663);
            barDockControlBottom.Manager = barManager1;
            barDockControlBottom.Size = new Size(1121, 0);
            // 
            // barDockControlLeft
            // 
            barDockControlLeft.CausesValidation = false;
            barDockControlLeft.Dock = DockStyle.Left;
            barDockControlLeft.Location = new Point(0, 0);
            barDockControlLeft.Manager = barManager1;
            barDockControlLeft.Size = new Size(0, 663);
            // 
            // barDockControlRight
            // 
            barDockControlRight.CausesValidation = false;
            barDockControlRight.Dock = DockStyle.Right;
            barDockControlRight.Location = new Point(1121, 0);
            barDockControlRight.Manager = barManager1;
            barDockControlRight.Size = new Size(0, 663);
            // 
            // RepuestosFormView
            // 
            AutoScaleDimensions = new SizeF(6F, 13F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1121, 663);
            Controls.Add(tablePanel1);
            Controls.Add(stackPanel2);
            Controls.Add(stackPanel1);
            Controls.Add(barDockControlLeft);
            Controls.Add(barDockControlRight);
            Controls.Add(barDockControlBottom);
            Controls.Add(barDockControlTop);
            IconOptions.Image = Properties.Resources.repair_16325030;
            MinimizeBox = false;
            Name = "RepuestosFormView";
            Text = "Repuestos";
            Load += RepuestosFormView_Load;
            ((System.ComponentModel.ISupportInitialize)stackPanel1).EndInit();
            stackPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)stackPanel2).EndInit();
            stackPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)tablePanel1).EndInit();
            tablePanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)gridControlRepuestos).EndInit();
            ((System.ComponentModel.ISupportInitialize)mantenimientoRepuestoDtoBindingSource).EndInit();
            ((System.ComponentModel.ISupportInitialize)gridViewRepuestos).EndInit();
            ((System.ComponentModel.ISupportInitialize)gridControlProductos).EndInit();
            ((System.ComponentModel.ISupportInitialize)productoDtoBindingSource).EndInit();
            ((System.ComponentModel.ISupportInitialize)gridViewProductos).EndInit();
            ((System.ComponentModel.ISupportInitialize)behaviorManager1).EndInit();
            ((System.ComponentModel.ISupportInitialize)popupMenu1).EndInit();
            ((System.ComponentModel.ISupportInitialize)barManager1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DevExpress.Utils.Layout.StackPanel stackPanel1;
        private DevExpress.Utils.Layout.StackPanel stackPanel2;
        private DevExpress.Utils.Layout.TablePanel tablePanel1;
        private DevExpress.XtraGrid.GridControl gridControlRepuestos;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewRepuestos;
        private DevExpress.XtraGrid.GridControl gridControlProductos;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewProductos;
        private BindingSource productoDtoBindingSource;
        private DevExpress.XtraGrid.Columns.GridColumn colCodigo;
        private DevExpress.XtraGrid.Columns.GridColumn colNombre;
        private DevExpress.XtraGrid.Columns.GridColumn colStockActual;
        private DevExpress.XtraGrid.Columns.GridColumn colPrecioVenta;
        private BindingSource mantenimientoRepuestoDtoBindingSource;
        private DevExpress.XtraGrid.Columns.GridColumn colProductoNombre;
        private DevExpress.XtraGrid.Columns.GridColumn colCantidad;
        private DevExpress.XtraGrid.Columns.GridColumn colObservaciones;
        private DevExpress.Utils.Behaviors.BehaviorManager behaviorManager1;
        private DevExpress.Utils.DragDrop.DragDropEvents dragDropEventsRepuestos;
        private DevExpress.Utils.DragDrop.DragDropEvents dragDropEventsProductos;
        private DevExpress.XtraEditors.SimpleButton btnAplicar;
        private Label lblTitulo;
        private DevExpress.XtraEditors.SimpleButton btnCancelar;
        private DevExpress.XtraBars.PopupMenu popupMenu1;
        private DevExpress.XtraBars.BarButtonItem barButtonItemDeleteRepuesto;
        private DevExpress.XtraBars.BarManager barManager1;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
    }
}