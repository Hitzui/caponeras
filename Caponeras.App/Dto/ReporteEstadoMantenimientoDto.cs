namespace Caponeras.App.Dto;

public sealed class ReporteEstadoMantenimientoDto
{
    public string Caponera { get; set; } = string.Empty;
    public string Placa { get; set; } = string.Empty;
    public string TipoMantenimiento { get; set; } = string.Empty;
    public string Trabajo { get; set; } = string.Empty;
    public DateTime FechaInicio { get; set; }
    public DateTime FechaFin { get; set; }
    public string Estado { get; set; } = "Sin estado";
    public string? Descripcion { get; set; }
    public string? Observaciones { get; set; }
}
