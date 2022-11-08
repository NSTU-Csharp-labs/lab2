using Avalonia.ReactiveUI;
using Avalonia.Markup.Xaml;
using Avalonia;

namespace App.Controls.WorkPlace.AdditionGen
{
    public partial class AdditionGenWindow : ReactiveWindow<AdditionGenViewModel>
    {
        public AdditionGenWindow()
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