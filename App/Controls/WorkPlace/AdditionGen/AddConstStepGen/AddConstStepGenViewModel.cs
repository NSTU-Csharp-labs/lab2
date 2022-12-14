using System;
using System.Reactive;
using System.Reactive.Linq;
using System.Security.Principal;
using Avalonia.Controls.Templates;
using ReactiveUI;
using Generators;
using App.Controls.ErrorMessage;


namespace App.Controls.WorkPlace.AdditionGen.AddConstStepGen;
public class AddConstStepGenViewModel: ReactiveObject, IRoutableViewModel
{
        public AddConstStepGenViewModel(IScreen hostScreen)
        {
                HostScreen = hostScreen;
                ShowErrorMessage = new Interaction<ErrorMessageViewModel, Unit>();
                
                CreateConstStepGen = ReactiveCommand.CreateFromTask(async () =>
                {
                        try
                        {
                                return new ConstStepGen(GenName, Int32.Parse(N), Behavior,
                                        Int32.Parse(Step), Int32.Parse(StartPosition)) as BaseGen;
                        }
                        catch (Exception)
                        {
                                await ShowErrorMessage.Handle(
                                        new ErrorMessageViewModel("Присутсвует ошибка в введенных данных.")
                                        );
                        }
                        return null;
                });
        }
        public Interaction<ErrorMessageViewModel, Unit> ShowErrorMessage { get; }

        public ReactiveCommand<Unit, BaseGen?> CreateConstStepGen { get; } 

        public string? UrlPathSegment { get; } = "/WorkPlace/AdditionGen/AdditionConstStepGen";
        public IScreen HostScreen { get; }
        
        public bool IsDataInvalid
        {
                get => _isDataInvalid;
                set => this.RaiseAndSetIfChanged(ref _isDataInvalid, value);
        }

        public string GenName
        {
                get => _genName;
                set => this.RaiseAndSetIfChanged(ref _genName, value);
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
        public string Step
        {
                get => _step;
                set => this.RaiseAndSetIfChanged(ref _step, value);
        }

        public string StartPosition
        {
                get => _startPosition;
                set => this.RaiseAndSetIfChanged(ref _startPosition, value);
        }

        private string _startPosition;
        private string _step;
        private string _genName;
        private AverageBehavior _behavior = AverageBehavior.ThrowException;
        private string _n;
        private bool _isDataInvalid = false;
        
}