// Generated by the Blazor I18n Text compiler
namespace MyBlazorApp.I18nText
{
    public partial class FetchDataResources : global::Toolbelt.Blazor.I18nText.Interfaces.I18nTextFallbackLanguage, global::Toolbelt.Blazor.I18nText.Interfaces.I18nTextLateBinding
    {
        string global::Toolbelt.Blazor.I18nText.Interfaces.I18nTextFallbackLanguage.FallBackLanguage => "en";

        public string this[string key] => global::Toolbelt.Blazor.I18nText.I18nTextExtensions.GetFieldValue(this, key);

        /// <summary>"This component demonstrates fetching data from the server."</summary>
        public string description;

        /// <summary>"loading..."</summary>
        public string loading;

        /// <summary>"Weather forecast"</summary>
        public string weatherForecast;
    }
}