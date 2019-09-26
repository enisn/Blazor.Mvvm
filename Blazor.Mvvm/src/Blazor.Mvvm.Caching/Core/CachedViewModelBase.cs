using Blazor.Extensions.Storage;
using Blazor.Extensions.Storage.Interfaces;
using Blazor.Mvvm.Caching.Attibutes;
using Blazor.Mvvm.Caching.Enums;
using Blazor.Mvvm.Core.Abstractions.Binding;
using Blazor.Mvvm.Core.ViewModels;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

// This is important: Use same namespace with core viewmodels!
namespace Blazor.Mvvm.Core.ViewModels
{
    public class CachedViewModelBase : ViewModelBase, ICachable
    {
        public string Identifier { get; set; }

        public LocalStorage LocalStorage { get; set; }

        public SessionStorage SessionStorage { get; set; }

        public async Task ClearAsync()
        {
            await GetStorage().RemoveItem(GetKey());
        }

        public async Task LoadAsync()
        {
            var json = await GetStorage().GetItem<string>(GetKey());
            JsonConvert.PopulateObject(json, this);
        }

        public async Task SaveAsync()
        {
            var json = JsonConvert.SerializeObject(this);
            await GetStorage().SetItem(GetKey(), json);
        }

        private protected virtual string GetKey()
        {
            return this.GetType().FullName + "_" + this.Identifier;
        }

        private IStorage GetStorage()
        {
            switch (GetStorageType())
            {
                case StorageType.SessionStorage:
                    return this.SessionStorage;
                case StorageType.LocalStorage:
                    return this.LocalStorage;
            }
            return default;
        }
        private StorageType GetStorageType()
        {
            return this.GetType().GetCustomAttribute<UseStorageAttribute>()?.Type ?? default;
        }
    }
}
