using MahApps.Metro.Controls;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows;

namespace Statistics_Table
{
    public partial class Statistics_Table_Window : MetroWindow
    {
        private void Frequency_Measurement_Save_Click(object sender, RoutedEventArgs e)
        {
            Save_Measurements_to_Text_File("Frequency_Hz", Frequency_Values, Frequency_DateTime_Values);
        }

        private void Period_Measurement_Save_Click(object sender, RoutedEventArgs e)
        {
            Save_Measurements_to_Text_File("Period_s", Period_Values, Period_DateTime_Values);
        }

        private void PeakPeak_Measurement_Save_Click(object sender, RoutedEventArgs e)
        {
            Save_Measurements_to_Text_File("PeakPeak_" + YAxis_Units, PeakPeak_Values, PeakPeak_DateTime_Values);
        }

        private void Mean_Measurement_Save_Click(object sender, RoutedEventArgs e)
        {
            Save_Measurements_to_Text_File("Mean_" + YAxis_Units, Mean_Values, Mean_DateTime_Values);
        }

        private void RMS_Measurement_Save_Click(object sender, RoutedEventArgs e)
        {
            Save_Measurements_to_Text_File("RMS_" + YAxis_Units, RMS_Values, RMS_DateTime_Values);
        }

        private void Min_Measurement_Save_Click(object sender, RoutedEventArgs e)
        {
            Save_Measurements_to_Text_File("Min_" + YAxis_Units, Min_Values, Min_DateTime_Values);
        }

        private void Max_Measurement_Save_Click(object sender, RoutedEventArgs e)
        {
            Save_Measurements_to_Text_File("Max_" + YAxis_Units, Max_Values, Max_DateTime_Values);
        }

        private void Stdev_Measurement_Save_Click(object sender, RoutedEventArgs e)
        {
            Save_Measurements_to_Text_File("Stdev_" + YAxis_Units, Stdev_Values, Stdev_DateTime_Values);
        }

        private void Save_Measurements_to_Text_File(string Measurement_FileName, List<double> Measurement_Values, List<double> DateTime_Values)
        {
            try
            {
                int Measurement_Count = Measurement_Values.Count;
                int Date_Time_Count = DateTime_Values.Count;

                if (Measurement_Count > 0)
                {

                    var Save_Data_Text_Window = new SaveFileDialog
                    {
                        FileName = Measurement_FileName + "_Data" + "_" + DateTime.Now.ToString("yyyy-MM-dd h-mm-ss tt") + ".txt",
                        OverwritePrompt = false,
                        Filter = "Normal text Files (*.txt)|*.txt;*.txt" +
                          "|All files (*.*)|*.*"
                    };

                    if (Save_Data_Text_Window.ShowDialog() is true)
                    {
                        using (TextWriter datatotxt = new StreamWriter(Save_Data_Text_Window.FileName, false))
                        {
                            if (Measurement_Count >= Date_Time_Count)
                            {
                                for (int i = 0; i < Date_Time_Count; i++)
                                {
                                    datatotxt.WriteLine(DateTime.FromOADate(DateTime_Values[i]).ToString("yyyy-MM-dd h:mm:ss.fff tt") + "," + Measurement_Values[i]);
                                }
                            }
                            else
                            {
                                for (int i = 0; i <= Measurement_Count; i++)
                                {
                                    datatotxt.WriteLine(DateTime.FromOADate(DateTime_Values[i]).ToString("yyyy-MM-dd h:mm:ss.fff tt") + "," + Measurement_Values[i]);
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception)
            {

            }
        }
    }
}
