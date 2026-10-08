using System;
using System.Diagnostics;
using System.Linq;
using Caponeras.App.Dto;
using Caponeras.App.ViewModels.Mcaja;

namespace Caponeras.App.Views.Mcaja
{
    public partial class MovCajaView : DevExpress.XtraEditors.XtraForm
    {
        private MovCajaViewModel _viewModel;

        public MovCajaView(MovCajaViewModel viewModel)
        {
            _viewModel = viewModel;
            DataContext = _viewModel;
            InitializeComponent();
        }

        private async void MovCajaView_Load(object sender, EventArgs e)
        {
            try
            {
                await _viewModel.LoadData();
                movCajasDtoBindingSource.DataSource = _viewModel.MovCajasBindingList;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
        }

        private void gridViewMovCaja_SelectionChanged(object sender, DevExpress.Data.SelectionChangedEventArgs e)
        {
            _viewModel.SelectedMovCaja = movCajasDtoBindingSource.Current as MovCajasDto;
        }
    }
}