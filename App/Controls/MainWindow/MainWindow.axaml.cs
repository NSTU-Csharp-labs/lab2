using System;
using System.Reactive.Disposables;
using Avalonia.ReactiveUI;
using ReactiveUI;

namespace App.Controls.MainWindow;

public partial class MainWindow : ReactiveWindow<MainWindowViewModel>
{
    public MainWindow()
    {
        this.WhenActivated(d => ViewModel!.GoToWelcome.Execute().Subscribe().DisposeWith(d));
        InitializeComponent();
    }
}