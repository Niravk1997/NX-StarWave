using MahApps.Metro.Controls;
using System;

namespace FFT_Waveform
{
    public partial class FFT_Waveform_Plotter : MetroWindow
    {
        private void Window_Closed(object sender, EventArgs e)
        {
            try
            {
                Waveform_Data_Queue.Dispose();
                Waveform_Data_Process.Dispose();
                Graph.Plot.Clear();
                Waveform_Curve = null;
                FFT_Waveform = null;
                Waveform_Data_Process = null;
                Waveform_Data_Queue = null;
                Phase_Waveform = null;
                X_Waveform_Values = null;
                Y_Waveform_Values = null;
                True_Y_Waveform_Values = null;
                Magnitude = null;
                Frequency = null;
                Phase = null;
                this.Close();
            }
            catch (Exception)
            {

            }
        }
    }
}
