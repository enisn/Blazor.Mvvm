using Blazor.Mvvm.Core.ViewModels;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace MyBlazorApp.ViewModels
{
    public class FetchDataViewModel : CachedViewModelBase
    {
        private readonly HttpClient http;

        public FetchDataViewModel(HttpClient http)
        {
            this.http = http;
        }

        public WeatherForecast[] Forecasts { get; set; }

        public override async Task InitializeAsync()
        {
            this.IsBusy = true;
            this.Forecasts = await http.GetJsonAsync<WeatherForecast[]>("sample-data/weather.json");
            this.IsBusy = false;
        }

        public class WeatherForecast
        {
            public DateTime Date { get; set; }

            public int TemperatureC { get; set; }

            public string Summary { get; set; }

            public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
        }
    }
}
