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
        public string UrlPathSegment { get; } = "location";
        
        private readonly ApiService _apiService;
        
        private string _location;
        public string Location
        {
            get => _location;
            set => this.RaiseAndSetIfChanged(ref _location, value);
        }

        public RoutingState Router { get; } = new RoutingState();
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
                        Console.WriteLine(Location);
                        return Router.Navigate.Execute(new SearchViewModel(router, HostScreen, _apiService, Location));
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e);
                        Location = "";
                        return Observable.Return<IRoutableViewModel>(this);
                    }
                },
                Observable.Return(true)
            );
        }
    }

}