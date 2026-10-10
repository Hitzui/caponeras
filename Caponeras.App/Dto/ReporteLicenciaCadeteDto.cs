namespace Caponeras.App.Dto;

public sealed class ReporteLicenciaCadeteDto
{
    public string Cadete { get; set; } = string.Empty;
    public string Categoria { get; set; } = "—";
    public string NumeroLicencia { get; set; } = "—";
    public DateTime? FechaEmision { get; set; }
    public DateTime? FechaVencimiento { get; set; }
    public string EstadoLicencia { get; set; } = "Sin licencia";
}
