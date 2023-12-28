using AnotherTravelApp.ViewModels;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Avalonia.ReactiveUI;

namespace AnotherTravelApp.Views;

public partial class HistoryView : ReactiveUserControl<HistoryViewModel>
{
    public HistoryView()
    {
        InitializeComponent();
    }
}