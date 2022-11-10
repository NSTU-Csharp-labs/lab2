using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Avalonia.ReactiveUI;

namespace App.Controls.WorkPlace.GeneratorCard;

public partial class GeneratorCardView : ReactiveUserControl<GeneratorCardViewModel>
{
    public GeneratorCardView()
    {
        InitializeComponent();
    }

    private void InitializeComponent()
    {
        AvaloniaXamlLoader.Load(this);
    }
}