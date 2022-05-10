using MahApps.Metro.Controls;
using Math_YT;
using System;
using System.Globalization;
using System.Threading;
using System.Windows;
using System.Windows.Threading;

namespace NX_StarWave
{
    public partial class NX_StarWave_Window : MetroWindow
    {
        private Math_YT_Plotter Math_YT_Window_1;
        private Math_YT_Plotter Math_YT_Window_2;
        private Math_YT_Plotter Math_YT_Window_3;
        private Math_YT_Plotter Math_YT_Window_4;

        private bool Math_YT_Window_1_isOpen = false;
        private bool Math_YT_Window_2_isOpen = false;
        private bool Math_YT_Window_3_isOpen = false;
        private bool Math_YT_Window_4_isOpen = false;

        private void Initialize_Math_YT_EventHandler()
        {
            AddHandler(Math_Graph_Control.Math_Graph_Control.W1_Math_YT_Open_Event, new RoutedEventHandler(W1_Math_YT_Open_Click));
            AddHandler(Math_Graph_Control.Math_Graph_Control.W2_Math_YT_Open_Event, new RoutedEventHandler(W2_Math_YT_Open_Click));
            AddHandler(Math_Graph_Control.Math_Graph_Control.W3_Math_YT_Open_Event, new RoutedEventHandler(W3_Math_YT_Open_Click));
            AddHandler(Math_Graph_Control.Math_Graph_Control.W4_Math_YT_Open_Event, new RoutedEventHandler(W4_Math_YT_Open_Click));
        }

        private void W1_Math_YT_Open_Click(object sender, RoutedEventArgs e)
        {
            if (Math_YT_Window_1 == null & Math_YT_Window_1_isOpen == false)
            {
                Math_YT_Window_1_isOpen = true;
                string Waveform_Color = Math_YT_Window_1_Color.ToString();
                Math_YT_W1_Graph_Selected = Graph_Selected;
                Thread Window_Thread = new Thread(new ThreadStart(() =>
                {
                    Math_YT_Window_1 = new Math_YT_Plotter(Communication_Selected.Company_Name + " " + Communication_Selected.Oscilloscope_Model + " " + "Single Channel Math Window 1", Waveform_Color);
                    Math_YT_Window_1.Show();
                    Math_YT_Window_1.Closed += W1_Math_YT_Close;
                    Dispatcher.Run();
                }));
                Window_Thread.CurrentCulture = CultureInfo.CreateSpecificCulture("en-US");
                Window_Thread.CurrentUICulture = CultureInfo.CreateSpecificCulture("en-US");
                Window_Thread.SetApartmentState(ApartmentState.STA);
                Window_Thread.IsBackground = true;
                Window_Thread.Start();
                insert_Log("YT Math Window 1 has been opened.", 0);
            }
            else
            {
                insert_Log("YT Math Window 1 is already open.", 2);
            }
        }

        private void W1_Math_YT_Close(object sender, EventArgs e)
        {
            Math_YT_Window_1.Closed -= W1_Math_YT_Close;
            Math_YT_Window_1.Dispatcher.BeginInvokeShutdown(DispatcherPriority.Normal);
            Math_YT_Window_1 = null;
            Math_YT_Window_1_isOpen = false;
            this.Dispatcher.BeginInvoke(DispatcherPriority.Normal, (Action)(() =>
            {
                Math_YT_W1_Graph_Selected = Graph_Not_Selected;
            }));
            insert_Log("YT Math Window 1 has been closed.", 0);
        }

        private void W2_Math_YT_Open_Click(object sender, RoutedEventArgs e)
        {
            if (Math_YT_Window_2 == null & Math_YT_Window_2_isOpen == false)
            {
                Math_YT_Window_2_isOpen = true;
                string Waveform_Color = Math_YT_Window_2_Color.ToString();
                Math_YT_W2_Graph_Selected = Graph_Selected;
                Thread Window_Thread = new Thread(new ThreadStart(() =>
                {
                    Math_YT_Window_2 = new Math_YT_Plotter(Communication_Selected.Company_Name + " " + Communication_Selected.Oscilloscope_Model + " " + "Single Channel Math Window 2", Waveform_Color);
                    Math_YT_Window_2.Show();
                    Math_YT_Window_2.Closed += W2_Math_YT_Close;
                    Dispatcher.Run();
                }));
                Window_Thread.CurrentCulture = CultureInfo.CreateSpecificCulture("en-US");
                Window_Thread.CurrentUICulture = CultureInfo.CreateSpecificCulture("en-US");
                Window_Thread.SetApartmentState(ApartmentState.STA);
                Window_Thread.IsBackground = true;
                Window_Thread.Start();
                insert_Log("YT Math Window 2 has been opened.", 0);
            }
            else
            {
                insert_Log("YT Math Window 2 is already open.", 2);
            }
        }

