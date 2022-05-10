using MahApps.Metro.Controls;
using System;

namespace Anytime_FFT
{
    public partial class FFT : MetroWindow
    {
        private void Window_Closed(object sender, EventArgs e)
        {
            try
            {
                Graph.Plot.Clear();
                Frequency = null;
                Magnitude = null;
                Phase = null;
                FFT_Waveform = null;
                Phase_Waveform = null;
                X_Waveform_Values = null;
                Y_Waveform_Values = null;
                Functions = null;
                Output_Log = null;
                this.Close();
            }
            catch (Exception)
            {

            }
        }
    }
}
