namespace Caponeras.App.Dto;

public record CuotaDetalleDto(
    DateTime Fecha,
    string Codigo,
    string Placa,
    decimal MontoCuota,
    decimal MontoEntregado,
    decimal Diferencia,
    decimal Porcentaje,
    string Conductor
);