using Caponeras.Data.Models;

namespace Caponeras.App.Dto;

public class MantenimientoRepuestoDto
{
    public int IdMantenimientoRepuestos { get; set; }

    public int IdMantenimiento { get; set; }

    public int IdProducto { get; set; }

    public decimal Cantidad { get; set; }

    public int IdUnidadMedida { get; set; }

    public string? Observaciones { get; set; }

    // Datos UI
    public string? ProductoNombre { get; set; }

    public string? UnidadMedidaNombre { get; set; }

    public string? UnidadMedidaSimbolo { get; set; }

    public decimal? StockDisponible { get; set; }

    // ===============================
    // MODEL -> DTO
    // ===============================
    public static MantenimientoRepuestoDto FromModel(MantenimientoRepuestos model)
    {
        if (model == null)
            throw new ArgumentNullException(nameof(model));

        return new MantenimientoRepuestoDto
        {
            IdMantenimientoRepuestos = model.Idmantenimientorepuestos,
            IdMantenimiento = model.Idmantenimiento,
            IdProducto = model.Idproducto,
            Cantidad = model.Cantidad,
            IdUnidadMedida = model.IdUnidadMedida,
            Observaciones = model.Observaciones,

            ProductoNombre = model.Productos?.Nombre,
            UnidadMedidaNombre = model.UnidadesMedidas?.Nombre,
            UnidadMedidaSimbolo = model.UnidadesMedidas?.Simbolo
        };
    }

    // ===============================
    // DTO -> MODEL (nuevo)
    // ===============================
    public MantenimientoRepuestos ToModel()
    {
        return new MantenimientoRepuestos
        {
            Idmantenimientorepuestos = IdMantenimientoRepuestos,
            Idmantenimiento = IdMantenimiento,
            Idproducto = IdProducto,
            Cantidad = Cantidad,
            IdUnidadMedida = IdUnidadMedida,
            Observaciones = Observaciones ?? string.Empty
        };
    }

    // ===============================
    // DTO -> MODEL (update)
    // ===============================
    public void UpdateModel(MantenimientoRepuestos model)
    {
        model.Idmantenimiento = IdMantenimiento;
        model.Idproducto = IdProducto;
        model.Cantidad = Cantidad;
        model.IdUnidadMedida = IdUnidadMedida;
        model.Observaciones = Observaciones ?? string.Empty;
    }
}

