using ReactiveUI;
using Generators;
using Avalonia;
using Avalonia.Controls;
using System;

namespace App.Controls.Welcome
{
    public class WelcomeViewModel : ReactiveObject
    {
        public string CompName
        {
            get => _compName;
            set => this.RaiseAndSetIfChanged(ref _compName, value);
        }
        public AverageBehavior Behavior
        {
            get => _behavior;
            set => this.RaiseAndSetIfChanged(ref _behavior, value);
        }
        public string N
        {
            get => _n;
            set
            {
                Console.WriteLine("ok!");
                this.RaiseAndSetIfChanged(ref _n, value);
            }
        }
        private string _compName;
        private AverageBehavior _behavior;
        private string _n;
        public WelcomeViewModel()
        {
            // var fontComboBox = this.Find<ComboBox>("fontComboBox");
        }

        public void CreateGen() { }
    }
}
