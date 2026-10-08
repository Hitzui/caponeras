namespace Caponeras.App.Views.Mantenimiento
{
    sealed partial class PaymentProveedorFormView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PaymentProveedorFormView));
            gridControlPagoManoObra = new DevExpress.XtraGrid.GridControl();
            manoObraProveedorDtoBindingSource = new BindingSource(components);
            gridViewPagoManoObra = new DevExpress.XtraGrid.Views.Grid.GridView();
            colNombreProveedor = new DevExpress.XtraGrid.Columns.GridColumn();
            colDescripcionTrabajo = new DevExpress.XtraGrid.Columns.GridColumn();
            colEstado = new DevExpress.XtraGrid.Columns.GridColumn();
            colObservacion = new DevExpress.XtraGrid.Columns.GridColumn();
            colFecha = new DevExpress.XtraGrid.Columns.GridColumn();
            colMonto = new DevExpress.XtraGrid.Columns.GridColumn();
            colSaldoPendiente = new DevExpress.XtraGrid.Columns.GridColumn();
            colMontoAplicar = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)tablePanel1).BeginInit();
            tablePanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)gridControlPagoManoObra).BeginInit();
            ((System.ComponentModel.ISupportInitialize)manoObraProveedorDtoBindingSource).BeginInit();
            ((System.ComponentModel.ISupportInitialize)gridViewPagoManoObra).BeginInit();
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
            btnCancelar.Click += btnCancelar_Click;
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
            labelControl1.Size = new Size(865, 30);
            labelControl1.Text = "Pago Mano Obra a Proveedor";
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
            btnAceptar.Location = new Point(633, 21);
            btnAceptar.Margin = new Padding(200, 3, 3, 3);
            tablePanel1.SetRow(btnAceptar, 0);
            btnAceptar.Click += btnAceptar_Click;
            // 
            // tablePanel1
            // 
            tablePanel1.Location = new Point(0, 432);
            tablePanel1.Size = new Size(865, 79);
            // 
            // gridControlPagoManoObra
            // 
            gridControlPagoManoObra.DataSource = manoObraProveedorDtoBindingSource;
            gridControlPagoManoObra.Dock = DockStyle.Fill;
            gridControlPagoManoObra.Location = new Point(0, 0);
            gridControlPagoManoObra.MainView = gridViewPagoManoObra;
            gridControlPagoManoObra.Name = "gridControlPagoManoObra";
            gridControlPagoManoObra.Size = new Size(865, 511);
            gridControlPagoManoObra.TabIndex = 0;
            gridControlPagoManoObra.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] { gridViewPagoManoObra });
            // 
            // manoObraProveedorDtoBindingSource
            // 
            manoObraProveedorDtoBindingSource.DataSource = typeof(Dto.ManoObraProveedorDto);
            // 
            // gridViewPagoManoObra
            // 
            gridViewPagoManoObra.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] { colNombreProveedor, colDescripcionTrabajo, colEstado, colObservacion, colFecha, colMonto, colSaldoPendiente, colMontoAplicar });
            gridViewPagoManoObra.GridControl = gridControlPagoManoObra;
            gridViewPagoManoObra.Name = "gridViewPagoManoObra";
            gridViewPagoManoObra.VertScrollVisibility = DevExpress.XtraGrid.Views.Base.ScrollVisibility.Never;
            gridViewPagoManoObra.ValidateRow += gridViewPagoManoObra_ValidateRow;
            // 
            // colNombreProveedor
            // 
            colNombreProveedor.FieldName = "NombreProveedor";
            colNombreProveedor.Name = "colNombreProveedor";
            colNombreProveedor.OptionsColumn.ReadOnly = true;
            colNombreProveedor.Visible = true;
            colNombreProveedor.VisibleIndex = 0;
            // 
            // colDescripcionTrabajo
            // 
            colDescripcionTrabajo.Caption = "Descripción";
            colDescripcionTrabajo.FieldName = "DescripcionTrabajo";
            colDescripcionTrabajo.Name = "colDescripcionTrabajo";
            colDescripcionTrabajo.OptionsColumn.ReadOnly = true;
            colDescripcionTrabajo.Visible = true;
            colDescripcionTrabajo.VisibleIndex = 1;
            // 
            // colEstado
            // 
            colEstado.FieldName = "Estado";
            colEstado.Name = "colEstado";
            colEstado.OptionsColumn.AllowEdit = false;
            colEstado.OptionsColumn.ReadOnly = true;
            colEstado.Visible = true;
            colEstado.VisibleIndex = 2;
            // 
            // colObservacion
            // 
            colObservacion.FieldName = "Observacion";
            colObservacion.Name = "colObservacion";
            colObservacion.Visible = true;
            colObservacion.VisibleIndex = 3;
            // 
            // colFecha
            // 
            colFecha.FieldName = "Fecha";
            colFecha.Name = "colFecha";
            colFecha.OptionsColumn.ReadOnly = true;
            colFecha.Visible = true;
            colFecha.VisibleIndex = 4;
            // 
            // colMonto
            // 
            colMonto.FieldName = "Monto";
            colMonto.Name = "colMonto";
            colMonto.OptionsColumn.AllowEdit = false;
            colMonto.OptionsColumn.ReadOnly = true;
            colMonto.Visible = true;
            colMonto.VisibleIndex = 5;
            // 
            // colSaldoPendiente
            // 
            colSaldoPendiente.FieldName = "SaldoPendiente";
            colSaldoPendiente.Name = "colSaldoPendiente";
            colSaldoPendiente.OptionsColumn.AllowEdit = false;
            colSaldoPendiente.OptionsColumn.ReadOnly = true;
            colSaldoPendiente.Visible = true;
            colSaldoPendiente.VisibleIndex = 6;
            // 
            // colMontoAplicar
            // 
            colMontoAplicar.FieldName = "MontoAplicar";
            colMontoAplicar.Name = "colMontoAplicar";
            colMontoAplicar.Visible = true;
            colMontoAplicar.VisibleIndex = 7;
            // 
            // PaymentProveedorFormView
            // 
            AutoScaleDimensions = new SizeF(6F, 13F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(865, 511);
            Controls.Add(gridControlPagoManoObra);
            FormBorderStyle = FormBorderStyle.None;
            IconOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("PaymentProveedorFormView.IconOptions.SvgImage");
            Name = "PaymentProveedorFormView";
            Text = "Pago a Proveedor";
            Load += PaymentProveedorFormView_Load;
            Controls.SetChildIndex(gridControlPagoManoObra, 0);
            Controls.SetChildIndex(labelControl1, 0);
            Controls.SetChildIndex(tablePanel1, 0);
            ((System.ComponentModel.ISupportInitialize)tablePanel1).EndInit();
            tablePanel1.ResumeLayout(false);
            tablePanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)gridControlPagoManoObra).EndInit();
            ((System.ComponentModel.ISupportInitialize)manoObraProveedorDtoBindingSource).EndInit();
            ((System.ComponentModel.ISupportInitialize)gridViewPagoManoObra).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DevExpress.XtraGrid.GridControl gridControlPagoManoObra;
        private BindingSource manoObraProveedorDtoBindingSource;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewPagoManoObra;
        private DevExpress.XtraGrid.Columns.GridColumn colNombreProveedor;
        private DevExpress.XtraGrid.Columns.GridColumn colDescripcionTrabajo;
        private DevExpress.XtraGrid.Columns.GridColumn colEstado;
        private DevExpress.XtraGrid.Columns.GridColumn colObservacion;
        private DevExpress.XtraGrid.Columns.GridColumn colFecha;
        private DevExpress.XtraGrid.Columns.GridColumn colMonto;
        private DevExpress.XtraGrid.Columns.GridColumn colSaldoPendiente;
        private DevExpress.XtraGrid.Columns.GridColumn colMontoAplicar;
    }
}