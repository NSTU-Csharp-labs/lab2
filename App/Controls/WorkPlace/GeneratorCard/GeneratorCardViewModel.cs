using System.Reactive;
using System.Reactive.Linq;
using App.Controls.WorkPlace.GenInfo;
using Generators;
using ReactiveUI;

namespace App.Controls.WorkPlace.GeneratorCard;

public class GeneratorCardViewModel : ReactiveObject
{
    public BaseGen Generator { get; } 
    
    public  ReactiveCommand<Unit, Unit> Info { get; }
    public Interaction<GenInfoViewModel, Unit> ShowInfo;

    public GeneratorCardViewModel(BaseGen generator)
    {
        Generator = generator;
        ShowInfo = new Interaction<GenInfoViewModel, Unit>();
        
        Info = ReactiveCommand.CreateFromTask(async () =>
        {
            await ShowInfo.Handle(new GenInfoViewModel(generator));
        });
    }
}