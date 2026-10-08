using DevExpress.XtraEditors;
using Caponeras.App.Dto;
using Caponeras.App.Services;
using Caponeras.App.ViewModels.Agencia;
using NLog;

namespace Caponeras.App.Views.Agencia
{
    public partial class AgenciaView : XtraForm
    {
        private readonly AgenciaViewModel _agenciaViewModel;
        private List<AgenciaDto> _agencias = new();
        readonly ILogger _logger = LogManager.GetCurrentClassLogger();

        public AgenciaView(AgenciaViewModel agenciaViewModel)
        {
            InitializeComponent();
            _agenciaViewModel = agenciaViewModel;
        }

        private void AgenciaView_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private async void LoadData()
        {
            try
            {
                _agencias = await _agenciaViewModel.GetAllTask();
                agenciaDtoBindingSource.DataSource = _agencias;
            }
            catch (Exception e)
            {
                _logger.Error(e, "Error an agencia view load data");
                await XtraMessageBox.ShowAsync($"No fue posible recuperar la lista de agencais. {e.Message}");
            }
        }
    }
}