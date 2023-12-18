using System;
using System.Reactive;
using System.Reactive.Linq;
using ReactiveUI;

namespace AnotherTravelApp.ViewModels;

public class SearchViewModel : ReactiveObject, IRoutableViewModel
{
    
    public SearchViewModel(RoutingState router, IScreen hostScreen)
    {
        
    }

    public string? UrlPathSegment { get; }
    public IScreen HostScreen { get; }
}