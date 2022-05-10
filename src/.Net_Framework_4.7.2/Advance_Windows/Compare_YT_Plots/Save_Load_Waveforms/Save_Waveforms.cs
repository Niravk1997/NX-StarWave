using MahApps.Metro.Controls;
using Microsoft.Win32;
using Newtonsoft.Json;
using NX_StarWave.Waveform_Model_Classes;
using System;
using System.IO;
using System.Windows;

namespace Compare_YT
{
    public partial class Compare_YT_Plots : MetroWindow
    {
        private void Copy_Reference_Data_Clipboard_Click(object sender, RoutedEventArgs e)
        {
            Copy_Reference_Data_Clipboard();
        }

        private void Copy_Reference_Data_Clipboard()
        {
            try
            {
                if (Selected_Checked_ListBox_Plottable_Data != null)
                {
                    Reference_Waveform Reference_Waveform = new Reference_Waveform(Selected_Checked_ListBox_Plottable_Data.Y_Values, Selected_Checked_ListBox_Plottable_Data.Data_Points, Selected_Checked_ListBox_Plottable_Data.Total_Time, Selected_Checked_ListBox_Plottable_Data.Start_Time, Selected_Checked_ListBox_Plottable_Data.Stop_Time, Selected_Checked_ListBox_Plottable_Data.Name, Selected_Checked_ListBox_Plottable_Data.Waveform_Color);
                    string output = JsonConvert.SerializeObject(Reference_Waveform);
                    Clipboard.SetText(output);
                }
            }
            catch (Exception)
            {

            }
        }

        private void Save_Reference_Data_File_Click(object sender, RoutedEventArgs e)
        {
            Save_Reference_Data_File();
        }

        private void Save_Reference_Data_File()
        {
            try
            {
                if (Selected_Checked_ListBox_Plottable_Data != null)
                {
                    Reference_Waveform Reference_Waveform = new Reference_Waveform(Selected_Checked_ListBox_Plottable_Data.Y_Values, Selected_Checked_ListBox_Plottable_Data.Data_Points, Selected_Checked_ListBox_Plottable_Data.Total_Time, Selected_Checked_ListBox_Plottable_Data.Start_Time, Selected_Checked_ListBox_Plottable_Data.Stop_Time, Selected_Checked_ListBox_Plottable_Data.Name, Selected_Checked_ListBox_Plottable_Data.Waveform_Color);
                    string output = JsonConvert.SerializeObject(Reference_Waveform);

                    var Save_Data_Text_Window = new SaveFileDialog
                    {
                        FileName = "Reference Waveform" + "_" + DateTime.Now.ToString("yyyy-MM-dd h-mm-ss tt") + ".txt",
                        Filter = "Normal text Files (*.txt)|*.txt;*.txt" +
                          "|All files (*.*)|*.*"
                    };

                    if (Save_Data_Text_Window.ShowDialog() is true)
                    {
                        using (TextWriter datatotxt = new StreamWriter(Save_Data_Text_Window.FileName, false))
                        {
                            datatotxt.WriteLine(output);
                        }
                    }
                }
            }
            catch (Exception) { }
        }
    }
}
