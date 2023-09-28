using PipApp.Interfaces;
using PipApp.Views;
using System.Windows.Input;

namespace PipApp.ViewModels
{
    public class VModelLogin : VModelBase
    {
        /// <summary>
        /// Referencias a servicios
        /// </summary>
        readonly INavigationService _navigationService;
        readonly IDataService _dataService;

        /// <summary>
        /// Comandos
        /// </summary>
        public ICommand LoginCommand { private set; get; }
        public ICommand RegisterCommand { private set; get; }

        /// <summary>
        /// Campos internos (variables)
        /// </summary>
        private string _user;
        private string _password;
        private string _version;

        /// <summary>
        /// Campos externos (Propiedades)
        /// </summary>
        public string User { get => _user; set => SetProperty(ref _user, value); }
        public string Password { get => _password; set => SetProperty(ref _password, value); }
        public string Version { get => _version; set => SetProperty(ref _version, value); }

        /// <summary>
        /// Constructor del ViewModel
        /// </summary>
        /// <param name="navigationService"></param>
        /// <param name="dataService"></param>
        public VModelLogin(INavigationService navigationService, IDataService dataService)
        {
            _navigationService = navigationService;
            _dataService = dataService;

            User = "demo";
            Password = "demo123";

            // Comando Login
            LoginCommand = new Command(
                execute: async () =>
                {
                    if (string.IsNullOrWhiteSpace(User) || string.IsNullOrWhiteSpace(Password))
                    {
                        await Application.Current.MainPage.DisplayAlert("Atención!", "Ingrese su usuario / contraseña", "Ok");
                        return;
                    }

                    if (User.Equals("demo") && Password.Equals("demo123"))
                    {
                        // Definimos nuevamente la página inicial (No Shell)
                        // Application.Current.MainPage = new NavigationPage();

                        // Indicamos parámetros y vamos a la página login
                        await _navigationService.NavigateToPage<MainPage>(new Dictionary<string, object> { { "user", User } });
                    }
                    else await Application.Current.MainPage.DisplayAlert("Error", "Usuario o Contraseña incorrecto", "Ok");
                });

            // Registrarse
            RegisterCommand = new Command(execute: async () => await Application.Current.MainPage.DisplayAlert("Atención!", "Opción de registro en desarrollo", "Ok"));
        }

        /// <summary>
        /// Cuando llegó a su siguiente página, aquí se notifica
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
                Version = $"Versión:  {pars["version"]}";
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