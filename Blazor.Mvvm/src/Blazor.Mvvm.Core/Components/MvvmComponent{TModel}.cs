using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using Blazor.Mvvm.Core.Attributes;

namespace Blazor.Mvvm.Core.Components
{
    public class MvvmComponent<TModel> : MvvmComponent
    {
        private IServiceProvider serviceProvider;

        private TModel model;
        [Inject] public IServiceProvider ServiceProvider { get => serviceProvider; set { serviceProvider = value; AfterInjected(); } }

        [Parameter]
        public TModel Model
        {
            get => model;
            set
            {
                if (value == null)
                    serviceProvider.GetService<ILogger<MvvmComponent>>()?.LogInformation($"The type of {typeof(TModel).FullName} couldn't be resolved as Model of {GetType().FullName} from Dependency Injection.");

                model = value;
                // Observer Pattern: Listening ViewModel Changes:
                // TODO: Render entire component until solution of https://github.com/aspnet/AspNetCore/issues/6647
                if (value is INotifyPropertyChanged notifyable)
                    notifyable.PropertyChanged += (s, e) => StateHasChanged();
            }
        }

        async void AfterInjected()
        {
            if (this.Model == null && this.GetType().GetCustomAttribute<IgnoreModelInjectionAttribute>() == null)
                this.Model = this.ServiceProvider.GetService<TModel>();
        }
    }
}
