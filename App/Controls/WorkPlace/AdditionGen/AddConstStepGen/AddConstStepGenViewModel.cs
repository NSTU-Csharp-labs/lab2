using ReactiveUI;
namespace App.Controls.WorkPlace.AdditionGen.AddConstStepGen;
public class AddConstStepGenViewModel: ReactiveObject, IRoutableViewModel
{
        public AddConstStepGenViewModel(IScreen hostScreen)
        {
                HostScreen = hostScreen;
        }

        public string? UrlPathSegment { get; } = "/WorkPlace/AdditionGen/AdditionConstStepGen";
        public IScreen HostScreen { get; }
}