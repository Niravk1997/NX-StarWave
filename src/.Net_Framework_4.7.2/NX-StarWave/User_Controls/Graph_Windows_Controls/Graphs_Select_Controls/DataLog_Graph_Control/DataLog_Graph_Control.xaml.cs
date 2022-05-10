using System.Windows;
using System.Windows.Controls;

namespace DataLog_Graph_Control
{
    /// <summary>
    /// Interaction logic for DataLog_Graph_Control.xaml
    /// </summary>
    public partial class DataLog_Graph_Control : UserControl
    {
        public static readonly RoutedEvent CH1_DataLog_Open_Event = EventManager.RegisterRoutedEvent("CH1_DataLog_Open_Event", RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(DataLog_Graph_Control));
        public static readonly RoutedEvent CH2_DataLog_Open_Event = EventManager.RegisterRoutedEvent("CH2_DataLog_Open_Event", RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(DataLog_Graph_Control));
        public static readonly RoutedEvent CH3_DataLog_Open_Event = EventManager.RegisterRoutedEvent("CH3_DataLog_Open_Event", RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(DataLog_Graph_Control));
        public static readonly RoutedEvent CH4_DataLog_Open_Event = EventManager.RegisterRoutedEvent("CH4_DataLog_Open_Event", RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(DataLog_Graph_Control));

        public DataLog_Graph_Control()
        {
            InitializeComponent();
        }

        private void CH1_DataLog_Open_Click(object sender, RoutedEventArgs e)
        {
            RaiseEvent(new RoutedEventArgs(DataLog_Graph_Control.CH1_DataLog_Open_Event));
        }

        private void CH2_DataLog_Open_Click(object sender, RoutedEventArgs e)
        {
            RaiseEvent(new RoutedEventArgs(DataLog_Graph_Control.CH2_DataLog_Open_Event));
        }

        private void CH3_DataLog_Open_Click(object sender, RoutedEventArgs e)
        {
            RaiseEvent(new RoutedEventArgs(DataLog_Graph_Control.CH3_DataLog_Open_Event));
        }

        private void CH4_DataLog_Open_Click(object sender, RoutedEventArgs e)
        {
            RaiseEvent(new RoutedEventArgs(DataLog_Graph_Control.CH4_DataLog_Open_Event));
        }
    }
}
