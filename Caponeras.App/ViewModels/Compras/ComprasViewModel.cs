using Caponeras.App.Dto;
using Caponeras.App.Helpers;
using Caponeras.App.Services;
using Caponeras.App.Views.Compras;
using DevExpress.Mvvm;
using NLog;
using System.ComponentModel;
using INavigationService = Caponeras.App.Helpers.INavigationService;

namespace Caponeras.App.ViewModels.Compras;

public class ComprasViewModel : BaseViewModel, ICrudViewModel
{
    private INavigationService _navigationService;
    private readonly ILogger _logger = LogManager.GetCurrentClassLogger();
    private ComprasService _comprasService;

    public BindingList<ComprasDto> ComprasBindingList { get; } = new();

    public ComprasViewModel(ComprasService comprasService, INavigationService navigationService)
    {
        _comprasService = comprasService;
        _navigationService = navigationService;
        Messenger.Default.Register<ComprasFormViewModel.CompraGuardadaMessage>(
            this,
            async void (_) =>
            {
                try
                {
                    await Load();
                }
                catch (Exception e)
                {
                    _logger.Error(e);
                }
            }
        );
    }

    public async Task Load()
    {
        var data = await _comprasService.Load();
        ComprasBindingList.Clear();
        foreach (var item in data)
        {
            ComprasBindingList.Add(item);
        }
    }

    public async Task DeleteAsync<TDto>(TDto? dto)
    {
        if (dto is not ComprasDto compraDto)
        {
            return;
        }

        var delete = await _comprasService.Delete(compraDto.Idcompra);
        if (delete)
        {
            ComprasBindingList.Remove(compraDto);
            Messenger.Default.Send(new ComprasFormViewModel.CompraGuardadaMessage());
            GetMessageAlert(TypeAlert.Success, "Eliminar", "La compra se anuló y, si estaba aprobada, se revirtió su inventario.",
                _navigationService.MainView);
        }
        else
        {
            GetMessageAlert(TypeAlert.Error, "Error",
                string.IsNullOrWhiteSpace(_comprasService.ErrorMessage)
                    ? "No fue posible eliminar o revertir la compra."
                    : _comprasService.ErrorMessage,
                _navigationService.MainView);
        }
    }

    public Task SaveAsync<TDto>(TDto? dto)
    {
        throw new NotImplementedException();
    }

    public void EditAsync<TDto>(TDto? dto)
    {
        _navigationService.ShowDialog<ComprasFormView>();
    }

    public void AddAsync()
    {
        _navigationService.Query = null;
        _navigationService.ShowDialog<ComprasFormView>();
    }

    public void SelectedCompra(ComprasDto current)
    {
        _navigationService.Query = current;
    }

    public void ProcessPaymentAsync(ComprasDto? comprasDto)
    {
        _navigationService.ShowDialog<PaymentCompraView>(query: comprasDto);
    }
}
