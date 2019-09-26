using Blazor.Mvvm.Core.Abstractions.Design;
using Blazor.Mvvm.Core.Abstractions.Web;
using Blazor.Mvvm.Web.Implementations;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blazor.Mvvm.Web
{
    public static class Startup
    {
        public static IServiceCollection AddBlazorMvvmWeb(this IServiceCollection services, ServiceLifetime lifetime= ServiceLifetime.Singleton)
        {
            services.Add(new ServiceDescriptor(typeof(ILayoutModifier), typeof(LayoutModifier), lifetime));
            services.Add(new ServiceDescriptor(typeof(IUtilitiesService), typeof(UtilitiesService), lifetime));
            
            return services;
        }
    }
}
