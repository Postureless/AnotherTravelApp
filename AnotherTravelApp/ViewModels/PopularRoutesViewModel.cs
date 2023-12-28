using System;
using System.Collections.ObjectModel;
using System.Reactive;
using System.Reactive.Linq;
using AnotherTravelApp.Services;
using ReactiveUI;

namespace AnotherTravelApp.ViewModels
{
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

        public RoutingState Router { get; } = new RoutingState();

        private ObservableCollection<DirectionDetails> _directionsData = new ObservableCollection<DirectionDetails>();

        public ObservableCollection<DirectionDetails> DirectionsData
        {
            get => _directionsData;
            set => this.RaiseAndSetIfChanged(ref _directionsData, value);
        }

        public PopularRoutesViewModel(RoutingState router, IScreen hostScreen, ApiService apiService, string location)
        {
            Console.WriteLine("PopularRoutesViewModel activated");
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
                        Console.WriteLine("Trying to refresh");
                        var data = await _apiService.GetPopularDirectionsData(Location, "usd", "f19f8d8de5e05bc4726ebf898a67a266");
                        if (data != null)
                        {
                            DirectionsData = new ObservableCollection<DirectionDetails>(data.Data.Values);
                        }
                        else
                        {
                            Console.WriteLine("Empty data");
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
} 
