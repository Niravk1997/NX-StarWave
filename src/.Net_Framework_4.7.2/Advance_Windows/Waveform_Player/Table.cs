using MahApps.Metro.Controls;
using System;
using System.Windows;

namespace Waveform_Player
{
    public partial class Waveform_Player_Window : MetroWindow
    {
        private void Clear_Table_Click(object sender, RoutedEventArgs e)
        {
            if (Is_Play_Mode_Running == false & Saving_to_SQLite_DataBase_Queue_InProgress == false & Reading_from_SQLite_DataBase_Queue_InProgress == false)
            {
                try
                {
                    Waveform_Data.Clear();
                }
                catch (Exception Ex)
                {
                    Insert_Log(Ex.Message, 1);
                }
            }
            else
            {
                Insert_Log("Cannot clear Table. Make sure No SQLite operations are active and Play Mode is not running.", 2);
            }
        }
    }
}
