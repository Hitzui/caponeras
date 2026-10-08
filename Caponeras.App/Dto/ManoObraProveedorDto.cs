using System.ComponentModel;
using System.Runtime.CompilerServices;
using Caponeras.Data.Models;

namespace Caponeras.App.Dto;

public class ManoObraProveedorDto : INotifyPropertyChanged
{
    private int _idManoObra;
    private int _idproveedor;
    private string? _nombreProveedor;
    private string? _descripcionTrabajo;
    private TipoManoObra _estado;
    private decimal _monto;
    private string? _observacion;
    private DateTime _fecha;
    private decimal _saldoPendiente;
    private decimal _montoAplicar;
    private int _idTransactionCxp;

    public ManoObraProveedorDto()
    {
        Idproveedor = 0;
        NombreProveedor = "";
        DescripcionTrabajo = "";
        Observacion = "";
    }

    public ManoObraProveedorDto(int idManoObra,
        int idproveedor,
        string nombreProveedor,
        string descripcionTrabajo,
        TipoManoObra estado,
        decimal monto,
        string observacion,
        DateTime fecha,
        decimal saldoPendiente,
        int idTransactionCxp)
    {
        this.IdManoObra = idManoObra;
        this.Idproveedor = idproveedor;
        this.NombreProveedor = nombreProveedor;
        this.DescripcionTrabajo = descripcionTrabajo;
        this.Estado = estado;
        this.Monto = monto;
        this.Observacion = observacion;
        this.Fecha = fecha;
        SaldoPendiente = saldoPendiente;
        MontoAplicar = 0m;
        this.IdTransactionCxp = idTransactionCxp;

    }

    public int IdTransactionCxp
    {
        get => _idTransactionCxp;
        set => SetField(ref _idTransactionCxp, value);
    }

    public decimal MontoAplicar
    {
        get => _montoAplicar;
        set => SetField(ref _montoAplicar, value);
    }

    public decimal SaldoPendiente
    {
        get => _saldoPendiente;
        set => SetField(ref _saldoPendiente, value);
    }

    public int IdManoObra
    {
        get => _idManoObra;
        set => SetField(ref _idManoObra, value);
    }

    public int Idproveedor
    {
        get => _idproveedor;
        set => SetField(ref _idproveedor, value);
    }

    public string? NombreProveedor
    {
        get => _nombreProveedor;
        set => SetField(ref _nombreProveedor, value);
    }

    public string? DescripcionTrabajo
    {
        get => _descripcionTrabajo;
        set => SetField(ref _descripcionTrabajo, value);
    }

    public TipoManoObra Estado
    {
        get => _estado;
        set => SetField(ref _estado, value);
    }

    public decimal Monto
    {
        get => _monto;
        set => SetField(ref _monto, value);
    }

    public string? Observacion
    {
        get => _observacion;
        set { SetField(ref _observacion, value); }
    }

    public DateTime Fecha
    {
        get => _fecha;
        set => SetField(ref _fecha, value);
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