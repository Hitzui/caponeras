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
using Caponeras.App.ViewModels.Mcaja;
using Caponeras.App.Views.Layouts;

namespace Caponeras.App.Views.Mcaja
{
    public partial class MovCajaFormView : FormLayout
    {
        private MovCajaViewModel _viewModel;
        private MovCajasDto? _movCajasDto;
        public MovCajaFormView(MovCajaViewModel viewModel)
        {
            _viewModel = viewModel;
            DataContext = _viewModel;
            InitializeComponent();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private async void MoCajaFormView_Load(object sender, EventArgs e)
        {
            await _viewModel.LoadRubrosTask();
            rubrosDtoBindingSource.DataSource = _viewModel.RubrosBindingList;
            _viewModel.GetSelectedMovCaja();
            _movCajasDto = _viewModel.SelectedMovCaja;
            if (_movCajasDto is null) return;
            txtDescripcion.Text = _movCajasDto.Descripcion;
            if (_movCajasDto.Rubros is null)
            {
                return;
            }
            cmbRubro.EditValue = _movCajasDto.Rubros.Idrubro;
        }

        private async void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtDescripcion.Text))
                {
                    txtDescripcion.ErrorText = "No puede indicar un movimiento sin descripción";
                    return;
                }

            
                if (cmbRubro.EditValue is null || cmbRubro.GetSelectedDataRow() is not RubrosDto rubro)
                {
                    cmbRubro.ErrorText = "Seleccione el rubro del movimiento";
                    return;
                }

                var movCaja = new MovCajasDto
                {
                    Descripcion = txtDescripcion.Text,
                    Idrubro = rubro.Idrubro,
                    Rubros = rubro
                };
                if (_movCajasDto is not null) movCaja.Idmovcaja = _movCajasDto.Idmovcaja;

                await _viewModel.SaveAsync(movCaja);
                if (_viewModel.Success)
                {
                    Close();
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
        }
    }
}