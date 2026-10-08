using Caponeras.App.ViewModels.Conductores;
using System;
using System.Diagnostics;
using System.Linq;
using Caponeras.App.Dto;

namespace Caponeras.App.Views.Conductores
{
    public partial class ConductorLicenciaFormView : DevExpress.XtraEditors.XtraForm
    {
        private ConductorLicenciaFormViewModel _viewModel;
        private ConductorLicenciasDto _licenciaCadete;

        public ConductorLicenciaFormView(ConductorLicenciaFormViewModel viewModel)
        {
            _viewModel = viewModel;
            DataContext = _viewModel;
            InitializeComponent();
        }

        private async void ConductorLicenciaForm_Load(object sender, EventArgs e)
        {
            try
            {
                cmbCategoriaLicencia.Properties.Items.Clear();
                cmbCategoriaLicencia.Properties.Items.AddRange(ConductorLicenciasDto.Categorias);
                _viewModel.LoadCadete();
                if (_viewModel.ConductorDto is null) return;
                var cadete = _viewModel.ConductorDto;
                txtNombreCompleto.Text = cadete.Nombre;
                txtIdentificacion.Text = cadete.Identificacion;
                _licenciaCadete = _viewModel.ConductorLicenciaDto ?? new();
                _licenciaCadete.Idconductor = cadete.Idconductor;
                if (_licenciaCadete.Idlicencia > 0)
                {
                    txtNumeroLicencia.Text = _licenciaCadete.NumeroLicencia;
                    cmbCategoriaLicencia.EditValue = _licenciaCadete.Categoria;
                    txtFechaEmision.DateTime = _licenciaCadete.FechaEmision!.Value;
                    txtFechaVencimiento.DateTime = _licenciaCadete.FechaVencimiento;
                    txtObservaciones.Text = _licenciaCadete.Observaciones;

                    picLicenciaFrente.Image =
                        await _viewModel.CargarImagenAsync(_licenciaCadete.FotoLicenciaFrente);
                    //devexpress trae un loadasync, pero solo para 4mb de tamaño, por eso se hace de esta manera
                    //await picLicenciaFrente.LoadAsync(_licenciaCadete.FotoLicenciaFrente);
                    picLicenciaTrasera.Image =
                        await _viewModel.CargarImagenAsync(_licenciaCadete.FotoLicenciaReverso);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                btnSave.Enabled = false;
                var licencia = new ConductorLicenciasDto
                {
                    Idlicencia = _licenciaCadete.Idlicencia,
                    Idconductor = _licenciaCadete.Idconductor,
                    NumeroLicencia = txtNumeroLicencia.Text,
                    Categoria = cmbCategoriaLicencia.Text,
                    FechaEmision = txtFechaEmision.DateTime,
                    FechaVencimiento = txtFechaVencimiento.DateTime,
                    Observaciones = txtObservaciones.Text,
                };
                await _viewModel.SaveLicencia(licencia, picLicenciaFrente.Image, picLicenciaTrasera.Image);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}