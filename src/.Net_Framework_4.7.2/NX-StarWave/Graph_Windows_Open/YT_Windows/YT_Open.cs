using MahApps.Metro.Controls;
using System;
using System.Globalization;
using System.Threading;
using System.Windows;
using System.Windows.Threading;
using YT;

namespace NX_StarWave
{
    public partial class NX_StarWave_Window : MetroWindow
    {
        private YT_Plotter Channel_1_YT;
        private YT_Plotter Channel_2_YT;
        private YT_Plotter Channel_3_YT;
        private YT_Plotter Channel_4_YT;

        private bool Channel_1_YT_isOpen = false;
        private bool Channel_2_YT_isOpen = false;
        private bool Channel_3_YT_isOpen = false;
        private bool Channel_4_YT_isOpen = false;

        private void Initialize_YT_EventHandler()
        {
            AddHandler(YT_Graph_Control.YT_Graph_Control.CH1_YT_Open_Event, new RoutedEventHandler(CH1_YT_Open_Click));
            AddHandler(YT_Graph_Control.YT_Graph_Control.CH2_YT_Open_Event, new RoutedEventHandler(CH2_YT_Open_Click));
            AddHandler(YT_Graph_Control.YT_Graph_Control.CH3_YT_Open_Event, new RoutedEventHandler(CH3_YT_Open_Click));
            AddHandler(YT_Graph_Control.YT_Graph_Control.CH4_YT_Open_Event, new RoutedEventHandler(CH4_YT_Open_Click));
        }

        private void CH1_YT_Open_Click(object sender, RoutedEventArgs e)
        {
            if (Channel_1_YT == null & Channel_1_YT_isOpen == false)
            {
                Channel_1_YT_isOpen = true;
                string Channel_Color = Channel_1_Color.ToString();
                YT_CH1_Graph_Selected = Graph_Selected;
                Thread Window_Thread = new Thread(new ThreadStart(() =>
                {
                    Channel_1_YT = new YT_Plotter(Communication_Selected.Company_Name + " " + Communication_Selected.Oscilloscope_Model + " " + "Channel 1 YT Window", "CH1", Channel_Color);
                    Channel_1_YT.Show();
                    Channel_1_YT.Closed += CH1_YT_Close;
                    Dispatcher.Run();
                }));
                Window_Thread.CurrentCulture = CultureInfo.CreateSpecificCulture("en-US");
                Window_Thread.CurrentUICulture = CultureInfo.CreateSpecificCulture("en-US");
                Window_Thread.SetApartmentState(ApartmentState.STA);
                Window_Thread.IsBackground = true;
                Window_Thread.Start();
                insert_Log("Channel 1 YT Graph Window has been opened.", 0);
            }
            else
            {
                insert_Log("Channel 1 YT Graph Window is already open.", 2);
            }
        }

        private void CH1_YT_Close(object sender, EventArgs e)
        {
            Channel_1_YT.Closed -= CH1_YT_Close;
            Channel_1_YT.Dispatcher.BeginInvokeShutdown(DispatcherPriority.Normal);
            Channel_1_YT = null;
            Channel_1_YT_isOpen = false;
            this.Dispatcher.BeginInvoke(DispatcherPriority.Normal, (Action)(() =>
            {
                YT_CH1_Graph_Selected = Graph_Not_Selected;
            }));
            insert_Log("Channel 1 YT Graph Window has been closed.", 0);
        }

        private void CH2_YT_Open_Click(object sender, RoutedEventArgs e)
        {
            if (Channel_2_YT == null & Channel_2_YT_isOpen == false)
            {
                Channel_2_YT_isOpen = true;
                string Channel_Color = Channel_2_Color.ToString();
                YT_CH2_Graph_Selected = Graph_Selected;
                Thread Window_Thread = new Thread(new ThreadStart(() =>
                {
                    Channel_2_YT = new YT_Plotter(Communication_Selected.Company_Name + " " + Communication_Selected.Oscilloscope_Model + " " + "Channel 2 YT Window", "CH2", Channel_Color);
                    Channel_2_YT.Show();
                    Channel_2_YT.Closed += CH2_YT_Close;
                    Dispatcher.Run();
                }));
                Window_Thread.CurrentCulture = CultureInfo.CreateSpecificCulture("en-US");
                Window_Thread.CurrentUICulture = CultureInfo.CreateSpecificCulture("en-US");
                Window_Thread.SetApartmentState(ApartmentState.STA);
                Window_Thread.IsBackground = true;
                Window_Thread.Start();
                insert_Log("Channel 2 YT Graph Window has been opened.", 0);
            }
            else
            {
                insert_Log("Channel 2 YT Graph Window is already open.", 2);
            }
        }

