using Caponeras.Data.Models;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Caponeras.App.Dto;

public class ConductorLicenciasDto : INotifyPropertyChanged
{
    private int _idlicencia;
    private int _idconductor;
    private string _numeroLicencia;
    private string _categoria;
    private DateTime? _fechaEmision;
    private DateTime _fechaVencimiento;
    private bool _activa;
    private string _fotoLicenciaFrente;
    private string _fotoLicenciaReverso;
    private string _observaciones;
    private DateTime? _createdAt;
    private DateTime? _updatedAt;
    private ConductoresDto? _conductors;

    public ConductorLicenciasDto()
    {
        _idlicencia = 0;
        _numeroLicencia = string.Empty;
        _categoria = string.Empty;
        _fotoLicenciaFrente = string.Empty;
        _fotoLicenciaReverso = string.Empty;
        _observaciones = string.Empty;
        _fechaVencimiento = DateTime.Today.AddYears(1);
    }

    public ConductorLicenciasDto(ConductorLicencias? model)
    {
        if (model is null) return;
        Idlicencia = model.Idlicencia;
        Idconductor = model.Idconductor;
        NumeroLicencia = model.NumeroLicencia;
        Categoria = model.Categoria;
        FechaEmision = model.FechaEmision;
        FechaVencimiento = model.FechaVencimiento;
        Activa = model.Activa;
        FotoLicenciaFrente = model.FotoLicenciaFrente;
        FotoLicenciaReverso = model.FotoLicenciaReverso;
        Observaciones = model.Observaciones;
        CreatedAt = model.CreatedAt;
        UpdatedAt = model.UpdatedAt;
        Conductors = model.Conductors is not null
            ? new ConductoresDto(model.Conductors)
            : null;
    }

    public ConductorLicencias ToModel()
    {
        return new ConductorLicencias
        {
            Idlicencia = _idlicencia,
            Idconductor = _idconductor,
            NumeroLicencia = _numeroLicencia,
            Categoria = _categoria,
            FechaEmision = _fechaEmision,
            FechaVencimiento = _fechaVencimiento,
            Activa = _activa,
            FotoLicenciaFrente = _fotoLicenciaFrente,
            FotoLicenciaReverso = _fotoLicenciaReverso,
            Observaciones = _observaciones,
            CreatedAt = _createdAt,
            UpdatedAt = _updatedAt,
            Conductors = _conductors?.Conductors()
        };
    }

    public Image? FotoLicenciaFrenteImage { get; set; }
    public Image? FotoLicenciaReversoImage { get; set; }

    public int Idlicencia
    {
        get => _idlicencia;
        set => SetField(ref _idlicencia, value);
    }

    public int Idconductor
    {
        get => _idconductor;
        set => SetField(ref _idconductor, value);
    }

    public string NumeroLicencia
    {
        get => _numeroLicencia;
        set => SetField(ref _numeroLicencia, value);
    }

    public string Categoria
    {
        get => _categoria;
        set => SetField(ref _categoria, value);
    }

    public DateTime? FechaEmision
    {
        get => _fechaEmision;
        set => SetField(ref _fechaEmision, value);
    }

    public DateTime FechaVencimiento
    {
        get => _fechaVencimiento;
        set => SetField(ref _fechaVencimiento, value);
    }

    public bool Activa
    {
        get => _activa;
        set => SetField(ref _activa, value);
    }

    public string FotoLicenciaFrente
    {
        get => _fotoLicenciaFrente;
        set => SetField(ref _fotoLicenciaFrente, value);
    }

    public string FotoLicenciaReverso
    {
        get => _fotoLicenciaReverso;
        set => SetField(ref _fotoLicenciaReverso, value);
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

    public virtual ConductoresDto? Conductors
    {
        get => _conductors;
        set => SetField(ref _conductors, value);
    }

    public bool Vencida => FechaVencimiento < DateTime.Today;

    public string EstadoLicencia => Vencida ? "VENCIDA" : "VIGENTE";

    public static readonly List<string> Categorias =
    [
        "1",
        "2",
        "3",
        "4A",
        "4B",
        "5A",
        "5B",
        "6",
        "7"
    ];

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