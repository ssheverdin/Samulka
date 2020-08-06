using System;
using System.IO;
using System.Linq;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Primitives;
using NetCoreConsoleExtensions;

namespace SharpScriptRunner
{
    class Program
    {


        static void Main(string[] args)
        {


            ServiceProvider serviceProvider = Startup.Configure(
                Path.Combine(Directory.GetCurrentDirectory(), @"..\..\..\"),
                services =>
                {
                    services.AddSingleton<ISharpScriptConsoleContainer, SharpScriptConsoleContainer>();
                }
            );

            var service = serviceProvider.GetService<ISharpScriptConsoleContainer>();
            service.Run(args.ToList());
            DisposeServices(serviceProvider);
        }

        private static void DisposeServices(ServiceProvider serviceProvider)
        {
            if (serviceProvider == null)
            {
                return;
            }
            if (serviceProvider is IDisposable)
            {
                ((IDisposable)serviceProvider).Dispose();
            }
        }
    }
}
