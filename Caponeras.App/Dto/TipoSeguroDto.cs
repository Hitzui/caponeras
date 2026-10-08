using System.ComponentModel;
using System.Runtime.CompilerServices;
using Caponeras.Data.Models;

namespace Caponeras.App.Dto;

public class TipoSeguroDto : INotifyPropertyChanged
{
    private int _idtiposeguro;
    private string _codigo;
    private string _nombre;
    private string _descripcion;
    private bool? _activo;

    public TipoSeguroDto(TipoSeguros model)
    {
        _idtiposeguro = model.Idtiposeguro;
        _codigo = model.Codigo;
        _nombre = model.Nombre;
        _descripcion = model.Descripcion;
        _activo = model.Activo;
    }
    public TipoSeguroDto()
    {
        _codigo = "";
        _nombre = "";
        _descripcion = "";
    }
    public int Idtiposeguro
    {
        get => _idtiposeguro;
        set => SetField(ref _idtiposeguro, value);
    }

    public string Codigo
    {
        get => _codigo;
        set => SetField(ref _codigo, value);
    }

    public string Nombre
    {
        get => _nombre;
        set => SetField(ref _nombre, value);
    }

    public string Descripcion
    {
        get => _descripcion;
        set => SetField(ref _descripcion, value);
    }

    public bool? Activo
    {
        get => _activo;
        set => SetField(ref _activo, value);
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