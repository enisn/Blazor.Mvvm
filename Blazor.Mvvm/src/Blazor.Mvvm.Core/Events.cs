using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blazor.Mvvm.Core
{
    public class Events
    {
        public static event EventHandler<string> LanguageChanged;

        public static void TriggerLanguageChanged(string newLanguage) => LanguageChanged?.Invoke(null, newLanguage);

    }
}
