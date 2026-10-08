using Caponeras.App.Helpers;
using Caponeras.App.ViewModels.Inventario;
using Caponeras.App.Views.Reportes.Inventario;
using DevExpress.XtraEditors;

namespace Caponeras.App.Views.Inventario
{
    public partial class ReportesProductosInventarioView : DevExpress.XtraEditors.XtraForm
    {
        private readonly ReportesProductosInventarioViewModel _viewModel;

        public ReportesProductosInventarioView(ReportesProductosInventarioViewModel viewModel)
        {
            _viewModel = viewModel;
            InitializeComponent();
        }

        private void btnVerReporte_Click(object sender, EventArgs e)
        {
            var index = radioGroupOpciones.SelectedIndex;
            switch (index)
            {
                case 0:
                    var reporte = new ReporteProductos();
                    HelperMethods.LoadReport(reporte, "Reporte de productos");
                    break;
                default:
                    XtraMessageBox.Show("No se ha seleccionado una opción", "Reporte", MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                    break;
            }
        }
    }
}