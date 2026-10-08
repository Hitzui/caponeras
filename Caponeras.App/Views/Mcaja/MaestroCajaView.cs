using Caponeras.App.ViewModels.Mcaja;
using System;
using System.Diagnostics;
using System.Linq;

namespace Caponeras.App.Views.Mcaja
{
    public partial class MaestroCajaView : DevExpress.XtraEditors.XtraForm
    {
        private MaestroCajaViewModel _viewModel;

        public MaestroCajaView(MaestroCajaViewModel viewModel)
        {
            _viewModel = viewModel;
            DataContext = _viewModel;
            InitializeComponent();
        }

        public async void MaestroCajaView_Load(object? sender, EventArgs e)
        {
            try
            {
                await _viewModel.LoadMaestroCaja();
                detaMovimientosDtoBindingSource.DataSource = _viewModel.DetaMovimientosBindingList;
                lblSaldoInicial.Text = _viewModel.MaestroCaja.SaldoInicial.ToString("N2");
                lblEntradas.Text = _viewModel.MaestroCaja.Entradas.ToString("N2");
                lblSalidas.Text = _viewModel.MaestroCaja.Salidas.ToString("N2");
                lblSaldoFinal.Text = _viewModel.MaestroCaja.SaldoFinal.ToString("N2");
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
        }
    }
}