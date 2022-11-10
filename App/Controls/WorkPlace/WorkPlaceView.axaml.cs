using System.Reactive;
using System.Threading.Tasks;
using App.Controls.MainWindow;
using App.Controls.WorkPlace.AdditionGen;
using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Controls.Mixins;
using Avalonia.ReactiveUI;
using Avalonia.Markup.Xaml;
using ReactiveUI;

namespace App.Controls.WorkPlace
{
    public partial class WorkPlaceView : ReactiveUserControl<WorkPlaceViewModel>
    {
        public WorkPlaceView()
        {
            this.WhenActivated(d =>
            {
                ViewModel!
                    .ShowAdditionGen
                    .RegisterHandler(DoShowAdditionGen)
                    .DisposeWith(d);
            });
            InitializeComponent();
        }

        private async Task DoShowAdditionGen(InteractionContext<AdditionGenViewModel, Unit> interactionContext)
        {
            var dialog = new AdditionGenWindow
            {
                DataContext = interactionContext.Input
            };
            
            if (Application.Current?.ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
            {
                await dialog.ShowDialog(desktop.MainWindow);
            }
            
            interactionContext.SetOutput(Unit.Default);
        }

        public void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }

    }
}