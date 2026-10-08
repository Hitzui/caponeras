using Caponeras.App.Dto;
using Caponeras.App.Services;
using System.ComponentModel;
using Caponeras.App.Helpers;
using Caponeras.Data.Models;

namespace Caponeras.App.ViewModels.Mcaja;

public class RealizarMovimientoCajaViewModel : BaseViewModel
{
    private MaestroCajaService _maestroCajaService;
    private INavigationService _navigationService;
    public RealizarMovimientoCajaViewModel(MaestroCajaService maestroCajaService, INavigationService navigationService)
    {
        _maestroCajaService = maestroCajaService;
        _navigationService = navigationService;
    }

    public BindingList<MovCajasDto> MovCajasBindingList { get; } = [];

    public async Task LoadMovimientos()
    {
        var data= await _maestroCajaService.GetAllMovimientosCaja();
        MovCajasBindingList.Clear();
        foreach (var mov in data)
        {
            MovCajasBindingList.Add(mov);
        }
    }

    public async Task RealizarMovimiento(string concepto, int idMovcaja, decimal monto)
    {
        var deta = new DetaMovimientosDto
        {
            Fecha = DateTime.Now,
            Concepto = concepto,
            Idmovimiento = idMovcaja,
            ReferenciaTipo = ReferenciaMovimiento.MovimientoGeneral,
            ReferenciaId = idMovcaja,
            Efectivo = monto,
            Transferencia = 0,
            Tipocambio = 1,
        };
        var realizarMovimiento = await _maestroCajaService.RealizarMovimiento(deta);
        if (realizarMovimiento)
        {
            GetMessageAlert(TypeAlert.Success, "Movimiento Caja","Movimiento realizado con éxito.", _navigationService.MainView);
        }
        else
        {
            GetMessageAlert(TypeAlert.Error, "Error", $"Se produjo un error al ingresar el movimiento. {_maestroCajaService.ErrorMessage}", _navigationService.MainView);
        }
    }

    public async Task<bool> VerificarCajaAperturada()
    {
        var maestroCaja = await _maestroCajaService.GetMaestroCaja();
        return maestroCaja.Estado == EstadoCaja.Abierta;
    }
}