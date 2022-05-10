using MahApps.Metro.Controls;
using System;
using System.Timers;
using System.Windows;

namespace NX_StarWave
{
    public partial class NX_StarWave_Window : MetroWindow
    {
        private System.Timers.Timer Runtime_Timer;
        private System.Diagnostics.Stopwatch Runtime_Timer_Watch = new System.Diagnostics.Stopwatch();

        private bool Reset_Runtime_Timer = false;

        private void Initialize_Runtime_Timer()
        {
            Runtime_Timer = new Timer();
            Runtime_Timer.Interval = 1000;
            Runtime_Timer.Elapsed += Runtime_Timer_Run;
            Runtime_Timer.AutoReset = true;
            Runtime_Timer.Enabled = true;
            Runtime_Timer_Watch.Start();
        }

        private void Runtime_Timer_Run(Object source, ElapsedEventArgs e)
        {
            RunTime_Counter_Value = String.Format("{0:00}:{1:00}:{2:00}", Runtime_Timer_Watch.Elapsed.Hours, Runtime_Timer_Watch.Elapsed.Minutes, Runtime_Timer_Watch.Elapsed.Seconds);
            if (Reset_Runtime_Timer)
            {
                Reset_Runtime_Timer = false;
                Runtime_Timer_Watch.Restart();
            }
        }

        private void Reset_Runtime_Timer_Click(object sender, RoutedEventArgs e)
        {
            Reset_Runtime_Timer = true;
        }
    }
}
