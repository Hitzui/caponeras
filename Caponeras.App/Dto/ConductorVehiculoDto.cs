using System.ComponentModel;
using System.Runtime.CompilerServices;
using Caponeras.Data.Models;

namespace Caponeras.App.Dto;

public class ConductorVehiculoDto : INotifyPropertyChanged
{
    private int _idConductor;
    private string _nombre = string.Empty;
    private string _telefono = string.Empty;
    private string _identificacion = string.Empty;
    private EstadoCadete _estado;
    private string? _observaciones;
    private DateTime? _createdAt;
    private string? _direccion;
    private int? _idVehiculoConductor;
    private int? _idVehiculo;
    private string? _codigoVehiculo;
    private string? _placa;
    private DateTime? _fechaInicio;
    private DateTime? _fechaFin;
    private int? _idZona;
    private string? _zona;

    public int IdConductor
    {
        get => _idConductor;
        set => SetField(ref _idConductor, value);
    }

    public string Nombre
    {
        get => _nombre;
        set => SetField(ref _nombre, value);
    }

    public string Telefono
    {
        get => _telefono;
        set => SetField(ref _telefono, value);
    }

    public string Identificacion
    {
        get => _identificacion;
        set => SetField(ref _identificacion, value);
    }

    public EstadoCadete Estado
    {
        get => _estado;
        set => SetField(ref _estado, value);
    }

    public string? Observaciones
    {
        get => _observaciones;
        set => SetField(ref _observaciones, value);
    }

    public DateTime? CreatedAt
    {
        get => _createdAt;
        set => SetField(ref _createdAt, value);
    }

    public string? Direccion
    {
        get => _direccion;
        set => SetField(ref _direccion, value);
    }


    // Asignación actual

    public int? IdVehiculoConductor
    {
        get => _idVehiculoConductor;
        set => SetField(ref _idVehiculoConductor, value);
    }

    public int? IdVehiculo
    {
        get => _idVehiculo;
        set => SetField(ref _idVehiculo, value);
    }

    public string? CodigoVehiculo
    {
        get => _codigoVehiculo;
        set => SetField(ref _codigoVehiculo, value);
    }

    public string? Placa
    {
        get => _placa;
        set => SetField(ref _placa, value);
    }

    public DateTime? FechaInicio
    {
        get => _fechaInicio;
        set => SetField(ref _fechaInicio, value);
    }

    public DateTime? FechaFin
    {
        get => _fechaFin;
        set => SetField(ref _fechaFin, value);
    }

    public int? IdZona
    {
        get => _idZona;
        set => SetField(ref _idZona, value);
    }

    public string? Zona
    {
        get => _zona;
        set => SetField(ref _zona, value);
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