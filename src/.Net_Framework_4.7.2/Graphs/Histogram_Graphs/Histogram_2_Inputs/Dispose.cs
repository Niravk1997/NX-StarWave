using MahApps.Metro.Controls;
using System;

namespace Histogram_2_Input
{
    public partial class Histogram_2_Input_Window : MetroWindow
    {
        private void Window_Closed(object sender, EventArgs e)
        {
            try
            {
                Input_1_Data_Queue.Dispose();
                Input_2_Data_Queue.Dispose();
                Graph.Plot.Clear();
                Waveform_Data_Process.Close();
                Waveform_Data_Process.Dispose();
                Waveform_Data_Process = null;
                Input_1_Data_Queue = null;
                Input_2_Data_Queue = null;
                Input_1_X_Waveform_Values = null;
                Input_1_Y_Waveform_Values = null;
                Input_2_X_Waveform_Values = null;
                Input_2_Y_Waveform_Values = null;
                Histogram_Input_1 = null;
                Histogram_Input_2 = null;
                Histogram_Data_Input_1 = null;
                Histogram_Data_Input_2 = null;
                this.Close();
            }
            catch (Exception)
            {

            }
        }
    }
}
