using System;
using System.Reactive;
using AnotherTravelApp.Services;
using ReactiveUI;

namespace AnotherTravelApp.ViewModels;

public class MainViewModel: ReactiveObject, IScreen
{
    public RoutingState Router { get; } = new RoutingState();

    public MainViewModel()
    {
        Console.WriteLine("MainViewModel activated");
        var screen = new LocationViewModel(Router, this, apiService: new ApiService());
        Router.Navigate.Execute(screen);
    }
}