using Caponeras.App.Dto;
using Caponeras.App.Helpers;
using Caponeras.App.Services;
using Caponeras.App.ViewModels.Compras;
using Caponeras.App.ViewModels.Mcaja;
using Caponeras.App.ViewModels.Productos;
using Caponeras.App.ViewModels.Proveedores;
using Caponeras.App.Views;
using Caponeras.App.Views.Agencia;
using Caponeras.App.Views.Caja;
using Caponeras.App.Views.CategoriaProductos;
using Caponeras.App.Views.Compras;
using Caponeras.App.Views.Conductores;
using Caponeras.App.Views.Inventario;
using Caponeras.App.Views.Mantenimiento;
using Caponeras.App.Views.Reportes;
using Caponeras.App.Views.Mcaja;
using Caponeras.App.Views.Productos;
using Caponeras.App.Views.Proveedores;
using Caponeras.App.Views.UnidadMedida;
using Caponeras.App.Views.Veniculos;
using Caponeras.Data.Models;
using DevExpress.XtraBars;
using DevExpress.XtraBars.Alerter;
using DevExpress.XtraBars.Ribbon;
using DevExpress.XtraEditors;
using DevExpress.XtraSplashScreen;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using NLog;
using System.Diagnostics;
using System.Globalization;
using System.IO;

