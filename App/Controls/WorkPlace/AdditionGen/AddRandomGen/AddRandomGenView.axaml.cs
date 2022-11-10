using System;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Avalonia.ReactiveUI;
using ReactiveUI;
using Tmds.DBus;

namespace App.Controls.WorkPlace.AdditionGen.AddRandomGen;

public partial class AddRandomGenView :  ReactiveUserControl<AddRandomGenViewModel>
{
    public AddRandomGenView()
    {
        InitializeComponent();
    }

    private void InitializeComponent()
    {
        AvaloniaXamlLoader.Load(this);
    }
    
}