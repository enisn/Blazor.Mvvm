using Microsoft.AspNetCore.Components.Builder;
using Microsoft.Extensions.DependencyInjection;
using Blazor.Mvvm;
using Toolbelt.Blazor.Extensions.DependencyInjection;

namespace MyBlazorApp
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddI18nText<Startup>();

            services.AddBlazorMvvm();

            services.AddTransient<ViewModels.IndexViewModel>();
            services.AddTransient<ViewModels.FetchDataViewModel>();
        }

        public void Configure(IComponentsApplicationBuilder app)
        {
            app.AddComponent<App>("app");
        }
    }
}
