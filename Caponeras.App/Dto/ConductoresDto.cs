using System.ComponentModel;
using System.Runtime.CompilerServices;
using Caponeras.Data.Models;

namespace Caponeras.App.Dto;

public class ConductoresDto : INotifyPropertyChanged
{
    private int _idconductor;
    private string _nombre;
    private string _telefono;
    private string _identificacion;
    private EstadoCadete _estado;
    private string _observaciones;
    private VehiculosDto? _vehiculosDto;
    private CuotaConfiguracions? _cuotaConfiguracions;
    private string _direccion;

    public ConductoresDto(Conductors? conductors)
    {
        if (conductors is null) return;
        _identificacion = conductors.Identificacion;
        _telefono = conductors.Telefono;
        _nombre = conductors.Nombre;
        _observaciones = conductors.Observaciones;
        _idconductor = conductors.Idconductor;
        _estado = conductors.Estado;
        _direccion = string.Empty;
    }

    public ConductoresDto(Conductors conductors, CuotaConfiguracions cuota)
    {
        _identificacion = conductors.Identificacion;
        _telefono = conductors.Telefono;
        _nombre = conductors.Nombre;
        _observaciones = conductors.Observaciones;
        _idconductor = conductors.Idconductor;
        _estado = conductors.Estado;
        _cuotaConfiguracions = cuota;
        _direccion = conductors.Direccion;
    }

    public ConductoresDto(Conductors conductors, CuotaConfiguracions cuota, VehiculosDto? vehiculosDto = null)
    {
        _identificacion = conductors.Identificacion;
        _telefono = conductors.Telefono;
        _nombre = conductors.Nombre;
        _observaciones = conductors.Observaciones;
        _idconductor = conductors.Idconductor;
        _estado = conductors.Estado;
        _cuotaConfiguracions = cuota;
        _direccion = conductors.Direccion;
        if (vehiculosDto != null)
        {
            _vehiculosDto = vehiculosDto;
        }
    }

    public ConductoresDto()
    {
        _idconductor = 0;
        _identificacion = string.Empty;
        _estado = EstadoCadete.ACTIVO;
        _telefono = string.Empty;
        _nombre = string.Empty;
        _observaciones = string.Empty;
        _direccion = string.Empty;
    }

    public string Direccion
    {
        get => _direccion;
        set => SetField(ref _direccion, value);
    }

    public CuotaConfiguracions? CuotaConfiguracions
    {
        get => _cuotaConfiguracions;
        set => SetField(ref _cuotaConfiguracions, value);
    }

    public VehiculosDto? VehiculosDto
    {
        get => _vehiculosDto;
        set => SetField(ref _vehiculosDto, value);
    }

    public int Idconductor
    {
        get => _idconductor;
        set { SetField(ref _idconductor, value); }
    }

    public string Nombre
    {
        get => _nombre;
        set { SetField(ref _nombre, value); }
    }

    public string Telefono
    {
        get => _telefono;
        set { SetField(ref _telefono, value); }
    }

    public string Identificacion
    {
        get => _identificacion;
        set { SetField(ref _identificacion, value); }
    }

    public EstadoCadete Estado
    {
        get => _estado;
        set { SetField(ref _estado, value); }
    }

    public string Observaciones
    {
        get => _observaciones;
        set { SetField(ref _observaciones, value); }
    }

    public Conductors Conductors()
    {
        return new Conductors()
        {
            Identificacion = Identificacion,
            Estado = Estado,
            Telefono = Telefono,
            Nombre = Nombre,
            Observaciones = Observaciones,
            Direccion = Direccion,
            Idconductor = Idconductor
        };
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