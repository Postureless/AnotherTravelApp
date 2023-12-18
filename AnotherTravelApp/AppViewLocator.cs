using System;
using AnotherTravelApp.ViewModels;
using AnotherTravelApp.Views;
using ReactiveUI;

namespace AnotherTravelApp;

public class AppViewLocator : IViewLocator
{
    public IViewFor ResolveView<T>(T viewModel, string contract = null) => viewModel switch
    {
        MainViewModel mainViewModel => new MainView() { DataContext = mainViewModel},
        LocationViewModel locationViewModel => new LocationView() { DataContext = locationViewModel},
        SearchViewModel searchViewModel => new SearchView() {DataContext = searchViewModel},
        PopularRoutesViewModel popularRoutesViewModel => new PopularRoutesView() {DataContext = popularRoutesViewModel},
        _ => throw new ArgumentOutOfRangeException(nameof(viewModel))
    };
}