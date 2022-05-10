using AllChannels_YT;
using AllChannels_YT_Square;
using AllChannels_YT_Stack;
using MahApps.Metro.Controls;
using System;
using System.Globalization;
using System.Threading;
using System.Windows;
using System.Windows.Threading;
using YT_All_Seperate_Axis;

namespace NX_StarWave
{
    public partial class NX_StarWave_Window : MetroWindow
    {
        private AllChannels_YT_Plotter All_Channels_YT;
        private AllChannels_YT_Square_Plotter All_Channels_YT_Square;
        private AllChannels_YT_Stack_Plotter All_Channels_YT_Stack;
        private YT_All_Seperate_Axis_Plotter All_Channels_YT_Seperate;

        private bool All_Channels_isOpen = false;
        private bool All_Channels_YT_Square_isOpen = false;
        private bool All_Channels_YT_Stack_isOpen = false;
        private bool All_Channels_YT_Seperate_isOpen = false;

        private void Initialize_YT_All_EventHandler()
        {
            AddHandler(YT_Graph_Control.YT_Graph_Control.All_CH_YT_Open_Event, new RoutedEventHandler(AllCH_YT_Open_Click));
            AddHandler(YT_Graph_Control.YT_Graph_Control.All_CH_YT_Square_Open_Event, new RoutedEventHandler(AllCH_YT_Square_Open_Click));
            AddHandler(YT_Graph_Control.YT_Graph_Control.All_CH_YT_Stack_Open_Event, new RoutedEventHandler(AllCH_YT_Stack_Open_Click));
            AddHandler(YT_Graph_Control.YT_Graph_Control.All_CH_YT_Seperate_Open_Event, new RoutedEventHandler(AllCH_YT_Seperate_Open_Click));
        }

        private void AllCH_YT_Open_Click(object sender, RoutedEventArgs e)
        {
            if (All_Channels_YT == null & All_Channels_isOpen == false)
            {
                All_Channels_isOpen = true;
                string CH_1_Color = Channel_1_Color.ToString();
                string CH_2_Color = Channel_2_Color.ToString();
                string CH_3_Color = Channel_3_Color.ToString();
                string CH_4_Color = Channel_4_Color.ToString();
                YT_ALL_CH_Graph_Selected = Graph_Selected;
                Thread Window_Thread = new Thread(new ThreadStart(() =>
                {
                    All_Channels_YT = new AllChannels_YT_Plotter(Communication_Selected.Company_Name + " " + Communication_Selected.Oscilloscope_Model + " " + "All Channels YT Window", CH_1_Color, CH_2_Color, CH_3_Color, CH_4_Color);
                    All_Channels_YT.Show();
                    All_Channels_YT.Closed += AllCH_YT_Close;
                    Dispatcher.Run();
                }));
                Window_Thread.CurrentCulture = CultureInfo.CreateSpecificCulture("en-US");
                Window_Thread.CurrentUICulture = CultureInfo.CreateSpecificCulture("en-US");
                Window_Thread.SetApartmentState(ApartmentState.STA);
                Window_Thread.IsBackground = true;
                Window_Thread.Start();
                insert_Log("All Channels YT Graph Window has been opened.", 0);
            }
            else
            {
                insert_Log("All Channels YT Graph Window is already open.", 2);
            }
        }

        private void AllCH_YT_Close(object sender, EventArgs e)
        {
            All_Channels_YT.Closed -= AllCH_YT_Close;
            All_Channels_YT.Dispatcher.BeginInvokeShutdown(DispatcherPriority.Normal);
            All_Channels_YT = null;
            All_Channels_isOpen = false;
            this.Dispatcher.BeginInvoke(DispatcherPriority.Normal, (Action)(() =>
            {
                YT_ALL_CH_Graph_Selected = Graph_Not_Selected;
            }));
            insert_Log("All Channels YT Graph Window has been closed.", 0);
        }

        private void AllCH_YT_Square_Open_Click(object sender, RoutedEventArgs e)
        {
            if (All_Channels_YT_Square == null & All_Channels_YT_Square_isOpen == false)
            {
                All_Channels_YT_Square_isOpen = true;
                string CH_1_Color = Channel_1_Color.ToString();
                string CH_2_Color = Channel_2_Color.ToString();
                string CH_3_Color = Channel_3_Color.ToString();
                string CH_4_Color = Channel_4_Color.ToString();
                YT_ALL_CH_Square_Graph_Selected = Graph_Selected;
                Thread Window_Thread = new Thread(new ThreadStart(() =>
                {
                    All_Channels_YT_Square = new AllChannels_YT_Square_Plotter(Communication_Selected.Company_Name + " " + Communication_Selected.Oscilloscope_Model + " " + "All Channels YT 4 Panels Square Window", CH_1_Color, CH_2_Color, CH_3_Color, CH_4_Color);
                    All_Channels_YT_Square.Show();
                    All_Channels_YT_Square.Closed += AllCH_YT_Square_Close;
                    Dispatcher.Run();
                }));
                Window_Thread.CurrentCulture = CultureInfo.CreateSpecificCulture("en-US");
                Window_Thread.CurrentUICulture = CultureInfo.CreateSpecificCulture("en-US");
                Window_Thread.SetApartmentState(ApartmentState.STA);
                Window_Thread.IsBackground = true;
                Window_Thread.Start();
                insert_Log("All Channels YT Four Graph Panels Window has been opened.", 0);
            }
            else
            {
                insert_Log("All Channels YT Four Graph Panels Window is already open.", 2);
            }
        }

