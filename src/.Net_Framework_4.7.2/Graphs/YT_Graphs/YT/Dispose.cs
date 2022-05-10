using MahApps.Metro.Controls;
using System;

namespace YT
{
    public partial class YT_Plotter : MetroWindow
    {
        private void Window_Closed(object sender, EventArgs e)
        {
            try
            {
                Waveform_Data_Queue.Dispose();
                Waveform_Data_Process.Dispose();
                Graph.Plot.Clear();
                Waveform_Curve = null;
                X_Waveform_Values = null;
                Y_Waveform_Values = null;
                Waveform_Data_Process = null;
                Waveform_Data_Queue = null;
                this.Close();
            }
            catch (Exception)
            {

            }
        }
    }
}
