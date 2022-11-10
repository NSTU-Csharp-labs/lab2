using ReactiveUI;
using System.Reactive;
using App.Controls.Welcome;
namespace App.Controls.MenuItems
{
    public class AboutViewModel : ReactiveObject, IRoutableViewModel
    {
        public string? UrlPathSegment { get; }
        public IScreen HostScreen { get; }

        public ReactiveCommand<Unit, IRoutableViewModel> GoBack { get; }
        // public ReactiveCommand<Unit, Unit> GoBack { get; }
        public AboutViewModel(IScreen hostScreen)
        {
            HostScreen = hostScreen;
            GoBack = ReactiveCommand.CreateFromObservable
                    (() => HostScreen.Router.Navigate.Execute(new WelcomeViewModel(HostScreen)));
        } 
    }
}
