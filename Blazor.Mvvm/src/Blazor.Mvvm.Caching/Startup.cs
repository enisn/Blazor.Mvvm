using Blazor.Extensions.Storage;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blazor.Mvvm.Caching
{
    public static class Startup
    {
        public static IServiceCollection AddBlazorMvvmCaching(this IServiceCollection services)
        {
            return services.AddStorage();
        }
    }
}
