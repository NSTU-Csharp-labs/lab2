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

        public object? UsedAverageBeahviour => CompositionGen.AverageBehavior switch
        {
            AverageBehavior.ReturnAverageOfAvailableNumbers => App.Current.Resources["AverageBehavior.ReturnAverageOfAvailableNumbers"],
            AverageBehavior.ThrowException => App.Current.Resources["AverageBehavior.ThrowException"],
            AverageBehavior.ReturnNaN => App.Current.Resources["AverageBehavior.ReturnNaN"],
        };

        public string? UrlPathSegment { get; } = "/WorkPlace";
        public IScreen HostScreen { get; }
    }
}
