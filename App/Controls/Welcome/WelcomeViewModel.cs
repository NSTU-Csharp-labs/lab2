using ReactiveUI;

namespace App.Controls.Welcome
{
    public class WelcomeViewModel : ReactiveObject, IRoutableViewModel
    {
        public string? UrlPathSegment { get; }
        public IScreen HostScreen { get; }
        public WelcomeViewModel(IScreen hostScreen)
        {
            HostScreen = hostScreen;
        }

    }
}
