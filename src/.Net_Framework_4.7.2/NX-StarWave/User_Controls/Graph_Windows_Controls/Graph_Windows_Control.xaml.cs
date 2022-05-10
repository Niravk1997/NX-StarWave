using System.Windows;
using System.Windows.Controls;

namespace Graph_Windows_Controls
{
    public partial class Graph_Windows_Control : UserControl
    {
        YT_Graph_Control.YT_Graph_Control YT_Control = new YT_Graph_Control.YT_Graph_Control();
        XY_Graph_Control.XY_Graph_Control XY_Control = new XY_Graph_Control.XY_Graph_Control();
        Math_Graph_Control.Math_Graph_Control Math_Control = new Math_Graph_Control.Math_Graph_Control();
        Histogram_Graph_Control.Histogram_Graph_Control Histogram_Control = new Histogram_Graph_Control.Histogram_Graph_Control();
        FFT_Graph_Control.FFT_Graph_Control FFT_Control = new FFT_Graph_Control.FFT_Graph_Control();
        DataLog_Graph_Control.DataLog_Graph_Control DataLog_Control = new DataLog_Graph_Control.DataLog_Graph_Control();
        Analysis_Graph_Control.Analysis_Graph_Control Analysis_Control = new Analysis_Graph_Control.Analysis_Graph_Control();

        public Graph_Windows_Control()
        {
            InitializeComponent();
            Load_Default_UserControl();
        }

        private void Load_Default_UserControl()
        {
            Load_UserControl.Content = YT_Control;
        }

        private void YT_Control_Load_button_Click(object sender, RoutedEventArgs e)
        {
            Load_UserControl.Content = YT_Control;
        }

        private void XY_Control_Load_button_Click(object sender, RoutedEventArgs e)
        {
            Load_UserControl.Content = XY_Control;
        }

        private void FFT_Control_Load_button_Click(object sender, RoutedEventArgs e)
        {
            Load_UserControl.Content = FFT_Control;
        }

        private void Math_Control_Load_button_Click(object sender, RoutedEventArgs e)
        {
            Load_UserControl.Content = Math_Control;
        }

        private void Histogram_Control_Load_button_Click(object sender, RoutedEventArgs e)
        {
            Load_UserControl.Content = Histogram_Control;
        }

        private void Analysis_Control_Load_button_Click(object sender, RoutedEventArgs e)
        {
            Load_UserControl.Content = Analysis_Control;
        }

        private void DataLog_Control_Load_button_Click(object sender, RoutedEventArgs e)
        {
            Load_UserControl.Content = DataLog_Control;
        }
    }
}
