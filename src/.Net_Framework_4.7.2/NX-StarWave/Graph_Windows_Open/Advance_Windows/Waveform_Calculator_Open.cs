using MahApps.Metro.Controls;
using NodeNetwork_Math;
using Reference_Calculator;
using System;
using System.Globalization;
using System.Threading;
using System.Windows;
using System.Windows.Threading;
using Waveform_Calculator;

namespace NX_StarWave
{
    public partial class NX_StarWave_Window : MetroWindow
    {
        private Calculator_Panel Waveform_Calculator_Window;
        private Reference_Config_Panel Reference_Calculator_Window;
        private NodeNetwork_Window NodeNetwork_Calculator_Window;

        private bool Waveform_Calculator_Window_isOpen = false;
        private bool Reference_Calculator_Window_isOpen = false;
        private bool NodeNetwork_Calculator_Window_isOpen = false;

        private void Initialize_Waveform_Calculator_EventHandler()
        {
            AddHandler(Math_Graph_Control.Math_Graph_Control.Waveform_Calculator_Open_Event, new RoutedEventHandler(Waveform_Calculator_Open_Click));
            AddHandler(Math_Graph_Control.Math_Graph_Control.Reference_Calculator_Open_Event, new RoutedEventHandler(Reference_Calculator_Open_Click));
            AddHandler(Math_Graph_Control.Math_Graph_Control.NodeNetwork_Calculator_Open_Event, new RoutedEventHandler(NodeNetwork_Calculator_Open_Click));
        }

        private void Waveform_Calculator_Open_Click(object sender, RoutedEventArgs e)
        {
            if (Waveform_Calculator_Window == null & Waveform_Calculator_Window_isOpen == false)
            {
                Waveform_Calculator_Window_isOpen = true;
                Waveform_Calculator_Selected = Graph_Selected;
                Thread Window_Thread = new Thread(new ThreadStart(() =>
                {
                    Waveform_Calculator_Window = new Calculator_Panel();
                    Waveform_Calculator_Window.Show();
                    Waveform_Calculator_Window.Closed += Waveform_Calculator_Close;
                    try
                    {
                        Dispatcher.Run();
                    }
                    catch (Exception Ex) 
                    {
                        Waveform_Calculator_Window_isOpen = false;
                        Waveform_Calculator_Window.Closed -= Waveform_Calculator_Close;
                        Waveform_Calculator_Window = null;
                        this.Dispatcher.BeginInvoke(DispatcherPriority.Normal, (Action)(() =>
                        {
                            Waveform_Calculator_Selected = Graph_Not_Selected;
                        }));
                        insert_Log(Ex.ToString(), 1);
                    }
                }));
                Window_Thread.CurrentCulture = CultureInfo.CreateSpecificCulture("en-US");
                Window_Thread.CurrentUICulture = CultureInfo.CreateSpecificCulture("en-US");
                Window_Thread.SetApartmentState(ApartmentState.STA);
                Window_Thread.IsBackground = true;
                Window_Thread.Start();
                insert_Log("Waveform Calculator Window has been opened.", 0);
            }
            else
            {
                insert_Log("Waveform Calculator Window is already open.", 2);
            }
        }

        private void Waveform_Calculator_Close(object sender, EventArgs e)
        {
            Waveform_Calculator_Window.Closed -= Waveform_Calculator_Close;
            Waveform_Calculator_Window.Dispatcher.BeginInvokeShutdown(DispatcherPriority.Normal);
            Waveform_Calculator_Window = null;
            Waveform_Calculator_Window_isOpen = false;
            this.Dispatcher.BeginInvoke(DispatcherPriority.Normal, (Action)(() =>
            {
                Waveform_Calculator_Selected = Graph_Not_Selected;
            }));
            insert_Log("Waveform Calculator Window has been closed.", 0);
        }

        private void Reference_Calculator_Open_Click(object sender, RoutedEventArgs e)
        {
            if (Reference_Calculator_Window == null & Reference_Calculator_Window_isOpen == false)
            {
                Reference_Calculator_Window_isOpen = true;
                Reference_Calculator_Graph_Selected = Graph_Selected;
                Reference_Calculator_Window = new Reference_Config_Panel();
                Reference_Calculator_Window.Show();
                Reference_Calculator_Window.Closed += Reference_Calculator_Close;
                insert_Log("Reference Calculator Window has been opened.", 0);
            }
            else
            {
                insert_Log("Reference Calculator Window is already open.", 2);
            }
        }

        private void Reference_Calculator_Close(object sender, EventArgs e)
        {
            Reference_Calculator_Window.Closed -= Reference_Calculator_Close;
            Reference_Calculator_Window = null;
            Reference_Calculator_Window_isOpen = false;
            this.Dispatcher.BeginInvoke(DispatcherPriority.Normal, (Action)(() =>
            {
                Reference_Calculator_Graph_Selected = Graph_Not_Selected;
            }));
            insert_Log("Reference Calculator Window has been closed.", 0);
        }

        private void NodeNetwork_Calculator_Open_Click(object sender, RoutedEventArgs e)
        {
            if (NodeNetwork_Calculator_Window == null & NodeNetwork_Calculator_Window_isOpen == false)
            {
                NodeNetwork_Calculator_Window_isOpen = true;
                NodeNetwork_Calculator_Graph_Selected = Graph_Selected;

                string Channel_1_Color_String = Channel_1_Color.ToString();
                string Channel_2_Color_String = Channel_2_Color.ToString();
                string Channel_3_Color_String = Channel_3_Color.ToString();
                string Channel_4_Color_String = Channel_4_Color.ToString();

                Thread Window_Thread = new Thread(new ThreadStart(() =>
                {
                    NodeNetwork_Calculator_Window = new NodeNetwork_Window(Channel_1_Color_String, Channel_2_Color_String, Channel_3_Color_String, Channel_4_Color_String);
                    NodeNetwork_Calculator_Window.Show();
                    NodeNetwork_Calculator_Window.Closed += NodeNetwork_Calculator_Close;
                    Dispatcher.Run();
                }));
                Window_Thread.CurrentCulture = CultureInfo.CreateSpecificCulture("en-US");
                Window_Thread.CurrentUICulture = CultureInfo.CreateSpecificCulture("en-US");
                Window_Thread.SetApartmentState(ApartmentState.STA);
                Window_Thread.IsBackground = true;
                Window_Thread.Start();
                insert_Log("NodeNetwork Calculator Window has been opened.", 0);
            }
            else
            {
                insert_Log("NodeNetwork Calculator Window is already open.", 2);
            }
        }

        private void NodeNetwork_Calculator_Close(object sender, EventArgs e)
        {
            NodeNetwork_Calculator_Window.Closed -= NodeNetwork_Calculator_Close;
            NodeNetwork_Calculator_Window.Dispatcher.BeginInvokeShutdown(DispatcherPriority.Normal);
            NodeNetwork_Calculator_Window = null;
            NodeNetwork_Calculator_Window_isOpen = false;
            this.Dispatcher.BeginInvoke(DispatcherPriority.Normal, (Action)(() =>
            {
                NodeNetwork_Calculator_Graph_Selected = Graph_Not_Selected;
            }));
            insert_Log("NodeNetwork Calculator Window has been closed.", 0);
        }
    }
}
