using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace PipApp.ViewModels
{
    /// <summary>
    /// Base para los ViewModel
    /// </summary>
    public abstract class VModelBase : INotifyPropertyChanged
    {
        protected bool SetProperty<T>(ref T backingStore, T value, [CallerMemberName] string propertyName = null)
        {
            if (Equals(backingStore, value)) return false;
            backingStore = value;
            OnPropertyChanged(propertyName);
            return true;
        }
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            var handler = PropertyChanged;
            handler?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        public virtual Task OnNavigatingTo(object? parameter) => Task.CompletedTask;
        public virtual Task OnNavigatedTo() => Task.CompletedTask;
        public virtual Task OnNavigatedFrom(bool isForwardNavigation) => Task.CompletedTask;
    }
}