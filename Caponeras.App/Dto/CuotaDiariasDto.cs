using System.ComponentModel;
using System.Runtime.CompilerServices;
using Caponeras.Data.Models;

namespace Caponeras.App.Dto;

public sealed class CuotaDiariasDto :INotifyPropertyChanged
{
    private int _idCuotaDiaria;
    private DateTime _fecha;
    private int _idVehiculo;
    private decimal _montoCuota;
    private decimal _montoEntregado;
    private decimal _diferencia;
    private decimal _porcentaje;
    private string _observaciones = string.Empty;
    private int? _createdBy;
    private DateTime? _createdAt;
    private int _idconductor;

    public int IdCuotaDiaria
    {
        get => _idCuotaDiaria;
        set => SetField(ref _idCuotaDiaria, value);
    }

    public DateTime Fecha
    {
        get => _fecha;
        set => SetField(ref _fecha, value);
    }

    public int IdVehiculo
    {
        get => _idVehiculo;
        set => SetField(ref _idVehiculo, value);
    }

    public decimal MontoCuota
    {
        get => _montoCuota;
        set => SetField(ref _montoCuota, value);
    }

    public decimal MontoEntregado
    {
        get => _montoEntregado;
        set => SetField(ref _montoEntregado, value);
    }

    public decimal Diferencia
    {
        get => _diferencia;
        set => SetField(ref _diferencia, value);
    }

    public decimal Porcentaje
    {
        get => _porcentaje;
        set => SetField(ref _porcentaje, value);
    }

    public string Observaciones
    {
        get => _observaciones;
        set => SetField(ref _observaciones, value);
    }

    public int? CreatedBy
    {
        get => _createdBy;
        set => SetField(ref _createdBy, value);
    }

    public DateTime? CreatedAt
    {
        get => _createdAt;
        set => SetField(ref _createdAt, value);
    }

    public int Idconductor
    {
        get => _idconductor;
        set => SetField(ref _idconductor, value);
    }

    public CuotaDiariasDto()
    {
    }

    public CuotaDiariasDto(CuotaDiarias model)
    {
        IdCuotaDiaria = model.IdCuotaDiaria;
        Fecha = model.Fecha;
        IdVehiculo = model.IdVehiculo;
        MontoCuota = model.MontoCuota;
        MontoEntregado = model.MontoEntregado;
        Diferencia = model.Diferencia;
        Porcentaje = model.Porcentaje;
        Observaciones = model.Observaciones;
        CreatedBy = model.CreatedBy;
        CreatedAt = model.CreatedAt;
        Idconductor = model.Idconductor;
    }

    public CuotaDiarias ToModel()
    {
        return new CuotaDiarias
        {
            IdCuotaDiaria = IdCuotaDiaria,
            Fecha = Fecha,
            IdVehiculo = IdVehiculo,
            MontoCuota = MontoCuota,
            MontoEntregado = MontoEntregado,
            Diferencia = Diferencia,
            Porcentaje = Porcentaje,
            Observaciones = Observaciones,
            CreatedBy = CreatedBy,
            CreatedAt = CreatedAt,
            Idconductor = Idconductor
        };
    }

    public void UpdateModel(CuotaDiarias model)
    {
        model.Fecha = Fecha;
        model.IdVehiculo = IdVehiculo;
        model.MontoCuota = MontoCuota;
        model.MontoEntregado = MontoEntregado;
        model.Diferencia = Diferencia;
        model.Porcentaje = Porcentaje;
        model.Observaciones = Observaciones;
        model.CreatedBy = CreatedBy;
        model.CreatedAt = CreatedAt;
        model.Idconductor = Idconductor;
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    private void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    private bool SetField<T>(ref T field, T value, [CallerMemberName] string? propertyName = null)
    {
        if (EqualityComparer<T>.Default.Equals(field, value)) return false;
        field = value;
        OnPropertyChanged(propertyName);
        return true;
    }
}