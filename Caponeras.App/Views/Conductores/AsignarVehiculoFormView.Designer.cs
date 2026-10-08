namespace Caponeras.App.Views.Conductores
{
    partial class AsignarVehiculoFormView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AsignarVehiculoFormView));
            groupControl1 = new DevExpress.XtraEditors.GroupControl();
            txtIdentificacion = new DevExpress.XtraEditors.TextEdit();
            labelControl3 = new DevExpress.XtraEditors.LabelControl();
            txtNombreCadete = new DevExpress.XtraEditors.TextEdit();
            labelControl2 = new DevExpress.XtraEditors.LabelControl();
            groupControl2 = new DevExpress.XtraEditors.GroupControl();
            labelControl7 = new DevExpress.XtraEditors.LabelControl();
            cmbZonas = new DevExpress.XtraEditors.LookUpEdit();
            zonasDtoBindingSource = new BindingSource(components);
            labelControl4 = new DevExpress.XtraEditors.LabelControl();
            cmbVeniculo = new DevExpress.XtraEditors.LookUpEdit();
            vehiculosDtoBindingSource = new BindingSource(components);
            groupControl3 = new DevExpress.XtraEditors.GroupControl();
            txtFechaFin = new DevExpress.XtraEditors.DateEdit();
            labelControl6 = new DevExpress.XtraEditors.LabelControl();
            txtFechaInicio = new DevExpress.XtraEditors.DateEdit();
            labelControl5 = new DevExpress.XtraEditors.LabelControl();
            dxErrorProvider1 = new DevExpress.XtraEditors.DXErrorProvider.DXErrorProvider(components);
            ((System.ComponentModel.ISupportInitialize)tablePanel1).BeginInit();
            tablePanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)groupControl1).BeginInit();
            groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)txtIdentificacion.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)txtNombreCadete.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)groupControl2).BeginInit();
            groupControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)cmbZonas.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)zonasDtoBindingSource).BeginInit();
            ((System.ComponentModel.ISupportInitialize)cmbVeniculo.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)vehiculosDtoBindingSource).BeginInit();
            ((System.ComponentModel.ISupportInitialize)groupControl3).BeginInit();
            groupControl3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)txtFechaFin.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)txtFechaFin.Properties.CalendarTimeProperties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)txtFechaInicio.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)txtFechaInicio.Properties.CalendarTimeProperties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dxErrorProvider1).BeginInit();
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
            btnAceptar.Location = new Point(351, 21);
            tablePanel1.SetRow(btnAceptar, 0);
            btnAceptar.Click += btnAceptar_Click;
            // 
            // tablePanel1
            // 
            tablePanel1.Location = new Point(0, 344);
            tablePanel1.Size = new Size(501, 79);
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
            labelControl1.Size = new Size(501, 30);
            labelControl1.Text = "Asignar Vehículo a Cadete";
            // 
            // groupControl1
            // 
            groupControl1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            groupControl1.Controls.Add(txtIdentificacion);
            groupControl1.Controls.Add(labelControl3);
            groupControl1.Controls.Add(txtNombreCadete);
            groupControl1.Controls.Add(labelControl2);
            groupControl1.Location = new Point(12, 36);
            groupControl1.Name = "groupControl1";
            groupControl1.Size = new Size(477, 100);
            groupControl1.TabIndex = 6;
            groupControl1.Text = "Datos del Cadete";
            // 
            // txtIdentificacion
            // 
            txtIdentificacion.Location = new Point(88, 56);
            txtIdentificacion.Name = "txtIdentificacion";
            txtIdentificacion.Properties.ReadOnly = true;
            txtIdentificacion.Size = new Size(318, 20);
            txtIdentificacion.TabIndex = 3;
            // 
            // labelControl3
            // 
            labelControl3.Location = new Point(14, 59);
            labelControl3.Name = "labelControl3";
            labelControl3.Size = new Size(68, 13);
            labelControl3.TabIndex = 2;
            labelControl3.Text = "Identificación:";
            // 
            // txtNombreCadete
            // 
            txtNombreCadete.Location = new Point(88, 24);
            txtNombreCadete.Name = "txtNombreCadete";
            txtNombreCadete.Properties.ReadOnly = true;
            txtNombreCadete.Size = new Size(318, 20);
            txtNombreCadete.TabIndex = 1;
            // 
            // labelControl2
            // 
            labelControl2.Location = new Point(41, 27);
            labelControl2.Name = "labelControl2";
            labelControl2.Size = new Size(41, 13);
            labelControl2.TabIndex = 0;
            labelControl2.Text = "Nombre:";
            // 
            // groupControl2
            // 
            groupControl2.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            groupControl2.Controls.Add(labelControl7);
            groupControl2.Controls.Add(cmbZonas);
            groupControl2.Controls.Add(labelControl4);
            groupControl2.Controls.Add(cmbVeniculo);
            groupControl2.Location = new Point(12, 142);
            groupControl2.Name = "groupControl2";
            groupControl2.Size = new Size(477, 111);
            groupControl2.TabIndex = 4;
            groupControl2.Text = "Vehiculo";
            // 
            // labelControl7
            // 
            labelControl7.Location = new Point(54, 72);
            labelControl7.Name = "labelControl7";
            labelControl7.Size = new Size(28, 13);
            labelControl7.TabIndex = 5;
            labelControl7.Text = "Zona:";
            // 
            // cmbZonas
            // 
            cmbZonas.Location = new Point(88, 69);
            cmbZonas.Name = "cmbZonas";
            cmbZonas.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo) });
            cmbZonas.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] { new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Idzonas", "Idzonas", 47, DevExpress.Utils.FormatType.Numeric, "", true, DevExpress.Utils.HorzAlignment.Far, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default), new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Nombre", "Nombre", 46, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Near, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default) });
            cmbZonas.Properties.DataSource = zonasDtoBindingSource;
            cmbZonas.Properties.DisplayMember = "Nombre";
            cmbZonas.Properties.PopupFilterMode = DevExpress.XtraEditors.PopupFilterMode.Contains;
            cmbZonas.Properties.SearchMode = DevExpress.XtraEditors.Controls.SearchMode.AutoSearch;
            cmbZonas.Properties.ValueMember = "Idzonas";
            cmbZonas.Size = new Size(318, 20);
            cmbZonas.TabIndex = 4;
            // 
            // zonasDtoBindingSource
            // 
            zonasDtoBindingSource.DataSource = typeof(Dto.ZonasDto);
            // 
            // labelControl4
            // 
            labelControl4.Location = new Point(39, 31);
            labelControl4.Name = "labelControl4";
            labelControl4.Size = new Size(43, 13);
            labelControl4.TabIndex = 3;
            labelControl4.Text = "Vehículo:";
            // 
            // cmbVeniculo
            // 
            cmbVeniculo.Location = new Point(88, 28);
            cmbVeniculo.Name = "cmbVeniculo";
            cmbVeniculo.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo) });
            cmbVeniculo.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] { new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Idvehiculo", "Idvehiculo", 58, DevExpress.Utils.FormatType.Numeric, "", true, DevExpress.Utils.HorzAlignment.Far, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default), new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Codigo", "Codigo", 42, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Near, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default), new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Placa", "Placa", 34, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Near, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default), new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Descripcion", "Descripcion", 63, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Near, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default) });
            cmbVeniculo.Properties.DataSource = vehiculosDtoBindingSource;
            cmbVeniculo.Properties.DisplayMember = "Placa";
            cmbVeniculo.Properties.PopupFilterMode = DevExpress.XtraEditors.PopupFilterMode.Contains;
            cmbVeniculo.Properties.SearchMode = DevExpress.XtraEditors.Controls.SearchMode.AutoSearch;
            cmbVeniculo.Properties.ValueMember = "Idvehiculo";
            cmbVeniculo.Size = new Size(318, 20);
            cmbVeniculo.TabIndex = 0;
            // 
            // vehiculosDtoBindingSource
            // 
            vehiculosDtoBindingSource.DataSource = typeof(Dto.VehiculosDto);
            // 
            // groupControl3
            // 
            groupControl3.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            groupControl3.Controls.Add(txtFechaFin);
            groupControl3.Controls.Add(labelControl6);
            groupControl3.Controls.Add(txtFechaInicio);
            groupControl3.Controls.Add(labelControl5);
            groupControl3.Location = new Point(17, 259);
            groupControl3.Name = "groupControl3";
            groupControl3.Size = new Size(472, 79);
            groupControl3.TabIndex = 7;
            groupControl3.Text = "Fechas a asignar";
            // 
            // txtFechaFin
            // 
            txtFechaFin.EditValue = null;
            txtFechaFin.Location = new Point(285, 30);
            txtFechaFin.Name = "txtFechaFin";
            txtFechaFin.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo) });
            txtFechaFin.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo) });
            txtFechaFin.Size = new Size(116, 20);
            txtFechaFin.TabIndex = 7;
            txtFechaFin.EditValueChanged += txtFechaFin_EditValueChanged;
            txtFechaFin.Validating += txtFechaFin_Validating;
            // 
            // labelControl6
            // 
            labelControl6.Location = new Point(209, 33);
            labelControl6.Name = "labelControl6";
            labelControl6.Size = new Size(63, 13);
            labelControl6.TabIndex = 6;
            labelControl6.Text = "Fecha de fin:";
            // 
            // txtFechaInicio
            // 
            txtFechaInicio.EditValue = null;
            txtFechaInicio.Location = new Point(94, 30);
            txtFechaInicio.Name = "txtFechaInicio";
            txtFechaInicio.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo) });
            txtFechaInicio.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo) });
            txtFechaInicio.Size = new Size(109, 20);
            txtFechaInicio.TabIndex = 5;
            txtFechaInicio.EditValueChanged += txtFechaInicio_EditValueChanged;
            txtFechaInicio.Validating += txtFechaInicio_Validating;
            // 
            // labelControl5
            // 
            labelControl5.Location = new Point(14, 33);
            labelControl5.Name = "labelControl5";
            labelControl5.Size = new Size(74, 13);
            labelControl5.TabIndex = 4;
            labelControl5.Text = "Fecha de inicio:";
            // 
            // dxErrorProvider1
            // 
            dxErrorProvider1.ContainerControl = this;
            // 
            // AsignarVehiculoFormView
            // 
            AutoScaleDimensions = new SizeF(6F, 13F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(501, 423);
            Controls.Add(groupControl3);
            Controls.Add(groupControl2);
            Controls.Add(groupControl1);
            Name = "AsignarVehiculoFormView";
            Text = "AsignarVehiculoFormView";
            Load += AsignarVehiculoForm_Load;
            Controls.SetChildIndex(labelControl1, 0);
            Controls.SetChildIndex(tablePanel1, 0);
            Controls.SetChildIndex(groupControl1, 0);
            Controls.SetChildIndex(groupControl2, 0);
            Controls.SetChildIndex(groupControl3, 0);
            ((System.ComponentModel.ISupportInitialize)tablePanel1).EndInit();
            tablePanel1.ResumeLayout(false);
            tablePanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)groupControl1).EndInit();
            groupControl1.ResumeLayout(false);
            groupControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)txtIdentificacion.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)txtNombreCadete.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)groupControl2).EndInit();
            groupControl2.ResumeLayout(false);
            groupControl2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)cmbZonas.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)zonasDtoBindingSource).EndInit();
            ((System.ComponentModel.ISupportInitialize)cmbVeniculo.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)vehiculosDtoBindingSource).EndInit();
            ((System.ComponentModel.ISupportInitialize)groupControl3).EndInit();
            groupControl3.ResumeLayout(false);
            groupControl3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)txtFechaFin.Properties.CalendarTimeProperties).EndInit();
            ((System.ComponentModel.ISupportInitialize)txtFechaFin.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)txtFechaInicio.Properties.CalendarTimeProperties).EndInit();
            ((System.ComponentModel.ISupportInitialize)txtFechaInicio.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)dxErrorProvider1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.TextEdit txtNombreCadete;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.TextEdit txtIdentificacion;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.GroupControl groupControl2;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.LookUpEdit cmbVeniculo;
        private DevExpress.XtraEditors.GroupControl groupControl3;
        private BindingSource vehiculosDtoBindingSource;
        private DevExpress.XtraEditors.DateEdit txtFechaFin;
        private DevExpress.XtraEditors.LabelControl labelControl6;
        private DevExpress.XtraEditors.DateEdit txtFechaInicio;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private DevExpress.XtraEditors.DXErrorProvider.DXErrorProvider dxErrorProvider1;
        private DevExpress.XtraEditors.LabelControl labelControl7;
        private DevExpress.XtraEditors.LookUpEdit cmbZonas;
        private BindingSource zonasDtoBindingSource;
    }
}