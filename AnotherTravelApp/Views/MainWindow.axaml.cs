using AnotherTravelApp.Services;
using Avalonia.Controls;
using AnotherTravelApp.ViewModels;
using Avalonia.ReactiveUI;
using ReactiveUI;

namespace AnotherTravelApp.Views;

public partial class MainWindow : ReactiveWindow<MainWindowViewModel>
{
    public MainWindow()
    {
        this.WhenActivated(disposables => { });
        InitializeComponent();
    }
}