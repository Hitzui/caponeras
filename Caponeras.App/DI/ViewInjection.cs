using Microsoft.Extensions.DependencyInjection;

namespace Caponeras.App.DI;

public static class ViewInjection
{
    //public static IServiceCollection AddViews(this IServiceCollection services)
    //{
    //    services.AddTransient<LoginView>();
    //    services.AddTransient<MainView>();
    //    services.AddTransient<AgenciaView>();
    //    services.AddTransient<CajaView>();
    //    services.AddTransient<ConductoresView>();
    //    services.AddTransient<CadeteFormView>();
    //    services.AddTransient<VehiculosView>();
    //    services.AddTransient<VehiculosFormView>();
    //    services.AddTransient<MantenimientoVehiculoView>();
    //    services.AddTransient<RepuestosFormView>();
    //    services.AddTransient<ProveedoreFormView>();
    //    services.AddTransient<ProductosView>();
    //    services.AddTransient<ProductosFormView>();
    //    services.AddTransient<UnidadMedidaView>();
    //    services.AddTransient<CategoriaProductosView>();
    //    services.AddTransient<ProveedoresView>();
    //    services.AddTransient<ProveedoresFormView>();
    //    services.AddTransient<PaymentProveedorFormView>();
    //    services.AddTransient<ComprasView>();
    //    services.AddTransient<ComprasFormView>();
    //    services.AddTransient<ProductoDialogView>();
    //    services.AddTransient<ProveedorDialogView>();
    //    services.AddTransient<MaestroCajaView>();
    //    services.AddTransient<AperturaCajaView>();
    //    services.AddTransient<MovCajaView>();
    //    services.AddTransient<MovCajaFormView>();
    //    services.AddTransient<PaymentCompraView>();
    //    services.AddTransient<ProductoExtraInventariableFormView>();
    //    services.AddTransient<RealizarMovimientoCajaFormView>();
    //    services.AddTransient<AsignarVehiculoFormView>();
    //    return services;
    //}

    public static IServiceCollection AddViews(this IServiceCollection services)
    {
        var assembly = typeof(ViewInjection).Assembly;

        var viewModels = assembly.GetTypes()
            .Where(t =>
                t.Name.EndsWith("View") &&
                t.IsClass &&
                !t.IsAbstract &&
                !t.IsGenericTypeDefinition)
            .ToList();

        foreach (var vm in viewModels)
        {
            services.AddTransient(vm);
        }

        return services;
    }

}
