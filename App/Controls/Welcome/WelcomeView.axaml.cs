using System.Reactive;
using System.Reactive.Disposables;
using System.Threading.Tasks;
using App.Controls.ErrorMessage;
using Avalonia.ReactiveUI;
using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using ReactiveUI;

namespace App.Controls.Welcome
{
    public partial class WelcomeView : ReactiveUserControl<WelcomeViewModel>
    {

        public WelcomeView()
        {
            this.WhenActivated(d =>
            {
                ViewModel!.ShowErrorMessage.RegisterHandler(DoShowErrorMessageDialog).DisposeWith(d);
            });
            InitializeComponent();
        }

        private async Task DoShowErrorMessageDialog(InteractionContext<ErrorMessageViewModel, Unit> context)
        {
            var dialog = new ErrorMessageWindow
            {
                DataContext = context.Input,
            };
            
            if (Application.Current?.ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
            {
                await dialog.ShowDialog(desktop.MainWindow);
            }
            
            context.SetOutput(Unit.Default);
        }

        public void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}