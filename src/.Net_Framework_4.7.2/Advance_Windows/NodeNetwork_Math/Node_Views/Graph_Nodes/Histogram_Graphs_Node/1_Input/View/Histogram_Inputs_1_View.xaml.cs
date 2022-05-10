﻿using ReactiveUI;
using System.Reactive.Disposables;
using System.Windows;

namespace Histogram_Node
{
    public partial class Histogram_Inputs_1_View : IViewFor<Histogram_Inputs_1_ViewModel>
    {
        public static readonly DependencyProperty ViewModelProperty =
        DependencyProperty.Register(nameof(ViewModel), typeof(Histogram_Inputs_1_ViewModel), typeof(Histogram_Inputs_1_View), new PropertyMetadata(null));

        public Histogram_Inputs_1_ViewModel ViewModel
        {
            get => (Histogram_Inputs_1_ViewModel)GetValue(ViewModelProperty);
            set => SetValue(ViewModelProperty, value);
        }

        object IViewFor.ViewModel
        {
            get => ViewModel;
            set => ViewModel = (Histogram_Inputs_1_ViewModel)value;
        }

        public Histogram_Inputs_1_View()
        {
            InitializeComponent();

            this.WhenActivated(d =>
            {
                this.WhenAnyValue(v => v.ViewModel).BindTo(this, v => v.NodeView.ViewModel).DisposeWith(d);
            });
        }
    }
}
