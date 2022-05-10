using ReactiveUI;
using System.Reactive.Disposables;
using System.Windows;

namespace Oscilloscope_Channel_Node
{
    public partial class Channel_7_Node_View : IViewFor<Channel_7_Node_ViewModel>
    {
        public static readonly DependencyProperty ViewModelProperty =
        DependencyProperty.Register(nameof(ViewModel), typeof(Channel_7_Node_ViewModel), typeof(Channel_7_Node_View), new PropertyMetadata(null));

        public Channel_7_Node_ViewModel ViewModel
        {
            get => (Channel_7_Node_ViewModel)GetValue(ViewModelProperty);
            set => SetValue(ViewModelProperty, value);
        }

        object IViewFor.ViewModel
        {
            get => ViewModel;
            set => ViewModel = (Channel_7_Node_ViewModel)value;
        }

        public Channel_7_Node_View()
        {
            InitializeComponent();

            this.WhenActivated(d =>
            {
                this.WhenAnyValue(v => v.ViewModel).BindTo(this, v => v.NodeView.ViewModel).DisposeWith(d);
            });
        }
    }
}
