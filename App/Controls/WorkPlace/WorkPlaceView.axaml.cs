using System.Reactive;
using System.Threading.Tasks;
using App.Controls.ErrorMessage;
using App.Controls.MainWindow;
using App.Controls.WorkPlace.AdditionGen;
using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Controls.Mixins;
using Avalonia.ReactiveUI;
using Avalonia.Markup.Xaml;
using Generators;
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

                ViewModel!
                    .ShowErrorMessage
                    .RegisterHandler(DoShowErrorMessage)
                    .DisposeWith(d);
            });
            
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }

        private static async Task DoShowErrorMessage(InteractionContext<ErrorMessageViewModel, Unit> interactionContext)
        {
            var dialog = new ErrorMessageWindow
            {
                DataContext = interactionContext.Input,
            };
            
            if (Application.Current?.ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
                await dialog.ShowDialog(desktop.MainWindow); 
            
            interactionContext.SetOutput(Unit.Default);
        }

        private static async Task DoShowAdditionGen(InteractionContext<AdditionGenViewModel, BaseGen?> interactionContext)
        {
            var dialog = new AdditionGenWindow
            {
                DataContext = interactionContext.Input
            };
            
            if (Application.Current?.ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
            {
                var newGen = await dialog.ShowDialog<BaseGen?>(desktop.MainWindow);
                interactionContext.SetOutput(newGen);
            }
            else
            {
                interactionContext.SetOutput(null); 
            }
        }
    }
}