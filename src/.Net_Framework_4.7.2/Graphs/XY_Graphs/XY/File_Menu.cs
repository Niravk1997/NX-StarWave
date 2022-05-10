using MahApps.Metro.Controls;
using Microsoft.Win32;
using System;
using System.IO;
using System.Windows;

namespace XY
{
    public partial class XY_Plotter : MetroWindow
    {
        private void Save_Data_Text_File_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                double[] CH1_X_Values_Local = new double[CH1_X_Waveform_Values.Length];
                double[] CH1_Y_Waveform_Values_Local = new double[CH1_Y_Waveform_Values.Length];

                double[] CH2_X_Values_Local = new double[CH2_X_Waveform_Values.Length];
                double[] CH2_Y_Waveform_Values_Local = new double[CH2_Y_Waveform_Values.Length];

                Array.Copy(CH1_X_Waveform_Values, CH1_X_Values_Local, CH1_X_Waveform_Values.Length);
                Array.Copy(CH1_Y_Waveform_Values, CH1_Y_Waveform_Values_Local, CH1_Y_Waveform_Values.Length);
                Array.Copy(CH2_X_Waveform_Values, CH2_X_Values_Local, CH2_X_Waveform_Values.Length);
                Array.Copy(CH2_Y_Waveform_Values, CH2_Y_Waveform_Values_Local, CH2_Y_Waveform_Values.Length);

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
                        for (int i = 0; i < CH1_X_Values_Local.Length; i++)
                        {
                            datatotxt.WriteLine(CH1_X_Values_Local[i] + "," + CH1_Y_Waveform_Values_Local[i] + "," + CH2_X_Values_Local[i] + "," + CH2_Y_Waveform_Values_Local[i]);
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
                double[] CH1_X_Values_Local = new double[CH1_X_Waveform_Values.Length];
                double[] CH1_Y_Waveform_Values_Local = new double[CH1_Y_Waveform_Values.Length];

                double[] CH2_X_Values_Local = new double[CH2_X_Waveform_Values.Length];
                double[] CH2_Y_Waveform_Values_Local = new double[CH2_Y_Waveform_Values.Length];

                Array.Copy(CH1_X_Waveform_Values, CH1_X_Values_Local, CH1_X_Waveform_Values.Length);
                Array.Copy(CH1_Y_Waveform_Values, CH1_Y_Waveform_Values_Local, CH1_Y_Waveform_Values.Length);
                Array.Copy(CH2_X_Waveform_Values, CH2_X_Values_Local, CH2_X_Waveform_Values.Length);
                Array.Copy(CH2_Y_Waveform_Values, CH2_Y_Waveform_Values_Local, CH2_Y_Waveform_Values.Length);

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
                        for (int i = 0; i < CH1_X_Values_Local.Length; i++)
                        {
                            datatotxt.WriteLine(CH1_X_Values_Local[i] + "," + CH1_Y_Waveform_Values_Local[i] + "," + CH2_X_Values_Local[i] + "," + CH2_Y_Waveform_Values_Local[i]);
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
