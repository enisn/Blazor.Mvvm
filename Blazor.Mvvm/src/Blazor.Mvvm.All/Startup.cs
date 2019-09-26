using Blazor.Mvvm.Caching;
using Blazor.Mvvm.FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Blazor.Mvvm
{
    public static class Startup
    {
        public static IServiceCollection AddBlazorMvvm(this IServiceCollection services, params Assembly[] assembliesForFluentValidation)
        {
            if (assembliesForFluentValidation == null || assembliesForFluentValidation.Length == 0)
                assembliesForFluentValidation = new[] { Assembly.GetExecutingAssembly() };

            return services
                .AddBlazorMvvmCore()
                .AddBlazorMvvmCaching()
                .AddFluentValidators(assembliesForFluentValidation);
        }
    }
}
