using MahApps.Metro.Controls;
using Microsoft.Win32;
using System;
using System.IO;
using System.Windows;

namespace Waveform_Player
{
    public partial class Waveform_Player_Window : MetroWindow
    {
        private void CH1_Waveform_Save_Click(object sender, RoutedEventArgs e)
        {
            Save_Channel_Data(1);
        }

        private void CH2_Waveform_Save_Click(object sender, RoutedEventArgs e)
        {
            Save_Channel_Data(2);
        }

        private void CH3_Waveform_Save_Click(object sender, RoutedEventArgs e)
        {
            Save_Channel_Data(3);
        }

        private void CH4_Waveform_Save_Click(object sender, RoutedEventArgs e)
        {
            Save_Channel_Data(4);
        }

        private void Save_Channel_Data(int Channel)
        {
            if (Is_Play_Mode_Running == false)
            {
                try
                {
                    switch (Channel)
                    {
                        case 1:
                            if (Selected_Waveform_Data.CH1_Valid)
                            {
                                double Total_Time = Selected_Waveform_Data.CH1.Total_Time;
                                double Start_Time = Selected_Waveform_Data.CH1.Start_Time;
                                double Stop_Time = Selected_Waveform_Data.CH1.Stop_Time;
                                int Data_Points = Selected_Waveform_Data.CH1.Data_Points;
                                string Channel_Info = Selected_Waveform_Data.CH1.Channel_Info;
                                double[] X_Value = Selected_Waveform_Data.CH1.X_Data;
                                double[] Y_Values = Selected_Waveform_Data.CH1.Y_Data;
                                Save_to_File(Total_Time, Start_Time, Stop_Time, Data_Points, Channel_Info, X_Value, Y_Values, "CH1");
                            }
                            else
                            {
                                Insert_Log("Channel 1 data is empty. Could not save channel data.", 2);
                            }
                            break;
                        case 2:
                            if (Selected_Waveform_Data.CH2_Valid)
                            {
                                double Total_Time = Selected_Waveform_Data.CH2.Total_Time;
                                double Start_Time = Selected_Waveform_Data.CH2.Start_Time;
                                double Stop_Time = Selected_Waveform_Data.CH2.Stop_Time;
                                int Data_Points = Selected_Waveform_Data.CH2.Data_Points;
                                string Channel_Info = Selected_Waveform_Data.CH2.Channel_Info;
                                double[] X_Value = Selected_Waveform_Data.CH2.X_Data;
                                double[] Y_Values = Selected_Waveform_Data.CH2.Y_Data;
                                Save_to_File(Total_Time, Start_Time, Stop_Time, Data_Points, Channel_Info, X_Value, Y_Values, "CH2");
                            }
                            else
                            {
                                Insert_Log("Channel 2 data is empty. Could not save channel data.", 2);
                            }
                            break;
                        case 3:
                            if (Selected_Waveform_Data.CH3_Valid)
                            {
                                double Total_Time = Selected_Waveform_Data.CH3.Total_Time;
                                double Start_Time = Selected_Waveform_Data.CH3.Start_Time;
                                double Stop_Time = Selected_Waveform_Data.CH3.Stop_Time;
                                int Data_Points = Selected_Waveform_Data.CH3.Data_Points;
                                string Channel_Info = Selected_Waveform_Data.CH3.Channel_Info;
                                double[] X_Value = Selected_Waveform_Data.CH3.X_Data;
                                double[] Y_Values = Selected_Waveform_Data.CH3.Y_Data;
                                Save_to_File(Total_Time, Start_Time, Stop_Time, Data_Points, Channel_Info, X_Value, Y_Values, "CH3");
                            }
                            else
                            {
                                Insert_Log("Channel 3 data is empty. Could not save channel data.", 2);
                            }
                            break;
                        case 4:
                            if (Selected_Waveform_Data.CH4_Valid)
                            {
                                double Total_Time = Selected_Waveform_Data.CH4.Total_Time;
                                double Start_Time = Selected_Waveform_Data.CH4.Start_Time;
                                double Stop_Time = Selected_Waveform_Data.CH4.Stop_Time;
                                int Data_Points = Selected_Waveform_Data.CH4.Data_Points;
                                string Channel_Info = Selected_Waveform_Data.CH4.Channel_Info;
                                double[] X_Value = Selected_Waveform_Data.CH4.X_Data;
                                double[] Y_Values = Selected_Waveform_Data.CH4.Y_Data;
                                Save_to_File(Total_Time, Start_Time, Stop_Time, Data_Points, Channel_Info, X_Value, Y_Values, "CH4");
                            }
                            else
                            {
                                Insert_Log("Channel 4 data is empty. Could not save channel data.", 2);
                            }
                            break;
                        default:
                            Insert_Log("No Channel selected. No data copied.", 2);
                            break;
                    }
                }
                catch (Exception Ex)
                {
                    Insert_Log(Ex.Message, 1);
                }
            }
            else
            {
                Insert_Log("Cannot save channel data when play mode is active.", 2);
            }
        }

        private void Save_to_File(double Total_Time, double Start_Time, double Stop_Time, int Data_Points, string Channel_Info, double[] X_Value, double[] Y_Values, string CH_Name = "")
        {
            try
            {

                SaveFileDialog Save_Data_Text_Window = new SaveFileDialog
                {
                    FileName = CH_Name + "_Waveform_Data" + "_" + DateTime.Now.ToString("yyyy-MM-dd h-mm-ss tt") + ".txt",
                    Filter = "Normal text Files (*.txt)|*.txt;*.txt" +
                      "|All files (*.*)|*.*"
                };

                if (Save_Data_Text_Window.ShowDialog() is true)
                {
                    using (TextWriter datatotxt = new StreamWriter(Save_Data_Text_Window.FileName, false))
                    {
                        datatotxt.WriteLine(Total_Time + "," + Start_Time + "," + Stop_Time + "," + Data_Points + "," + Channel_Info);
                        for (int i = 0; i < Data_Points; i++)
                        {
                            datatotxt.WriteLine(X_Value[i] + "," + Y_Values[i]);
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
    }
}
