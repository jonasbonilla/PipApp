namespace PipApp.Interfaces
{
    /// <summary>
    /// Interfaz para el servicio Navegacion
    /// </summary>
    public interface INavigationService
    {
        Task NavigateToMainPage(object? parameter = null);
        Task NavigateToPage<T>(object? parameter = null) where T : Page;
        Task NavigateBack();
        void PageNavigatedTo(object? sender, NavigatedToEventArgs e);
        void PageNavigatedFrom(object? sender, NavigatedFromEventArgs e);
    }
}