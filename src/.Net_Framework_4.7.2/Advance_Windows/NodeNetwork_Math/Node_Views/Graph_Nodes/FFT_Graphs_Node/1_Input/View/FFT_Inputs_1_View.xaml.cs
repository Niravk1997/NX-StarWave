using ReactiveUI;
using System.Reactive.Disposables;
using System.Windows;

namespace FFT_Node
{
    public partial class FFT_Inputs_1_View : IViewFor<FFT_Inputs_1_ViewModel>
    {
        public static readonly DependencyProperty ViewModelProperty =
        DependencyProperty.Register(nameof(ViewModel), typeof(FFT_Inputs_1_ViewModel), typeof(FFT_Inputs_1_View), new PropertyMetadata(null));

        public FFT_Inputs_1_ViewModel ViewModel
        {
            get => (FFT_Inputs_1_ViewModel)GetValue(ViewModelProperty);
            set => SetValue(ViewModelProperty, value);
        }

        object IViewFor.ViewModel
        {
            get => ViewModel;
            set => ViewModel = (FFT_Inputs_1_ViewModel)value;
        }

        public FFT_Inputs_1_View()
        {
            InitializeComponent();

            this.WhenActivated(d =>
            {
                this.WhenAnyValue(v => v.ViewModel).BindTo(this, v => v.NodeView.ViewModel).DisposeWith(d);
            });
        }
    }
}
