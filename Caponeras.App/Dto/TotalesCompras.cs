using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Caponeras.App.Dto;

public class TotalesCompras : INotifyPropertyChanged
{
    private decimal _subTotal;
    private decimal _iva;
    private decimal _total;


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

    public decimal SubTotal
    {
        get => _subTotal;

        set => SetField(ref _subTotal, value);
    }

    public decimal Iva
    {
        get => _iva;

        set => SetField(ref _iva, value);
    }

    public decimal Total
    {
        get => _total;

        set => SetField(ref _total, value);
    }

    public TotalesCompras()
    {
        SubTotal = 0m;
        Iva = 0m;
        Total = 0m;
    }

    public TotalesCompras(decimal subTotal, decimal iva, decimal total)
    {
        SubTotal = subTotal;
        Iva = iva;
        Total = total;
    }
}