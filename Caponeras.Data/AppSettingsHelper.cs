namespace Caponeras.Data;

using Microsoft.Extensions.Configuration;

public class AppSettingsHelper
{
    private readonly IConfiguration _configuration;

    public AppSettingsHelper()
    {
        var exePath = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
        //var appSettingsPath = Path.Combine(exePath, "appsettings.json");
        _configuration = new ConfigurationBuilder()
            .SetBasePath(exePath)
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
            .Build();
    }

    public string GetConnectionString(string name)
    {
        return _configuration.GetConnectionString(name);
    }

    public string GetSetting(string key)
    {
        return _configuration[key];
    }

}