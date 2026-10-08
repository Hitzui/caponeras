using Caponeras.App.Dto;
using Caponeras.App.Helpers;
using Caponeras.App.Services;
using NLog.Filters;
using System.ComponentModel;

namespace Caponeras.App.ViewModels.Conductores;

public class AsignacionesVehiculoFechaViewModel : BaseViewModel
{
    private readonly ConductorVehiculoService _conductorVehiculoService;
    private readonly INavigationService _navigationService;

    public AsignacionesVehiculoFechaViewModel(ConductorVehiculoService conductorVehiculoService,
        INavigationService navigationService)
    {
        _conductorVehiculoService = conductorVehiculoService;
        _navigationService = navigationService;
    }

    public BindingList<ConductorVehiculoDto> ConductorVehiculoBindingList { get; private set; } = [];
    public BindingList<VehiculosDto> VehiculosBindingList { get; private set; } = [];
    public BindingList<ZonasDto> ZonasBindingList { get; private set; } = [];

    public async Task LoadList(DateTime fecha)
    {
        var data = await _conductorVehiculoService.GetConductoresVehiculosAsync(fecha);
        ConductorVehiculoBindingList = new BindingList<ConductorVehiculoDto>(data);
    }

    public async Task LoadVehiculos()
    {
        var data = await _conductorVehiculoService.GetVehiculosAsync(null);
        VehiculosBindingList = new BindingList<VehiculosDto>(data);
    }

    public async Task LoadZonas()
    {
        var data = await _conductorVehiculoService.GetZonasASync();
        ZonasBindingList = new BindingList<ZonasDto>(data);
    }

    public async Task AsignarVehiculosPorDiaAsync(
        DateTime fecha,
        List<ConductorVehiculoDto> filas)
    {
        if (!ValidarVehiculosDuplicados(filas))
            return;

        var result = await _conductorVehiculoService
            .AsignarVehiculosPorDiaAsync(fecha, filas);

        if (result.Exitoso)
        {
            GetMessageAlert(
                TypeAlert.Success,
                "Guardar",
                "Se han guardado las asignaciones de forma correcta.",
                _navigationService.MainView);
            await LoadList(fecha);
            return;
        }

        if (result.Conflictos.Count > 0)
        {
            var mensaje = string.Join(
                Environment.NewLine,
                result.Conflictos.Select(x => $"• {x}"));

            GetMessageAlert(
                TypeAlert.Warning,
                "Conflictos de asignación",
                mensaje,
                _navigationService.MainView);

            return;
        }

        GetMessageAlert(
            TypeAlert.Error,
            "Error",
            $"Ocurrió un error al guardar las asignaciones: {_conductorVehiculoService.ErrorSms}",
            _navigationService.MainView);
    }

    public bool ValidarVehiculosDuplicados(List<ConductorVehiculoDto> filas)
    {
        var duplicados = filas
            .GroupBy(x => x.IdVehiculo!.Value)
            .Where(g => g.Count() > 1)
            .ToList();

        if (duplicados.Count == 0)
            return true;

        var mensajes = duplicados.Select(g =>
        {
            var placa = g.First().Placa;

            var conductores = string.Join(
                ", ",
                g.Select(x => x.Nombre));

            return $"El vehículo {placa} está asignado a " +
                   $"más de un conductor: {conductores}.";
        });
        var mensajeFinal = string.Join(Environment.NewLine, mensajes);
        GetMessageAlert(TypeAlert.Warning, "Guardar", $"{mensajeFinal}", _navigationService.MainView);
        return false;
    }

    public async Task QuitarAsignacionVehiculoPorDiaAsync(DateTime fecha,ConductorVehiculoDto fila)
    {
        if (fila.IdVehiculo is null or <= 0)
            return;

        if (fila.IdZona is null or <= 0)
            return;

        var delete = await _conductorVehiculoService.QuitarAsignacionVehiculoPorDia(fecha,fila);
        if (delete)
        {
            GetMessageAlert(
                TypeAlert.Success, 
                "Quitar", 
                "Se ha eliminado la asignacion de vehiculo al conductor",
                _navigationService.MainView);
        }
        else
        {
            GetMessageAlert(
                TypeAlert.Error, "Error", 
                $"No fue posible quitar la asignación. {_conductorVehiculoService.ErrorSms}",
                _navigationService.MainView);
        }
    }
}