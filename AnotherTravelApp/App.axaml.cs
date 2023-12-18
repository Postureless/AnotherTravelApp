using AnotherTravelApp.Services;
using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using AnotherTravelApp.ViewModels;
using AnotherTravelApp.Views;



namespace AnotherTravelApp;

public class App : Application
{
    public override void Initialize()
    {
        AvaloniaXamlLoader.Load(this);
    }

    public override void OnFrameworkInitializationCompleted()
    {
        switch (ApplicationLifetime)
        {
            case IClassicDesktopStyleApplicationLifetime desktop:
            {
                var apiService = new ApiService();
                desktop.MainWindow = new MainWindow();
                desktop.MainWindow.DataContext = new MainViewModel(apiService);
                break;
            }
            case ISingleViewApplicationLifetime singleViewPlatform:
            {
                var apiService = new ApiService();
                singleViewPlatform.MainView = new MainView()
                {
                    DataContext = new MainViewModel(apiService)
                };
                break;
            }
        }

        base.OnFrameworkInitializationCompleted();
    }
}