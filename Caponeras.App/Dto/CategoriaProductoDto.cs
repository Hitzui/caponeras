using Caponeras.Data.Models;

namespace Caponeras.App.Dto;

public class CategoriaProductoDto
{
    public CategoriaProductoDto()
    {
        IdCategoria = 0;
        Nombre = string.Empty;
        Descripcion = string.Empty;
        Activo = true;
    }
    public int IdCategoria { get; set; }

    public string Nombre { get; set; }

    public string Descripcion { get; set; }

    public int? IdCategoriaPadre { get; set; }

    public bool Activo { get; set; }

    /* ===========================
       MAPEO MODEL → DTO
       =========================== */
    public static CategoriaProductoDto FromModel(CategoriasProductos model)
    {
        if (model == null) return null;

        return new CategoriaProductoDto
        {
            IdCategoria = model.IdCategoria,
            Nombre = model.Nombre,
            Descripcion = model.Descripcion,
            IdCategoriaPadre = model.IdCategoriaPadre,
            Activo = model.Activo ?? false
        };
    }

    /* ===========================
       MAPEO DTO → MODEL
       =========================== */
    public CategoriasProductos ToModel(CategoriasProductos model = null)
    {
        model ??= new CategoriasProductos();

        model.IdCategoria = this.IdCategoria;
        model.Nombre = this.Nombre;
        model.Descripcion = this.Descripcion;
        model.IdCategoriaPadre = this.IdCategoriaPadre;
        model.Activo = this.Activo;

        return model;
    }

    public override string ToString()
    {
        return Descripcion;
    }
}
