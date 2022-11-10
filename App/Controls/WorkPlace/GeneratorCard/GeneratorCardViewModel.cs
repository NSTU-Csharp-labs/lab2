using System.Reactive;
using Generators;
using ReactiveUI;

namespace App.Controls.WorkPlace.GeneratorCard;

public class GeneratorCardViewModel
{
    public BaseGen Generator { get; } 
    
    public ReactiveCommand<Unit, Unit> Click { get; }
    
    public GeneratorCardViewModel(BaseGen generator)
    {
        Generator = generator;
        Click = ReactiveCommand.Create(() => {});
    }
}