using MahApps.Metro.Controls;
using Microsoft.Win32;
using System;
using System.IO;
using System.Windows;

namespace Histogram_2_Input
{
    public partial class Histogram_2_Input_Window : MetroWindow
    {
        private (double Total_Time, double Start_Time, double Stop_Time, int Data_Points, string Channel_Info, double[] X_Values, double[] Y_Values) Input_1_Save_Data()
        {
            int Length = Input_1_X_Waveform_Values.Length;
            double[] X_Values = new double[Length];
            double[] Y_Values = new double[Length];
            Array.Copy(Input_1_X_Waveform_Values, X_Values, Length);
            Array.Copy(Input_1_Y_Waveform_Values, Y_Values, Length);
            double Total_Time = Input_1_Total_Time;
            double Start_Time = Input_1_Start_Time;
            double Stop_Time = Input_1_Stop_Time;
            int Data_Points = Input_1_Data_Points;
            string Channel_Info = Input_1_Channel_Info;
            return (Total_Time, Start_Time, Stop_Time, Data_Points, Channel_Info, X_Values, Y_Values);
        }

        private void Input_1_Save_Data_Text_File_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                (double Total_Time, double Start_Time, double Stop_Time, int Data_Points, string Channel_Info, double[] X_Values, double[] Y_Values) = Input_1_Save_Data();
                var Save_Data_Text_Window = new SaveFileDialog
                {
                    FileName = "Input 1 Data" + "_" + DateTime.Now.ToString("yyyy-MM-dd h-mm-ss tt") + ".txt",
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
                Insert_Log("Could not save Input 1 Data to text file.", 1);
                Insert_Log(Ex.Message, 1);
            }
        }

        private void Input_1_Save_Data_CSV_File_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                (double Total_Time, double Start_Time, double Stop_Time, int Data_Points, string Channel_Info, double[] X_Values, double[] Y_Values) = Input_1_Save_Data();
                var Save_Data_Text_Window = new SaveFileDialog
                {
                    FileName = "Input 1 Data" + "_" + DateTime.Now.ToString("yyyy-MM-dd h-mm-ss tt") + ".csv",
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
                Insert_Log("Could not save Input 1 Data to csv file.", 1);
                Insert_Log(Ex.Message, 1);
            }
        }

        private (double Total_Time, double Start_Time, double Stop_Time, int Data_Points, string Channel_Info, double[] X_Values, double[] Y_Values) Input_2_Save_Data()
        {
            int Length = Input_2_X_Waveform_Values.Length;
            double[] X_Values = new double[Length];
            double[] Y_Values = new double[Length];
            Array.Copy(Input_2_X_Waveform_Values, X_Values, Length);
            Array.Copy(Input_2_Y_Waveform_Values, Y_Values, Length);
            double Total_Time = Input_2_Total_Time;
            double Start_Time = Input_2_Start_Time;
            double Stop_Time = Input_2_Stop_Time;
            int Data_Points = Input_2_Data_Points;
            string Channel_Info = Input_2_Channel_Info;
            return (Total_Time, Start_Time, Stop_Time, Data_Points, Channel_Info, X_Values, Y_Values);
        }

        private void Input_2_Save_Data_Text_File_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                (double Total_Time, double Start_Time, double Stop_Time, int Data_Points, string Channel_Info, double[] X_Values, double[] Y_Values) = Input_2_Save_Data();
                var Save_Data_Text_Window = new SaveFileDialog
                {
                    FileName = "Input 2 Data" + "_" + DateTime.Now.ToString("yyyy-MM-dd h-mm-ss tt") + ".txt",
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
                Insert_Log("Could not save Input 2 Data to text file.", 1);
                Insert_Log(Ex.Message, 1);
            }
        }

        private void Input_2_Save_Data_CSV_File_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                (double Total_Time, double Start_Time, double Stop_Time, int Data_Points, string Channel_Info, double[] X_Values, double[] Y_Values) = Input_2_Save_Data();
                var Save_Data_Text_Window = new SaveFileDialog
                {
                    FileName = "Input 2 Data" + "_" + DateTime.Now.ToString("yyyy-MM-dd h-mm-ss tt") + ".csv",
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
                Insert_Log("Could not save Input 2 Data to csv file.", 1);
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
