using Blazor.Mvvm.Core.Abstractions.Design.Enums;
using System.Threading.Tasks;

namespace Blazor.Mvvm.Core.Abstractions.Design
{
    public interface ILayoutModifier
    {
        Task SetTitleAsync(string title);

        Task AddStyleAsync(string fileUrl);

        Task AddScriptAsync(string fileUrl);

        Task LoadFileAsync(string fileUrl, FileType type);

        Task AppendAsync(string selector, string rawHtml);

        Task SetAttributeAsync(string selector, string attributeName, string attributeValue);
    }
}
