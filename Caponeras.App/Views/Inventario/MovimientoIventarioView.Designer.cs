namespace Caponeras.App.Views.Inventario
{
    sealed partial class MovimientoIventarioView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MovimientoIventarioView));
            groupControl1 = new DevExpress.XtraEditors.GroupControl();
            btnLimpiar = new DevExpress.XtraEditors.SimpleButton();
            labelControl5 = new DevExpress.XtraEditors.LabelControl();
            txtProducto = new DevExpress.XtraEditors.TextEdit();
            labelControl4 = new DevExpress.XtraEditors.LabelControl();
            labelControl3 = new DevExpress.XtraEditors.LabelControl();
            labelControl2 = new DevExpress.XtraEditors.LabelControl();
            labelControl1 = new DevExpress.XtraEditors.LabelControl();
            btnSearch = new DevExpress.XtraEditors.SimpleButton();
            txtHasta = new DevExpress.XtraEditors.DateEdit();
            cmbTipo = new DevExpress.XtraEditors.ComboBoxEdit();
            cmbReferencia = new DevExpress.XtraEditors.ComboBoxEdit();
            txtDesde = new DevExpress.XtraEditors.DateEdit();
            gridControlMovimientoInventario = new DevExpress.XtraGrid.GridControl();
            movimientoInventarioGridDtoBindingSource = new BindingSource(components);
            gridViewInventario = new DevExpress.XtraGrid.Views.Grid.GridView();
            colFecha = new DevExpress.XtraGrid.Columns.GridColumn();
            colProducto = new DevExpress.XtraGrid.Columns.GridColumn();
            colTipo = new DevExpress.XtraGrid.Columns.GridColumn();
            colEntrada = new DevExpress.XtraGrid.Columns.GridColumn();
            colSalida = new DevExpress.XtraGrid.Columns.GridColumn();
            colStockAnterior = new DevExpress.XtraGrid.Columns.GridColumn();
            colStockNuevo = new DevExpress.XtraGrid.Columns.GridColumn();
            colReferencia = new DevExpress.XtraGrid.Columns.GridColumn();
            colReferenciaInventario = new DevExpress.XtraGrid.Columns.GridColumn();
            colUsuario = new DevExpress.XtraGrid.Columns.GridColumn();
            stackPanel1 = new DevExpress.Utils.Layout.StackPanel();
            btnFirstPage = new DevExpress.XtraEditors.SimpleButton();
            btnPrev = new DevExpress.XtraEditors.SimpleButton();
            lblNavigator = new DevExpress.XtraEditors.LabelControl();
            btnNext = new DevExpress.XtraEditors.SimpleButton();
            btnLastPage = new DevExpress.XtraEditors.SimpleButton();
            btnVerReporte = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)groupControl1).BeginInit();
            groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)txtProducto.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)txtHasta.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)txtHasta.Properties.CalendarTimeProperties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)cmbTipo.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)cmbReferencia.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)txtDesde.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)txtDesde.Properties.CalendarTimeProperties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)gridControlMovimientoInventario).BeginInit();
            ((System.ComponentModel.ISupportInitialize)movimientoInventarioGridDtoBindingSource).BeginInit();
            ((System.ComponentModel.ISupportInitialize)gridViewInventario).BeginInit();
            ((System.ComponentModel.ISupportInitialize)stackPanel1).BeginInit();
            stackPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // groupControl1
            // 
            groupControl1.Controls.Add(btnVerReporte);
            groupControl1.Controls.Add(btnLimpiar);
            groupControl1.Controls.Add(labelControl5);
            groupControl1.Controls.Add(txtProducto);
            groupControl1.Controls.Add(labelControl4);
            groupControl1.Controls.Add(labelControl3);
            groupControl1.Controls.Add(labelControl2);
            groupControl1.Controls.Add(labelControl1);
            groupControl1.Controls.Add(btnSearch);
            groupControl1.Controls.Add(txtHasta);
            groupControl1.Controls.Add(cmbTipo);
            groupControl1.Controls.Add(cmbReferencia);
            groupControl1.Controls.Add(txtDesde);
            groupControl1.Dock = DockStyle.Top;
            groupControl1.Location = new Point(7, 7);
            groupControl1.Name = "groupControl1";
            groupControl1.Size = new Size(1010, 100);
            groupControl1.TabIndex = 0;
            groupControl1.Text = "Filtros";
            // 
            // btnLimpiar
            // 
            btnLimpiar.Appearance.BackColor = DevExpress.LookAndFeel.DXSkinColors.FillColors.Danger;
            btnLimpiar.Appearance.ForeColor = Color.White;
            btnLimpiar.Appearance.Options.UseBackColor = true;
            btnLimpiar.Appearance.Options.UseForeColor = true;
            btnLimpiar.ImageOptions.AllowGlyphSkinning = DevExpress.Utils.DefaultBoolean.True;
            btnLimpiar.ImageOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("btnLimpiar.ImageOptions.SvgImage");
            btnLimpiar.ImageOptions.SvgImageSize = new Size(16, 16);
            btnLimpiar.Location = new Point(645, 68);
            btnLimpiar.Name = "btnLimpiar";
            btnLimpiar.Size = new Size(102, 22);
            btnLimpiar.TabIndex = 11;
            btnLimpiar.Text = "Limpiar";
            btnLimpiar.Click += btnLimpiar_Click;
            // 
            // labelControl5
            // 
            labelControl5.Location = new Point(455, 40);
            labelControl5.Name = "labelControl5";
            labelControl5.Size = new Size(148, 13);
            labelControl5.TabIndex = 10;
            labelControl5.Text = "Código o descripción producto:";
            // 
            // txtProducto
            // 
            txtProducto.Location = new Point(455, 63);
            txtProducto.Name = "txtProducto";
            txtProducto.Size = new Size(157, 20);
            txtProducto.TabIndex = 9;
            // 
            // labelControl4
            // 
            labelControl4.Location = new Point(212, 66);
            labelControl4.Name = "labelControl4";
            labelControl4.Size = new Size(96, 13);
            labelControl4.TabIndex = 8;
            labelControl4.Text = "Tipo de movimiento:";
            // 
            // labelControl3
            // 
            labelControl3.Location = new Point(217, 40);
            labelControl3.Name = "labelControl3";
            labelControl3.Size = new Size(91, 13);
            labelControl3.TabIndex = 7;
            labelControl3.Text = "Tipo de referencia:";
            // 
            // labelControl2
            // 
            labelControl2.Location = new Point(59, 65);
            labelControl2.Name = "labelControl2";
            labelControl2.Size = new Size(32, 13);
            labelControl2.TabIndex = 6;
            labelControl2.Text = "Hasta:";
            // 
            // labelControl1
            // 
            labelControl1.Location = new Point(57, 39);
            labelControl1.Name = "labelControl1";
            labelControl1.Size = new Size(34, 13);
            labelControl1.TabIndex = 5;
            labelControl1.Text = "Desde:";
            // 
            // btnSearch
            // 
            btnSearch.Appearance.BackColor = DevExpress.LookAndFeel.DXSkinColors.FillColors.Success;
            btnSearch.Appearance.ForeColor = Color.White;
            btnSearch.Appearance.Options.UseBackColor = true;
            btnSearch.Appearance.Options.UseForeColor = true;
            btnSearch.ImageOptions.AllowGlyphSkinning = DevExpress.Utils.DefaultBoolean.True;
            btnSearch.ImageOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("btnSearch.ImageOptions.SvgImage");
            btnSearch.ImageOptions.SvgImageSize = new Size(16, 16);
            btnSearch.Location = new Point(645, 40);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(102, 22);
            btnSearch.TabIndex = 4;
            btnSearch.Text = "Buscar";
            btnSearch.Click += btnSearch_Click;
            // 
            // txtHasta
            // 
            txtHasta.EditValue = null;
            txtHasta.Location = new Point(97, 62);
            txtHasta.Name = "txtHasta";
            txtHasta.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo) });
            txtHasta.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo) });
            txtHasta.Size = new Size(100, 20);
            txtHasta.TabIndex = 3;
            // 
            // cmbTipo
            // 
            cmbTipo.Location = new Point(314, 63);
            cmbTipo.Name = "cmbTipo";
            cmbTipo.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo) });
            cmbTipo.Size = new Size(135, 20);
            cmbTipo.TabIndex = 2;
            // 
            // cmbReferencia
            // 
            cmbReferencia.Location = new Point(314, 37);
            cmbReferencia.Name = "cmbReferencia";
            cmbReferencia.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo) });
            cmbReferencia.Size = new Size(135, 20);
            cmbReferencia.TabIndex = 1;
            // 
            // txtDesde
            // 
            txtDesde.EditValue = null;
            txtDesde.Location = new Point(97, 36);
            txtDesde.Name = "txtDesde";
            txtDesde.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo) });
            txtDesde.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo) });
            txtDesde.Size = new Size(100, 20);
            txtDesde.TabIndex = 0;
            // 
            // gridControlMovimientoInventario
            // 
            gridControlMovimientoInventario.DataSource = movimientoInventarioGridDtoBindingSource;
            gridControlMovimientoInventario.Dock = DockStyle.Fill;
            gridControlMovimientoInventario.Location = new Point(7, 107);
            gridControlMovimientoInventario.MainView = gridViewInventario;
            gridControlMovimientoInventario.Name = "gridControlMovimientoInventario";
            gridControlMovimientoInventario.Size = new Size(1010, 392);
            gridControlMovimientoInventario.TabIndex = 1;
            gridControlMovimientoInventario.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] { gridViewInventario });
            // 
            // movimientoInventarioGridDtoBindingSource
            // 
            movimientoInventarioGridDtoBindingSource.DataSource = typeof(Dto.MovimientoInventarioGridDto);
            // 
            // gridViewInventario
            // 
            gridViewInventario.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] { colFecha, colProducto, colTipo, colEntrada, colSalida, colStockAnterior, colStockNuevo, colReferencia, colReferenciaInventario, colUsuario });
            gridViewInventario.GridControl = gridControlMovimientoInventario;
            gridViewInventario.Name = "gridViewInventario";
            gridViewInventario.OptionsBehavior.Editable = false;
            // 
            // colFecha
            // 
            colFecha.FieldName = "Fecha";
            colFecha.Name = "colFecha";
            colFecha.Visible = true;
            colFecha.VisibleIndex = 0;
            // 
            // colProducto
            // 
            colProducto.FieldName = "Producto";
            colProducto.Name = "colProducto";
            colProducto.Visible = true;
            colProducto.VisibleIndex = 1;
            // 
            // colTipo
            // 
            colTipo.FieldName = "Tipo";
            colTipo.Name = "colTipo";
            colTipo.Visible = true;
            colTipo.VisibleIndex = 2;
            // 
            // colEntrada
            // 
            colEntrada.FieldName = "Entrada";
            colEntrada.Name = "colEntrada";
            colEntrada.Visible = true;
            colEntrada.VisibleIndex = 3;
            // 
            // colSalida
            // 
            colSalida.FieldName = "Salida";
            colSalida.Name = "colSalida";
            colSalida.Visible = true;
            colSalida.VisibleIndex = 4;
            // 
            // colStockAnterior
            // 
            colStockAnterior.FieldName = "StockAnterior";
            colStockAnterior.Name = "colStockAnterior";
            colStockAnterior.Visible = true;
            colStockAnterior.VisibleIndex = 5;
            // 
            // colStockNuevo
            // 
            colStockNuevo.FieldName = "StockNuevo";
            colStockNuevo.Name = "colStockNuevo";
            colStockNuevo.Visible = true;
            colStockNuevo.VisibleIndex = 6;
            // 
            // colReferencia
            // 
            colReferencia.FieldName = "Referencia";
            colReferencia.Name = "colReferencia";
            colReferencia.Visible = true;
            colReferencia.VisibleIndex = 7;
            // 
            // colReferenciaInventario
            // 
            colReferenciaInventario.FieldName = "ReferenciaInventario";
            colReferenciaInventario.Name = "colReferenciaInventario";
            colReferenciaInventario.Visible = true;
            colReferenciaInventario.VisibleIndex = 8;
            // 
            // colUsuario
            // 
            colUsuario.FieldName = "Usuario";
            colUsuario.Name = "colUsuario";
            colUsuario.Visible = true;
            colUsuario.VisibleIndex = 9;
            // 
            // stackPanel1
            // 
            stackPanel1.AutoSize = true;
            stackPanel1.Controls.Add(btnFirstPage);
            stackPanel1.Controls.Add(btnPrev);
            stackPanel1.Controls.Add(lblNavigator);
            stackPanel1.Controls.Add(btnNext);
            stackPanel1.Controls.Add(btnLastPage);
            stackPanel1.Dock = DockStyle.Bottom;
            stackPanel1.Location = new Point(7, 499);
            stackPanel1.Name = "stackPanel1";
            stackPanel1.Padding = new Padding(1);
            stackPanel1.Size = new Size(1010, 29);
            stackPanel1.TabIndex = 2;
            stackPanel1.UseSkinIndents = true;
            // 
            // btnFirstPage
            // 
            btnFirstPage.ImageOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("btnFirstPage.ImageOptions.SvgImage");
            btnFirstPage.ImageOptions.SvgImageSize = new Size(24, 24);
            btnFirstPage.Location = new Point(3, 3);
            btnFirstPage.Name = "btnFirstPage";
            btnFirstPage.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light;
            btnFirstPage.Size = new Size(47, 23);
            btnFirstPage.TabIndex = 0;
            btnFirstPage.Click += btnFirstPage_Click;
            // 
            // btnPrev
            // 
            btnPrev.ImageOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("btnPrev.ImageOptions.SvgImage");
            btnPrev.Location = new Point(54, 3);
            btnPrev.Name = "btnPrev";
            btnPrev.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light;
            btnPrev.Size = new Size(52, 23);
            btnPrev.TabIndex = 1;
            btnPrev.Click += btnPrev_Click;
            // 
            // lblNavigator
            // 
            lblNavigator.Location = new Point(110, 8);
            lblNavigator.Name = "lblNavigator";
            lblNavigator.Size = new Size(16, 13);
            lblNavigator.TabIndex = 4;
            lblNavigator.Text = "....";
            // 
            // btnNext
            // 
            btnNext.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.RightCenter;
            btnNext.ImageOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("btnNext.ImageOptions.SvgImage");
            btnNext.Location = new Point(130, 3);
            btnNext.Name = "btnNext";
            btnNext.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light;
            btnNext.Size = new Size(46, 23);
            btnNext.TabIndex = 2;
            btnNext.Click += btnNext_Click;
            // 
            // btnLastPage
            // 
            btnLastPage.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.RightCenter;
            btnLastPage.ImageOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("btnLastPage.ImageOptions.SvgImage");
            btnLastPage.ImageOptions.SvgImageSize = new Size(24, 24);
            btnLastPage.Location = new Point(180, 3);
            btnLastPage.Name = "btnLastPage";
            btnLastPage.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light;
            btnLastPage.Size = new Size(52, 23);
            btnLastPage.TabIndex = 3;
            btnLastPage.Click += btnLastPage_Click;
            // 
            // btnVerReporte
            // 
            btnVerReporte.Appearance.BackColor = Color.Navy;
            btnVerReporte.Appearance.ForeColor = Color.White;
            btnVerReporte.Appearance.Options.UseBackColor = true;
            btnVerReporte.Appearance.Options.UseForeColor = true;
            btnVerReporte.ImageOptions.AllowGlyphSkinning = DevExpress.Utils.DefaultBoolean.True;
            btnVerReporte.ImageOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("simpleButton1.ImageOptions.SvgImage");
            btnVerReporte.ImageOptions.SvgImageSize = new Size(16, 16);
            btnVerReporte.Location = new Point(753, 66);
            btnVerReporte.Name = "btnVerReporte";
            btnVerReporte.Size = new Size(102, 22);
            btnVerReporte.TabIndex = 12;
            btnVerReporte.Text = "Ver Reporte";
            btnVerReporte.Click += btnVerReporte_Click;
            // 
            // MovimientoIventarioView
            // 
            AutoScaleDimensions = new SizeF(6F, 13F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1024, 535);
            Controls.Add(gridControlMovimientoInventario);
            Controls.Add(stackPanel1);
            Controls.Add(groupControl1);
            IconOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("MovimientoIventarioView.IconOptions.SvgImage");
            Name = "MovimientoIventarioView";
            Padding = new Padding(7);
            Text = "Movimientos Inventario";
            Load += MovimientoIventarioView_Load;
            ((System.ComponentModel.ISupportInitialize)groupControl1).EndInit();
            groupControl1.ResumeLayout(false);
            groupControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)txtProducto.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)txtHasta.Properties.CalendarTimeProperties).EndInit();
            ((System.ComponentModel.ISupportInitialize)txtHasta.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)cmbTipo.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)cmbReferencia.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)txtDesde.Properties.CalendarTimeProperties).EndInit();
            ((System.ComponentModel.ISupportInitialize)txtDesde.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)gridControlMovimientoInventario).EndInit();
            ((System.ComponentModel.ISupportInitialize)movimientoInventarioGridDtoBindingSource).EndInit();
            ((System.ComponentModel.ISupportInitialize)gridViewInventario).EndInit();
            ((System.ComponentModel.ISupportInitialize)stackPanel1).EndInit();
            stackPanel1.ResumeLayout(false);
            stackPanel1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.SimpleButton btnSearch;
        private DevExpress.XtraEditors.DateEdit txtHasta;
        private DevExpress.XtraEditors.ComboBoxEdit cmbTipo;
        private DevExpress.XtraEditors.ComboBoxEdit cmbReferencia;
        private DevExpress.XtraEditors.DateEdit txtDesde;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private DevExpress.XtraEditors.TextEdit txtProducto;
        private DevExpress.XtraEditors.SimpleButton btnLimpiar;
        private DevExpress.XtraGrid.GridControl gridControlMovimientoInventario;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewInventario;
        private BindingSource movimientoInventarioGridDtoBindingSource;
        private DevExpress.XtraGrid.Columns.GridColumn colFecha;
        private DevExpress.XtraGrid.Columns.GridColumn colProducto;
        private DevExpress.XtraGrid.Columns.GridColumn colTipo;
        private DevExpress.XtraGrid.Columns.GridColumn colEntrada;
        private DevExpress.XtraGrid.Columns.GridColumn colSalida;
        private DevExpress.XtraGrid.Columns.GridColumn colStockAnterior;
        private DevExpress.XtraGrid.Columns.GridColumn colStockNuevo;
        private DevExpress.XtraGrid.Columns.GridColumn colReferencia;
        private DevExpress.XtraGrid.Columns.GridColumn colReferenciaInventario;
        private DevExpress.XtraGrid.Columns.GridColumn colUsuario;
        private DevExpress.Utils.Layout.StackPanel stackPanel1;
        private DevExpress.XtraEditors.SimpleButton btnFirstPage;
        private DevExpress.XtraEditors.SimpleButton btnPrev;
        private DevExpress.XtraEditors.LabelControl lblNavigator;
        private DevExpress.XtraEditors.SimpleButton btnNext;
        private DevExpress.XtraEditors.SimpleButton btnLastPage;
        private DevExpress.XtraEditors.SimpleButton btnVerReporte;
    }
}