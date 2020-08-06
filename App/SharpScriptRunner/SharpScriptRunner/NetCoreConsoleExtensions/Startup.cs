using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace NetCoreConsoleExtensions
{
    public static class Startup
    {
        public static ServiceProvider Configure(string appSettingsJsonPath, Action<IServiceCollection> serviceConfigurations )
        {
            string applicationRootPath = Path.GetFullPath(appSettingsJsonPath);

            IConfigurationBuilder configurationBuilder = new ConfigurationBuilder()
                .SetBasePath(applicationRootPath)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
                //.AddUserSecrets<Program>()
                //.AddEnvironmentVariables();

            IConfigurationRoot configurationRoot = configurationBuilder.Build();

            var serviceProvider = new ServiceCollection()
                .AddLogging(cfg => cfg.AddConsole())
                .Configure<LoggerFilterOptions>(cfg => cfg.MinLevel = LogLevel.Debug)
                .AddSingleton(configurationRoot);
            
            serviceConfigurations?.Invoke(serviceProvider);

            return serviceProvider.BuildServiceProvider();
        }
    }
}
