using Color_Graded_FFT;
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
        private Color_Graded_FFT_Plotter Color_Graded_FFT_Channel_1;
        private Color_Graded_FFT_Plotter Color_Graded_FFT_Channel_2;
        private Color_Graded_FFT_Plotter Color_Graded_FFT_Channel_3;
        private Color_Graded_FFT_Plotter Color_Graded_FFT_Channel_4;

        private bool Color_Graded_FFT_Channel_1_isOpen = false;
        private bool Color_Graded_FFT_Channel_2_isOpen = false;
        private bool Color_Graded_FFT_Channel_3_isOpen = false;
        private bool Color_Graded_FFT_Channel_4_isOpen = false;

        private void Initialize_Color_Graded_FFT_EventHandler()
        {
            AddHandler(FFT_Graph_Control.FFT_Graph_Control.CH1_ColorGradedFFT_Open_Event, new RoutedEventHandler(CH1_Color_Graded_FFT_Open_Click));
            AddHandler(FFT_Graph_Control.FFT_Graph_Control.CH2_ColorGradedFFT_Open_Event, new RoutedEventHandler(CH2_FFT_Open_Click));
            AddHandler(FFT_Graph_Control.FFT_Graph_Control.CH3_ColorGradedFFT_Open_Event, new RoutedEventHandler(CH3_FFT_Open_Click));
            AddHandler(FFT_Graph_Control.FFT_Graph_Control.CH4_ColorGradedFFT_Open_Event, new RoutedEventHandler(CH4_FFT_Open_Click));
        }

        private void CH1_Color_Graded_FFT_Open_Click(object sender, RoutedEventArgs e)
        {
            if (Color_Graded_FFT_Channel_1 == null & Color_Graded_FFT_Channel_1_isOpen == false)
            {
                Color_Graded_FFT_Channel_1_isOpen = true;
                string Channel_Color = Channel_1_Color.ToString();
                ColorGradedFFT_CH1_Graph_Selected = Graph_Selected;
                Thread Window_Thread = new Thread(new ThreadStart(() =>
                {
                    Color_Graded_FFT_Channel_1 = new Color_Graded_FFT_Plotter(Communication_Selected.Company_Name + " " + Communication_Selected.Oscilloscope_Model + " " + "Channel 1 Color Graded FFT", "CH1", Channel_Color);
                    Color_Graded_FFT_Channel_1.Show();
                    Color_Graded_FFT_Channel_1.Closed += CH1_Color_Graded_FFT_Close;
                    try
                    {
                        Dispatcher.Run();
                    }
                    catch (Exception Ex)
                    {
                        Color_Graded_FFT_Channel_1_isOpen = false;
                        Color_Graded_FFT_Channel_1.Closed -= CH1_Color_Graded_FFT_Close;
                        Color_Graded_FFT_Channel_1 = null;
                        this.Dispatcher.BeginInvoke(DispatcherPriority.Normal, (Action)(() =>
                        {
                            ColorGradedFFT_CH1_Graph_Selected = Graph_Not_Selected;
                        }));
                        insert_Log(Ex.ToString(), 1);
                    }
                }));
                Window_Thread.CurrentCulture = CultureInfo.CreateSpecificCulture("en-US");
                Window_Thread.CurrentUICulture = CultureInfo.CreateSpecificCulture("en-US");
                Window_Thread.SetApartmentState(ApartmentState.STA);
                Window_Thread.IsBackground = true;
                Window_Thread.Start();
                insert_Log("Channel 1 Color Graded FFT graph has been opened.", 0);
            }
            else
            {
                insert_Log("Channel 1 Color Graded FFT graph is already open.", 2);
            }
        }

        private void CH1_Color_Graded_FFT_Close(object sender, EventArgs e)
        {
            Color_Graded_FFT_Channel_1.Closed -= CH1_Color_Graded_FFT_Close;
            Color_Graded_FFT_Channel_1.Dispatcher.BeginInvokeShutdown(DispatcherPriority.Normal);
            Color_Graded_FFT_Channel_1 = null;
            Color_Graded_FFT_Channel_1_isOpen = false;
            this.Dispatcher.BeginInvoke(DispatcherPriority.Normal, (Action)(() =>
            {
                ColorGradedFFT_CH1_Graph_Selected = Graph_Not_Selected;
            }));
            insert_Log("Channel 1 Color Graded FFT graph has been closed.", 0);
        }
    }
}
