using Avalonia.ReactiveUI;
using ReactiveUI;
using AnotherTravelApp.ViewModels;

namespace AnotherTravelApp.Views;

public partial class SearchView : ReactiveUserControl<LocationViewModel>
{
    public SearchView()
    {
        this.WhenActivated(_ => { });
        InitializeComponent();
    }
}