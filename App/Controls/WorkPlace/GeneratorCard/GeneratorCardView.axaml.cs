using System.Reactive;
using System.Threading.Tasks;
using App.Controls.ErrorMessage;
using App.Controls.WorkPlace.GenInfo;
using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Controls.Mixins;
using Avalonia.Markup.Xaml;
using Avalonia.ReactiveUI;
using ReactiveUI;


namespace App.Controls.WorkPlace.GeneratorCard;

public partial class GeneratorCardView : ReactiveUserControl<GeneratorCardViewModel>
{
    public GeneratorCardView()
    {
        InitializeComponent();
        this.WhenActivated(d =>
        {
            ViewModel!
                .ShowInfo
                .RegisterHandler(DoShowInfo)
                .DisposeWith(d);
        });
    }

    private void InitializeComponent()
    {
        AvaloniaXamlLoader.Load(this);
    }
    
    private static async Task DoShowInfo(InteractionContext<GenInfoViewModel, bool> interactionContext)
    {
        var dialog = new GenInfoWindow
        {
            DataContext = interactionContext.Input,
        };
            
        if (Application.Current?.ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
            interactionContext.SetOutput(await dialog.ShowDialog<bool>(desktop.MainWindow)); 
        else
            interactionContext.SetOutput(false);
    }
}