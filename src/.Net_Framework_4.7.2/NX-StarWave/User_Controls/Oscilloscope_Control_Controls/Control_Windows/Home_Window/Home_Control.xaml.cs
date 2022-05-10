using System.Windows;
using System.Windows.Controls;

namespace Home_Control_Window
{
    public partial class Home_Control : UserControl
    {
        public static readonly RoutedEvent Web_Server_Open_Event = EventManager.RegisterRoutedEvent("Web_Server_Open_Event", RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(Home_Control));

        public Home_Control()
        {
            InitializeComponent();
        }

        private void Web_Server_Open_Click(object sender, RoutedEventArgs e)
        {
            RaiseEvent(new RoutedEventArgs(Home_Control.Web_Server_Open_Event));
        }
    }
}
