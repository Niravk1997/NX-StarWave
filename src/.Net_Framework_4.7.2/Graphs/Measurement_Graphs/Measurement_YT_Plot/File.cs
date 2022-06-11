using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using MahApps.Metro.Controls;
using Microsoft.Win32;

namespace Measurement_Plot
{
    public partial class Measurement_Plot_Window : MetroWindow
    {
        private void Save_Data_to_Text_File_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var Save_Data_Text_Window = new SaveFileDialog
                {
                    FileName = "Measurement Data_" + DateTime.Now.ToString("yyyy-MM-dd h-mm-ss tt") + ".txt",
                    Filter = "Normal text Files (*.txt)|*.txt;*.txt" +
                      "|All files (*.*)|*.*"
                };

                if (Save_Data_Text_Window.ShowDialog() is true)
                {
                    Save_Data_to_File(Save_Data_Text_Window.FileName);
                }
            }
            catch (Exception Ex)
            {
                Insert_Log("Could not save Graph Plot Data to text file.", 1);
                Insert_Log(Ex.Message, 1);
            }
        }

        private void Save_Data_to_CSV_File_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var Save_Data_Text_Window = new SaveFileDialog
                {
                    FileName = "Measurement Data_" + DateTime.Now.ToString("yyyy-MM-dd h-mm-ss tt") + ".csv",
                    Filter = "Normal text Files (*.txt)|*.txt;*.txt" +
                      "|All files (*.*)|*.*"
                };

                if (Save_Data_Text_Window.ShowDialog() is true)
                {
                    Save_Data_to_File(Save_Data_Text_Window.FileName);
                }
            }
            catch (Exception Ex)
            {
                Insert_Log("Could not save Graph Plot Data to csv file.", 1);
                Insert_Log(Ex.Message, 1);
            }
        }

        private void Save_Data_to_File(string FileName) 
        {
            using (TextWriter datatotxt = new StreamWriter(FileName, false))
            {
                for (int i = 0; i < Measurement_Data_Count; i++)
                {
                    datatotxt.WriteLine(Date_Time[i] + "," + Measurement_Data[i]);
                }
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
