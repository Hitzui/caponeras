using Caponeras.Data.Models;

namespace Caponeras.App.Dto;

public class CajaDto
{
    public CajaDto()
    {
        Codcaja = string.Empty;
        Descripcion = string.Empty;
    }
    public CajaDto(int idcaja, string codcaja, string descripcion, int idagencia, AgenciaDto? agencias=null)
    {
        Idcaja = idcaja;
        Codcaja = codcaja;
        Descripcion = descripcion;
        Idagencia = idagencia;
        Agencias = agencias;
    }

    public int Idcaja { get; set; }

    public string Codcaja { get; set; }

    public string Descripcion { get; set; }

    public int? Idagencia { get; set; }

    public AgenciaDto? Agencias { get; set; }
}