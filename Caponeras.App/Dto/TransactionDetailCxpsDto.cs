using System.ComponentModel;
using System.Runtime.CompilerServices;
using Caponeras.Data.Models;

namespace Caponeras.App.Dto;

public class TransactionDetailCxpsDto : INotifyPropertyChanged
{
    private int _idtransactiondetail;
    private int? _idtrasactionCxp;
    private DateTime? _fecha;
    private decimal _monto = 0.00m;
    private int? _iddetamovimiento;
    private string _metodoPago = "EFECTIVO";

    public event PropertyChangedEventHandler PropertyChanged;

    public TransactionDetailCxpsDto()
    {
        
    }

    public TransactionDetailCxpsDto(TransactionDetailCxps entity)
    {
        if (entity == null)
            return;

        _idtransactiondetail = entity.Idtransactiondetail;
        _idtrasactionCxp = entity.IdtrasactionCxp;
        _fecha = entity.Fecha;
        _monto = entity.Monto;
        _iddetamovimiento = entity.Iddetamovimiento;
        _metodoPago = entity.MetodoPago;
    }

    public int Idtransactiondetail
    {
        get => _idtransactiondetail;
        set => SetField(ref _idtransactiondetail, value);
    }

    public int? IdtrasactionCxp
    {
        get => _idtrasactionCxp;
        set => SetField(ref _idtrasactionCxp, value);
    }

    public DateTime? Fecha
    {
        get => _fecha;
        set => SetField(ref _fecha, value);
    }

    public decimal Monto
    {
        get => _monto;
        set => SetField(ref _monto, value);
    }

    public int? Iddetamovimiento
    {
        get => _iddetamovimiento;
        set => SetField(ref _iddetamovimiento, value);
    }

    public string MetodoPago
    {
        get => _metodoPago;
        set => SetField(ref _metodoPago, value);
    }

    protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

    protected bool SetField<T>(ref T field, T value, [CallerMemberName] string propertyName = null)
    {
        if (EqualityComparer<T>.Default.Equals(field, value))
            return false;

        field = value;
        OnPropertyChanged(propertyName);
        return true;
    }

    public TransactionDetailCxps ToEntity()
    {
        return new TransactionDetailCxps
        {
            Idtransactiondetail = this.Idtransactiondetail,
            IdtrasactionCxp = this.IdtrasactionCxp,
            Fecha = this.Fecha,
            Monto = this.Monto,
            Iddetamovimiento = this.Iddetamovimiento,
            MetodoPago = this.MetodoPago
        };
    }
}