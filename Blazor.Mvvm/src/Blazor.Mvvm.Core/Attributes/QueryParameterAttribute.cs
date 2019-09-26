using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blazor.Mvvm.Core.Attributes
{
    [AttributeUsage(AttributeTargets.Property)]
    public class QueryParameterAttribute : Attribute
    {
        public QueryParameterAttribute()
        {
        }
        public QueryParameterAttribute(string name)
        {
            this.Name = name;
        }
        public string Name { get; set; }
    }
}
