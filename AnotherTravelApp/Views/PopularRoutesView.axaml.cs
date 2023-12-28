using System;
using AnotherTravelApp.ViewModels;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Avalonia.ReactiveUI;
using ReactiveUI;

namespace AnotherTravelApp.Views;

public partial class PopularRoutesView : ReactiveUserControl<PopularRoutesViewModel>
{
    public PopularRoutesView()
    {
        this.WhenActivated(disposables => 
        {
            ViewModel.Refresh.Execute().Subscribe();
        });
        InitializeComponent();
    }
}