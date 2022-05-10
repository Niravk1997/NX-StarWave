using MahApps.Metro.Controls;
using System;
using System.Globalization;
using System.Threading;
using System.Windows;
using System.Windows.Threading;
using XY;
using XY_Waveform;

namespace NX_StarWave
{
    public partial class NX_StarWave_Window : MetroWindow
    {
        private XY_Plotter XY_Window_1;
        private XY_Plotter XY_Window_2;
        private XY_Plotter XY_Window_3;
        private XY_Plotter XY_Window_4;

        private bool XY_Window_1_isOpen = false;
        private bool XY_Window_2_isOpen = false;
        private bool XY_Window_3_isOpen = false;
        private bool XY_Window_4_isOpen = false;

        private XY_Waveform_Plotter XY_Waveform_Window_1;
        private XY_Waveform_Plotter XY_Waveform_Window_2;
        private XY_Waveform_Plotter XY_Waveform_Window_3;
        private XY_Waveform_Plotter XY_Waveform_Window_4;

        private bool XY_Waveform_Window_1_isOpen = false;
        private bool XY_Waveform_Window_2_isOpen = false;
        private bool XY_Waveform_Window_3_isOpen = false;
        private bool XY_Waveform_Window_4_isOpen = false;

        private void Initialize_XY_EventHandler()
        {
            AddHandler(XY_Graph_Control.XY_Graph_Control.W1_XY_Open_Event, new RoutedEventHandler(W1_XY_Open_Click));
            AddHandler(XY_Graph_Control.XY_Graph_Control.W2_XY_Open_Event, new RoutedEventHandler(W2_XY_Open_Click));
            AddHandler(XY_Graph_Control.XY_Graph_Control.W3_XY_Open_Event, new RoutedEventHandler(W3_XY_Open_Click));
            AddHandler(XY_Graph_Control.XY_Graph_Control.W4_XY_Open_Event, new RoutedEventHandler(W4_XY_Open_Click));

            AddHandler(XY_Graph_Control.XY_Graph_Control.W1_XY_Waveform_Open_Event, new RoutedEventHandler(W1_XY_Waveform_Open_Click));
            AddHandler(XY_Graph_Control.XY_Graph_Control.W2_XY_Waveform_Open_Event, new RoutedEventHandler(W2_XY_Waveform_Open_Click));
            AddHandler(XY_Graph_Control.XY_Graph_Control.W3_XY_Waveform_Open_Event, new RoutedEventHandler(W3_XY_Waveform_Open_Click));
            AddHandler(XY_Graph_Control.XY_Graph_Control.W4_XY_Waveform_Open_Event, new RoutedEventHandler(W4_XY_Waveform_Open_Click));
        }

        private void W1_XY_Open_Click(object sender, RoutedEventArgs e)
        {
            if (XY_Window_1 == null & XY_Window_1_isOpen == false)
            {
                XY_Window_1_isOpen = true;
                XY_W1_Graph_Selected = Graph_Selected;
                Thread Window_Thread = new Thread(new ThreadStart(() =>
                {
                    XY_Window_1 = new XY_Plotter(Communication_Selected.Company_Name + " " + Communication_Selected.Oscilloscope_Model + " " + "XY Window 1");
                    XY_Window_1.Show();
                    XY_Window_1.Closed += W1_XY_Close;
                    Dispatcher.Run();
                }));
                Window_Thread.CurrentCulture = CultureInfo.CreateSpecificCulture("en-US");
                Window_Thread.CurrentUICulture = CultureInfo.CreateSpecificCulture("en-US");
                Window_Thread.SetApartmentState(ApartmentState.STA);
                Window_Thread.IsBackground = true;
                Window_Thread.Start();
                insert_Log("XY Graph Window 1 has been opened.", 0);
            }
            else
            {
                insert_Log("XY Graph Window 1 is already open.", 2);
            }
        }

        private void W1_XY_Close(object sender, EventArgs e)
        {
            XY_Window_1.Closed -= W1_XY_Close;
            XY_Window_1.Dispatcher.BeginInvokeShutdown(DispatcherPriority.Normal);
            XY_Window_1 = null;
            XY_Window_1_isOpen = false;
            this.Dispatcher.BeginInvoke(DispatcherPriority.Normal, (Action)(() =>
            {
                XY_W1_Graph_Selected = Graph_Not_Selected;
            }));
            insert_Log("XY Graph Window 1 has been closed.", 0);
        }

