using MahApps.Metro.Controls;
using System;

namespace Channel_DataLogger
{
    public partial class Math_Waveform : MetroWindow
    {
        private void Window_Closed(object sender, EventArgs e)
        {
            try
            {
                Graph.Plot.Clear();
                Measurement_Data = null;
                Measurement_Plot = null;
                this.Close();
            }
            catch (Exception)
            {

            }
        }
    }
}
