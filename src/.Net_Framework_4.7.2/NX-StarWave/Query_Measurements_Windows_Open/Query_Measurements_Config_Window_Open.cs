using MahApps.Metro.Controls;
using Oscilloscope_Control_Controls;
using Query_Measurements_Config;
using System;
using System.Windows;
using System.Windows.Threading;

namespace NX_StarWave
{
    public partial class NX_StarWave_Window : MetroWindow
    {
        private Query_Measurement_Config_Window Query_Measurement_Config_Window;

        private bool isQuery_Measurement_Config_Window_Open = false;

        private void Initialize_Query_Measurement_Window_EventHandler()
        {
            AddHandler(Oscilloscope_Control_Windows_Control.Query_Measurement_Config_Window_Open_Event, new RoutedEventHandler(Query_Measurement_Config_Window_Open_Click));
        }

        private void Query_Measurement_Config_Window_Open_Click(object sender, RoutedEventArgs e)
        {
            if (Query_Measurement_Config_Window == null & isQuery_Measurement_Config_Window_Open == false)
            {
                isQuery_Measurement_Config_Window_Open = true;
                Query_Measurement_Config_Window_Selected = Graph_Selected;
                Query_Measurement_Config_Window = new Query_Measurement_Config_Window();
                Query_Measurement_Config_Window.Owner = this;
                Query_Measurement_Config_Window.Show();
                Query_Measurement_Config_Window.Closed += Query_Measurement_Config_Window_Close;
                insert_Log("Query Measurement Config Window has been opened.", 0);
            }
            else
            {
                insert_Log("Query Measurement Config Window is already open.", 2);
            }
        }

        private void Query_Measurement_Config_Window_Close(object sender, EventArgs e)
        {
            Query_Measurement_Config_Window.Closed -= Query_Measurement_Config_Window_Close;
            Query_Measurement_Config_Window = null;
            isQuery_Measurement_Config_Window_Open = false;
            this.Dispatcher.BeginInvoke(DispatcherPriority.Normal, (Action)(() =>
            {
                Query_Measurement_Config_Window_Selected = Graph_Not_Selected;
            }));
            insert_Log("Query Measurement Config Window has been closed.", 0);
        }
    }
}
