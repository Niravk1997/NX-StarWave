using Channel_DataLogger;
using MahApps.Metro.Controls;
using System;
using System.Globalization;
using System.Threading;
using System.Windows;
using System.Windows.Threading;

namespace NX_StarWave
{
    public partial class NX_StarWave_Window : MetroWindow
    {
        private CH_DataLog_Graph_Window Channel_1_DataLog;
        private CH_DataLog_Graph_Window Channel_2_DataLog;
        private CH_DataLog_Graph_Window Channel_3_DataLog;
        private CH_DataLog_Graph_Window Channel_4_DataLog;

        private bool Channel_1_DataLog_isOpen = false;
        private bool Channel_2_DataLog_isOpen = false;
        private bool Channel_3_DataLog_isOpen = false;
        private bool Channel_4_DataLog_isOpen = false;

        private void Initialize_DataLog_EventHandler()
        {
            AddHandler(DataLog_Graph_Control.DataLog_Graph_Control.CH1_DataLog_Open_Event, new RoutedEventHandler(CH1_DataLog_Open_Click));
            AddHandler(DataLog_Graph_Control.DataLog_Graph_Control.CH2_DataLog_Open_Event, new RoutedEventHandler(CH2_DataLog_Open_Click));
            AddHandler(DataLog_Graph_Control.DataLog_Graph_Control.CH3_DataLog_Open_Event, new RoutedEventHandler(CH3_DataLog_Open_Click));
            AddHandler(DataLog_Graph_Control.DataLog_Graph_Control.CH4_DataLog_Open_Event, new RoutedEventHandler(CH4_DataLog_Open_Click));
        }

        private void CH1_DataLog_Open_Click(object sender, RoutedEventArgs e)
        {
            if (Channel_1_DataLog == null & Channel_1_DataLog_isOpen == false)
            {
                Channel_1_DataLog_isOpen = true;
                string Channel_Color = Channel_1_Color.ToString();
                Datalog_CH1_Graph_Selected = Graph_Selected;
                Thread Window_Thread = new Thread(new ThreadStart(() =>
                {
                    Channel_1_DataLog = new CH_DataLog_Graph_Window("CH1 Voltage (v)", Communication_Selected.Company_Name + " " + Communication_Selected.Oscilloscope_Model + " " + "Channel 1", Channel_Color);
                    Channel_1_DataLog.Show();
                    Channel_1_DataLog.Closed += CH1_DataLog_Close;
                    Dispatcher.Run();
                }));
                Window_Thread.CurrentCulture = CultureInfo.CreateSpecificCulture("en-US");
                Window_Thread.CurrentUICulture = CultureInfo.CreateSpecificCulture("en-US");
                Window_Thread.SetApartmentState(ApartmentState.STA);
                Window_Thread.IsBackground = true;
                Window_Thread.Start();
                insert_Log("Channel 1 Data Log Graph Window has been opened.", 0);
            }
            else
            {
                insert_Log("Channel 1 Data Log Graph Window is already open.", 2);
            }
        }

        private void CH1_DataLog_Close(object sender, EventArgs e)
        {
            Channel_1_DataLog.Closed -= CH1_DataLog_Close;
            Channel_1_DataLog.Dispatcher.BeginInvokeShutdown(DispatcherPriority.Normal);
            Channel_1_DataLog = null;
            Channel_1_DataLog_isOpen = false;
            this.Dispatcher.BeginInvoke(DispatcherPriority.Normal, (Action)(() =>
            {
                Datalog_CH1_Graph_Selected = Graph_Not_Selected;
            }));
            insert_Log("Channel 1 Data Log Graph Window has been closed.", 0);
        }

        private void CH2_DataLog_Open_Click(object sender, RoutedEventArgs e)
        {
            if (Channel_2_DataLog == null & Channel_2_DataLog_isOpen == false)
            {
                Channel_2_DataLog_isOpen = true;
                string Channel_Color = Channel_2_Color.ToString();
                Datalog_CH2_Graph_Selected = Graph_Selected;
                Thread Window_Thread = new Thread(new ThreadStart(() =>
                {
                    Channel_2_DataLog = new CH_DataLog_Graph_Window("CH2 Voltage (v)", Communication_Selected.Company_Name + " " + Communication_Selected.Oscilloscope_Model + " " + "Channel 2", Channel_Color);
                    Channel_2_DataLog.Show();
                    Channel_2_DataLog.Closed += CH2_DataLog_Close;
                    Dispatcher.Run();
                }));
                Window_Thread.CurrentCulture = CultureInfo.CreateSpecificCulture("en-US");
                Window_Thread.CurrentUICulture = CultureInfo.CreateSpecificCulture("en-US");
                Window_Thread.SetApartmentState(ApartmentState.STA);
                Window_Thread.IsBackground = true;
                Window_Thread.Start();
                insert_Log("Channel 2 Data Log Graph Window has been opened.", 0);
            }
            else
            {
                insert_Log("Channel 2 Data Log Graph Window is already open.", 2);
            }
        }

