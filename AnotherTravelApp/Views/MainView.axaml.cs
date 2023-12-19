using System;
using Avalonia.Controls;
using Avalonia.ReactiveUI;
using ReactiveUI;
using AnotherTravelApp.ViewModels;

namespace AnotherTravelApp.Views;

public partial class MainView : ReactiveUserControl<MainViewModel>
{
    public MainView()
    {
        Console.WriteLine("MainView activated");
        this.WhenActivated(disposables => { });
        InitializeComponent();
    }
}