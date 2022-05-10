using System.Windows;
using System.Windows.Controls;

namespace FFT_Graph_Control
{
    /// <summary>
    /// Interaction logic for FFT_Graph_Control.xaml
    /// </summary>
    public partial class FFT_Graph_Control : UserControl
    {
        public static readonly RoutedEvent CH1_FFT_Open_Event = EventManager.RegisterRoutedEvent("CH1_FFT_Open_Event", RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(FFT_Graph_Control));
        public static readonly RoutedEvent CH2_FFT_Open_Event = EventManager.RegisterRoutedEvent("CH2_FFT_Open_Event", RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(FFT_Graph_Control));
        public static readonly RoutedEvent CH3_FFT_Open_Event = EventManager.RegisterRoutedEvent("CH3_FFT_Open_Event", RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(FFT_Graph_Control));
        public static readonly RoutedEvent CH4_FFT_Open_Event = EventManager.RegisterRoutedEvent("CH4_FFT_Open_Event", RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(FFT_Graph_Control));

        public static readonly RoutedEvent CH1_FFTWaveform_Open_Event = EventManager.RegisterRoutedEvent("CH1_FFTWaveform_Open_Event", RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(FFT_Graph_Control));
        public static readonly RoutedEvent CH2_FFTWaveform_Open_Event = EventManager.RegisterRoutedEvent("CH2_FFTWaveform_Open_Event", RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(FFT_Graph_Control));
        public static readonly RoutedEvent CH3_FFTWaveform_Open_Event = EventManager.RegisterRoutedEvent("CH3_FFTWaveform_Open_Event", RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(FFT_Graph_Control));
        public static readonly RoutedEvent CH4_FFTWaveform_Open_Event = EventManager.RegisterRoutedEvent("CH4_FFTWaveform_Open_Event", RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(FFT_Graph_Control));

        public static readonly RoutedEvent CH1_FFTWaterfall_Open_Event = EventManager.RegisterRoutedEvent("CH1_FFTWaterfall_Open_Event", RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(FFT_Graph_Control));
        public static readonly RoutedEvent CH2_FFTWaterfall_Open_Event = EventManager.RegisterRoutedEvent("CH2_FFTWaterfall_Open_Event", RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(FFT_Graph_Control));
        public static readonly RoutedEvent CH3_FFTWaterfall_Open_Event = EventManager.RegisterRoutedEvent("CH3_FFTWaterfall_Open_Event", RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(FFT_Graph_Control));
        public static readonly RoutedEvent CH4_FFTWaterfall_Open_Event = EventManager.RegisterRoutedEvent("CH4_FFTWaterfall_Open_Event", RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(FFT_Graph_Control));


        public FFT_Graph_Control()
        {
            InitializeComponent();
        }

        private void CH1_FFT_Open_Click(object sender, RoutedEventArgs e)
        {
            RaiseEvent(new RoutedEventArgs(FFT_Graph_Control.CH1_FFT_Open_Event));
        }

        private void CH2_FFT_Open_Click(object sender, RoutedEventArgs e)
        {
            RaiseEvent(new RoutedEventArgs(FFT_Graph_Control.CH2_FFT_Open_Event));
        }

        private void CH3_FFT_Open_Click(object sender, RoutedEventArgs e)
        {
            RaiseEvent(new RoutedEventArgs(FFT_Graph_Control.CH3_FFT_Open_Event));
        }

        private void CH4_FFT_Open_Click(object sender, RoutedEventArgs e)
        {
            RaiseEvent(new RoutedEventArgs(FFT_Graph_Control.CH4_FFT_Open_Event));
        }

        private void CH1_FFTWaveform_Open_Click(object sender, RoutedEventArgs e)
        {
            RaiseEvent(new RoutedEventArgs(FFT_Graph_Control.CH1_FFTWaveform_Open_Event));
        }

        private void CH2_FFTWaveform_Open_Click(object sender, RoutedEventArgs e)
        {
            RaiseEvent(new RoutedEventArgs(FFT_Graph_Control.CH2_FFTWaveform_Open_Event));
        }

        private void CH3_FFTWaveform_Open_Click(object sender, RoutedEventArgs e)
        {
            RaiseEvent(new RoutedEventArgs(FFT_Graph_Control.CH3_FFTWaveform_Open_Event));
        }

        private void CH4_FFTWaveform_Open_Click(object sender, RoutedEventArgs e)
        {
            RaiseEvent(new RoutedEventArgs(FFT_Graph_Control.CH4_FFTWaveform_Open_Event));
        }

        private void CH1_FFTWaterfall_Open_Click(object sender, RoutedEventArgs e)
        {
            RaiseEvent(new RoutedEventArgs(FFT_Graph_Control.CH1_FFTWaterfall_Open_Event));
        }

        private void CH2_FFTWaterfall_Open_Click(object sender, RoutedEventArgs e)
        {
            RaiseEvent(new RoutedEventArgs(FFT_Graph_Control.CH2_FFTWaterfall_Open_Event));
        }

        private void CH3_FFTWaterfall_Open_Click(object sender, RoutedEventArgs e)
        {
            RaiseEvent(new RoutedEventArgs(FFT_Graph_Control.CH3_FFTWaterfall_Open_Event));
        }

        private void CH4_FFTWaterfall_Open_Click(object sender, RoutedEventArgs e)
        {
            RaiseEvent(new RoutedEventArgs(FFT_Graph_Control.CH4_FFTWaterfall_Open_Event));
        }
    }
}