        private void W2_XY_Open_Click(object sender, RoutedEventArgs e)
        {
            if (XY_Window_2 == null & XY_Window_2_isOpen == false)
            {
                XY_Window_2_isOpen = true;
                XY_W2_Graph_Selected = Graph_Selected;
                Thread Window_Thread = new Thread(new ThreadStart(() =>
                {
                    XY_Window_2 = new XY_Plotter(Communication_Selected.Company_Name + " " + Communication_Selected.Oscilloscope_Model + " " + "XY Window 2");
                    XY_Window_2.Show();
                    XY_Window_2.Closed += W2_XY_Close;
                    Dispatcher.Run();
                }));
                Window_Thread.CurrentCulture = CultureInfo.CreateSpecificCulture("en-US");
                Window_Thread.CurrentUICulture = CultureInfo.CreateSpecificCulture("en-US");
                Window_Thread.SetApartmentState(ApartmentState.STA);
                Window_Thread.IsBackground = true;
                Window_Thread.Start();
                insert_Log("XY Graph Window 2 has been opened.", 0);
            }
            else
            {
                insert_Log("XY Graph Window 2 is already open.", 2);
            }
        }

        private void W2_XY_Close(object sender, EventArgs e)
        {
            XY_Window_2.Closed -= W2_XY_Close;
            XY_Window_2.Dispatcher.BeginInvokeShutdown(DispatcherPriority.Normal);
            XY_Window_2 = null;
            XY_Window_2_isOpen = false;
            this.Dispatcher.BeginInvoke(DispatcherPriority.Normal, (Action)(() =>
            {
                XY_W2_Graph_Selected = Graph_Not_Selected;
            }));
            insert_Log("XY Graph Window 2 has been closed.", 0);
        }

        private void W3_XY_Open_Click(object sender, RoutedEventArgs e)
        {
            if (XY_Window_3 == null & XY_Window_3_isOpen == false)
            {
                XY_Window_3_isOpen = true;
                XY_W3_Graph_Selected = Graph_Selected;
                Thread Window_Thread = new Thread(new ThreadStart(() =>
                {
                    XY_Window_3 = new XY_Plotter(Communication_Selected.Company_Name + " " + Communication_Selected.Oscilloscope_Model + " " + "XY Window 3");
                    XY_Window_3.Show();
                    XY_Window_3.Closed += W3_XY_Close;
                    Dispatcher.Run();
                }));
                Window_Thread.CurrentCulture = CultureInfo.CreateSpecificCulture("en-US");
                Window_Thread.CurrentUICulture = CultureInfo.CreateSpecificCulture("en-US");
                Window_Thread.SetApartmentState(ApartmentState.STA);
                Window_Thread.IsBackground = true;
                Window_Thread.Start();
                insert_Log("XY Graph Window 3 has been opened.", 0);
            }
            else
            {
                insert_Log("XY Graph Window 3 is already open.", 2);
            }
        }

        private void W3_XY_Close(object sender, EventArgs e)
        {
            XY_Window_3.Closed -= W3_XY_Close;
            XY_Window_3.Dispatcher.BeginInvokeShutdown(DispatcherPriority.Normal);
            XY_Window_3 = null;
            XY_Window_3_isOpen = false;
            this.Dispatcher.BeginInvoke(DispatcherPriority.Normal, (Action)(() =>
            {
                XY_W3_Graph_Selected = Graph_Not_Selected;
            }));
            insert_Log("XY Graph Window 3 has been closed.", 0);
        }

        private void W4_XY_Open_Click(object sender, RoutedEventArgs e)
        {
            if (XY_Window_4 == null & XY_Window_4_isOpen == false)
            {
                XY_Window_4_isOpen = true;
                XY_W4_Graph_Selected = Graph_Selected;
                Thread Window_Thread = new Thread(new ThreadStart(() =>
                {
                    XY_Window_4 = new XY_Plotter(Communication_Selected.Company_Name + " " + Communication_Selected.Oscilloscope_Model + " " + "XY Window 4");
                    XY_Window_4.Show();
                    XY_Window_4.Closed += W4_XY_Close;
                    Dispatcher.Run();
                }));
                Window_Thread.CurrentCulture = CultureInfo.CreateSpecificCulture("en-US");
                Window_Thread.CurrentUICulture = CultureInfo.CreateSpecificCulture("en-US");
                Window_Thread.SetApartmentState(ApartmentState.STA);
                Window_Thread.IsBackground = true;
                Window_Thread.Start();
                insert_Log("XY Graph Window 4 has been opened.", 0);
            }
            else
            {
                insert_Log("XY Graph Window 4 is already open.", 2);
            }
        }

