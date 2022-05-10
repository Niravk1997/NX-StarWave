using System.Windows.Controls;

namespace HardCopy_Window
{
    public partial class HardCopy_Control : UserControl
    {
        public HardCopy_Control()
        {
            InitializeComponent();
        }

        private void HardCopy_Color_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            NX_StarWave.NX_StarWave_Window.Tektronix_SendCommands_Queue.Add("HardCopy_Color");
        }

        private void HardCopy_ColorCompress_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            NX_StarWave.NX_StarWave_Window.Tektronix_SendCommands_Queue.Add("HardCopy_ColorCompress");
        }

        private void HardCopy_Monochrome_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            NX_StarWave.NX_StarWave_Window.Tektronix_SendCommands_Queue.Add("HardCopy_MonoChrome");
        }
    }
}
