using MahApps.Metro.Controls;
using System;

namespace Anytime_Waveform
{
    public partial class Waveform : MetroWindow
    {
        private void Window_Closed(object sender, EventArgs e)
        {
            try
            {
                Graph.Plot.Clear();
                Waveform_Curve = null;
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
