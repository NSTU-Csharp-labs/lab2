using System.Reactive;
using System;
using System.Threading.Tasks;
using App.Controls.ErrorMessage;
using Avalonia.ReactiveUI;
using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Controls.Mixins;
using Avalonia.Markup.Xaml;
using ReactiveUI;

namespace App.Controls.WorkPlace.GenInfo

{
    public partial class GenInfoWindow : ReactiveWindow<GenInfoViewModel>
    {
        public GenInfoWindow()
        {
            this.WhenActivated(d =>
            {
                ViewModel!
                    .Back
                    .Subscribe(_ => Close(false))
                    .DisposeWith(d);
                
                ViewModel!
                    .Delete
                    .Subscribe(_ => Close(true))
                    .DisposeWith(d);
                
                ViewModel!
                    .ShowErrorMessage
                    .RegisterHandler(DoShowErrorMessage)
                    .DisposeWith(d);
            });
            InitializeComponent();
#if DEBUG
            this.AttachDevTools();
#endif
        }

        public void InitializeComponent()
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


    }
}