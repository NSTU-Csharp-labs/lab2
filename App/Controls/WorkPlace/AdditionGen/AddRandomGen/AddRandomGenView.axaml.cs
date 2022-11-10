using System.Reactive;
using System.Reactive.Disposables;
using System.Threading.Tasks;
using App.Controls.ErrorMessage;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using Avalonia.ReactiveUI;
using ReactiveUI;

namespace App.Controls.WorkPlace.AdditionGen.AddRandomGen;

public partial class AddRandomGenView :  ReactiveUserControl<AddRandomGenViewModel>
{
    public AddRandomGenView()
    {
        this.WhenActivated(d =>
            {
                ViewModel!.ShowErrorMessage.RegisterHandler(DoShowErrorMessageDialog).DisposeWith(d);
            }
        );
        InitializeComponent();
    }

    private void InitializeComponent()
    {
        AvaloniaXamlLoader.Load(this);
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
    
}