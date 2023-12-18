using System;
using AnotherTravelApp.Services;
using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using AnotherTravelApp.ViewModels;
using AnotherTravelApp.Views;
using Avalonia.Platform;
using ReactiveUI;


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
                Console.WriteLine("Desktop MainWindow");
                desktop.MainWindow = new MainWindow
                {
                    DataContext = new MainWindowViewModel(),
                };
                break;
            }
            case ISingleViewApplicationLifetime singleViewPlatform:
            {
                Console.WriteLine("Desktop MainView");
                singleViewPlatform.MainView = new MainView()
                {
                    DataContext = new MainViewModel()
                };
                break;
            }
        }

        base.OnFrameworkInitializationCompleted();
    }
}