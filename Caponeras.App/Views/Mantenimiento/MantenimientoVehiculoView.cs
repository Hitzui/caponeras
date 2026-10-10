using Caponeras.App.ViewModels.Mantenimiento;
using DevExpress.Utils.Menu;
using DevExpress.XtraEditors;
using DevExpress.XtraScheduler;
using DevExpress.XtraScheduler.Views;
using NLog;
using System.Diagnostics;

namespace Caponeras.App.Views.Mantenimiento
{
    public partial class MantenimientoVehiculoView : XtraForm
    {
        private ProveedoreFormViewModel _proveedoresFormViewModel;
        private MantenimientoVehiculoViewModel _viewModel;
        private ILogger _logger = LogManager.GetCurrentClassLogger();

        public MantenimientoVehiculoView(
            MantenimientoVehiculoViewModel viewModel,
            ProveedoreFormViewModel proveedoresFormViewModel
        )
        {
            _viewModel = viewModel;
            _proveedoresFormViewModel = proveedoresFormViewModel;
            InitializeComponent();
            schedulerDataStorage.Appointments.ResourceSharing = false;
            schedulerControl.OptionsCustomization.AllowAppointmentDrag = UsedAppointmentType.Custom;
            schedulerControl.OptionsCustomization.AllowAppointmentResize = UsedAppointmentType.Custom;
            schedulerControl.OptionsCustomization.AllowAppointmentEdit = UsedAppointmentType.Custom;
            schedulerControl.OptionsCustomization.AllowAppointmentDelete = UsedAppointmentType.Custom;
        }

        private async void MantenimientoVehiculoView_Load(object sender, EventArgs e)
        {
            try
            {
                await InitAppointments();
                await InitResources();
                await InitLabels();
                await InitStatus();
                schedulerControl.RefreshData();
                schedulerControl.Start = DateTime.Now;
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show($"Error: {ex.Message}");
                _logger.Error(ex, "Error al cargar los mantenimientos");
            }
        }


