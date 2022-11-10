using ReactiveUI;
using Generators;
using System;
using System.Reactive;
using System.Reactive.Linq;
using System.Threading.Tasks;
using App.Controls.MenuItems;
using App.Controls.WorkPlace;

namespace App.Controls.Welcome
{
    public class WelcomeViewModel : ReactiveObject, IRoutableViewModel
    {
        public WelcomeViewModel(IScreen hostScreen)
        {
            HostScreen = hostScreen;
            IsDataInvalid = false;

            CreateGen = ReactiveCommand.CreateFromTask(GoToWorkPlace);
            
            GoToAbout = ReactiveCommand.CreateFromObservable(
                () => HostScreen.Router.Navigate.Execute(new AboutViewModel(HostScreen))
            );

            GoToManual = ReactiveCommand.CreateFromObservable(
                () => HostScreen.Router.Navigate.Execute(new ManualViewModel(HostScreen))
            );
        }

        private async Task GoToWorkPlace()
        {
            try
            {
                CompositionGenManager.Initialize(CompName, int.Parse(_n), _behavior);
                IsDataInvalid = false;
                await HostScreen.Router.Navigate.Execute(new WorkPlaceViewModel(HostScreen));
            }
            catch (Exception)
            {
                IsDataInvalid = true;
            }
        }
        
        public ReactiveCommand<Unit, IRoutableViewModel> GoToAbout { get; }

        public ReactiveCommand<Unit, IRoutableViewModel> GoToManual { get; }
        
        public bool IsDataInvalid
        {
            get => _isDataInvalid;
            set => this.RaiseAndSetIfChanged(ref _isDataInvalid, value);
        }

        public string CompName
        {
            get => _compName;
            set => this.RaiseAndSetIfChanged(ref _compName, value);
        }
        
        public AverageBehavior Behavior
        {
            get => _behavior;
            set => this.RaiseAndSetIfChanged(ref _behavior, value);
        }
        
        public string N
        {
            get => _n;
            set => this.RaiseAndSetIfChanged(ref _n, value);
        }

        public byte SelectedAverageBehaviorIndex
        {
            get => (byte)_behavior;
            set => this.RaiseAndSetIfChanged(ref _behavior, (AverageBehavior)value);
        }

        public string? UrlPathSegment { get; } = "/Welcome";
        
        public ReactiveCommand<Unit, Unit> CreateGen { get; }
        
        public IScreen HostScreen { get; }
        
        private string _compName;
        private AverageBehavior _behavior = AverageBehavior.ThrowException;
        private string _n;
        
        private bool _isDataInvalid = false;
    }
}
