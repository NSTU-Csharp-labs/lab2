using Avalonia.ReactiveUI;
using Avalonia.Markup.Xaml;
using Avalonia;

namespace App.Controls.Welcome
{
    public partial class WelcomeView : ReactiveUserControl<WelcomeViewModel>
    {
        public WelcomeView()
        {
            InitializeComponent();
        }

        public void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}