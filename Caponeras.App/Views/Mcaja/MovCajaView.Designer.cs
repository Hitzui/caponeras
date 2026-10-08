namespace Caponeras.App.Views.Mcaja
{
    sealed partial class MovCajaView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MovCajaView));
            gridControlMovCaja = new DevExpress.XtraGrid.GridControl();
            movCajasDtoBindingSource = new BindingSource(components);
            gridViewMovCaja = new DevExpress.XtraGrid.Views.Grid.GridView();
            colIdmovcaja = new DevExpress.XtraGrid.Columns.GridColumn();
            colDescripcion = new DevExpress.XtraGrid.Columns.GridColumn();
            colRubros = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)gridControlMovCaja).BeginInit();
            ((System.ComponentModel.ISupportInitialize)movCajasDtoBindingSource).BeginInit();
            ((System.ComponentModel.ISupportInitialize)gridViewMovCaja).BeginInit();
            SuspendLayout();
            // 
            // gridControlMovCaja
            // 
            gridControlMovCaja.DataSource = movCajasDtoBindingSource;
            gridControlMovCaja.Dock = DockStyle.Fill;
            gridControlMovCaja.Location = new Point(0, 0);
            gridControlMovCaja.MainView = gridViewMovCaja;
            gridControlMovCaja.Name = "gridControlMovCaja";
            gridControlMovCaja.Size = new Size(667, 474);
            gridControlMovCaja.TabIndex = 0;
            gridControlMovCaja.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] { gridViewMovCaja });
            // 
            // movCajasDtoBindingSource
            // 
            movCajasDtoBindingSource.DataSource = typeof(Dto.MovCajasDto);
            // 
            // gridViewMovCaja
            // 
            gridViewMovCaja.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] { colIdmovcaja, colDescripcion, colRubros });
            gridViewMovCaja.GridControl = gridControlMovCaja;
            gridViewMovCaja.Name = "gridViewMovCaja";
            gridViewMovCaja.SelectionChanged += gridViewMovCaja_SelectionChanged;
            // 
            // colIdmovcaja
            // 
            colIdmovcaja.FieldName = "Idmovcaja";
            colIdmovcaja.Name = "colIdmovcaja";
            colIdmovcaja.Visible = true;
            colIdmovcaja.VisibleIndex = 0;
            // 
            // colDescripcion
            // 
            colDescripcion.FieldName = "Descripcion";
            colDescripcion.Name = "colDescripcion";
            colDescripcion.Visible = true;
            colDescripcion.VisibleIndex = 1;
            // 
            // colRubros
            // 
            colRubros.FieldName = "Rubros";
            colRubros.Name = "colRubros";
            colRubros.Visible = true;
            colRubros.VisibleIndex = 2;
            // 
            // MovCajaView
            // 
            AutoScaleDimensions = new SizeF(6F, 13F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(667, 474);
            Controls.Add(gridControlMovCaja);
            IconOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("MovCajaView.IconOptions.SvgImage");
            Name = "MovCajaView";
            Text = "Movimientos de caja";
            Load += MovCajaView_Load;
            ((System.ComponentModel.ISupportInitialize)gridControlMovCaja).EndInit();
            ((System.ComponentModel.ISupportInitialize)movCajasDtoBindingSource).EndInit();
            ((System.ComponentModel.ISupportInitialize)gridViewMovCaja).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DevExpress.XtraGrid.GridControl gridControlMovCaja;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewMovCaja;
        private BindingSource movCajasDtoBindingSource;
        private DevExpress.XtraGrid.Columns.GridColumn colIdmovcaja;
        private DevExpress.XtraGrid.Columns.GridColumn colDescripcion;
        private DevExpress.XtraGrid.Columns.GridColumn colRubros;
    }
}