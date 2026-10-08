namespace Caponeras.App.Dto;


public class ReporteCuotaDto
{
    public string Zona { get; set; }
    public string Cadete { get; set; }
    public string Codigo { get; set; }
    public string Placa { get; set; }
    public int Dias { get; set; }
    public decimal CuotaEsperada { get; set; }
    public decimal TotalEntregado { get; set; }

    public decimal Saldo => CuotaEsperada - TotalEntregado;

    public decimal PorcentajeCumplimiento =>
        CuotaEsperada == 0
            ? 0
            : Math.Round((TotalEntregado / CuotaEsperada) * 100, 2);
}