using Avalonia.ReactiveUI;
using Avalonia.Markup.Xaml;

namespace App.Controls.MenuItems
{
    public partial class ManualView : ReactiveUserControl<ManualViewModel>
    {
        public ManualView()
        {
            InitializeComponent();
        }

        public void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}