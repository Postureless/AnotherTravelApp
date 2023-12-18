using System;
using System.Reactive;
using System.Reactive.Linq;
using AnotherTravelApp.Services;
using ReactiveUI;

namespace AnotherTravelApp.ViewModels;

public class PopularRoutesViewModel : ReactiveObject, IRoutableViewModel
{
    private readonly ApiService _apiService;

    public string? UrlPathSegment { get; } = Guid.NewGuid().ToString().Substring(0, 5);
    private string _location;

    public string Location
    {
        get => _location;
        set => this.RaiseAndSetIfChanged(ref _location, value);
    }

    public IScreen HostScreen { get; }
    public ReactiveCommand<Unit, IRoutableViewModel> GoBack { get; }
    public ReactiveCommand<Unit, Unit> Refresh { get; }

    private DirectionDetails? _selectedDirection;

    public DirectionDetails? SelectedDirection
    {
        get => _selectedDirection;
        set => this.RaiseAndSetIfChanged(ref _selectedDirection, value);
    }

    private PopularDirectionsData? _directionsData;

    public PopularDirectionsData? DirectionsData
    {
        get => _directionsData;
        set => this.RaiseAndSetIfChanged(ref _directionsData, value);
    }

    public PopularRoutesViewModel(RoutingState router, IScreen hostScreen, ApiService apiService, string location)
    {
        HostScreen = hostScreen;
        _apiService = apiService;
        Location = location;

        GoBack = ReactiveCommand.CreateFromObservable(
            () => Observable.Return<IRoutableViewModel>(new LocationViewModel(router, hostScreen, apiService))
        );

        Refresh = ReactiveCommand.CreateFromTask(
            async () =>
            {
                try
                {
                    var data = await _apiService.GetPopularDirectionsData(Location, "usd", "f19f8d8de5e05bc4726ebf898a67a266");
                    if (data != null)
                    {
                        DirectionsData = data;
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine($"Error fetching data: {e.Message}");
                }
            }
        );
    }
}