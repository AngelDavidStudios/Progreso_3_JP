using Microsoft.Extensions.Logging;
using TestAPI_Demo_P3.MVVM.ViewModels;
using TestAPI_Demo_P3.MVVM.Views;
using TestAPI_Demo_P3.Services;

namespace TestAPI_Demo_P3;

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
            });
        
        // Registrar los servicios y ViewModel
        var dbPath = Path.Combine(FileSystem.AppDataDirectory, "StarWarsDb.db3");
        builder.Services.AddSingleton<DataBaseService>(s => new DataBaseService(dbPath));
        builder.Services.AddSingleton<APIService>();
        builder.Services.AddSingleton<SWViewModel>();

        // Registrar la página principal
        builder.Services.AddSingleton<SWView>();
        
        var app = builder.Build();
        App.InitializeServiceProvider(app.Services);

        return app;
    }
}