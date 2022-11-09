using ReactiveUI;
using ReactiveUI;
using System.Reactive;
using App.Controls.Welcome;

namespace App.Controls.MenuItems
{
    public class ManualViewModel : ReactiveObject, IRoutableViewModel
    {
        public string? UrlPathSegment { get; }
        public IScreen HostScreen { get; }

        public ReactiveCommand<Unit, Unit> GoBack { get; }
        public ManualViewModel(IScreen hostScreen)
        {
            HostScreen = hostScreen;
            GoBack = ReactiveCommand.CreateFromObservable
                    (() => HostScreen.Router.NavigateBack.Execute(Unit.Default));
        }
    }
}
