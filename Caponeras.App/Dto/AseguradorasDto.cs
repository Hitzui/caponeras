using System.ComponentModel;
using System.Runtime.CompilerServices;
using Caponeras.Data.Models;

namespace Caponeras.App.Dto;

public class AseguradorasDto : INotifyPropertyChanged
{
    private int _idaseguradora;
    private string _nombre;
    private string _nombreCorto;
    private string _telefono;
    private string _correo;
    private string _sitioWeb;
    private string _direccion;
    private bool _activo;
    private DateTime? _createdAt;
    private DateTime? _updatedAt;

    public AseguradorasDto()
    {
        _nombre = string.Empty;
        _nombreCorto = string.Empty;
        _telefono = string.Empty;
        _correo = string.Empty;
        _sitioWeb = string.Empty;
        _direccion = string.Empty;
    }

    public AseguradorasDto(Aseguradoras model)
    {
        _idaseguradora = model.Idaseguradora;
        _nombre = model.Nombre;
        _nombreCorto = model.NombreCorto;
        _telefono = model.Telefono;
        _correo = model.Correo;
        _sitioWeb = model.SitioWeb;
        _direccion = model.Direccion;
        _activo = model.Activo;
        _createdAt = model.CreatedAt;
        _updatedAt = model.UpdatedAt;
    }

    public int Idaseguradora
    {
        get => _idaseguradora;
        set => SetField(ref _idaseguradora, value);
    }

    public string Nombre
    {
        get => _nombre;
        set => SetField(ref _nombre, value);
    }

    public string NombreCorto
    {
        get => _nombreCorto;
        set => SetField(ref _nombreCorto, value);
    }

    public string Telefono
    {
        get => _telefono;
        set => SetField(ref _telefono, value);
    }

    public string Correo
    {
        get => _correo;
        set => SetField(ref _correo, value);
    }

    public string SitioWeb
    {
        get => _sitioWeb;
        set => SetField(ref _sitioWeb, value);
    }

    public string Direccion
    {
        get => _direccion;
        set => SetField(ref _direccion, value);
    }

    public bool Activo
    {
        get => _activo;
        set => SetField(ref _activo, value);
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