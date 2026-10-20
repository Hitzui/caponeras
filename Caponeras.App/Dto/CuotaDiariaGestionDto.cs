using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Caponeras.App.Dto;

public sealed class CuotaDiariaGestionDto : INotifyPropertyChanged
{
    private decimal _montoCuota;
    private decimal _montoEntregado;
    private decimal _montoPago;

    public int IdConductor { get; set; }
    public string Nombre { get; set; } = string.Empty;
    public string Identificacion { get; set; } = string.Empty;
    public string? Placa { get; set; }
    public string? Zona { get; set; }
    public int IdVehiculo { get; set; }
    public int? IdCuotaDiaria { get; set; }
    public decimal MontoCuota
    {
        get => _montoCuota;
        set
        {
            if (_montoCuota == value) return;
            _montoCuota = value;
            OnPropertyChanged();
            OnPropertyChanged(nameof(Diferencia));
        }
    }

    public decimal MontoEntregado
    {
        get => _montoEntregado;
        set
        {
            if (_montoEntregado == value) return;
            _montoEntregado = value;
            OnPropertyChanged();
            OnPropertyChanged(nameof(Diferencia));
        }
    }

    public decimal Diferencia => MontoCuota - MontoEntregado;
    public decimal MontoPago
    {
        get => _montoPago;
        set
        {
            if (_montoPago == value) return;
            _montoPago = value;
            OnPropertyChanged();
        }
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    private void OnPropertyChanged([CallerMemberName] string? propertyName = null) =>
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
}
