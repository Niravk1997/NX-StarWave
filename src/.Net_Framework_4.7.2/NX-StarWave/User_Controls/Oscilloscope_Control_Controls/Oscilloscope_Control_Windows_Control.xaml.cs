using System.Windows;
using System.Windows.Controls;

namespace Oscilloscope_Control_Controls
{
    public partial class Oscilloscope_Control_Windows_Control : UserControl
    {
        Home_Control_Window.Home_Control Home_Control = new Home_Control_Window.Home_Control();

        Channel_1_Control_Window.Channel_1_Control Channel_1_Control = new Channel_1_Control_Window.Channel_1_Control();
        Channel_2_Control_Window.Channel_2_Control Channel_2_Control = new Channel_2_Control_Window.Channel_2_Control();
        Channel_3_Control_Window.Channel_3_Control Channel_3_Control = new Channel_3_Control_Window.Channel_3_Control();
        Channel_4_Control_Window.Channel_4_Control Channel_4_Control = new Channel_4_Control_Window.Channel_4_Control();

        Acquire_Window.Acquire_Control Acquire_Control = new Acquire_Window.Acquire_Control();

        Horizontal_Window.Horizontal_Control Horizontal_Control = new Horizontal_Window.Horizontal_Control();

        Trigger_Window.Trigger_Control Trigger_Control = new Trigger_Window.Trigger_Control();

        HardCopy_Window.HardCopy_Control HardCopy_Control = new HardCopy_Window.HardCopy_Control();

        public static readonly RoutedEvent SCPI_Communication_Window_Open_Event = EventManager.RegisterRoutedEvent("SCPI_Communication_Window_Open_Event", RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(Oscilloscope_Control_Windows_Control));

        public static readonly RoutedEvent Query_Measurement_Config_Window_Open_Event = EventManager.RegisterRoutedEvent("Query_Measurement_Config_Window_Open_Event", RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(Oscilloscope_Control_Windows_Control));

        public static readonly RoutedEvent Web_Server_Open_Event = EventManager.RegisterRoutedEvent("Web_Server_Open_Event", RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(Oscilloscope_Control_Windows_Control));

        public Oscilloscope_Control_Windows_Control()
        {
            InitializeComponent();
            Load_Default_UserControl();
        }

        private void Load_Default_UserControl()
        {
            Load_Oscilloscope_UserControl.Content = Home_Control;
        }

        private void Home_Control_UserControl_Click(object sender, RoutedEventArgs e)
        {
            Load_Oscilloscope_UserControl.Content = Home_Control;
        }

        private void Web_Server_Open_Click(object sender, RoutedEventArgs e)
        {
            RaiseEvent(new RoutedEventArgs(Oscilloscope_Control_Windows_Control.Web_Server_Open_Event));
        }

        private void SCPI_Communication_Window_Open_Click(object sender, RoutedEventArgs e)
        {
            RaiseEvent(new RoutedEventArgs(Oscilloscope_Control_Windows_Control.SCPI_Communication_Window_Open_Event));
        }

        private void Query_Measurement_Config_Window_Open_Click(object sender, RoutedEventArgs e)
        {
            RaiseEvent(new RoutedEventArgs(Oscilloscope_Control_Windows_Control.Query_Measurement_Config_Window_Open_Event));
        }

        private void Query_Measurements_Control_UserControl_Click(object sender, RoutedEventArgs e)
        {

        }

        private void CH1_Control_UserControl_Click(object sender, RoutedEventArgs e)
        {
            Load_Oscilloscope_UserControl.Content = Channel_1_Control;
        }

        private void CH2_Control_UserControl_Click(object sender, RoutedEventArgs e)
        {
            Load_Oscilloscope_UserControl.Content = Channel_2_Control;
        }

        private void CH3_Control_UserControl_Click(object sender, RoutedEventArgs e)
        {
            Load_Oscilloscope_UserControl.Content = Channel_3_Control;
        }

        private void CH4_Control_UserControl_Click(object sender, RoutedEventArgs e)
        {
            Load_Oscilloscope_UserControl.Content = Channel_4_Control;
        }

        private void Acquire_Control_UserControl_Click(object sender, RoutedEventArgs e)
        {
            Load_Oscilloscope_UserControl.Content = Acquire_Control;
        }

        private void Horizontal_Control_UserControl_Click(object sender, RoutedEventArgs e)
        {
            Load_Oscilloscope_UserControl.Content = Horizontal_Control;
        }

        private void Trigger_Control_UserControl_Click(object sender, RoutedEventArgs e)
        {
            Load_Oscilloscope_UserControl.Content = Trigger_Control;
        }

        private void Hardcopy_Control_UserControl_Click(object sender, RoutedEventArgs e)
        {
            Load_Oscilloscope_UserControl.Content = HardCopy_Control;
        }
    }
}
