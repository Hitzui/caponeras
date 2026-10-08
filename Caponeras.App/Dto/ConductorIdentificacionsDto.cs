using Caponeras.Data.Models;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Caponeras.App.Helpers;

namespace Caponeras.App.Dto;

public class ConductorIdentificacionsDto : INotifyPropertyChanged
{
    private int _ididentificacion;
    private int _idconductor;
    private string _numeroIdentificacion;
    private DateTime? _fechaEmision;
    private DateTime? _fechaVencimiento;
    private bool _activa;
    private string _fotoFrente;
    private string _fotoReverso;
    private string _observaciones;
    private DateTime? _createdAt;
    private DateTime? _updatedAt;
    private string _direccionDomiciliar;
    private string _municipioResidencia;
    private ConductoresDto _conductors;

    public ConductorIdentificacionsDto()
    {
        _numeroIdentificacion = string.Empty;
        _fotoFrente = string.Empty;
        _fotoReverso = string.Empty;
        _observaciones = string.Empty;
        _direccionDomiciliar = string.Empty;
        _municipioResidencia = string.Empty;
        _conductors = new ConductoresDto();
    }

    public ConductorIdentificacionsDto(string numeroIdentificacion, string fotoFrente, string fotoReverso,
        string observaciones, string direccionDomiciliar, string municipioResidencia, ConductoresDto conductors)
    {
        _numeroIdentificacion = numeroIdentificacion;
        _fotoFrente = fotoFrente;
        _fotoReverso = fotoReverso;
        _observaciones = observaciones;
        _direccionDomiciliar = direccionDomiciliar;
        _municipioResidencia = municipioResidencia;
        _conductors = conductors;
    }

    public ConductorIdentificacionsDto(ConductorIdentificacions model)
    {
        _ididentificacion = model.Ididentificacion;
        _idconductor = model.Idconductor;
        _numeroIdentificacion = model.NumeroIdentificacion;
        _fechaEmision = model.FechaEmision;
        _fechaVencimiento = model.FechaVencimiento;
        _activa = model.Activa;
        _fotoFrente = model.FotoFrente;
        _fotoReverso = model.FotoReverso;
        _observaciones = model.Observaciones;
        _createdAt = model.CreatedAt;
        _updatedAt = model.UpdatedAt;
        _direccionDomiciliar = model.DireccionDomiciliar;
        _municipioResidencia = model.MunicipioResidencia;
        _conductors = new ConductoresDto(model.Conductors);
    }

    public Image? FotoIdentificacionFrenteImage { get; set; }
    public Image? FotoIdentificacionReversoImage { get; set; }

    public int Ididentificacion
    {
        get => _ididentificacion;
        set => SetField(ref _ididentificacion, value);
    }

    public int Idconductor
    {
        get => _idconductor;
        set => SetField(ref _idconductor, value);
    }

    public string NumeroIdentificacion
    {
        get => _numeroIdentificacion;
        set => SetField(ref _numeroIdentificacion, value);
    }

    public DateTime? FechaEmision
    {
        get => _fechaEmision;
        set => SetField(ref _fechaEmision, value);
    }

    public DateTime? FechaVencimiento
    {
        get => _fechaVencimiento;
        set => SetField(ref _fechaVencimiento, value);
    }

    public bool Activa
    {
        get => _activa;
        set => SetField(ref _activa, value);
    }

    public string FotoFrente
    {
        get => _fotoFrente;
        set => SetField(ref _fotoFrente, value);
    }

    public string FotoReverso
    {
        get => _fotoReverso;
        set => SetField(ref _fotoReverso, value);
    }

    public string Observaciones
    {
        get => _observaciones;
        set => SetField(ref _observaciones, value);
    }

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

    public string DireccionDomiciliar
    {
        get => _direccionDomiciliar;
        set => SetField(ref _direccionDomiciliar, value);
    }

    public string MunicipioResidencia
    {
        get => _municipioResidencia;
        set => SetField(ref _municipioResidencia, value);
    }

    public virtual ConductoresDto Conductors
    {
        get => _conductors;
        set => SetField(ref _conductors, value);
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