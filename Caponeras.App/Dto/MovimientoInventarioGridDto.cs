using Caponeras.Data.Models;

namespace Caponeras.App.Dto;

public sealed record MovimientoInventarioGridDto(
    int Idmovimiento,
    DateTime Fecha,
    string Producto,
    TipoMovimiento Tipo,
    decimal Entrada,
    decimal Salida,
    decimal StockAnterior,
    decimal StockNuevo,
    string Referencia,
    ReferenciaInventario ReferenciaInventario,
    string Usuario,
    string Observaciones
);