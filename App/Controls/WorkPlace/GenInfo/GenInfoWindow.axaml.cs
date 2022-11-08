using Avalonia.ReactiveUI;
using Avalonia;
using Avalonia.Markup.Xaml;

namespace App.Controls.WorkPlace.GenInfo
{
    public partial class GenInfoWindow : ReactiveWindow<GenInfoViewModel>
    {
        public GenInfoWindow()
        {
            InitializeComponent();
#if DEBUG
            this.AttachDevTools();
#endif
        }

        public void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }

    }
}