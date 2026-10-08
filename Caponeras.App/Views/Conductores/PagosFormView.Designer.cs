namespace Caponeras.App.Views.Conductores
{
    partial class PagosFormView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PagosFormView));
            gridControl1 = new DevExpress.XtraGrid.GridControl();
            cuotaDetalleBindingSource = new BindingSource(components);
            gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            colFecha = new DevExpress.XtraGrid.Columns.GridColumn();
            colCodigo = new DevExpress.XtraGrid.Columns.GridColumn();
            colPlaca = new DevExpress.XtraGrid.Columns.GridColumn();
            colMontoCuota = new DevExpress.XtraGrid.Columns.GridColumn();
            colMontoEntregado = new DevExpress.XtraGrid.Columns.GridColumn();
            colDiferencia = new DevExpress.XtraGrid.Columns.GridColumn();
            colPorcentaje = new DevExpress.XtraGrid.Columns.GridColumn();
            colConductor = new DevExpress.XtraGrid.Columns.GridColumn();
            stackPanel1 = new DevExpress.Utils.Layout.StackPanel();
            labelControl1 = new DevExpress.XtraEditors.LabelControl();
            txtFecha = new DevExpress.XtraEditors.DateEdit();
            btnSearch = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)gridControl1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)cuotaDetalleBindingSource).BeginInit();
            ((System.ComponentModel.ISupportInitialize)gridView1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)stackPanel1).BeginInit();
            stackPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)txtFecha.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)txtFecha.Properties.CalendarTimeProperties).BeginInit();
            SuspendLayout();
            // 
            // gridControl1
            // 
            gridControl1.DataSource = cuotaDetalleBindingSource;
            gridControl1.Dock = DockStyle.Fill;
            gridControl1.Location = new Point(0, 44);
            gridControl1.MainView = gridView1;
            gridControl1.Name = "gridControl1";
            gridControl1.Size = new Size(673, 396);
            gridControl1.TabIndex = 0;
            gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] { gridView1 });
            // 
            // gridView1
            // 
            gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] { colFecha, colCodigo, colPlaca, colMontoCuota, colMontoEntregado, colDiferencia, colPorcentaje, colConductor });
            gridView1.GridControl = gridControl1;
            gridView1.Name = "gridView1";
            // 
            // colFecha
            // 
            colFecha.FieldName = "Fecha";
            colFecha.Name = "colFecha";
            colFecha.Visible = true;
            colFecha.VisibleIndex = 0;
            // 
            // colCodigo
            // 
            colCodigo.FieldName = "Codigo";
            colCodigo.Name = "colCodigo";
            colCodigo.Visible = true;
            colCodigo.VisibleIndex = 1;
            // 
            // colPlaca
            // 
            colPlaca.FieldName = "Placa";
            colPlaca.Name = "colPlaca";
            colPlaca.Visible = true;
            colPlaca.VisibleIndex = 2;
            // 
            // colMontoCuota
            // 
            colMontoCuota.FieldName = "MontoCuota";
            colMontoCuota.Name = "colMontoCuota";
            colMontoCuota.Visible = true;
            colMontoCuota.VisibleIndex = 3;
            // 
            // colMontoEntregado
            // 
            colMontoEntregado.FieldName = "MontoEntregado";
            colMontoEntregado.Name = "colMontoEntregado";
            colMontoEntregado.Visible = true;
            colMontoEntregado.VisibleIndex = 4;
            // 
            // colDiferencia
            // 
            colDiferencia.FieldName = "Diferencia";
            colDiferencia.Name = "colDiferencia";
            colDiferencia.Visible = true;
            colDiferencia.VisibleIndex = 5;
            // 
            // colPorcentaje
            // 
            colPorcentaje.FieldName = "Porcentaje";
            colPorcentaje.Name = "colPorcentaje";
            colPorcentaje.Visible = true;
            colPorcentaje.VisibleIndex = 6;
            // 
            // colConductor
            // 
            colConductor.FieldName = "Conductor";
            colConductor.Name = "colConductor";
            colConductor.Visible = true;
            colConductor.VisibleIndex = 7;
            // 
            // stackPanel1
            // 
            stackPanel1.Controls.Add(labelControl1);
            stackPanel1.Controls.Add(txtFecha);
            stackPanel1.Controls.Add(btnSearch);
            stackPanel1.Dock = DockStyle.Top;
            stackPanel1.Location = new Point(0, 0);
            stackPanel1.Name = "stackPanel1";
            stackPanel1.Padding = new Padding(25, 5, 5, 5);
            stackPanel1.Size = new Size(673, 44);
            stackPanel1.TabIndex = 1;
            stackPanel1.UseSkinIndents = true;
            // 
            // labelControl1
            // 
            labelControl1.Location = new Point(27, 15);
            labelControl1.Name = "labelControl1";
            labelControl1.Size = new Size(50, 13);
            labelControl1.TabIndex = 0;
            labelControl1.Text = "Por fecha:";
            // 
            // txtFecha
            // 
            txtFecha.EditValue = null;
            txtFecha.Location = new Point(81, 12);
            txtFecha.Name = "txtFecha";
            txtFecha.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo) });
            txtFecha.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo) });
            txtFecha.Size = new Size(118, 20);
            txtFecha.TabIndex = 1;
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
            btnSearch.Location = new Point(203, 10);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(106, 23);
            btnSearch.TabIndex = 3;
            btnSearch.Text = "Buscar";
            btnSearch.Click += btnSearch_Click;
            // 
            // PagosFormView
            // 
            AutoScaleDimensions = new SizeF(6F, 13F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(673, 440);
            Controls.Add(gridControl1);
            Controls.Add(stackPanel1);
            IconOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("PagosFormView.IconOptions.SvgImage");
            Name = "PagosFormView";
            Text = "Pagos";
            Load += PagosFormView_Load;
            ((System.ComponentModel.ISupportInitialize)gridControl1).EndInit();
            ((System.ComponentModel.ISupportInitialize)cuotaDetalleBindingSource).EndInit();
            ((System.ComponentModel.ISupportInitialize)gridView1).EndInit();
            ((System.ComponentModel.ISupportInitialize)stackPanel1).EndInit();
            stackPanel1.ResumeLayout(false);
            stackPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)txtFecha.Properties.CalendarTimeProperties).EndInit();
            ((System.ComponentModel.ISupportInitialize)txtFecha.Properties).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private BindingSource cuotaDetalleBindingSource;
        private DevExpress.XtraGrid.Columns.GridColumn colFecha;
        private DevExpress.XtraGrid.Columns.GridColumn colCodigo;
        private DevExpress.XtraGrid.Columns.GridColumn colPlaca;
        private DevExpress.XtraGrid.Columns.GridColumn colMontoCuota;
        private DevExpress.XtraGrid.Columns.GridColumn colMontoEntregado;
        private DevExpress.XtraGrid.Columns.GridColumn colDiferencia;
        private DevExpress.XtraGrid.Columns.GridColumn colPorcentaje;
        private DevExpress.XtraGrid.Columns.GridColumn colConductor;
        private DevExpress.Utils.Layout.StackPanel stackPanel1;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.DateEdit txtFecha;
        private DevExpress.XtraEditors.SimpleButton btnSearch;
    }
}