using MahApps.Metro.Controls;
using System;

namespace Query_Measurement_Control
{
    public partial class Query_Measurement_Window : MetroWindow
    {
        private void Window_Close(object sender, EventArgs e)
        {
            try
            {
                SCPI_Timer.Stop();
                SCPI_Timer.Dispose();
                SCPI_Timer = null;
                SCPI_Stopwatch.Stop();
                SCPI_Stopwatch = null;
                Progress_Timer.Stop();
                Progress_Timer.Dispose();
                Progress_Timer = null;
                Measurements.Clear();
                Measurements = null;
            }
            catch (Exception)
            {

            }
        }
    }
}
