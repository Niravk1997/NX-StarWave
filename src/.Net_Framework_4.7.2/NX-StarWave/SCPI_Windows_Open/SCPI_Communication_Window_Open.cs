using MahApps.Metro.Controls;
using Oscilloscope_Control_Controls;
using SCPI_Communication;
using System;
using System.Windows;
using System.Windows.Threading;

namespace NX_StarWave
{
    public partial class NX_StarWave_Window : MetroWindow
    {
        private SCPI_Communication_Window SCPI_Communication_Window;

        private bool SCPI_Communication_Window_isOpen = false;

        private void Initialize_SCPI_Communication_EventHandler()
        {
            AddHandler(Oscilloscope_Control_Windows_Control.SCPI_Communication_Window_Open_Event, new RoutedEventHandler(SCPI_Communication_Window_Open_Click));
        }

        private void SCPI_Communication_Window_Open_Click(object sender, RoutedEventArgs e)
        {
            if (SCPI_Communication_Window == null & SCPI_Communication_Window_isOpen == false)
            {
                SCPI_Communication_Window_isOpen = true;
                SCPI_Communication_Window_Selected = Graph_Selected;
                SCPI_Communication_Window = new SCPI_Communication_Window();
                SCPI_Communication_Window.Show();
                SCPI_Communication_Window.Closed += SCPI_Communication_Window_Close;
                insert_Log("SCPI Communication Window has been opened.", 0);
            }
            else
            {
                insert_Log("SCPI Communication Window is already open.", 2);
            }
        }

        private void SCPI_Communication_Window_Close(object sender, EventArgs e)
        {
            SCPI_Communication_Window.Closed -= Reference_Calculator_Close;
            SCPI_Communication_Window = null;
            SCPI_Communication_Window_isOpen = false;
            this.Dispatcher.BeginInvoke(DispatcherPriority.Normal, (Action)(() =>
            {
                SCPI_Communication_Window_Selected = Graph_Not_Selected;
            }));
            insert_Log("SCPI Communication Window has been closed.", 0);
        }
    }
}
