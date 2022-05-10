using MahApps.Metro.Controls;
using System;
using System.Windows;

namespace Statistics_Table
{
    public partial class Statistics_Table_Window : MetroWindow
    {
        private void All_Measurement_Reset_Click(object sender, RoutedEventArgs e)
        {
            Reset_Measurements(100);
        }

        private void Frequency_Measurement_Reset_Click(object sender, RoutedEventArgs e)
        {
            Reset_Measurements(0);
        }

        private void Period_Measurement_Reset_Click(object sender, RoutedEventArgs e)
        {
            Reset_Measurements(1);
        }

        private void PeakPeak_Measurement_Reset_Click(object sender, RoutedEventArgs e)
        {
            Reset_Measurements(2);
        }

        private void Mean_Measurement_Reset_Click(object sender, RoutedEventArgs e)
        {
            Reset_Measurements(3);
        }

        private void RMS_Measurement_Reset_Click(object sender, RoutedEventArgs e)
        {
            Reset_Measurements(4);
        }

        private void Min_Measurement_Reset_Click(object sender, RoutedEventArgs e)
        {
            Reset_Measurements(5);
        }

        private void Max_Measurement_Reset_Click(object sender, RoutedEventArgs e)
        {
            Reset_Measurements(6);
        }

        private void Stdev_Measurement_Reset_Click(object sender, RoutedEventArgs e)
        {
            Reset_Measurements(7);
        }

        private void Reset_Measurements(int Measurement_Type)
        {
            switch (Measurement_Type)
            {
                case 0:
                    Frequency_Reset();
                    break;
                case 1:
                    Period_Reset();
                    break;
                case 2:
                    PeakPeak_Reset();
                    break;
                case 3:
                    Mean_Reset();
                    break;
                case 4:
                    RMS_Reset();
                    break;
                case 5:
                    Min_Reset();
                    break;
                case 6:
                    Max_Reset();
                    break;
                case 7:
                    Stdev_Reset();
                    break;
                default:
                    Frequency_Reset();
                    Period_Reset();
                    PeakPeak_Reset();
                    Mean_Reset();
                    RMS_Reset();
                    Min_Reset();
                    Max_Reset();
                    Stdev_Reset();
                    break;

            }
        }

        private void Frequency_Reset()
        {
            Frequency_Values.Clear();
            Frequency_DateTime_Values.Clear();
            if (Frequency_Measurement_Plot_Enabled || Frequency_Measurement_Plot_Window != null)
            { try { Frequency_Measurement_Plot_Window.Measurement_Plot_Reset_Request = true; } catch (Exception) { } }
        }

        private void Period_Reset()
        {
            Period_Values.Clear();
            Period_DateTime_Values.Clear();
            if (Period_Measurement_Plot_Enabled || Period_Measurement_Plot_Window != null)
            { try { Period_Measurement_Plot_Window.Measurement_Plot_Reset_Request = true; } catch (Exception) { } }
        }

        private void PeakPeak_Reset()
        {
            PeakPeak_Values.Clear();
            PeakPeak_DateTime_Values.Clear();
            if (PeakPeak_Measurement_Plot_Enabled || PeakPeak_Measurement_Plot_Window != null)
            { try { PeakPeak_Measurement_Plot_Window.Measurement_Plot_Reset_Request = true; } catch (Exception) { } }
        }

        private void Mean_Reset()
        {
            Mean_Values.Clear();
            Mean_DateTime_Values.Clear();
            if (Mean_Measurement_Plot_Enabled || Mean_Measurement_Plot_Window != null)
            { try { Mean_Measurement_Plot_Window.Measurement_Plot_Reset_Request = true; } catch (Exception) { } }
        }

        private void RMS_Reset()
        {
            RMS_Values.Clear();
            RMS_DateTime_Values.Clear();
            if (RMS_Measurement_Plot_Enabled || RMS_Measurement_Plot_Window != null)
            { try { RMS_Measurement_Plot_Window.Measurement_Plot_Reset_Request = true; } catch (Exception) { } }
        }

        private void Min_Reset()
        {
            Min_Values.Clear();
            Min_DateTime_Values.Clear();
            if (Min_Measurement_Plot_Enabled || Min_Measurement_Plot_Window != null)
            { try { Min_Measurement_Plot_Window.Measurement_Plot_Reset_Request = true; } catch (Exception) { } }
        }

        private void Max_Reset()
        {
            Max_Values.Clear();
            Max_DateTime_Values.Clear();
            if (Max_Measurement_Plot_Enabled || Max_Measurement_Plot_Window != null)
            { try { Max_Measurement_Plot_Window.Measurement_Plot_Reset_Request = true; } catch (Exception) { } }
        }

        private void Stdev_Reset()
        {
            Stdev_Values.Clear();
            Stdev_DateTime_Values.Clear();
            if (Stdev_Measurement_Plot_Enabled || Stdev_Measurement_Plot_Window != null)
            { try { Stdev_Measurement_Plot_Window.Measurement_Plot_Reset_Request = true; } catch (Exception) { } }
        }
    }
}
