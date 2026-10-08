using Caponeras.App.Helpers;
using Caponeras.App.ViewModels;
using Caponeras.App.ViewModels.Agencia;
using Caponeras.App.ViewModels.Caja;
using Caponeras.App.ViewModels.CategoriaProductos;
using Caponeras.App.ViewModels.Compras;
using Caponeras.App.ViewModels.Conductores;
using Caponeras.App.ViewModels.Login;
using Caponeras.App.ViewModels.Mantenimiento;
using Caponeras.App.ViewModels.Mcaja;
using Caponeras.App.ViewModels.Productos;
using Caponeras.App.ViewModels.Proveedores;
using Caponeras.App.ViewModels.UnidadMedida;
using Caponeras.App.ViewModels.Vehiculo;
using Microsoft.Extensions.DependencyInjection;

namespace Caponeras.App.DI;

public static class ViewModelInjection
{
    //public static IServiceCollection AddViewModels(this IServiceCollection services)
    //{
    //    services.AddTransient<LoginViewModel>();
    //    services.AddTransient<MainViewModel>();
    //    services.AddTransient<AgenciaViewModel>();
    //    services.AddTransient<CajaViewModel>();
    //    services.AddTransient<ConductoresViewModel>();
    //    services.AddTransient<CadetesFormViewModel>();
    //    services.AddTransient<VehiculosViewModel>();
    //    services.AddTransient<VehiculoFormViewModel>();
    //    services.AddTransient<MantenimientoVehiculoViewModel>();
    //    services.AddTransient<RepuestosFormViewModel>();
    //    services.AddTransient<ProveedoreFormViewModel>();
    //    services.AddTransient<PaymentProveedorFormViewModel>();
    //    services.AddTransient<ProductosViewModel>();
    //    services.AddTransient<UnidadMedidaViewModel>();
    //    services.AddTransient<CategoriaProductosViewModel>();
    //    services.AddTransient<ProductosFormViewModel>();
    //    services.AddTransient<ICrudViewModel, ProductosViewModel>();
    //    services.AddTransient<ProveedoresViewModel>();
    //    services.AddTransient<ProveedoresFormViewModel>();
    //    services.AddTransient<ICrudViewModel, ProveedoresViewModel>();
    //    services.AddTransient<ICrudViewModel, ComprasViewModel>();
    //    services.AddTransient<ComprasViewModel>();
    //    services.AddTransient<ProductoDialogViewModel>();
    //    services.AddTransient<ComprasFormViewModel>();
    //    services.AddTransient<ProveedorDialogViewModel>();
    //    services.AddTransient<MaestroCajaViewModel>();
    //    services.AddTransient<AperturaCajaViewModel>();
    //    services.AddTransient<MovCajaViewModel>();
    //    services.AddTransient<ICrudViewModel, MovCajaViewModel>();
    //    services.AddTransient<PaymentCompraViewModel>();
    //    services.AddTransient<ProductoExtraInventariableViewModel>();
    //    services.AddTransient<RealizarMovimientoCajaViewModel>();
    //    services.AddTransient<AsignarVehiculoViewModel>();
    //    return services;
    //}

    public static IServiceCollection AddViewModels(this IServiceCollection services)
    {
        var assembly = typeof(ViewModelInjection).Assembly;

        var viewModels = assembly.GetTypes()
            .Where(t =>
                t.Name.EndsWith("ViewModel") &&
                t.IsClass &&
                !t.IsAbstract &&
                !t.IsGenericTypeDefinition)
            .ToList();

        foreach (var vm in viewModels)
        {
            services.AddTransient(vm);

            if (typeof(ICrudViewModel).IsAssignableFrom(vm))
                services.AddTransient(typeof(ICrudViewModel), vm);
        }

        return services;
    }

}
