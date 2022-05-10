using NX_StarWave;
using SCPI_Commands;
using System.Windows;
using System.Windows.Controls;

namespace Channel_2_Control_Window
{
    public partial class Channel_2_Control : UserControl
    {
        public Channel_2_Control()
        {
            InitializeComponent();
        }

        private void Channel_2_ON_Click(object sender, RoutedEventArgs e)
        {
            NX_StarWave_Window.Tektronix_SendCommands_Queue.Add(Oscilloscope_SCPI_Commands.Select + Oscilloscope_SCPI_Commands.CH2 + Oscilloscope_SCPI_Commands.CH_ON);
        }

        private void Channel_2_OFF_Click(object sender, RoutedEventArgs e)
        {
            NX_StarWave_Window.Tektronix_SendCommands_Queue.Add(Oscilloscope_SCPI_Commands.Select + Oscilloscope_SCPI_Commands.CH2 + Oscilloscope_SCPI_Commands.CH_OFF);
        }

        private void Channel_2_Status_Query_Click(object sender, RoutedEventArgs e)
        {
            NX_StarWave_Window.Tektronix_SendCommands_Queue.Add(Oscilloscope_SCPI_Commands.CH2 + Oscilloscope_SCPI_Commands.CH_Status);
        }

        private void Channel_2_Coupling_DC_Click(object sender, RoutedEventArgs e)
        {
            NX_StarWave_Window.Tektronix_SendCommands_Queue.Add(Oscilloscope_SCPI_Commands.CH2 + Oscilloscope_SCPI_Commands.Coupling_DC);
        }

        private void Channel_2_Coupling_AC_Click(object sender, RoutedEventArgs e)
        {
            NX_StarWave_Window.Tektronix_SendCommands_Queue.Add(Oscilloscope_SCPI_Commands.CH2 + Oscilloscope_SCPI_Commands.Coupling_AC);
        }

        private void Channel_2_Coupling_GND_Click(object sender, RoutedEventArgs e)
        {
            NX_StarWave_Window.Tektronix_SendCommands_Queue.Add(Oscilloscope_SCPI_Commands.CH2 + Oscilloscope_SCPI_Commands.Coupling_GND);
        }

        private void Channel_2_Bandwidth_FULL_Click(object sender, RoutedEventArgs e)
        {
            NX_StarWave_Window.Tektronix_SendCommands_Queue.Add(Oscilloscope_SCPI_Commands.CH2 + Oscilloscope_SCPI_Commands.Bandwidth_Full);
        }

        private void Channel_2_Bandwidth_250MHz_Click(object sender, RoutedEventArgs e)
        {
            NX_StarWave_Window.Tektronix_SendCommands_Queue.Add(Oscilloscope_SCPI_Commands.CH2 + Oscilloscope_SCPI_Commands.Bandwidth_250MHz);
        }

        private void Channel_2_Bandwidth_20MHz_Click(object sender, RoutedEventArgs e)
        {
            NX_StarWave_Window.Tektronix_SendCommands_Queue.Add(Oscilloscope_SCPI_Commands.CH2 + Oscilloscope_SCPI_Commands.Bandwidth_20MHz);
        }

        private void Channel_2_Termination_1M_Click(object sender, RoutedEventArgs e)
        {
            NX_StarWave_Window.Tektronix_SendCommands_Queue.Add(Oscilloscope_SCPI_Commands.CH2 + Oscilloscope_SCPI_Commands.Termination_1M);
        }

        private void Channel_2_Termination_50_Click(object sender, RoutedEventArgs e)
        {
            NX_StarWave_Window.Tektronix_SendCommands_Queue.Add(Oscilloscope_SCPI_Commands.CH2 + Oscilloscope_SCPI_Commands.Termination_50);
        }

        private void Channel_2_Vertical_Position_SetValue_Click(object sender, RoutedEventArgs e)
        {
            double Value = 0;
            bool isValid = double.TryParse(CH2_Vertical_Postion_TextBox.Text, out Value);
            if (isValid)
            {
                if (Value <= 5 & Value >= -5)
                {
                    NX_StarWave_Window.Tektronix_SendCommands_Queue.Add(Oscilloscope_SCPI_Commands.CH2 + Oscilloscope_SCPI_Commands.Vertical_Position + Value);
                }
                else
                {
                    CH2_Vertical_Postion_TextBox.Text = string.Empty;
                }
            }
            else
            {
                CH2_Vertical_Postion_TextBox.Text = string.Empty;
            }
        }

        private void Channel_2_Vertical_Position_Query_Click(object sender, RoutedEventArgs e)
        {
            NX_StarWave_Window.Tektronix_SendCommands_Queue.Add(Oscilloscope_SCPI_Commands.CH2 + Oscilloscope_SCPI_Commands.Vertical_Position_Query);
        }

        private void Channel_2_Vertical_Offset_SetValue_Click(object sender, RoutedEventArgs e)
        {
            double Value = 0;
            bool isValid = double.TryParse(CH2_Vertical_Offset_TextBox.Text, out Value);
            if (isValid)
            {
                NX_StarWave_Window.Tektronix_SendCommands_Queue.Add(Oscilloscope_SCPI_Commands.CH2 + Oscilloscope_SCPI_Commands.Vertical_Offset + Value);
            }
            else
            {
                CH2_Vertical_Offset_TextBox.Text = string.Empty;
            }
        }

        private void Channel_2_Vertical_Offset_Query_Click(object sender, RoutedEventArgs e)
        {
            NX_StarWave_Window.Tektronix_SendCommands_Queue.Add(Oscilloscope_SCPI_Commands.CH2 + Oscilloscope_SCPI_Commands.Vertical_Offset_Query);
        }
    }
}
