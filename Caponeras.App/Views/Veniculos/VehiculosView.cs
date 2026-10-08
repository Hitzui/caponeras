using Caponeras.App.ViewModels.Vehiculo;
using NLog;
using System;
using System.Linq;
using Caponeras.App.Dto;
using DevExpress.XtraGrid.Views.Grid;

namespace Caponeras.App.Views.Veniculos
{
    public partial class VehiculosView : DevExpress.XtraEditors.XtraForm
    {
        private ILogger _logger = LogManager.GetCurrentClassLogger();

        private readonly VehiculosViewModel _viewModel;

        public VehiculosView(VehiculosViewModel viewModel)
        {
            InitializeComponent();
            _viewModel = viewModel;
        }

        private async void VehiculosView_Load(object sender, EventArgs e)
        {
            try
            {
                await _viewModel.LoadTask();
                vehiculosDtoBindingSource.DataSource = _viewModel.VehiculosBindingList;
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
            }
        }

        private void gridViewVehiculos_SelectionChanged(object sender, DevExpress.Data.SelectionChangedEventArgs e)
        {
            if (gridViewVehiculos.GetFocusedRow() is VehiculosDto vehiculoDto)
            {
                _viewModel.SelectedVehiculo(vehiculoDto);
            }
        }

        private void gridViewVehiculos_PopupMenuShowing(object sender,
            DevExpress.XtraGrid.Views.Grid.PopupMenuShowingEventArgs e)
        {
            if (e.MenuType == GridMenuType.Row)
            {
                e.ShowCustomMenu(popupMenu1);
            }
        }

        private void barButtonItemAdd_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            _viewModel.SelectedVehiculo(new VehiculosDto());
            _viewModel.ShowForm();
        }

        private void barButtonItemEdit_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (gridViewVehiculos.GetFocusedRow() is VehiculosDto vehiculoDto)
            {
                _viewModel.SelectedVehiculo(vehiculoDto);
            }

            _viewModel.ShowForm();
        }

        private void barButtonItemDelete_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
        }

        private void gridViewVehiculos_FocusedRowChanged(object sender,
            DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (gridViewVehiculos.GetRow(e.FocusedRowHandle) is VehiculosDto vehiculoDto)
            {
                _viewModel.SelectedVehiculo(vehiculoDto);
            }
        }
    }
}