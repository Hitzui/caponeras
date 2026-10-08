namespace Caponeras.App.Views.Conductores
{
    partial class AsignacionesVehiculoFechaView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AsignacionesVehiculoFechaView));
            stackPanel1 = new DevExpress.Utils.Layout.StackPanel();
            labelControl1 = new DevExpress.XtraEditors.LabelControl();
            txtFecha = new DevExpress.XtraEditors.DateEdit();
            btnFiltrar = new DevExpress.XtraEditors.SimpleButton();
            btnGuardar = new DevExpress.XtraEditors.SimpleButton();
            gridControlAsignaciones = new DevExpress.XtraGrid.GridControl();
            conductorVehiculoDtoBindingSource = new BindingSource(components);
            gridViewAsignaciones = new DevExpress.XtraGrid.Views.Grid.GridView();
            colNombre = new DevExpress.XtraGrid.Columns.GridColumn();
            colTelefono = new DevExpress.XtraGrid.Columns.GridColumn();
            colIdentificacion = new DevExpress.XtraGrid.Columns.GridColumn();
            colIdvehiculo = new DevExpress.XtraGrid.Columns.GridColumn();
            searchVehiculo = new DevExpress.XtraEditors.Repository.RepositoryItemSearchLookUpEdit();
            vehiculosDtoBindingSource = new BindingSource(components);
            repositorySearchVehiculo = new DevExpress.XtraGrid.Views.Grid.GridView();
            colIdvehiculoRepository = new DevExpress.XtraGrid.Columns.GridColumn();
            colCodigo = new DevExpress.XtraGrid.Columns.GridColumn();
            colPlaca = new DevExpress.XtraGrid.Columns.GridColumn();
            colMarca = new DevExpress.XtraGrid.Columns.GridColumn();
            colModelo = new DevExpress.XtraGrid.Columns.GridColumn();
            colZona = new DevExpress.XtraGrid.Columns.GridColumn();
            searchZona = new DevExpress.XtraEditors.Repository.RepositoryItemSearchLookUpEdit();
            zonasBindingSource = new BindingSource(components);
            repositoryItemSearchLookUpEdit3View = new DevExpress.XtraGrid.Views.Grid.GridView();
            colIdzonas = new DevExpress.XtraGrid.Columns.GridColumn();
            colNombreZona = new DevExpress.XtraGrid.Columns.GridColumn();
            colDescripcionZona = new DevExpress.XtraGrid.Columns.GridColumn();
            colAcciones = new DevExpress.XtraGrid.Columns.GridColumn();
            btnQuitarAsignacion = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            ((System.ComponentModel.ISupportInitialize)stackPanel1).BeginInit();
            stackPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)txtFecha.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)txtFecha.Properties.CalendarTimeProperties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)gridControlAsignaciones).BeginInit();
            ((System.ComponentModel.ISupportInitialize)conductorVehiculoDtoBindingSource).BeginInit();
            ((System.ComponentModel.ISupportInitialize)gridViewAsignaciones).BeginInit();
            ((System.ComponentModel.ISupportInitialize)searchVehiculo).BeginInit();
            ((System.ComponentModel.ISupportInitialize)vehiculosDtoBindingSource).BeginInit();
            ((System.ComponentModel.ISupportInitialize)repositorySearchVehiculo).BeginInit();
            ((System.ComponentModel.ISupportInitialize)searchZona).BeginInit();
            ((System.ComponentModel.ISupportInitialize)zonasBindingSource).BeginInit();
            ((System.ComponentModel.ISupportInitialize)repositoryItemSearchLookUpEdit3View).BeginInit();
            ((System.ComponentModel.ISupportInitialize)btnQuitarAsignacion).BeginInit();
            SuspendLayout();
            // 
            // stackPanel1
            // 
            stackPanel1.Controls.Add(labelControl1);
            stackPanel1.Controls.Add(txtFecha);
            stackPanel1.Controls.Add(btnFiltrar);
            stackPanel1.Controls.Add(btnGuardar);
            stackPanel1.Dock = DockStyle.Top;
            stackPanel1.Location = new Point(0, 0);
            stackPanel1.Name = "stackPanel1";
            stackPanel1.Size = new Size(1020, 62);
            stackPanel1.TabIndex = 0;
            stackPanel1.UseSkinIndents = true;
            // 
            // labelControl1
            // 
            labelControl1.Appearance.Font = new Font("Tahoma", 9F);
            labelControl1.Appearance.Options.UseFont = true;
            labelControl1.Location = new Point(13, 23);
            labelControl1.Name = "labelControl1";
            labelControl1.Size = new Size(77, 14);
            labelControl1.TabIndex = 0;
            labelControl1.Text = "Fecha a filtrar:";
            // 
            // txtFecha
            // 
            txtFecha.EditValue = null;
            txtFecha.Location = new Point(94, 20);
            txtFecha.Name = "txtFecha";
            txtFecha.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo) });
            txtFecha.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo) });
            txtFecha.Size = new Size(155, 20);
            txtFecha.TabIndex = 1;
            // 
            // btnFiltrar
            // 
            btnFiltrar.Appearance.BackColor = DevExpress.LookAndFeel.DXSkinColors.FillColors.Warning;
            btnFiltrar.Appearance.ForeColor = Color.White;
            btnFiltrar.Appearance.Options.UseBackColor = true;
            btnFiltrar.Appearance.Options.UseForeColor = true;
            btnFiltrar.ImageOptions.AllowGlyphSkinning = DevExpress.Utils.DefaultBoolean.True;
            btnFiltrar.ImageOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("btnFiltrar.ImageOptions.SvgImage");
            btnFiltrar.ImageOptions.SvgImageSize = new Size(16, 16);
            btnFiltrar.Location = new Point(253, 19);
            btnFiltrar.Name = "btnFiltrar";
            btnFiltrar.Size = new Size(132, 23);
            btnFiltrar.TabIndex = 2;
            btnFiltrar.Text = "Filtrar";
            btnFiltrar.Click += btnFiltrar_Click;
            // 
            // btnGuardar
            // 
            btnGuardar.Appearance.BackColor = Color.FromArgb(0, 192, 0);
            btnGuardar.Appearance.ForeColor = Color.White;
            btnGuardar.Appearance.Options.UseBackColor = true;
            btnGuardar.Appearance.Options.UseForeColor = true;
            btnGuardar.ImageOptions.AllowGlyphSkinning = DevExpress.Utils.DefaultBoolean.True;
            btnGuardar.ImageOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("btnGuardar.ImageOptions.SvgImage");
            btnGuardar.ImageOptions.SvgImageSize = new Size(16, 16);
            btnGuardar.Location = new Point(389, 19);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(132, 23);
            btnGuardar.TabIndex = 3;
            btnGuardar.Text = "Aplicar Cambios";
            btnGuardar.Click += btnGuardar_Click;
            // 
            // gridControlAsignaciones
            // 
            gridControlAsignaciones.DataSource = conductorVehiculoDtoBindingSource;
            gridControlAsignaciones.Dock = DockStyle.Fill;
            gridControlAsignaciones.Location = new Point(0, 62);
            gridControlAsignaciones.MainView = gridViewAsignaciones;
            gridControlAsignaciones.Name = "gridControlAsignaciones";
            gridControlAsignaciones.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] { searchVehiculo, searchZona, btnQuitarAsignacion });
            gridControlAsignaciones.Size = new Size(1020, 525);
            gridControlAsignaciones.TabIndex = 1;
            gridControlAsignaciones.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] { gridViewAsignaciones });
            // 
            // conductorVehiculoDtoBindingSource
            // 
            conductorVehiculoDtoBindingSource.DataSource = typeof(Dto.ConductorVehiculoDto);
            // 
            // gridViewAsignaciones
            // 
            gridViewAsignaciones.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] { colNombre, colTelefono, colIdentificacion, colIdvehiculo, colZona, colAcciones });
            gridViewAsignaciones.GridControl = gridControlAsignaciones;
            gridViewAsignaciones.Name = "gridViewAsignaciones";
            // 
            // colNombre
            // 
            colNombre.FieldName = "Nombre";
            colNombre.Name = "colNombre";
            colNombre.OptionsColumn.ReadOnly = true;
            colNombre.Visible = true;
            colNombre.VisibleIndex = 0;
            // 
            // colTelefono
            // 
            colTelefono.FieldName = "Telefono";
            colTelefono.Name = "colTelefono";
            colTelefono.OptionsColumn.ReadOnly = true;
            colTelefono.Visible = true;
            colTelefono.VisibleIndex = 1;
            // 
            // colIdentificacion
            // 
            colIdentificacion.FieldName = "Identificacion";
            colIdentificacion.Name = "colIdentificacion";
            colIdentificacion.OptionsColumn.ReadOnly = true;
            colIdentificacion.Visible = true;
            colIdentificacion.VisibleIndex = 2;
            // 
            // colIdvehiculo
            // 
            colIdvehiculo.Caption = "Vehiculo";
            colIdvehiculo.ColumnEdit = searchVehiculo;
            colIdvehiculo.FieldName = "IdVehiculo";
            colIdvehiculo.Name = "colIdvehiculo";
            colIdvehiculo.Visible = true;
            colIdvehiculo.VisibleIndex = 3;
            // 
            // searchVehiculo
            // 
            searchVehiculo.AutoHeight = false;
            searchVehiculo.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo) });
            searchVehiculo.DataSource = vehiculosDtoBindingSource;
            searchVehiculo.DisplayMember = "Placa";
            searchVehiculo.Name = "searchVehiculo";
            searchVehiculo.PopupView = repositorySearchVehiculo;
            searchVehiculo.ValueMember = "Idvehiculo";
            // 
            // vehiculosDtoBindingSource
            // 
            vehiculosDtoBindingSource.DataSource = typeof(Dto.VehiculosDto);
            // 
            // repositorySearchVehiculo
            // 
            repositorySearchVehiculo.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] { colIdvehiculoRepository, colCodigo, colPlaca, colMarca, colModelo });
            repositorySearchVehiculo.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            repositorySearchVehiculo.Name = "repositorySearchVehiculo";
            repositorySearchVehiculo.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False;
            repositorySearchVehiculo.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.False;
            repositorySearchVehiculo.OptionsBehavior.Editable = false;
            repositorySearchVehiculo.OptionsSelection.EnableAppearanceFocusedCell = false;
            repositorySearchVehiculo.OptionsView.ShowGroupPanel = false;
            // 
            // colIdvehiculoRepository
            // 
            colIdvehiculoRepository.FieldName = "Idvehiculo";
            colIdvehiculoRepository.Name = "colIdvehiculoRepository";
            colIdvehiculoRepository.Visible = true;
            colIdvehiculoRepository.VisibleIndex = 0;
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
            // colMarca
            // 
            colMarca.FieldName = "Marca";
            colMarca.Name = "colMarca";
            colMarca.Visible = true;
            colMarca.VisibleIndex = 3;
            // 
            // colModelo
            // 
            colModelo.FieldName = "Modelo";
            colModelo.Name = "colModelo";
            colModelo.Visible = true;
            colModelo.VisibleIndex = 4;
            // 
            // colZona
            // 
            colZona.ColumnEdit = searchZona;
            colZona.FieldName = "IdZona";
            colZona.Name = "colZona";
            colZona.Visible = true;
            colZona.VisibleIndex = 4;
            // 
            // searchZona
            // 
            searchZona.AutoHeight = false;
            searchZona.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo) });
            searchZona.DataSource = zonasBindingSource;
            searchZona.DisplayMember = "Descripcion";
            searchZona.Name = "searchZona";
            searchZona.PopupView = repositoryItemSearchLookUpEdit3View;
            searchZona.ValueMember = "Idzonas";
            // 
            // zonasBindingSource
            // 
            zonasBindingSource.DataSource = typeof(Dto.ZonasDto);
            // 
            // repositoryItemSearchLookUpEdit3View
            // 
            repositoryItemSearchLookUpEdit3View.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] { colIdzonas, colNombreZona, colDescripcionZona });
            repositoryItemSearchLookUpEdit3View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            repositoryItemSearchLookUpEdit3View.Name = "repositoryItemSearchLookUpEdit3View";
            repositoryItemSearchLookUpEdit3View.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False;
            repositoryItemSearchLookUpEdit3View.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.False;
            repositoryItemSearchLookUpEdit3View.OptionsBehavior.Editable = false;
            repositoryItemSearchLookUpEdit3View.OptionsSelection.EnableAppearanceFocusedCell = false;
            repositoryItemSearchLookUpEdit3View.OptionsView.ShowGroupPanel = false;
            // 
            // colIdzonas
            // 
            colIdzonas.FieldName = "Idzonas";
            colIdzonas.Name = "colIdzonas";
            colIdzonas.Visible = true;
            colIdzonas.VisibleIndex = 0;
            // 
            // colNombreZona
            // 
            colNombreZona.FieldName = "Nombre";
            colNombreZona.Name = "colNombreZona";
            colNombreZona.Visible = true;
            colNombreZona.VisibleIndex = 1;
            // 
            // colDescripcionZona
            // 
            colDescripcionZona.FieldName = "Descripcion";
            colDescripcionZona.Name = "colDescripcionZona";
            colDescripcionZona.Visible = true;
            colDescripcionZona.VisibleIndex = 2;
            // 
            // colAcciones
            // 
            colAcciones.Caption = "Acciones";
            colAcciones.ColumnEdit = btnQuitarAsignacion;
            colAcciones.Name = "colAcciones";
            colAcciones.Visible = true;
            colAcciones.VisibleIndex = 5;
            // 
            // btnQuitarAsignacion
            // 
            btnQuitarAsignacion.AutoHeight = false;
            btnQuitarAsignacion.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton() });
            btnQuitarAsignacion.Name = "btnQuitarAsignacion";
            // 
            // AsignacionesVehiculoFechaView
            // 
            AutoScaleDimensions = new SizeF(6F, 13F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1020, 587);
            Controls.Add(gridControlAsignaciones);
            Controls.Add(stackPanel1);
            Name = "AsignacionesVehiculoFechaView";
            Text = "AsignacionesVehiculoFechaView";
            ((System.ComponentModel.ISupportInitialize)stackPanel1).EndInit();
            stackPanel1.ResumeLayout(false);
            stackPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)txtFecha.Properties.CalendarTimeProperties).EndInit();
            ((System.ComponentModel.ISupportInitialize)txtFecha.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)gridControlAsignaciones).EndInit();
            ((System.ComponentModel.ISupportInitialize)conductorVehiculoDtoBindingSource).EndInit();
            ((System.ComponentModel.ISupportInitialize)gridViewAsignaciones).EndInit();
            ((System.ComponentModel.ISupportInitialize)searchVehiculo).EndInit();
            ((System.ComponentModel.ISupportInitialize)vehiculosDtoBindingSource).EndInit();
            ((System.ComponentModel.ISupportInitialize)repositorySearchVehiculo).EndInit();
            ((System.ComponentModel.ISupportInitialize)searchZona).EndInit();
            ((System.ComponentModel.ISupportInitialize)zonasBindingSource).EndInit();
            ((System.ComponentModel.ISupportInitialize)repositoryItemSearchLookUpEdit3View).EndInit();
            ((System.ComponentModel.ISupportInitialize)btnQuitarAsignacion).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DevExpress.Utils.Layout.StackPanel stackPanel1;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.DateEdit txtFecha;
        private DevExpress.XtraGrid.GridControl gridControlAsignaciones;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewAsignaciones;
        private BindingSource conductorVehiculoDtoBindingSource;
        private DevExpress.XtraGrid.Columns.GridColumn colNombre;
        private DevExpress.XtraGrid.Columns.GridColumn colTelefono;
        private DevExpress.XtraGrid.Columns.GridColumn colIdentificacion;
        private DevExpress.XtraGrid.Columns.GridColumn colCodigoVehiculo;
        private DevExpress.XtraGrid.Columns.GridColumn colZona;
        private DevExpress.XtraEditors.SimpleButton btnFiltrar;
        private DevExpress.XtraEditors.Repository.RepositoryItemSearchLookUpEdit searchVehiculo;
        private DevExpress.XtraGrid.Views.Grid.GridView repositorySearchVehiculo;
        private DevExpress.XtraEditors.Repository.RepositoryItemSearchLookUpEdit searchCodigo;
        private DevExpress.XtraGrid.Views.Grid.GridView repositoryItemSearchLookUpEdit2View;
        private DevExpress.XtraEditors.Repository.RepositoryItemSearchLookUpEdit searchZona;
        private DevExpress.XtraGrid.Views.Grid.GridView repositoryItemSearchLookUpEdit3View;
        private BindingSource vehiculosDtoBindingSource;
        private DevExpress.XtraGrid.Columns.GridColumn colCodigo;
        private DevExpress.XtraGrid.Columns.GridColumn colPlaca;
        private DevExpress.XtraGrid.Columns.GridColumn colMarca;
        private DevExpress.XtraGrid.Columns.GridColumn colModelo;
        private BindingSource zonasBindingSource;
        private DevExpress.XtraGrid.Columns.GridColumn colNombreZona;
        private DevExpress.XtraGrid.Columns.GridColumn colDescripcionZona;
        private DevExpress.XtraEditors.SimpleButton btnGuardar;
        private DevExpress.XtraGrid.Columns.GridColumn colIdvehiculo;
        private DevExpress.XtraGrid.Columns.GridColumn colIdvehiculoRepository;
        private DevExpress.XtraGrid.Columns.GridColumn colIdzonas;
        private DevExpress.XtraGrid.Columns.GridColumn colAcciones;
        private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit btnQuitarAsignacion;
    }
}