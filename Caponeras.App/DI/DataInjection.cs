using System.Net.Http;
using Caponeras.App.Helpers;

namespace Caponeras.App.DI;

using Caponeras.Data.Models;
using Microsoft.Extensions.DependencyInjection;

public static class DataInjection
{
    public static IServiceCollection AddData(this IServiceCollection services)
    {
        services.AddScoped<DataContextCaponeras>();
        services.ConfigureDbContext<DataContextCaponeras>(options =>
            options.EnableSensitiveDataLogging()
                .EnableDetailedErrors());
        services.AddSingleton<ISelectionService, SelectionService>();
        services.AddSingleton<INavigationService, NavigationService>();
        services.AddSingleton<HttpClient>();
        return services;
    }
}
