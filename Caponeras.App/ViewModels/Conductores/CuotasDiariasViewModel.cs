using System.ComponentModel;
using Caponeras.App.Dto;
using Caponeras.App.Helpers;
using Caponeras.App.Services;

namespace Caponeras.App.ViewModels.Conductores;

public sealed record ResultadoPagosCuota(int CantidadRegistrada, IReadOnlyList<string> Errores);

public sealed class CuotasDiariasViewModel
{
    private readonly CuotasDiariasService _service;
    private readonly ConductoresService _conductoresService;
    private readonly INavigationService _navigation;

    public CuotasDiariasViewModel(
        CuotasDiariasService service,
        ConductoresService conductoresService,
        INavigationService navigation)
    {
        _service = service;
        _conductoresService = conductoresService;
        _navigation = navigation;
    }

    public BindingList<CuotaDiariaGestionDto> Cuotas { get; private set; } = [];

    public async Task CargarAsync(DateTime fecha)
    {
        Cuotas = new BindingList<CuotaDiariaGestionDto>(
            await _service.ObtenerCuotasPorFechaAsync(fecha));
    }

    public async Task<ResultadoPagosCuota> RegistrarPagosAsync(DateTime fecha)
    {
        var fechaPago = fecha.Date;
        var filasParaPagar = Cuotas.Where(c => c.MontoPago > 0m).ToList();
        if (filasParaPagar.Count == 0)
            throw new InvalidOperationException("Ingrese el monto a pagar para al menos un cadete.");

        foreach (var fila in filasParaPagar)
        {
            if (fila.MontoCuota <= 0m)
                throw new InvalidOperationException($"{fila.Nombre} no tiene una cuota configurada.");
            if (fila.MontoPago > fila.Diferencia)
                throw new InvalidOperationException(
                    $"El pago de {fila.Nombre} ({fila.MontoPago:C}) supera su saldo pendiente ({fila.Diferencia:C}).");
        }

        var errores = new List<string>();
        var cantidadRegistrada = 0;
        var pagosPendientesPorConductor = new Dictionary<int, decimal>();
        foreach (var fila in filasParaPagar)
        {
            var guardado = await _conductoresService.RegistrarPagoCuotaDiaria(
                fila.IdConductor,
                fila.MontoPago,
                string.Empty,
                fechaPago,
                _navigation.CurrentUser);

            if (guardado)
            {
                cantidadRegistrada++;
                continue;
            }

            pagosPendientesPorConductor[fila.IdConductor] = fila.MontoPago;
            errores.Add($"{fila.Nombre}: {_conductoresService.ErrorMessage}");
        }

        await CargarAsync(fechaPago);
        foreach (var fila in Cuotas.Where(c => pagosPendientesPorConductor.ContainsKey(c.IdConductor)))
            fila.MontoPago = pagosPendientesPorConductor[fila.IdConductor];

        return new ResultadoPagosCuota(cantidadRegistrada, errores);
    }
}
