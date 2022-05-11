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

                Waveform_Data_Process.Dispose();
                All_Channels_Data_Queue.Dispose();

                Channels_Data_Process_Task_List.Clear();

                this.Close();
            }
            catch (Exception)
            {

            }
        }
    }
}