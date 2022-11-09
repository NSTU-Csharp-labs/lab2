using Avalonia.ReactiveUI;
using Avalonia;
using Avalonia.Markup.Xaml;

namespace App.Controls.MainWindow
{
    public partial class MainWindow : ReactiveWindow<MainWindowViewModel>
    {
        public MainWindow()
        {
            InitializeComponent();
        }
    }
}