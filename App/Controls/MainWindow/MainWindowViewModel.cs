using ReactiveUI;
using App.Controls.Welcome;


namespace App.Controls.MainWindow
{
    public class MainWindowViewModel : ReactiveObject, IScreen
    {
        public RoutingState Router { get; }
        public WelcomeViewModel WelcomeViewModel { get; }

        public MainWindowViewModel()
        {
            Router = new RoutingState();
            WelcomeViewModel = new WelcomeViewModel(this);
        }
    }
}
