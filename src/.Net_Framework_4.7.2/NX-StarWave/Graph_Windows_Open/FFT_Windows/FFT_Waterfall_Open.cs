using FFT_Waterfall;
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
        private FFT_Waterfall_Plotter FFT_Waterfall_Channel_1;
        private FFT_Waterfall_Plotter FFT_Waterfall_Channel_2;
        private FFT_Waterfall_Plotter FFT_Waterfall_Channel_3;
        private FFT_Waterfall_Plotter FFT_Waterfall_Channel_4;

        //These are required as FFT Waterfall windows take a while to open
        // during this time if user presses the button repeatedly multiple windows can open 
        private bool FFT_Waterfall_CH1_Window_Open = false;
        private bool FFT_Waterfall_CH2_Window_Open = false;
        private bool FFT_Waterfall_CH3_Window_Open = false;
        private bool FFT_Waterfall_CH4_Window_Open = false;

        private void Initialize_FFT_Waterfall_EventHandler()
        {
            AddHandler(FFT_Graph_Control.FFT_Graph_Control.CH1_FFTWaterfall_Open_Event, new RoutedEventHandler(CH1_FFTWaterfall_Open_Click));
            AddHandler(FFT_Graph_Control.FFT_Graph_Control.CH2_FFTWaterfall_Open_Event, new RoutedEventHandler(CH2_FFTWaterfall_Open_Click));
            AddHandler(FFT_Graph_Control.FFT_Graph_Control.CH3_FFTWaterfall_Open_Event, new RoutedEventHandler(CH3_FFTWaterfall_Open_Click));
            AddHandler(FFT_Graph_Control.FFT_Graph_Control.CH4_FFTWaterfall_Open_Event, new RoutedEventHandler(CH4_FFTWaterfall_Open_Click));
        }

        private void CH1_FFTWaterfall_Open_Click(object sender, RoutedEventArgs e)
        {
            if (FFT_Waterfall_Channel_1 == null & FFT_Waterfall_CH1_Window_Open == false)
            {
                FFT_Waterfall_CH1_Window_Open = true;
                string Channel_Color = Channel_1_Color.ToString();
                FFTWaterfall_CH1_Graph_Selected = Graph_Selected;
                Thread Window_Thread = new Thread(new ThreadStart(() =>
                {
                    FFT_Waterfall_Channel_1 = new FFT_Waterfall_Plotter(Communication_Selected.Company_Name + " " + Communication_Selected.Oscilloscope_Model + " " + "Channel 1 FFT + Waterfall", "CH1", Channel_Color);
                    FFT_Waterfall_Channel_1.Show();
                    FFT_Waterfall_Channel_1.Closed += CH1_FFTWaterfall_Close;
                    try
                    {
                        Dispatcher.Run();
                    }
                    catch (Exception Ex)
                    {
                        FFT_Waterfall_CH1_Window_Open = false;
                        FFT_Waterfall_Channel_1.Closed -= CH1_FFTWaterfall_Close;
                        FFT_Waterfall_Channel_1 = null;
                        this.Dispatcher.BeginInvoke(DispatcherPriority.Normal, (Action)(() =>
                        {
                            FFTWaterfall_CH1_Graph_Selected = Graph_Not_Selected;
                        }));
                        insert_Log(Ex.ToString(), 1);
                    }
                }));
                Window_Thread.CurrentCulture = CultureInfo.CreateSpecificCulture("en-US");
                Window_Thread.CurrentUICulture = CultureInfo.CreateSpecificCulture("en-US");
                Window_Thread.SetApartmentState(ApartmentState.STA);
                Window_Thread.IsBackground = true;
                Window_Thread.Start();
                insert_Log("Channel 1 FFT Waterfall graph has been opened.", 0);
            }
            else
            {
                insert_Log("Channel 1 FFT Waterfall graph is already open.", 2);
            }
        }

        private void CH1_FFTWaterfall_Close(object sender, EventArgs e)
        {
            FFT_Waterfall_Channel_1.Closed -= CH1_FFTWaterfall_Close;
            FFT_Waterfall_Channel_1.Dispatcher.BeginInvokeShutdown(DispatcherPriority.Normal);
            FFT_Waterfall_Channel_1 = null;
            FFT_Waterfall_CH1_Window_Open = false;
            this.Dispatcher.BeginInvoke(DispatcherPriority.Normal, (Action)(() =>
            {
                FFTWaterfall_CH1_Graph_Selected = Graph_Not_Selected;
            }));
            insert_Log("Channel 1 FFT Waterfall graph has been closed.", 0);
        }

        private void CH2_FFTWaterfall_Open_Click(object sender, RoutedEventArgs e)
        {
            if (FFT_Waterfall_Channel_2 == null & FFT_Waterfall_CH2_Window_Open == false)
            {
                FFT_Waterfall_CH2_Window_Open = true;
                string Channel_Color = Channel_2_Color.ToString();
                FFTWaterfall_CH2_Graph_Selected = Graph_Selected;
                Thread Window_Thread = new Thread(new ThreadStart(() =>
                {
                    FFT_Waterfall_Channel_2 = new FFT_Waterfall_Plotter(Communication_Selected.Company_Name + " " + Communication_Selected.Oscilloscope_Model + " " + "Channel 2 FFT + Waterfall", "CH2", Channel_Color);
                    FFT_Waterfall_Channel_2.Show();
                    FFT_Waterfall_Channel_2.Closed += CH2_FFTWaterfall_Close;
                    try
                    {
                        Dispatcher.Run();
                    }
                    catch (Exception Ex)
                    {
                        FFT_Waterfall_CH2_Window_Open = false;
                        FFT_Waterfall_Channel_2.Closed -= CH2_FFTWaterfall_Close;
                        FFT_Waterfall_Channel_2 = null;
                        this.Dispatcher.BeginInvoke(DispatcherPriority.Normal, (Action)(() =>
                        {
                            FFTWaterfall_CH2_Graph_Selected = Graph_Not_Selected;
                        }));
                        insert_Log(Ex.ToString(), 1);
                    }
                }));
                Window_Thread.CurrentCulture = CultureInfo.CreateSpecificCulture("en-US");
                Window_Thread.CurrentUICulture = CultureInfo.CreateSpecificCulture("en-US");
                Window_Thread.SetApartmentState(ApartmentState.STA);
                Window_Thread.IsBackground = true;
                Window_Thread.Start();
                insert_Log("Channel 2 FFT Waterfall graph has been opened.", 0);
            }
            else
            {
                insert_Log("Channel 2 FFT Waterfall graph is already open.", 2);
            }
        }

        private void CH2_FFTWaterfall_Close(object sender, EventArgs e)
        {
            FFT_Waterfall_Channel_2.Closed -= CH2_FFTWaterfall_Close;
            FFT_Waterfall_Channel_2.Dispatcher.BeginInvokeShutdown(DispatcherPriority.Normal);
            FFT_Waterfall_Channel_2 = null;
            FFT_Waterfall_CH2_Window_Open = false;
            this.Dispatcher.BeginInvoke(DispatcherPriority.Normal, (Action)(() =>
            {
                FFTWaterfall_CH2_Graph_Selected = Graph_Not_Selected;
            }));
            insert_Log("Channel 2 FFT Waterfall graph has been closed.", 0);
        }

        private void CH3_FFTWaterfall_Open_Click(object sender, RoutedEventArgs e)
        {
            if (FFT_Waterfall_Channel_3 == null & FFT_Waterfall_CH3_Window_Open == false)
            {
                FFT_Waterfall_CH3_Window_Open = true;
                string Channel_Color = Channel_3_Color.ToString();
                FFTWaterfall_CH3_Graph_Selected = Graph_Selected;
                Thread Window_Thread = new Thread(new ThreadStart(() =>
                {
                    FFT_Waterfall_Channel_3 = new FFT_Waterfall_Plotter(Communication_Selected.Company_Name + " " + Communication_Selected.Oscilloscope_Model + " " + "Channel 3 FFT + Waterfall", "CH3", Channel_Color);
                    FFT_Waterfall_Channel_3.Show();
                    FFT_Waterfall_Channel_3.Closed += CH3_FFTWaterfall_Close;
                    try
                    {
                        Dispatcher.Run();
                    }
                    catch (Exception Ex)
                    {
                        FFT_Waterfall_CH3_Window_Open = false;
                        FFT_Waterfall_Channel_3.Closed -= CH3_FFTWaterfall_Close;
                        FFT_Waterfall_Channel_3 = null;
                        this.Dispatcher.BeginInvoke(DispatcherPriority.Normal, (Action)(() =>
                        {
                            FFTWaterfall_CH3_Graph_Selected = Graph_Not_Selected;
                        }));
                        insert_Log(Ex.ToString(), 1);
                    }
                }));
                Window_Thread.CurrentCulture = CultureInfo.CreateSpecificCulture("en-US");
                Window_Thread.CurrentUICulture = CultureInfo.CreateSpecificCulture("en-US");
                Window_Thread.SetApartmentState(ApartmentState.STA);
                Window_Thread.IsBackground = true;
                Window_Thread.Start();
                insert_Log("Channel 3 FFT Waterfall graph has been opened.", 0);
            }
            else
            {
                insert_Log("Channel 3 FFT Waterfall graph is already open.", 2);
            }
        }

        private void CH3_FFTWaterfall_Close(object sender, EventArgs e)
        {
            FFT_Waterfall_Channel_3.Closed -= CH3_FFTWaterfall_Close;
            FFT_Waterfall_Channel_3.Dispatcher.BeginInvokeShutdown(DispatcherPriority.Normal);
            FFT_Waterfall_Channel_3 = null;
            FFT_Waterfall_CH3_Window_Open = false;
            this.Dispatcher.BeginInvoke(DispatcherPriority.Normal, (Action)(() =>
            {
                FFTWaterfall_CH3_Graph_Selected = Graph_Not_Selected;
            }));
            insert_Log("Channel 3 FFT Waterfall graph has been closed.", 0);
        }

        private void CH4_FFTWaterfall_Open_Click(object sender, RoutedEventArgs e)
        {
            if (FFT_Waterfall_Channel_4 == null & FFT_Waterfall_CH4_Window_Open == false)
            {
                FFT_Waterfall_CH4_Window_Open = true;
                string Channel_Color = Channel_4_Color.ToString();
                FFTWaterfall_CH4_Graph_Selected = Graph_Selected;
                Thread Window_Thread = new Thread(new ThreadStart(() =>
                {
                    FFT_Waterfall_Channel_4 = new FFT_Waterfall_Plotter(Communication_Selected.Company_Name + " " + Communication_Selected.Oscilloscope_Model + " " + "Channel 4 FFT + Waterfall", "CH4", Channel_Color);
                    FFT_Waterfall_Channel_4.Show();
                    FFT_Waterfall_Channel_4.Closed += CH4_FFTWaterfall_Close;
                    try
                    {
                        Dispatcher.Run();
                    }
                    catch (Exception Ex)
                    {
                        FFT_Waterfall_CH4_Window_Open = false;
                        FFT_Waterfall_Channel_4.Closed -= CH4_FFTWaterfall_Close;
                        FFT_Waterfall_Channel_4 = null;
                        this.Dispatcher.BeginInvoke(DispatcherPriority.Normal, (Action)(() =>
                        {
                            FFTWaterfall_CH4_Graph_Selected = Graph_Not_Selected;
                        }));
                        insert_Log(Ex.ToString(), 1);
                    }
                }));
                Window_Thread.CurrentCulture = CultureInfo.CreateSpecificCulture("en-US");
                Window_Thread.CurrentUICulture = CultureInfo.CreateSpecificCulture("en-US");
                Window_Thread.SetApartmentState(ApartmentState.STA);
                Window_Thread.IsBackground = true;
                Window_Thread.Start();
                insert_Log("Channel 4 FFT Waterfall graph has been opened.", 0);
            }
            else
            {
                insert_Log("Channel 4 FFT Waterfall graph is already open.", 2);
            }
        }

        private void CH4_FFTWaterfall_Close(object sender, EventArgs e)
        {
            FFT_Waterfall_Channel_4.Closed -= CH4_FFTWaterfall_Close;
            FFT_Waterfall_Channel_4.Dispatcher.BeginInvokeShutdown(DispatcherPriority.Normal);
            FFT_Waterfall_Channel_4 = null;
            FFT_Waterfall_CH4_Window_Open = false;
            this.Dispatcher.BeginInvoke(DispatcherPriority.Normal, (Action)(() =>
            {
                FFTWaterfall_CH4_Graph_Selected = Graph_Not_Selected;
            }));
            insert_Log("Channel 4 FFT Waterfall graph has been closed.", 0);
        }
    }
}
