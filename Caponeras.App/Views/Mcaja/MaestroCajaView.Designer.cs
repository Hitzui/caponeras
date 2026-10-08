namespace Caponeras.App.Views.Mcaja
{
    sealed partial class MaestroCajaView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MaestroCajaView));
            tablePanel1 = new DevExpress.Utils.Layout.TablePanel();
            lblSaldoFinal = new DevExpress.XtraEditors.LabelControl();
            lblSalidas = new DevExpress.XtraEditors.LabelControl();
            lblEntradas = new DevExpress.XtraEditors.LabelControl();
            lblSaldoInicial = new DevExpress.XtraEditors.LabelControl();
            labelControl4 = new DevExpress.XtraEditors.LabelControl();
            labelControl3 = new DevExpress.XtraEditors.LabelControl();
            labelControl2 = new DevExpress.XtraEditors.LabelControl();
            labelControl1 = new DevExpress.XtraEditors.LabelControl();
            gridControl1 = new DevExpress.XtraGrid.GridControl();
            detaMovimientosDtoBindingSource = new BindingSource(components);
            gridViewDetalleMovimientos = new DevExpress.XtraGrid.Views.Grid.GridView();
            colFecha = new DevExpress.XtraGrid.Columns.GridColumn();
            colConcepto = new DevExpress.XtraGrid.Columns.GridColumn();
            colReferenciaTipo = new DevExpress.XtraGrid.Columns.GridColumn();
            colEfectivo = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)tablePanel1).BeginInit();
            tablePanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)gridControl1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)detaMovimientosDtoBindingSource).BeginInit();
            ((System.ComponentModel.ISupportInitialize)gridViewDetalleMovimientos).BeginInit();
            SuspendLayout();
            // 
            // tablePanel1
            // 
            tablePanel1.Appearance.BorderColor = Color.FromArgb(64, 64, 64);
            tablePanel1.Appearance.Options.UseBorderColor = true;
            tablePanel1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            tablePanel1.Columns.AddRange(new DevExpress.Utils.Layout.TablePanelColumn[] { new DevExpress.Utils.Layout.TablePanelColumn(DevExpress.Utils.Layout.TablePanelEntityStyle.Relative, 25F), new DevExpress.Utils.Layout.TablePanelColumn(DevExpress.Utils.Layout.TablePanelEntityStyle.Relative, 25F), new DevExpress.Utils.Layout.TablePanelColumn(DevExpress.Utils.Layout.TablePanelEntityStyle.Relative, 25F), new DevExpress.Utils.Layout.TablePanelColumn(DevExpress.Utils.Layout.TablePanelEntityStyle.Relative, 25F) });
            tablePanel1.Controls.Add(lblSaldoFinal);
            tablePanel1.Controls.Add(lblSalidas);
            tablePanel1.Controls.Add(lblEntradas);
            tablePanel1.Controls.Add(lblSaldoInicial);
            tablePanel1.Controls.Add(labelControl4);
            tablePanel1.Controls.Add(labelControl3);
            tablePanel1.Controls.Add(labelControl2);
            tablePanel1.Controls.Add(labelControl1);
            tablePanel1.Dock = DockStyle.Top;
            tablePanel1.Location = new Point(0, 0);
            tablePanel1.Name = "tablePanel1";
            tablePanel1.Rows.AddRange(new DevExpress.Utils.Layout.TablePanelRow[] { new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.Absolute, 26F), new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.Absolute, 26F) });
            tablePanel1.ShowGrid = DevExpress.Utils.DefaultBoolean.False;
            tablePanel1.Size = new Size(859, 106);
            tablePanel1.TabIndex = 0;
            tablePanel1.UseSkinIndents = true;
            // 
            // lblSaldoFinal
            // 
            lblSaldoFinal.Appearance.BorderColor = Color.Black;
            lblSaldoFinal.Appearance.Options.UseBorderColor = true;
            lblSaldoFinal.Appearance.Options.UseTextOptions = true;
            lblSaldoFinal.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            lblSaldoFinal.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            lblSaldoFinal.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            lblSaldoFinal.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            tablePanel1.SetColumn(lblSaldoFinal, 3);
            lblSaldoFinal.Dock = DockStyle.Fill;
            lblSaldoFinal.Location = new Point(641, 38);
            lblSaldoFinal.Name = "lblSaldoFinal";
            tablePanel1.SetRow(lblSaldoFinal, 1);
            lblSaldoFinal.Size = new Size(205, 55);
            lblSaldoFinal.TabIndex = 7;
            lblSaldoFinal.Text = "0.0";
            // 
            // lblSalidas
            // 
            lblSalidas.Appearance.BorderColor = Color.Black;
            lblSalidas.Appearance.Options.UseBorderColor = true;
            lblSalidas.Appearance.Options.UseTextOptions = true;
            lblSalidas.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            lblSalidas.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            lblSalidas.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            lblSalidas.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            tablePanel1.SetColumn(lblSalidas, 2);
            lblSalidas.Dock = DockStyle.Fill;
            lblSalidas.Location = new Point(432, 38);
            lblSalidas.Name = "lblSalidas";
            tablePanel1.SetRow(lblSalidas, 1);
            lblSalidas.Size = new Size(205, 55);
            lblSalidas.TabIndex = 6;
            lblSalidas.Text = "0.0";
            // 
            // lblEntradas
            // 
            lblEntradas.Appearance.BorderColor = Color.Black;
            lblEntradas.Appearance.Options.UseBorderColor = true;
            lblEntradas.Appearance.Options.UseTextOptions = true;
            lblEntradas.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            lblEntradas.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            lblEntradas.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            lblEntradas.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            tablePanel1.SetColumn(lblEntradas, 1);
            lblEntradas.Dock = DockStyle.Fill;
            lblEntradas.Location = new Point(222, 38);
            lblEntradas.Name = "lblEntradas";
            tablePanel1.SetRow(lblEntradas, 1);
            lblEntradas.Size = new Size(205, 55);
            lblEntradas.TabIndex = 5;
            lblEntradas.Text = "0.0";
            // 
            // lblSaldoInicial
            // 
            lblSaldoInicial.Appearance.BorderColor = Color.Black;
            lblSaldoInicial.Appearance.Options.UseBorderColor = true;
            lblSaldoInicial.Appearance.Options.UseTextOptions = true;
            lblSaldoInicial.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            lblSaldoInicial.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            lblSaldoInicial.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            lblSaldoInicial.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            tablePanel1.SetColumn(lblSaldoInicial, 0);
            lblSaldoInicial.Dock = DockStyle.Fill;
            lblSaldoInicial.Location = new Point(13, 38);
            lblSaldoInicial.Name = "lblSaldoInicial";
            tablePanel1.SetRow(lblSaldoInicial, 1);
            lblSaldoInicial.Size = new Size(205, 55);
            lblSaldoInicial.TabIndex = 4;
            lblSaldoInicial.Text = "0.0";
            // 
            // labelControl4
            // 
            labelControl4.Appearance.BorderColor = Color.Black;
            labelControl4.Appearance.Font = new Font("Tahoma", 8.25F, FontStyle.Bold);
            labelControl4.Appearance.Options.UseBorderColor = true;
            labelControl4.Appearance.Options.UseFont = true;
            labelControl4.Appearance.Options.UseTextOptions = true;
            labelControl4.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            labelControl4.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            labelControl4.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            labelControl4.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            tablePanel1.SetColumn(labelControl4, 3);
            labelControl4.Dock = DockStyle.Fill;
            labelControl4.Location = new Point(641, 12);
            labelControl4.Name = "labelControl4";
            tablePanel1.SetRow(labelControl4, 0);
            labelControl4.Size = new Size(205, 22);
            labelControl4.TabIndex = 3;
            labelControl4.Text = "Saldo Final";
            // 
            // labelControl3
            // 
            labelControl3.Appearance.BorderColor = Color.Black;
            labelControl3.Appearance.Font = new Font("Tahoma", 8.25F, FontStyle.Bold);
            labelControl3.Appearance.Options.UseBorderColor = true;
            labelControl3.Appearance.Options.UseFont = true;
            labelControl3.Appearance.Options.UseTextOptions = true;
            labelControl3.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            labelControl3.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            labelControl3.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            labelControl3.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            tablePanel1.SetColumn(labelControl3, 2);
            labelControl3.Dock = DockStyle.Fill;
            labelControl3.Location = new Point(432, 12);
            labelControl3.Name = "labelControl3";
            tablePanel1.SetRow(labelControl3, 0);
            labelControl3.Size = new Size(205, 22);
            labelControl3.TabIndex = 2;
            labelControl3.Text = "Salidas";
            // 
            // labelControl2
            // 
            labelControl2.Appearance.BorderColor = Color.Black;
            labelControl2.Appearance.Font = new Font("Tahoma", 8.25F, FontStyle.Bold);
            labelControl2.Appearance.Options.UseBorderColor = true;
            labelControl2.Appearance.Options.UseFont = true;
            labelControl2.Appearance.Options.UseTextOptions = true;
            labelControl2.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            labelControl2.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            labelControl2.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            labelControl2.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            tablePanel1.SetColumn(labelControl2, 1);
            labelControl2.Dock = DockStyle.Fill;
            labelControl2.Location = new Point(222, 12);
            labelControl2.Name = "labelControl2";
            tablePanel1.SetRow(labelControl2, 0);
            labelControl2.Size = new Size(205, 22);
            labelControl2.TabIndex = 1;
            labelControl2.Text = "Entradas";
            // 
            // labelControl1
            // 
            labelControl1.Appearance.BorderColor = Color.Black;
            labelControl1.Appearance.Font = new Font("Tahoma", 8.25F, FontStyle.Bold);
            labelControl1.Appearance.Options.UseBorderColor = true;
            labelControl1.Appearance.Options.UseFont = true;
            labelControl1.Appearance.Options.UseTextOptions = true;
            labelControl1.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            labelControl1.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            labelControl1.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            labelControl1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            tablePanel1.SetColumn(labelControl1, 0);
            labelControl1.Dock = DockStyle.Fill;
            labelControl1.Location = new Point(13, 12);
            labelControl1.Name = "labelControl1";
            tablePanel1.SetRow(labelControl1, 0);
            labelControl1.Size = new Size(205, 22);
            labelControl1.TabIndex = 0;
            labelControl1.Text = "Saldo Inicial";
            // 
            // gridControl1
            // 
            gridControl1.DataSource = detaMovimientosDtoBindingSource;
            gridControl1.Dock = DockStyle.Fill;
            gridControl1.Location = new Point(0, 106);
            gridControl1.MainView = gridViewDetalleMovimientos;
            gridControl1.Name = "gridControl1";
            gridControl1.Size = new Size(859, 462);
            gridControl1.TabIndex = 1;
            gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] { gridViewDetalleMovimientos });
            // 
            // detaMovimientosDtoBindingSource
            // 
            detaMovimientosDtoBindingSource.DataSource = typeof(Dto.DetaMovimientosDto);
            // 
            // gridViewDetalleMovimientos
            // 
            gridViewDetalleMovimientos.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] { colFecha, colConcepto, colReferenciaTipo, colEfectivo });
            gridViewDetalleMovimientos.GridControl = gridControl1;
            gridViewDetalleMovimientos.Name = "gridViewDetalleMovimientos";
            // 
            // colFecha
            // 
            colFecha.FieldName = "Fecha";
            colFecha.Name = "colFecha";
            colFecha.Visible = true;
            colFecha.VisibleIndex = 0;
            // 
            // colConcepto
            // 
            colConcepto.FieldName = "Concepto";
            colConcepto.Name = "colConcepto";
            colConcepto.Visible = true;
            colConcepto.VisibleIndex = 1;
            // 
            // colReferenciaTipo
            // 
            colReferenciaTipo.FieldName = "ReferenciaTipo";
            colReferenciaTipo.Name = "colReferenciaTipo";
            colReferenciaTipo.Visible = true;
            colReferenciaTipo.VisibleIndex = 2;
            // 
            // colEfectivo
            // 
            colEfectivo.FieldName = "Efectivo";
            colEfectivo.Name = "colEfectivo";
            colEfectivo.Visible = true;
            colEfectivo.VisibleIndex = 3;
            // 
            // MaestroCajaView
            // 
            AutoScaleDimensions = new SizeF(6F, 13F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(859, 568);
            Controls.Add(gridControl1);
            Controls.Add(tablePanel1);
            IconOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("MaestroCajaView.IconOptions.SvgImage");
            Name = "MaestroCajaView";
            Text = "Detalle de Caja";
            Load += MaestroCajaView_Load;
            ((System.ComponentModel.ISupportInitialize)tablePanel1).EndInit();
            tablePanel1.ResumeLayout(false);
            tablePanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)gridControl1).EndInit();
            ((System.ComponentModel.ISupportInitialize)detaMovimientosDtoBindingSource).EndInit();
            ((System.ComponentModel.ISupportInitialize)gridViewDetalleMovimientos).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DevExpress.Utils.Layout.TablePanel tablePanel1;
        private DevExpress.XtraEditors.LabelControl lblSaldoFinal;
        private DevExpress.XtraEditors.LabelControl lblSalidas;
        private DevExpress.XtraEditors.LabelControl lblEntradas;
        private DevExpress.XtraEditors.LabelControl lblSaldoInicial;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewDetalleMovimientos;
        private BindingSource detaMovimientosDtoBindingSource;
        private DevExpress.XtraGrid.Columns.GridColumn colFecha;
        private DevExpress.XtraGrid.Columns.GridColumn colConcepto;
        private DevExpress.XtraGrid.Columns.GridColumn colReferenciaTipo;
        private DevExpress.XtraGrid.Columns.GridColumn colEfectivo;
    }
}