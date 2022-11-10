using System.Reactive;
using ReactiveUI;
using App.Controls.WorkPlace.AdditionGen.AddRandomGen;
using App.Controls.WorkPlace.AdditionGen.AddConstStepGen;

namespace App.Controls.WorkPlace.AdditionGen
{
    public class AdditionGenViewModel : ReactiveObject, IScreen
    {
        public RoutingState Router { get; }
        public ReactiveCommand <Unit, IRoutableViewModel> NavigateToAddConstStepGen { get; }
        public ReactiveCommand <Unit, IRoutableViewModel> NavigateToAddRandomGen { get; }

        public AdditionGenViewModel()
        {
            Router = new RoutingState();
            NavigateToAddConstStepGen = ReactiveCommand.CreateFromObservable(
                () => Router.Navigate.Execute(new AddConstStepGenViewModel(this)));
            NavigateToAddRandomGen = ReactiveCommand.CreateFromObservable(
                () => Router.Navigate.Execute(new AddRandomGenViewModel(this)));
        }

    }
}
