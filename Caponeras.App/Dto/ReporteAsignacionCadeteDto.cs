namespace Caponeras.App.Dto;

public class ReporteAsignacionCadeteDto
{
    public int IdConductor { get; set; }
    public int IdVehiculo { get; set; }
    public string GrupoAsignacion => $"{IdConductor}:{IdVehiculo}";
    public string Zona { get; set; } = "";
    public string Cadete { get; set; } = "";
    public string Identificacion { get; set; } = "";
    public string Codigo { get; set; } = "";
    public string Placa { get; set; } = "";
    public DateTime FechaInicio { get; set; }
    public DateTime? FechaFin { get; set; }
}
