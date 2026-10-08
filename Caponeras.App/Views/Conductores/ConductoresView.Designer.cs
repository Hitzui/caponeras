namespace Caponeras.App.Views.Conductores
{
    partial class ConductoresView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ConductoresView));
            gridControlConductores = new DevExpress.XtraGrid.GridControl();
            conductoresDtoBindingSource = new BindingSource(components);
            gridViewConductores = new DevExpress.XtraGrid.Views.Grid.GridView();
            colIdconductor = new DevExpress.XtraGrid.Columns.GridColumn();
            colNombre = new DevExpress.XtraGrid.Columns.GridColumn();
            colTelefono = new DevExpress.XtraGrid.Columns.GridColumn();
            colIdentificacion = new DevExpress.XtraGrid.Columns.GridColumn();
            colEstado = new DevExpress.XtraGrid.Columns.GridColumn();
            colObservaciones = new DevExpress.XtraGrid.Columns.GridColumn();
            colCuota = new DevExpress.XtraGrid.Columns.GridColumn();
            popupMenu1 = new DevExpress.XtraBars.PopupMenu(components);
            barButtonItemAdd = new DevExpress.XtraBars.BarButtonItem();
            barButtonItemEdit = new DevExpress.XtraBars.BarButtonItem();
            barButtonItemDelete = new DevExpress.XtraBars.BarButtonItem();
            barButtonItemLicencia = new DevExpress.XtraBars.BarButtonItem();
            barButtonItemIdentificacion = new DevExpress.XtraBars.BarButtonItem();
            barButtonItemInfoReporte = new DevExpress.XtraBars.BarButtonItem();
            barManager1 = new DevExpress.XtraBars.BarManager(components);
            barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            ((System.ComponentModel.ISupportInitialize)gridControlConductores).BeginInit();
            ((System.ComponentModel.ISupportInitialize)conductoresDtoBindingSource).BeginInit();
            ((System.ComponentModel.ISupportInitialize)gridViewConductores).BeginInit();
            ((System.ComponentModel.ISupportInitialize)popupMenu1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)barManager1).BeginInit();
            SuspendLayout();
            // 
            // gridControlConductores
            // 
            gridControlConductores.DataSource = conductoresDtoBindingSource;
            gridControlConductores.Dock = DockStyle.Fill;
            gridControlConductores.Location = new Point(0, 0);
            gridControlConductores.MainView = gridViewConductores;
            gridControlConductores.Name = "gridControlConductores";
            gridControlConductores.Size = new Size(787, 465);
            gridControlConductores.TabIndex = 0;
            gridControlConductores.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] { gridViewConductores });
            // 
            // conductoresDtoBindingSource
            // 
            conductoresDtoBindingSource.DataSource = typeof(Dto.ConductoresDto);
            // 
            // gridViewConductores
            // 
            gridViewConductores.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] { colIdconductor, colNombre, colTelefono, colIdentificacion, colEstado, colObservaciones, colCuota });
            gridViewConductores.GridControl = gridControlConductores;
            gridViewConductores.Name = "gridViewConductores";
            gridViewConductores.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False;
            gridViewConductores.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.False;
            gridViewConductores.OptionsBehavior.Editable = false;
            gridViewConductores.PopupMenuShowing += gridViewConductores_PopupMenuShowing;
            gridViewConductores.SelectionChanged += gridViewConductores_SelectionChanged;
            gridViewConductores.FocusedRowChanged += gridViewConductores_FocusedRowChanged;
            // 
            // colIdconductor
            // 
            colIdconductor.FieldName = "Idconductor";
            colIdconductor.Name = "colIdconductor";
            colIdconductor.Visible = true;
            colIdconductor.VisibleIndex = 0;
            // 
            // colNombre
            // 
            colNombre.FieldName = "Nombre";
            colNombre.Name = "colNombre";
            colNombre.Visible = true;
            colNombre.VisibleIndex = 1;
            // 
            // colTelefono
            // 
            colTelefono.FieldName = "Telefono";
            colTelefono.Name = "colTelefono";
            colTelefono.Visible = true;
            colTelefono.VisibleIndex = 2;
            // 
            // colIdentificacion
            // 
            colIdentificacion.FieldName = "Identificacion";
            colIdentificacion.Name = "colIdentificacion";
            colIdentificacion.Visible = true;
            colIdentificacion.VisibleIndex = 3;
            // 
            // colEstado
            // 
            colEstado.FieldName = "Estado";
            colEstado.Name = "colEstado";
            colEstado.Visible = true;
            colEstado.VisibleIndex = 4;
            // 
            // colObservaciones
            // 
            colObservaciones.FieldName = "Observaciones";
            colObservaciones.Name = "colObservaciones";
            colObservaciones.Visible = true;
            colObservaciones.VisibleIndex = 5;
            // 
            // colCuota
            // 
            colCuota.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            colCuota.FieldName = "CuotaConfiguracions.MontoDiario";
            colCuota.MinWidth = 30;
            colCuota.Name = "colCuota";
            colCuota.OptionsColumn.ReadOnly = true;
            colCuota.Visible = true;
            colCuota.VisibleIndex = 6;
            // 
            // popupMenu1
            // 
            popupMenu1.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] { new DevExpress.XtraBars.LinkPersistInfo(barButtonItemAdd), new DevExpress.XtraBars.LinkPersistInfo(barButtonItemEdit), new DevExpress.XtraBars.LinkPersistInfo(barButtonItemDelete), new DevExpress.XtraBars.LinkPersistInfo(barButtonItemLicencia), new DevExpress.XtraBars.LinkPersistInfo(barButtonItemIdentificacion), new DevExpress.XtraBars.LinkPersistInfo(barButtonItemInfoReporte) });
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
            barButtonItemEdit.Caption = "Edit";
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
            // barButtonItemLicencia
            // 
            barButtonItemLicencia.Caption = "Datos Licencia";
            barButtonItemLicencia.Id = 3;
            barButtonItemLicencia.ImageOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("barButtonItemLicencia.ImageOptions.SvgImage");
            barButtonItemLicencia.Name = "barButtonItemLicencia";
            barButtonItemLicencia.ItemClick += barButtonItemLicencia_ItemClick;
            // 
            // barButtonItemIdentificacion
            // 
            barButtonItemIdentificacion.Caption = "Identificacion";
            barButtonItemIdentificacion.Id = 4;
            barButtonItemIdentificacion.ImageOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("barButtonItemIdentificacion.ImageOptions.SvgImage");
            barButtonItemIdentificacion.Name = "barButtonItemIdentificacion";
            barButtonItemIdentificacion.ItemClick += barButtonItemIdentificacion_ItemClick;
            // 
            // barButtonItemInfoReporte
            // 
            barButtonItemInfoReporte.Caption = "Ver Información";
            barButtonItemInfoReporte.Id = 5;
            barButtonItemInfoReporte.ImageOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("barButtonItemInfoReporte.ImageOptions.SvgImage");
            barButtonItemInfoReporte.Name = "barButtonItemInfoReporte";
            barButtonItemInfoReporte.ItemClick += barButtonItemInfoReporte_ItemClick;
            // 
            // barManager1
            // 
            barManager1.DockControls.Add(barDockControlTop);
            barManager1.DockControls.Add(barDockControlBottom);
            barManager1.DockControls.Add(barDockControlLeft);
            barManager1.DockControls.Add(barDockControlRight);
            barManager1.Form = this;
            barManager1.Items.AddRange(new DevExpress.XtraBars.BarItem[] { barButtonItemAdd, barButtonItemEdit, barButtonItemDelete, barButtonItemLicencia, barButtonItemIdentificacion, barButtonItemInfoReporte });
            barManager1.MaxItemId = 6;
            // 
            // barDockControlTop
            // 
            barDockControlTop.CausesValidation = false;
            barDockControlTop.Dock = DockStyle.Top;
            barDockControlTop.Location = new Point(0, 0);
            barDockControlTop.Manager = barManager1;
            barDockControlTop.Size = new Size(787, 0);
            // 
            // barDockControlBottom
            // 
            barDockControlBottom.CausesValidation = false;
            barDockControlBottom.Dock = DockStyle.Bottom;
            barDockControlBottom.Location = new Point(0, 465);
            barDockControlBottom.Manager = barManager1;
            barDockControlBottom.Size = new Size(787, 0);
            // 
            // barDockControlLeft
            // 
            barDockControlLeft.CausesValidation = false;
            barDockControlLeft.Dock = DockStyle.Left;
            barDockControlLeft.Location = new Point(0, 0);
            barDockControlLeft.Manager = barManager1;
            barDockControlLeft.Size = new Size(0, 465);
            // 
            // barDockControlRight
            // 
            barDockControlRight.CausesValidation = false;
            barDockControlRight.Dock = DockStyle.Right;
            barDockControlRight.Location = new Point(787, 0);
            barDockControlRight.Manager = barManager1;
            barDockControlRight.Size = new Size(0, 465);
            // 
            // ConductoresView
            // 
            AutoScaleDimensions = new SizeF(6F, 13F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(787, 465);
            Controls.Add(gridControlConductores);
            Controls.Add(barDockControlLeft);
            Controls.Add(barDockControlRight);
            Controls.Add(barDockControlBottom);
            Controls.Add(barDockControlTop);
            IconOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("ConductoresView.IconOptions.SvgImage");
            Name = "ConductoresView";
            Text = "Cadetes";
            Load += ConductoresView_Load;
            ((System.ComponentModel.ISupportInitialize)gridControlConductores).EndInit();
            ((System.ComponentModel.ISupportInitialize)conductoresDtoBindingSource).EndInit();
            ((System.ComponentModel.ISupportInitialize)gridViewConductores).EndInit();
            ((System.ComponentModel.ISupportInitialize)popupMenu1).EndInit();
            ((System.ComponentModel.ISupportInitialize)barManager1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DevExpress.XtraGrid.GridControl gridControlConductores;
        private BindingSource conductoresDtoBindingSource;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewConductores;
        private DevExpress.XtraGrid.Columns.GridColumn colIdconductor;
        private DevExpress.XtraGrid.Columns.GridColumn colNombre;
        private DevExpress.XtraGrid.Columns.GridColumn colTelefono;
        private DevExpress.XtraGrid.Columns.GridColumn colIdentificacion;
        private DevExpress.XtraGrid.Columns.GridColumn colEstado;
        private DevExpress.XtraGrid.Columns.GridColumn colObservaciones;
        private DevExpress.XtraBars.PopupMenu popupMenu1;
        private DevExpress.XtraBars.BarButtonItem barButtonItemAdd;
        private DevExpress.XtraBars.BarButtonItem barButtonItemEdit;
        private DevExpress.XtraBars.BarButtonItem barButtonItemDelete;
        private DevExpress.XtraBars.BarManager barManager1;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraGrid.Columns.GridColumn colCuota;
        private DevExpress.XtraBars.BarButtonItem barButtonItemLicencia;
        private DevExpress.XtraBars.BarButtonItem barButtonItemIdentificacion;
        private DevExpress.XtraBars.BarButtonItem barButtonItemInfoReporte;
    }
}