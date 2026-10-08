namespace Caponeras.App.Views.UnidadMedida
{
    partial class UnidadMedidaView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UnidadMedidaView));
            gridControlUnidadMedida = new DevExpress.XtraGrid.GridControl();
            unidadMedidaDtoBindingSource = new BindingSource(components);
            gridViewUnidadMedida = new DevExpress.XtraGrid.Views.Grid.GridView();
            colNombre = new DevExpress.XtraGrid.Columns.GridColumn();
            colSimbolo = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)gridControlUnidadMedida).BeginInit();
            ((System.ComponentModel.ISupportInitialize)unidadMedidaDtoBindingSource).BeginInit();
            ((System.ComponentModel.ISupportInitialize)gridViewUnidadMedida).BeginInit();
            SuspendLayout();
            // 
            // gridControlUnidadMedida
            // 
            gridControlUnidadMedida.DataSource = unidadMedidaDtoBindingSource;
            gridControlUnidadMedida.Dock = DockStyle.Fill;
            gridControlUnidadMedida.Location = new Point(0, 0);
            gridControlUnidadMedida.MainView = gridViewUnidadMedida;
            gridControlUnidadMedida.Name = "gridControlUnidadMedida";
            gridControlUnidadMedida.Size = new Size(610, 395);
            gridControlUnidadMedida.TabIndex = 0;
            gridControlUnidadMedida.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] { gridViewUnidadMedida });
            // 
            // unidadMedidaDtoBindingSource
            // 
            unidadMedidaDtoBindingSource.DataSource = typeof(Dto.UnidadMedidaDto);
            // 
            // gridViewUnidadMedida
            // 
            gridViewUnidadMedida.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] { colNombre, colSimbolo });
            gridViewUnidadMedida.GridControl = gridControlUnidadMedida;
            gridViewUnidadMedida.Name = "gridViewUnidadMedida";
            gridViewUnidadMedida.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.True;
            gridViewUnidadMedida.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.True;
            gridViewUnidadMedida.OptionsBehavior.EditingMode = DevExpress.XtraGrid.Views.Grid.GridEditingMode.EditForm;
            gridViewUnidadMedida.OptionsEditForm.FormCaptionFormat = "Datos de UM";
            gridViewUnidadMedida.OptionsEditForm.ShowOnDoubleClick = DevExpress.Utils.DefaultBoolean.True;
            gridViewUnidadMedida.OptionsEditForm.ShowOnEnterKey = DevExpress.Utils.DefaultBoolean.True;
            gridViewUnidadMedida.OptionsEditForm.ShowOnF2Key = DevExpress.Utils.DefaultBoolean.True;
            gridViewUnidadMedida.OptionsScrollAnnotations.ShowErrors = DevExpress.Utils.DefaultBoolean.True;
            gridViewUnidadMedida.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Top;
            gridViewUnidadMedida.EditFormPrepared += gridViewUnidadMedida_EditFormPrepared;
            gridViewUnidadMedida.EditFormHidden += gridViewUnidadMedida_EditFormHidden;
            gridViewUnidadMedida.KeyDown += gridViewUnidadMedida_KeyDown;
            // 
            // colNombre
            // 
            colNombre.FieldName = "Nombre";
            colNombre.Name = "colNombre";
            colNombre.Visible = true;
            colNombre.VisibleIndex = 0;
            // 
            // colSimbolo
            // 
            colSimbolo.FieldName = "Simbolo";
            colSimbolo.Name = "colSimbolo";
            colSimbolo.Visible = true;
            colSimbolo.VisibleIndex = 1;
            // 
            // UnidadMedidaView
            // 
            AutoScaleDimensions = new SizeF(6F, 13F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(610, 395);
            Controls.Add(gridControlUnidadMedida);
            IconOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("UnidadMedidaView.IconOptions.SvgImage");
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "UnidadMedidaView";
            Text = "Unidad Medida";
            Load += UnidadMedidaView_Load;
            ((System.ComponentModel.ISupportInitialize)gridControlUnidadMedida).EndInit();
            ((System.ComponentModel.ISupportInitialize)unidadMedidaDtoBindingSource).EndInit();
            ((System.ComponentModel.ISupportInitialize)gridViewUnidadMedida).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DevExpress.XtraGrid.GridControl gridControlUnidadMedida;
        private BindingSource unidadMedidaDtoBindingSource;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewUnidadMedida;
        private DevExpress.XtraGrid.Columns.GridColumn colNombre;
        private DevExpress.XtraGrid.Columns.GridColumn colSimbolo;
    }
}