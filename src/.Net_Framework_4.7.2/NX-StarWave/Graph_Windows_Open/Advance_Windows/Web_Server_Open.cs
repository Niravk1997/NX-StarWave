using MahApps.Metro.Controls;
using System;
using System.Globalization;
using System.Threading;
using System.Windows;
using System.Windows.Threading;
using Waveform_Web_Server;

namespace NX_StarWave
{
    public partial class NX_StarWave_Window : MetroWindow
    {
        private Web_Server_MainWindow Waveform_Web_Server;
        private bool Web_Server_Window_isOpen = false;

        private void Initialize_Web_Server_EventHandler()
        {
            AddHandler(Home_Control_Window.Home_Control.Web_Server_Open_Event, new RoutedEventHandler(Web_Server_Open_Click));
        }

        private void Web_Server_Open_Click(object sender, RoutedEventArgs e)
        {
            if (Waveform_Web_Server == null & Web_Server_Window_isOpen == false)
            {
                Web_Server_Window_isOpen = true;
                Web_Server_Selected = Graph_Selected;
                Thread Window_Thread = new Thread(new ThreadStart(() =>
                {
                    Waveform_Web_Server = new Web_Server_MainWindow();
                    Waveform_Web_Server.Show();
                    Waveform_Web_Server.Closed += Web_Server_Close;
                    Dispatcher.Run();
                }));
                Window_Thread.CurrentCulture = CultureInfo.CreateSpecificCulture("en-US");
                Window_Thread.CurrentUICulture = CultureInfo.CreateSpecificCulture("en-US");
                Window_Thread.SetApartmentState(ApartmentState.STA);
                Window_Thread.IsBackground = true;
                Window_Thread.Start();
                insert_Log("Web Server Window has been opened.", 0);
            }
            else
            {
                insert_Log("Web Server Window is already open.", 2);
            }
        }

        private void Web_Server_Close(object sender, EventArgs e)
        {
            Waveform_Web_Server.Closed -= Waveform_Calculator_Close;
            Waveform_Web_Server.Dispatcher.BeginInvokeShutdown(DispatcherPriority.Normal);
            Waveform_Web_Server = null;
            Web_Server_Window_isOpen = false;
            this.Dispatcher.BeginInvoke(DispatcherPriority.Normal, (Action)(() =>
            {
                Web_Server_Selected = Graph_Not_Selected;
            }));
            insert_Log("Web Server Window has been closed.", 0);
        }
    }
}
