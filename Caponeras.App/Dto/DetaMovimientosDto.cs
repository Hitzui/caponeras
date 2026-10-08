using System.ComponentModel;
using System.Runtime.CompilerServices;
using Caponeras.Data.Models;

namespace Caponeras.App.Dto;

public class DetaMovimientosDto : INotifyPropertyChanged
{
    private int _iddetamovimientos;
    private int _idmaestrocaja;
    private DateTime _fecha;
    private string _concepto = string.Empty;
    private int _idmovimiento;
    private string _referenciaTipo = string.Empty;
    private int? _referenciaId;
    private decimal _efectivo;
    private decimal _transferencia;
    private decimal? _tipocambio;
    private MaestroCajaDto? _maestroCajas;

    public DetaMovimientosDto()
    {
        
    }
    public DetaMovimientosDto(DetaMovimientos dm)
    {
        Iddetamovimientos = dm.Iddetamovimientos;
        Idmaestrocaja = dm.Idmaestrocaja;
        Fecha = dm.Fecha;
        Concepto = dm.Concepto;
        Idmovimiento = dm.Idmovimiento;
        ReferenciaTipo = dm.ReferenciaTipo;
        ReferenciaId = dm.ReferenciaId;
        Efectivo = dm.Efectivo;
        Transferencia = dm.Transferencia;
        Tipocambio = dm.Tipocambio;
    }

    public int Iddetamovimientos
    {
        get => _iddetamovimientos;
        set => SetField(ref _iddetamovimientos, value);
    }

    public int Idmaestrocaja
    {
        get => _idmaestrocaja;
        set => SetField(ref _idmaestrocaja, value);
    }

    public DateTime Fecha
    {
        get => _fecha;
        set => SetField(ref _fecha, value);
    }

    public string Concepto
    {
        get => _concepto;
        set => SetField(ref _concepto, value);
    }

    public int Idmovimiento
    {
        get => _idmovimiento;
        set => SetField(ref _idmovimiento, value);
    }

    public string ReferenciaTipo
    {
        get => _referenciaTipo;
        set => SetField(ref _referenciaTipo, value);
    }

    public int? ReferenciaId
    {
        get => _referenciaId;
        set => SetField(ref _referenciaId, value);
    }

    public decimal Efectivo
    {
        get => _efectivo;
        set => SetField(ref _efectivo, value);
    }

    public decimal Transferencia
    {
        get => _transferencia;
        set => SetField(ref _transferencia, value);
    }

    public decimal? Tipocambio
    {
        get => _tipocambio;
        set => SetField(ref _tipocambio, value);
    }

    public int? CreatedBy { get; set; }
    public DateTime? CreatedAt { get; set; }
    public int? UpdatedBy { get; set; }
    public DateTime? UpdatedAt { get; set; }

    public MaestroCajaDto? MaestroCajas
    {
        get => _maestroCajas;
        set => SetField(ref _maestroCajas, value);
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    protected bool SetField<T>(ref T field, T value, [CallerMemberName] string? propertyName = null)
    {
        if (EqualityComparer<T>.Default.Equals(field, value))
            return false;

        field = value;
        OnPropertyChanged(propertyName);
        return true;
    }
}