namespace Caponeras.App.Views.Proveedores
{
    sealed partial class ProveedoresView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ProveedoresView));
            gridControlProveedores = new DevExpress.XtraGrid.GridControl();
            proveedoresDtoBindingSource = new BindingSource(components);
            gridViewProveedores = new DevExpress.XtraGrid.Views.Grid.GridView();
            colNombre = new DevExpress.XtraGrid.Columns.GridColumn();
            colRuc = new DevExpress.XtraGrid.Columns.GridColumn();
            colTelefono = new DevExpress.XtraGrid.Columns.GridColumn();
            colEmail = new DevExpress.XtraGrid.Columns.GridColumn();
            colDireccion = new DevExpress.XtraGrid.Columns.GridColumn();
            colContacto = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)gridControlProveedores).BeginInit();
            ((System.ComponentModel.ISupportInitialize)proveedoresDtoBindingSource).BeginInit();
            ((System.ComponentModel.ISupportInitialize)gridViewProveedores).BeginInit();
            SuspendLayout();
            // 
            // gridControlProveedores
            // 
            gridControlProveedores.DataSource = proveedoresDtoBindingSource;
            gridControlProveedores.Dock = DockStyle.Fill;
            gridControlProveedores.Location = new Point(0, 0);
            gridControlProveedores.MainView = gridViewProveedores;
            gridControlProveedores.Name = "gridControlProveedores";
            gridControlProveedores.Size = new Size(857, 518);
            gridControlProveedores.TabIndex = 0;
            gridControlProveedores.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] { gridViewProveedores });
            // 
            // proveedoresDtoBindingSource
            // 
            proveedoresDtoBindingSource.DataSource = typeof(Dto.ProveedoresDto);
            // 
            // gridViewProveedores
            // 
            gridViewProveedores.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] { colNombre, colRuc, colTelefono, colEmail, colDireccion, colContacto });
            gridViewProveedores.GridControl = gridControlProveedores;
            gridViewProveedores.Name = "gridViewProveedores";
            gridViewProveedores.SelectionChanged += gridViewProveedores_SelectionChanged;
            gridViewProveedores.FocusedRowChanged += gridViewProveedores_FocusedRowChanged;
            // 
            // colNombre
            // 
            colNombre.FieldName = "Nombre";
            colNombre.Name = "colNombre";
            colNombre.Visible = true;
            colNombre.VisibleIndex = 0;
            // 
            // colRuc
            // 
            colRuc.FieldName = "Ruc";
            colRuc.Name = "colRuc";
            colRuc.Visible = true;
            colRuc.VisibleIndex = 1;
            // 
            // colTelefono
            // 
            colTelefono.FieldName = "Telefono";
            colTelefono.Name = "colTelefono";
            colTelefono.Visible = true;
            colTelefono.VisibleIndex = 2;
            // 
            // colEmail
            // 
            colEmail.FieldName = "Email";
            colEmail.Name = "colEmail";
            colEmail.Visible = true;
            colEmail.VisibleIndex = 3;
            // 
            // colDireccion
            // 
            colDireccion.FieldName = "Direccion";
            colDireccion.Name = "colDireccion";
            colDireccion.Visible = true;
            colDireccion.VisibleIndex = 4;
            // 
            // colContacto
            // 
            colContacto.FieldName = "Contacto";
            colContacto.Name = "colContacto";
            colContacto.Visible = true;
            colContacto.VisibleIndex = 5;
            // 
            // ProveedoresView
            // 
            AutoScaleDimensions = new SizeF(6F, 13F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(857, 518);
            Controls.Add(gridControlProveedores);
            IconOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("ProveedoresView.IconOptions.SvgImage");
            Name = "ProveedoresView";
            Text = "Proveedores";
            Load += ProveedoresView_Load;
            ((System.ComponentModel.ISupportInitialize)gridControlProveedores).EndInit();
            ((System.ComponentModel.ISupportInitialize)proveedoresDtoBindingSource).EndInit();
            ((System.ComponentModel.ISupportInitialize)gridViewProveedores).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DevExpress.XtraGrid.GridControl gridControlProveedores;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewProveedores;
        private BindingSource proveedoresDtoBindingSource;
        private DevExpress.XtraGrid.Columns.GridColumn colNombre;
        private DevExpress.XtraGrid.Columns.GridColumn colRuc;
        private DevExpress.XtraGrid.Columns.GridColumn colTelefono;
        private DevExpress.XtraGrid.Columns.GridColumn colEmail;
        private DevExpress.XtraGrid.Columns.GridColumn colDireccion;
        private DevExpress.XtraGrid.Columns.GridColumn colContacto;
    }
}