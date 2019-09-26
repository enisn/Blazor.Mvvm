using Blazor.Mvvm.Core.Abstractions.Design;
using Blazor.Mvvm.Core.Abstractions.Web;
using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blazor.Mvvm.Web.Implementations
{
    public class UtilitiesService : IUtilitiesService
    {
        public const string SET_COOKIE = "writeCookieFromCs";
        public const string GET_COOKIE = "readCookieFromCs";
        public const string JQUERY_CLICK = "clickFromCs";

        public ILayoutModifier Modifier { get; }
        public IJSRuntime JSRuntime { get; }

        public UtilitiesService(IJSRuntime jSRuntime, ILayoutModifier modifier)
        {
            this.Modifier = modifier;
            this.JSRuntime = jSRuntime;
        }

        public async Task WriteCookie(string name, string value, int days, string domain, string path = "/")
        {
            await this.JSRuntime.InvokeAsync<object>(SET_COOKIE, name, value, days, path, domain);
        }

        public async Task<string> ReadCookie(string name)
        {
            return await this.JSRuntime.InvokeAsync<string>(GET_COOKIE, name);
        }

        public async Task SimulateClick(string selector)
        {
            await this.JSRuntime.InvokeAsync<object>(JQUERY_CLICK, selector);
        }
    }
}