namespace Caponeras.App.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        private readonly ILogger _logger = LogManager.GetCurrentClassLogger();
        private readonly INavigationService _navigation;
        private readonly IServiceProvider _serviceProvider;
        private readonly ISelectionService _selectionService;
        private readonly SegurosVehicularesService _segurosVehicularesService;
        private readonly IConfiguration _configuration;

        public MainViewModel(INavigationService navigation, ISelectionService selectionService,
            IServiceProvider serviceProvider, SegurosVehicularesService segurosVehicularesService,
            IConfiguration configuration)
        {
            _navigation = navigation;
            _selectionService = selectionService;
            _serviceProvider = serviceProvider;
            _segurosVehicularesService = segurosVehicularesService;
            _configuration = configuration;
        }

        public async Task<List<SeguroVehicularDto>> GetDailyExpiringPoliciesAsync()
        {
            var markerPath = Path.Combine(Application.LocalUserAppDataPath, "aviso-seguros.txt");
            var todayMarker = DateTime.Today.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture);
            if (File.Exists(markerPath) &&
                await File.ReadAllTextAsync(markerPath) == todayMarker)
                return new List<SeguroVehicularDto>();

            var configuredDays = _configuration.GetValue<int?>("Seguros:DiasAvisoVencimiento") ?? 3;
            var days = configuredDays >= 0 ? configuredDays : 3;
            var policies = await _segurosVehicularesService.GetExpiringWithinDays(days);

            Directory.CreateDirectory(Path.GetDirectoryName(markerPath)!);
            await File.WriteAllTextAsync(markerPath, todayMarker);
            return policies;
        }

        private async Task ExecuteDeleteAsync<TViewModel, TDto>()
            where TViewModel : ICrudViewModel
        {
            if (_navigation.Query is not TDto dto)
                return;

            var vm = _serviceProvider.GetRequiredService<TViewModel>();

            await vm.DeleteAsync(dto);
        }

        public void OnAgenciasClick(SplashScreenManager splashScreenManager)
        {
            _navigation.ShowDialog<AgenciaView>(splashScreenManager);
        }

        public void OnCajasClick(SplashScreenManager splashScreenManager)
        {
            _navigation.ShowDialog<CajaView>(splashScreenManager);
        }

        public void OnConductoresClick(SplashScreenManager splashScreenManager, RibbonPage ribbonPageCadetes)
        {
            ribbonPageCadetes.Visible = true;
            ribbonPageCadetes.Ribbon.SelectedPage = ribbonPageCadetes;
            var view = _navigation.Show<ConductoresView>(splashScreenManager);

            view.FormClosed += (s, e) => { ribbonPageCadetes.Visible = false; };
        }

        public void OnCadeteAddClick(SplashScreenManager splashScreenManager)
        {
            _navigation.ShowDialog<CadeteFormView>(splashScreenManager, query: null);
        }


        public void OnCadeteEditClick(SplashScreenManager splashScreenManager)
        {
            if (_navigation.Query is not ConductoresDto cadete)
            {
                return;
            }

            _navigation.ShowDialog<CadeteFormView>(splashScreenManager, query: cadete);
        }

        public void OnVehiculosClick(SplashScreenManager splashScreenManager)
        {
            _navigation.Show<VehiculosView>(splashScreenManager);
        }

        public void OnVehiculosAddClick(SplashScreenManager splashScreenManager)
        {
            _navigation.ShowDialog<VehiculosFormView>(splashScreenManager: splashScreenManager);
        }

        public void OnVehiculosEditClick(SplashScreenManager splashScreenManager)
        {
            if (_navigation.Query is not VehiculosDto vehiculo)
            {
                return;
            }

            _navigation.ShowDialog<VehiculosFormView>(splashScreenManager, query: vehiculo);
        }

        private MantenimientoVehiculoView? _mantenimientoVehiculoView;

        public void OnMantenimientoVehiculosClick(SplashScreenManager splashScreenManager,
            BarButtonItem barButtonItemRecargarMantenimiento)
        {
            barButtonItemRecargarMantenimiento.Visibility = BarItemVisibility.Always;
            _mantenimientoVehiculoView = _navigation.Show<MantenimientoVehiculoView>(splashScreenManager);
            _mantenimientoVehiculoView.FormClosed += (sender, args) =>
            {
                barButtonItemRecargarMantenimiento.Visibility = BarItemVisibility.Never;
            };
        }

        public void OnProductosClick(SplashScreenManager splash, RibbonPageGroup ribbonPageGroupOpcionesProductos)
        {
            ribbonPageGroupOpcionesProductos.Visible = true;
            var form = _navigation.Show<ProductosView>(splash);
            form.FormClosed += (sender, args) => { ribbonPageGroupOpcionesProductos.Visible = false; };
        }

        public void OnUnidadMedidaClick(SplashScreenManager splash)
        {
            _navigation.ShowDialog<UnidadMedidaView>(splash);
        }

        public void SetAlertControl(AlertControl alertControl)
        {
            _navigation.AlertControl = alertControl;
        }

        public void SetMainView(MainView mainView)
        {
            _navigation.SetMain(mainView);
        }

        public void OnCategoriaProductoClick(SplashScreenManager splash)
        {
            var form = _navigation.ShowDialog<CategoriaProductosView>(splash);
        }


        public void OnEditProductosClick(SplashScreenManager splash)
        {
            if (_selectionService.SelectedItem is not ProductoDto query)
            {
                return;
            }

            _navigation.ShowDialog<ProductosFormView>(splash, query);
        }


        public async void OnRecargarMantenimientoClick(SplashScreenManager? splashScreenManager)
        {
            try
            {
                splashScreenManager ??= new SplashScreenManager(_navigation.MainView, typeof(WaitForm1), true, true);
                splashScreenManager.ShowWaitForm();
                if (_mantenimientoVehiculoView is { IsDisposed: false })
                {
                    await _mantenimientoVehiculoView.InitAppointments();
                }

                splashScreenManager.CloseWaitForm();
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
            }
        }

        public void OnProveedoresClick(SplashScreenManager splash, RibbonPageGroup ribbonPageGroupOpcionesProductos)
        {
            ribbonPageGroupOpcionesProductos.Visible = true;
            var frm = _navigation.Show<ProveedoresView>(splash);
            frm.FormClosed += (sender, args) => { ribbonPageGroupOpcionesProductos.Visible = false; };
        }

        public async Task OnDeleteClick()
        {
            var selectedItem = _navigation.Query;
            switch (selectedItem)
            {
                case null:
                    return;
                case ProductoDto:
                    await ExecuteDeleteAsync<ProductosViewModel, ProductoDto>();
                    break;
                case ProveedoresDto:
                    await ExecuteDeleteAsync<ProveedoresViewModel, ProveedoresDto>();
                    break;
                case ComprasDto:
                    await ExecuteDeleteAsync<ComprasViewModel, ComprasDto>();
                    break;
                case MovCajasDto:
                    await ExecuteDeleteAsync<MovCajaViewModel, MovCajasDto>();
                    break;
            }
        }

        public void OnShowAddClick(SplashScreenManager splashScreenManager1)
        {
            var activeForm = _navigation.MainView.ActiveMdiChild;

            if (activeForm?.DataContext is not ICrudViewModel vm)
                return;

            vm.AddAsync();
        }

        public void OnEditClick(SplashScreenManager splashScreenManager1)
        {
            var activeForm = _navigation.MainView.ActiveMdiChild;

            if (activeForm?.DataContext is not ICrudViewModel vm)
                return;

            vm.EditAsync(_navigation.Query);
        }

        public Usuarios GetUsuario()
        {
            return _navigation.CurrentUser;
        }

        public void OnComrpasClick(SplashScreenManager splash, RibbonPageGroup ribbonPageGroupOpciones)
        {
            ribbonPageGroupOpciones.Visible = true;
            var frm = _navigation.Show<ComprasView>(splash);
            frm.FormClosed += (sender, args) => { ribbonPageGroupOpciones.Visible = false; };
        }

        public void OnMcajaClick(SplashScreenManager splash, RibbonPageGroup ribbonPageGroupOpciones)
        {
            _navigation.Show<MaestroCajaView>(splash: splash);
        }

        public void OnRecargarMcajaClick(SplashScreenManager splashScreenManager1)
        {
            var mca = _serviceProvider.GetRequiredService<MaestroCajaView>();
            mca.MaestroCajaView_Load(null, EventArgs.Empty);
        }

        public void AperturaCierreCaja(
            BarButtonItem barButtonItemCerrarCaja,
            BarButtonItem barButtonItemAperturarCaja,
            ToolStripLabel lblMaestroCaja)
        {
            try
            {
                var mcajaService = _serviceProvider.GetRequiredService<MaestroCajaService>();
                var apertura = mcajaService.CajaAperturada();
                if (apertura is null)
                {
                    barButtonItemCerrarCaja.Enabled = false;
                    barButtonItemAperturarCaja.Enabled = true;
                    lblMaestroCaja.Text = @"Caja Cerrada, Aperturar Para realizar Movimientos";
                }
                else if (apertura.Fecha.Date == DateTime.Today)
                {
                    barButtonItemAperturarCaja.Enabled = false;
                    barButtonItemCerrarCaja.Enabled = true;
                    lblMaestroCaja.Text = @"Caja Abierta";
                }
                else
                {
                    GetMessageAlert(
                        TypeAlert.Warning,
                        "Caja",
                        "La caja aperturada no corresponde al día de hoy",
                        _navigation.MainView);
                    barButtonItemCerrarCaja.Enabled = true;
                    barButtonItemAperturarCaja.Enabled = false;
                    lblMaestroCaja.Text = @"Caja aperturada no corresponde al día de hoy";
                }
            }
            catch (Exception e)
            {
                _logger.Error(e);
            }
        }

        public void OnAperturarCajaClick(SplashScreenManager splashScreenManager, BarButtonItem barButtonItemCerrarCaja,
            BarButtonItem barButtonItemAperturarCaja, ToolStripLabel lblMaestroCaja)
        {
            var aperturarCajaView = _navigation.ShowDialog<AperturaCajaView>(splashScreenManager: splashScreenManager);
            if (aperturarCajaView.DialogResult != DialogResult.OK) return;
            barButtonItemCerrarCaja.Enabled = true;
            barButtonItemAperturarCaja.Enabled = false;
            lblMaestroCaja.Text = @"Caja Aperturada";
        }

        public async void OnCerrarCajaClick(SplashScreenManager splashScreenManager,
            BarButtonItem barButtonItemCerrarCaja, BarButtonItem barButtonItemAperturarCaja)
        {
            try
            {
                var result = XtraMessageBox.Show("¿Seguro desea cerrar caja?", "Cerrar Caja", MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);
                if (result != DialogResult.Yes)
                {
                    return;
                }

                var mcajaService = _serviceProvider.GetService<MaestroCajaService>();
                if (mcajaService is null)
                {
                    return;
                }

                var cerrar = await mcajaService.CerrarCaja();
                if (cerrar)
                {
                    barButtonItemCerrarCaja.Enabled = false;
                    barButtonItemAperturarCaja.Enabled = true;
                    GetMessageAlert(TypeAlert.Success, "Cerrar Caja", "Caja cerrada de forma correcta",
                        _navigation.MainView);
                }
                else
                {
                    GetMessageAlert(TypeAlert.Error, "Cerrar Caja", "No fue posible cerrar la caja",
                        _navigation.MainView);
                }
            }
            catch (Exception e)
            {
                _logger.Error(e);
            }
        }

        public void OnMovCajaClick(SplashScreenManager splashScreenManager,
            RibbonPageGroup ribbonPageGroupOpcionesAdministrar)
        {
            ribbonPageGroupOpcionesAdministrar.Visible = true;
            var form = _navigation.Show<MovCajaView>(splash: splashScreenManager);
            form.FormClosed += (sender, args) => { ribbonPageGroupOpcionesAdministrar.Visible = false; };
        }

        public void RealizarMovimientoOnClick(SplashScreenManager splash)
        {
            _navigation.ShowDialog<RealizarMovimientoCajaFormView>(splashScreenManager: splash);
        }

        public void AsignarVehiculoCadeteOnClick(SplashScreenManager splash)
        {
            _navigation.ShowDialog<AsignarVehiculoFormView>(splashScreenManager: splash, query: _navigation.Query);
        }

        public void AsignacionesVehiculoOnClick(SplashScreenManager splashScreenManager)
        {
            _navigation.Show<AsignacionesVehiculoView>(splash: splashScreenManager);
        }

        public void ConfigurarCuotaCadeteOnClick(SplashScreenManager splashScreenManager)
        {
            _navigation.ShowDialog<ConfigurarCuotaFormView>(splashScreenManager: splashScreenManager,
                query: _navigation.Query);
        }

        public void RealizarPagoCadeteOnClick(SplashScreenManager splashScreenManager)
        {
            _navigation.ShowDialog<PagoCuotaCadeteFormView>(
                splashScreenManager: splashScreenManager,
                query: _navigation.Query);
        }

        public void InventarioOnClick(SplashScreenManager splashScreenManager)
        {
            _navigation.Show<MovimientoIventarioView>(splash: splashScreenManager);
        }

        public void ReportesCadetesOnClick(SplashScreenManager splashScreenManager)
        {
            _navigation.Show<ReportesCadetesView>(splash: splashScreenManager);
        }

        public void ReporteDiaCajaOnClick(SplashScreenManager splashScreenManager)
        {
            var vmMaestroCaja = _serviceProvider.GetRequiredService<MaestroCajaViewModel>();
            vmMaestroCaja.ReporteDiarioCaja();
        }

        public void AseguradorasOnClick(SplashScreenManager splashScreenManager,
            RibbonPageGroup ribbonPageGroupVehiculosOpciones)
        {
            ribbonPageGroupVehiculosOpciones.Visible = true;
            var view =_navigation.Show<AseguradorasFormView>(splash: splashScreenManager);
            view.FormClosed += (s, e) => { ribbonPageGroupVehiculosOpciones.Visible = false; };
        }

        public void ReportesMantenimientosOnClick(SplashScreenManager splashScreenManager)
        {
            _navigation.Show<ReporteMantenimientosView>(splashScreenManager);
        }

        public void SegurosVehicularesOnClick(SplashScreenManager splashScreenManager,
            RibbonPageGroup ribbonPageGroupVehiculosOpciones)
        {
            ribbonPageGroupVehiculosOpciones.Visible = true;
            var view = _navigation.Show<SegurosVehicularesView>(splash: splashScreenManager);
            view.FormClosed += (s, e) => { ribbonPageGroupVehiculosOpciones.Visible = false; };
        }

        public void PagosOnClick(SplashScreenManager splashScreenManager)
        {
            _navigation.Show<PagosFormView>(splash: splashScreenManager);
        }

        public void AsignacionesVehiculoDiariasOnClick(SplashScreenManager splashScreenManager)
        {
            _navigation.Show<AsignacionesVehiculoFechaView>(splashScreenManager);
        }

        public void CuotasDiariasOnClick(SplashScreenManager splashScreenManager)
        {
            _navigation.Show<CuotasDiariasView>(splashScreenManager);
        }

        public void ControlAusenciasCadetesOnClick(SplashScreenManager splashScreenManager)
        {
            _navigation.Show<ControlAusenciasCadetesView>(splash: splashScreenManager);
        }

        public void ReportesProductosInventariosOnClick(SplashScreenManager splashScreenManager)
        {
            _navigation.Show<ReportesProductosInventarioView>(splash: splashScreenManager);
        }
    }
}
