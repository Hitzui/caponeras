namespace Caponeras.App.Dto;

public class CategoriaProductoTreeDto : CategoriaProductoDto
{
    public List<CategoriaProductoTreeDto> Hijos { get; set; } = new();
}
