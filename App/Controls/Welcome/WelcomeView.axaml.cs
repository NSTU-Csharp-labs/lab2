using Avalonia.ReactiveUI;
using Avalonia;
using Avalonia.Markup.Xaml;

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