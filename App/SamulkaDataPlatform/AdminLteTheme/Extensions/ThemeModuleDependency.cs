using Blazored.SessionStorage;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace AdminLteTheme.Extensions
{
    public static class ThemeModuleDependency
    {
        public static void AddAdminLteThemeModule(this IServiceCollection services)
        {
            services.AddBlazoredSessionStorage();
            //services.AddScoped<IStateService, StateService>();
        }
    }
}
