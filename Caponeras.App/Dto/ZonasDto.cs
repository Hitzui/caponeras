using System.ComponentModel;
using System.Runtime.CompilerServices;
using Caponeras.Data.Models;

namespace Caponeras.App.Dto;

public class ZonasDto : INotifyPropertyChanged
{
    private int _idzonas;
    private string _nombre;
    private string _descripcion;
    private int? _estado;

    public int Idzonas
    {
        get => _idzonas;
        set => SetField(ref _idzonas, value);
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

    public int? Estado
    {
        get => _estado;
        set => SetField(ref _estado, value);
    }

    public ZonasDto()
    {
        _idzonas = 0;
        _nombre = string.Empty;
        _descripcion = string.Empty;
        _estado = 1;
    }

    public ZonasDto(Zonas? model)
    {
        if (model is null)
        {
            _idzonas = 0;
            _nombre = string.Empty;
            _descripcion = string.Empty;
        }
        else
        {
            _idzonas = model.Idzonas;
            _nombre = model.Nombre;
            _descripcion = model.Descripcion;
            _estado = model.Estado;
        }
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