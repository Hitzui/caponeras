using Caponeras.Data.Models;
using DevExpress.XtraEditors.DXErrorProvider;

namespace Caponeras.App.Dto;

public class UnidadMedidaDto : IDXDataErrorInfo
{
    public int IdUnidad { get; set; }

    public string Nombre { get; set; }

    public string Simbolo { get; set; }

    public bool? Activo { get; set; }

    /* ===========================
       MAPEO MODEL → DTO
       =========================== */
    public static UnidadMedidaDto FromModel(UnidadesMedidas model)
    {
        if (model == null) return null;

        return new UnidadMedidaDto
        {
            IdUnidad = model.IdUnidad,
            Nombre = model.Nombre,
            Simbolo = model.Simbolo,
            Activo = model.Activo
        };
    }

    /* ===========================
       MAPEO DTO → MODEL
       =========================== */
    public UnidadesMedidas ToModel(UnidadesMedidas? model = null)
    {
        model ??= new UnidadesMedidas();

        model.IdUnidad = this.IdUnidad;
        model.Nombre = this.Nombre;
        model.Simbolo = this.Simbolo;
        model.Activo = this.Activo;

        return model;
    }

    public override string ToString()
    {
        return Simbolo;
    }

    // Implements the IDXDataErrorInfo.GetPropertyError method.
    public void GetPropertyError(string propertyName, ErrorInfo info)
    {
        if (propertyName == "Nombre" && Nombre == "" ||
            propertyName == "Simbolo" && Simbolo == "")
        {
            info.ErrorText = String.Format("The '{0}' field cannot be empty", propertyName);
        }
    }
    // IDXDataErrorInfo.GetError method
    public void GetError(ErrorInfo info) { }
}
