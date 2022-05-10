using Histogram;
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
        private Histogram_Plotter Channel_1_Histogram;
        private Histogram_Plotter Channel_2_Histogram;
        private Histogram_Plotter Channel_3_Histogram;
        private Histogram_Plotter Channel_4_Histogram;

        private bool Channel_1_Histogram_isOpen = false;
        private bool Channel_2_Histogram_isOpen = false;
        private bool Channel_3_Histogram_isOpen = false;
        private bool Channel_4_Histogram_isOpen = false;

        private void Initialize_Histogram_EventHandler()
        {
            AddHandler(Histogram_Graph_Control.Histogram_Graph_Control.CH1_Histogram_Open_Event, new RoutedEventHandler(CH1_Histogram_Open_Click));
            AddHandler(Histogram_Graph_Control.Histogram_Graph_Control.CH2_Histogram_Open_Event, new RoutedEventHandler(CH2_Histogram_Open_Click));
            AddHandler(Histogram_Graph_Control.Histogram_Graph_Control.CH3_Histogram_Open_Event, new RoutedEventHandler(CH3_Histogram_Open_Click));
            AddHandler(Histogram_Graph_Control.Histogram_Graph_Control.CH4_Histogram_Open_Event, new RoutedEventHandler(CH4_Histogram_Open_Click));
        }

        private void CH1_Histogram_Open_Click(object sender, RoutedEventArgs e)
        {
            if (Channel_1_Histogram == null & Channel_1_Histogram_isOpen == false)
            {
                string Channel_Color = Channel_1_Color.ToString();
                Channel_1_Histogram_isOpen = true;
                Histogram_CH1_Graph_Selected = Graph_Selected;
                Thread Window_Thread = new Thread(new ThreadStart(() =>
                {
                    Channel_1_Histogram = new Histogram_Plotter(Communication_Selected.Company_Name + " " + Communication_Selected.Oscilloscope_Model + " " + "Channel 1 Histogram", "CH1", Channel_Color);
                    Channel_1_Histogram.Show();
                    Channel_1_Histogram.Closed += CH1_Histogram_Close;
                    Dispatcher.Run();
                }));
                Window_Thread.CurrentCulture = CultureInfo.CreateSpecificCulture("en-US");
                Window_Thread.CurrentUICulture = CultureInfo.CreateSpecificCulture("en-US");
                Window_Thread.SetApartmentState(ApartmentState.STA);
                Window_Thread.IsBackground = true;
                Window_Thread.Start();
                insert_Log("Channel 1 Histogram Window has been opened.", 0);
            }
            else
            {
                insert_Log("Channel 1 Histogram Window is already open.", 2);
            }
        }

        private void CH1_Histogram_Close(object sender, EventArgs e)
        {
            Channel_1_Histogram.Closed -= CH1_Histogram_Close;
            Channel_1_Histogram.Dispatcher.BeginInvokeShutdown(DispatcherPriority.Normal);
            Channel_1_Histogram = null;
            Channel_1_Histogram_isOpen = false;
            this.Dispatcher.BeginInvoke(DispatcherPriority.Normal, (Action)(() =>
            {
                Histogram_CH1_Graph_Selected = Graph_Not_Selected;
            }));
            insert_Log("Channel 1 Histogram Window has been closed.", 0);
        }

        private void CH2_Histogram_Open_Click(object sender, RoutedEventArgs e)
        {
            if (Channel_2_Histogram == null & Channel_2_Histogram_isOpen == false)
            {
                string Channel_Color = Channel_2_Color.ToString();
                Channel_2_Histogram_isOpen = true;
                Histogram_CH2_Graph_Selected = Graph_Selected;
                Thread Window_Thread = new Thread(new ThreadStart(() =>
                {
                    Channel_2_Histogram = new Histogram_Plotter(Communication_Selected.Company_Name + " " + Communication_Selected.Oscilloscope_Model + " " + "Channel 2 Histogram", "CH2", Channel_Color);
                    Channel_2_Histogram.Show();
                    Channel_2_Histogram.Closed += CH2_Histogram_Close;
                    Dispatcher.Run();
                }));
                Window_Thread.CurrentCulture = CultureInfo.CreateSpecificCulture("en-US");
                Window_Thread.CurrentUICulture = CultureInfo.CreateSpecificCulture("en-US");
                Window_Thread.SetApartmentState(ApartmentState.STA);
                Window_Thread.IsBackground = true;
                Window_Thread.Start();
                insert_Log("Channel 2 Histogram Window has been opened.", 0);
            }
            else
            {
                insert_Log("Channel 2 Histogram Window is already open.", 2);
            }
        }

        private void CH2_Histogram_Close(object sender, EventArgs e)
        {
            Channel_2_Histogram.Closed -= CH2_Histogram_Close;
            Channel_2_Histogram.Dispatcher.BeginInvokeShutdown(DispatcherPriority.Normal);
            Channel_2_Histogram = null;
            Channel_2_Histogram_isOpen = false;
            this.Dispatcher.BeginInvoke(DispatcherPriority.Normal, (Action)(() =>
            {
                Histogram_CH2_Graph_Selected = Graph_Not_Selected;
            }));
            insert_Log("Channel 2 Histogram Window has been closed.", 0);
        }

        private void CH3_Histogram_Open_Click(object sender, RoutedEventArgs e)
        {
            if (Channel_3_Histogram == null & Channel_3_Histogram_isOpen == false)
            {
                string Channel_Color = Channel_3_Color.ToString();
                Channel_3_Histogram_isOpen = true;
                Histogram_CH3_Graph_Selected = Graph_Selected;
                Thread Window_Thread = new Thread(new ThreadStart(() =>
                {
                    Channel_3_Histogram = new Histogram_Plotter(Communication_Selected.Company_Name + " " + Communication_Selected.Oscilloscope_Model + " " + "Channel 3 Histogram", "CH3", Channel_Color);
                    Channel_3_Histogram.Show();
                    Channel_3_Histogram.Closed += CH3_Histogram_Close;
                    Dispatcher.Run();
                }));
                Window_Thread.CurrentCulture = CultureInfo.CreateSpecificCulture("en-US");
                Window_Thread.CurrentUICulture = CultureInfo.CreateSpecificCulture("en-US");
                Window_Thread.SetApartmentState(ApartmentState.STA);
                Window_Thread.IsBackground = true;
                Window_Thread.Start();
                insert_Log("Channel 3 Histogram Window has been opened.", 0);
            }
            else
            {
                insert_Log("Channel 3 Histogram Window is already open.", 2);
            }
        }

        private void CH3_Histogram_Close(object sender, EventArgs e)
        {
            Channel_3_Histogram.Closed -= CH3_Histogram_Close;
            Channel_3_Histogram.Dispatcher.BeginInvokeShutdown(DispatcherPriority.Normal);
            Channel_3_Histogram = null;
            Channel_3_Histogram_isOpen = false;
            this.Dispatcher.BeginInvoke(DispatcherPriority.Normal, (Action)(() =>
            {
                Histogram_CH3_Graph_Selected = Graph_Not_Selected;
            }));
            insert_Log("Channel 3 Histogram Window has been closed.", 0);
        }

        private void CH4_Histogram_Open_Click(object sender, RoutedEventArgs e)
        {
            if (Channel_4_Histogram == null & Channel_4_Histogram_isOpen == false)
            {
                string Channel_Color = Channel_4_Color.ToString();
                Channel_4_Histogram_isOpen = true;
                Histogram_CH4_Graph_Selected = Graph_Selected;
                Thread Window_Thread = new Thread(new ThreadStart(() =>
                {
                    Channel_4_Histogram = new Histogram_Plotter(Communication_Selected.Company_Name + " " + Communication_Selected.Oscilloscope_Model + " " + "Channel 4 Histogram", "CH4", Channel_Color);
                    Channel_4_Histogram.Show();
                    Channel_4_Histogram.Closed += CH4_Histogram_Close;
                    Dispatcher.Run();
                }));
                Window_Thread.CurrentCulture = CultureInfo.CreateSpecificCulture("en-US");
                Window_Thread.CurrentUICulture = CultureInfo.CreateSpecificCulture("en-US");
                Window_Thread.SetApartmentState(ApartmentState.STA);
                Window_Thread.IsBackground = true;
                Window_Thread.Start();
                insert_Log("Channel 4 Histogram Window has been opened.", 0);
            }
            else
            {
                insert_Log("Channel 4 Histogram Window is already open.", 2);
            }
        }

        private void CH4_Histogram_Close(object sender, EventArgs e)
        {
            Channel_4_Histogram.Closed -= CH4_Histogram_Close;
            Channel_4_Histogram.Dispatcher.BeginInvokeShutdown(DispatcherPriority.Normal);
            Channel_4_Histogram = null;
            Channel_4_Histogram_isOpen = false;
            this.Dispatcher.BeginInvoke(DispatcherPriority.Normal, (Action)(() =>
            {
                Histogram_CH4_Graph_Selected = Graph_Not_Selected;
            }));
            insert_Log("Channel 4 Histogram Window has been closed.", 0);
        }
    }
}
