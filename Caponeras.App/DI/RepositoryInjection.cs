using Caponeras.Insfraestructura.Repository;
using Microsoft.Extensions.DependencyInjection;

namespace Caponeras.App.DI;

public static class RepositoryInjection
{
    public static IServiceCollection AddRepositories(this IServiceCollection services)
    {
        services.AddScoped<IAgenciaRepository, AgenciaRepository>();
        services.AddScoped<ICajaRepository, CajaRepository>();
        services.AddScoped<IMantenimientoLabelRepository, MantenimientoLabelRepository>();
        services.AddScoped<IConductorRpository, ConductorRpository>();
        services.AddScoped<IVehiculoRepository, VehiculoRepository>();
        services.AddScoped<ITipoMantenimientoRepository, TipoMantenimientoRepository>();
        services.AddScoped<IMantenimientoStatusRepository, MantenimientoStatusRepository>();
        services.AddScoped<IMantenimietoRepository, MantenimientoRepository>();
        services.AddScoped<IMantenimientoRepuestosRepository, MantenimientoRepuestosRepository>();
        services.AddScoped<IProductoRepository, ProductoRepository>();
        services.AddScoped<IUnidadMedidaRepository, UnidadMedidaRepository>();
        services.AddScoped<ICategoriaProductosRepository, CategoriaProductosRepository>();
        services.AddScoped<IMovimientoInventarioRepository, MovimientoInventarioRepository>();
        services.AddScoped<IProveedorRepository, ProveedorRepository>();
        return services;
    }
}
