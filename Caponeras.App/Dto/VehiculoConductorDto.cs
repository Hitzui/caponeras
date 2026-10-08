using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Caponeras.App.Dto;

public class VehiculoConductorDto : INotifyPropertyChanged
{
    public VehiculoConductorDto()
    {
    }

    public VehiculoConductorDto(
        DateTime fechaFin, 
        int idvehiculoConductor,
        int idVehiculo, 
        int idConductor,
        string codigo, 
        string placa, 
        string conductor, 
        string identificacion, 
        DateTime fechaInicio, 
        ZonasDto? zonas)
    {
        _fechaFin = fechaFin;
        _idvehiculoConductor = idvehiculoConductor;
        _idVehiculo = idVehiculo;
        _idConductor = idConductor;
        _codigo = codigo;
        _placa = placa;
        _conductor = conductor;
        _identificacion = identificacion;
        _fechaInicio = fechaInicio;
        _zonas = zonas;
    }

    public int IdvehiculoConductor
    {
        get => _idvehiculoConductor;
        set => SetField(ref _idvehiculoConductor, value);
    }

    public int IdVehiculo
    {
        get => _idVehiculo;
        set => SetField(ref _idVehiculo, value);
    }

    public int IdConductor
    {
        get => _idConductor;
        set => SetField(ref _idConductor, value);
    }

    public string Codigo
    {
        get => _codigo;
        set => SetField(ref _codigo, value);
    }

    public string Placa
    {
        get => _placa;
        set => SetField(ref _placa, value);
    }

    public string Conductor
    {
        get => _conductor;
        set => SetField(ref _conductor, value);
    }

    public string Identificacion
    {
        get => _identificacion;
        set => SetField(ref _identificacion, value);
    }

    public DateTime FechaInicio
    {
        get => _fechaInicio;
        set => SetField(ref _fechaInicio, value);
    }

    public DateTime FechaFin
    {
        get => _fechaFin.AddDays(1);
        set => SetField(ref _fechaFin, value);
    }

    private DateTime _fechaFin;
    private int _idvehiculoConductor;
    private int _idVehiculo;
    private int _idConductor;
    private string _codigo = string.Empty;
    private string _placa = string.Empty;
    private string _conductor = string.Empty;
    private string _identificacion = string.Empty;
    private DateTime _fechaInicio;
    private ZonasDto? _zonas;

    private bool _allDay = true;

    public bool AllDay
    {
        get => _allDay;
        set => SetField(ref _allDay, value);
    }

    public ZonasDto? Zonas
    {
        get => _zonas;
        set => SetField(ref _zonas, value);
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    protected bool SetField<T>(ref T field, T value, [CallerMemberName] string? propertyName = null)
    {
        if (EqualityComparer<T>.Default.Equals(field, value)) return false;
        field = value;
        OnPropertyChanged(propertyName);
        return true;
    }
}