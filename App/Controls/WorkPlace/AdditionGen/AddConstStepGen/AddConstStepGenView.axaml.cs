using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Avalonia.ReactiveUI;
using ReactiveUI;

namespace App.Controls.WorkPlace.AdditionGen.AddConstStepGen;

public partial class AddConstStepGenView : ReactiveUserControl<AddConstStepGenViewModel>
{
    public AddConstStepGenView()
    {
        InitializeComponent();
    }

    private void InitializeComponent()
    {
        AvaloniaXamlLoader.Load(this);
    }
}