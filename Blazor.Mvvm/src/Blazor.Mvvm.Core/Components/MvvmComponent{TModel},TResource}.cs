using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Toolbelt.Blazor.I18nText.Interfaces;

namespace Blazor.Mvvm.Core.Components
{
    public class MvvmComponent<TModel, TResource> : MvvmComponent<TModel>
        where TResource : class, I18nTextFallbackLanguage, new()
    {
        /// <summary>
        /// This will be added after real title with '-'.
        /// Your title will be like this: <see cref="Title"/> - <see cref="titleSuffix"/>.
        /// </summary>
        public static string titleSuffix = "";
        public MvvmComponent()
        {
            if (titleSuffix == "")
                titleSuffix = this.GetType().Assembly.GetName().Name;
        }
        private Expression<Func<string>> title;
        public Expression<Func<string>> Title { get => title; set { title = value; UpdateTitleAsync(); } }
        public TResource Resources { get; private set; } = new TResource();
        protected override async Task OnInitializedAsync()
        {
            await base.OnInitializedAsync();
            this.Resources = await GetResourceAsync<TResource>();

            var lang = await I18nText.GetCurrentLanguageAsync();
            CultureInfo.CurrentCulture = new CultureInfo(lang);
            CultureInfo.CurrentUICulture = new CultureInfo(lang);
        }

        public async Task<T> GetResourceAsync<T>() where T : class, I18nTextFallbackLanguage, new() => await this.I18nText.GetTextTableAsync<T>(this);

        private protected async void UpdateTitleAsync()
        {
            if (this.Title == null)
                return;

            await LayoutModifier.SetTitleAsync(title + " - " + titleSuffix);
        }
    }
}
