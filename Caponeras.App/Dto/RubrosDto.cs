using System.ComponentModel;
using System.Runtime.CompilerServices;
using Caponeras.Data.Models;

namespace Caponeras.App.Dto;

public class RubrosDto : INotifyPropertyChanged
{
    private int _idrubro;
    private string _codrubro;
    private string _descripcion;
    private RubroNaturaleza _naturaleza;

    public RubrosDto()
    {
        MovCajas = new List<MovCajasDto>();
        _codrubro = string.Empty;
        _descripcion = string.Empty;
        _naturaleza = 0;
    }

    public RubrosDto(int idrubro, string codrubro, string descripcion, RubroNaturaleza naturaleza)
    {
        _idrubro = idrubro;
        _codrubro = codrubro;
        _descripcion = descripcion;
        _naturaleza = naturaleza;
        MovCajas = new List<MovCajasDto>();
    }

    public int Idrubro
    {
        get => _idrubro;
        set => SetField(ref _idrubro, value);
    }

    public string Codrubro
    {
        get => _codrubro;
        set => SetField(ref _codrubro, value);
    }

    public string Descripcion
    {
        get => _descripcion;
        set => SetField(ref _descripcion, value);
    }

    public RubroNaturaleza Naturaleza
    {
        get => _naturaleza;
        set
        {
            if (SetField(ref _naturaleza, value))
            {
                OnPropertyChanged(nameof(NaturalezaDescripcion));
            }
        }
    }

    public string NaturalezaDescripcion => _naturaleza == RubroNaturaleza.Ingreso ? "Entrada" : "Salida";

    public IList<MovCajasDto> MovCajas { get; set; }


    public event PropertyChangedEventHandler? PropertyChanged;

    protected void OnPropertyChanged([CallerMemberName] string? propertyName = null)
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

    public Rubros ToModel()
    {
        return new Rubros
        {
            Idrubro = Idrubro,
            Codrubro = Codrubro,
            Descripcion = Descripcion,
            Naturaleza = Naturaleza,
        };
    }

    public RubrosDto FromModel(Rubros? model)
    {
        return model is not null
            ? new RubrosDto(model.Idrubro, model.Codrubro, model.Descripcion, model.Naturaleza)
            : new RubrosDto();
    }

    public override string ToString()
    {
        return Descripcion;
    }
}