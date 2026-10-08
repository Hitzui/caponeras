using Caponeras.App.Dto;
using Caponeras.App.Helpers;
using Caponeras.App.Services;
using DevExpress.Mvvm;
using INavigationService = Caponeras.App.Helpers.INavigationService;

namespace Caponeras.App.ViewModels.Compras;

public class PaymentCompraViewModel : BaseViewModel
{
    private ComprasService _comprasService;
    private INavigationService _navigationService;

    private ComprasDto? _comprasDto;

    public ComprasDto? ComprasDto
    {
        get => _comprasDto;
        set => SetValue(ref _comprasDto, value, OnChangedCompras);
    }

    private void OnChangedCompras()
    {
        TransactionCxpsDto = _comprasService.FindTransactionCxpsByCompra(ComprasDto?.Idcompra ?? 0);
    }

    private TransactionCxpsDto? _transactionCxpsDto;

    public TransactionCxpsDto? TransactionCxpsDto
    {
        get => _transactionCxpsDto;
        set => SetValue(ref _transactionCxpsDto, value);
    }

    public PaymentCompraViewModel(ComprasService comprasService, INavigationService navigationService)
    {
        _comprasService = comprasService;
        _navigationService = navigationService;
    }

    public void LoadCompra()
    {
        ComprasDto = _navigationService.Query as ComprasDto;
    }

    public async Task<bool> ProcesarPagoCompra(decimal? monto)
    {
        try
        {
            if (TransactionCxpsDto is null)
            {
                GetMessageAlert(TypeAlert.Warning, "Pagar compra", "No se encontró la cuenta por pagar.", _navigationService.MainView);
                return false;
            }

            if (ComprasDto is null)
            {
                GetMessageAlert(TypeAlert.Warning, "Pagar compra", "No se encontró la compra.", _navigationService.MainView);
                return false;
            }

            if (monto is null or <= 0)
            {
                GetMessageAlert(TypeAlert.Warning, "Pagar compra", "Ingrese un monto mayor a cero.", _navigationService.MainView);
                return false;
            }

            if (TransactionCxpsDto.SaldoPendiente < monto.Value)
            {
                GetMessageAlert(TypeAlert.Warning, "Pagar compra",
                    "El Saldo pendiente de la compra es menor al monto por pagar", _navigationService.MainView);
                return false;
            }

            var result = await _comprasService.ProcesarPagoCompra(ComprasDto, TransactionCxpsDto, monto.Value);
            if (result)
            {
                GetMessageAlert(TypeAlert.Success, "Pago procesado",
                    "El pago de la compra se ha procesado correctamente", _navigationService.MainView);
                Messenger.Default.Send(new ComprasFormViewModel.CompraGuardadaMessage());
                return true;
            }
            else
            {
                GetMessageAlert(TypeAlert.Error, "Error", _comprasService.ErrorMessage, _navigationService.MainView);
                return false;
            }
        }
        catch (Exception e)
        {
            GetMessageAlert(TypeAlert.Error, "Error", $"Se produjo el siguiente error: {e.GetBaseException().Message}",
                _navigationService.MainView);
            return false;
        }
    }
}
