using System.Windows;
using System.Windows.Controls;

namespace Math_Graph_Control
{
    /// <summary>
    /// Interaction logic for Math_Graph_Control.xaml
    /// </summary>
    public partial class Math_Graph_Control : UserControl
    {
        public static readonly RoutedEvent W1_Math_YT_Open_Event = EventManager.RegisterRoutedEvent("W1_Math_YT_Open_Event", RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(Math_Graph_Control));
        public static readonly RoutedEvent W2_Math_YT_Open_Event = EventManager.RegisterRoutedEvent("W2_Math_YT_Open_Event", RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(Math_Graph_Control));
        public static readonly RoutedEvent W3_Math_YT_Open_Event = EventManager.RegisterRoutedEvent("W3_Math_YT_Open_Event", RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(Math_Graph_Control));
        public static readonly RoutedEvent W4_Math_YT_Open_Event = EventManager.RegisterRoutedEvent("W4_Math_YT_Open_Event", RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(Math_Graph_Control));

        public static readonly RoutedEvent W1_Math_FFT_Open_Event = EventManager.RegisterRoutedEvent("W1_Math_FFT_Open_Event", RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(Math_Graph_Control));
        public static readonly RoutedEvent W2_Math_FFT_Open_Event = EventManager.RegisterRoutedEvent("W2_Math_FFT_Open_Event", RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(Math_Graph_Control));
        public static readonly RoutedEvent W3_Math_FFT_Open_Event = EventManager.RegisterRoutedEvent("W3_Math_FFT_Open_Event", RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(Math_Graph_Control));
        public static readonly RoutedEvent W4_Math_FFT_Open_Event = EventManager.RegisterRoutedEvent("W4_Math_FFT_Open_Event", RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(Math_Graph_Control));

        public static readonly RoutedEvent Waveform_Calculator_Open_Event = EventManager.RegisterRoutedEvent("Waveform_Calculator_Open_Event", RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(Math_Graph_Control));
        public static readonly RoutedEvent Reference_Calculator_Open_Event = EventManager.RegisterRoutedEvent("Reference_Calculator_Open_Event", RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(Math_Graph_Control));
        public static readonly RoutedEvent NodeNetwork_Calculator_Open_Event = EventManager.RegisterRoutedEvent("NodeNetwork_Calculator_Open_Event", RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(Math_Graph_Control));


        public Math_Graph_Control()
        {
            InitializeComponent();
        }

        private void W1_Math_YT_Open_Click(object sender, RoutedEventArgs e)
        {
            RaiseEvent(new RoutedEventArgs(Math_Graph_Control.W1_Math_YT_Open_Event));
        }

        private void W2_Math_YT_Open_Click(object sender, RoutedEventArgs e)
        {
            RaiseEvent(new RoutedEventArgs(Math_Graph_Control.W2_Math_YT_Open_Event));
        }

        private void W3_Math_YT_Open_Click(object sender, RoutedEventArgs e)
        {
            RaiseEvent(new RoutedEventArgs(Math_Graph_Control.W3_Math_YT_Open_Event));
        }

        private void W4_Math_YT_Open_Click(object sender, RoutedEventArgs e)
        {
            RaiseEvent(new RoutedEventArgs(Math_Graph_Control.W4_Math_YT_Open_Event));
        }

        private void W1_Math_FFT_Open_Click(object sender, RoutedEventArgs e)
        {
            RaiseEvent(new RoutedEventArgs(Math_Graph_Control.W1_Math_FFT_Open_Event));
        }

        private void W2_Math_FFT_Open_Click(object sender, RoutedEventArgs e)
        {
            RaiseEvent(new RoutedEventArgs(Math_Graph_Control.W2_Math_FFT_Open_Event));
        }

        private void W3_Math_FFT_Open_Click(object sender, RoutedEventArgs e)
        {
            RaiseEvent(new RoutedEventArgs(Math_Graph_Control.W3_Math_FFT_Open_Event));
        }

        private void W4_Math_FFT_Open_Click(object sender, RoutedEventArgs e)
        {
            RaiseEvent(new RoutedEventArgs(Math_Graph_Control.W4_Math_FFT_Open_Event));
        }

        private void Waveform_Calculator_Open_Click(object sender, RoutedEventArgs e)
        {
            RaiseEvent(new RoutedEventArgs(Math_Graph_Control.Waveform_Calculator_Open_Event));
        }

        private void Reference_Calculator_Open_Click(object sender, RoutedEventArgs e)
        {
            RaiseEvent(new RoutedEventArgs(Math_Graph_Control.Reference_Calculator_Open_Event));
        }

        private void NodeNetwork_Calculator_Open_Click(object sender, RoutedEventArgs e)
        {
            RaiseEvent(new RoutedEventArgs(Math_Graph_Control.NodeNetwork_Calculator_Open_Event));
        }
    }
}
