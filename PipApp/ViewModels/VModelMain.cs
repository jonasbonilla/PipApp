using PipApp.Interfaces;
using System.Windows.Input;

namespace PipApp.ViewModels
{
    public class VModelMain : VModelBase
    {
        /// <summary>
        /// Referencias a servicios
        /// </summary>
        readonly INavigationService _navigationService;
        readonly IDataService _dataService;

        /// <summary>
        /// Comandos
        /// </summary>
        public ICommand NewPage1Command { private set; get; }
        public ICommand NewPage2Command { private set; get; }
        public ICommand NewPage3Command { private set; get; }

        /// <summary>
        /// Campos internos (variables)
        /// </summary>
        private string _user;

        /// <summary>
        /// Campos externos (Propiedades)
        /// </summary>
        public string User { get => _user; set => SetProperty(ref _user, value); }

        public VModelMain(INavigationService navigationService, IDataService dataService)
        {
            _navigationService = navigationService;
            _dataService = dataService;

            //NewPage1Command = new Command(execute: async () => await _navigationService.NavigateToPage<NewPage1>(new Dictionary<string, object> { { "user", User } }));
            //NewPage2Command = new Command(execute: async () => await _navigationService.NavigateToPage<NewPage2>(new Dictionary<string, object> { { "user", User } }));
            //NewPage3Command = new Command(execute: async () => await _navigationService.NavigateToPage<NewPage3>(new Dictionary<string, object> { { "user", User } }));
        }

        /// <summary>
        ///  
        /// </summary>
        /// <param name="isForwardNavigation"></param>
        /// <returns></returns>
        public override Task OnNavigatedFrom(bool isForwardNavigation)
        {
            return base.OnNavigatedFrom(isForwardNavigation);
        }

        /// <summary>
        /// Cuando estamos llegando a esta página (antes del initialize)
        /// Aquí recibiríamos los parámetros
        /// </summary>
        /// <param name="parameter"></param>
        /// <returns></returns>
        public override Task OnNavigatingTo(object? parameter)
        {
            if (parameter != null)
            {
                var pars = (Dictionary<string, object>)parameter;
                if (pars == null) return base.OnNavigatingTo(parameter);
                User = pars["user"].ToString();
            }
            return base.OnNavigatingTo(parameter);
        }

        /// <summary>
        /// Cuando hemos llegado a esta página (después del initialize)
        /// Aquí realizaríamos cualquier operación con los parámetros obenidos
        /// </summary>
        /// <returns></returns>
        public override Task OnNavigatedTo()
        {
            return base.OnNavigatedTo();
        }
    }
}
