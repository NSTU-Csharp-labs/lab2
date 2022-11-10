using System;
using System.Reactive;
using System.Reactive.Linq;
using App.Controls.ErrorMessage;
using ReactiveUI;
using Generators;


namespace App.Controls.WorkPlace.AdditionGen.AddRandomGen;

public class AddRandomGenViewModel: ReactiveObject, IRoutableViewModel
{
    public AddRandomGenViewModel(IScreen hostScreen)
    {
        HostScreen = hostScreen;
        ShowErrorMessage = new Interaction<ErrorMessageViewModel, Unit>();
        
        CreateRandomGen = ReactiveCommand.CreateFromTask(async () =>
        {
                try
                {
                        return new RandomGen(GenName, Int32.Parse(N), Behavior);
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

    public ReactiveCommand<Unit,RandomGen?> CreateRandomGen{get;}

    public string? UrlPathSegment { get; } = "/WorkPlace/AdditionGen/AdditionRandomGen";
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

    private string _genName;
    private AverageBehavior _behavior = AverageBehavior.ThrowException;
    private string _n;
    private bool _isDataInvalid = false;
}