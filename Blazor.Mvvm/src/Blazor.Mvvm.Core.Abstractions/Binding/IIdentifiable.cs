using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blazor.Mvvm.Core.Abstractions.Binding
{
    public interface IIdentifiable
    {
        string Identifier { get; set; }
    }
}
