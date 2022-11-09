using System;
using ReactiveUI;
using App.Controls.Welcome;

namespace App
{
    public class RoutedViewLocator : IViewLocator
    {
        public IViewFor ResolveView<T>(T viewModel, string contract = null) => viewModel switch
        {

            WelcomeViewModel context => new WelcomeView { DataContext = context },
            // LoginViewModel context => new LoginView { DataContext = context },

            // WorkPlaceViewModel context => new WorkPlaceView { DataContext = context },

            // // DefaultWorkPlaceViewModel context => new DefaultWorkPlaceView { DataContext = context },

            // WorkPlaceProfileViewModel context => new WorkPlaceProfileView { DataContext = context },

            _ => throw new ArgumentOutOfRangeException(nameof(viewModel))
        };
    }
}