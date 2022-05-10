using FFT_Waveform;
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
        private FFT_Waveform_Plotter FFT_Waveform_Channel_1;
        private FFT_Waveform_Plotter FFT_Waveform_Channel_2;
        private FFT_Waveform_Plotter FFT_Waveform_Channel_3;
        private FFT_Waveform_Plotter FFT_Waveform_Channel_4;

        private bool FFT_Waveform_Channel_1_isOpen = false;
        private bool FFT_Waveform_Channel_2_isOpen = false;
        private bool FFT_Waveform_Channel_3_isOpen = false;
        private bool FFT_Waveform_Channel_4_isOpen = false;

        private void Initialize_FFT_Waveform_EventHandler()
        {
            AddHandler(FFT_Graph_Control.FFT_Graph_Control.CH1_FFTWaveform_Open_Event, new RoutedEventHandler(CH1_FFTWaveform_Open_Click));
            AddHandler(FFT_Graph_Control.FFT_Graph_Control.CH2_FFTWaveform_Open_Event, new RoutedEventHandler(CH2_FFTWaveform_Open_Click));
            AddHandler(FFT_Graph_Control.FFT_Graph_Control.CH3_FFTWaveform_Open_Event, new RoutedEventHandler(CH3_FFTWaveform_Open_Click));
            AddHandler(FFT_Graph_Control.FFT_Graph_Control.CH4_FFTWaveform_Open_Event, new RoutedEventHandler(CH4_FFTWaveform_Open_Click));
        }

        private void CH1_FFTWaveform_Open_Click(object sender, RoutedEventArgs e)
        {
            if (FFT_Waveform_Channel_1 == null & FFT_Waveform_Channel_1_isOpen == false)
            {
                FFT_Waveform_Channel_1_isOpen = true;
                string Channel_Color = Channel_1_Color.ToString();
                FFTWaveform_CH1_Graph_Selected = Graph_Selected;
                Thread Window_Thread = new Thread(new ThreadStart(() =>
                {
                    FFT_Waveform_Channel_1 = new FFT_Waveform_Plotter(Communication_Selected.Company_Name + " " + Communication_Selected.Oscilloscope_Model + " " + "Channel 1 FFT & Waveform", "CH1", Channel_Color);
                    FFT_Waveform_Channel_1.Show();
                    FFT_Waveform_Channel_1.Closed += CH1_FFTWaveform_Close;
                    try
                    {
                        Dispatcher.Run();
                    }
                    catch (Exception Ex)
                    {
                        FFT_Waveform_Channel_1_isOpen = false;
                        FFT_Waveform_Channel_1.Closed -= CH1_FFTWaveform_Close;
                        FFT_Waveform_Channel_1 = null;
                        this.Dispatcher.BeginInvoke(DispatcherPriority.Normal, (Action)(() =>
                        {
                            FFTWaveform_CH1_Graph_Selected = Graph_Not_Selected;
                        }));
                        insert_Log(Ex.ToString(), 1);
                    }
                }));
                Window_Thread.CurrentCulture = CultureInfo.CreateSpecificCulture("en-US");
                Window_Thread.CurrentUICulture = CultureInfo.CreateSpecificCulture("en-US");
                Window_Thread.SetApartmentState(ApartmentState.STA);
                Window_Thread.IsBackground = true;
                Window_Thread.Start();
                insert_Log("Channel 1 FFT Waveform graph has been opened.", 0);
            }
            else
            {
                insert_Log("Channel 1 FFT Waveform graph is already open.", 2);
            }
        }

        private void CH1_FFTWaveform_Close(object sender, EventArgs e)
        {
            FFT_Waveform_Channel_1.Closed -= CH1_FFTWaveform_Close;
            FFT_Waveform_Channel_1.Dispatcher.BeginInvokeShutdown(DispatcherPriority.Normal);
            FFT_Waveform_Channel_1 = null;
            FFT_Waveform_Channel_1_isOpen = false;
            this.Dispatcher.BeginInvoke(DispatcherPriority.Normal, (Action)(() =>
            {
                FFTWaveform_CH1_Graph_Selected = Graph_Not_Selected;
            }));
            insert_Log("Channel 1 FFT Waveform graph has been closed.", 0);
        }

        private void CH2_FFTWaveform_Open_Click(object sender, RoutedEventArgs e)
        {
            if (FFT_Waveform_Channel_2 == null & FFT_Waveform_Channel_2_isOpen == false)
            {
                FFT_Waveform_Channel_2_isOpen = true;
                string Channel_Color = Channel_2_Color.ToString();
                FFTWaveform_CH2_Graph_Selected = Graph_Selected;
                Thread Window_Thread = new Thread(new ThreadStart(() =>
                {
                    FFT_Waveform_Channel_2 = new FFT_Waveform_Plotter(Communication_Selected.Company_Name + " " + Communication_Selected.Oscilloscope_Model + " " + "Channel 2 FFT & Waveform", "CH2", Channel_Color);
                    FFT_Waveform_Channel_2.Show();
                    FFT_Waveform_Channel_2.Closed += CH2_FFTWaveform_Close;
                    try
                    {
                        Dispatcher.Run();
                    }
                    catch (Exception Ex)
                    {
                        FFT_Waveform_Channel_2_isOpen = false;
                        FFT_Waveform_Channel_2.Closed -= CH2_FFTWaveform_Close;
                        FFT_Waveform_Channel_2 = null;
                        this.Dispatcher.BeginInvoke(DispatcherPriority.Normal, (Action)(() =>
                        {
                            FFTWaveform_CH2_Graph_Selected = Graph_Not_Selected;
                        }));
                        insert_Log(Ex.ToString(), 1);
                    }
                }));
                Window_Thread.CurrentCulture = CultureInfo.CreateSpecificCulture("en-US");
                Window_Thread.CurrentUICulture = CultureInfo.CreateSpecificCulture("en-US");
                Window_Thread.SetApartmentState(ApartmentState.STA);
                Window_Thread.IsBackground = true;
                Window_Thread.Start();
                insert_Log("Channel 2 FFT Waveform graph has been opened.", 0);
            }
            else
            {
                insert_Log("Channel 2 FFT Waveform graph is already open.", 2);
            }
        }

        private void CH2_FFTWaveform_Close(object sender, EventArgs e)
        {
            FFT_Waveform_Channel_2.Closed -= CH2_FFTWaveform_Close;
            FFT_Waveform_Channel_2.Dispatcher.BeginInvokeShutdown(DispatcherPriority.Normal);
            FFT_Waveform_Channel_2 = null;
            FFT_Waveform_Channel_2_isOpen = false;
            this.Dispatcher.BeginInvoke(DispatcherPriority.Normal, (Action)(() =>
            {
                FFTWaveform_CH2_Graph_Selected = Graph_Not_Selected;
            }));
            insert_Log("Channel 2 FFT Waveform graph has been closed.", 0);
        }

        private void CH3_FFTWaveform_Open_Click(object sender, RoutedEventArgs e)
        {
            if (FFT_Waveform_Channel_3 == null & FFT_Waveform_Channel_3_isOpen == false)
            {
                FFT_Waveform_Channel_3_isOpen = true;
                string Channel_Color = Channel_3_Color.ToString();
                FFTWaveform_CH3_Graph_Selected = Graph_Selected;
                Thread Window_Thread = new Thread(new ThreadStart(() =>
                {
                    FFT_Waveform_Channel_3 = new FFT_Waveform_Plotter(Communication_Selected.Company_Name + " " + Communication_Selected.Oscilloscope_Model + " " + "Channel 3 FFT & Waveform", "CH3", Channel_Color);
                    FFT_Waveform_Channel_3.Show();
                    FFT_Waveform_Channel_3.Closed += CH3_FFTWaveform_Close;
                    try
                    {
                        Dispatcher.Run();
                    }
                    catch (Exception Ex)
                    {
                        FFT_Waveform_Channel_3_isOpen = false;
                        FFT_Waveform_Channel_3.Closed -= CH3_FFTWaveform_Close;
                        FFT_Waveform_Channel_3 = null;
                        this.Dispatcher.BeginInvoke(DispatcherPriority.Normal, (Action)(() =>
                        {
                            FFTWaveform_CH3_Graph_Selected = Graph_Not_Selected;
                        }));
                        insert_Log(Ex.ToString(), 1);
                    }
                }));
                Window_Thread.CurrentCulture = CultureInfo.CreateSpecificCulture("en-US");
                Window_Thread.CurrentUICulture = CultureInfo.CreateSpecificCulture("en-US");
                Window_Thread.SetApartmentState(ApartmentState.STA);
                Window_Thread.IsBackground = true;
                Window_Thread.Start();
                insert_Log("Channel 3 FFT Waveform graph has been opened.", 0);
            }
            else
            {
                insert_Log("Channel 3 FFT Waveform graph is already open.", 2);
            }
        }

        private void CH3_FFTWaveform_Close(object sender, EventArgs e)
        {
            FFT_Waveform_Channel_3.Closed -= CH3_FFTWaveform_Close;
            FFT_Waveform_Channel_3.Dispatcher.BeginInvokeShutdown(DispatcherPriority.Normal);
            FFT_Waveform_Channel_3 = null;
            FFT_Waveform_Channel_3_isOpen = false;
            this.Dispatcher.BeginInvoke(DispatcherPriority.Normal, (Action)(() =>
            {
                FFTWaveform_CH3_Graph_Selected = Graph_Not_Selected;
            }));
            insert_Log("Channel 3 FFT Waveform graph has been closed.", 0);
        }

        private void CH4_FFTWaveform_Open_Click(object sender, RoutedEventArgs e)
        {
            if (FFT_Waveform_Channel_4 == null & FFT_Waveform_Channel_4_isOpen == false)
            {
                FFT_Waveform_Channel_4_isOpen = true;
                string Channel_Color = Channel_4_Color.ToString();
                FFTWaveform_CH4_Graph_Selected = Graph_Selected;
                Thread Window_Thread = new Thread(new ThreadStart(() =>
                {
                    FFT_Waveform_Channel_4 = new FFT_Waveform_Plotter(Communication_Selected.Company_Name + " " + Communication_Selected.Oscilloscope_Model + " " + "Channel 4 FFT & Waveform", "CH4", Channel_Color);
                    FFT_Waveform_Channel_4.Show();
                    FFT_Waveform_Channel_4.Closed += CH4_FFTWaveform_Close;
                    try
                    {
                        Dispatcher.Run();
                    }
                    catch (Exception Ex)
                    {
                        FFT_Waveform_Channel_4_isOpen = false;
                        FFT_Waveform_Channel_4.Closed -= CH4_FFTWaveform_Close;
                        FFT_Waveform_Channel_4 = null;
                        this.Dispatcher.BeginInvoke(DispatcherPriority.Normal, (Action)(() =>
                        {
                            FFTWaveform_CH4_Graph_Selected = Graph_Not_Selected;
                        }));
                        insert_Log(Ex.ToString(), 1);
                    }
                }));
                Window_Thread.CurrentCulture = CultureInfo.CreateSpecificCulture("en-US");
                Window_Thread.CurrentUICulture = CultureInfo.CreateSpecificCulture("en-US");
                Window_Thread.SetApartmentState(ApartmentState.STA);
                Window_Thread.IsBackground = true;
                Window_Thread.Start();
                insert_Log("Channel 4 FFT Waveform graph has been opened.", 0);
            }
            else
            {
                insert_Log("Channel 4 FFT Waveform graph is already open.", 2);
            }
        }

        private void CH4_FFTWaveform_Close(object sender, EventArgs e)
        {
            FFT_Waveform_Channel_4.Closed -= CH4_FFTWaveform_Close;
            FFT_Waveform_Channel_4.Dispatcher.BeginInvokeShutdown(DispatcherPriority.Normal);
            FFT_Waveform_Channel_4 = null;
            FFT_Waveform_Channel_4_isOpen = false;
            this.Dispatcher.BeginInvoke(DispatcherPriority.Normal, (Action)(() =>
            {
                FFTWaveform_CH4_Graph_Selected = Graph_Not_Selected;
            }));
            insert_Log("Channel 4 FFT Waveform graph has been closed.", 0);
        }

    }
}