        private void W4_XY_Close(object sender, EventArgs e)
        {
            XY_Window_4.Closed -= W4_XY_Close;
            XY_Window_4.Dispatcher.BeginInvokeShutdown(DispatcherPriority.Normal);
            XY_Window_4 = null;
            XY_Window_4_isOpen = false;
            this.Dispatcher.BeginInvoke(DispatcherPriority.Normal, (Action)(() =>
            {
                XY_W4_Graph_Selected = Graph_Not_Selected;
            }));
            insert_Log("XY Graph Window 4 has been closed.", 0);
        }

        private void W1_XY_Waveform_Open_Click(object sender, RoutedEventArgs e)
        {
            if (XY_Waveform_Window_1 == null & XY_Waveform_Window_1_isOpen == false)
            {
                XY_Waveform_Window_1_isOpen = true;
                XY_Waveform_W1_Graph_Selected = Graph_Selected;
                Thread Window_Thread = new Thread(new ThreadStart(() =>
                {
                    XY_Waveform_Window_1 = new XY_Waveform_Plotter(Communication_Selected.Company_Name + " " + Communication_Selected.Oscilloscope_Model + " " + "XY Waveform Window 1");
                    XY_Waveform_Window_1.Show();
                    XY_Waveform_Window_1.Closed += W1_XY_Waveform_Close;
                    Dispatcher.Run();
                }));
                Window_Thread.CurrentCulture = CultureInfo.CreateSpecificCulture("en-US");
                Window_Thread.CurrentUICulture = CultureInfo.CreateSpecificCulture("en-US");
                Window_Thread.SetApartmentState(ApartmentState.STA);
                Window_Thread.IsBackground = true;
                Window_Thread.Start();
                insert_Log("XY Waveform Graph Window 1 has been opened.", 0);
            }
            else
            {
                insert_Log("XY Waveform Graph Window 1 is already open.", 2);
            }
        }

        private void W1_XY_Waveform_Close(object sender, EventArgs e)
        {
            XY_Waveform_Window_1.Closed -= W1_XY_Waveform_Close;
            XY_Waveform_Window_1.Dispatcher.BeginInvokeShutdown(DispatcherPriority.Normal);
            XY_Waveform_Window_1 = null;
            XY_Waveform_Window_1_isOpen = false;
            this.Dispatcher.BeginInvoke(DispatcherPriority.Normal, (Action)(() =>
            {
                XY_Waveform_W1_Graph_Selected = Graph_Not_Selected;
            }));
            insert_Log("XY Waveform Graph Window 1 has been closed.", 0);
        }

        private void W2_XY_Waveform_Open_Click(object sender, RoutedEventArgs e)
        {
            if (XY_Waveform_Window_2 == null & XY_Waveform_Window_2_isOpen == false)
            {
                XY_Waveform_Window_2_isOpen = true;
                XY_Waveform_W2_Graph_Selected = Graph_Selected;
                Thread Window_Thread = new Thread(new ThreadStart(() =>
                {
                    XY_Waveform_Window_2 = new XY_Waveform_Plotter(Communication_Selected.Company_Name + " " + Communication_Selected.Oscilloscope_Model + " " + "XY Waveform Window 2");
                    XY_Waveform_Window_2.Show();
                    XY_Waveform_Window_2.Closed += W2_XY_Waveform_Close;
                    Dispatcher.Run();
                }));
                Window_Thread.CurrentCulture = CultureInfo.CreateSpecificCulture("en-US");
                Window_Thread.CurrentUICulture = CultureInfo.CreateSpecificCulture("en-US");
                Window_Thread.SetApartmentState(ApartmentState.STA);
                Window_Thread.IsBackground = true;
                Window_Thread.Start();
                insert_Log("XY Waveform Graph Window 2 has been opened.", 0);
            }
            else
            {
                insert_Log("XY Waveform Graph Window 2 is already open.", 2);
            }
        }

