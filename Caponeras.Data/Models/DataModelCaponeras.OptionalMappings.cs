using Microsoft.EntityFrameworkCore;

namespace Caponeras.Data.Models;

public partial class DataContextCaponeras
{
    partial void CustomizeAseguradorasMapping(ModelBuilder modelBuilder)
    {
        var aseguradoras = modelBuilder.Entity<Aseguradoras>();
        aseguradoras.Property(a => a.NombreCorto).IsRequired(false);
        aseguradoras.Property(a => a.Telefono).IsRequired(false);
        aseguradoras.Property(a => a.Correo).IsRequired(false);
        aseguradoras.Property(a => a.SitioWeb).IsRequired(false);
        aseguradoras.Property(a => a.Direccion).IsRequired(false);
    }
}
