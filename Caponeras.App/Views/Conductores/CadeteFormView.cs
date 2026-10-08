using Caponeras.App.Dto;
using Caponeras.App.ViewModels.Conductores;
using Caponeras.App.Views.Layouts;
using System;
using System.Linq;
using Caponeras.App.Helpers;
using Caponeras.Data.Models;
using DevExpress.XtraEditors;
using NLog;

namespace Caponeras.App.Views.Conductores
{
    public partial class CadeteFormView : FormLayout
    {
        private readonly CadetesFormViewModel _viewModel;
        private ILogger _logger = LogManager.GetCurrentClassLogger();
        private int IdCadete = 0;

        public CadeteFormView(CadetesFormViewModel viewModel)
        {
            _viewModel = viewModel;
            InitializeComponent();
            txtNombre.Focus();
            btnAceptar.Click += BtnAceptar_Click;
        }

        private async void BtnAceptar_Click(object? sender, EventArgs e)
        {
            try
            {
                if (!ValidateForm())
                {
                    return;
                }

                var validateIdentificacion = await _viewModel.ValidarIdentificacion(txtIdentificacion.Text, IdCadete);
                if (validateIdentificacion)
                {
                    XtraMessageBox.Show(
                        "Ya existe otro cadete con esa identificación, intente nuevamente",
                        "Agregar Cadete",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning
                    );
                    return;
                }

                var estadoCadete = chkActivo.CheckState switch
                {
                    CheckState.Checked => EstadoCadete.ACTIVO,
                    CheckState.Unchecked or CheckState.Indeterminate =>
                        _viewModel.ConductorDto?.Estado == EstadoCadete.SUSPENDIDO
                            ? EstadoCadete.SUSPENDIDO
                            : EstadoCadete.INACTIVO,
                    _ => throw new ArgumentOutOfRangeException()
                };
                _viewModel.ConductorDto = new ConductoresDto
                {
                    Idconductor = IdCadete,
                    Nombre = txtNombre.Text,
                    Telefono = txtCelular.Text,
                    Identificacion = txtIdentificacion.Text,
                    Observaciones = txtObservaciones.Text,
                    Direccion = txtDireccion.Text,
                    Estado = estadoCadete
                };
                btnAceptar.Enabled = false;
                var result = await _viewModel.GuardarCadete();
                if (result > 0)
                {
                    ResultDialog = true;
                    Close();
                }
                else
                {
                    btnAceptar.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
            }
        }

        private bool ValidateForm()
        {
            var isValid = true;

            isValid &= HelperMethods.ValidateRequired(txtNombre, "No puede estar vacío", errorProvider);
            isValid &= HelperMethods.ValidateRequired(txtIdentificacion, "Debe indicar una identificación",
                errorProvider);

            return isValid;
        }

        private void CadeteFormView_Load(object sender, EventArgs e)
        {
            chkActivo.Checked = true;
            _viewModel.Load();
            txtNombre.Focus();
            var selected = _viewModel.ConductorDto;
            if (selected is null) return;
            if (selected.Idconductor == 0) return;
            IdCadete = selected.Idconductor;
            txtNombre.Text = selected.Nombre;
            txtIdentificacion.Text = selected.Identificacion;
            txtCelular.Text = selected.Telefono;
            txtObservaciones.Text = selected.Observaciones;
            txtDireccion.Text = selected.Direccion;
            chkActivo.Checked = selected.Estado switch
            {
                EstadoCadete.ACTIVO => true,
                EstadoCadete.INACTIVO or EstadoCadete.SUSPENDIDO => false,
                _ => chkActivo.Checked
            };
        }
    }
}
