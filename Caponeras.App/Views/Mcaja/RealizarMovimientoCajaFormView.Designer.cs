namespace Caponeras.App.Views.Mcaja
{
    partial class RealizarMovimientoCajaFormView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RealizarMovimientoCajaFormView));
            layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            txtConcepto = new DevExpress.XtraEditors.TextEdit();
            txtMonto = new DevExpress.XtraEditors.TextEdit();
            cmbMovcaja = new DevExpress.XtraEditors.LookUpEdit();
            movCajasDtoBindingSource = new BindingSource(components);
            Root = new DevExpress.XtraLayout.LayoutControlGroup();
            layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)tablePanel1).BeginInit();
            tablePanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)layoutControl1).BeginInit();
            layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)txtConcepto.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)txtMonto.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)cmbMovcaja.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)movCajasDtoBindingSource).BeginInit();
            ((System.ComponentModel.ISupportInitialize)Root).BeginInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem3).BeginInit();
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
            labelControl1.Appearance.BackColor = Color.FromArgb(64, 64, 64);
            labelControl1.Appearance.Font = new Font("Tahoma", 12F, FontStyle.Bold);
            labelControl1.Appearance.ForeColor = Color.White;
            labelControl1.Appearance.Options.UseBackColor = true;
            labelControl1.Appearance.Options.UseFont = true;
            labelControl1.Appearance.Options.UseForeColor = true;
            labelControl1.Appearance.Options.UseTextOptions = true;
            labelControl1.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            labelControl1.Size = new Size(610, 30);
            labelControl1.Text = "Realizar Movimiento en Caja";
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
            btnAceptar.Location = new Point(455, 21);
            btnAceptar.Margin = new Padding(150, 3, 3, 3);
            tablePanel1.SetRow(btnAceptar, 0);
            btnAceptar.Click += btnAceptar_Click;
            // 
            // tablePanel1
            // 
            tablePanel1.Location = new Point(0, 220);
            tablePanel1.Size = new Size(610, 79);
            // 
            // layoutControl1
            // 
            layoutControl1.Controls.Add(txtConcepto);
            layoutControl1.Controls.Add(txtMonto);
            layoutControl1.Controls.Add(cmbMovcaja);
            layoutControl1.Dock = DockStyle.Fill;
            layoutControl1.Location = new Point(0, 30);
            layoutControl1.Name = "layoutControl1";
            layoutControl1.Root = Root;
            layoutControl1.Size = new Size(610, 190);
            layoutControl1.TabIndex = 6;
            layoutControl1.Text = "layoutControl1";
            // 
            // txtConcepto
            // 
            txtConcepto.Location = new Point(86, 12);
            txtConcepto.Name = "txtConcepto";
            txtConcepto.Properties.Appearance.Font = new Font("Tahoma", 9F);
            txtConcepto.Properties.Appearance.Options.UseFont = true;
            txtConcepto.Properties.BeepOnError = true;
            txtConcepto.Properties.NullValuePrompt = "Concepto del movimiento a realizar";
            txtConcepto.Size = new Size(512, 20);
            txtConcepto.StyleController = layoutControl1;
            txtConcepto.TabIndex = 4;
            txtConcepto.ToolTip = "concepto del movimiento a realizar en caja";
            txtConcepto.ToolTipIconType = DevExpress.Utils.ToolTipIconType.Information;
            txtConcepto.ToolTipTitle = "Concepto";
            // 
            // txtMonto
            // 
            txtMonto.Location = new Point(86, 90);
            txtMonto.Name = "txtMonto";
            txtMonto.Properties.Appearance.Font = new Font("Tahoma", 9F);
            txtMonto.Properties.Appearance.Options.UseFont = true;
            txtMonto.Properties.BeepOnError = true;
            txtMonto.Properties.MaskSettings.Set("MaskManagerType", typeof(DevExpress.Data.Mask.NumericMaskManager));
            txtMonto.Properties.MaskSettings.Set("mask", "n");
            txtMonto.Properties.NullValuePrompt = "Monto a debitar o acreditar de la caja";
            txtMonto.Properties.UseMaskAsDisplayFormat = true;
            txtMonto.Size = new Size(512, 20);
            txtMonto.StyleController = layoutControl1;
            txtMonto.TabIndex = 6;
            // 
            // cmbMovcaja
            // 
            cmbMovcaja.Location = new Point(86, 51);
            cmbMovcaja.Name = "cmbMovcaja";
            cmbMovcaja.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo) });
            cmbMovcaja.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] { new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Descripcion", "Descripcion", 63, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Near, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default), new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Rubros", "Rubros", 42, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Near, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default) });
            cmbMovcaja.Properties.DataSource = movCajasDtoBindingSource;
            cmbMovcaja.Properties.DisplayMember = "Descripcion";
            cmbMovcaja.Properties.NullText = "";
            cmbMovcaja.Properties.PopupSizeable = false;
            cmbMovcaja.Properties.ValueMember = "Idmovcaja";
            cmbMovcaja.Size = new Size(512, 20);
            cmbMovcaja.StyleController = layoutControl1;
            cmbMovcaja.TabIndex = 5;
            // 
            // movCajasDtoBindingSource
            // 
            movCajasDtoBindingSource.DataSource = typeof(Dto.MovCajasDto);
            // 
            // Root
            // 
            Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            Root.GroupBordersVisible = false;
            Root.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] { layoutControlItem1, layoutControlItem2, layoutControlItem3 });
            Root.Name = "Root";
            Root.Size = new Size(610, 190);
            Root.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            layoutControlItem1.AppearanceItemCaption.Font = new Font("Tahoma", 9.5F);
            layoutControlItem1.AppearanceItemCaption.Options.UseFont = true;
            layoutControlItem1.Control = txtConcepto;
            layoutControlItem1.Location = new Point(0, 0);
            layoutControlItem1.Name = "layoutControlItem1";
            layoutControlItem1.Size = new Size(590, 39);
            layoutControlItem1.Spacing = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 15);
            layoutControlItem1.Text = "Concepto:";
            layoutControlItem1.TextSize = new Size(70, 16);
            // 
            // layoutControlItem2
            // 
            layoutControlItem2.AppearanceItemCaption.Font = new Font("Tahoma", 9.5F);
            layoutControlItem2.AppearanceItemCaption.Options.UseFont = true;
            layoutControlItem2.Control = cmbMovcaja;
            layoutControlItem2.Location = new Point(0, 39);
            layoutControlItem2.Name = "layoutControlItem2";
            layoutControlItem2.Size = new Size(590, 39);
            layoutControlItem2.Spacing = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 15);
            layoutControlItem2.Text = "Movimiento:";
            layoutControlItem2.TextSize = new Size(70, 16);
            // 
            // layoutControlItem3
            // 
            layoutControlItem3.AppearanceItemCaption.Font = new Font("Tahoma", 9.5F);
            layoutControlItem3.AppearanceItemCaption.Options.UseFont = true;
            layoutControlItem3.Control = txtMonto;
            layoutControlItem3.Location = new Point(0, 78);
            layoutControlItem3.Name = "layoutControlItem3";
            layoutControlItem3.Size = new Size(590, 92);
            layoutControlItem3.Text = "Monto";
            layoutControlItem3.TextSize = new Size(70, 16);
            // 
            // RealizarMovimientoCajaFormView
            // 
            AutoScaleDimensions = new SizeF(6F, 13F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(610, 299);
            Controls.Add(layoutControl1);
            IconOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("RealizarMovimientoCajaFormView.IconOptions.SvgImage");
            Name = "RealizarMovimientoCajaFormView";
            Text = "Realizar Movimiento Caja";
            Load += RealizarMovimientoCajaForm_Load;
            Controls.SetChildIndex(labelControl1, 0);
            Controls.SetChildIndex(tablePanel1, 0);
            Controls.SetChildIndex(layoutControl1, 0);
            ((System.ComponentModel.ISupportInitialize)tablePanel1).EndInit();
            tablePanel1.ResumeLayout(false);
            tablePanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)layoutControl1).EndInit();
            layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)txtConcepto.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)txtMonto.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)cmbMovcaja.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)movCajasDtoBindingSource).EndInit();
            ((System.ComponentModel.ISupportInitialize)Root).EndInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem1).EndInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem2).EndInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem3).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraEditors.TextEdit txtConcepto;
        private DevExpress.XtraEditors.TextEdit txtMonto;
        private DevExpress.XtraLayout.LayoutControlGroup Root;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraEditors.LookUpEdit cmbMovcaja;
        private BindingSource movCajasDtoBindingSource;
    }
}