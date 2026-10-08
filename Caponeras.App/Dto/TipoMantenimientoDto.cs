namespace Caponeras.App.Dto;

public class TipoMantenimientoDto
{

    public int Idtipomantenimiento { get; set; }

    public string Nombre { get; set; }

    public string Tipo { get; set; }

    public decimal? FrecuenciaKm { get; set; }

    public int? FrecuenciaMeses { get; set; }

    public string? Descripcion { get; set; }
}