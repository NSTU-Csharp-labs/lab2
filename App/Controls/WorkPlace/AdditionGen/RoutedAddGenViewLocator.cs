using System;
using App.Controls.WorkPlace.AdditionGen.AddConstStepGen;
using App.Controls.WorkPlace.AdditionGen.AddRandomGen;
using ReactiveUI;

namespace App.Controls.WorkPlace.AdditionGen;

public class RoutedAddGenViewLocator: IViewLocator
{
    public IViewFor ResolveView<T>(T viewModel, string contract = null) => viewModel switch
    {
        AddConstStepGenViewModel context => new AddConstStepGenView { DataContext = context },
        AddRandomGenViewModel context => new AddRandomGenView() { DataContext = context },
        _ => throw new ArgumentOutOfRangeException(nameof(viewModel))
    };
}
