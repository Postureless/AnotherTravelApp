using System;
using AnotherTravelApp.Services;
using ReactiveUI;

namespace AnotherTravelApp.ViewModels;

public class MainWindowViewModel : ReactiveObject, IScreen
{
    public RoutingState Router { get; } = new ();

    public MainWindowViewModel(ApiService apiService)
    {
        Console.WriteLine("MainWindowViewModel activated");
        var screen = new LocationViewModel(Router, this, apiService);
        Router.Navigate.Execute(screen);
        Console.WriteLine("Navigated to LocationViewModel");
    }
}