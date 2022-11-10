using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace App.Controls.WorkPlace.GeneratorCard;

public partial class GeneratorCardView : UserControl
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