using System.Threading.Tasks;

namespace Blazor.Mvvm.Core.Abstractions.Binding
{
    public interface ICachable : IIdentifiable
    {
        Task SaveAsync();

        Task LoadAsync();

        Task ClearAsync();
    }
}
