using Blazor.Mvvm.Core.Abstractions.Binding;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Blazor.Mvvm.Core.ViewModels
{
    public class ViewModelBase : QueryBinderBase, INotifyPropertyChanged, IViewModelBase
    {
        private bool isBusy;

        public bool IsBusy { get => isBusy; set => SetProperty(ref isBusy, value); }

        // Observer Pattern
        public event PropertyChangedEventHandler PropertyChanged;
        /// <summary>
        /// Raises <see cref="PropertyChanged"/> event with called member name.
        /// </summary>
        /// <param name="memberName">Caller member name.</param>
        public void OnPropertyChanged([CallerMemberName]string memberName = null) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(memberName));

        protected bool SetProperty<T>(ref T backingStore, T value, [CallerMemberName]string propertyName = "", Action onChanged = null)
        {
            if (EqualityComparer<T>.Default.Equals(backingStore, value))
                return false;

            backingStore = value;
            onChanged?.Invoke();
            OnPropertyChanged(propertyName);
            return true;
        }
    }
}
