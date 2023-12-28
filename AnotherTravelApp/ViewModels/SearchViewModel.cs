using System;
using System.Reactive;
using System.Reactive.Linq;
using AnotherTravelApp.Services;
using Microsoft.CodeAnalysis;
using ReactiveUI;

namespace AnotherTravelApp.ViewModels;

public class SearchViewModel : ReactiveObject, IRoutableViewModel
{
    public string? UrlPathSegment { get; } = "search";
    public IScreen HostScreen { get; }
    
    private readonly ApiService _apiService;
    private string _location;
    
    public RoutingState Router { get; } = new RoutingState();
    public ReactiveCommand<Unit, IRoutableViewModel> Popular { get; }
    public ReactiveCommand<Unit, IRoutableViewModel> History { get; }
    public ReactiveCommand<Unit, IRoutableViewModel> Response { get; }

    private string _from;
    public string From
    {
        get => _from;
        set => this.RaiseAndSetIfChanged(ref _from, value);
    }
    
    private string _where;
    public string Where
    {
        get => _where;
        set => this.RaiseAndSetIfChanged(ref _where, value);
    }
    
    private string _date;
    public string Date
    {
        get => _date;
        set => this.RaiseAndSetIfChanged(ref _date, value);
    }
    
    private string _passangers;
    public string Passangers
    {
        get => _passangers;
        set => this.RaiseAndSetIfChanged(ref _passangers, value);
    }

    public SearchViewModel(RoutingState router, IScreen hostScreen, ApiService apiService, string location)
    {
        Console.WriteLine("SearchViewModel activated");
        HostScreen = hostScreen;
        _apiService = apiService;

        Popular = ReactiveCommand.CreateFromObservable(
            () =>
            {
                try
                {
                    Console.WriteLine(location);
                    return Router.Navigate.Execute(
                        new PopularRoutesViewModel(router, HostScreen, _apiService, location));
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    return Observable.Return<IRoutableViewModel>(this);
                }
            });

        Response = ReactiveCommand.CreateFromObservable(
            () =>
            {
                try
                {
                    return null;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    return Observable.Return<IRoutableViewModel>(this);
                }
            });
    }
}