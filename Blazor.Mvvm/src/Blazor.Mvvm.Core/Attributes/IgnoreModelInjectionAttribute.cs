using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blazor.Mvvm.Core.Attributes
{
    /// <summary>
    /// Use this attribute if you need to ignore injection as model by <see cref="BaseComponent"/>
    /// </summary>
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
    public class IgnoreModelInjectionAttribute : Attribute
    {
    }
}
