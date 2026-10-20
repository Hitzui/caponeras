namespace Caponeras.App.Dto;

public sealed class ReporteMantenimientoDto
{
    public int Id { get; set; }
    public string Caponera { get; set; } = string.Empty;
    public string Placa { get; set; } = string.Empty;
    public string TipoMantenimiento { get; set; } = string.Empty;
    public string Titulo { get; set; } = string.Empty;
    public DateTime FechaInicio { get; set; }
    public DateTime FechaFin { get; set; }
    public string? Descripcion { get; set; }
    public string? Observaciones { get; set; }
    public string Estado { get; set; } = string.Empty;
}
