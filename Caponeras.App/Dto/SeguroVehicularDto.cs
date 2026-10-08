using System.ComponentModel;
using System.Runtime.CompilerServices;
using Caponeras.Data.Models;

namespace Caponeras.App.Dto;

public class SeguroVehicularDto : INotifyPropertyChanged
{
    private int _idseguro;
    private int _idvehiculo;
    private int _idaseguradora;
    private string _numeroPoliza;
    private string _numeroCertificado;
    private int _tipoSeguro;
    private DateTime _fechaInicio;
    private DateTime _fechaVencimiento;
    private decimal _primaAnual;
    private string _moneda;
    private decimal? _deducible;
    private string _archivoPoliza;
    private string _observaciones;
    private int? _estado;
    private DateTime? _createdAt;
    private DateTime? _updatedAt;
    private VehiculosDto? _vehiculos;
    private AseguradorasDto? _aseguradoras;
    private TipoSeguroDto? _tipoSeguros;
    private string _vehiculoDescripcion = string.Empty;
    private string _aseguradoraNombre = string.Empty;
    private string _tipoSeguroNombre = string.Empty;

    public SeguroVehicularDto()
    {
        _numeroPoliza = string.Empty;
        _numeroCertificado = string.Empty;

        _fechaInicio = DateTime.MinValue;
        _fechaVencimiento = DateTime.MinValue;
        _primaAnual = decimal.Zero;
        _moneda = string.Empty;
        _deducible = null;
        _archivoPoliza = string.Empty;
        _observaciones = string.Empty;
        _estado = 1;
    }

    public SeguroVehicularDto(SeguroVehiculars model)
    {
        _idseguro = model.Idseguro;
        _idvehiculo = model.Idvehiculo;
        _idaseguradora = model.Idaseguradora;
        _numeroPoliza = model.NumeroPoliza;
        _numeroCertificado = model.NumeroCertificado;
        _tipoSeguro = model.TipoSeguro;
        _fechaInicio = model.FechaInicio;
        _fechaVencimiento = model.FechaVencimiento;
        _primaAnual = model.PrimaAnual;
        _moneda = model.Moneda;
        _deducible = model.Deducible;
        _archivoPoliza = model.ArchivoPoliza;
        _observaciones = model.Observaciones;
        _estado = model.Estado;
        _createdAt = model.CreatedAt;
        _updatedAt = model.UpdatedAt;
        _vehiculos = new VehiculosDto(model.Vehiculos);
        _aseguradoras = new AseguradorasDto(model.Aseguradoras);
        _tipoSeguros = new TipoSeguroDto(model.TipoSeguros);
        _vehiculoDescripcion = $"{model.Vehiculos?.Codigo} · {model.Vehiculos?.Placa} · {model.Vehiculos?.Marca} {model.Vehiculos?.Modelo}";
        _aseguradoraNombre = model.Aseguradoras?.Nombre ?? string.Empty;
        _tipoSeguroNombre = model.TipoSeguros?.Nombre ?? string.Empty;
    }
    public int Idseguro
    {
        get => _idseguro;
        set => SetField(ref _idseguro, value);
    }

    public int Idvehiculo
    {
        get => _idvehiculo;
        set => SetField(ref _idvehiculo, value);
    }

    public int Idaseguradora
    {
        get => _idaseguradora;
        set => SetField(ref _idaseguradora, value);
    }

    public string NumeroPoliza
    {
        get => _numeroPoliza;
        set => SetField(ref _numeroPoliza, value);
    }

    public string NumeroCertificado
    {
        get => _numeroCertificado;
        set => SetField(ref _numeroCertificado, value);
    }

    public int TipoSeguro
    {
        get => _tipoSeguro;
        set => SetField(ref _tipoSeguro, value);
    }

    public DateTime FechaInicio
    {
        get => _fechaInicio;
        set => SetField(ref _fechaInicio, value);
    }

    public DateTime FechaVencimiento
    {
        get => _fechaVencimiento;
        set => SetField(ref _fechaVencimiento, value);
    }

    public decimal PrimaAnual
    {
        get => _primaAnual;
        set => SetField(ref _primaAnual, value);
    }

    public string Moneda
    {
        get => _moneda;
        set => SetField(ref _moneda, value);
    }

    public decimal? Deducible
    {
        get => _deducible;
        set => SetField(ref _deducible, value);
    }

    public string ArchivoPoliza
    {
        get => _archivoPoliza;
        set => SetField(ref _archivoPoliza, value);
    }

    public string Observaciones
    {
        get => _observaciones;
        set => SetField(ref _observaciones, value);
    }

    public int? Estado
    {
        get => _estado;
        set => SetField(ref _estado, value);
    }

    public string VehiculoDescripcion
    {
        get => _vehiculoDescripcion;
        set => SetField(ref _vehiculoDescripcion, value);
    }

    public string AseguradoraNombre
    {
        get => _aseguradoraNombre;
        set => SetField(ref _aseguradoraNombre, value);
    }

    public string TipoSeguroNombre
    {
        get => _tipoSeguroNombre;
        set => SetField(ref _tipoSeguroNombre, value);
    }

    public string EstadoDescripcion => Estado != 1
        ? "Inactivo"
        : FechaVencimiento.Date < DateTime.Today
            ? "Vencido"
            : FechaInicio.Date > DateTime.Today
                ? "Programado"
                : "Vigente";

    public DateTime? CreatedAt
    {
        get => _createdAt;
        set => SetField(ref _createdAt, value);
    }

    public DateTime? UpdatedAt
    {
        get => _updatedAt;
        set => SetField(ref _updatedAt, value);
    }


    public virtual VehiculosDto Vehiculos
    {
        get => _vehiculos;
        set => SetField(ref _vehiculos, value);
    }


    public virtual AseguradorasDto Aseguradoras
    {
        get => _aseguradoras;
        set => SetField(ref _aseguradoras, value);
    }


    public virtual TipoSeguroDto TipoSeguros
    {
        get => _tipoSeguros;
        set => SetField(ref _tipoSeguros, value);
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
