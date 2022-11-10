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
        
        public AddConstStepGenViewModel AddConstStepGenViewModel { get; }
        public AddRandomGenViewModel AddRandomGenViewModel { get; }

        public AdditionGenViewModel()
        {
            Router = new RoutingState();
            AddConstStepGenViewModel = new AddConstStepGenViewModel(this);
            AddRandomGenViewModel = new AddRandomGenViewModel(this);
            
            NavigateToAddConstStepGen = ReactiveCommand.CreateFromObservable(
                () => Router.Navigate.Execute(AddConstStepGenViewModel));
            NavigateToAddRandomGen = ReactiveCommand.CreateFromObservable(
                () => Router.Navigate.Execute(AddRandomGenViewModel));
        }

    }
}
