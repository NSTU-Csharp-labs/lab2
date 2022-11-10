using ReactiveUI;
using Avalonia.Controls;
using App.Controls.MenuItems;
using App.Controls.Welcome;
using System.Reactive;
using System;
using App.Controls.WorkPlace;



namespace App.Controls.MainWindow
{
    public class MainWindowViewModel : ReactiveObject, IScreen
    {
        public RoutingState Router { get; }
        public WelcomeViewModel WelcomeViewModel { get; }

        public WorkPlaceViewModel WorkPlaceViewModel { get; }

        public ReactiveCommand<Unit, IRoutableViewModel> GoToAbout { get; }
        public ReactiveCommand<Unit, IRoutableViewModel> GoToManual { get; }

        public bool IsMenuVisible;


        public MainWindowViewModel()
        {

             WelcomeViewModel = new WelcomeViewModel(this);
            // WorkPlaceViewModel = new WorkPlaceViewModel();

            Router = new RoutingState();

            GoToAbout = ReactiveCommand.CreateFromObservable(
                () => Router.NavigateAndReset.Execute(new AboutViewModel(this)));

            GoToManual = ReactiveCommand.CreateFromObservable(
                () => Router.NavigateAndReset.Execute(new ManualViewModel(this)));


        }
    }
}
