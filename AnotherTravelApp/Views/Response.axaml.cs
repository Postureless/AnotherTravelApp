using AnotherTravelApp.ViewModels;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Avalonia.ReactiveUI;
using ReactiveUI;

namespace AnotherTravelApp.Views;

public partial class Response : ReactiveUserControl<ResponseViewModel>
{
    public Response()
    {
        this.WhenActivated(disposables => { });
        InitializeComponent();
    }
}