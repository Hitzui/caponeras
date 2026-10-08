using System.ComponentModel;
using System.Runtime.CompilerServices;
using Caponeras.Data.Models;

namespace Caponeras.App.Dto;

public class MovimientoInventarioDto : INotifyPropertyChanged
{
    private int _idMovimiento;
    private int _idProducto;
    private DateTime _fecha;
    private TipoMovimiento _tipoMovimiento;
    private decimal _entrada;
    private int _idUnidadMedida;
    private ReferenciaInventario _referenciaTipo;
    private decimal _salida;
    private decimal _stockAnterior;
    private decimal _stockNuevo;
    private int? _createdBy;
    private DateTime _createdAt;
    private int? _referenciaId;
    private string _observaciones = "";
    private ProductoDto? _productos;

    public MovimientoInventarioDto()
    {
    }

    public MovimientoInventarioDto(MovimientoInventarios model)
    {
        FromModel(model);
    }

    public int IdMovimiento
    {
        get => _idMovimiento;
        set => SetField(ref _idMovimiento, value);
    }

    public int IdProducto
    {
        get => _idProducto;
        set => SetField(ref _idProducto, value);
    }

    public DateTime Fecha
    {
        get => _fecha;
        set => SetField(ref _fecha, value);
    }

    public TipoMovimiento TipoMovimiento
    {
        get => _tipoMovimiento;
        set => SetField(ref _tipoMovimiento, value);
    }

    public decimal Entrada
    {
        get => _entrada;
        set => SetField(ref _entrada, value);
    }

    public int IdUnidadMedida
    {
        get => _idUnidadMedida;
        set => SetField(ref _idUnidadMedida, value);
    }

    public ReferenciaInventario ReferenciaTipo
    {
        get => _referenciaTipo;
        set => SetField(ref _referenciaTipo, value);
    }

    public decimal Salida
    {
        get => _salida;
        set => SetField(ref _salida, value);
    }

    public decimal StockAnterior
    {
        get => _stockAnterior;
        set => SetField(ref _stockAnterior, value);
    }

    public decimal StockNuevo
    {
        get => _stockNuevo;
        set => SetField(ref _stockNuevo, value);
    }

    public int? CreatedBy
    {
        get => _createdBy;
        set => SetField(ref _createdBy, value);
    }

    public DateTime CreatedAt
    {
        get => _createdAt;
        set => SetField(ref _createdAt, value);
    }

    public int? ReferenciaId
    {
        get => _referenciaId;
        set => SetField(ref _referenciaId, value);
    }

    public string Observaciones
    {
        get => _observaciones;
        set => SetField(ref _observaciones, value);
    }

    public ProductoDto? Productos
    {
        get => _productos;
        set => SetField(ref _productos, value);
    }

    #region Mapping

    public MovimientoInventarios ToModel()
    {
        var m = new MovimientoInventarios
        {
            IdMovimiento = this.IdMovimiento,
            IdProducto = this.IdProducto,
            Fecha = this.Fecha,
            TipoMovimiento = this.TipoMovimiento,
            Entrada = Entrada,
            IdUnidadMedida = this.IdUnidadMedida,
            ReferenciaTipo = this.ReferenciaTipo,
            Salida = Salida,
            ReferenciaId = this.ReferenciaId,
            Observaciones = this.Observaciones,
            StockAnterior = StockAnterior,
            StockNuevo = StockNuevo,
            CreatedBy = CreatedBy,
            CreatedAt = CreatedAt,
        };
        if (Productos is not null)
        {
            m.Productos = Productos.ToModel();
        }

        return m;
    }

    public MovimientoInventarioDto FromModel(MovimientoInventarios model)
    {
        return new MovimientoInventarioDto
        {
            IdMovimiento = model.IdMovimiento,
            IdProducto = model.IdProducto,
            Fecha = model.Fecha,
            TipoMovimiento = model.TipoMovimiento,
            Entrada = model.Entrada,
            IdUnidadMedida = model.IdUnidadMedida,
            ReferenciaTipo = model.ReferenciaTipo,
            Salida = model.Salida,
            StockAnterior = model.StockAnterior,
            StockNuevo = model.StockNuevo,
            CreatedBy = model.CreatedBy,
            CreatedAt = model.CreatedAt,
            ReferenciaId = model.ReferenciaId,
            Observaciones = model.Observaciones,
            Productos = new ProductoDto(model.Productos)
        };
    }

    #endregion

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