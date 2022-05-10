using MahApps.Metro.Controls;
using Microsoft.Win32;
using System;
using System.IO;
using System.Windows;

namespace Anytime_FFT
{
    public partial class FFT : MetroWindow
    {
        private void Save_Data_Text_File_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                double[] Frequency = new double[this.Frequency.Length];
                double[] Magnitude = new double[this.Magnitude.Length];
                double[] Phase = new double[this.Phase.Length];
                Array.Copy(this.Frequency, Frequency, this.Frequency.Length);
                Array.Copy(this.Magnitude, Magnitude, this.Magnitude.Length);
                Array.Copy(this.Phase, Phase, this.Phase.Length);
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
                        if (Show_Phase == false)
                        {
                            for (int i = 0; i < Frequency.Length; i++)
                            {
                                datatotxt.WriteLine(Frequency[i] + "," + Magnitude[i]);
                            }
                        }
                        else
                        {
                            for (int i = 0; i < Frequency.Length; i++)
                            {
                                datatotxt.WriteLine(Frequency[i] + "," + Magnitude[i] + "," + Phase[i]);
                            }
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
                double[] Frequency = new double[this.Frequency.Length];
                double[] Magnitude = new double[this.Magnitude.Length];
                double[] Phase = new double[this.Phase.Length];
                Array.Copy(this.Frequency, Frequency, this.Frequency.Length);
                Array.Copy(this.Magnitude, Magnitude, this.Magnitude.Length);
                Array.Copy(this.Phase, Phase, this.Phase.Length);
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
                        if (Show_Phase == false)
                        {
                            for (int i = 0; i < Frequency.Length; i++)
                            {
                                datatotxt.WriteLine(Frequency[i] + "," + Magnitude[i]);
                            }
                        }
                        else
                        {
                            for (int i = 0; i < Frequency.Length; i++)
                            {
                                datatotxt.WriteLine(Frequency[i] + "," + Magnitude[i] + "," + Phase[i]);
                            }
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
