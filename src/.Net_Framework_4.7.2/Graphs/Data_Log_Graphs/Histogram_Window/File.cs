using MahApps.Metro.Controls;
using Microsoft.Win32;
using System;
using System.IO;
using System.Windows;

namespace Channel_DataLogger
{
    public partial class Histogram_Waveform : MetroWindow
    {
        private void Save_Data_Text_File_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var Save_Data_Text_Window = new SaveFileDialog
                {
                    FileName = "Histogram Plot Data_" + DateTime.Now.ToString("yyyy-MM-dd h-mm-ss tt") + ".txt",
                    Filter = "Normal text Files (*.txt)|*.txt;*.txt" +
                      "|All files (*.*)|*.*"
                };

                if (Save_Data_Text_Window.ShowDialog() is true)
                {
                    using (TextWriter datatotxt = new StreamWriter(Save_Data_Text_Window.FileName, false))
                    {
                        for (int i = 0; i < Measurement_Count; i++)
                        {
                            datatotxt.WriteLine(Measurement_Data[i]);
                        }
                    }
                }
            }
            catch (Exception)
            {

            }
        }

        private void Save_Data_CSV_File_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var Save_Data_Text_Window = new SaveFileDialog
                {
                    FileName = "Histogram Plot Data_" + DateTime.Now.ToString("yyyy-MM-dd h-mm-ss tt") + ".csv",
                    Filter = "CSV Files (*.csv)|*.csv;*.csv" +
                      "|All files (*.*)|*.*"
                };

                if (Save_Data_Text_Window.ShowDialog() is true)
                {
                    using (TextWriter datatotxt = new StreamWriter(Save_Data_Text_Window.FileName, false))
                    {
                        for (int i = 0; i < Measurement_Count; i++)
                        {
                            datatotxt.WriteLine(Measurement_Data[i]);
                        }
                    }
                }
            }
            catch (Exception)
            {

            }
        }

        private void Save_Graph_Image_Click(object sender, RoutedEventArgs e)
        {
            Save_Graph_to_Image();
        }

        private void Save_Graph_to_Image()
        {
            try
            {
                var Save_Image_Window = new SaveFileDialog
                {
                    FileName = "Histogram Plot_" + DateTime.Now.ToString("yyyy-MM-dd h-mm-ss tt") + ".png",
                    Filter = "PNG Files (*.png)|*.png;*.png" +
                      "|JPG Files (*.jpg, *.jpeg)|*.jpg;*.jpeg" +
                      "|BMP Files (*.bmp)|*.bmp;*.bmp" +
                      "|All files (*.*)|*.*"
                };

                if (Save_Image_Window.ShowDialog() is true)
                {
                    Graph.Plot.SaveFig(Save_Image_Window.FileName);
                }
            }
            catch (Exception)
            {

            }
        }

        private void Exit_Graph_Window_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
