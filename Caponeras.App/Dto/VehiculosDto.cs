using Caponeras.Data.Models;

namespace Caponeras.App.Dto;

public class VehiculosDto
{
    public VehiculosDto()
    {
        Estado = @"ACTIVO";
        Idvehiculo = 0;
    }

    public VehiculosDto(Vehiculos? vehiculos)
    {
        if (vehiculos is null) return;
        Idagencia = vehiculos.Idagencia;
        Idvehiculo = vehiculos.Idvehiculo;
        Codigo = vehiculos.Codigo;
        Placa = vehiculos.Placa;
        Descripcion = vehiculos.Descripcion;
        Tipo = vehiculos.Tipo;
        Marca = vehiculos.Marca;
        Modelo = vehiculos.Modelo;
        Anio = vehiculos.Anio;
        Estado = vehiculos.Estado;
        KmActual = vehiculos.KmActual ?? 0m;
        Observaciones = vehiculos.Observaciones;
        CreatedAt = vehiculos.CreatedAt;
        UpdatedAt = vehiculos.UpdatedAt;
    }

    public int Idvehiculo { get; set; }

    public string? Codigo { get; set; }

    public string? Placa { get; set; }

    public string? Descripcion { get; set; }

    public string? Tipo { get; set; }

    public string? Marca { get; set; }

    public string? Modelo { get; set; }

    public int? Anio { get; set; }

    public int? Idagencia { get; set; }

    public string Estado { get; set; }

    public decimal KmActual { get; set; } = 0m;

    public string? Observaciones { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public Vehiculos GetVehiclo()
    {
        return new Vehiculos
        {
            Idvehiculo = Idvehiculo,
            Codigo = Codigo ?? string.Empty,
            Placa = Placa ?? string.Empty,
            Descripcion = Descripcion ?? string.Empty,
            Tipo = Tipo ?? string.Empty,
            Marca = Marca ?? string.Empty,
            Modelo = Modelo ?? string.Empty,
            Anio = Anio,
            Idagencia = Idagencia,
            Estado = Estado,
            KmActual = KmActual,
            Observaciones = Observaciones ?? string.Empty,
            CreatedAt = CreatedAt,
            UpdatedAt = UpdatedAt
        };
    }
}