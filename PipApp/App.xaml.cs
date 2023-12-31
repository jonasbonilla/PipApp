﻿using PipApp.Clases;
using PipApp.Interfaces;

namespace PipApp
{
    public partial class App : Application
    {
        /// <summary>
        /// Referencias a servicios
        /// </summary>
        private readonly INavigationService _navigationService;
        private readonly IDataService _dataService;
         
        public App(IDataService dataService, INavigationService navigationService)
        {
            InitializeComponent();

            // Iniciamos los servicios
            _dataService = dataService;
            _navigationService = navigationService;

            // Iniciamos BD sqlite
            _dataService.Init();

            // Plataforma
            if (DeviceInfo.Current.Platform == DevicePlatform.Android) CComunes.Plataforma = TipoPlataforma.Android; 
            else if (DeviceInfo.Current.Platform == DevicePlatform.iOS) CComunes.Plataforma = TipoPlataforma.Ios;
            else CComunes.Plataforma = TipoPlataforma.Windows;

            // Para saber si tiene lector de huellas
            CComunes.HasFingerprint = false;

            // Definimos página inicial (No Shell)
            MainPage = new NavigationPage();
            _navigationService.NavigateToMainPage(new Dictionary<string, object> { { "version", $"{AppInfo.Current.VersionString}.{AppInfo.Current.BuildString}" } });
        }
    }
}