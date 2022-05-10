using MahApps.Metro.Controls;
using System;

namespace Histogram
{
    public partial class Histogram_Plotter : MetroWindow
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
                Histogram = null;
                Histogram_Data = null;
                Histogram_Values = null;
                values = null;
                positions = null;
                this.Close();
            }
            catch (Exception)
            {

            }
        }
    }
}
