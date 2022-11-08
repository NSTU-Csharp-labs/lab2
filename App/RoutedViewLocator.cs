using System;
using ReactiveUI;

namespace Presentation
{
    public class AppViewLocator : IViewLocator
    {
        public IViewFor ResolveView<T>(T viewModel, string contract = null) => viewModel switch
        {
            // LoginViewModel context => new LoginView { DataContext = context },

            // WorkPlaceViewModel context => new WorkPlaceView { DataContext = context },

            // // DefaultWorkPlaceViewModel context => new DefaultWorkPlaceView { DataContext = context },

            // WorkPlaceProfileViewModel context => new WorkPlaceProfileView { DataContext = context },

            _ => throw new ArgumentOutOfRangeException(nameof(viewModel))
        };
    }
}