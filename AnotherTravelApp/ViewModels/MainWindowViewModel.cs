using System;
using System.Reactive;
using AnotherTravelApp.Services;
using ReactiveUI;

namespace AnotherTravelApp.ViewModels;

public class MainWindowViewModel : ReactiveObject, IScreen
{
    public RoutingState Router { get; } = new RoutingState();
    public ReactiveCommand<Unit, IRoutableViewModel> GoNext { get; }
    

    public MainWindowViewModel()
    {
        Router.Navigate.Execute(new LocationViewModel(Router, this, new ApiService()));
    }
}