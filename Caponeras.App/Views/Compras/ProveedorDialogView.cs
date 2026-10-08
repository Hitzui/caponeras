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
using Caponeras.App.Dto;
using Caponeras.App.ViewModels.Compras;
using Caponeras.App.Views.Layouts;

namespace Caponeras.App.Views.Compras
{
    public partial class ProveedorDialogView : FormLayout
    {
        private ProveedorDialogViewModel _viewModel;
        public ProveedoresDto? SelectedProveedor { get; private set; }

        public ProveedorDialogView(ProveedorDialogViewModel viewModel)
        {
            _viewModel = viewModel;
            DataContext = _viewModel;
            InitializeComponent();
        }

        private async void ProveedorDialogView_Load(object sender, EventArgs e)
        {
            try
            {
                await _viewModel.Load();
                proveedoresDtoBindingSource.DataSource = _viewModel.ProveedoresBindingList;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            SelectedProveedor = proveedoresDtoBindingSource.Current as ProveedoresDto;
            DialogResult = DialogResult.OK;
            Close();
        }
    }
}