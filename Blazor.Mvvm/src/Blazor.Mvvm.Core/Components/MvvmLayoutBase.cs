using Blazor.Mvvm.Core.Abstractions.Design;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blazor.Mvvm.Core.Components
{
    public class MvvmLayoutBase : LayoutComponentBase
    {
        [Inject] public ILayoutModifier LayoutModifier { get; set; }

    }
}
