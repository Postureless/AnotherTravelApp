using System;
using AnotherTravelApp.ViewModels;
using AnotherTravelApp.Views;
using ReactiveUI;

namespace AnotherTravelApp;

public class AppViewLocator : ReactiveUI.IViewLocator
{
    public IViewFor ResolveView<T>(T viewModel, string contract = null) => viewModel switch
    {
        MainViewModel context => new MainView() { DataContext = context},
        LocationViewModel context => new LocationView() { DataContext = context },
        SearchViewModel context => new SearchView() { DataContext = context },
        PopularRoutesViewModel context => new PopularRoutesView() {DataContext = context },
        _ => throw new ArgumentOutOfRangeException(nameof(viewModel))
    };
}