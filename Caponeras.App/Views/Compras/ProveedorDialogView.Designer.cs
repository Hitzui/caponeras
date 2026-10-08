namespace Caponeras.App.Views.Compras
{
    partial class ProveedorDialogView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ProveedorDialogView));
            gridControl1 = new DevExpress.XtraGrid.GridControl();
            proveedoresDtoBindingSource = new BindingSource(components);
            gridViewProveedores = new DevExpress.XtraGrid.Views.Grid.GridView();
            colNombre = new DevExpress.XtraGrid.Columns.GridColumn();
            colRuc = new DevExpress.XtraGrid.Columns.GridColumn();
            colTelefono = new DevExpress.XtraGrid.Columns.GridColumn();
            colEmail = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)tablePanel1).BeginInit();
            tablePanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)gridControl1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)proveedoresDtoBindingSource).BeginInit();
            ((System.ComponentModel.ISupportInitialize)gridViewProveedores).BeginInit();
            SuspendLayout();
            // 
            // btnCancelar
            // 
            btnCancelar.Appearance.BackColor = Color.Red;
            btnCancelar.Appearance.ForeColor = Color.White;
            btnCancelar.Appearance.Options.UseBackColor = true;
            btnCancelar.Appearance.Options.UseForeColor = true;
            tablePanel1.SetColumn(btnCancelar, 0);
            btnCancelar.ImageOptions.AllowGlyphSkinning = DevExpress.Utils.DefaultBoolean.True;
            btnCancelar.ImageOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("btnCancelar.ImageOptions.SvgImage");
            btnCancelar.ImageOptions.SvgImageSize = new Size(32, 32);
            tablePanel1.SetRow(btnCancelar, 0);
            // 
            // labelControl1
            // 
            labelControl1.Appearance.BackColor = Color.Gray;
            labelControl1.Appearance.Font = new Font("Tahoma", 12F, FontStyle.Bold);
            labelControl1.Appearance.ForeColor = Color.White;
            labelControl1.Appearance.Options.UseBackColor = true;
            labelControl1.Appearance.Options.UseFont = true;
            labelControl1.Appearance.Options.UseForeColor = true;
            labelControl1.Appearance.Options.UseTextOptions = true;
            labelControl1.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            labelControl1.Size = new Size(760, 30);
            labelControl1.Text = "Proveedor";
            // 
            // btnAceptar
            // 
            btnAceptar.Appearance.BackColor = Color.ForestGreen;
            btnAceptar.Appearance.ForeColor = Color.White;
            btnAceptar.Appearance.Options.UseBackColor = true;
            btnAceptar.Appearance.Options.UseFont = true;
            btnAceptar.Appearance.Options.UseForeColor = true;
            tablePanel1.SetColumn(btnAceptar, 1);
            btnAceptar.ImageOptions.AllowGlyphSkinning = DevExpress.Utils.DefaultBoolean.True;
            btnAceptar.ImageOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("btnAceptar.ImageOptions.SvgImage");
            btnAceptar.ImageOptions.SvgImageSize = new Size(32, 32);
            btnAceptar.Location = new Point(480, 21);
            tablePanel1.SetRow(btnAceptar, 0);
            btnAceptar.Click += btnAceptar_Click;
            // 
            // tablePanel1
            // 
            tablePanel1.Location = new Point(0, 376);
            tablePanel1.Size = new Size(760, 79);
            // 
            // gridControl1
            // 
            gridControl1.DataSource = proveedoresDtoBindingSource;
            gridControl1.Dock = DockStyle.Fill;
            gridControl1.Location = new Point(0, 30);
            gridControl1.MainView = gridViewProveedores;
            gridControl1.Name = "gridControl1";
            gridControl1.Size = new Size(760, 346);
            gridControl1.TabIndex = 6;
            gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] { gridViewProveedores });
            // 
            // proveedoresDtoBindingSource
            // 
            proveedoresDtoBindingSource.DataSource = typeof(Dto.ProveedoresDto);
            // 
            // gridViewProveedores
            // 
            gridViewProveedores.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] { colNombre, colRuc, colTelefono, colEmail });
            gridViewProveedores.GridControl = gridControl1;
            gridViewProveedores.Name = "gridViewProveedores";
            gridViewProveedores.OptionsBehavior.ReadOnly = true;
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
            // ProveedorDialogView
            // 
            AutoScaleDimensions = new SizeF(6F, 13F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(760, 455);
            Controls.Add(gridControl1);
            FormBorderEffect = DevExpress.XtraEditors.FormBorderEffect.Shadow;
            FormBorderStyle = FormBorderStyle.None;
            Name = "ProveedorDialogView";
            Text = "ProveedorDialogView";
            Load += ProveedorDialogView_Load;
            Controls.SetChildIndex(labelControl1, 0);
            Controls.SetChildIndex(tablePanel1, 0);
            Controls.SetChildIndex(gridControl1, 0);
            ((System.ComponentModel.ISupportInitialize)tablePanel1).EndInit();
            tablePanel1.ResumeLayout(false);
            tablePanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)gridControl1).EndInit();
            ((System.ComponentModel.ISupportInitialize)proveedoresDtoBindingSource).EndInit();
            ((System.ComponentModel.ISupportInitialize)gridViewProveedores).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DevExpress.XtraGrid.GridControl gridControl1;
        private BindingSource proveedoresDtoBindingSource;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewProveedores;
        private DevExpress.XtraGrid.Columns.GridColumn colNombre;
        private DevExpress.XtraGrid.Columns.GridColumn colRuc;
        private DevExpress.XtraGrid.Columns.GridColumn colTelefono;
        private DevExpress.XtraGrid.Columns.GridColumn colEmail;
    }
}