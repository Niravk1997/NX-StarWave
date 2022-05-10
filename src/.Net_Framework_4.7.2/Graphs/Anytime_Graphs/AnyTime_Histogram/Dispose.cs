using MahApps.Metro.Controls;
using System;

namespace Anytime_Histogram
{
    public partial class Histogram : MetroWindow
    {
        private void Window_Closed(object sender, EventArgs e)
        {
            try
            {
                Graph.Plot.Clear();
                X_Waveform_Values = null;
                Y_Waveform_Values = null;
                this.Close();
            }
            catch (Exception)
            {

            }
        }
    }
}
