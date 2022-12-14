using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Reactive;
using System.Reactive.Linq;
using System.Threading.Tasks;
using App.Controls.ErrorMessage;
using App.Controls.WorkPlace.AdditionGen;
using App.Controls.WorkPlace.GeneratorCard;
using Avalonia;
using Generators;
using ReactiveUI;

namespace App.Controls.WorkPlace
{
    public class WorkPlaceViewModel : ReactiveObject, IRoutableViewModel
    {
        public CompositionGen CompositionGen { get; }
        public ReactiveCommand<Unit, Unit> AddGenerator { get; }
        
        public ReactiveCommand<Unit, Unit> GenerateNextNumber { get; }
        
        public ReactiveCommand<string, Unit> ShowGeneratorInfo { get; }

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
        
        public WorkPlaceViewModel(IScreen hostScreen)
        {
            HostScreen = hostScreen;
            CompositionGen = CompositionGenManager.Get();

            AvailableGenerators = new ObservableCollection<GeneratorCardViewModel>(CompositionGen.Select(gen => new GeneratorCardViewModel(gen, DeleteGenerator)));
            
            ShowAdditionGen = new Interaction<AdditionGenViewModel, BaseGen?>();
            ShowErrorMessage = new Interaction<ErrorMessageViewModel, Unit>();

            CalculateAverage = ReactiveCommand.CreateFromTask(OnCalculateAverage);
            GenerateNextNumber = ReactiveCommand.CreateFromTask(OnGenerateNextNumber);

            AddGenerator = ReactiveCommand.CreateFromTask(OnAddGenerator);
            
            ShowGeneratorInfo = ReactiveCommand.CreateFromTask(async (string a) =>
            {
                
            });
        }

        private async Task DeleteGenerator(string name)
        {
            try
            {
                CompositionGen.DeleteGenByName(name);

                for (var i = 0; i < AvailableGenerators.Count; i++)
                {
                    if (AvailableGenerators[i].Generator.Name == name)
                    {
                        AvailableGenerators.RemoveAt(i); 
                    }
                }
            }
            catch (Exception e)
            {
                await ShowErrorMessage.Handle(new ErrorMessageViewModel(e.Message));
            }
        } 
        
        private async Task OnAddGenerator()
        {
            try
            {
                var newGen = await ShowAdditionGen.Handle(new AdditionGenViewModel());
                if (newGen != null)
                {
                    CompositionGen.PushGen(newGen);
                    AvailableGenerators.Add(new GeneratorCardViewModel(newGen, DeleteGenerator));
                }
            }
            catch (Exception e)
            {
                await ShowErrorMessage.Handle(new ErrorMessageViewModel(e.Message));
            }
        }

        private async Task OnCalculateAverage()
        {
            try
            {
                LastCalculatedAverage = Convert.ToString(
                    CompositionGen.CalculateAverage(),
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
                    CompositionGen.GenerateNextNumber(),
                    CultureInfo.InvariantCulture);
            }
            catch (Exception e)
            {
                await ShowErrorMessage.Handle(new ErrorMessageViewModel(e.Message));
            }
        }

        public Interaction<AdditionGenViewModel, BaseGen?> ShowAdditionGen { get; }
        
        public Interaction<ErrorMessageViewModel, Unit> ShowErrorMessage { get; }

        public object? UsedAverageBehaviour => CompositionGen.AverageBehavior switch
        {
            AverageBehavior.ReturnAverageOfAvailableNumbers => Application.Current?.Resources["AverageBehavior.ReturnAverageOfAvailableNumbers"],
            AverageBehavior.ThrowException => Application.Current?.Resources["AverageBehavior.ThrowException"],
            AverageBehavior.ReturnNaN => Application.Current?.Resources["AverageBehavior.ReturnNaN"],
        };

        public string? UrlPathSegment { get; } = "/WorkPlace";
        public IScreen HostScreen { get; }
        
        public ObservableCollection<GeneratorCardViewModel> AvailableGenerators { get; }
    }
}
