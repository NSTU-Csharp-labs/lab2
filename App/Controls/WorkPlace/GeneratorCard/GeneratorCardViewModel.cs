using System.Reactive;
using App.Controls.WorkPlace.GenInfo;
using Generators;
using ReactiveUI;

namespace App.Controls.WorkPlace.GeneratorCard;

public class GeneratorCardViewModel
{
    public BaseGen Generator { get; } 
    
    public ReactiveCommand<Unit, Unit> Click { get; }
    public  ReactiveCommand<Unit, Unit> Info { get; }
    public Interaction<GenInfoViewModel, Unit> ShowInfo;

    public GeneratorCardViewModel(BaseGen generator)
    {
        Generator = generator;
        Click = ReactiveCommand.Create(() => {});
        ShowInfo = new Interaction<GenInfoViewModel, Unit>();
    }
}