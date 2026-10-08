using Caponeras.App.DI;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using NLog;
using System.Globalization;
using Caponeras.App.Views;
using Caponeras.App.Views.Login;

namespace Caponeras.App;

internal static class Program
{
    [STAThread]
    private static void Main()
    {
        var logger = LogManager.GetCurrentClassLogger();
        Thread.CurrentThread.CurrentCulture = new CultureInfo("es-NI");
        Thread.CurrentThread.CurrentUICulture = new CultureInfo("es-NI");

        ApplicationConfiguration.Initialize();

        var host = Host.CreateDefaultBuilder()
            .ConfigureServices((context, services) =>
            {
                services
                    .AddData()
                    .AddRepositories()
                    .AddDomainServices()
                    .AddViewModels()
                    .AddViews();
            })
            .Build();

        try
        {
            host.Start();

            using var scope = host.Services.CreateScope();
            var services = scope.ServiceProvider;

            var login = services.GetRequiredService<LoginView>();

            // Si el login es exitoso, ejecutar la aplicación
            if (login.ShowDialog() == DialogResult.OK && login.LoginSuccess)
            {
                var main = services.GetRequiredService<MainView>();
                Application.Run(main);
            }
            // Si no hay login exitoso, la aplicación termina aquí
        }
        catch (Exception e)
        {
            logger.Error(e, "Error en la aplicación");
            MessageBox.Show($"Error crítico: {e.Message}", "Error", 
                MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        finally
        {
            // ✅ Asegurar que el host se detenga correctamente
            host.StopAsync().GetAwaiter().GetResult();
            host.Dispose();
        }
    }
}