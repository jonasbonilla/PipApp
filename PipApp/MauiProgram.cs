using Microsoft.Extensions.Logging;
using PipApp.Interfaces;
using PipApp.Services;
using PipApp.ViewModels;
using PipApp.Views;

namespace PipApp
{
    public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			})
			.RegisterAppServices()
            .RegisterViewModels()
            .RegisterView();

#if DEBUG
        builder.Logging.AddDebug();
#endif

		return builder.Build();
	}

    // Creado para llevar similitud con la versión anterior del App (Xamarin)

    /// <summary>
    /// Registrar servicios
    /// </summary>
    /// <param name="mauiAppBuilder"></param>
    /// <returns></returns>
    public static MauiAppBuilder RegisterAppServices(this MauiAppBuilder mauiAppBuilder)
    {
            mauiAppBuilder.Services.AddSingleton<IDataService, SDataService>();
            mauiAppBuilder.Services.AddSingleton<INavigationService, SNavigationService>();
            return mauiAppBuilder;
    }

    /// <summary>
    /// Registrar modelos de vista
    /// </summary>
    /// <param name="mauiAppBuilder"></param>
    /// <returns></returns>
    public static MauiAppBuilder RegisterViewModels(this MauiAppBuilder mauiAppBuilder)
    {
        mauiAppBuilder.Services.AddSingleton<VModelLogin>();
        //mauiAppBuilder.Services.AddSingleton<MainPageViewModel>();
        //mauiAppBuilder.Services.AddSingleton<NewPage1ViewModel>();
        //mauiAppBuilder.Services.AddSingleton<NewPage2ViewModel>();
        //mauiAppBuilder.Services.AddSingleton<NewPage3ViewModel>();
        return mauiAppBuilder;
    }

    /// <summary>
    /// Registrar vistas
    /// </summary>
    /// <param name="mauiAppBuilder"></param>
    /// <returns></returns>
    public static MauiAppBuilder RegisterView(this MauiAppBuilder mauiAppBuilder)
    {
        mauiAppBuilder.Services.AddSingleton<LoginPage>();
        //mauiAppBuilder.Services.AddSingleton<MainPage>();
        //mauiAppBuilder.Services.AddSingleton<NewPage1>();
        //mauiAppBuilder.Services.AddSingleton<NewPage2>();
        //mauiAppBuilder.Services.AddSingleton<NewPage3>();
        return mauiAppBuilder;
    }
}
}