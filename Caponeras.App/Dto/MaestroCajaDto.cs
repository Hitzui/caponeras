using Caponeras.Data.Models;

namespace Caponeras.App.Dto;

public record MaestroCajaDto(
    int IdMaestroCaja,
    int IdCaja,
    decimal SaldoInicial,
    decimal Entradas,
    decimal Salidas,
    decimal SaldoFinal,
    DateTime Fecha,
    EstadoCaja Estado)
{
    public MaestroCajas ToEntity()
    {
        return new MaestroCajas
        {
            Idmaestrocaja = IdMaestroCaja,
            Idcaja = IdCaja,
            SaldoInicial = SaldoInicial,
            Entradas = Entradas,
            Salidas = Salidas,
            SaldoFinal = SaldoFinal,
            Fecha = Fecha,
            Estado = Estado
        };
    }

    public MaestroCajaDto(MaestroCajas entity) : this(
        entity.Idmaestrocaja,
        entity.Idcaja ?? 0,
        entity.SaldoInicial,
        entity.Entradas,
        entity.Salidas,
        entity.SaldoFinal,
        entity.Fecha,
        entity.Estado)
    {
    }
}