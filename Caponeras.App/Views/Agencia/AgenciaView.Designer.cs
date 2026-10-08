namespace Caponeras.App.Views.Agencia
{
    partial class AgenciaView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AgenciaView));
            gridControlAgencia = new DevExpress.XtraGrid.GridControl();
            agenciaDtoBindingSource = new BindingSource(components);
            gridViewAgencias = new DevExpress.XtraGrid.Views.Grid.GridView();
            colIdagencia = new DevExpress.XtraGrid.Columns.GridColumn();
            colCodagencia = new DevExpress.XtraGrid.Columns.GridColumn();
            colDescripcion = new DevExpress.XtraGrid.Columns.GridColumn();
            colRuc = new DevExpress.XtraGrid.Columns.GridColumn();
            colActivio = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)gridControlAgencia).BeginInit();
            ((System.ComponentModel.ISupportInitialize)agenciaDtoBindingSource).BeginInit();
            ((System.ComponentModel.ISupportInitialize)gridViewAgencias).BeginInit();
            SuspendLayout();
            // 
            // gridControlAgencia
            // 
            gridControlAgencia.DataSource = agenciaDtoBindingSource;
            gridControlAgencia.Dock = DockStyle.Fill;
            gridControlAgencia.Location = new Point(0, 0);
            gridControlAgencia.MainView = gridViewAgencias;
            gridControlAgencia.Name = "gridControlAgencia";
            gridControlAgencia.Size = new Size(615, 372);
            gridControlAgencia.TabIndex = 0;
            gridControlAgencia.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] { gridViewAgencias });
            // 
            // agenciaDtoBindingSource
            // 
            agenciaDtoBindingSource.DataSource = typeof(Dto.AgenciaDto);
            // 
            // gridViewAgencias
            // 
            gridViewAgencias.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] { colIdagencia, colCodagencia, colDescripcion, colRuc, colActivio });
            gridViewAgencias.GridControl = gridControlAgencia;
            gridViewAgencias.Name = "gridViewAgencias";
            // 
            // colIdagencia
            // 
            colIdagencia.FieldName = "Idagencia";
            colIdagencia.Name = "colIdagencia";
            colIdagencia.Visible = true;
            colIdagencia.VisibleIndex = 0;
            // 
            // colCodagencia
            // 
            colCodagencia.FieldName = "Codagencia";
            colCodagencia.Name = "colCodagencia";
            colCodagencia.Visible = true;
            colCodagencia.VisibleIndex = 1;
            // 
            // colDescripcion
            // 
            colDescripcion.FieldName = "Descripcion";
            colDescripcion.Name = "colDescripcion";
            colDescripcion.Visible = true;
            colDescripcion.VisibleIndex = 2;
            // 
            // colRuc
            // 
            colRuc.FieldName = "Ruc";
            colRuc.Name = "colRuc";
            colRuc.Visible = true;
            colRuc.VisibleIndex = 3;
            // 
            // colActivio
            // 
            colActivio.FieldName = "Activio";
            colActivio.Name = "colActivio";
            colActivio.Visible = true;
            colActivio.VisibleIndex = 4;
            // 
            // AgenciaView
            // 
            AutoScaleDimensions = new SizeF(6F, 13F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(615, 372);
            Controls.Add(gridControlAgencia);
            IconOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("AgenciaView.IconOptions.SvgImage");
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "AgenciaView";
            Text = "Agencias";
            Load += AgenciaView_Load;
            ((System.ComponentModel.ISupportInitialize)gridControlAgencia).EndInit();
            ((System.ComponentModel.ISupportInitialize)agenciaDtoBindingSource).EndInit();
            ((System.ComponentModel.ISupportInitialize)gridViewAgencias).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DevExpress.XtraGrid.GridControl gridControlAgencia;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewAgencias;
        private BindingSource agenciaDtoBindingSource;
        private DevExpress.XtraGrid.Columns.GridColumn colIdagencia;
        private DevExpress.XtraGrid.Columns.GridColumn colCodagencia;
        private DevExpress.XtraGrid.Columns.GridColumn colDescripcion;
        private DevExpress.XtraGrid.Columns.GridColumn colRuc;
        private DevExpress.XtraGrid.Columns.GridColumn colActivio;
    }
}