using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Blazor.Mvvm.FluentValidation
{
    public static class Startup
    {
        public static IServiceCollection AddFluentValidators(this IServiceCollection services, Assembly assembly)
        {
            var types = assembly.GetTypes().Where(x => typeof(IValidator).IsAssignableFrom(x));

            foreach (var validatorType in types)
            {
                var viewModelType = validatorType.BaseType.GenericTypeArguments.FirstOrDefault();
                services.AddTransient(typeof(IValidator<>).MakeGenericType(viewModelType), validatorType);
            }

            return services;
        }

        public static IServiceCollection AddFluentValidators(this IServiceCollection services, params Assembly[] assemblies)
        {
            foreach (var assembly in assemblies)            
                services.AddFluentValidators(assembly);
            
            return services;
        }
    }
}