        private void W2_Math_YT_Close(object sender, EventArgs e)
        {
            Math_YT_Window_2.Closed -= W2_Math_YT_Close;
            Math_YT_Window_2.Dispatcher.BeginInvokeShutdown(DispatcherPriority.Normal);
            Math_YT_Window_2 = null;
            Math_YT_Window_2_isOpen = false;
            this.Dispatcher.BeginInvoke(DispatcherPriority.Normal, (Action)(() =>
            {
                Math_YT_W2_Graph_Selected = Graph_Not_Selected;
            }));
            insert_Log("YT Math Window 2 has been closed.", 0);
        }

        private void W3_Math_YT_Open_Click(object sender, RoutedEventArgs e)
        {
            if (Math_YT_Window_3 == null & Math_YT_Window_3_isOpen == false)
            {
                Math_YT_Window_3_isOpen = true;
                string Waveform_Color = Math_YT_Window_3_Color.ToString();
                Math_YT_W3_Graph_Selected = Graph_Selected;
                Thread Window_Thread = new Thread(new ThreadStart(() =>
                {
                    Math_YT_Window_3 = new Math_YT_Plotter(Communication_Selected.Company_Name + " " + Communication_Selected.Oscilloscope_Model + " " + "Single Channel Math Window 3", Waveform_Color);
                    Math_YT_Window_3.Show();
                    Math_YT_Window_3.Closed += W3_Math_YT_Close;
                    Dispatcher.Run();
                }));
                Window_Thread.CurrentCulture = CultureInfo.CreateSpecificCulture("en-US");
                Window_Thread.CurrentUICulture = CultureInfo.CreateSpecificCulture("en-US");
                Window_Thread.SetApartmentState(ApartmentState.STA);
                Window_Thread.IsBackground = true;
                Window_Thread.Start();
                insert_Log("YT Math Window 3 has been opened.", 0);
            }
            else
            {
                insert_Log("YT Math Window 3 is already open.", 2);
            }
        }

        private void W3_Math_YT_Close(object sender, EventArgs e)
        {
            Math_YT_Window_3.Closed -= W3_Math_YT_Close;
            Math_YT_Window_3.Dispatcher.BeginInvokeShutdown(DispatcherPriority.Normal);
            Math_YT_Window_3 = null;
            Math_YT_Window_3_isOpen = false;
            this.Dispatcher.BeginInvoke(DispatcherPriority.Normal, (Action)(() =>
            {
                Math_YT_W3_Graph_Selected = Graph_Not_Selected;
            }));
            insert_Log("YT Math Window 3 has been closed.", 0);
        }

        private void W4_Math_YT_Open_Click(object sender, RoutedEventArgs e)
        {
            if (Math_YT_Window_4 == null & Math_YT_Window_4_isOpen == false)
            {
                Math_YT_Window_4_isOpen = true;
                string Waveform_Color = Math_YT_Window_4_Color.ToString();
                Math_YT_W4_Graph_Selected = Graph_Selected;
                Thread Window_Thread = new Thread(new ThreadStart(() =>
                {
                    Math_YT_Window_4 = new Math_YT_Plotter(Communication_Selected.Company_Name + " " + Communication_Selected.Oscilloscope_Model + " " + "Single Channel Math Window 4", Waveform_Color);
                    Math_YT_Window_4.Show();
                    Math_YT_Window_4.Closed += W4_Math_YT_Close;
                    Dispatcher.Run();
                }));
                Window_Thread.CurrentCulture = CultureInfo.CreateSpecificCulture("en-US");
                Window_Thread.CurrentUICulture = CultureInfo.CreateSpecificCulture("en-US");
                Window_Thread.SetApartmentState(ApartmentState.STA);
                Window_Thread.IsBackground = true;
                Window_Thread.Start();
                insert_Log("YT Math Window 4 has been opened.", 0);
            }
            else
            {
                insert_Log("YT Math Window 4 is already open.", 2);
            }
        }

        private void W4_Math_YT_Close(object sender, EventArgs e)
        {
            Math_YT_Window_4.Closed -= W4_Math_YT_Close;
            Math_YT_Window_4.Dispatcher.BeginInvokeShutdown(DispatcherPriority.Normal);
            Math_YT_Window_4 = null;
            Math_YT_Window_4_isOpen = false;
            this.Dispatcher.BeginInvoke(DispatcherPriority.Normal, (Action)(() =>
            {
                Math_YT_W4_Graph_Selected = Graph_Not_Selected;
            }));
            insert_Log("YT Math Window 4 has been closed.", 0);
        }
    }
}