        private async void schedulerControl_EditAppointmentFormShowing(object sender, AppointmentFormEventArgs e)
        {
            try
            {
                if (splashScreenManager1.IsSplashFormVisible)
                {
                    splashScreenManager1.CloseWaitForm();
                }
                e.Handled = true;
                if (e.Appointment.Id is null)
                {
                    e.Appointment.SetId(0);
                    if (e.Appointment.AllDay)
                    {
                        var fecha = e.Appointment.Start.Date;
                        e.Appointment.AllDay = false;
                        e.Appointment.Start = fecha.AddHours(8);
                        e.Appointment.End = fecha.AddHours(9);
                    }
                }

                splashScreenManager1.ShowWaitForm();
                // Forzar el procesamiento de mensajes para que el WaitForm se dibuje
                await Task.Delay(50); // Pequeña pausa para asegurar que se muestre
                var myForm = new MantenimientoFormView(
                    schedulerControl,
                    e.Appointment,
                    e.OpenRecurrenceForm,
                    _viewModel,
                    _proveedoresFormViewModel
                );
                myForm.WindowState = FormWindowState.Maximized;
                var result = await myForm.ShowDialogAsync();
                if (splashScreenManager1.IsSplashFormVisible)
                {
                    splashScreenManager1.CloseWaitForm();
                }
                if (result != DialogResult.OK) return;
                if (await _viewModel.Save(e.Appointment))
                {
                    await InitAppointments();
                    schedulerDataStorage.RefreshData();
                    schedulerControl.RefreshData();
                    schedulerControl.Refresh();
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
            }
            finally
            {
                if (splashScreenManager1.IsSplashFormVisible)
                    splashScreenManager1.CloseWaitForm();
            }
        }

        public async Task InitAppointments()
        {
            var mappings = schedulerDataStorage.Appointments.Mappings;
            mappings.AppointmentId = "Idmantenimiento";
            mappings.ResourceId = "Idtipomantenimiento";

            await _viewModel.GetAllMantenimientos();

            mantenimientoDtoBindingSource.DataSource = null;
            mantenimientoDtoBindingSource.DataSource = _viewModel.BindingMantenimientoDtos;

            schedulerDataStorage.Appointments.DataSource = null;
            schedulerDataStorage.Appointments.DataSource = mantenimientoDtoBindingSource;

            schedulerDataStorage.RefreshData();
        }

        private async Task InitResources()
        {
            var mappings = schedulerDataStorage.Resources.Mappings;
            mappings.Id = "Idtipomantenimiento";
            mappings.Caption = "Nombre";
            await _viewModel.GetAllTipoMantenimiento();
            tipoMantenimientoDtoBindingSource.DataSource = _viewModel.BindingTipoMantenimientoDtos;
            schedulerDataStorage.Resources.DataSource = tipoMantenimientoDtoBindingSource;
        }

        private async Task InitLabels()
        {
            await _viewModel.GetAllMantenimientoLabel();
            mantenimientoLabelDtoBindingSource.DataSource = _viewModel.BindingMantenimientoLabelDtos;
            schedulerDataStorage.Labels.DataSource = mantenimientoLabelDtoBindingSource;
        }

        private async Task InitStatus()
        {
            await _viewModel.GetAllMantenimientoStatus();
            mantenimientoStatusDtoBindingSource.DataSource = _viewModel.BindingMantenimienStatusDtos;
            schedulerDataStorage.Statuses.DataSource = mantenimientoStatusDtoBindingSource;
        }

        private void schedulerControl_AppointmentDrag(object sender, AppointmentDragEventArgs e)
        {
        }

        private async void schedulerControl_AppointmentDrop(object sender, AppointmentDragEventArgs e)
        {
            try
            {
                var apt = e.EditedAppointment;
                await _viewModel.Save(apt);
                await InitAppointments();
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
            }
            finally
            {
                schedulerDataStorage.RefreshData();
            }
        }

        private void Allow(AppointmentOperationEventArgs e, string? msg = null)
        {
            try
            {
                var allow = _viewModel.AllowDragAndDrop(e.Appointment);
                if (allow) return;
                if (string.IsNullOrEmpty(msg))
                {
                    msg = "No se puede mover el mantenimiento, ya que ha sido completado";
                }

                XtraMessageBox.Show(msg, "Mantenimientos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Allow = false;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
        }

        private void schedulerControl_AllowAppointmentDrag(object sender, AppointmentOperationEventArgs e)
        {
            Allow(e);
        }

        private async void schedulerControl_AppointmentResized(object sender, AppointmentResizeEventArgs e)
        {
            try
            {
                var apt = e.EditedAppointment;
                await _viewModel.Save(apt);
                await InitAppointments();
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
            }
            finally
            {
                schedulerDataStorage.RefreshData();
            }
        }

        private void schedulerControl_AllowAppointmentResize(object sender, AppointmentOperationEventArgs e)
        {
            Allow(e);
        }

        private void schedulerControl_PopupMenuShowing(object sender, PopupMenuShowingEventArgs e)
        {
            Debug.WriteLine($"Tipo de menu {e.MenuType.ToString()}");
            if (e.MenuType == SchedulerMenuType.AppointmentMenu)
            {
                var repuestosItem = new DXMenuItem("Repuestos", OnRepuestosClick, DXMenuItemPriority.Normal);
                repuestosItem.ImageOptions.SvgImage = svgImageCollection1[0];
                var proveedorItem = new DXMenuItem("Mano de obra", OnProveedorClick, DXMenuItemPriority.Normal);
                proveedorItem.ImageOptions.SvgImage = svgImageCollection1[1];
                e.Menu.Items.Add(repuestosItem);
                e.Menu.Items.Add(proveedorItem);
            }
        }

        private void OnProveedorClick(object? sender, EventArgs e)
        {
            _viewModel.ShowFormProveedores(schedulerControl.SelectedAppointments[0]);
        }

        private void OnRepuestosClick(object? sender, EventArgs e)
        {
            _viewModel.ShowFormRepuestos(schedulerControl.SelectedAppointments[0]);
        }

        private void schedulerControl_AllowAppointmentDelete(object sender, AppointmentOperationEventArgs e)
        {
            Allow(e, "No se puede eliminar el evento, ya fue completado");
        }

        private void schedulerControl_AllowAppointmentEdit(object sender, AppointmentOperationEventArgs e)
        {
            Allow(e, "No se puede editar el evento, ya ha sido completado");
        }

        private async void schedulerDataStorage_AppointmentDeleting(object sender, PersistentObjectCancelEventArgs e)
        {
            e.Cancel = true;
            var result = XtraMessageBox.Show("¿Seguro desea elminar el evento?", "Eliminar", MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);
            if (result != DialogResult.Yes)
            {
                return;
            }

            if (await _viewModel.Delete(e.Object as Appointment))
                await InitAppointments();
        }
    }
}
