using MahApps.Metro.Controls;
using System;

namespace Query_Measurement_Control
{
    public partial class Query_Measurement_Window : MetroWindow
    {
        private System.Timers.Timer SCPI_Timer;
        private System.Timers.Timer Progress_Timer;
        private System.Diagnostics.Stopwatch SCPI_Stopwatch;

        private void Initialize_Timers(double SCPI_Send_Delay)
        {
            SCPI_Stopwatch = new System.Diagnostics.Stopwatch();
            SCPI_Stopwatch.Start();

            Progress_Timer = new System.Timers.Timer((SCPI_Send_Delay * 1000) / 10);
            Progress_Timer.Elapsed += Progress_process;
            Progress_Timer.AutoReset = false;
            Progress_Timer.Enabled = true;

            SCPI_Timer = new System.Timers.Timer((SCPI_Send_Delay * 1000));
            SCPI_Timer.Elapsed += SCPI_Process;
            SCPI_Timer.AutoReset = false;
            SCPI_Timer.Enabled = true;
        }

        private void SCPI_Process(object sender, EventArgs e)
        {
            if (Query_Measurement_Pause == false)
            {
                NX_StarWave.NX_StarWave_Window.Tektronix_SendCommands_Queue.Add("Query_Measurement," + Window_ID + "," + SCPI_Command);
            }
            SCPI_Stopwatch.Restart();
            SCPI_Timer.Enabled = true;
        }

        private void Progress_process(object sender, EventArgs e)
        {
            if (Query_Measurement_Pause == false)
            {
                Delay_Timer_Progress = SCPI_Stopwatch.Elapsed.TotalSeconds;
            }
            else
            {
                Delay_Timer_Progress = 0;
            }
            Progress_Timer.Enabled = true;
        }
    }
}
