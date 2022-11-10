using ReactiveUI;

namespace App.Controls.WorkPlace.AdditionGen.AddRandomGen;

public class AddRandomGenViewModel: ReactiveObject, IRoutableViewModel
{
    public AddRandomGenViewModel(IScreen hostScreen)
    {
        HostScreen = hostScreen;
    }

    public string? UrlPathSegment { get; } = "/WorkPlace/AdditionGen/AdditionConstStepGen";
    public IScreen HostScreen { get; }
}