using Caponeras.App.ViewModels.Conductores;
using Caponeras.App.Views.Mantenimiento;
using DevExpress.XtraEditors;
using DevExpress.XtraGauges.Core.Customization;
using DevExpress.XtraScheduler;
using DevExpress.XtraScheduler.Views;
using DevExpress.XtraSplashScreen;
using System;
using System.Diagnostics;
using System.Linq;

namespace Caponeras.App.Views.Conductores
{
    public partial class AsignacionesVehiculoView : XtraForm
    {
        private AsignacionesVehiculoViewModel _viewModel;
        public AsignacionesVehiculoView(AsignacionesVehiculoViewModel viewModel)
        {
            _viewModel = viewModel;
            InitializeComponent();
            DataContext = _viewModel;
            schedulerDataStorage.Appointments.ResourceSharing = false;
        }

        private async void AsignacionesVehiculoView_Load(object sender, EventArgs e)
        {
            try
            {
                schedulerControl.Start = DateTime.Now;
                var mappings = schedulerDataStorage.Appointments.Mappings;
                mappings.AppointmentId = "IdvehiculoConductor";
                await _viewModel.LoadData();
                vehiculoConductorDtoBindingSource.DataSource = _viewModel.VehiculoConductoresBindingList;
            }
            catch (Exception ex)
            {
                MessageBox.Show(@$"Error al cargar los datos: {ex.Message}");
            }
        }

        private async void schedulerControl_EditAppointmentFormShowing(object sender, AppointmentFormEventArgs e)
        {
            try
            {
                e.Handled = true;
                if (e.Appointment.Id is null)
                {
                    return;
                }
                splashScreenManager1.ShowWaitForm();
                var myForm = new CustomAppointmentForm(
                    schedulerControl,
                    e.Appointment,
                    e.OpenRecurrenceForm
                );
                var result = myForm.ShowDialog();
                splashScreenManager1.CloseWaitForm();
                if (result != DialogResult.OK) return;
                await _viewModel.UpdateAsignacionVehiculo(e.Appointment);
                await _viewModel.LoadData();
                vehiculoConductorDtoBindingSource.DataSource = _viewModel.VehiculoConductoresBindingList;
                schedulerDataStorage.RefreshData();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
        }

        private void schedulerControl_PopupMenuShowing(object sender, PopupMenuShowingEventArgs e)
        {
            switch (e.MenuType)
            {
                case SchedulerMenuType.AppointmentMenu:
                {
                    var deleteMenu = e.Menu.GetMenuItemById(SchedulerMenuItemId.DeleteAppointment);
                    deleteMenu.Visible = false;
                    e.Menu.Items.Add(new SchedulerMenuItem("Eliminar", OnDeleteMenuOnClick, deleteMenu.GetImage()));
                    
                    break;
                }
                case SchedulerMenuType.DefaultMenu:
                {
                    var menuItemById = e.Menu.GetMenuItemById(SchedulerMenuItemId.NewAppointment);
                    menuItemById.Visible = false;
                    break;
                }
                case SchedulerMenuType.RulerMenu:
                    break;
                case SchedulerMenuType.DependencyMenu:
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        private async void OnDeleteMenuOnClick(object? s, EventArgs args)
        {
            try
            {
                var appointment = schedulerControl.SelectedAppointments.FirstOrDefault();
                if (appointment is null) return;
                var result = XtraMessageBox.Show("¿Está seguro de eliminar esta asignación?", "Confirmar eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result != DialogResult.Yes) return;
                var delete =await _viewModel.DeleteAsignacionVehiculo((int?)appointment.Id);
                if (delete)
                {
                    schedulerDataStorage.Appointments.Remove(appointment);
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
            }
        }
    }
}
