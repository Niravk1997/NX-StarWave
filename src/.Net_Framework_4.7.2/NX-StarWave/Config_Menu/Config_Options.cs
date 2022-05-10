using MahApps.Metro.Controls;
using System.Windows;

namespace NX_StarWave
{
    public partial class NX_StarWave_Window : MetroWindow
    {
        private void Local_Exit_Click(object sender, RoutedEventArgs e)
        {
            Tektronix_SendCommands_Queue.Add("LOCAL_EXIT");
            insert_Log("Local Exit Command send. Please wait....", 0);
        }
    }
}
