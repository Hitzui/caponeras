using System.ComponentModel;
using System.Runtime.CompilerServices;
using Caponeras.Data.Models;

namespace Caponeras.App.Dto
{
    public class MovCajasDto : INotifyPropertyChanged
    {
        private string _descripcion;
        private int _idmovcaja;
        private int _idrubro;
        private RubrosDto? _rubros;

        public MovCajasDto()
        {
            _idmovcaja = 0;
            _descripcion = string.Empty;
            _idrubro = 0;
        }

        public MovCajasDto(MovCajas model)
        {
            _idmovcaja = model.Idmovcaja;
            _descripcion = model.Descripcion;
            _idrubro = model.Idrubro;
            _rubros = new RubrosDto().FromModel(model.Rubros);
        }
        public MovCajasDto(int idmovcaja, string descripcion, int idrubro, RubrosDto rubros)
        {
            _idmovcaja = idmovcaja;
            _descripcion = descripcion;
            _idrubro = idrubro;
            _rubros = rubros;
        }

        public MovCajas ToModel()
        {
            return new MovCajas
            {
                Idmovcaja = Idmovcaja,
                Descripcion = Descripcion,
                Idrubro = Idrubro,
                Rubros = new RubrosDto().ToModel()
            };
        }

        public MovCajasDto FromModel(MovCajas model)
        {
            return new MovCajasDto
            {
                Idmovcaja = model.Idmovcaja,
                Descripcion = model.Descripcion,
                Idrubro = model.Idrubro,
                Rubros = new RubrosDto().FromModel(model.Rubros)
            };
        }

        public int Idmovcaja
        {
            get => _idmovcaja;
            set => SetField(ref _idmovcaja, value);
        }

        public string Descripcion
        {
            get => _descripcion;
            set => SetField(ref _descripcion, value);
        }

        public int Idrubro
        {
            get => _idrubro;
            set => SetField(ref _idrubro, value);
        }

        public RubrosDto? Rubros
        {
            get => _rubros;
            set => SetField(ref _rubros, value);
        }

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
    }
}