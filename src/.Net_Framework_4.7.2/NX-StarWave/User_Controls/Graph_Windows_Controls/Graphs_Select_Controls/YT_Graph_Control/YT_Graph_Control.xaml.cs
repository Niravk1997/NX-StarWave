using System.Windows;
using System.Windows.Controls;

namespace YT_Graph_Control
{
    /// <summary>
    /// Interaction logic for YT_Graph_Control.xaml
    /// </summary>
    public partial class YT_Graph_Control : UserControl
    {
        public static readonly RoutedEvent CH1_YT_Open_Event = EventManager.RegisterRoutedEvent("CH1_YT_Open_Event", RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(YT_Graph_Control));
        public static readonly RoutedEvent CH2_YT_Open_Event = EventManager.RegisterRoutedEvent("CH2_YT_Open_Event", RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(YT_Graph_Control));
        public static readonly RoutedEvent CH3_YT_Open_Event = EventManager.RegisterRoutedEvent("CH3_YT_Open_Event", RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(YT_Graph_Control));
        public static readonly RoutedEvent CH4_YT_Open_Event = EventManager.RegisterRoutedEvent("CH4_YT_Open_Event", RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(YT_Graph_Control));

        public static readonly RoutedEvent All_CH_YT_Open_Event = EventManager.RegisterRoutedEvent("All_CH_YT_Open_Event", RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(YT_Graph_Control));
        public static readonly RoutedEvent All_CH_YT_Square_Open_Event = EventManager.RegisterRoutedEvent("All_CH_YT_Square_Open_Event", RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(YT_Graph_Control));
        public static readonly RoutedEvent All_CH_YT_Stack_Open_Event = EventManager.RegisterRoutedEvent("All_CH_YT_Stack_Open_Event", RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(YT_Graph_Control));
        public static readonly RoutedEvent All_CH_YT_Seperate_Open_Event = EventManager.RegisterRoutedEvent("All_CH_YT_Seperate_Open_Event", RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(YT_Graph_Control));

        public YT_Graph_Control()
        {
            InitializeComponent();
        }

        private void CH1_YT_Open_Click(object sender, RoutedEventArgs e)
        {
            RaiseEvent(new RoutedEventArgs(YT_Graph_Control.CH1_YT_Open_Event));
        }

        private void CH2_YT_Open_Click(object sender, RoutedEventArgs e)
        {
            RaiseEvent(new RoutedEventArgs(YT_Graph_Control.CH2_YT_Open_Event));
        }

        private void CH3_YT_Open_Click(object sender, RoutedEventArgs e)
        {
            RaiseEvent(new RoutedEventArgs(YT_Graph_Control.CH3_YT_Open_Event));
        }

        private void CH4_YT_Open_Click(object sender, RoutedEventArgs e)
        {
            RaiseEvent(new RoutedEventArgs(YT_Graph_Control.CH4_YT_Open_Event));
        }

        private void AllCH_YT_Open_Click(object sender, RoutedEventArgs e)
        {
            RaiseEvent(new RoutedEventArgs(YT_Graph_Control.All_CH_YT_Open_Event));
        }

        private void AllCH_YT_Square_Open_Click(object sender, RoutedEventArgs e)
        {
            RaiseEvent(new RoutedEventArgs(YT_Graph_Control.All_CH_YT_Square_Open_Event));
        }

        private void AllCH_YT_Stack_Open_Click(object sender, RoutedEventArgs e)
        {
            RaiseEvent(new RoutedEventArgs(YT_Graph_Control.All_CH_YT_Stack_Open_Event));
        }

        private void AllCH_YT_Seperate_Open_Click(object sender, RoutedEventArgs e)
        {
            RaiseEvent(new RoutedEventArgs(YT_Graph_Control.All_CH_YT_Seperate_Open_Event));
        }
    }
}
