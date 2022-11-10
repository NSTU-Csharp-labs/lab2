using System;
using Avalonia.ReactiveUI;
using Avalonia.Markup.Xaml;
using Avalonia;
using Avalonia.Controls.Mixins;
using ReactiveUI;

namespace App.Controls.WorkPlace.AdditionGen
{
    public partial class AdditionGenWindow : ReactiveWindow<AdditionGenViewModel>
    {
        public AdditionGenWindow()
        {
            this.WhenActivated(d =>
            {
                ViewModel!.AddRandomGenViewModel.CreateRandomGen.Subscribe(Close).DisposeWith(d);
                ViewModel!.AddConstStepGenViewModel.CreateConstStepGen.Subscribe(Close).DisposeWith(d);
            });
            InitializeComponent();
        }

        public void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}