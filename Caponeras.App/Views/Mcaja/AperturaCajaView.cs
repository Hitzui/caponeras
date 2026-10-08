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
using Caponeras.App.ViewModels.Mcaja;

namespace Caponeras.App.Views.Mcaja
{
    public partial class AperturaCajaView : XtraForm
    {
        private AperturaCajaViewModel _viewModel;
        public AperturaCajaView(AperturaCajaViewModel viewModel)
        {
            _viewModel = viewModel;
            DataContext =_viewModel;
            InitializeComponent();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private async void btnAperturar_Click(object sender, EventArgs e)
        {
            try
            {
                var aperturar = await _viewModel.AperturarCaja();
                DialogResult = aperturar ? DialogResult.OK : DialogResult.Cancel;
                Close();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
        }
    }
}