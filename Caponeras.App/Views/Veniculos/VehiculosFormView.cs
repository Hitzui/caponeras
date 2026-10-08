using Caponeras.App.Dto;
using Caponeras.App.Helpers;
using Caponeras.App.ViewModels.Vehiculo;
using Caponeras.App.Views.Layouts;
using System;
using System.Linq;

namespace Caponeras.App.Views.Veniculos
{
    public partial class VehiculosFormView : FormLayout
    {
        private readonly VehiculoFormViewModel _viewModel;
        private int idvehiculo = 0;
        public VehiculosFormView(VehiculoFormViewModel vehiculoFormViewModel)
        {
            _viewModel = vehiculoFormViewModel;
            InitializeComponent();
            btnAceptar.Click += BtnAceptar_Click;
        }

        private async void BtnAceptar_Click(object? sender, EventArgs e)
        {
            if (!ValiedateForm())
            {
                return;
            }

            var vehiculoDto = new VehiculosDto
            {
                Idvehiculo = idvehiculo,
                Codigo = txtCodigo.Text,
                Placa = txtPlaca.Text,
                Descripcion = txtDescripcion.Text,
                Tipo = txtTipo.Text,
                Marca = txtMarca.Text,
                Modelo = txtModelo.Text,
                Anio = Convert.ToInt32(txtAnio.Text),
                KmActual = 0,
                Observaciones = txtObservaciones.Text
            };
            _viewModel.VehiculosDto = vehiculoDto;
            await _viewModel.GuardarVehiculo();
            DialogResult = DialogResult.OK;
            Close();
        }

        private bool ValiedateForm()
        {
            var isValid = true;

            isValid &= HelperMethods.ValidateRequired(txtCodigo, "No puede estar vacío", errorProvider);
            isValid &= HelperMethods.ValidateRequired(txtMarca, "Debe indicar una marca de vehiculo", errorProvider);
            isValid &= HelperMethods.ValidateRequired(txtPlaca, "Debe indicar la placa del vehiculo", errorProvider);
            isValid &= HelperMethods.ValidateRequired(txtModelo, "Debe indicar el modelo del vehiculo", errorProvider);

            return isValid;
        }

        private void VehiculosFormView_Load(object sender, EventArgs e)
        {
            txtCodigo.Focus();
            _viewModel.Load();
            if (_viewModel.VehiculosDto is null) return;
            var selected = _viewModel.VehiculosDto;
            if (selected.Idvehiculo == 0) return;
            idvehiculo = selected.Idvehiculo;
            txtAnio.EditValue = selected.Anio;
            txtCodigo.EditValue = selected.Codigo;
            txtDescripcion.EditValue = selected.Descripcion;
            txtMarca.EditValue = selected.Marca;
            txtModelo.EditValue = selected.Modelo;
            txtObservaciones.EditValue = selected.Observaciones;
            txtPlaca.EditValue = selected.Placa;
            txtTipo.EditValue = selected.Tipo;
        }
    }
}