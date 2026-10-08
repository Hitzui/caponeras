using Caponeras.App.ViewModels.Conductores;
using Caponeras.App.Views.Layouts;
using System.Diagnostics;
using Caponeras.App.Helpers;
using DevExpress.XtraEditors;

namespace Caponeras.App.Views.Conductores;

public partial class ConfigurarCuotaFormView : FormLayout
{
    private ConfigurarCuotaFormViewModel _viewModel;

    public ConfigurarCuotaFormView(ConfigurarCuotaFormViewModel viewModel)
    {
        _viewModel = viewModel;
        InitializeComponent();
        DataContext = viewModel;
    }

    private void btnCancelar_Click(object sender, EventArgs e)
    {
        Close();
    }

    private async void btnAceptar_Click(object sender, EventArgs e)
    {
        try
        {
            if (string.IsNullOrEmpty(txtCuota.Text))
            {
                txtCuota.ErrorText = "La cuota es requerida.";
                return;
            }

            var cuota = HelperMethods.ToDecimal(txtCuota.Text);
            await _viewModel.ConfigurarCuota(cuota, txtObservaciones.Text);
            btnAceptar.Enabled = false;
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex);
        }
    }

    private async void ConfigurarCuotaFormView_Load(object sender, EventArgs e)
    {
        try
        {
            txtObservaciones.Focus();
            await _viewModel.LoadCadete();
            var cadete = _viewModel.ConductoresDto;
            if (cadete == null)
            {
                btnAceptar.Enabled = false;
                return;
            }
            txtNombreCadete.Text = cadete.Nombre;
            txtIdentificacion.Text = cadete.Identificacion;
            if (cadete.CuotaConfiguracions is null) return;

            txtObservaciones.Text = cadete.CuotaConfiguracions.Observaciones;
            txtCuota.EditValue = cadete.CuotaConfiguracions.MontoDiario;
        }
        catch (Exception ex)
        {
            await XtraMessageBox.ShowAsync(ex.Message);
        }
    }
}