using MahApps.Metro.Controls;
using Microsoft.Win32;
using System;
using System.IO;
using System.Windows;

namespace Histogram
{
    public partial class Histogram_Plotter : MetroWindow
    {
        private void Save_Data_Text_File_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                double[] X_Values = new double[X_Waveform_Values.Length];
                double[] Y_Values = new double[Y_Waveform_Values.Length];
                Array.Copy(X_Waveform_Values, X_Values, X_Waveform_Values.Length);
                Array.Copy(Y_Waveform_Values, Y_Values, X_Waveform_Values.Length);
                double Total_Time = this.Total_Time;
                double Start_Time = this.Start_Time;
                double Stop_Time = this.Stop_Time;
                int Data_Points = this.Data_Points;
                string Channel_Info = this.Channel_Info;
                var Save_Data_Text_Window = new SaveFileDialog
                {
                    FileName = "Waveform Data" + "_" + DateTime.Now.ToString("yyyy-MM-dd h-mm-ss tt") + ".txt",
                    Filter = "Normal text Files (*.txt)|*.txt;*.txt" +
                      "|All files (*.*)|*.*"
                };

                if (Save_Data_Text_Window.ShowDialog() is true)
                {
                    using (TextWriter datatotxt = new StreamWriter(Save_Data_Text_Window.FileName, false))
                    {
                        datatotxt.WriteLine(Total_Time + "," + Start_Time + "," + Stop_Time + "," + Data_Points + "," + Channel_Info);
                        for (int i = 0; i < X_Values.Length; i++)
                        {
                            datatotxt.WriteLine(X_Values[i] + "," + Y_Values[i]);
                        }
                    }
                }
            }
            catch (Exception Ex)
            {
                Insert_Log("Could not save Waveform Data to text file.", 1);
                Insert_Log(Ex.Message, 1);
            }
        }

        private void Save_Data_CSV_File_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                double[] X_Values = new double[X_Waveform_Values.Length];
                double[] Y_Values = new double[Y_Waveform_Values.Length];
                Array.Copy(X_Waveform_Values, X_Values, X_Waveform_Values.Length);
                Array.Copy(Y_Waveform_Values, Y_Values, X_Waveform_Values.Length);
                double Total_Time = this.Total_Time;
                double Start_Time = this.Start_Time;
                double Stop_Time = this.Stop_Time;
                int Data_Points = this.Data_Points;
                string Channel_Info = this.Channel_Info;
                var Save_Data_Text_Window = new SaveFileDialog
                {
                    FileName = "Waveform Data" + "_" + DateTime.Now.ToString("yyyy-MM-dd h-mm-ss tt") + ".csv",
                    Filter = "CSV Files (*.csv)|*.csv;*.csv" +
                      "|All files (*.*)|*.*"
                };

                if (Save_Data_Text_Window.ShowDialog() is true)
                {
                    using (TextWriter datatotxt = new StreamWriter(Save_Data_Text_Window.FileName, false))
                    {
                        datatotxt.WriteLine(Total_Time + "," + Start_Time + "," + Stop_Time + "," + Data_Points + "," + Channel_Info);
                        for (int i = 0; i < X_Values.Length; i++)
                        {
                            datatotxt.WriteLine(X_Values[i] + "," + Y_Values[i]);
                        }
                    }
                }
            }
            catch (Exception Ex)
            {
                Insert_Log("Could not save Waveform Data to csv file.", 1);
                Insert_Log(Ex.Message, 1);
            }
        }

        private void Save_Graph_Image_Click(object sender, RoutedEventArgs e)
        {
            Save_Graph_to_Image();
        }

        private void Exit_Graph_Window_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
