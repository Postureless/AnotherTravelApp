using System;
using Avalonia.Controls;
using Avalonia.ReactiveUI;
using ReactiveUI;
using AnotherTravelApp.ViewModels;

namespace AnotherTravelApp.Views;

public partial class MainView : ReactiveUserControl<MainViewModel>
{
    private ContentControl _mainContent;
    public MainView()
    {
        Console.WriteLine("LocationView activated");
        this.WhenActivated(disposables => { });
        InitializeComponent();
    }
}