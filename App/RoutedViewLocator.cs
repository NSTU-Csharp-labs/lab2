using System;
using ReactiveUI;
using App.Controls.Welcome;
using App.Controls.MenuItems;
using App.Controls.WorkPlace;
// using App.Controls.WorkPlace.AdditionGen;
// using App.Controls.WorkPlace.GenInfo;

namespace App
{
    public class RoutedViewLocator : IViewLocator
    {
        public IViewFor ResolveView<T>(T viewModel, string contract = null) => viewModel switch
        {
            WelcomeViewModel context => new WelcomeView { DataContext = context },
            AboutViewModel context => new AboutView { DataContext = context },
            ManualViewModel context => new ManualView { DataContext = context },
            WorkPlaceViewModel context => new WorkPlaceView { DataContext = context },

            _ => throw new ArgumentOutOfRangeException(nameof(viewModel))
        };
    }
}