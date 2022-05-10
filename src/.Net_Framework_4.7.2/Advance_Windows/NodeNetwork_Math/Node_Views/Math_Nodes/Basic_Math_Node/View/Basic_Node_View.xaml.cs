using ReactiveUI;
using System.Reactive.Disposables;
using System.Windows;

namespace Basic_Math_Node
{
    public partial class Basic_Node_View : IViewFor<Basic_Math_ViewModel>
    {
        public static readonly DependencyProperty ViewModelProperty =
        DependencyProperty.Register(nameof(ViewModel), typeof(Basic_Math_ViewModel), typeof(Basic_Node_View), new PropertyMetadata(null));

        public Basic_Math_ViewModel ViewModel
        {
            get => (Basic_Math_ViewModel)GetValue(ViewModelProperty);
            set => SetValue(ViewModelProperty, value);
        }

        object IViewFor.ViewModel
        {
            get => ViewModel;
            set => ViewModel = (Basic_Math_ViewModel)value;
        }

        public Basic_Node_View()
        {
            InitializeComponent();

            this.WhenActivated(d =>
            {
                this.WhenAnyValue(v => v.ViewModel).BindTo(this, v => v.NodeView.ViewModel).DisposeWith(d);
            });
        }
    }
}