        private void CH2_DataLog_Close(object sender, EventArgs e)
        {
            Channel_2_DataLog.Closed -= CH2_DataLog_Close;
            Channel_2_DataLog.Dispatcher.BeginInvokeShutdown(DispatcherPriority.Normal);
            Channel_2_DataLog = null;
            Channel_2_DataLog_isOpen = false;
            this.Dispatcher.BeginInvoke(DispatcherPriority.Normal, (Action)(() =>
            {
                Datalog_CH2_Graph_Selected = Graph_Not_Selected;
            }));
            insert_Log("Channel 2 Data Log Graph Window has been closed.", 0);
        }

        private void CH3_DataLog_Open_Click(object sender, RoutedEventArgs e)
        {
            if (Channel_3_DataLog == null & Channel_3_DataLog_isOpen == false)
            {
                Channel_3_DataLog_isOpen = true;
                string Channel_Color = Channel_3_Color.ToString();
                Datalog_CH3_Graph_Selected = Graph_Selected;
                Thread Window_Thread = new Thread(new ThreadStart(() =>
                {
                    Channel_3_DataLog = new CH_DataLog_Graph_Window("CH3 Voltage (v)", Communication_Selected.Company_Name + " " + Communication_Selected.Oscilloscope_Model + " " + "Channel 3", Channel_Color);
                    Channel_3_DataLog.Show();
                    Channel_3_DataLog.Closed += CH3_DataLog_Close;
                    Dispatcher.Run();
                }));
                Window_Thread.CurrentCulture = CultureInfo.CreateSpecificCulture("en-US");
                Window_Thread.CurrentUICulture = CultureInfo.CreateSpecificCulture("en-US");
                Window_Thread.SetApartmentState(ApartmentState.STA);
                Window_Thread.IsBackground = true;
                Window_Thread.Start();
                insert_Log("Channel 3 Data Log Graph Window has been opened.", 0);
            }
            else
            {
                insert_Log("Channel 3 Data Log Graph Window is already open.", 2);
            }
        }

        private void CH3_DataLog_Close(object sender, EventArgs e)
        {
            Channel_3_DataLog.Closed -= CH3_DataLog_Close;
            Channel_3_DataLog.Dispatcher.BeginInvokeShutdown(DispatcherPriority.Normal);
            Channel_3_DataLog = null;
            Channel_3_DataLog_isOpen = false;
            this.Dispatcher.BeginInvoke(DispatcherPriority.Normal, (Action)(() =>
            {
                Datalog_CH3_Graph_Selected = Graph_Not_Selected;
            }));
            insert_Log("Channel 3 Data Log Graph Window has been closed.", 0);
        }

        private void CH4_DataLog_Open_Click(object sender, RoutedEventArgs e)
        {
            if (Channel_4_DataLog == null & Channel_4_DataLog_isOpen == false)
            {
                Channel_4_DataLog_isOpen = true;
                string Channel_Color = Channel_4_Color.ToString();
                Datalog_CH4_Graph_Selected = Graph_Selected;
                Thread Window_Thread = new Thread(new ThreadStart(() =>
                {
                    Channel_4_DataLog = new CH_DataLog_Graph_Window("CH4 Voltage (v)", Communication_Selected.Company_Name + " " + Communication_Selected.Oscilloscope_Model + " " + "Channel 4", Channel_Color);
                    Channel_4_DataLog.Show();
                    Channel_4_DataLog.Closed += CH4_DataLog_Close;
                    Dispatcher.Run();
                }));
                Window_Thread.CurrentCulture = CultureInfo.CreateSpecificCulture("en-US");
                Window_Thread.CurrentUICulture = CultureInfo.CreateSpecificCulture("en-US");
                Window_Thread.SetApartmentState(ApartmentState.STA);
                Window_Thread.IsBackground = true;
                Window_Thread.Start();
                insert_Log("Channel 4 Data Log Graph Window has been opened.", 0);
            }
            else
            {
                insert_Log("Channel 4 Data Log Graph Window is already open.", 2);
            }
        }

        private void CH4_DataLog_Close(object sender, EventArgs e)
        {
            Channel_4_DataLog.Closed -= CH4_DataLog_Close;
            Channel_4_DataLog.Dispatcher.BeginInvokeShutdown(DispatcherPriority.Normal);
            Channel_4_DataLog = null;
            Channel_4_DataLog_isOpen = false;
            this.Dispatcher.BeginInvoke(DispatcherPriority.Normal, (Action)(() =>
            {
                Datalog_CH4_Graph_Selected = Graph_Not_Selected;
            }));
            insert_Log("Channel 4 Data Log Graph Window has been closed.", 0);
        }
    }
}
