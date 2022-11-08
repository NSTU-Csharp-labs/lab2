using Avalonia.ReactiveUI;
using Avalonia.Markup.Xaml;

namespace App.Controls.Welcome
{
    public partial class WelcomeView : ReactiveUserControl<WelcomeViewModel>
    {
        public WelcomeView()
        {
            InitializeComponent();
        }
using Avalonia.Markup.Xaml;

        public void InitializeComponent()
    {
        AvaloniaXamlLoader.Load(this);
    }
}
}