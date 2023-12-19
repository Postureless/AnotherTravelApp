using System;
using System.Reactive;
using AnotherTravelApp.Services;
using ReactiveUI;

namespace AnotherTravelApp.ViewModels;

public class MainViewModel: ReactiveObject, IScreen
{
    public RoutingState Router { get; }
    public ReactiveCommand<Unit, IRoutableViewModel> GoNext { get; }

    public MainViewModel()
    {
        Router = new RoutingState();
        Console.WriteLine("MainViewModel activated");
        GoNext = ReactiveCommand.CreateFromObservable(() => Router.NavigateAndReset.Execute(new LocationViewModel(Router, this, new ApiService())));
        
    }
}