namespace Caponeras.App.Dto;

public sealed class AusenciaCadeteDto
{
    public int Id { get; set; }
    public int Idconductor { get; set; }
    public string Cadete { get; set; } = string.Empty;
    public DateTime Fecha { get; set; }
    public string Motivo { get; set; } = string.Empty;
    public string? Detalle { get; set; }
    public int? Idvehiculo { get; set; }
    public int? Idzona { get; set; }
    public string? CodigoVehiculo { get; set; }
    public string? Placa { get; set; }
    public string? Zona { get; set; }
    public string Vehiculo => string.IsNullOrWhiteSpace(CodigoVehiculo)
        ? "Sin asignación"
        : $"{CodigoVehiculo}{(string.IsNullOrWhiteSpace(Placa) ? "" : $" · {Placa}")}";
}
