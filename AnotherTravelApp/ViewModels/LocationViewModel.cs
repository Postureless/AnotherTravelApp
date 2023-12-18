using System;
using System.Reactive;
using System.Reactive.Linq;
using AnotherTravelApp.Services;
using ReactiveUI;

namespace AnotherTravelApp.ViewModels
{
    public class LocationViewModel : ReactiveObject, IRoutableViewModel
    {
        public IScreen HostScreen { get; }
        public string UrlPathSegment { get; } = Guid.NewGuid().ToString().Substring(0, 5);
        
        private readonly ApiService _apiService;
        private string _location;

        public string Location
        {
            get => _location;
            set => this.RaiseAndSetIfChanged(ref _location, value);
        }

        public ReactiveCommand<Unit, IRoutableViewModel> GoNext { get; }

        public LocationViewModel(RoutingState router, IScreen hostScreen, ApiService apiService)
        {
            Console.WriteLine("LocationViewModel activated");
            HostScreen = hostScreen;
            _apiService = apiService;

            GoNext = ReactiveCommand.CreateFromObservable(
                () =>
                {
                    try
                    {
                        var directionsViewModel = new PopularRoutesViewModel(router, hostScreen, _apiService, Location);
                        return Observable.Return<IRoutableViewModel>(directionsViewModel);
                    }
                    catch
                    {
                        Location = "";
                        return Observable.Return<IRoutableViewModel>(this);
                    }
                },
                Observable.Return(true)
            );
        }
    }

}