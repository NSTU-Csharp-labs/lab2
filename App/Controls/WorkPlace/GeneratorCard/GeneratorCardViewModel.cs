using System;
using System.Reactive;
using System.Reactive.Linq;
using System.Threading.Tasks;
using App.Controls.WorkPlace.GenInfo;
using Generators;
using ReactiveUI;

namespace App.Controls.WorkPlace.GeneratorCard;

public class GeneratorCardViewModel : ReactiveObject
{
    public BaseGen Generator { get; } 
    
    public  ReactiveCommand<Unit, Unit> Info { get; }
    public Interaction<GenInfoViewModel, bool> ShowInfo;

    public GeneratorCardViewModel(BaseGen generator, Func<string, Task> delete)
    {
        Generator = generator;
        ShowInfo = new Interaction<GenInfoViewModel, bool>();
        
        Info = ReactiveCommand.CreateFromTask(async () =>
        {
            var isDeleted = await ShowInfo.Handle(new GenInfoViewModel(generator));

            if (isDeleted) await delete(Generator.Name);
        });
    }
}