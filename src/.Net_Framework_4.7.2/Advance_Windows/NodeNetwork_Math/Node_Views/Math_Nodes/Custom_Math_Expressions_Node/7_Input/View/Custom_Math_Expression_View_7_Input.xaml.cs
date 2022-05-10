using ReactiveUI;
using System.Reactive.Disposables;
using System.Windows;

namespace Custom_Math_Expressions_Node
{
    public partial class Custom_Math_Expression_View_7_Input : IViewFor<Custom_Math_Expression_ViewModel_7_Input>
    {
        public static readonly DependencyProperty ViewModelProperty =
        DependencyProperty.Register(nameof(ViewModel), typeof(Custom_Math_Expression_ViewModel_7_Input), typeof(Custom_Math_Expression_View_7_Input), new PropertyMetadata(null));

        public Custom_Math_Expression_ViewModel_7_Input ViewModel
        {
            get => (Custom_Math_Expression_ViewModel_7_Input)GetValue(ViewModelProperty);
            set => SetValue(ViewModelProperty, value);
        }

        object IViewFor.ViewModel
        {
            get => ViewModel;
            set => ViewModel = (Custom_Math_Expression_ViewModel_7_Input)value;
        }

        public Custom_Math_Expression_View_7_Input()
        {
            InitializeComponent();

            this.WhenActivated(d =>
            {
                this.WhenAnyValue(v => v.ViewModel).BindTo(this, v => v.NodeView.ViewModel).DisposeWith(d);
            });
        }
    }
}
