using ReactiveUI;

namespace App.Controls.Welcome
{
    public class WelcomeViewModel : ReactiveObject
    {
        public string Greeting => "Welcome to Avalonia!";
    }
}
