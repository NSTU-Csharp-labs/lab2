using Avalonia.ReactiveUI;
using Avalonia.Markup.Xaml;

namespace App.Controls.WorkPlace
{
    public partial class WorkPlaceView : ReactiveUserControl<WorkPlaceViewModel>
    {
        public WorkPlaceView()
        {
            InitializeComponent();
        }

        public void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }

    }
}