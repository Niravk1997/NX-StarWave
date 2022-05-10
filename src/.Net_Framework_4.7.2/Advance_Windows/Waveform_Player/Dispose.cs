using MahApps.Metro.Controls;
using System;

namespace Waveform_Player
{
    public partial class Waveform_Player_Window : MetroWindow
    {
        private void Window_Closed(object sender, EventArgs e)
        {
            try
            {
                Waveform_Data_Process.Stop();
                SQLite_Data_Process.Stop();
                SQLite_Read_Data_Process.Stop();
                SQLite_Data_Process.Dispose();
                Waveform_Data_Process.Dispose();
                SQLite_Read_Data_Process.Dispose();

                Waveform_Data.Clear();
                All_Channels_Data_Queue.Dispose();
                Save_Waveforms_SQLite_DataBase_Queue.Dispose();
                Insert_Waveforms_Graph_Windows_Queue.Dispose();
                Read_Waveforms_SQLite_DataBase_Queue.Dispose();

                this.Close();
            }
            catch (Exception)
            {

            }
        }
    }
}
