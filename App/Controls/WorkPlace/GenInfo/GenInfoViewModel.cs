using System;
using System.Globalization;
using System.Reactive;
using System.Reactive.Linq;
using System.Threading.Tasks;
using App.Controls.ErrorMessage;
using Generators;
using ReactiveUI;
using App.Controls.ErrorMessage;
using Avalonia;

namespace App.Controls.WorkPlace.GenInfo
{
    public class GenInfoViewModel : ReactiveObject
    {
        private string _lastGeneratedNumber;
        
        public string LastGeneratedNumber
        {
            get => _lastGeneratedNumber;
            set => this.RaiseAndSetIfChanged(ref _lastGeneratedNumber, value);
        }

        private string _lastCalculatedAverage;

        public string LastCalculatedAverage
        {
            get => _lastCalculatedAverage;
            set => this.RaiseAndSetIfChanged(ref _lastCalculatedAverage, value);
        }
        
        public ReactiveCommand<Unit, Unit> CalculateAverage { get; }
        public ReactiveCommand<Unit, Unit> GenerateNextNumber { get; }
        public BaseGen Gen { get; }
        public Interaction<ErrorMessageViewModel, Unit> ShowErrorMessage { get; }
        
        public ReactiveCommand<Unit, Unit> Back { get; }
        
        public ReactiveCommand<Unit, Unit> Delete { get; }

        public GenInfoViewModel(BaseGen gen)
        {
            Gen = gen;
            Back = ReactiveCommand.Create(() => Unit.Default);
            Delete = ReactiveCommand.Create(() => Unit.Default);
            ShowErrorMessage = new Interaction<ErrorMessageViewModel, Unit>();
            CalculateAverage = ReactiveCommand.CreateFromTask(OnCalculateAverage);
            GenerateNextNumber = ReactiveCommand.CreateFromTask(OnGenerateNextNumber);
        }
        
        private async Task OnCalculateAverage()
        {
            try
            {
                LastCalculatedAverage = Convert.ToString(
                    Gen.CalculateAverage(),
                    CultureInfo.InvariantCulture
                );
            }
            catch (Exception e)
            {
                await ShowErrorMessage.Handle(new ErrorMessageViewModel(e.Message));
            }
        }

        private async Task OnGenerateNextNumber()
        {
            try
            {
                LastGeneratedNumber = Convert.ToString(
                    Gen.GenerateNextNumber(),
                    CultureInfo.InvariantCulture);
            }
            catch (Exception e)
            {
                await ShowErrorMessage.Handle(new ErrorMessageViewModel(e.Message));
            }
        }
        
        public object? UsedAverageBehaviour => Gen.AverageBehavior switch
        {
            AverageBehavior.ReturnAverageOfAvailableNumbers => Application.Current?.Resources["AverageBehavior.ReturnAverageOfAvailableNumbers"],
            AverageBehavior.ThrowException => Application.Current?.Resources["AverageBehavior.ThrowException"],
            AverageBehavior.ReturnNaN => Application.Current?.Resources["AverageBehavior.ReturnNaN"],
        };
    }
}
