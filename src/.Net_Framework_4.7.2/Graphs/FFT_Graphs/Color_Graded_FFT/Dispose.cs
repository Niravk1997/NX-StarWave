using MahApps.Metro.Controls;
using System;

namespace Color_Graded_FFT
{
    public partial class Color_Graded_FFT_Plotter : MetroWindow
    {
        private void Window_Closed(object sender, EventArgs e)
        {
            try
            {
                Waveform_Data_Queue.Dispose();
                Waveform_Data_Process.Dispose();
                Graph.Plot.Clear();
                Waveform_Data_Process = null;
                Waveform_Data_Queue = null;
                X_Waveform_Values = null;
                Y_Waveform_Values = null;
                Magnitude = null;
                Frequency = null;
                FFT_Hitmap_Array = null;
                FFT_Hitmap = null;
                FFT_Hitmap_Colorbar = null;
                Decay_Interval.Stop();
                Decay_Interval = null;
                this.Close();
            }
            catch (Exception)
            {

            }
        }
    }
}
