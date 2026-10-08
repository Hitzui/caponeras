using System.ComponentModel;
using System.Runtime.CompilerServices;
using Caponeras.Data.Models;

namespace Caponeras.App.Dto;

public class DetalleCompraDto : INotifyPropertyChanged
{
    public int Iddetalle { get; set; }

    public int? Idcompra { get; set; }

    public int Idproducto { get; set; }

    private decimal _cantidad;

    public decimal Cantidad
    {
        get => _cantidad;
        set => SetField(ref _cantidad, value);
    }

    private decimal _precioUnitario;

    public decimal PrecioUnitario
    {
        get => _precioUnitario;
        set => SetField(ref _precioUnitario, value);
    }

    private decimal _importe;

    public decimal Importe
    {
        get => _importe;
        set => SetField(ref _importe, value);
    }

    public string? Codigo { get; set; }

    public string? Nombre { get; set; }

    public DetalleCompraDto()
    {
        Iddetalle = 0;
        Codigo = string.Empty;
        Nombre = string.Empty;
    }

    public DetalleCompraDto(DetalleCompras model)
    {
        Iddetalle = model.Iddetalle;
        Idcompra = model.Idcompra;
        Idproducto = model.Idproducto;
        Cantidad = model.Cantidad;
        PrecioUnitario = model.PrecioUnitario;
        Importe = model.Importe;
        Codigo = model.Productos?.Codigo ?? string.Empty;
        Nombre = model.Productos?.Nombre ?? string.Empty;
    }

    public DetalleCompras ToModel()
    {
        return new DetalleCompras
        {
            Iddetalle = Iddetalle,
            Idcompra = Idcompra,
            Idproducto = Idproducto,
            Cantidad = Cantidad,
            PrecioUnitario = PrecioUnitario,
            Importe = Importe
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