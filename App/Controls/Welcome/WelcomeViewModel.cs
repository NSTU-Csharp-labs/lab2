using ReactiveUI;
using Generators;
using Avalonia;
using Avalonia.Controls;
using System;

namespace App.Controls.Welcome
{
    public class WelcomeViewModel : ReactiveObject, IRoutableViewModel

    {

        public WelcomeViewModel(IScreen hostScreen)
        {
            HostScreen = hostScreen;
            IsDataInvalid = false;
        }

        public void CreateGen()
        {
            try
            {
                ProgramGen = new CompositionGen(CompName, Convert.ToInt32(N), AverageBehavior.ReturnAverageOfAvailableNumbers);
                IsDataInvalid = false;
            }
            catch (Exception)
            {
                IsDataInvalid = true;
            }
        }
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
            set
            {
                this.RaiseAndSetIfChanged(ref _n, value);
            }
        }

        //
        private CompositionGen ProgramGen;
        private string _compName;
        private AverageBehavior _behavior;
        private string _n;
        private bool _isDataInvalid = false;

        public string? UrlPathSegment { get; }
        public IScreen HostScreen { get; }
    }
}
