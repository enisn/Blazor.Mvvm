using Microsoft.AspNetCore.Components;
using System;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using System.Web;
using Blazor.Mvvm.Core.Attributes;

namespace Blazor.Mvvm.Core.ViewModels
{
    public class QueryBinderBase
    {
        public NavigationManager Navigation { get; }
        public QueryBinderBase()
        {
            this.Navigation = Startup.ServiceProvider?.GetService<NavigationManager>();
            var uri = new Uri(Navigation.Uri);
            var queryString = System.Web.HttpUtility.ParseQueryString(uri.Query);
            foreach (string key in queryString.Keys)
            {
                foreach (var propertyType in this.GetType().GetProperties())
                {
                    var attr = propertyType.GetCustomAttribute<QueryParameterAttribute>();
                    if ((attr != null && attr.Name == key) || propertyType.Name.Equals(key, StringComparison.InvariantCultureIgnoreCase))
                    {
                        propertyType.SetValue(this, HttpUtility.UrlDecode(queryString[key]));
                    }
                }
            }
        }

    }
}
