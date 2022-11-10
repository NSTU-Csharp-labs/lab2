using Avalonia;
using Generators;
using ReactiveUI;

namespace App.Controls.WorkPlace
{
    public class WorkPlaceViewModel : ReactiveObject, IRoutableViewModel
    {
        public CompositionGen CompositionGen { get; }

        public WorkPlaceViewModel(IScreen hostScreen)
        {
            HostScreen = hostScreen;
            CompositionGen = CompositionGenManager.Get();
        }

        public object? UsedAverageBehaviour => CompositionGen.AverageBehavior switch
        {
            AverageBehavior.ReturnAverageOfAvailableNumbers => Application.Current?.Resources["AverageBehavior.ReturnAverageOfAvailableNumbers"],
            AverageBehavior.ThrowException => Application.Current?.Resources["AverageBehavior.ThrowException"],
            AverageBehavior.ReturnNaN => Application.Current?.Resources["AverageBehavior.ReturnNaN"],
        };

        public string? UrlPathSegment { get; } = "/WorkPlace";
        public IScreen HostScreen { get; }
    }
}
