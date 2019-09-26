using Blazor.Mvvm.Core.Abstractions.Design;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using Blazor.Mvvm.Web;
using Microsoft.AspNetCore.Components.Builder;
using Toolbelt.Blazor.Extensions.DependencyInjection;

namespace Blazor.Mvvm
{
    public static class Startup
    {
        public static IServiceProvider ServiceProvider { get; private set; }
        public static IServiceCollection AddBlazorMvvmCore(this IServiceCollection services)
        {
            services.AddHotKeys();
            services.AddBlazorMvvmWeb();
            return services;
        }

        public static IComponentsApplicationBuilder ConfigureBlazorMvvmCore(this IComponentsApplicationBuilder app)
        {
            ServiceProvider = app.Services;
            return app;
        }
    }
}
