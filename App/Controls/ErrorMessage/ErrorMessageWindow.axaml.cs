using System;
using System.Reactive;
using System.Reactive.Disposables;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Avalonia.ReactiveUI;
using ReactiveUI;

namespace App.Controls.ErrorMessage;

public partial class ErrorMessageWindow : ReactiveWindow<ErrorMessageViewModel>
{
    public ErrorMessageWindow()
    {
        this.WhenActivated(d => ViewModel!
            .Close
            .Subscribe(_ => Close(Unit.Default))
            .DisposeWith(d)
        );
        
        InitializeComponent();
#if DEBUG
        this.AttachDevTools();
#endif
    }

    private void InitializeComponent()
    {
        AvaloniaXamlLoader.Load(this);
    }
}