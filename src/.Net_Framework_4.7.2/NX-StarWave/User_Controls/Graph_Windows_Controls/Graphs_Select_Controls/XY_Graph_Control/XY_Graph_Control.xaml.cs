using System.Windows;
using System.Windows.Controls;

namespace XY_Graph_Control
{
    /// <summary>
    /// Interaction logic for XY_Graph_Control.xaml
    /// </summary>
    public partial class XY_Graph_Control : UserControl
    {
        public static readonly RoutedEvent W1_XY_Waveform_Open_Event = EventManager.RegisterRoutedEvent("W1_XY_Waveform_Open_Event", RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(XY_Graph_Control));
        public static readonly RoutedEvent W2_XY_Waveform_Open_Event = EventManager.RegisterRoutedEvent("W2_XY_Waveform_Open_Event", RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(XY_Graph_Control));
        public static readonly RoutedEvent W3_XY_Waveform_Open_Event = EventManager.RegisterRoutedEvent("W3_XY_Waveform_Open_Event", RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(XY_Graph_Control));
        public static readonly RoutedEvent W4_XY_Waveform_Open_Event = EventManager.RegisterRoutedEvent("W4_XY_Waveform_Open_Event", RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(XY_Graph_Control));

        public static readonly RoutedEvent W1_XY_Open_Event = EventManager.RegisterRoutedEvent("W1_XY_Open_Event", RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(XY_Graph_Control));
        public static readonly RoutedEvent W2_XY_Open_Event = EventManager.RegisterRoutedEvent("W2_XY_Open_Event", RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(XY_Graph_Control));
        public static readonly RoutedEvent W3_XY_Open_Event = EventManager.RegisterRoutedEvent("W3_XY_Open_Event", RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(XY_Graph_Control));
        public static readonly RoutedEvent W4_XY_Open_Event = EventManager.RegisterRoutedEvent("W4_XY_Open_Event", RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(XY_Graph_Control));

        public XY_Graph_Control()
        {
            InitializeComponent();
        }

        private void W1_XY_Waveform_Open_Click(object sender, RoutedEventArgs e)
        {
            RaiseEvent(new RoutedEventArgs(XY_Graph_Control.W1_XY_Waveform_Open_Event));
        }

        private void W2_XY_Waveform_Open_Click(object sender, RoutedEventArgs e)
        {
            RaiseEvent(new RoutedEventArgs(XY_Graph_Control.W2_XY_Waveform_Open_Event));
        }

        private void W3_XY_Waveform_Open_Click(object sender, RoutedEventArgs e)
        {
            RaiseEvent(new RoutedEventArgs(XY_Graph_Control.W3_XY_Waveform_Open_Event));
        }

        private void W4_XY_Waveform_Open_Click(object sender, RoutedEventArgs e)
        {
            RaiseEvent(new RoutedEventArgs(XY_Graph_Control.W4_XY_Waveform_Open_Event));
        }

        private void W1_XY_Open_Click(object sender, RoutedEventArgs e)
        {
            RaiseEvent(new RoutedEventArgs(XY_Graph_Control.W1_XY_Open_Event));
        }

        private void W2_XY_Open_Click(object sender, RoutedEventArgs e)
        {
            RaiseEvent(new RoutedEventArgs(XY_Graph_Control.W2_XY_Open_Event));
        }

        private void W3_XY_Open_Click(object sender, RoutedEventArgs e)
        {
            RaiseEvent(new RoutedEventArgs(XY_Graph_Control.W3_XY_Open_Event));
        }

        private void W4_XY_Open_Click(object sender, RoutedEventArgs e)
        {
            RaiseEvent(new RoutedEventArgs(XY_Graph_Control.W4_XY_Open_Event));
        }
    }
}
