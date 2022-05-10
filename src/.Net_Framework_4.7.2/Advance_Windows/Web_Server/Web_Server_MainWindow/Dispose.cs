using MahApps.Metro.Controls;
using System;

namespace Waveform_Web_Server
{
    public partial class Web_Server_MainWindow : MetroWindow
    {
        private void Window_Closed(object sender, EventArgs e)
        {
            try
            {
                if (Waveform_Web_Server != null)
                {
                    Waveform_Web_Server.Stop();
                    Waveform_Web_Server.Dispose();
                    Waveform_Web_Server = null;
                }
                this.Close();
            }
            catch (Exception)
            {

            }
        }
    }
}