using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blazor.Mvvm.Core.Abstractions.Web
{
    public interface IUtilitiesService
    {
        Task SimulateClick(string selector);

        Task WriteCookie(string name, string value, int days, string domain, string path = "/");

        Task<string> ReadCookie(string name);
    }
}
