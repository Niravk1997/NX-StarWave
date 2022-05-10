using Compare_YT;
using MahApps.Metro.Controls;
using System;
using System.Globalization;
using System.Threading;
using System.Windows;
using System.Windows.Threading;
using Waveform_Player;

namespace NX_StarWave
{
    public partial class NX_StarWave_Window : MetroWindow
    {
        private Waveform_Player_Window Waveform_Player_Window;
        private Compare_YT_Plots Compare_YT_Plots_Window;

        private bool Waveform_Player_Window_isOpen = false;
        private bool Compare_YT_Plots_Window_isOpen = false;

        private void Initialize_Analysis_Windows_Open_EventHandler()
        {
            AddHandler(Analysis_Graph_Control.Analysis_Graph_Control.Waveform_Player_Open_Event, new RoutedEventHandler(Waveform_Player_Open_Click));
            AddHandler(Analysis_Graph_Control.Analysis_Graph_Control.Compare_YT_Plots_Open_Event, new RoutedEventHandler(Compare_YT_Plots_Open_Click));
        }

        private void Waveform_Player_Open_Click(object sender, RoutedEventArgs e)
        {
            if (Waveform_Player_Window == null & Waveform_Player_Window_isOpen == false)
            {
                Waveform_Player_Window_isOpen = true;
                Waveform_Player_Selected = Graph_Selected;
                Waveform_Player_Window = new Waveform_Player_Window();
                Waveform_Player_Window.Show();
                Waveform_Player_Window.Closed += Waveform_Player_Close;
                insert_Log("Waveform Player Window has been opened.", 0);
            }
            else
            {
                insert_Log("Waveform Player Window is already open.", 2);
            }
        }

        private void Waveform_Player_Close(object sender, EventArgs e)
        {
            Waveform_Player_Window.Closed -= Waveform_Player_Close;
            Waveform_Player_Window = null;
            Waveform_Player_Window_isOpen = false;
            this.Dispatcher.BeginInvoke(DispatcherPriority.Normal, (Action)(() =>
            {
                Waveform_Player_Selected = Graph_Not_Selected;
            }));
            insert_Log("Waveform Player  Window has been closed.", 0);
        }

        private void Compare_YT_Plots_Open_Click(object sender, RoutedEventArgs e)
        {
            if (Compare_YT_Plots_Window == null & Compare_YT_Plots_Window_isOpen == false)
            {
                Compare_YT_Plots_Window_isOpen = true;
                Compare_YT_Plots_Selected = Graph_Selected;
                Thread Window_Thread = new Thread(new ThreadStart(() =>
                {
                    Compare_YT_Plots_Window = new Compare_YT_Plots();
                    Compare_YT_Plots_Window.Show();
                    Compare_YT_Plots_Window.Closed += Compare_YT_Plots_Close;
                    Dispatcher.Run();
                }));
                Window_Thread.CurrentCulture = CultureInfo.CreateSpecificCulture("en-US");
                Window_Thread.CurrentUICulture = CultureInfo.CreateSpecificCulture("en-US");
                Window_Thread.SetApartmentState(ApartmentState.STA);
                Window_Thread.IsBackground = true;
                Window_Thread.Start();
                insert_Log("Reference Calculator Window has been opened.", 0);
            }
            else
            {
                insert_Log("Compare YT Plots Window is already open.", 2);
            }
        }

        private void Compare_YT_Plots_Close(object sender, EventArgs e)
        {
            Compare_YT_Plots_Window.Closed -= Compare_YT_Plots_Close;
            Compare_YT_Plots_Window.Dispatcher.BeginInvokeShutdown(DispatcherPriority.Normal);
            Compare_YT_Plots_Window = null;
            Compare_YT_Plots_Window_isOpen = false;
            this.Dispatcher.BeginInvoke(DispatcherPriority.Normal, (Action)(() =>
            {
                Compare_YT_Plots_Selected = Graph_Not_Selected;
            }));
            insert_Log("Compare YT Plots Window has been closed.", 0);
        }
    }
}
