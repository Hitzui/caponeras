using System.ComponentModel;
using System.Runtime.CompilerServices;
using Caponeras.Data.Models;

namespace Caponeras.App.Dto;

public class ProveedoresDto : INotifyPropertyChanged
{
    private int _idProveedor;
    private string? _direccion;
    private string? _contacto;
    private DateTime _fechaRegistro;
    private bool _activo;
    private int? _createdBy;
    private DateTime _createdAt;
    private int? _updatedBy;
    private DateTime _updatedAt;
    private decimal _montoManoObra;
    private int _idMantenimientoProveedor;

    public ProveedoresDto()
    {
        IdProveedor = 0;
    }

    public int IdMantenimientoProveedor
    {
        get => _idMantenimientoProveedor;
        set => SetField(ref _idMantenimientoProveedor, value);
    }

    public int IdProveedor
    {
        get => _idProveedor;
        set { SetField(ref _idProveedor, value); }
    }

    public string Nombre
    {
        get;
        set => SetField(ref field, value);
    } = string.Empty;

    public string? Ruc
    {
        get;
        set => SetField(ref field, value);
    }

    public string? Telefono
    {
        get;
        set => SetField(ref field, value);
    }

    public string? Email
    {
        get;
        set => SetField(ref field, value);
    }

    public string? Direccion
    {
        get => _direccion;
        set { SetField(ref _direccion, value); }
    }

    public string? Contacto
    {
        get => _contacto;
        set { SetField(ref _contacto, value); }
    }

    public DateTime FechaRegistro
    {
        get => _fechaRegistro;
        set { SetField(ref _fechaRegistro, value); }
    }

    public bool Activo
    {
        get => _activo;
        set { SetField(ref _activo, value); }
    }

    public int? CreatedBy
    {
        get => _createdBy;
        set { SetField(ref _createdBy, value); }
    }

    public DateTime CreatedAt
    {
        get => _createdAt;
        set { SetField(ref _createdAt, value); }
    }

    public int? UpdatedBy
    {
        get => _updatedBy;
        set { SetField(ref _updatedBy, value); }
    }

    public DateTime UpdatedAt
    {
        get => _updatedAt;
        set { SetField(ref _updatedAt, value); }
    }

    public decimal MontoManoObra
    {
        get => _montoManoObra;
        set { SetField(ref _montoManoObra, value); }
    }

    #region Mappers

    public static ProveedoresDto FromEntity(Proveedores entity, int idmantenimientoProveedor = 0, decimal monto = 0m)
    {
        if (entity == null)
            throw new ArgumentNullException(nameof(entity));

        return new ProveedoresDto
        {
            IdProveedor = entity.Idproveedor,
            Nombre = entity.Nombre,
            Ruc = entity.Ruc,
            Telefono = entity.Telefono,
            Email = entity.Email,
            Direccion = entity.Direccion,
            Contacto = entity.Contacto,
            FechaRegistro = entity.FechaRegistro,
            Activo = entity.Activo ?? false,
            CreatedBy = entity.CreatedBy,
            CreatedAt = entity.CreatedAt,
            UpdatedBy = entity.UpdatedBy,
            UpdatedAt = entity.UpdatedAt,
            IdMantenimientoProveedor = idmantenimientoProveedor,
            MontoManoObra = monto
        };
    }

    public static Proveedores ToEntity(ProveedoresDto dto)
    {
        if (dto == null)
            throw new ArgumentNullException(nameof(dto));

        return new Proveedores
        {
            Idproveedor = dto.IdProveedor,
            Nombre = dto.Nombre,
            Ruc = dto.Ruc,
            Telefono = dto.Telefono,
            Email = dto.Email,
            Direccion = dto.Direccion,
            Contacto = dto.Contacto,
            FechaRegistro = dto.FechaRegistro,
            Activo = dto.Activo,
            CreatedBy = dto.CreatedBy,
            CreatedAt = dto.CreatedAt,
            UpdatedBy = dto.UpdatedBy,
            UpdatedAt = dto.UpdatedAt
        };
    }

    public static void UpdateEntity(Proveedores entity, ProveedoresDto dto)
    {
        if (entity == null)
            throw new ArgumentNullException(nameof(entity));

        if (dto == null)
            throw new ArgumentNullException(nameof(dto));

        entity.Nombre = dto.Nombre;
        entity.Ruc = dto.Ruc;
        entity.Telefono = dto.Telefono;
        entity.Email = dto.Email;
        entity.Direccion = dto.Direccion;
        entity.Contacto = dto.Contacto;
        entity.FechaRegistro = dto.FechaRegistro;
        entity.Activo = dto.Activo;
        entity.UpdatedBy = dto.UpdatedBy;
        entity.UpdatedAt = dto.UpdatedAt;
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

    public static ProveedoresDto FromView(ProveedoresManoObras mp)
    {
        return new ProveedoresDto
        {
            IdMantenimientoProveedor = mp.IdmantenimientoProveedor,
            IdProveedor = mp.Idproveedor,
            Nombre = mp.Nombre,
            Ruc = mp.Ruc,
            Telefono = mp.Telefono,
            Email = mp.Email,
            Direccion = mp.Direccion,
            Contacto = mp.Contacto,
            FechaRegistro = mp.FechaRegistro,
            Activo = mp.Activo ?? false,
            CreatedBy = mp.CreatedBy,
            CreatedAt = mp.CreatedAt,
            UpdatedBy = mp.UpdatedBy,
            UpdatedAt = mp.UpdatedAt,
            MontoManoObra = mp.Monto
        };
    }
}