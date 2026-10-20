using Caponeras.App.Dto;
using Caponeras.App.ViewModels.Conductores;
using DevExpress.XtraEditors;

namespace Caponeras.App.Views.Conductores;

public partial class CuotasDiariasView : XtraForm
{
    private readonly CuotasDiariasViewModel _viewModel;

    public CuotasDiariasView(CuotasDiariasViewModel viewModel)
    {
        _viewModel = viewModel;
        InitializeComponent();
        _filtrar.Click += async (_, _) => await CargarAsync();
        _registrarPagos.Click += async (_, _) => await RegistrarPagosAsync();
        Load += async (_, _) => await CargarAsync();
    }

    private async Task CargarAsync()
    {
        try
        {
            _filtrar.Enabled = false;
            await _viewModel.CargarAsync(_fecha.DateTime);
            _source.DataSource = _viewModel.Cuotas;
            _grid.RefreshDataSource();
        }
        catch (Exception ex)
        {
            XtraMessageBox.Show(this, $"No se pudieron cargar las cuotas. {ex.Message}", "Error");
        }
        finally
        {
            _filtrar.Enabled = true;
        }
    }

    private async Task RegistrarPagosAsync()
    {
        _gridView.CloseEditor();
        _gridView.UpdateCurrentRow();
        var pagos = _viewModel.Cuotas.Where(c => c.MontoPago > 0m).ToList();
        if (pagos.Count == 0)
        {
            XtraMessageBox.Show(this, "Ingrese el monto a pagar en al menos un cadete.",
                "No hay pagos para registrar", MessageBoxButtons.OK, MessageBoxIcon.Information);
            return;
        }

        var total = pagos.Sum(c => c.MontoPago);
        var detalle = string.Join(Environment.NewLine,
            pagos.Take(8).Select(c => $"• {c.Nombre}: {c.MontoPago:C2}"));
        if (pagos.Count > 8)
            detalle += Environment.NewLine + $"… y {pagos.Count - 8} cadete(s) más.";

        var confirmacion = XtraMessageBox.Show(this,
            $"¿Confirma registrar los pagos del { _fecha.DateTime:dd/MM/yyyy}?" +
            Environment.NewLine + Environment.NewLine +
            $"Cadetes: {pagos.Count}" + Environment.NewLine +
            $"Total a registrar: {total:C2}" + Environment.NewLine + Environment.NewLine +
            detalle,
            "Confirmar pagos",
            MessageBoxButtons.YesNo,
            MessageBoxIcon.Question);
        if (confirmacion != DialogResult.Yes)
            return;

        try
        {
            _registrarPagos.Enabled = false;
            _filtrar.Enabled = false;

            var resultado = await _viewModel.RegistrarPagosAsync(_fecha.DateTime);
            var mensaje = $"Pagos registrados: {resultado.CantidadRegistrada}.";
            if (resultado.Errores.Count > 0)
                mensaje += Environment.NewLine + Environment.NewLine + string.Join(Environment.NewLine, resultado.Errores);

            XtraMessageBox.Show(this, mensaje,
                resultado.Errores.Count == 0 ? "Pagos de cuotas" : "Resultado parcial",
                MessageBoxButtons.OK,
                resultado.Errores.Count == 0 ? MessageBoxIcon.Information : MessageBoxIcon.Warning);

            _source.DataSource = _viewModel.Cuotas;
            _grid.RefreshDataSource();
        }
        catch (Exception ex)
        {
            XtraMessageBox.Show(this, ex.Message, "No se pudieron registrar los pagos");
        }
        finally
        {
            _registrarPagos.Enabled = true;
            _filtrar.Enabled = true;
        }
    }
}
