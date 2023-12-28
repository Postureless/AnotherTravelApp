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
        LocationViewModel context => new LocationView() { DataContext = context },
        SearchViewModel context => new SearchView() { DataContext = context },
        PopularRoutesViewModel context => new PopularRoutesView() {DataContext = context },
        ResponseViewModel context => new Response() {DataContext = context},
        _ => throw new ArgumentOutOfRangeException(nameof(viewModel))
    };
}