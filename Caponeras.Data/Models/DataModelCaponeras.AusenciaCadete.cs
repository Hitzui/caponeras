using Microsoft.EntityFrameworkCore;

namespace Caponeras.Data.Models;

public sealed class AusenciaCadete
{
    public int Id { get; set; }
    public int Idconductor { get; set; }
    public DateTime Fecha { get; set; }
    public string Motivo { get; set; } = string.Empty;
    public string? Detalle { get; set; }
    public int? Idvehiculo { get; set; }
    public int? Idzona { get; set; }
    public string? CodigoVehiculo { get; set; }
    public string? Placa { get; set; }
    public string? Zona { get; set; }
    public DateTime CreadoEn { get; set; }
}

public partial class DataContextCaponeras
{
    public DbSet<AusenciaCadete> AusenciasCadetes => Set<AusenciaCadete>();

    partial void CustomizeMapping(ref ModelBuilder modelBuilder)
    {
        var ausencia = modelBuilder.Entity<AusenciaCadete>();
        ausencia.ToTable("ausencia_cadete", "caponeras");
        ausencia.HasKey(x => x.Id);
        ausencia.HasIndex(x => new { x.Idconductor, x.Fecha }).IsUnique();
        ausencia.Property(x => x.Id).HasColumnName("id").HasColumnType("int").ValueGeneratedOnAdd();
        ausencia.Property(x => x.Idconductor).HasColumnName("idconductor").HasColumnType("int").IsRequired();
        ausencia.Property(x => x.Fecha).HasColumnName("fecha").HasColumnType("date").IsRequired();
        ausencia.Property(x => x.Motivo).HasColumnName("motivo").HasColumnType("varchar(100)").HasMaxLength(100).IsRequired();
        ausencia.Property(x => x.Detalle).HasColumnName("detalle").HasColumnType("text").IsRequired(false);
        ausencia.Property(x => x.Idvehiculo).HasColumnName("idvehiculo").HasColumnType("int").IsRequired(false);
        ausencia.Property(x => x.Idzona).HasColumnName("idzona").HasColumnType("int").IsRequired(false);
        ausencia.Property(x => x.CodigoVehiculo).HasColumnName("codigo_vehiculo").HasColumnType("varchar(50)").HasMaxLength(50).IsRequired(false);
        ausencia.Property(x => x.Placa).HasColumnName("placa").HasColumnType("varchar(50)").HasMaxLength(50).IsRequired(false);
        ausencia.Property(x => x.Zona).HasColumnName("zona").HasColumnType("varchar(255)").HasMaxLength(255).IsRequired(false);
        ausencia.Property(x => x.CreadoEn).HasColumnName("creado_en").HasColumnType("datetime").HasDefaultValueSql("CURRENT_TIMESTAMP");
    }
}
