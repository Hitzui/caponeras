namespace Caponeras.App.Views.Mantenimiento
{
    partial class MantenimientoVehiculoView
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
            DevExpress.XtraScheduler.TimeRuler timeRuler1 = new DevExpress.XtraScheduler.TimeRuler();
            DevExpress.XtraScheduler.TimeRuler timeRuler2 = new DevExpress.XtraScheduler.TimeRuler();
            DevExpress.XtraScheduler.TimeRuler timeRuler3 = new DevExpress.XtraScheduler.TimeRuler();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MantenimientoVehiculoView));
            schedulerControl = new DevExpress.XtraScheduler.SchedulerControl();
            schedulerDataStorage = new DevExpress.XtraScheduler.SchedulerDataStorage(components);
            mantenimientoDtoBindingSource = new BindingSource(components);
            mantenimientoLabelDtoBindingSource = new BindingSource(components);
            tipoMantenimientoDtoBindingSource = new BindingSource(components);
            mantenimientoStatusDtoBindingSource = new BindingSource(components);
            schedulerBarController = new DevExpress.XtraScheduler.UI.SchedulerBarController(components);
            splashScreenManager1 = new DevExpress.XtraSplashScreen.SplashScreenManager(this, typeof(WaitForm1), true, true);
            svgImageCollection1 = new DevExpress.Utils.SvgImageCollection(components);
            ((System.ComponentModel.ISupportInitialize)schedulerControl).BeginInit();
            ((System.ComponentModel.ISupportInitialize)schedulerDataStorage).BeginInit();
            ((System.ComponentModel.ISupportInitialize)mantenimientoDtoBindingSource).BeginInit();
            ((System.ComponentModel.ISupportInitialize)mantenimientoLabelDtoBindingSource).BeginInit();
            ((System.ComponentModel.ISupportInitialize)tipoMantenimientoDtoBindingSource).BeginInit();
            ((System.ComponentModel.ISupportInitialize)mantenimientoStatusDtoBindingSource).BeginInit();
            ((System.ComponentModel.ISupportInitialize)schedulerBarController).BeginInit();
            ((System.ComponentModel.ISupportInitialize)svgImageCollection1).BeginInit();
            SuspendLayout();
            // 
            // schedulerControl
            // 
            schedulerControl.ActiveViewType = DevExpress.XtraScheduler.SchedulerViewType.Month;
            schedulerControl.DataStorage = schedulerDataStorage;
            schedulerControl.Dock = DockStyle.Fill;
            schedulerControl.Location = new Point(0, 0);
            schedulerControl.Name = "schedulerControl";
            schedulerControl.OptionsCustomization.AllowAppointmentDrag = DevExpress.XtraScheduler.UsedAppointmentType.Custom;
            schedulerControl.Size = new Size(872, 556);
            schedulerControl.Start = new DateTime(2026, 2, 1, 0, 0, 0, 0);
            schedulerControl.TabIndex = 0;
            schedulerControl.Views.DayView.TimeRulers.Add(timeRuler1);
            schedulerControl.Views.DayView.TimeScale = TimeSpan.FromMinutes(30);
            schedulerControl.Views.FullWeekView.Enabled = true;
            schedulerControl.Views.FullWeekView.TimeRulers.Add(timeRuler2);
            schedulerControl.Views.FullWeekView.TimeScale = TimeSpan.FromMinutes(30);
            schedulerControl.Views.GanttView.Enabled = false;
            schedulerControl.Views.WeekView.Enabled = false;
            schedulerControl.Views.WorkWeekView.TimeRulers.Add(timeRuler3);
            schedulerControl.Views.YearView.UseOptimizedScrolling = false;
            schedulerControl.AllowAppointmentDrag += schedulerControl_AllowAppointmentDrag;
            schedulerControl.AllowAppointmentResize += schedulerControl_AllowAppointmentResize;
            schedulerControl.AllowAppointmentDelete += schedulerControl_AllowAppointmentDelete;
            schedulerControl.AllowAppointmentEdit += schedulerControl_AllowAppointmentEdit;
            schedulerControl.AppointmentDrag += schedulerControl_AppointmentDrag;
            schedulerControl.AppointmentDrop += schedulerControl_AppointmentDrop;
            schedulerControl.AppointmentResized += schedulerControl_AppointmentResized;
            schedulerControl.PopupMenuShowing += schedulerControl_PopupMenuShowing;
            schedulerControl.EditAppointmentFormShowing += schedulerControl_EditAppointmentFormShowing;
            // 
            // schedulerDataStorage
            // 
            // 
            // 
            // 
            schedulerDataStorage.AppointmentDependencies.AutoReload = false;
            // 
            // 
            // 
            schedulerDataStorage.Appointments.DataSource = mantenimientoDtoBindingSource;
            schedulerDataStorage.Appointments.Mappings.Description = "Observaciones";
            schedulerDataStorage.Appointments.Mappings.End = "FechaFin";
            schedulerDataStorage.Appointments.Mappings.Label = "Idlabel";
            schedulerDataStorage.Appointments.Mappings.Location = "Descripcion";
            schedulerDataStorage.Appointments.Mappings.ResourceId = "Idtipomantenimiento";
            schedulerDataStorage.Appointments.Mappings.Start = "FechaInicio";
            schedulerDataStorage.Appointments.Mappings.Status = "Idstatus";
            schedulerDataStorage.Appointments.Mappings.Subject = "Titulo";
            // 
            // 
            // 
            schedulerDataStorage.Labels.DataSource = mantenimientoLabelDtoBindingSource;
            schedulerDataStorage.Labels.Mappings.Color = "Color";
            schedulerDataStorage.Labels.Mappings.DisplayName = "DisplayName";
            schedulerDataStorage.Labels.Mappings.Id = "Id";
            schedulerDataStorage.Labels.Mappings.MenuCaption = "MenuCaption";
            // 
            // 
            // 
            schedulerDataStorage.Resources.CustomFieldMappings.Add(new DevExpress.XtraScheduler.ResourceCustomFieldMapping("FrecuenciaKm", "FrecuenciaKm"));
            schedulerDataStorage.Resources.CustomFieldMappings.Add(new DevExpress.XtraScheduler.ResourceCustomFieldMapping("FrecuenciaMeses", "FrecuenciaMeses"));
            schedulerDataStorage.Resources.CustomFieldMappings.Add(new DevExpress.XtraScheduler.ResourceCustomFieldMapping("Descripcion", "Descripcion"));
            schedulerDataStorage.Resources.DataSource = tipoMantenimientoDtoBindingSource;
            schedulerDataStorage.Resources.Mappings.Caption = "Nombre";
            schedulerDataStorage.Resources.Mappings.Id = "IdtipoMantenimiento";
            schedulerDataStorage.Resources.Mappings.ParentId = "Tipo";
            // 
            // 
            // 
            schedulerDataStorage.Statuses.DataSource = mantenimientoStatusDtoBindingSource;
            schedulerDataStorage.Statuses.Mappings.Brush = "CustomBrush";
            schedulerDataStorage.Statuses.Mappings.DisplayName = "DisplayName";
            schedulerDataStorage.Statuses.Mappings.Id = "Id";
            schedulerDataStorage.Statuses.Mappings.MenuCaption = "MenuCaption";
            schedulerDataStorage.AppointmentDeleting += schedulerDataStorage_AppointmentDeleting;
            // 
            // mantenimientoDtoBindingSource
            // 
            mantenimientoDtoBindingSource.DataSource = typeof(Dto.MantenimientoDto);
            // 
            // mantenimientoLabelDtoBindingSource
            // 
            mantenimientoLabelDtoBindingSource.DataSource = typeof(Dto.MantenimientoLabelDto);
            // 
            // tipoMantenimientoDtoBindingSource
            // 
            tipoMantenimientoDtoBindingSource.DataSource = typeof(Dto.TipoMantenimientoDto);
            // 
            // mantenimientoStatusDtoBindingSource
            // 
            mantenimientoStatusDtoBindingSource.DataSource = typeof(Dto.MantenimientoStatusDto);
            // 
            // schedulerBarController
            // 
            schedulerBarController.Control = schedulerControl;
            // 
            // splashScreenManager1
            // 
            splashScreenManager1.ClosingDelay = 500;
            // 
            // svgImageCollection1
            // 
            svgImageCollection1.Add("bo_quote", "image://svgimages/business objects/bo_quote.svg");
            svgImageCollection1.Add("bo_department", "image://svgimages/business objects/bo_department.svg");
            svgImageCollection1.Add("payment", "image://svgimages/outlook inspired/payment.svg");
            // 
            // MantenimientoVehiculoView
            // 
            AutoScaleDimensions = new SizeF(6F, 13F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(872, 556);
            Controls.Add(schedulerControl);
            IconOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("MantenimientoVehiculoView.IconOptions.SvgImage");
            Name = "MantenimientoVehiculoView";
            Text = "Mantenimientos";
            Load += MantenimientoVehiculoView_Load;
            ((System.ComponentModel.ISupportInitialize)schedulerControl).EndInit();
            ((System.ComponentModel.ISupportInitialize)schedulerDataStorage).EndInit();
            ((System.ComponentModel.ISupportInitialize)mantenimientoDtoBindingSource).EndInit();
            ((System.ComponentModel.ISupportInitialize)mantenimientoLabelDtoBindingSource).EndInit();
            ((System.ComponentModel.ISupportInitialize)tipoMantenimientoDtoBindingSource).EndInit();
            ((System.ComponentModel.ISupportInitialize)mantenimientoStatusDtoBindingSource).EndInit();
            ((System.ComponentModel.ISupportInitialize)schedulerBarController).EndInit();
            ((System.ComponentModel.ISupportInitialize)svgImageCollection1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DevExpress.XtraScheduler.SchedulerControl schedulerControl;
        private DevExpress.XtraScheduler.SchedulerDataStorage schedulerDataStorage;
        private DevExpress.XtraScheduler.UI.SchedulerBarController schedulerBarController;
        private BindingSource mantenimientoDtoBindingSource;
        private BindingSource tipoMantenimientoDtoBindingSource;
        private BindingSource mantenimientoLabelDtoBindingSource;
        private BindingSource mantenimientoStatusDtoBindingSource;
        private DevExpress.XtraSplashScreen.SplashScreenManager splashScreenManager1;
        private DevExpress.Utils.SvgImageCollection svgImageCollection1;
    }
}
