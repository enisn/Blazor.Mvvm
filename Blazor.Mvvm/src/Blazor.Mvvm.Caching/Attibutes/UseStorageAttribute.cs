using Blazor.Mvvm.Caching.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blazor.Mvvm.Caching.Attibutes
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
    public class UseStorageAttribute : Attribute
    {
        public UseStorageAttribute()
        {
        }

        public UseStorageAttribute(StorageType type)
        {
            this.Type = type;
        }

        public StorageType Type { get; set; }
    }
}
