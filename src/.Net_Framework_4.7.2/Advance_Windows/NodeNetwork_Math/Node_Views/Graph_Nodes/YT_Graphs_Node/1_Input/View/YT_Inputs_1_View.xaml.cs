using ReactiveUI;
using System.Reactive.Disposables;
using System.Windows;

namespace YT_Node
{
    public partial class YT_Inputs_1_View : IViewFor<YT_Inputs_1_ViewModel>
    {
        public static readonly DependencyProperty ViewModelProperty =
        DependencyProperty.Register(nameof(ViewModel), typeof(YT_Inputs_1_ViewModel), typeof(YT_Inputs_1_View), new PropertyMetadata(null));

        public YT_Inputs_1_ViewModel ViewModel
        {
            get => (YT_Inputs_1_ViewModel)GetValue(ViewModelProperty);
            set => SetValue(ViewModelProperty, value);
        }

        object IViewFor.ViewModel
        {
            get => ViewModel;
            set => ViewModel = (YT_Inputs_1_ViewModel)value;
        }

        public YT_Inputs_1_View()
        {
            InitializeComponent();

            this.WhenActivated(d =>
            {
                this.WhenAnyValue(v => v.ViewModel).BindTo(this, v => v.NodeView.ViewModel).DisposeWith(d);
            });
        }
    }
}
