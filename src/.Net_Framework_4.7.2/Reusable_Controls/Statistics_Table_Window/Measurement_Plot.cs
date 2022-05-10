using MahApps.Metro.Controls;
using Measurement_Plot;
using System;
using System.Windows;

namespace Statistics_Table
{
    public partial class Statistics_Table_Window : MetroWindow
    {
        private bool Frequency_Measurement_Plot_Enabled = false;
        private bool Period_Measurement_Plot_Enabled = false;
        private bool PeakPeak_Measurement_Plot_Enabled = false;
        private bool Mean_Measurement_Plot_Enabled = false;
        private bool RMS_Measurement_Plot_Enabled = false;
        private bool Min_Measurement_Plot_Enabled = false;
        private bool Max_Measurement_Plot_Enabled = false;
        private bool Stdev_Measurement_Plot_Enabled = false;

        private Measurement_Plot_Window Frequency_Measurement_Plot_Window;
        private Measurement_Plot_Window Period_Measurement_Plot_Window;
        private Measurement_Plot_Window PeakPeak_Measurement_Plot_Window;
        private Measurement_Plot_Window Mean_Measurement_Plot_Window;
        private Measurement_Plot_Window RMS_Measurement_Plot_Window;
        private Measurement_Plot_Window Min_Measurement_Plot_Window;
        private Measurement_Plot_Window Max_Measurement_Plot_Window;
        private Measurement_Plot_Window Stdev_Measurement_Plot_Window;

        private void Frequency_Measurement_Plot_Click(object sender, RoutedEventArgs e)
        {
            if (Frequency_Measurement_Plot_Window == null & Frequency_Measurement_Plot_Enabled == false & Frequency_Values.Count > 0 & Frequency_DateTime_Values.Count > 0)
            {
                Frequency_Measurement_Plot_Enabled = true;
                Frequency_Measurement_Plot_Window = new Measurement_Plot_Window(Frequency_DateTime_Values.ToArray(), Frequency_Values.ToArray(), Short_Title + " Frequency (Hz)", "Hz", Statistics_Table_Owner_Color.ToString());
                Frequency_Measurement_Plot_Window.Show();
                Frequency_Measurement_Plot_Window.Closed += Frequency_Measurement_Plot_Window_Close;
            }
        }

        private void Frequency_Measurement_Plot_Window_Close(object sender, EventArgs e)
        {
            Frequency_Measurement_Plot_Window.Closed -= Frequency_Measurement_Plot_Window_Close;
            Frequency_Measurement_Plot_Window = null;
            Frequency_Measurement_Plot_Enabled = false;
        }

        private void Period_Measurement_Plot_Click(object sender, RoutedEventArgs e)
        {
            if (Period_Measurement_Plot_Window == null & Period_Measurement_Plot_Enabled == false & Period_Values.Count > 0 & Period_DateTime_Values.Count > 0)
            {
                Period_Measurement_Plot_Enabled = true;
                Period_Measurement_Plot_Window = new Measurement_Plot_Window(Period_DateTime_Values.ToArray(), Period_Values.ToArray(), Short_Title + " Period (s)", "s", Statistics_Table_Owner_Color.ToString());
                Period_Measurement_Plot_Window.Show();
                Period_Measurement_Plot_Window.Closed += Period_Measurement_Plot_Window_Close;
            }
        }

        private void Period_Measurement_Plot_Window_Close(object sender, EventArgs e)
        {
            Period_Measurement_Plot_Window.Closed -= Period_Measurement_Plot_Window_Close;
            Period_Measurement_Plot_Window = null;
            Period_Measurement_Plot_Enabled = false;
        }

        private void PeakPeak_Measurement_Plot_Click(object sender, RoutedEventArgs e)
        {
            if (PeakPeak_Measurement_Plot_Window == null & PeakPeak_Measurement_Plot_Enabled == false & PeakPeak_Values.Count > 0 & PeakPeak_DateTime_Values.Count > 0)
            {
                PeakPeak_Measurement_Plot_Enabled = true;
                PeakPeak_Measurement_Plot_Window = new Measurement_Plot_Window(PeakPeak_DateTime_Values.ToArray(), PeakPeak_Values.ToArray(), Short_Title + " Pk-Pk (" + YAxis_Units + ")", YAxis_Units, Statistics_Table_Owner_Color.ToString());
                PeakPeak_Measurement_Plot_Window.Show();
                PeakPeak_Measurement_Plot_Window.Closed += PeakPeak_Measurement_Plot_Window_Close;
            }
        }

        private void PeakPeak_Measurement_Plot_Window_Close(object sender, EventArgs e)
        {
            PeakPeak_Measurement_Plot_Window.Closed -= PeakPeak_Measurement_Plot_Window_Close;
            PeakPeak_Measurement_Plot_Window = null;
            PeakPeak_Measurement_Plot_Enabled = false;
        }

