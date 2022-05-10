using MahApps.Metro.Controls;
using System;
using System.Threading;
using System.Windows;
using System.Windows.Documents;
using System.Windows.Media;
using System.Windows.Threading;

namespace NX_StarWave.Serial_Communication
{
    public partial class COM_Select_Window : MetroWindow
    {
        private void insert_Log(string Message, int Code)
        {
            SolidColorBrush Color = Brushes.Black;
            string Status = "";
            if (Code == 1) //Error Message
            {
                Status = "[Error]";
                Color = Brushes.Red;
            }
            else if (Code == 0) //Success Message
            {
                Status = "[Success]";
                Color = Brushes.Green;
            }
            else if (Code == 2) //Warning Message
            {
                Status = "[Warning]";
                Color = Brushes.Orange;
            }
            else if (Code == 3) //Config Message
            {
                Status = "";
                Color = Brushes.Blue;
            }
            else if (Code == 4)//Standard Message
            {
                Status = "";
                Color = Brushes.Black;
            }
            else if (Code == 5) // Message
            {
                Status = "";
                Color = Brushes.DodgerBlue;
            }
            this.Dispatcher.Invoke(DispatcherPriority.Normal, new ThreadStart(delegate
            {
                Info_Log.Inlines.Add(new Run(Status + " " + Message + "\n") { Foreground = Color });
                Info_Scroll.ScrollToBottom();
            }));
        }

        private void Info_Clear_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Info_Log.Inlines.Clear();
                Info_Log.Text = string.Empty;
            }
            catch (Exception)
            {

            }
        }
    }
}
