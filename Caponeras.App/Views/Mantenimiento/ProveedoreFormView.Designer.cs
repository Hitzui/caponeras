namespace Caponeras.App.Views.Mantenimiento
{
    sealed partial class ProveedoreFormView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ProveedoreFormView));
            panelControl1 = new DevExpress.XtraEditors.PanelControl();
            btnSeleccionar = new DevExpress.XtraEditors.SimpleButton();
            gridControlProveedores = new DevExpress.XtraGrid.GridControl();
            proveedoresDtoBindingSource = new BindingSource(components);
            gridViewProveedores = new DevExpress.XtraGrid.Views.Grid.GridView();
            colNombre = new DevExpress.XtraGrid.Columns.GridColumn();
            colRuc = new DevExpress.XtraGrid.Columns.GridColumn();
            colTelefono = new DevExpress.XtraGrid.Columns.GridColumn();
            colEmail = new DevExpress.XtraGrid.Columns.GridColumn();
            colContacto = new DevExpress.XtraGrid.Columns.GridColumn();
            splitContainerControl1 = new DevExpress.XtraEditors.SplitContainerControl();
            gridControlSelectedProveedores = new DevExpress.XtraGrid.GridControl();
            selectedProveedoresDtoBindingSource = new BindingSource(components);
            gridViewSelectedProveedores = new DevExpress.XtraGrid.Views.Grid.GridView();
            colNombre1 = new DevExpress.XtraGrid.Columns.GridColumn();
            colRuc1 = new DevExpress.XtraGrid.Columns.GridColumn();
            colTelefono1 = new DevExpress.XtraGrid.Columns.GridColumn();
            colContacto1 = new DevExpress.XtraGrid.Columns.GridColumn();
            colMontoManoObra = new DevExpress.XtraGrid.Columns.GridColumn();
            behaviorManager1 = new DevExpress.Utils.Behaviors.BehaviorManager(components);
            dragDropEvents1 = new DevExpress.Utils.DragDrop.DragDropEvents(components);
            dragDropEvents2 = new DevExpress.Utils.DragDrop.DragDropEvents(components);
            ((System.ComponentModel.ISupportInitialize)panelControl1).BeginInit();
            panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)gridControlProveedores).BeginInit();
            ((System.ComponentModel.ISupportInitialize)proveedoresDtoBindingSource).BeginInit();
            ((System.ComponentModel.ISupportInitialize)gridViewProveedores).BeginInit();
            ((System.ComponentModel.ISupportInitialize)splitContainerControl1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)splitContainerControl1.Panel1).BeginInit();
            splitContainerControl1.Panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainerControl1.Panel2).BeginInit();
            splitContainerControl1.Panel2.SuspendLayout();
            splitContainerControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)gridControlSelectedProveedores).BeginInit();
            ((System.ComponentModel.ISupportInitialize)selectedProveedoresDtoBindingSource).BeginInit();
            ((System.ComponentModel.ISupportInitialize)gridViewSelectedProveedores).BeginInit();
            ((System.ComponentModel.ISupportInitialize)behaviorManager1).BeginInit();
            SuspendLayout();
            // 
            // panelControl1
            // 
            panelControl1.Controls.Add(btnSeleccionar);
            panelControl1.Dock = DockStyle.Bottom;
            panelControl1.Location = new Point(0, 416);
            panelControl1.Name = "panelControl1";
            panelControl1.Padding = new Padding(10);
            panelControl1.Size = new Size(763, 64);
            panelControl1.TabIndex = 0;
            // 
            // btnSeleccionar
            // 
            btnSeleccionar.Appearance.BackColor = Color.FromArgb(88, 123, 127);
            btnSeleccionar.Appearance.ForeColor = Color.White;
            btnSeleccionar.Appearance.Options.UseBackColor = true;
            btnSeleccionar.Appearance.Options.UseForeColor = true;
            btnSeleccionar.Dock = DockStyle.Right;
            btnSeleccionar.ImageOptions.AllowGlyphSkinning = DevExpress.Utils.DefaultBoolean.True;
            btnSeleccionar.ImageOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("btnSeleccionar.ImageOptions.SvgImage");
            btnSeleccionar.Location = new Point(587, 12);
            btnSeleccionar.Name = "btnSeleccionar";
            btnSeleccionar.Size = new Size(164, 40);
            btnSeleccionar.TabIndex = 0;
            btnSeleccionar.Text = "Seleccionar y guardar";
            btnSeleccionar.Click += btnSeleccionar_Click;
            // 
            // gridControlProveedores
            // 
            gridControlProveedores.DataSource = proveedoresDtoBindingSource;
            gridControlProveedores.Dock = DockStyle.Fill;
            gridControlProveedores.Location = new Point(0, 0);
            gridControlProveedores.MainView = gridViewProveedores;
            gridControlProveedores.Name = "gridControlProveedores";
            gridControlProveedores.Size = new Size(350, 410);
            gridControlProveedores.TabIndex = 1;
            gridControlProveedores.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] { gridViewProveedores });
            // 
            // proveedoresDtoBindingSource
            // 
            proveedoresDtoBindingSource.DataSource = typeof(Dto.ProveedoresDto);
            // 
            // gridViewProveedores
            // 
            behaviorManager1.SetBehaviors(gridViewProveedores, new DevExpress.Utils.Behaviors.Behavior[] { DevExpress.Utils.DragDrop.DragDropBehavior.Create(typeof(DevExpress.XtraGrid.Extensions.ColumnViewDragDropSource), true, true, true, true, dragDropEvents1) });
            gridViewProveedores.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] { colNombre, colRuc, colTelefono, colEmail, colContacto });
            gridViewProveedores.GridControl = gridControlProveedores;
            gridViewProveedores.Name = "gridViewProveedores";
            gridViewProveedores.OptionsBehavior.Editable = false;
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
            // 
            // colContacto
            // 
            colContacto.FieldName = "Contacto";
            colContacto.Name = "colContacto";
            colContacto.Visible = true;
            colContacto.VisibleIndex = 3;
            // 
            // splitContainerControl1
            // 
            splitContainerControl1.Dock = DockStyle.Fill;
            splitContainerControl1.Location = new Point(0, 0);
            splitContainerControl1.Name = "splitContainerControl1";
            splitContainerControl1.Padding = new Padding(3);
            // 
            // splitContainerControl1.Panel1
            // 
            splitContainerControl1.Panel1.Controls.Add(gridControlProveedores);
            splitContainerControl1.Panel1.MinSize = 350;
            splitContainerControl1.Panel1.Text = "Panel1";
            // 
            // splitContainerControl1.Panel2
            // 
            splitContainerControl1.Panel2.Controls.Add(gridControlSelectedProveedores);
            splitContainerControl1.Panel2.Text = "Panel2";
            splitContainerControl1.Size = new Size(763, 416);
            splitContainerControl1.SplitterPosition = 350;
            splitContainerControl1.TabIndex = 2;
            // 
            // gridControlSelectedProveedores
            // 
            gridControlSelectedProveedores.DataSource = selectedProveedoresDtoBindingSource;
            gridControlSelectedProveedores.Dock = DockStyle.Fill;
            gridControlSelectedProveedores.Location = new Point(0, 0);
            gridControlSelectedProveedores.MainView = gridViewSelectedProveedores;
            gridControlSelectedProveedores.Name = "gridControlSelectedProveedores";
            gridControlSelectedProveedores.Size = new Size(395, 410);
            gridControlSelectedProveedores.TabIndex = 0;
            gridControlSelectedProveedores.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] { gridViewSelectedProveedores });
            // 
            // selectedProveedoresDtoBindingSource
            // 
            selectedProveedoresDtoBindingSource.DataSource = typeof(Dto.ProveedoresDto);
            // 
            // gridViewSelectedProveedores
            // 
            behaviorManager1.SetBehaviors(gridViewSelectedProveedores, new DevExpress.Utils.Behaviors.Behavior[] { DevExpress.Utils.DragDrop.DragDropBehavior.Create(typeof(DevExpress.XtraGrid.Extensions.ColumnViewDragDropSource), true, true, true, true, dragDropEvents2) });
            gridViewSelectedProveedores.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] { colNombre1, colRuc1, colTelefono1, colContacto1, colMontoManoObra });
            gridViewSelectedProveedores.GridControl = gridControlSelectedProveedores;
            gridViewSelectedProveedores.Name = "gridViewSelectedProveedores";
            gridViewSelectedProveedores.KeyDown += gridViewSelectedProveedores_KeyDown;
            // 
            // colNombre1
            // 
            colNombre1.FieldName = "Nombre";
            colNombre1.Name = "colNombre1";
            colNombre1.OptionsColumn.ReadOnly = true;
            colNombre1.Visible = true;
            colNombre1.VisibleIndex = 0;
            // 
            // colRuc1
            // 
            colRuc1.FieldName = "Ruc";
            colRuc1.Name = "colRuc1";
            colRuc1.OptionsColumn.ReadOnly = true;
            colRuc1.Visible = true;
            colRuc1.VisibleIndex = 1;
            // 
            // colTelefono1
            // 
            colTelefono1.FieldName = "Telefono";
            colTelefono1.Name = "colTelefono1";
            colTelefono1.OptionsColumn.ReadOnly = true;
            colTelefono1.Visible = true;
            colTelefono1.VisibleIndex = 2;
            // 
            // colContacto1
            // 
            colContacto1.FieldName = "Contacto";
            colContacto1.Name = "colContacto1";
            colContacto1.OptionsColumn.ReadOnly = true;
            colContacto1.Visible = true;
            colContacto1.VisibleIndex = 3;
            // 
            // colMontoManoObra
            // 
            colMontoManoObra.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            colMontoManoObra.FieldName = "MontoManoObra";
            colMontoManoObra.Name = "colMontoManoObra";
            colMontoManoObra.Visible = true;
            colMontoManoObra.VisibleIndex = 4;
            // 
            // ProveedoreFormView
            // 
            AutoScaleDimensions = new SizeF(6F, 13F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(splitContainerControl1);
            Controls.Add(panelControl1);
            Name = "ProveedoreFormView";
            Size = new Size(763, 480);
            Load += ProveedoreFormView_Load;
            ((System.ComponentModel.ISupportInitialize)panelControl1).EndInit();
            panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)gridControlProveedores).EndInit();
            ((System.ComponentModel.ISupportInitialize)proveedoresDtoBindingSource).EndInit();
            ((System.ComponentModel.ISupportInitialize)gridViewProveedores).EndInit();
            ((System.ComponentModel.ISupportInitialize)splitContainerControl1.Panel1).EndInit();
            splitContainerControl1.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainerControl1.Panel2).EndInit();
            splitContainerControl1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainerControl1).EndInit();
            splitContainerControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)gridControlSelectedProveedores).EndInit();
            ((System.ComponentModel.ISupportInitialize)selectedProveedoresDtoBindingSource).EndInit();
            ((System.ComponentModel.ISupportInitialize)gridViewSelectedProveedores).EndInit();
            ((System.ComponentModel.ISupportInitialize)behaviorManager1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.SimpleButton btnSeleccionar;
        private DevExpress.XtraGrid.GridControl gridControlProveedores;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewProveedores;
        private BindingSource proveedoresDtoBindingSource;
        private DevExpress.XtraGrid.Columns.GridColumn colNombre;
        private DevExpress.XtraGrid.Columns.GridColumn colRuc;
        private DevExpress.XtraGrid.Columns.GridColumn colTelefono;
        private DevExpress.XtraGrid.Columns.GridColumn colEmail;
        private DevExpress.XtraGrid.Columns.GridColumn colContacto;
        private DevExpress.XtraEditors.SplitContainerControl splitContainerControl1;
        private DevExpress.XtraGrid.GridControl gridControlSelectedProveedores;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewSelectedProveedores;
        private BindingSource selectedProveedoresDtoBindingSource;
        private DevExpress.XtraGrid.Columns.GridColumn colNombre1;
        private DevExpress.XtraGrid.Columns.GridColumn colRuc1;
        private DevExpress.XtraGrid.Columns.GridColumn colTelefono1;
        private DevExpress.XtraGrid.Columns.GridColumn colContacto1;
        private DevExpress.Utils.Behaviors.BehaviorManager behaviorManager1;
        private DevExpress.Utils.DragDrop.DragDropEvents dragDropEvents1;
        private DevExpress.Utils.DragDrop.DragDropEvents dragDropEvents2;
        private DevExpress.XtraGrid.Columns.GridColumn colMontoManoObra;
    }
}