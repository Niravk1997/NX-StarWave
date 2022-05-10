using NX_StarWave;
using SCPI_Commands;
using System.Windows;
using System.Windows.Controls;

namespace Acquire_Window
{
    public partial class Acquire_Control : UserControl
    {
        public Acquire_Control()
        {
            InitializeComponent();
        }

        private void Acquire_RUN_Click(object sender, RoutedEventArgs e)
        {
            NX_StarWave_Window.Tektronix_SendCommands_Queue.Add(Oscilloscope_SCPI_Commands.Acquire_Run);
        }

        private void Acquire_Stop_Click(object sender, RoutedEventArgs e)
        {
            NX_StarWave_Window.Tektronix_SendCommands_Queue.Add(Oscilloscope_SCPI_Commands.Acquire_Stop);
        }

        private void Acquire_Query_Click(object sender, RoutedEventArgs e)
        {
            NX_StarWave_Window.Tektronix_SendCommands_Queue.Add(Oscilloscope_SCPI_Commands.Acquire_Query);
        }

        private void Acquire_Mode_Sample_Click(object sender, RoutedEventArgs e)
        {
            NX_StarWave_Window.Tektronix_SendCommands_Queue.Add(Oscilloscope_SCPI_Commands.Acquire_Mode_Sample);
        }

        private void Acquire_Mode_Peak_Click(object sender, RoutedEventArgs e)
        {
            NX_StarWave_Window.Tektronix_SendCommands_Queue.Add(Oscilloscope_SCPI_Commands.Acquire_Mode_PeakDetect);
        }

        private void Acquire_Mode_Env_Click(object sender, RoutedEventArgs e)
        {
            NX_StarWave_Window.Tektronix_SendCommands_Queue.Add(Oscilloscope_SCPI_Commands.Acquire_Mode_Envelope);
        }

        private void Acquire_Mode_Env_Value_Set_Click(object sender, RoutedEventArgs e)
        {
            int Value = 0;
            bool isValid = int.TryParse(Env_Value_TextBox.Text, out Value);
            if (isValid)
            {
                if (Value > 0 & Value < 50)
                {
                    NX_StarWave_Window.Tektronix_SendCommands_Queue.Add(Oscilloscope_SCPI_Commands.Acquire_Mode_Envelope_Count + Value);
                }
                else
                {
                    Avg_Value_TextBox.Text = string.Empty;
                }
            }
        }

        private void Acquire_Mode_Env_Value_Query_Click(object sender, RoutedEventArgs e)
        {
            NX_StarWave_Window.Tektronix_SendCommands_Queue.Add(Oscilloscope_SCPI_Commands.Acquire_Mode_Envelope_Count_Query);
        }

        private void Acquire_Mode_HiRes_Click(object sender, RoutedEventArgs e)
        {
            NX_StarWave_Window.Tektronix_SendCommands_Queue.Add(Oscilloscope_SCPI_Commands.Acquire_Mode_HIRes);
        }

        private void Acquire_Mode_Avg_Click(object sender, RoutedEventArgs e)
        {
            NX_StarWave_Window.Tektronix_SendCommands_Queue.Add(Oscilloscope_SCPI_Commands.Acquire_Mode_Average);
        }

        private void Acquire_Mode_Avg_Value_Set_Click(object sender, RoutedEventArgs e)
        {
            int Value = 0;
            bool isValid = int.TryParse(Avg_Value_TextBox.Text, out Value);
            if (isValid)
            {
                if (Value > 0 & Value < 50)
                {
                    NX_StarWave_Window.Tektronix_SendCommands_Queue.Add(Oscilloscope_SCPI_Commands.Acquire_Mode_Average_Count + Value);
                }
                else
                {
                    Avg_Value_TextBox.Text = string.Empty;
                }
            }
        }

        private void Acquire_Mode_Avg_Value_Query_Click(object sender, RoutedEventArgs e)
        {
            NX_StarWave_Window.Tektronix_SendCommands_Queue.Add(Oscilloscope_SCPI_Commands.Acquire_Mode_Average_Count_Query);
        }

        private void Acquire_Repetive_Signal_ON_Click(object sender, RoutedEventArgs e)
        {
            NX_StarWave_Window.Tektronix_SendCommands_Queue.Add("");
        }

        private void Acquire_Repetive_Signal_OFF_Click(object sender, RoutedEventArgs e)
        {
            NX_StarWave_Window.Tektronix_SendCommands_Queue.Add("");
        }
    }
}
