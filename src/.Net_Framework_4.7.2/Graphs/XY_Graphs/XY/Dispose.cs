using MahApps.Metro.Controls;
using System;

namespace XY
{
    public partial class XY_Plotter : MetroWindow
    {
        private void Window_Closed(object sender, EventArgs e)
        {
            try
            {
                All_Channels_Data_Queue.Dispose();
                Waveform_Data_Process.Dispose();
                Graph.Plot.Clear();
                Waveform_Data_Process = null;
                All_Channels_Data_Queue = null;
                CH1_X_Waveform_Values = null;
                CH1_Y_Waveform_Values = null;
                CH2_X_Waveform_Values = null;
                CH2_Y_Waveform_Values = null;
                this.Close();
            }
            catch (Exception)
            {

            }
        }
    }
}
