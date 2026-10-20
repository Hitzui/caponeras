namespace Caponeras.App.Dto;

public sealed class ReporteCostoRepuestoDto
{
    public DateTime FechaMantenimiento { get; set; }
    public string Caponera { get; set; } = string.Empty;
    public string Placa { get; set; } = string.Empty;
    public string Trabajo { get; set; } = string.Empty;
    public string Repuesto { get; set; } = string.Empty;
    public string Origen { get; set; } = string.Empty;
    public decimal Cantidad { get; set; }
    public decimal CostoUnitario { get; set; }
    public decimal CostoTotal { get; set; }
}