        private void Mean_Measurement_Plot_Click(object sender, RoutedEventArgs e)
        {
            if (Mean_Measurement_Plot_Window == null & Mean_Measurement_Plot_Enabled == false & Mean_Values.Count > 0 & Mean_DateTime_Values.Count > 0)
            {
                Mean_Measurement_Plot_Enabled = true;
                Mean_Measurement_Plot_Window = new Measurement_Plot_Window(Mean_DateTime_Values.ToArray(), Mean_Values.ToArray(), Short_Title + " Mean (" + YAxis_Units + ")", YAxis_Units, Statistics_Table_Owner_Color.ToString());
                Mean_Measurement_Plot_Window.Show();
                Mean_Measurement_Plot_Window.Closed += Mean_Measurement_Plot_Window_Close;
            }
        }

        private void Mean_Measurement_Plot_Window_Close(object sender, EventArgs e)
        {
            Mean_Measurement_Plot_Window.Closed -= Mean_Measurement_Plot_Window_Close;
            Mean_Measurement_Plot_Window = null;
            Mean_Measurement_Plot_Enabled = false;
        }

        private void RMS_Measurement_Plot_Click(object sender, RoutedEventArgs e)
        {
            if (RMS_Measurement_Plot_Window == null & RMS_Measurement_Plot_Enabled == false & RMS_Values.Count > 0 & RMS_DateTime_Values.Count > 0)
            {
                RMS_Measurement_Plot_Enabled = true;
                RMS_Measurement_Plot_Window = new Measurement_Plot_Window(RMS_DateTime_Values.ToArray(), RMS_Values.ToArray(), Short_Title + " RMS (" + YAxis_Units + ")", YAxis_Units, Statistics_Table_Owner_Color.ToString());
                RMS_Measurement_Plot_Window.Show();
                RMS_Measurement_Plot_Window.Closed += RMS_Measurement_Plot_Window_Close;
            }
        }

        private void RMS_Measurement_Plot_Window_Close(object sender, EventArgs e)
        {
            RMS_Measurement_Plot_Window.Closed -= RMS_Measurement_Plot_Window_Close;
            RMS_Measurement_Plot_Window = null;
            RMS_Measurement_Plot_Enabled = false;
        }

        private void Min_Measurement_Plot_Click(object sender, RoutedEventArgs e)
        {
            if (Min_Measurement_Plot_Window == null & Min_Measurement_Plot_Enabled == false & Min_Values.Count > 0 & Min_DateTime_Values.Count > 0)
            {
                Min_Measurement_Plot_Enabled = true;
                Min_Measurement_Plot_Window = new Measurement_Plot_Window(Min_DateTime_Values.ToArray(), Min_Values.ToArray(), Short_Title + " Min (" + YAxis_Units + ")", YAxis_Units, Statistics_Table_Owner_Color.ToString());
                Min_Measurement_Plot_Window.Show();
                Min_Measurement_Plot_Window.Closed += Min_Measurement_Plot_Window_Close;
            }
        }

        private void Min_Measurement_Plot_Window_Close(object sender, EventArgs e)
        {
            Min_Measurement_Plot_Window.Closed -= Min_Measurement_Plot_Window_Close;
            Min_Measurement_Plot_Window = null;
            Min_Measurement_Plot_Enabled = false;
        }

        private void Max_Measurement_Plot_Click(object sender, RoutedEventArgs e)
        {
            if (Max_Measurement_Plot_Window == null & Max_Measurement_Plot_Enabled == false & Max_Values.Count > 0 & Max_DateTime_Values.Count > 0)
            {
                Max_Measurement_Plot_Enabled = true;
                Max_Measurement_Plot_Window = new Measurement_Plot_Window(Max_DateTime_Values.ToArray(), Max_Values.ToArray(), Short_Title + " Max (" + YAxis_Units + ")", YAxis_Units, Statistics_Table_Owner_Color.ToString());
                Max_Measurement_Plot_Window.Show();
                Max_Measurement_Plot_Window.Closed += Max_Measurement_Plot_Window_Close;
            }
        }

        private void Max_Measurement_Plot_Window_Close(object sender, EventArgs e)
        {
            Max_Measurement_Plot_Window.Closed -= Max_Measurement_Plot_Window_Close;
            Max_Measurement_Plot_Window = null;
            Max_Measurement_Plot_Enabled = false;
        }

        private void Stdev_Measurement_Plot_Click(object sender, RoutedEventArgs e)
        {
            if (Stdev_Measurement_Plot_Window == null & Stdev_Measurement_Plot_Enabled == false & Stdev_Values.Count > 0 & Stdev_DateTime_Values.Count > 0)
            {
                Stdev_Measurement_Plot_Enabled = true;
                Stdev_Measurement_Plot_Window = new Measurement_Plot_Window(Stdev_DateTime_Values.ToArray(), Stdev_Values.ToArray(), Short_Title + " Stdev (" + YAxis_Units + ")", YAxis_Units, Statistics_Table_Owner_Color.ToString());
                Stdev_Measurement_Plot_Window.Show();
                Stdev_Measurement_Plot_Window.Closed += Stdev_Measurement_Plot_Window_Close;
            }
        }

        private void Stdev_Measurement_Plot_Window_Close(object sender, EventArgs e)
        {
            Stdev_Measurement_Plot_Window.Closed -= Stdev_Measurement_Plot_Window_Close;
            Stdev_Measurement_Plot_Window = null;
            Stdev_Measurement_Plot_Enabled = false;
        }
    }
}
