using NX_StarWave;
using SCPI_Commands;
using System.Windows;
using System.Windows.Controls;

namespace Channel_4_Control_Window
{
    public partial class Channel_4_Control : UserControl
    {
        public Channel_4_Control()
        {
            InitializeComponent();
        }

        private void Channel_4_ON_Click(object sender, RoutedEventArgs e)
        {
            NX_StarWave_Window.Tektronix_SendCommands_Queue.Add(Oscilloscope_SCPI_Commands.Select + Oscilloscope_SCPI_Commands.CH4 + Oscilloscope_SCPI_Commands.CH_ON);
        }

        private void Channel_4_OFF_Click(object sender, RoutedEventArgs e)
        {
            NX_StarWave_Window.Tektronix_SendCommands_Queue.Add(Oscilloscope_SCPI_Commands.Select + Oscilloscope_SCPI_Commands.CH4 + Oscilloscope_SCPI_Commands.CH_OFF);
        }

        private void Channel_4_Status_Query_Click(object sender, RoutedEventArgs e)
        {
            NX_StarWave_Window.Tektronix_SendCommands_Queue.Add(Oscilloscope_SCPI_Commands.CH4 + Oscilloscope_SCPI_Commands.CH_Status);
        }

        private void Channel_4_Coupling_DC_Click(object sender, RoutedEventArgs e)
        {
            NX_StarWave_Window.Tektronix_SendCommands_Queue.Add(Oscilloscope_SCPI_Commands.CH4 + Oscilloscope_SCPI_Commands.Coupling_DC);
        }

        private void Channel_4_Coupling_AC_Click(object sender, RoutedEventArgs e)
        {
            NX_StarWave_Window.Tektronix_SendCommands_Queue.Add(Oscilloscope_SCPI_Commands.CH4 + Oscilloscope_SCPI_Commands.Coupling_AC);
        }

        private void Channel_4_Coupling_GND_Click(object sender, RoutedEventArgs e)
        {
            NX_StarWave_Window.Tektronix_SendCommands_Queue.Add(Oscilloscope_SCPI_Commands.CH4 + Oscilloscope_SCPI_Commands.Coupling_GND);
        }

        private void Channel_4_Bandwidth_FULL_Click(object sender, RoutedEventArgs e)
        {
            NX_StarWave_Window.Tektronix_SendCommands_Queue.Add(Oscilloscope_SCPI_Commands.CH4 + Oscilloscope_SCPI_Commands.Bandwidth_Full);
        }

        private void Channel_4_Bandwidth_250MHz_Click(object sender, RoutedEventArgs e)
        {
            NX_StarWave_Window.Tektronix_SendCommands_Queue.Add(Oscilloscope_SCPI_Commands.CH4 + Oscilloscope_SCPI_Commands.Bandwidth_250MHz);
        }

        private void Channel_4_Bandwidth_20MHz_Click(object sender, RoutedEventArgs e)
        {
            NX_StarWave_Window.Tektronix_SendCommands_Queue.Add(Oscilloscope_SCPI_Commands.CH4 + Oscilloscope_SCPI_Commands.Bandwidth_20MHz);
        }

        private void Channel_4_Termination_1M_Click(object sender, RoutedEventArgs e)
        {
            NX_StarWave_Window.Tektronix_SendCommands_Queue.Add(Oscilloscope_SCPI_Commands.CH4 + Oscilloscope_SCPI_Commands.Termination_1M);
        }

        private void Channel_4_Termination_50_Click(object sender, RoutedEventArgs e)
        {
            NX_StarWave_Window.Tektronix_SendCommands_Queue.Add(Oscilloscope_SCPI_Commands.CH4 + Oscilloscope_SCPI_Commands.Termination_50);
        }

        private void Channel_4_Vertical_Position_SetValue_Click(object sender, RoutedEventArgs e)
        {
            double Value = 0;
            bool isValid = double.TryParse(CH4_Vertical_Postion_TextBox.Text, out Value);
            if (isValid)
            {
                if (Value <= 5 & Value >= -5)
                {
                    NX_StarWave_Window.Tektronix_SendCommands_Queue.Add(Oscilloscope_SCPI_Commands.CH4 + Oscilloscope_SCPI_Commands.Vertical_Position + Value);
                }
                else
                {
                    CH4_Vertical_Postion_TextBox.Text = string.Empty;
                }
            }
            else
            {
                CH4_Vertical_Postion_TextBox.Text = string.Empty;
            }
        }

        private void Channel_4_Vertical_Position_Query_Click(object sender, RoutedEventArgs e)
        {
            NX_StarWave_Window.Tektronix_SendCommands_Queue.Add(Oscilloscope_SCPI_Commands.CH4 + Oscilloscope_SCPI_Commands.Vertical_Position_Query);
        }

        private void Channel_4_Vertical_Offset_SetValue_Click(object sender, RoutedEventArgs e)
        {
            double Value = 0;
            bool isValid = double.TryParse(CH4_Vertical_Offset_TextBox.Text, out Value);
            if (isValid)
            {
                NX_StarWave_Window.Tektronix_SendCommands_Queue.Add(Oscilloscope_SCPI_Commands.CH4 + Oscilloscope_SCPI_Commands.Vertical_Offset + Value);
            }
            else
            {
                CH4_Vertical_Offset_TextBox.Text = string.Empty;
            }
        }

        private void Channel_4_Vertical_Offset_Query_Click(object sender, RoutedEventArgs e)
        {
            NX_StarWave_Window.Tektronix_SendCommands_Queue.Add(Oscilloscope_SCPI_Commands.CH4 + Oscilloscope_SCPI_Commands.Vertical_Offset_Query);
        }
    }
}
