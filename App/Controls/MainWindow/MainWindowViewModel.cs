using System.Reactive;
using App.Controls.MenuItems;
using App.Controls.Welcome;
using ReactiveUI;

namespace App.Controls.MainWindow;

public class MainWindowViewModel : ReactiveObject, IScreen
{
    public MainWindowViewModel()
    {
        Router = new RoutingState();

        GoToWelcome = ReactiveCommand.CreateFromObservable(
            () => Router.Navigate.Execute(new WelcomeViewModel(this))
        );
    }

    public ReactiveCommand<Unit, IRoutableViewModel> GoToWelcome { get; }
    
    public RoutingState Router { get; }
}