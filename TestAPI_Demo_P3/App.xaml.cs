using TestAPI_Demo_P3.MVVM.Views;

namespace TestAPI_Demo_P3;

public partial class App : Application
{
    public App()
    {
        InitializeComponent();
        MainPage = new NavigationPage(ServiceProvider.GetService<SWView>());
    }
    
    public static IServiceProvider ServiceProvider { get; private set; }

    public static void InitializeServiceProvider(IServiceProvider serviceProvider)
    {
        ServiceProvider = serviceProvider;
    }
}