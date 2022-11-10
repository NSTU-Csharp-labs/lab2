using System.Reactive;
using ReactiveUI;

namespace App.Controls.ErrorMessage;

public class ErrorMessageViewModel
{
    public string Message { get; } 
    
    public ReactiveCommand<Unit, Unit> Close { get; }
    
    public ErrorMessageViewModel(string msg)
    {
        Message = msg;

        Close = ReactiveCommand.Create(() => Unit.Default);
    }
}