        private void W2_XY_Waveform_Close(object sender, EventArgs e)
        {
            XY_Waveform_Window_2.Closed -= W2_XY_Waveform_Close;
            XY_Waveform_Window_2.Dispatcher.BeginInvokeShutdown(DispatcherPriority.Normal);
            XY_Waveform_Window_2 = null;
            XY_Waveform_Window_2_isOpen = false;
            this.Dispatcher.BeginInvoke(DispatcherPriority.Normal, (Action)(() =>
            {
                XY_Waveform_W2_Graph_Selected = Graph_Not_Selected;
            }));
            insert_Log("XY Waveform Graph Window 2 has been closed.", 0);
        }

        private void W3_XY_Waveform_Open_Click(object sender, RoutedEventArgs e)
        {
            if (XY_Waveform_Window_3 == null & XY_Waveform_Window_3_isOpen == false)
            {
                XY_Waveform_Window_3_isOpen = true;
                XY_Waveform_W3_Graph_Selected = Graph_Selected;
                Thread Window_Thread = new Thread(new ThreadStart(() =>
                {
                    XY_Waveform_Window_3 = new XY_Waveform_Plotter(Communication_Selected.Company_Name + " " + Communication_Selected.Oscilloscope_Model + " " + "XY Waveform Window 3");
                    XY_Waveform_Window_3.Show();
                    XY_Waveform_Window_3.Closed += W3_XY_Waveform_Close;
                    Dispatcher.Run();
                }));
                Window_Thread.CurrentCulture = CultureInfo.CreateSpecificCulture("en-US");
                Window_Thread.CurrentUICulture = CultureInfo.CreateSpecificCulture("en-US");
                Window_Thread.SetApartmentState(ApartmentState.STA);
                Window_Thread.IsBackground = true;
                Window_Thread.Start();
                insert_Log("XY Waveform Graph Window 3 has been opened.", 0);
            }
            else
            {
                insert_Log("XY Waveform Graph Window 3 is already open.", 2);
            }
        }

        private void W3_XY_Waveform_Close(object sender, EventArgs e)
        {
            XY_Waveform_Window_3.Closed -= W3_XY_Waveform_Close;
            XY_Waveform_Window_3.Dispatcher.BeginInvokeShutdown(DispatcherPriority.Normal);
            XY_Waveform_Window_3 = null;
            XY_Waveform_Window_3_isOpen = false;
            this.Dispatcher.BeginInvoke(DispatcherPriority.Normal, (Action)(() =>
            {
                XY_Waveform_W3_Graph_Selected = Graph_Not_Selected;
            }));
            insert_Log("XY Waveform Graph Window 3 has been closed.", 0);
        }

        private void W4_XY_Waveform_Open_Click(object sender, RoutedEventArgs e)
        {
            if (XY_Waveform_Window_4 == null & XY_Waveform_Window_4_isOpen == false)
            {
                XY_Waveform_Window_4_isOpen = true;
                XY_Waveform_W4_Graph_Selected = Graph_Selected;
                Thread Window_Thread = new Thread(new ThreadStart(() =>
                {
                    XY_Waveform_Window_4 = new XY_Waveform_Plotter(Communication_Selected.Company_Name + " " + Communication_Selected.Oscilloscope_Model + " " + "XY Waveform Window 4");
                    XY_Waveform_Window_4.Show();
                    XY_Waveform_Window_4.Closed += W4_XY_Waveform_Close;
                    Dispatcher.Run();
                }));
                Window_Thread.CurrentCulture = CultureInfo.CreateSpecificCulture("en-US");
                Window_Thread.CurrentUICulture = CultureInfo.CreateSpecificCulture("en-US");
                Window_Thread.SetApartmentState(ApartmentState.STA);
                Window_Thread.IsBackground = true;
                Window_Thread.Start();
                insert_Log("XY Waveform Graph Window 4 has been opened.", 0);
            }
            else
            {
                insert_Log("XY Waveform Graph Window 4 is already open.", 2);
            }
        }

        private void W4_XY_Waveform_Close(object sender, EventArgs e)
        {
            XY_Waveform_Window_4.Closed -= W4_XY_Waveform_Close;
            XY_Waveform_Window_4.Dispatcher.BeginInvokeShutdown(DispatcherPriority.Normal);
            XY_Waveform_Window_4 = null;
            XY_Waveform_Window_4_isOpen = false;
            this.Dispatcher.BeginInvoke(DispatcherPriority.Normal, (Action)(() =>
            {
                XY_Waveform_W4_Graph_Selected = Graph_Not_Selected;
            }));
            insert_Log("XY Waveform Graph Window 4 has been closed.", 0);
        }
    }
}
