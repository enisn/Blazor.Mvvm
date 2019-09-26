using Blazor.Mvvm.Core.Abstractions.Design;
using Blazor.Mvvm.Core.Abstractions.Design.Enums;
using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blazor.Mvvm.Web.Implementations
{
    public class LayoutModifier : ILayoutModifier
    {
        private const string SET_TITLE = "setTitle";
        private const string LOAD_FILE = "loadFile";
        private const string APPEND = "appendFromCs";
        private const string SET_ATTRIBUTE = "setAttributeFromCs";

        public LayoutModifier(IJSRuntime jsRuntime)
        {
            this.JsRuntime = jsRuntime;
        }

        public IJSRuntime JsRuntime { get; }

        public async Task AddScriptAsync(string fileUrl)
        {
            await JsRuntime.InvokeAsync<object>(LOAD_FILE, fileUrl, "js");            
        }

        public async Task AddStyleAsync(string fileUrl)
        {
            await JsRuntime.InvokeAsync<object>(LOAD_FILE, fileUrl, "css");            
        }

        public async Task SetTitleAsync(string title)
        {
            await JsRuntime.InvokeAsync<object>(SET_TITLE, title);            
        }

        public async Task AppendAsync(string selector, string rawHtml)
        {
            await JsRuntime.InvokeAsync<object>(APPEND, selector, rawHtml);            
        }

        public async Task SetAttributeAsync(string selector, string attributeName, string attributeValue)
        {
            await JsRuntime.InvokeAsync<object>(SET_ATTRIBUTE, selector, attributeName, attributeValue);            
        }

        public async Task LoadFileAsync(string fileUrl, FileType type)
        {
            await JsRuntime.InvokeAsync<object>(LOAD_FILE, fileUrl, type.ToString().ToLowerInvariant());            
        }
    }
}
