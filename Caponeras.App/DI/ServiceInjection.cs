using Caponeras.App.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Caponeras.App.DI;

public static class ServiceInjection
{
    public static IServiceCollection AddDomainServices(this IServiceCollection services)
    {
        var assembly = typeof(ServiceInjection).Assembly;

        var servicesToRegister = assembly.GetTypes()
            .Where(t =>
                (t.Name.EndsWith("Service")) &&
                t.IsClass &&
                !t.IsAbstract &&
                !t.IsGenericTypeDefinition)
            .ToList();

        foreach (var service in servicesToRegister)
            services.AddTransient(service);

        return services;
    }
}

