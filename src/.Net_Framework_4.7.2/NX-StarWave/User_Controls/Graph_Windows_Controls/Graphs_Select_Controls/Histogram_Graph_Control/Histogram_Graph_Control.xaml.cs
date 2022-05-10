using System.Windows;
using System.Windows.Controls;

namespace Histogram_Graph_Control
{
    /// <summary>
    /// Interaction logic for Histogram_Graph_Control.xaml
    /// </summary>
    public partial class Histogram_Graph_Control : UserControl
    {
        public static readonly RoutedEvent CH1_Histogram_Open_Event = EventManager.RegisterRoutedEvent("CH1_Histogram_Open_Event", RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(Histogram_Graph_Control));
        public static readonly RoutedEvent CH2_Histogram_Open_Event = EventManager.RegisterRoutedEvent("CH2_Histogram_Open_Event", RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(Histogram_Graph_Control));
        public static readonly RoutedEvent CH3_Histogram_Open_Event = EventManager.RegisterRoutedEvent("CH3_Histogram_Open_Event", RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(Histogram_Graph_Control));
        public static readonly RoutedEvent CH4_Histogram_Open_Event = EventManager.RegisterRoutedEvent("CH4_Histogram_Open_Event", RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(Histogram_Graph_Control));

        public Histogram_Graph_Control()
        {
            InitializeComponent();
        }

        private void CH1_Histogram_Open_Click(object sender, RoutedEventArgs e)
        {
            RaiseEvent(new RoutedEventArgs(Histogram_Graph_Control.CH1_Histogram_Open_Event));
        }

        private void CH2_Histogram_Open_Click(object sender, RoutedEventArgs e)
        {
            RaiseEvent(new RoutedEventArgs(Histogram_Graph_Control.CH2_Histogram_Open_Event));
        }

        private void CH3_Histogram_Open_Click(object sender, RoutedEventArgs e)
        {
            RaiseEvent(new RoutedEventArgs(Histogram_Graph_Control.CH3_Histogram_Open_Event));
        }

        private void CH4_Histogram_Open_Click(object sender, RoutedEventArgs e)
        {
            RaiseEvent(new RoutedEventArgs(Histogram_Graph_Control.CH4_Histogram_Open_Event));
        }
    }
}
