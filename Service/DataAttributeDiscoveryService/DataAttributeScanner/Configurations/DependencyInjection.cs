using System;
using System.Collections.Generic;
using System.Text;
using DataAttributeScannerLogic.Services;
using DataAttributeScannerLogic.Services.Implementations;
using DataUnitOfWork;
using MetadataDiscoveryService;
using MetadataStoreDataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace DataAttributeScannerLogic.Configurations
{
    public static class DependencyInjection
    {
        public static void AddDataAttributeScannerModule(this IServiceCollection services, string connectionToMetadataStore)
        {
            services.AddDbContext<MetadataStoreContext>(options => options.UseSqlServer(connectionToMetadataStore));
            services.AddUnitOfWork<MetadataStoreContext>();
            services.AddScoped<IMetadataDiscoveryService, MetadataDiscovery>();
            services.AddScoped<IMetadataService, MetadataService>();
        }

    }
}
