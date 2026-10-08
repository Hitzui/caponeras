namespace Caponeras.App.Views.Veniculos
{
    partial class VehiculosView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(VehiculosView));
            gridControlVehiculos = new DevExpress.XtraGrid.GridControl();
            vehiculosDtoBindingSource = new BindingSource(components);
            gridViewVehiculos = new DevExpress.XtraGrid.Views.Grid.GridView();
            colCodigo = new DevExpress.XtraGrid.Columns.GridColumn();
            colPlaca = new DevExpress.XtraGrid.Columns.GridColumn();
            colDescripcion = new DevExpress.XtraGrid.Columns.GridColumn();
            colTipo = new DevExpress.XtraGrid.Columns.GridColumn();
            colMarca = new DevExpress.XtraGrid.Columns.GridColumn();
            colModelo = new DevExpress.XtraGrid.Columns.GridColumn();
            colAnio = new DevExpress.XtraGrid.Columns.GridColumn();
            colEstado = new DevExpress.XtraGrid.Columns.GridColumn();
            colKmActual = new DevExpress.XtraGrid.Columns.GridColumn();
            colObservaciones = new DevExpress.XtraGrid.Columns.GridColumn();
            popupMenu1 = new DevExpress.XtraBars.PopupMenu(components);
            barButtonItemAdd = new DevExpress.XtraBars.BarButtonItem();
            barButtonItemEdit = new DevExpress.XtraBars.BarButtonItem();
            barButtonItemDelete = new DevExpress.XtraBars.BarButtonItem();
            barManager1 = new DevExpress.XtraBars.BarManager(components);
            barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            ((System.ComponentModel.ISupportInitialize)gridControlVehiculos).BeginInit();
            ((System.ComponentModel.ISupportInitialize)vehiculosDtoBindingSource).BeginInit();
            ((System.ComponentModel.ISupportInitialize)gridViewVehiculos).BeginInit();
            ((System.ComponentModel.ISupportInitialize)popupMenu1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)barManager1).BeginInit();
            SuspendLayout();
            // 
            // gridControlVehiculos
            // 
            gridControlVehiculos.DataSource = vehiculosDtoBindingSource;
            gridControlVehiculos.Dock = DockStyle.Fill;
            gridControlVehiculos.Location = new Point(0, 0);
            gridControlVehiculos.MainView = gridViewVehiculos;
            gridControlVehiculos.Name = "gridControlVehiculos";
            gridControlVehiculos.Size = new Size(809, 471);
            gridControlVehiculos.TabIndex = 0;
            gridControlVehiculos.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] { gridViewVehiculos });
            // 
            // vehiculosDtoBindingSource
            // 
            vehiculosDtoBindingSource.DataSource = typeof(Dto.VehiculosDto);
            // 
            // gridViewVehiculos
            // 
            gridViewVehiculos.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] { colCodigo, colPlaca, colDescripcion, colTipo, colMarca, colModelo, colAnio, colEstado, colKmActual, colObservaciones });
            gridViewVehiculos.GridControl = gridControlVehiculos;
            gridViewVehiculos.Name = "gridViewVehiculos";
            gridViewVehiculos.OptionsBehavior.Editable = false;
            gridViewVehiculos.PopupMenuShowing += gridViewVehiculos_PopupMenuShowing;
            gridViewVehiculos.SelectionChanged += gridViewVehiculos_SelectionChanged;
            gridViewVehiculos.FocusedRowChanged += gridViewVehiculos_FocusedRowChanged;
            // 
            // colCodigo
            // 
            colCodigo.FieldName = "Codigo";
            colCodigo.Name = "colCodigo";
            colCodigo.Visible = true;
            colCodigo.VisibleIndex = 0;
            // 
            // colPlaca
            // 
            colPlaca.FieldName = "Placa";
            colPlaca.Name = "colPlaca";
            colPlaca.Visible = true;
            colPlaca.VisibleIndex = 1;
            // 
            // colDescripcion
            // 
            colDescripcion.FieldName = "Descripcion";
            colDescripcion.Name = "colDescripcion";
            colDescripcion.Visible = true;
            colDescripcion.VisibleIndex = 2;
            // 
            // colTipo
            // 
            colTipo.FieldName = "Tipo";
            colTipo.Name = "colTipo";
            colTipo.Visible = true;
            colTipo.VisibleIndex = 3;
            // 
            // colMarca
            // 
            colMarca.FieldName = "Marca";
            colMarca.Name = "colMarca";
            colMarca.Visible = true;
            colMarca.VisibleIndex = 4;
            // 
            // colModelo
            // 
            colModelo.FieldName = "Modelo";
            colModelo.Name = "colModelo";
            colModelo.Visible = true;
            colModelo.VisibleIndex = 5;
            // 
            // colAnio
            // 
            colAnio.FieldName = "Anio";
            colAnio.Name = "colAnio";
            colAnio.Visible = true;
            colAnio.VisibleIndex = 6;
            // 
            // colEstado
            // 
            colEstado.FieldName = "Estado";
            colEstado.Name = "colEstado";
            colEstado.Visible = true;
            colEstado.VisibleIndex = 7;
            // 
            // colKmActual
            // 
            colKmActual.FieldName = "KmActual";
            colKmActual.Name = "colKmActual";
            colKmActual.Visible = true;
            colKmActual.VisibleIndex = 8;
            // 
            // colObservaciones
            // 
            colObservaciones.FieldName = "Observaciones";
            colObservaciones.Name = "colObservaciones";
            colObservaciones.Visible = true;
            colObservaciones.VisibleIndex = 9;
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
            barDockControlTop.Size = new Size(809, 0);
            // 
            // barDockControlBottom
            // 
            barDockControlBottom.CausesValidation = false;
            barDockControlBottom.Dock = DockStyle.Bottom;
            barDockControlBottom.Location = new Point(0, 471);
            barDockControlBottom.Manager = barManager1;
            barDockControlBottom.Size = new Size(809, 0);
            // 
            // barDockControlLeft
            // 
            barDockControlLeft.CausesValidation = false;
            barDockControlLeft.Dock = DockStyle.Left;
            barDockControlLeft.Location = new Point(0, 0);
            barDockControlLeft.Manager = barManager1;
            barDockControlLeft.Size = new Size(0, 471);
            // 
            // barDockControlRight
            // 
            barDockControlRight.CausesValidation = false;
            barDockControlRight.Dock = DockStyle.Right;
            barDockControlRight.Location = new Point(809, 0);
            barDockControlRight.Manager = barManager1;
            barDockControlRight.Size = new Size(0, 471);
            // 
            // VehiculosView
            // 
            AutoScaleDimensions = new SizeF(6F, 13F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(809, 471);
            Controls.Add(gridControlVehiculos);
            Controls.Add(barDockControlLeft);
            Controls.Add(barDockControlRight);
            Controls.Add(barDockControlBottom);
            Controls.Add(barDockControlTop);
            IconOptions.Image = (Image)resources.GetObject("VehiculosView.IconOptions.Image");
            Name = "VehiculosView";
            Text = "Caponeras";
            Load += VehiculosView_Load;
            ((System.ComponentModel.ISupportInitialize)gridControlVehiculos).EndInit();
            ((System.ComponentModel.ISupportInitialize)vehiculosDtoBindingSource).EndInit();
            ((System.ComponentModel.ISupportInitialize)gridViewVehiculos).EndInit();
            ((System.ComponentModel.ISupportInitialize)popupMenu1).EndInit();
            ((System.ComponentModel.ISupportInitialize)barManager1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DevExpress.XtraGrid.GridControl gridControlVehiculos;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewVehiculos;
        private BindingSource vehiculosDtoBindingSource;
        private DevExpress.XtraGrid.Columns.GridColumn colCodigo;
        private DevExpress.XtraGrid.Columns.GridColumn colPlaca;
        private DevExpress.XtraGrid.Columns.GridColumn colDescripcion;
        private DevExpress.XtraGrid.Columns.GridColumn colTipo;
        private DevExpress.XtraGrid.Columns.GridColumn colMarca;
        private DevExpress.XtraGrid.Columns.GridColumn colModelo;
        private DevExpress.XtraGrid.Columns.GridColumn colAnio;
        private DevExpress.XtraGrid.Columns.GridColumn colEstado;
        private DevExpress.XtraGrid.Columns.GridColumn colKmActual;
        private DevExpress.XtraGrid.Columns.GridColumn colObservaciones;
        private DevExpress.XtraBars.PopupMenu popupMenu1;
        private DevExpress.XtraBars.BarButtonItem barButtonItemAdd;
        private DevExpress.XtraBars.BarButtonItem barButtonItemEdit;
        private DevExpress.XtraBars.BarManager barManager1;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraBars.BarButtonItem barButtonItemDelete;
    }
}