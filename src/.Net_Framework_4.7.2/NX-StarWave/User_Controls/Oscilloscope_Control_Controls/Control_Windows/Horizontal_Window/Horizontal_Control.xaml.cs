using NX_StarWave;
using SCPI_Commands;
using System.Windows;
using System.Windows.Controls;

namespace Horizontal_Window
{
    public partial class Horizontal_Control : UserControl
    {
        public Horizontal_Control()
        {
            InitializeComponent();
        }

        private void Horizontal_Query_Click(object sender, RoutedEventArgs e)
        {
            NX_StarWave_Window.Tektronix_SendCommands_Queue.Add(Oscilloscope_SCPI_Commands.Horizontal_Config_Status);
        }

        private void Set_Horizontal_Record_Length_Click(object sender, RoutedEventArgs e)
        {
            switch (Horizontal_Record_Length_Select.SelectedIndex)
            {
                case 0:
                    NX_StarWave_Window.Tektronix_SendCommands_Queue.Add(Oscilloscope_SCPI_Commands.Horizontal_Record_Length + "500");
                    break;
                case 1:
                    NX_StarWave_Window.Tektronix_SendCommands_Queue.Add(Oscilloscope_SCPI_Commands.Horizontal_Record_Length + "1000");
                    break;
                case 2:
                    NX_StarWave_Window.Tektronix_SendCommands_Queue.Add(Oscilloscope_SCPI_Commands.Horizontal_Record_Length + "2500");
                    break;
                case 3:
                    NX_StarWave_Window.Tektronix_SendCommands_Queue.Add(Oscilloscope_SCPI_Commands.Horizontal_Record_Length + "5000");
                    break;
                case 4:
                    NX_StarWave_Window.Tektronix_SendCommands_Queue.Add(Oscilloscope_SCPI_Commands.Horizontal_Record_Length + "15000");
                    break;
                case 5:
                    NX_StarWave_Window.Tektronix_SendCommands_Queue.Add(Oscilloscope_SCPI_Commands.Horizontal_Record_Length + "50000");
                    break;
                case 6:
                    NX_StarWave_Window.Tektronix_SendCommands_Queue.Add(Oscilloscope_SCPI_Commands.Horizontal_Record_Length + "75000");
                    break;
                case 7:
                    NX_StarWave_Window.Tektronix_SendCommands_Queue.Add(Oscilloscope_SCPI_Commands.Horizontal_Record_Length + "100000");
                    break;
                case 8:
                    NX_StarWave_Window.Tektronix_SendCommands_Queue.Add(Oscilloscope_SCPI_Commands.Horizontal_Record_Length + "130000");
                    break;
                case 9:
                    NX_StarWave_Window.Tektronix_SendCommands_Queue.Add(Oscilloscope_SCPI_Commands.Horizontal_Record_Length + "250000");
                    break;
                case 10:
                    NX_StarWave_Window.Tektronix_SendCommands_Queue.Add(Oscilloscope_SCPI_Commands.Horizontal_Record_Length + "500000");
                    break;
                default:
                    break;
            }
        }

        private void Horizontal_Record_Length_Query_Click(object sender, RoutedEventArgs e)
        {
            NX_StarWave_Window.Tektronix_SendCommands_Queue.Add(Oscilloscope_SCPI_Commands.Horizontal_Record_Length_Query);
        }

        private void Horizontal_Position_Set_Click(object sender, RoutedEventArgs e)
        {
            double Value = 0;
            bool isValid = double.TryParse(Horizontal_Position_Set_Text.Text, out Value);
            if (isValid)
            {
                NX_StarWave_Window.Tektronix_SendCommands_Queue.Add(Oscilloscope_SCPI_Commands.Horizontal_Position + Value);
            }
            else
            {
                Horizontal_Position_Set_Text.Text = string.Empty;
            }
        }

        private void Horizontal_Position_Query_Click(object sender, RoutedEventArgs e)
        {
            NX_StarWave_Window.Tektronix_SendCommands_Queue.Add(Oscilloscope_SCPI_Commands.Horizontal_Position_Query);
        }

        private void Trigger_Position_Set_Click(object sender, RoutedEventArgs e)
        {
            double Value = 0;
            bool isValid = double.TryParse(Trigger_Position_Set_Text.Text, out Value);
            if (isValid)
            {
                NX_StarWave_Window.Tektronix_SendCommands_Queue.Add(Oscilloscope_SCPI_Commands.Horizontal_Trigger_Position + Value);
            }
            else
            {
                Trigger_Position_Set_Text.Text = string.Empty;
            }
        }

        private void Trigger_Position_Query_Click(object sender, RoutedEventArgs e)
        {
            NX_StarWave_Window.Tektronix_SendCommands_Queue.Add(Oscilloscope_SCPI_Commands.Horizontal_Trigger_Position_Query);
        }
    }
}
