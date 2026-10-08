using DevExpress.XtraEditors;
using Caponeras.App.ViewModels.Caja;

namespace Caponeras.App.Views.Caja
{
    public partial class CajaView : XtraForm
    {
        readonly CajaViewModel _viewModel;

        public CajaView(CajaViewModel viewModel)
        {
            _viewModel = viewModel;
            InitializeComponent();
        }

        private void CajaView_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private async void LoadData()
        {
            try
            {
                cajaDtoBindingSource.DataSource = await _viewModel.GetAll();
            }
            catch (Exception e)
            {
                await XtraMessageBox.ShowAsync($"No fue posible cargar los datos de caja. {e.Message}");
            }
        }
    }
}