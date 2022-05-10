using MahApps.Metro.Controls;
using System;

namespace Channel_DataLogger
{
    public partial class Histogram_Waveform : MetroWindow
    {
        private void Window_Closed(object sender, EventArgs e)
        {
            try
            {
                Graph.Plot.Clear();
                Measurement_Data = null;
                Graph = null;
                this.Close();
            }
            catch (Exception)
            {

            }
        }
    }
}
