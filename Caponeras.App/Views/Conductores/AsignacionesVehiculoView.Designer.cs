namespace Caponeras.App.Views.Conductores
{
    partial class AsignacionesVehiculoView
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
            schedulerControl = new DevExpress.XtraScheduler.SchedulerControl();
            schedulerDataStorage = new DevExpress.XtraScheduler.SchedulerDataStorage(components);
            vehiculoConductorDtoBindingSource = new BindingSource(components);
            splashScreenManager1 = new DevExpress.XtraSplashScreen.SplashScreenManager(this, typeof(WaitForm1), true, true);
            ((System.ComponentModel.ISupportInitialize)schedulerControl).BeginInit();
            ((System.ComponentModel.ISupportInitialize)schedulerDataStorage).BeginInit();
            ((System.ComponentModel.ISupportInitialize)vehiculoConductorDtoBindingSource).BeginInit();
            SuspendLayout();
            // 
            // schedulerControl
            // 
            schedulerControl.ActiveViewType = DevExpress.XtraScheduler.SchedulerViewType.Month;
            schedulerControl.DataStorage = schedulerDataStorage;
            schedulerControl.Dock = DockStyle.Fill;
            schedulerControl.Location = new Point(0, 0);
            schedulerControl.Name = "schedulerControl";
            schedulerControl.Size = new Size(730, 502);
            schedulerControl.Start = new DateTime(2026, 5, 3, 0, 0, 0, 0);
            schedulerControl.TabIndex = 0;
            schedulerControl.Text = "schedulerControl1";
            schedulerControl.Views.DayView.TimeRulers.Add(timeRuler1);
            schedulerControl.Views.FullWeekView.Enabled = true;
            schedulerControl.Views.FullWeekView.TimeRulers.Add(timeRuler2);
            schedulerControl.Views.GanttView.Enabled = false;
            schedulerControl.Views.TimelineView.Enabled = false;
            schedulerControl.Views.WorkWeekView.TimeRulers.Add(timeRuler3);
            schedulerControl.Views.YearView.UseOptimizedScrolling = false;
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
            schedulerDataStorage.Appointments.CustomFieldMappings.Add(new DevExpress.XtraScheduler.AppointmentCustomFieldMapping("Identificacion", "Identificacion"));
            schedulerDataStorage.Appointments.CustomFieldMappings.Add(new DevExpress.XtraScheduler.AppointmentCustomFieldMapping("IdVehiculo", "IdVehiculo"));
            schedulerDataStorage.Appointments.CustomFieldMappings.Add(new DevExpress.XtraScheduler.AppointmentCustomFieldMapping("Placa", "Placa"));
            schedulerDataStorage.Appointments.CustomFieldMappings.Add(new DevExpress.XtraScheduler.AppointmentCustomFieldMapping("IdConductor", "IdConductor"));
            schedulerDataStorage.Appointments.DataSource = vehiculoConductorDtoBindingSource;
            schedulerDataStorage.Appointments.Labels.CreateNewLabel(0, "None", "&None", SystemColors.Window);
            schedulerDataStorage.Appointments.Labels.CreateNewLabel(1, "Important", "&Important", Color.FromArgb(255, 194, 190));
            schedulerDataStorage.Appointments.Labels.CreateNewLabel(2, "Business", "&Business", Color.FromArgb(168, 213, 255));
            schedulerDataStorage.Appointments.Labels.CreateNewLabel(3, "Personal", "&Personal", Color.FromArgb(193, 244, 156));
            schedulerDataStorage.Appointments.Labels.CreateNewLabel(4, "Vacation", "&Vacation", Color.FromArgb(243, 228, 199));
            schedulerDataStorage.Appointments.Labels.CreateNewLabel(5, "Must Attend", "Must &Attend", Color.FromArgb(244, 206, 147));
            schedulerDataStorage.Appointments.Labels.CreateNewLabel(6, "Travel Required", "&Travel Required", Color.FromArgb(199, 244, 255));
            schedulerDataStorage.Appointments.Labels.CreateNewLabel(7, "Needs Preparation", "&Needs Preparation", Color.FromArgb(207, 219, 152));
            schedulerDataStorage.Appointments.Labels.CreateNewLabel(8, "Birthday", "&Birthday", Color.FromArgb(224, 207, 233));
            schedulerDataStorage.Appointments.Labels.CreateNewLabel(9, "Anniversary", "&Anniversary", Color.FromArgb(141, 233, 223));
            schedulerDataStorage.Appointments.Labels.CreateNewLabel(10, "Phone Call", "Phone &Call", Color.FromArgb(255, 247, 165));
            schedulerDataStorage.Appointments.Mappings.AllDay = "AllDay";
            schedulerDataStorage.Appointments.Mappings.Description = "Conductor";
            schedulerDataStorage.Appointments.Mappings.End = "FechaFin";
            schedulerDataStorage.Appointments.Mappings.Label = "Zonas";
            schedulerDataStorage.Appointments.Mappings.Location = "Placa";
            schedulerDataStorage.Appointments.Mappings.Start = "FechaInicio";
            schedulerDataStorage.Appointments.Mappings.Subject = "Codigo";
            // 
            // vehiculoConductorDtoBindingSource
            // 
            vehiculoConductorDtoBindingSource.DataSource = typeof(Dto.VehiculoConductorDto);
            // 
            // splashScreenManager1
            // 
            splashScreenManager1.ClosingDelay = 500;
            // 
            // AsignacionesVehiculoView
            // 
            AutoScaleDimensions = new SizeF(6F, 13F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(730, 502);
            Controls.Add(schedulerControl);
            Name = "AsignacionesVehiculoView";
            Text = "AsignacionesVehiculoView";
            Load += AsignacionesVehiculoView_Load;
            ((System.ComponentModel.ISupportInitialize)schedulerControl).EndInit();
            ((System.ComponentModel.ISupportInitialize)schedulerDataStorage).EndInit();
            ((System.ComponentModel.ISupportInitialize)vehiculoConductorDtoBindingSource).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DevExpress.XtraScheduler.SchedulerControl schedulerControl;
        private DevExpress.XtraScheduler.SchedulerDataStorage schedulerDataStorage;
        private BindingSource vehiculoConductorDtoBindingSource;
        private DevExpress.XtraSplashScreen.SplashScreenManager splashScreenManager1;
    }
}