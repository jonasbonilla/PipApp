using PipApp.Interfaces;
using PipApp.ViewModels;
using PipApp.Views;
using System.Diagnostics;

namespace PipApp.Services
{
    /// <summary>
    /// Servicio Navegacion
    /// </summary>
    public class SNavigationService : INavigationService
    {
        readonly IServiceProvider _services;
        protected INavigation Navigation
        {
            get
            {
                var navigation = Application.Current?.MainPage?.Navigation;
                if (navigation is not null) return navigation;
                else
                {
                    //This is not good!
                    if (Debugger.IsAttached) Debugger.Break();
                    throw new Exception();
                }
            }
        }
        public SNavigationService(IServiceProvider services) => _services = services;
        private T? ResolvePage<T>() where T : Page => _services.GetService<T>();
        public Task NavigateToMainPage(object? parameter = null) => NavigateToPage<LoginPage>(parameter);
        private VModelBase? GetPageViewModelBase(Page? p) => p?.BindingContext as VModelBase;
        public async void PageNavigatedTo(object? sender, NavigatedToEventArgs e) => await CallNavigatedTo(sender as Page);
        public async Task NavigateToPage<T>(object? parameter = null) where T : Page
        {
            var toPage = ResolvePage<T>();

            if (toPage is not null)
            {
                //Subscribe to the toPage's NavigatedTo event
                toPage.NavigatedTo += PageNavigatedTo;

                //Get VM of the toPage
                var toViewModel = GetPageViewModelBase(toPage);

                //Call navigatingTo on VM, passing in the paramter
                if (toViewModel is not null) await toViewModel.OnNavigatingTo(parameter);

                //Navigate to requested page
                await Navigation.PushAsync(toPage, true);

                //Subscribe to the toPage's NavigatedFrom event
                toPage.NavigatedFrom += PageNavigatedFrom;
            }
            else throw new InvalidOperationException($"Unable to resolve type {typeof(T).FullName}");
        }
         
        private Task CallNavigatedTo(Page? p)
        {
            var fromViewModel = GetPageViewModelBase(p);
            if (fromViewModel is not null) return fromViewModel.OnNavigatedTo();
            return Task.CompletedTask;
        } 
        public async void PageNavigatedFrom(object? sender, NavigatedFromEventArgs e)
        {
            //To determine forward navigation, we look at the 2nd to last item on the NavigationStack
            //If that entry equals the sender, it means we navigated forward from the sender to another page
            bool isForwardNavigation = Navigation.NavigationStack.Count > 1 && Navigation.NavigationStack[^2] == sender;

            if (sender is Page thisPage)
            {
                if (!isForwardNavigation)
                {
                    thisPage.NavigatedTo -= PageNavigatedTo;
                    thisPage.NavigatedFrom -= PageNavigatedFrom;
                }

                await CallNavigatedFrom(thisPage, isForwardNavigation);
            }
        }
        private Task CallNavigatedFrom(Page p, bool isForward)
        {
            var fromViewModel = GetPageViewModelBase(p);
            if (fromViewModel is not null) return fromViewModel.OnNavigatedFrom(isForward);
            return Task.CompletedTask;
        }

        public Task NavigateBack()
        {
            if (Navigation.NavigationStack.Count > 1) return Navigation.PopAsync();
            throw new InvalidOperationException("No pages to navigate back to!");
        }
    }
}