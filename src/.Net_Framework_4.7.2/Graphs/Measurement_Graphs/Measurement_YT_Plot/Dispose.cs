using MahApps.Metro.Controls;
using System;

namespace Measurement_Plot
{
    public partial class Measurement_Plot_Window : MetroWindow
    {

        private void Window_Closed(object sender, EventArgs e)
        {
            try
            {
                Measurement_Data_Timer.Stop();
                GraphRender.Stop();
                Measurement_Data_Timer.Dispose();
                Graph.Plot.Clear();
                Measurement_Data_Queue.Dispose();
                Measurement_Data_Queue = null;
                Measurement_Data_Timer = null;
                GraphRender = null;
                Date_Time = null;
                Measurement_Data = null;
                Graph = null;
            }
            catch (Exception)
            {

            }

        }
    }
}
