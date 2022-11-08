using Avalonia.ReactiveUI;
using Avalonia.Markup.Xaml;

namespace App.Controls.MenuItems
{
    public partial class AboutView : ReactiveUserControl<AboutViewModel>
    {
        public AboutView()
        {
            InitializeComponent();
        }


        public void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}