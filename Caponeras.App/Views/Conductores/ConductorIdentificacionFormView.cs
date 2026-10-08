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
using Caponeras.App.ViewModels.Conductores;

namespace Caponeras.App.Views.Conductores
{
    public partial class ConductorIdentificacionFormView : DevExpress.XtraEditors.XtraForm
    {
        private ConductorIdentificacionFormViewModel _viewModel;
        private ConductoresDto _cadete;

        public ConductorIdentificacionFormView(ConductorIdentificacionFormViewModel viewModel)
        {
            _cadete = new();
            _viewModel = viewModel;
            DataContext = _viewModel;
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private async void ConductorIdentificacionFormView_Load(object sender, EventArgs e)
        {
            try
            {
                await _viewModel.Load();
                if (_viewModel.ConductorDto is not null)
                {
                    _cadete = _viewModel.ConductorDto;
                    txtNombreCompleto.Text = _cadete.Nombre;
                    txtIdentificacion.Text = _cadete.Identificacion;
                }

                if (_viewModel.ConductorIdentificacionsDto is null) return;
                var identificacion = _viewModel.ConductorIdentificacionsDto;
                txtIdentificacion.Text = identificacion.NumeroIdentificacion;
                txtObservaciones.Text = identificacion.Observaciones;
                txtDireccionDomiciliar.Text = identificacion.DireccionDomiciliar;
                txtMunicipioResidencia.Text = identificacion.MunicipioResidencia;
                txtFechaEmision.DateTime = identificacion.FechaEmision!.Value;
                txtFechaVencimiento.DateTime = identificacion.FechaVencimiento!.Value;
                picIdentificacionFrente.Image = await _viewModel.CargarImagenAsync(identificacion.FotoFrente);
                picIdentificacionTrasera.Image = await _viewModel.CargarImagenAsync(identificacion.FotoReverso);
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
                var identificacion = new ConductorIdentificacionsDto
                {
                    Ididentificacion = _viewModel.ConductorIdentificacionsDto?.Ididentificacion ?? 0,
                    Idconductor = _cadete.Idconductor,
                    NumeroIdentificacion = txtIdentificacion.Text,
                    Observaciones = txtObservaciones.Text,
                    DireccionDomiciliar = txtDireccionDomiciliar.Text,
                    MunicipioResidencia = txtMunicipioResidencia.Text,
                    FechaEmision = txtFechaEmision.DateTime,
                    FechaVencimiento = txtFechaVencimiento.DateTime
                };
                _viewModel.ConductorIdentificacionsDto = identificacion;
                await _viewModel.SaveIdentificacion(picIdentificacionFrente.Image, picIdentificacionTrasera.Image);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
        }
    }
}