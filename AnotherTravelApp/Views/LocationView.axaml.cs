using System;
using Avalonia.ReactiveUI;
using ReactiveUI;
using AnotherTravelApp.ViewModels;
using Avalonia.Markup.Xaml;

namespace AnotherTravelApp.Views;

public partial class LocationView : ReactiveUserControl<LocationViewModel>
{
    public LocationView()
    {
        this.WhenActivated(disposables => { });
        AvaloniaXamlLoader.Load(this);
    }
}