using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Toolbelt.Blazor.I18nText.Interfaces;

namespace Blazor.Mvvm.Core.Extensions
{
    public static class LocalizationExtensions
    {
        /// <summary>
        /// Get's value from resources by given key. Also you can send default value if key doesn't exist. This method does not throw any exception.
        /// * Exception-free.
        /// </summary>
        /// <param name="resource">Resources to search in.</param>
        /// <param name="key">Key to search for.</param>
        /// <param name="defaultValue">Default value to return if key doesn't exist in resources.</param>
        /// <returns>Found value or default.</returns>
        public static string GetValue(this I18nTextFallbackLanguage resource, string key, string defaultValue = null)
        {
            try
            {
                if (string.IsNullOrEmpty(key))
                    return defaultValue;

                return resource.GetType().GetField(key)?.GetValue(resource)?.ToString() ?? defaultValue;
            }
            catch (Exception ex)
            {
                Console.WriteLine("[" + key + "]" + ex.ToString());
                return defaultValue;
            }
        }

        public static string Format(this string value, params object[] parameters)
        {
            try
            {
                return string.Format(value, parameters);
            }
            catch
            {
                return default;
            }
        }
    }
}
