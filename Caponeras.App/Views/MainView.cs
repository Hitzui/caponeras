using System.Diagnostics;
using Caponeras.App.ViewModels;
using DevExpress.XtraEditors;

namespace Caponeras.App.Views
{
    public partial class MainView : XtraForm
    {
        private readonly MainViewModel _viewModel;

        public MainView(MainViewModel viewModel)
        {
            _viewModel = viewModel;
            InitializeComponent();
            IsMdiContainer = true;
            _viewModel.SetMainView(this);
            FormClosing += (sender, args) =>
            {
                var result = XtraMessageBox.Show("¿Salir de la aplicación de gestion de caponeras'",
                    "Salir", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.No)
                {
                    args.Cancel = true;
                }
            };
        }

        private void barButtonItemAgencias_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            _viewModel.OnAgenciasClick(splashScreenManager1);
        }

        private void barButtonItemCajas_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            _viewModel.OnCajasClick(splashScreenManager1);
        }

        private void barButtonItemConductores_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            _viewModel.OnConductoresClick(splashScreenManager1, ribbonPageCadetes);
        }

        private void barButtonItemAddCadete_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            _viewModel.OnCadeteAddClick(splashScreenManager1);
        }

        private void barButtonItemEditConductor_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            _viewModel.OnCadeteEditClick(splashScreenManager1);
        }

        private void barButtonItemVehiculos_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            _viewModel.OnVehiculosClick(splashScreenManager1);
        }

        private void barButtonItemAgregarVehiculo_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            _viewModel.OnVehiculosAddClick(splashScreenManager1);
        }

        private void barButtonItemEditVehiculo_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            _viewModel.OnVehiculosEditClick(splashScreenManager1);
        }

        private void barButtonItemMantenimientosVehiculo_ItemClick(object sender,
            DevExpress.XtraBars.ItemClickEventArgs e)
        {
            _viewModel.OnMantenimientoVehiculosClick(splashScreenManager1, barButtonItemRecargarMantenimiento);
        }

        private void barButtonItem4_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            _viewModel.OnProductosClick(splashScreenManager1, ribbonPageGroupOpciones);
        }

        private void barButtonItemUm_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            _viewModel.OnUnidadMedidaClick(splashScreenManager1);
        }

        private void MainView_Load(object sender, EventArgs e)
        {
            try
            {
                lblUsuario.Text = _viewModel.GetUsuario().Nombre;
                _viewModel.SetAlertControl(alertControl);
                _viewModel.AperturaCierreCaja(barButtonItemCerrarCaja, barButtonItemAperturarCaja, lblMaestroCaja);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
        }

        private void barButtonItemCategoriaProductos_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            _viewModel.OnCategoriaProductoClick(splashScreenManager1);
        }

        private void barButtonItemAddProducto_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            _viewModel.OnShowAddClick(splashScreenManager1);
        }

        private void barButtonItemEditProducto_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            _viewModel.OnEditClick(splashScreenManager1);
        }

        private async void barButtonItemDeleteProducto_ItemClick(object sender,
            DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                var result = XtraMessageBox.Show("¿Seguro desea elminar el registro seleccionado", "Eliminar",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result != DialogResult.Yes)
                {
                    return;
                }

                await _viewModel.OnDeleteClick();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
        }

        private void barButtonItemRecargarMantenimiento_ItemClick(object sender,
            DevExpress.XtraBars.ItemClickEventArgs e)
        {
            _viewModel.OnRecargarMantenimientoClick(splashScreenManager1);
        }

        private void barButtonItemProveedores_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            _viewModel.OnProveedoresClick(splashScreenManager1, ribbonPageGroupOpciones);
        }

        private void barButtonItemCompras_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            _viewModel.OnComrpasClick(splashScreenManager1, ribbonPageGroupOpciones);
        }

        private void barButtonItemMcaja_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            _viewModel.OnMcajaClick(splashScreenManager1, ribbonPageGroupOpciones);
            _viewModel.OnRecargarMcajaClick(splashScreenManager1);
        }

        private void barButtonItemAperturarCaja_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            _viewModel.OnAperturarCajaClick(splashScreenManager1, barButtonItemCerrarCaja, barButtonItemAperturarCaja,
                lblMaestroCaja);
        }

        private void barButtonItemCerrarCaja_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            _viewModel.OnCerrarCajaClick(splashScreenManager1, barButtonItemCerrarCaja, barButtonItemAperturarCaja);
        }

        private void barButtonItemMovCaja_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            _viewModel.OnMovCajaClick(splashScreenManager1, ribbonPageGroupOpcionesAdministrar);
        }

        private void barButtonItemAddAdministrar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            _viewModel.OnShowAddClick(splashScreenManager1);
        }

        private void barButtonItemEditAdministrar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            _viewModel.OnEditClick(splashScreenManager1);
        }

        private async void barButtonItemDeleteAdministrar_ItemClick(object sender,
            DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                var result = XtraMessageBox.Show("¿Seguro desea elminar el registro seleccionado", "Eliminar",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result != DialogResult.Yes)
                {
                    return;
                }

                await _viewModel.OnDeleteClick();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
        }

        private void barButtonItemRealizarMovimiento_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            _viewModel.RealizarMovimientoOnClick(splashScreenManager1);
        }

        private void barButtonItemAsignarVehiculoCadete_ItemClick(object sender,
            DevExpress.XtraBars.ItemClickEventArgs e)
        {
            _viewModel.AsignarVehiculoCadeteOnClick(splashScreenManager1);
        }

        private void barButtonItemAsignacionesVehiculo_ItemClick(object sender,
            DevExpress.XtraBars.ItemClickEventArgs e)
        {
            _viewModel.AsignacionesVehiculoOnClick(splashScreenManager1);
        }

        private void barButtonItemConfigurarCuotaCadete_ItemClick(object sender,
            DevExpress.XtraBars.ItemClickEventArgs e)
        {
            _viewModel.ConfigurarCuotaCadeteOnClick(splashScreenManager1);
        }

        private void barButtonItemRealiarPagoCadete_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            _viewModel.RealizarPagoCadeteOnClick(splashScreenManager1);
        }

        private void barButtonItemIventario_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            _viewModel.InventarioOnClick(splashScreenManager1);
        }

        private void barButtonItemReportesCadetes_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            _viewModel.ReportesCadetesOnClick(splashScreenManager1);
        }

        private void barButtonItemReporteDiaCaja_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            _viewModel.ReporteDiaCajaOnClick(splashScreenManager1);
        }

        private void barButtonItemAseguradoras_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            _viewModel.AseguradorasOnClick(splashScreenManager1, ribbonPageGroupVehiculosOpciones);
        }

        private async void barButtonItemAgregarAseguradora_ItemClick(object sender,
            DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (ActiveMdiChild is Veniculos.AseguradorasFormView view)
                await view.AddAseguradoraAsync();
            else if (ActiveMdiChild is Veniculos.SegurosVehicularesView segurosView)
                await segurosView.AgregarSeguroAsync();
        }

        private async void barButtonItemEditarAseguradora_ItemClick(object sender,
            DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (ActiveMdiChild is Veniculos.AseguradorasFormView view)
                await view.EditarAseguradoraSeleccionadaAsync();
            else if (ActiveMdiChild is Veniculos.SegurosVehicularesView segurosView)
                await segurosView.EditarSeguroSeleccionadoAsync();
        }

        private async void barButtonItemEliminarAseguradora_ItemClick(object sender,
            DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (ActiveMdiChild is Veniculos.AseguradorasFormView view)
                await view.EliminarAseguradoraSeleccionadaAsync();
            else if (ActiveMdiChild is Veniculos.SegurosVehicularesView segurosView)
                await segurosView.EliminarSeguroSeleccionadoAsync();
        }

        private void barButtonItemSegurosVehiculares_ItemClick(object sender,
            DevExpress.XtraBars.ItemClickEventArgs e)
        {
            _viewModel.SegurosVehicularesOnClick(splashScreenManager1, ribbonPageGroupVehiculosOpciones);
        }

        private void barButtonItemPagos_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            _viewModel.PagosOnClick(splashScreenManager1);
        }

        private async void MainView_Shown(object sender, EventArgs e)
        {
            DataContext = _viewModel;
            try
            {
                var policies = await _viewModel.GetDailyExpiringPoliciesAsync();
                if (policies.Count == 0)
                    return;

                var message = string.Join(Environment.NewLine, policies.Select(policy =>
                {
                    var daysRemaining = (policy.FechaVencimiento.Date - DateTime.Today).Days;
                    var expiryText = daysRemaining == 0
                        ? "vence hoy"
                        : $"vence en {daysRemaining} día(s)";
                    return $"• {policy.NumeroPoliza} | {policy.VehiculoDescripcion} | " +
                           $"{policy.AseguradoraNombre} | {policy.TipoSeguroNombre} | " +
                           $"{policy.FechaVencimiento:dd/MM/yyyy} ({expiryText})";
                }));

                XtraMessageBox.Show(this,
                    $"Hay pólizas de seguro próximas a vencer:{Environment.NewLine}{Environment.NewLine}{message}",
                    "Advertencia de vencimiento de seguros",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"No fue posible consultar pólizas próximas a vencer: {ex}");
            }
        }

        private void barButtonItemAsignacionesVehiculoDiarias_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            _viewModel.AsignacionesVehiculoDiariasOnClick(splashScreenManager1);
        }

        private void barButtonItemControlAusencias_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            _viewModel.ControlAusenciasCadetesOnClick(splashScreenManager1);
        }

        private void btnReportesInventario_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            _viewModel.ReportesProductosInventariosOnClick(splashScreenManager1);
        }
    }
}
