namespace Caponeras.App.Views.Veniculos
{
    partial class AseguradorasFormView
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
            gridControl1 = new DevExpress.XtraGrid.GridControl();
            gridViewAseguradoras = new DevExpress.XtraGrid.Views.Grid.GridView();
            aseguradorasDtoBindingSource = new BindingSource(components);
            colNombre = new DevExpress.XtraGrid.Columns.GridColumn();
            colNombreCorto = new DevExpress.XtraGrid.Columns.GridColumn();
            colTelefono = new DevExpress.XtraGrid.Columns.GridColumn();
            colCorreo = new DevExpress.XtraGrid.Columns.GridColumn();
            colSitioWeb = new DevExpress.XtraGrid.Columns.GridColumn();
            colDireccion = new DevExpress.XtraGrid.Columns.GridColumn();
            colActivo = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)gridControl1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)gridViewAseguradoras).BeginInit();
            ((System.ComponentModel.ISupportInitialize)aseguradorasDtoBindingSource).BeginInit();
            SuspendLayout();
            // 
            // gridControl1
            // 
            gridControl1.DataSource = aseguradorasDtoBindingSource;
            gridControl1.Dock = DockStyle.Fill;
            gridControl1.Location = new Point(0, 0);
            gridControl1.MainView = gridViewAseguradoras;
            gridControl1.Name = "gridControl1";
            gridControl1.Size = new Size(752, 491);
            gridControl1.TabIndex = 0;
            gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] { gridViewAseguradoras });
            // 
            // gridViewAseguradoras
            // 
            gridViewAseguradoras.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] { colNombre, colNombreCorto, colTelefono, colCorreo, colSitioWeb, colDireccion, colActivo });
            gridViewAseguradoras.GridControl = gridControl1;
            gridViewAseguradoras.Name = "gridViewAseguradoras";
            gridViewAseguradoras.OptionsBehavior.Editable = false;
            gridViewAseguradoras.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None;
            gridViewAseguradoras.KeyDown += gridViewAseguradoras_KeyDown;
            // 
            // aseguradorasDtoBindingSource
            // 
            aseguradorasDtoBindingSource.DataSource = typeof(Dto.AseguradorasDto);
            // 
            // colNombre
            // 
            colNombre.FieldName = "Nombre";
            colNombre.Caption = "Agencia / Aseguradora";
            colNombre.Name = "colNombre";
            colNombre.Visible = true;
            colNombre.VisibleIndex = 0;
            // 
            // colNombreCorto
            // 
            colNombreCorto.FieldName = "NombreCorto";
            colNombreCorto.Caption = "Nombre corto";
            colNombreCorto.Name = "colNombreCorto";
            colNombreCorto.OptionsEditForm.Caption = "Nombre Abr.:";
            colNombreCorto.Visible = true;
            colNombreCorto.VisibleIndex = 1;
            // 
            // colTelefono
            // 
            colTelefono.FieldName = "Telefono";
            colTelefono.Caption = "Teléfono";
            colTelefono.Name = "colTelefono";
            colTelefono.Visible = true;
            colTelefono.VisibleIndex = 2;
            // 
            // colCorreo
            // 
            colCorreo.FieldName = "Correo";
            colCorreo.Caption = "Correo";
            colCorreo.Name = "colCorreo";
            colCorreo.Visible = true;
            colCorreo.VisibleIndex = 3;
            // 
            // colSitioWeb
            // 
            colSitioWeb.FieldName = "SitioWeb";
            colSitioWeb.Caption = "Sitio web";
            colSitioWeb.Name = "colSitioWeb";
            colSitioWeb.Visible = true;
            colSitioWeb.VisibleIndex = 4;
            // 
            // colDireccion
            // 
            colDireccion.FieldName = "Direccion";
            colDireccion.Caption = "Dirección";
            colDireccion.Name = "colDireccion";
            colDireccion.Visible = true;
            colDireccion.VisibleIndex = 5;
            // 
            // colActivo
            // 
            colActivo.Caption = "Activa";
            colActivo.FieldName = "Activo";
            colActivo.Name = "colActivo";
            colActivo.Visible = true;
            colActivo.VisibleIndex = 6;
            // 
            // AseguradorasFormView
            // 
            AutoScaleDimensions = new SizeF(6F, 13F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(752, 491);
            Controls.Add(gridControl1);
            Name = "AseguradorasFormView";
            Text = "Agencias vendedoras de seguros";
            Load += AseguradorasFormView_Load;
            ((System.ComponentModel.ISupportInitialize)gridControl1).EndInit();
            ((System.ComponentModel.ISupportInitialize)gridViewAseguradoras).EndInit();
            ((System.ComponentModel.ISupportInitialize)aseguradorasDtoBindingSource).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DevExpress.XtraGrid.GridControl gridControl1;
        private BindingSource aseguradorasDtoBindingSource;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewAseguradoras;
        private DevExpress.XtraGrid.Columns.GridColumn colNombre;
        private DevExpress.XtraGrid.Columns.GridColumn colNombreCorto;
        private DevExpress.XtraGrid.Columns.GridColumn colTelefono;
        private DevExpress.XtraGrid.Columns.GridColumn colCorreo;
        private DevExpress.XtraGrid.Columns.GridColumn colSitioWeb;
        private DevExpress.XtraGrid.Columns.GridColumn colDireccion;
        private DevExpress.XtraGrid.Columns.GridColumn colActivo;
    }
}
