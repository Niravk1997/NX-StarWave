using MahApps.Metro.Controls;
using System;

namespace Channel_DataLogger
{
    public partial class CH_DataLog_Graph_Window : MetroWindow
    {
        private void Window_Closed(object sender, EventArgs e)
        {
            try
            {
                Graph.Plot.Clear();
                DataProcess.Stop();
                DataProcess.Dispose();
                GraphRender.Stop();
                Data_Queue.Dispose();
                DataProcess = null;
                GraphRender = null;
                Data_Queue = null;
                Measurement_Data = null;
                Measurement_Plot = null;
                Functions = null;
                Graph = null;
                if (Zoom_Control_Window_IsEnabled)
                {
                    Zoom_Control_Plot.Plot.Clear();
                    Zoom_Control_Plot = null;
                }
                this.Close();
            }
            catch (Exception)
            {

            }
        }
    }
}
