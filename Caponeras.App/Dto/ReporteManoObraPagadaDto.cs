namespace Caponeras.App.Dto;

public sealed class ReporteManoObraPagadaDto
{
    public DateTime FechaPago { get; set; }
    public string Caponera { get; set; } = string.Empty;
    public string Placa { get; set; } = string.Empty;
    public string Trabajo { get; set; } = string.Empty;
    public string Proveedor { get; set; } = string.Empty;
    public decimal MontoPagado { get; set; }
}
