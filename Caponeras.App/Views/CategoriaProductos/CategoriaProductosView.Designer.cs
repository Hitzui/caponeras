namespace Caponeras.App.Views.CategoriaProductos
{
    partial class CategoriaProductosView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CategoriaProductosView));
            gridControlCategoriaProductos = new DevExpress.XtraGrid.GridControl();
            categoriaProductoDtoBindingSource = new BindingSource(components);
            gridViewCategoriaProductos = new DevExpress.XtraGrid.Views.Grid.GridView();
            colNombre = new DevExpress.XtraGrid.Columns.GridColumn();
            colDescripcion = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)gridControlCategoriaProductos).BeginInit();
            ((System.ComponentModel.ISupportInitialize)categoriaProductoDtoBindingSource).BeginInit();
            ((System.ComponentModel.ISupportInitialize)gridViewCategoriaProductos).BeginInit();
            SuspendLayout();
            // 
            // gridControlCategoriaProductos
            // 
            gridControlCategoriaProductos.DataSource = categoriaProductoDtoBindingSource;
            gridControlCategoriaProductos.Dock = DockStyle.Fill;
            gridControlCategoriaProductos.Location = new Point(0, 0);
            gridControlCategoriaProductos.MainView = gridViewCategoriaProductos;
            gridControlCategoriaProductos.Name = "gridControlCategoriaProductos";
            gridControlCategoriaProductos.Size = new Size(710, 427);
            gridControlCategoriaProductos.TabIndex = 0;
            gridControlCategoriaProductos.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] { gridViewCategoriaProductos });
            // 
            // categoriaProductoDtoBindingSource
            // 
            categoriaProductoDtoBindingSource.DataSource = typeof(Dto.CategoriaProductoDto);
            // 
            // gridViewCategoriaProductos
            // 
            gridViewCategoriaProductos.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] { colNombre, colDescripcion });
            gridViewCategoriaProductos.GridControl = gridControlCategoriaProductos;
            gridViewCategoriaProductos.Name = "gridViewCategoriaProductos";
            gridViewCategoriaProductos.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.True;
            gridViewCategoriaProductos.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.True;
            gridViewCategoriaProductos.OptionsBehavior.EditingMode = DevExpress.XtraGrid.Views.Grid.GridEditingMode.EditForm;
            gridViewCategoriaProductos.OptionsEditForm.ShowOnDoubleClick = DevExpress.Utils.DefaultBoolean.True;
            gridViewCategoriaProductos.OptionsEditForm.ShowOnEnterKey = DevExpress.Utils.DefaultBoolean.True;
            gridViewCategoriaProductos.OptionsEditForm.ShowOnF2Key = DevExpress.Utils.DefaultBoolean.True;
            gridViewCategoriaProductos.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Top;
            gridViewCategoriaProductos.OptionsView.ShowButtonMode = DevExpress.XtraGrid.Views.Base.ShowButtonModeEnum.ShowForFocusedRow;
            gridViewCategoriaProductos.EditFormHidden += gridViewCategoriaProductos_EditFormHidden;
            gridViewCategoriaProductos.KeyDown += gridViewCategoriaProductos_KeyDown;
            // 
            // colNombre
            // 
            colNombre.FieldName = "Nombre";
            colNombre.Name = "colNombre";
            colNombre.Visible = true;
            colNombre.VisibleIndex = 0;
            // 
            // colDescripcion
            // 
            colDescripcion.FieldName = "Descripcion";
            colDescripcion.Name = "colDescripcion";
            colDescripcion.Visible = true;
            colDescripcion.VisibleIndex = 1;
            // 
            // CategoriaProductosView
            // 
            AutoScaleDimensions = new SizeF(6F, 13F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(710, 427);
            Controls.Add(gridControlCategoriaProductos);
            IconOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("CategoriaProductosView.IconOptions.SvgImage");
            Name = "CategoriaProductosView";
            Text = "Categoría de productos";
            Load += CategoriaProductosView_Load;
            ((System.ComponentModel.ISupportInitialize)gridControlCategoriaProductos).EndInit();
            ((System.ComponentModel.ISupportInitialize)categoriaProductoDtoBindingSource).EndInit();
            ((System.ComponentModel.ISupportInitialize)gridViewCategoriaProductos).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DevExpress.XtraGrid.GridControl gridControlCategoriaProductos;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewCategoriaProductos;
        private BindingSource categoriaProductoDtoBindingSource;
        private DevExpress.XtraGrid.Columns.GridColumn colNombre;
        private DevExpress.XtraGrid.Columns.GridColumn colDescripcion;
    }
}