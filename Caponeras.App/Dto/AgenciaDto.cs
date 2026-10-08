using Caponeras.Data.Models;

namespace Caponeras.App.Dto;

public class AgenciaDto
{
    public AgenciaDto()
    {
        Codagencia = string.Empty;
        Descripcion = string.Empty;
        Ruc = string.Empty;
    }

    public AgenciaDto(Agencias agencias)
    {
        Idagencia = agencias.Idagencia;
        Codagencia = agencias.Codagencia;
        Descripcion = agencias.Descripcion;
        Ruc = agencias.Ruc;
        Activio = agencias.Activio ?? false;
    }
    public int Idagencia { get; set; }

    public string Codagencia { get; set; }

    public string Descripcion { get; set; }

    public string Ruc { get; set; }

    public bool Activio { get; set; }

    public override string ToString()
    {
        return Descripcion;
    }
}