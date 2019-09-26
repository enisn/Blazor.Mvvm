using Blazor.Mvvm.Core.Abstractions.Design;
using Blazor.Mvvm.Core.Abstractions.Web;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Toolbelt.Blazor.HotKeys;
using Toolbelt.Blazor.I18nText;

namespace Blazor.Mvvm.Core.Components
{
    public class MvvmComponent : ComponentBase, IDisposable
    {
        private string title;

        public virtual string Title { get => title; set { title = value; Task.Run(async () => await this.LayoutModifier.SetTitleAsync(value)); } }

        [Inject] public ILayoutModifier LayoutModifier { get; set; }

        [Inject] public IUtilitiesService JsUtilities { get; set; }

        [Inject] public I18nText I18nText { get; set; }

        [Inject] public HotKeys HotKeys { get; set; }

        [CascadingParameter] public ComponentBase Parent { get; set; }

        public HotKeysContext HotKeysContext { get; private set; }

        protected async override Task OnInitializedAsync()
        {
            await base.OnInitializedAsync();
            InitHotkeys();
        }

        public virtual void InitHotkeys()
        {
            this.HotKeysContext = ConfigureHotkeys(this.HotKeys.CreateContext());
        }

        public virtual HotKeysContext ConfigureHotkeys(HotKeysContext hotKeys)
        {
            return hotKeys;
        }

        /// <summary>
        /// This is an exported method to render a component from csharp code.
        /// </summary>
        /// <param name="builder">Default RenderTreeBuilder.</param>
        public void Render(RenderTreeBuilder builder)
        {
            BuildRenderTree(builder);
        }

        /// <inheritdoc/>
        public void Dispose()
        {
        }
    }
}