        private void AllCH_YT_Square_Close(object sender, EventArgs e)
        {
            All_Channels_YT_Square.Closed -= AllCH_YT_Square_Close;
            All_Channels_YT_Square.Dispatcher.BeginInvokeShutdown(DispatcherPriority.Normal);
            All_Channels_YT_Square = null;
            All_Channels_YT_Square_isOpen = false;
            this.Dispatcher.BeginInvoke(DispatcherPriority.Normal, (Action)(() =>
            {
                YT_ALL_CH_Square_Graph_Selected = Graph_Not_Selected;
            }));
            insert_Log("All Channels YT Four Graph Panels Window has been closed.", 0);
        }

        private void AllCH_YT_Stack_Open_Click(object sender, RoutedEventArgs e)
        {
            if (All_Channels_YT_Stack == null & All_Channels_YT_Stack_isOpen == false)
            {
                All_Channels_YT_Stack_isOpen = true;
                string CH_1_Color = Channel_1_Color.ToString();
                string CH_2_Color = Channel_2_Color.ToString();
                string CH_3_Color = Channel_3_Color.ToString();
                string CH_4_Color = Channel_4_Color.ToString();
                YT_ALL_CH_Stack_Graph_Selected = Graph_Selected;
                Thread Window_Thread = new Thread(new ThreadStart(() =>
                {
                    All_Channels_YT_Stack = new AllChannels_YT_Stack_Plotter(Communication_Selected.Company_Name + " " + Communication_Selected.Oscilloscope_Model + " " + "All Channels YT 4 Panels Square Window", CH_1_Color, CH_2_Color, CH_3_Color, CH_4_Color);
                    All_Channels_YT_Stack.Show();
                    All_Channels_YT_Stack.Closed += AllCH_YT_Stack_Close;
                    Dispatcher.Run();
                }));
                Window_Thread.CurrentCulture = CultureInfo.CreateSpecificCulture("en-US");
                Window_Thread.CurrentUICulture = CultureInfo.CreateSpecificCulture("en-US");
                Window_Thread.SetApartmentState(ApartmentState.STA);
                Window_Thread.IsBackground = true;
                Window_Thread.Start();
                insert_Log("All Channels YT Stack Graph Panels Window has been opened.", 0);
            }
            else
            {
                insert_Log("All Channels YT Stack Graph Panels Window is already open.", 2);
            }
        }

        private void AllCH_YT_Stack_Close(object sender, EventArgs e)
        {
            All_Channels_YT_Stack.Closed -= AllCH_YT_Stack_Close;
            All_Channels_YT_Stack.Dispatcher.BeginInvokeShutdown(DispatcherPriority.Normal);
            All_Channels_YT_Stack = null;
            All_Channels_YT_Stack_isOpen = false;
            this.Dispatcher.BeginInvoke(DispatcherPriority.Normal, (Action)(() =>
            {
                YT_ALL_CH_Stack_Graph_Selected = Graph_Not_Selected;
            }));
            insert_Log("All Channels YT Stack Graph Panels Window has been closed.", 0);
        }

        private void AllCH_YT_Seperate_Open_Click(object sender, RoutedEventArgs e)
        {
            if (All_Channels_YT_Seperate == null & All_Channels_YT_Seperate_isOpen == false)
            {
                All_Channels_YT_Seperate_isOpen = true;
                string CH_1_Color = Channel_1_Color.ToString();
                string CH_2_Color = Channel_2_Color.ToString();
                string CH_3_Color = Channel_3_Color.ToString();
                string CH_4_Color = Channel_4_Color.ToString();
                YT_ALL_CH_Seperate_Graph_Selected = Graph_Selected;
                Thread Window_Thread = new Thread(new ThreadStart(() =>
                {
                    All_Channels_YT_Seperate = new YT_All_Seperate_Axis_Plotter(Communication_Selected.Company_Name + " " + Communication_Selected.Oscilloscope_Model + " " + "All Channels Seperate Axis YT Window", CH_1_Color, CH_2_Color, CH_3_Color, CH_4_Color);
                    All_Channels_YT_Seperate.Show();
                    All_Channels_YT_Seperate.Closed += AllCH_YT_Seperate_Close;
                    Dispatcher.Run();
                }));
                Window_Thread.CurrentCulture = CultureInfo.CreateSpecificCulture("en-US");
                Window_Thread.CurrentUICulture = CultureInfo.CreateSpecificCulture("en-US");
                Window_Thread.SetApartmentState(ApartmentState.STA);
                Window_Thread.IsBackground = true;
                Window_Thread.Start();
                insert_Log("All Channels YT Seperate Graph Panels Window has been opened.", 0);
            }
            else
            {
                insert_Log("All Channels YT Seperate Graph Panels Window is already open.", 2);
            }
        }

        private void AllCH_YT_Seperate_Close(object sender, EventArgs e)
        {
            All_Channels_YT_Seperate.Closed -= AllCH_YT_Seperate_Close;
            All_Channels_YT_Seperate.Dispatcher.BeginInvokeShutdown(DispatcherPriority.Normal);
            All_Channels_YT_Seperate = null;
            All_Channels_YT_Seperate_isOpen = false;
            this.Dispatcher.BeginInvoke(DispatcherPriority.Normal, (Action)(() =>
            {
                YT_ALL_CH_Seperate_Graph_Selected = Graph_Not_Selected;
            }));
            insert_Log("All Channels YT Seperate Graph Panels Window has been closed.", 0);
        }
    }
}
