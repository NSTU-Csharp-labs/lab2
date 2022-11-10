using Avalonia.ReactiveUI;
using System;
using System.Reactive.Disposables;
using Avalonia.Markup.Xaml;
using Avalonia;
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