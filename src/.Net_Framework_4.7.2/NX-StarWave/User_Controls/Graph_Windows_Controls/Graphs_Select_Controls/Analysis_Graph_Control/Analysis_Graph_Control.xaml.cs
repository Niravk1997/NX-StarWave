using System.Windows;
using System.Windows.Controls;

namespace Analysis_Graph_Control
{
    public partial class Analysis_Graph_Control : UserControl
    {
        public static readonly RoutedEvent Waveform_Player_Open_Event = EventManager.RegisterRoutedEvent("Waveform_Player_Open_Event", RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(Analysis_Graph_Control));
        public static readonly RoutedEvent Compare_YT_Plots_Open_Event = EventManager.RegisterRoutedEvent("Compare_YT_Plots_Open_Event", RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(Analysis_Graph_Control));

        public Analysis_Graph_Control()
        {
            InitializeComponent();
        }

        private void Waveform_Player_Open_Click(object sender, RoutedEventArgs e)
        {
            RaiseEvent(new RoutedEventArgs(Analysis_Graph_Control.Waveform_Player_Open_Event));
        }

        private void Compare_YT_Plots_Open_Click(object sender, RoutedEventArgs e)
        {
            RaiseEvent(new RoutedEventArgs(Analysis_Graph_Control.Compare_YT_Plots_Open_Event));
        }
    }
}
