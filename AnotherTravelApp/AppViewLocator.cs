using System;
using AnotherTravelApp.ViewModels;
using AnotherTravelApp.Views;
using ReactiveUI;

namespace AnotherTravelApp;

public class AppViewLocator : ReactiveUI.IViewLocator
{
    public IViewFor ResolveView<T>(T viewModel, string contract = null) => viewModel switch
    {
        LocationViewModel context => new LocationView() { DataContext = context },
        _ => throw new ArgumentOutOfRangeException(nameof(viewModel))
    };
}