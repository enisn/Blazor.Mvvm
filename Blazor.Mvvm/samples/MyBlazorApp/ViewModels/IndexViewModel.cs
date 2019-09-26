using Blazor.Mvvm.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlazorApp.ViewModels
{
    public class IndexViewModel : ViewModelBase
    {
        public bool IsSurveyVisible { get; set; }

        public void SwitchSurveyVisibility()
        {
            this.IsSurveyVisible = !this.IsSurveyVisible;
        }
    }
}
