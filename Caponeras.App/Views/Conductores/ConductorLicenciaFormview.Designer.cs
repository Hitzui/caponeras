namespace Caponeras.App.Views.Conductores
{
    partial class ConductorLicenciaFormView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ConductorLicenciaFormView));
            groupControl1 = new DevExpress.XtraEditors.GroupControl();
            txtIdentificacion = new DevExpress.XtraEditors.TextEdit();
            labelControl2 = new DevExpress.XtraEditors.LabelControl();
            txtNombreCompleto = new DevExpress.XtraEditors.TextEdit();
            labelControl1 = new DevExpress.XtraEditors.LabelControl();
            groupControl2 = new DevExpress.XtraEditors.GroupControl();
            layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            txtNumeroLicencia = new DevExpress.XtraEditors.TextEdit();
            cmbCategoriaLicencia = new DevExpress.XtraEditors.ComboBoxEdit();
            txtFechaEmision = new DevExpress.XtraEditors.DateEdit();
            txtFechaVencimiento = new DevExpress.XtraEditors.DateEdit();
            txtObservaciones = new DevExpress.XtraEditors.MemoEdit();
            Root = new DevExpress.XtraLayout.LayoutControlGroup();
            layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            layoutControlItem5 = new DevExpress.XtraLayout.LayoutControlItem();
            picLicenciaFrente = new DevExpress.XtraEditors.PictureEdit();
            picLicenciaTrasera = new DevExpress.XtraEditors.PictureEdit();
            btnSave = new DevExpress.XtraEditors.SimpleButton();
            btnCancel = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)groupControl1).BeginInit();
            groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)txtIdentificacion.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)txtNombreCompleto.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)groupControl2).BeginInit();
            groupControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)layoutControl1).BeginInit();
            layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)txtNumeroLicencia.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)cmbCategoriaLicencia.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)txtFechaEmision.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)txtFechaEmision.Properties.CalendarTimeProperties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)txtFechaVencimiento.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)txtFechaVencimiento.Properties.CalendarTimeProperties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)txtObservaciones.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)Root).BeginInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem4).BeginInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem5).BeginInit();
            ((System.ComponentModel.ISupportInitialize)picLicenciaFrente.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)picLicenciaTrasera.Properties).BeginInit();
            SuspendLayout();
            // 
            // groupControl1
            // 
            groupControl1.Controls.Add(txtIdentificacion);
            groupControl1.Controls.Add(labelControl2);
            groupControl1.Controls.Add(txtNombreCompleto);
            groupControl1.Controls.Add(labelControl1);
            groupControl1.Location = new Point(12, 12);
            groupControl1.Name = "groupControl1";
            groupControl1.Size = new Size(545, 100);
            groupControl1.TabIndex = 0;
            groupControl1.Text = "Datos Cadete";
            // 
            // txtIdentificacion
            // 
            txtIdentificacion.Location = new Point(100, 55);
            txtIdentificacion.Name = "txtIdentificacion";
            txtIdentificacion.Properties.ReadOnly = true;
            txtIdentificacion.Size = new Size(431, 20);
            txtIdentificacion.TabIndex = 3;
            // 
            // labelControl2
            // 
            labelControl2.Location = new Point(26, 58);
            labelControl2.Name = "labelControl2";
            labelControl2.Size = new Size(68, 13);
            labelControl2.TabIndex = 2;
            labelControl2.Text = "Identificación:";
            // 
            // txtNombreCompleto
            // 
            txtNombreCompleto.Location = new Point(100, 29);
            txtNombreCompleto.Name = "txtNombreCompleto";
            txtNombreCompleto.Properties.ReadOnly = true;
            txtNombreCompleto.Size = new Size(431, 20);
            txtNombreCompleto.TabIndex = 1;
            // 
            // labelControl1
            // 
            labelControl1.Location = new Point(53, 32);
            labelControl1.Name = "labelControl1";
            labelControl1.Size = new Size(41, 13);
            labelControl1.TabIndex = 0;
            labelControl1.Text = "Nombre:";
            // 
            // groupControl2
            // 
            groupControl2.Controls.Add(layoutControl1);
            groupControl2.Location = new Point(12, 118);
            groupControl2.Name = "groupControl2";
            groupControl2.Size = new Size(545, 200);
            groupControl2.TabIndex = 4;
            groupControl2.Text = "Datos Licencia";
            // 
            // layoutControl1
            // 
            layoutControl1.Controls.Add(txtNumeroLicencia);
            layoutControl1.Controls.Add(cmbCategoriaLicencia);
            layoutControl1.Controls.Add(txtFechaEmision);
            layoutControl1.Controls.Add(txtFechaVencimiento);
            layoutControl1.Controls.Add(txtObservaciones);
            layoutControl1.Dock = DockStyle.Fill;
            layoutControl1.Location = new Point(2, 21);
            layoutControl1.Name = "layoutControl1";
            layoutControl1.Root = Root;
            layoutControl1.Size = new Size(541, 177);
            layoutControl1.TabIndex = 0;
            layoutControl1.Text = "layoutControl1";
            // 
            // txtNumeroLicencia
            // 
            txtNumeroLicencia.Location = new Point(109, 12);
            txtNumeroLicencia.Name = "txtNumeroLicencia";
            txtNumeroLicencia.Size = new Size(420, 20);
            txtNumeroLicencia.StyleController = layoutControl1;
            txtNumeroLicencia.TabIndex = 0;
            // 
            // cmbCategoriaLicencia
            // 
            cmbCategoriaLicencia.Location = new Point(109, 36);
            cmbCategoriaLicencia.Name = "cmbCategoriaLicencia";
            cmbCategoriaLicencia.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo) });
            cmbCategoriaLicencia.Size = new Size(420, 20);
            cmbCategoriaLicencia.StyleController = layoutControl1;
            cmbCategoriaLicencia.TabIndex = 2;
            // 
            // txtFechaEmision
            // 
            txtFechaEmision.EditValue = null;
            txtFechaEmision.Location = new Point(109, 60);
            txtFechaEmision.Name = "txtFechaEmision";
            txtFechaEmision.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo) });
            txtFechaEmision.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo) });
            txtFechaEmision.Size = new Size(159, 20);
            txtFechaEmision.StyleController = layoutControl1;
            txtFechaEmision.TabIndex = 3;
            // 
            // txtFechaVencimiento
            // 
            txtFechaVencimiento.EditValue = null;
            txtFechaVencimiento.Location = new Point(369, 60);
            txtFechaVencimiento.Name = "txtFechaVencimiento";
            txtFechaVencimiento.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo) });
            txtFechaVencimiento.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo) });
            txtFechaVencimiento.Size = new Size(160, 20);
            txtFechaVencimiento.StyleController = layoutControl1;
            txtFechaVencimiento.TabIndex = 4;
            // 
            // txtObservaciones
            // 
            txtObservaciones.Location = new Point(12, 100);
            txtObservaciones.Name = "txtObservaciones";
            txtObservaciones.Size = new Size(517, 65);
            txtObservaciones.StyleController = layoutControl1;
            txtObservaciones.TabIndex = 5;
            // 
            // Root
            // 
            Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            Root.GroupBordersVisible = false;
            Root.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] { layoutControlItem1, layoutControlItem2, layoutControlItem3, layoutControlItem4, layoutControlItem5 });
            Root.Name = "Root";
            Root.Size = new Size(541, 177);
            Root.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            layoutControlItem1.Control = txtNumeroLicencia;
            layoutControlItem1.Location = new Point(0, 0);
            layoutControlItem1.Name = "layoutControlItem1";
            layoutControlItem1.Size = new Size(521, 24);
            layoutControlItem1.Text = "Número de licencia:";
            layoutControlItem1.TextSize = new Size(93, 13);
            // 
            // layoutControlItem2
            // 
            layoutControlItem2.Control = cmbCategoriaLicencia;
            layoutControlItem2.Location = new Point(0, 24);
            layoutControlItem2.Name = "layoutControlItem2";
            layoutControlItem2.Size = new Size(521, 24);
            layoutControlItem2.Text = "Categoría";
            layoutControlItem2.TextSize = new Size(93, 13);
            // 
            // layoutControlItem3
            // 
            layoutControlItem3.Control = txtFechaEmision;
            layoutControlItem3.Location = new Point(0, 48);
            layoutControlItem3.Name = "layoutControlItem3";
            layoutControlItem3.Size = new Size(260, 24);
            layoutControlItem3.Text = "Fecha emisión:";
            layoutControlItem3.TextSize = new Size(93, 13);
            // 
            // layoutControlItem4
            // 
            layoutControlItem4.Control = txtFechaVencimiento;
            layoutControlItem4.Location = new Point(260, 48);
            layoutControlItem4.Name = "layoutControlItem4";
            layoutControlItem4.Size = new Size(261, 24);
            layoutControlItem4.Text = "Fecha vencimiento:";
            layoutControlItem4.TextSize = new Size(93, 13);
            // 
            // layoutControlItem5
            // 
            layoutControlItem5.Control = txtObservaciones;
            layoutControlItem5.Location = new Point(0, 72);
            layoutControlItem5.Name = "layoutControlItem5";
            layoutControlItem5.Size = new Size(521, 85);
            layoutControlItem5.Text = "Observaciones";
            layoutControlItem5.TextLocation = DevExpress.Utils.Locations.Top;
            layoutControlItem5.TextSize = new Size(93, 13);
            // 
            // picLicenciaFrente
            // 
            picLicenciaFrente.Location = new Point(581, 12);
            picLicenciaFrente.Name = "picLicenciaFrente";
            picLicenciaFrente.Properties.ShowCameraMenuItem = DevExpress.XtraEditors.Controls.CameraMenuItemVisibility.Auto;
            picLicenciaFrente.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Stretch;
            picLicenciaFrente.Size = new Size(287, 132);
            picLicenciaFrente.TabIndex = 5;
            // 
            // picLicenciaTrasera
            // 
            picLicenciaTrasera.Location = new Point(581, 184);
            picLicenciaTrasera.Name = "picLicenciaTrasera";
            picLicenciaTrasera.Properties.ShowCameraMenuItem = DevExpress.XtraEditors.Controls.CameraMenuItemVisibility.Auto;
            picLicenciaTrasera.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Stretch;
            picLicenciaTrasera.Size = new Size(287, 132);
            picLicenciaTrasera.TabIndex = 6;
            // 
            // btnSave
            // 
            btnSave.Appearance.BackColor = DevExpress.LookAndFeel.DXSkinColors.FillColors.Success;
            btnSave.Appearance.ForeColor = Color.White;
            btnSave.Appearance.Options.UseBackColor = true;
            btnSave.Appearance.Options.UseForeColor = true;
            btnSave.ImageOptions.AllowGlyphSkinning = DevExpress.Utils.DefaultBoolean.True;
            btnSave.ImageOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("btnSave.ImageOptions.SvgImage");
            btnSave.Location = new Point(530, 346);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(144, 48);
            btnSave.TabIndex = 7;
            btnSave.Text = "Guardar";
            btnSave.Click += btnSave_Click;
            // 
            // btnCancel
            // 
            btnCancel.Appearance.BackColor = DevExpress.LookAndFeel.DXSkinColors.FillColors.Danger;
            btnCancel.Appearance.ForeColor = Color.White;
            btnCancel.Appearance.Options.UseBackColor = true;
            btnCancel.Appearance.Options.UseForeColor = true;
            btnCancel.DialogResult = DialogResult.Cancel;
            btnCancel.ImageOptions.AllowGlyphSkinning = DevExpress.Utils.DefaultBoolean.True;
            btnCancel.ImageOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("btnCancel.ImageOptions.SvgImage");
            btnCancel.Location = new Point(123, 346);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(144, 48);
            btnCancel.TabIndex = 8;
            btnCancel.Text = "Cancelar";
            btnCancel.Click += btnCancel_Click;
            // 
            // ConductorLicenciaFormView
            // 
            AutoScaleDimensions = new SizeF(6F, 13F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(880, 406);
            Controls.Add(btnCancel);
            Controls.Add(btnSave);
            Controls.Add(picLicenciaTrasera);
            Controls.Add(picLicenciaFrente);
            Controls.Add(groupControl2);
            Controls.Add(groupControl1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            IconOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("ConductorLicenciaFormView.IconOptions.SvgImage");
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "ConductorLicenciaFormView";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Licencia Cadete";
            Load += ConductorLicenciaForm_Load;
            ((System.ComponentModel.ISupportInitialize)groupControl1).EndInit();
            groupControl1.ResumeLayout(false);
            groupControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)txtIdentificacion.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)txtNombreCompleto.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)groupControl2).EndInit();
            groupControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)layoutControl1).EndInit();
            layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)txtNumeroLicencia.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)cmbCategoriaLicencia.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)txtFechaEmision.Properties.CalendarTimeProperties).EndInit();
            ((System.ComponentModel.ISupportInitialize)txtFechaEmision.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)txtFechaVencimiento.Properties.CalendarTimeProperties).EndInit();
            ((System.ComponentModel.ISupportInitialize)txtFechaVencimiento.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)txtObservaciones.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)Root).EndInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem1).EndInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem2).EndInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem3).EndInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem4).EndInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem5).EndInit();
            ((System.ComponentModel.ISupportInitialize)picLicenciaFrente.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)picLicenciaTrasera.Properties).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.TextEdit txtNombreCompleto;
        private DevExpress.XtraEditors.TextEdit txtIdentificacion;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.GroupControl groupControl2;
        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraEditors.TextEdit txtNumeroLicencia;
        private DevExpress.XtraLayout.LayoutControlGroup Root;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraEditors.ComboBoxEdit cmbCategoriaLicencia;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraEditors.DateEdit txtFechaEmision;
        private DevExpress.XtraEditors.DateEdit txtFechaVencimiento;
        private DevExpress.XtraEditors.MemoEdit txtObservaciones;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem5;
        private DevExpress.XtraEditors.PictureEdit picLicenciaFrente;
        private DevExpress.XtraEditors.PictureEdit picLicenciaTrasera;
        private DevExpress.XtraEditors.SimpleButton btnSave;
        private DevExpress.XtraEditors.SimpleButton btnCancel;
    }
}