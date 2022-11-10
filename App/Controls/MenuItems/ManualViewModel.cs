using ReactiveUI;
using ReactiveUI;
using System.Reactive;
using App.Controls.Welcome;

namespace App.Controls.MenuItems
{
    public class ManualViewModel : ReactiveObject, IRoutableViewModel
    {
        public string? UrlPathSegment { get; } = "/Manual";
        
        public IScreen HostScreen { get; }

        public ReactiveCommand<Unit, IRoutableViewModel> GoBack { get; }
        
        public ManualViewModel(IScreen hostScreen)
        {
            HostScreen = hostScreen;
            
            GoBack = ReactiveCommand.CreateFromObservable(() =>
                HostScreen.Router.Navigate.Execute(new WelcomeViewModel(HostScreen)));
        }
    }
}
