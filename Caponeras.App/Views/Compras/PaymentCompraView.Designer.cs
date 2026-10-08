namespace Caponeras.App.Views.Compras
{
    sealed partial class PaymentCompraView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PaymentCompraView));
            groupControl1 = new DevExpress.XtraEditors.GroupControl();
            txtProveedor = new DevExpress.XtraEditors.TextEdit();
            label3 = new Label();
            txtFechaCompra = new DevExpress.XtraEditors.DateEdit();
            label2 = new Label();
            txtNumeroDocumento = new DevExpress.XtraEditors.TextEdit();
            label1 = new Label();
            groupControl2 = new DevExpress.XtraEditors.GroupControl();
            txtMontoPagar = new DevExpress.XtraEditors.TextEdit();
            label6 = new Label();
            txtSaldo = new DevExpress.XtraEditors.TextEdit();
            label5 = new Label();
            txtMontoOriginal = new DevExpress.XtraEditors.TextEdit();
            label4 = new Label();
            btnAplicar = new DevExpress.XtraEditors.SimpleButton();
            btnCancelar = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)groupControl1).BeginInit();
            groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)txtProveedor.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)txtFechaCompra.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)txtFechaCompra.Properties.CalendarTimeProperties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)txtNumeroDocumento.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)groupControl2).BeginInit();
            groupControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)txtMontoPagar.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)txtSaldo.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)txtMontoOriginal.Properties).BeginInit();
            SuspendLayout();
            // 
            // groupControl1
            // 
            groupControl1.Controls.Add(txtProveedor);
            groupControl1.Controls.Add(label3);
            groupControl1.Controls.Add(txtFechaCompra);
            groupControl1.Controls.Add(label2);
            groupControl1.Controls.Add(txtNumeroDocumento);
            groupControl1.Controls.Add(label1);
            groupControl1.Location = new Point(12, 2);
            groupControl1.Name = "groupControl1";
            groupControl1.Size = new Size(449, 100);
            groupControl1.TabIndex = 0;
            groupControl1.Text = "Información de la compra";
            // 
            // txtProveedor
            // 
            txtProveedor.Location = new Point(97, 50);
            txtProveedor.Name = "txtProveedor";
            txtProveedor.Properties.ReadOnly = true;
            txtProveedor.Size = new Size(328, 20);
            txtProveedor.TabIndex = 5;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(30, 53);
            label3.Name = "label3";
            label3.Size = new Size(61, 13);
            label3.TabIndex = 4;
            label3.Text = "Proveedor:";
            // 
            // txtFechaCompra
            // 
            txtFechaCompra.EditValue = null;
            txtFechaCompra.Enabled = false;
            txtFechaCompra.Location = new Point(325, 24);
            txtFechaCompra.Name = "txtFechaCompra";
            txtFechaCompra.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo) });
            txtFechaCompra.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo) });
            txtFechaCompra.Size = new Size(100, 20);
            txtFechaCompra.TabIndex = 3;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(241, 27);
            label2.Name = "label2";
            label2.Size = new Size(78, 13);
            label2.TabIndex = 2;
            label2.Text = "Fecha compra:";
            // 
            // txtNumeroDocumento
            // 
            txtNumeroDocumento.Location = new Point(97, 24);
            txtNumeroDocumento.Name = "txtNumeroDocumento";
            txtNumeroDocumento.Properties.ReadOnly = true;
            txtNumeroDocumento.Size = new Size(106, 20);
            txtNumeroDocumento.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(15, 26);
            label1.Name = "label1";
            label1.Size = new Size(76, 13);
            label1.TabIndex = 0;
            label1.Text = "# Documento:";
            // 
            // groupControl2
            // 
            groupControl2.Controls.Add(txtMontoPagar);
            groupControl2.Controls.Add(label6);
            groupControl2.Controls.Add(txtSaldo);
            groupControl2.Controls.Add(label5);
            groupControl2.Controls.Add(txtMontoOriginal);
            groupControl2.Controls.Add(label4);
            groupControl2.Location = new Point(12, 108);
            groupControl2.Name = "groupControl2";
            groupControl2.Size = new Size(449, 100);
            groupControl2.TabIndex = 1;
            groupControl2.Text = "Información de pago";
            // 
            // txtMontoPagar
            // 
            txtMontoPagar.Location = new Point(325, 49);
            txtMontoPagar.Name = "txtMontoPagar";
            txtMontoPagar.Properties.BeepOnError = true;
            txtMontoPagar.Properties.MaskSettings.Set("MaskManagerType", typeof(DevExpress.Data.Mask.NumericMaskManager));
            txtMontoPagar.Properties.MaskSettings.Set("mask", "n");
            txtMontoPagar.Properties.UseMaskAsDisplayFormat = true;
            txtMontoPagar.Size = new Size(106, 20);
            txtMontoPagar.TabIndex = 7;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(237, 52);
            label6.Name = "label6";
            label6.Size = new Size(81, 13);
            label6.TabIndex = 6;
            label6.Text = "Monto a pagar:";
            // 
            // txtSaldo
            // 
            txtSaldo.Location = new Point(108, 50);
            txtSaldo.Name = "txtSaldo";
            txtSaldo.Properties.ReadOnly = true;
            txtSaldo.Size = new Size(106, 20);
            txtSaldo.TabIndex = 5;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(15, 52);
            label5.Name = "label5";
            label5.Size = new Size(87, 13);
            label5.TabIndex = 4;
            label5.Text = "Saldo por pagar.";
            // 
            // txtMontoOriginal
            // 
            txtMontoOriginal.Location = new Point(108, 24);
            txtMontoOriginal.Name = "txtMontoOriginal";
            txtMontoOriginal.Properties.ReadOnly = true;
            txtMontoOriginal.Size = new Size(106, 20);
            txtMontoOriginal.TabIndex = 3;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(24, 27);
            label4.Name = "label4";
            label4.Size = new Size(78, 13);
            label4.TabIndex = 2;
            label4.Text = "Monto original:";
            // 
            // btnAplicar
            // 
            btnAplicar.Appearance.BackColor = DevExpress.LookAndFeel.DXSkinColors.FillColors.Success;
            btnAplicar.Appearance.ForeColor = Color.White;
            btnAplicar.Appearance.Options.UseBackColor = true;
            btnAplicar.Appearance.Options.UseForeColor = true;
            btnAplicar.ImageOptions.AllowGlyphSkinning = DevExpress.Utils.DefaultBoolean.True;
            btnAplicar.ImageOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("btnAplicar.ImageOptions.SvgImage");
            btnAplicar.ImageOptions.SvgImageSize = new Size(24, 24);
            btnAplicar.Location = new Point(362, 240);
            btnAplicar.Name = "btnAplicar";
            btnAplicar.Size = new Size(99, 23);
            btnAplicar.TabIndex = 2;
            btnAplicar.Text = "Aplicar";
            btnAplicar.Click += btnAplicar_Click;
            // 
            // btnCancelar
            // 
            btnCancelar.Appearance.BackColor = Color.FromArgb(192, 0, 0);
            btnCancelar.Appearance.Options.UseBackColor = true;
            btnCancelar.Location = new Point(58, 240);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(75, 23);
            btnCancelar.TabIndex = 3;
            btnCancelar.Text = "Cancelar";
            btnCancelar.Click += btnCancelar_Click;
            // 
            // PaymentCompraView
            // 
            AutoScaleDimensions = new SizeF(6F, 13F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(473, 278);
            Controls.Add(btnCancelar);
            Controls.Add(btnAplicar);
            Controls.Add(groupControl2);
            Controls.Add(groupControl1);
            FormBorderEffect = DevExpress.XtraEditors.FormBorderEffect.Shadow;
            FormBorderStyle = FormBorderStyle.FixedSingle;
            IconOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("PaymentCompraView.IconOptions.SvgImage");
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "PaymentCompraView";
            Text = "Pagar compra";
            Load += PaymentCompraView_Load;
            ((System.ComponentModel.ISupportInitialize)groupControl1).EndInit();
            groupControl1.ResumeLayout(false);
            groupControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)txtProveedor.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)txtFechaCompra.Properties.CalendarTimeProperties).EndInit();
            ((System.ComponentModel.ISupportInitialize)txtFechaCompra.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)txtNumeroDocumento.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)groupControl2).EndInit();
            groupControl2.ResumeLayout(false);
            groupControl2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)txtMontoPagar.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)txtSaldo.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)txtMontoOriginal.Properties).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.TextEdit txtNumeroDocumento;
        private Label label1;
        private DevExpress.XtraEditors.DateEdit txtFechaCompra;
        private Label label2;
        private DevExpress.XtraEditors.TextEdit txtProveedor;
        private Label label3;
        private DevExpress.XtraEditors.GroupControl groupControl2;
        private DevExpress.XtraEditors.TextEdit txtSaldo;
        private Label label5;
        private DevExpress.XtraEditors.TextEdit txtMontoOriginal;
        private Label label4;
        private DevExpress.XtraEditors.TextEdit txtMontoPagar;
        private Label label6;
        private DevExpress.XtraEditors.SimpleButton btnAplicar;
        private DevExpress.XtraEditors.SimpleButton btnCancelar;
    }
}