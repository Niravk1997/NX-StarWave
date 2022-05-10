using NX_StarWave;
using SCPI_Commands;
using System.Windows;
using System.Windows.Controls;

namespace Trigger_Window
{
    public partial class Trigger_Control : UserControl
    {
        public Trigger_Control()
        {
            InitializeComponent();
        }

        private void Trigger_Info_Query_Click(object sender, RoutedEventArgs e)
        {
            NX_StarWave_Window.Tektronix_SendCommands_Queue.Add(Oscilloscope_SCPI_Commands.Trigger_Query);
        }

        private void Trigger_Edge_Source_Select_Click(object sender, RoutedEventArgs e)
        {
            switch (Trigger_Edge_CH_Select.SelectedIndex)
            {
                case 0:
                    NX_StarWave_Window.Tektronix_SendCommands_Queue.Add(Oscilloscope_SCPI_Commands.Trigger_Edge_Source + Oscilloscope_SCPI_Commands.CH1);
                    break;
                case 1:
                    NX_StarWave_Window.Tektronix_SendCommands_Queue.Add(Oscilloscope_SCPI_Commands.Trigger_Edge_Source + Oscilloscope_SCPI_Commands.CH2);
                    break;
                case 2:
                    NX_StarWave_Window.Tektronix_SendCommands_Queue.Add(Oscilloscope_SCPI_Commands.Trigger_Edge_Source + Oscilloscope_SCPI_Commands.CH3);
                    break;
                case 3:
                    NX_StarWave_Window.Tektronix_SendCommands_Queue.Add(Oscilloscope_SCPI_Commands.Trigger_Edge_Source + Oscilloscope_SCPI_Commands.CH4);
                    break;
            }
        }
    }
}
