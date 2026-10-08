using Caponeras.Data.Models;

namespace Caponeras.App.Dto;

public class ComprasDto
{
    public int Idcompra { get; set; }

    public DateTime Fecha { get; set; }

    public string NumeroDocumento { get; set; }

    public int? Idproveedor { get; set; }

    public decimal Total { get; set; }

    public decimal Subtotal { get; set; }

    public decimal Iva { get; set; }

    public int? CreatedBy { get; set; }

    public DateTime CreatedAt { get; set; }

    public int? UpdatedBy { get; set; }

    public DateTime UpdatedAt { get; set; }

    public EstadoCompra Estado { get; set; }

    public string NombreProveedor { get; set; } = string.Empty;

    public ProveedoresDto Proveedores { get; set; }

    public ComprasDto()
    {
        Idcompra = 0;
        NumeroDocumento = string.Empty;
        Proveedores = new ProveedoresDto();
    }
    public ComprasDto(Compras compraModel)
    {
        Idcompra = compraModel.Idcompra;
        Fecha = compraModel.Frecha;
        NumeroDocumento = compraModel.NumeroDocumento;
        Idproveedor = compraModel.Idproveedor;
        Total = compraModel.Total;
        Subtotal = compraModel.Subtotal;
        Iva = compraModel.Iva;
        CreatedBy = compraModel.CreatedBy;
        CreatedAt = compraModel.CreatedAt;
        UpdatedBy = compraModel.UpdatedBy;
        UpdatedAt = compraModel.UpdatedAt;
        Estado = compraModel.Estado;
        NombreProveedor = compraModel.Proveedores.Nombre;
        Proveedores = ProveedoresDto.FromEntity(compraModel.Proveedores);
    }

    public Compras ToModel()
    {
        return new Compras
        {
            Idcompra = Idcompra,
            Frecha = Fecha,
            NumeroDocumento = NumeroDocumento,
            Idproveedor = Idproveedor,
            Total = Total,
            Subtotal = Subtotal,
            Iva = Iva,
            CreatedBy = CreatedBy,
            CreatedAt = CreatedAt,
            UpdatedBy = UpdatedBy,
            UpdatedAt = UpdatedAt,
            Estado = EstadoCompra.Anulada,
            Proveedores = ProveedoresDto.ToEntity(Proveedores)
        };
    }
}