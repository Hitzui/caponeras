using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Caponeras.App.ViewModels.Conductores;

namespace Caponeras.App.Views.Conductores
{
    public partial class PagosFormView : DevExpress.XtraEditors.XtraForm
    {
        private PagoFormViewModel _viewModel;
        public PagosFormView(PagoFormViewModel viewModel)
        {
            _viewModel = viewModel;
            InitializeComponent();
        }

        private void PagosFormView_Load(object sender, EventArgs e)
        {
            DataContext = _viewModel;
            txtFecha.DateTime = DateTime.Now;
        }

        private async void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                await _viewModel.GetAll(txtFecha.DateTime);
                cuotaDetalleBindingSource.DataSource = _viewModel.ListaCuotasBindingList;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
        }
    }
}