        private void CH2_YT_Close(object sender, EventArgs e)
        {
            Channel_2_YT.Closed -= CH2_YT_Close;
            Channel_2_YT.Dispatcher.BeginInvokeShutdown(DispatcherPriority.Normal);
            Channel_2_YT = null;
            Channel_2_YT_isOpen = false;
            this.Dispatcher.BeginInvoke(DispatcherPriority.Normal, (Action)(() =>
            {
                YT_CH2_Graph_Selected = Graph_Not_Selected;
            }));
            insert_Log("Channel 2 YT Graph Window has been closed.", 0);
        }

        private void CH3_YT_Open_Click(object sender, RoutedEventArgs e)
        {
            if (Channel_3_YT == null & Channel_3_YT_isOpen == false)
            {
                Channel_3_YT_isOpen = true;
                string Channel_Color = Channel_3_Color.ToString();
                YT_CH3_Graph_Selected = Graph_Selected;
                Thread Window_Thread = new Thread(new ThreadStart(() =>
                {
                    Channel_3_YT = new YT_Plotter(Communication_Selected.Company_Name + " " + Communication_Selected.Oscilloscope_Model + " " + "Channel 3 YT Window", "CH3", Channel_Color);
                    Channel_3_YT.Show();
                    Channel_3_YT.Closed += CH3_YT_Close;
                    Dispatcher.Run();
                }));
                Window_Thread.CurrentCulture = CultureInfo.CreateSpecificCulture("en-US");
                Window_Thread.CurrentUICulture = CultureInfo.CreateSpecificCulture("en-US");
                Window_Thread.SetApartmentState(ApartmentState.STA);
                Window_Thread.IsBackground = true;
                Window_Thread.Start();
                insert_Log("Channel 3 YT Graph Window has been opened.", 0);
            }
            else
            {
                insert_Log("Channel 3 YT Graph Window is already open.", 2);
            }
        }

        private void CH3_YT_Close(object sender, EventArgs e)
        {
            Channel_3_YT.Closed -= CH3_YT_Close;
            Channel_3_YT.Dispatcher.BeginInvokeShutdown(DispatcherPriority.Normal);
            Channel_3_YT = null;
            Channel_3_YT_isOpen = false;
            this.Dispatcher.BeginInvoke(DispatcherPriority.Normal, (Action)(() =>
            {
                YT_CH3_Graph_Selected = Graph_Not_Selected;
            }));
            insert_Log("Channel 3 YT Graph Window has been closed.", 0);
        }

        private void CH4_YT_Open_Click(object sender, RoutedEventArgs e)
        {
            if (Channel_4_YT == null & Channel_4_YT_isOpen == false)
            {
                Channel_4_YT_isOpen = true;
                string Channel_Color = Channel_4_Color.ToString();
                YT_CH4_Graph_Selected = Graph_Selected;
                Thread Window_Thread = new Thread(new ThreadStart(() =>
                {
                    Channel_4_YT = new YT_Plotter(Communication_Selected.Company_Name + " " + Communication_Selected.Oscilloscope_Model + " " + "Channel 4 YT Window", "CH4", Channel_Color);
                    Channel_4_YT.Show();
                    Channel_4_YT.Closed += CH4_YT_Close;
                    Dispatcher.Run();
                }));
                Window_Thread.CurrentCulture = CultureInfo.CreateSpecificCulture("en-US");
                Window_Thread.CurrentUICulture = CultureInfo.CreateSpecificCulture("en-US");
                Window_Thread.SetApartmentState(ApartmentState.STA);
                Window_Thread.IsBackground = true;
                Window_Thread.Start();
                insert_Log("Channel 4 YT Graph Window has been opened.", 0);
            }
            else
            {
                insert_Log("Channel 4 YT Graph Window is already open.", 2);
            }
        }

        private void CH4_YT_Close(object sender, EventArgs e)
        {
            Channel_4_YT.Closed -= CH4_YT_Close;
            Channel_4_YT.Dispatcher.BeginInvokeShutdown(DispatcherPriority.Normal);
            Channel_4_YT = null;
            Channel_4_YT_isOpen = false;
            this.Dispatcher.BeginInvoke(DispatcherPriority.Normal, (Action)(() =>
            {
                YT_CH4_Graph_Selected = Graph_Not_Selected;
            }));
            insert_Log("All Channels YT Graph Window has been closed.", 0);
        }
    }
}
