using Caponeras.Data.Models;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Caponeras.App.Dto;

public class ProductoDto : INotifyPropertyChanged
{
    private int _idProducto;
    private string? _codigo;
    private string? _nombre;
    private string? _descripcion;
    private int? _idCategoria;
    private int? _idUnidadMedida;
    private decimal _stockMinimo;
    private decimal _stockActual;
    private decimal? _precioCosto;
    private decimal? _precioVenta;
    private bool? _activo;
    private string? _urlImage;
    private CategoriaProductoDto? _categoriasProductos;
    private UnidadMedidaDto? _unidadesMedidas;
    private bool _inventariable;

    public ProductoDto()
    {
    }

    public ProductoDto(Productos model)
    {
        _idProducto = model.IdProducto;
        _codigo = model.Codigo;
        _nombre = model.Nombre;
        _descripcion = model.Descripcion;
        _idCategoria = model.IdCategoria;
        _idUnidadMedida = model.IdUnidadMedida;
        _stockMinimo = model.StockMinimo ?? 0m;
        _stockActual = model.StockActual ?? 0m;
        _precioCosto = model.PrecioCosto;
        _precioVenta = model.PrecioVenta;
        _activo = model.Activo;
        _urlImage = model.UrlImage;
        _categoriasProductos = CategoriaProductoDto.FromModel(model.CategoriasProductos);
        _unidadesMedidas = UnidadMedidaDto.FromModel(model.UnidadesMedidas);
        _inventariable = model.Inventariable;
    }

    public int IdProducto
    {
        get => _idProducto;
        set => SetField(ref _idProducto, value);
    }

    public string? Codigo
    {
        get => _codigo;
        set => SetField(ref _codigo, value);
    }

    public string? Nombre
    {
        get => _nombre;
        set => SetField(ref _nombre, value);
    }

    public string? Descripcion
    {
        get => _descripcion;
        set => SetField(ref _descripcion, value);
    }

    public int? IdCategoria
    {
        get => _idCategoria;
        set => SetField(ref _idCategoria, value);
    }

    public int? IdUnidadMedida
    {
        get => _idUnidadMedida;
        set => SetField(ref _idUnidadMedida, value);
    }

    public decimal StockMinimo
    {
        get => _stockMinimo;
        set => SetField(ref _stockMinimo, value);
    }

    public decimal StockActual
    {
        get => _stockActual;
        set => SetField(ref _stockActual, value);
    }

    public decimal? PrecioCosto
    {
        get => _precioCosto;
        set => SetField(ref _precioCosto, value);
    }

    public decimal? PrecioVenta
    {
        get => _precioVenta;
        set => SetField(ref _precioVenta, value);
    }

    public bool? Activo
    {
        get => _activo;
        set => SetField(ref _activo, value);
    }

    public string? UrlImage
    {
        get => _urlImage;
        set => SetField(ref _urlImage, value);
    }

    public Image? Imagen { get; set; }

    public virtual CategoriaProductoDto? CategoriasProductos
    {
        get => _categoriasProductos;
        set => SetField(ref _categoriasProductos, value);
    }

    public virtual UnidadMedidaDto? UnidadesMedidas
    {
        get => _unidadesMedidas;
        set => SetField(ref _unidadesMedidas, value);
    }

    public bool Inventariable
    {
        get => _inventariable;
        set => SetField(ref _inventariable, value);
    }

    public ProductoDto FromModel(Productos model)
    {
        var dto = new ProductoDto
        {
            IdProducto = model.IdProducto,
            Codigo = model.Codigo,
            Nombre = model.Nombre,
            Descripcion = model.Descripcion,
            IdCategoria = model.IdCategoria,
            IdUnidadMedida = model.IdUnidadMedida,
            StockMinimo = model.StockMinimo ?? 0m,
            StockActual = model.StockActual ?? 0m,
            PrecioCosto = model.PrecioCosto,
            PrecioVenta = model.PrecioVenta,
            Activo = model.Activo,
            UrlImage = model.UrlImage,
            Inventariable = model.Inventariable,
            CategoriasProductos = CategoriaProductoDto.FromModel(model.CategoriasProductos),
            UnidadesMedidas = UnidadMedidaDto.FromModel(model.UnidadesMedidas)
        };
        return dto;
    }

    public Productos ToModel()
    {
        var model = new Productos();

        model.IdProducto = IdProducto;
        model.Codigo = Codigo ?? "";
        model.Nombre = Nombre ?? "";
        model.Descripcion = Descripcion ?? "";
        model.IdCategoria = IdCategoria;
        model.IdUnidadMedida = IdUnidadMedida;
        model.StockMinimo = StockMinimo;
        model.StockActual = StockActual;
        model.PrecioCosto = PrecioCosto;
        model.PrecioVenta = PrecioVenta;
        model.UrlImage = UrlImage ?? string.Empty;
        model.Activo = Activo;
        model.Inventariable = Inventariable;

        return model;
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