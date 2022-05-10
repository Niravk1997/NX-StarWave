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
        private void Paste_Reference_Waveform_Click(object sender, RoutedEventArgs e)
        {
            Paste_Reference_Waveform();
        }

        private void Paste_Reference_Waveform()
        {
            try
            {
                string Reference_Data = Clipboard.GetText();
                Reference_Waveform Reference_Waveform_Data = JsonConvert.DeserializeObject<Reference_Waveform>(Reference_Data);
                double[] X_Values = Functions.Linspace(Reference_Waveform_Data.Start_Time, Reference_Waveform_Data.Stop_Time, Reference_Waveform_Data.Data_Points);

                Checked_ListBox_Plottable Waveform = new Checked_ListBox_Plottable(Reference_Waveform_Data.Channel_Info, true,
                    Graph.Plot.AddSignalXY(X_Values, Reference_Waveform_Data.Waveform_Y_Data,
                    color: System.Drawing.ColorTranslator.FromHtml(Reference_Waveform_Data.Waveform_Color),
                    Reference_Waveform_Data.Channel_Info), Reference_Waveform_Data.Total_Time,
                    Reference_Waveform_Data.Start_Time, Reference_Waveform_Data.Stop_Time, Reference_Waveform_Data.Data_Points,
                    Reference_Waveform_Data.Waveform_Color, Functions.Linspace(Reference_Waveform_Data.Start_Time,
                    Reference_Waveform_Data.Stop_Time, Reference_Waveform_Data.Data_Points),
                    Reference_Waveform_Data.Waveform_Y_Data);

                Checked_ListBox_Plottable_Table.Add(Waveform);
                Graph.Plot.AxisAuto();
                Graph.Refresh();
            }
            catch (Exception Ex)
            {
                Insert_Log(Ex.Message, 1);
            }
        }

        private void Load_Reference_Waveform_Click(object sender, RoutedEventArgs e)
        {
            Load_Reference_Waveform();
        }

        private void Load_Reference_Waveform()
        {
            try
            {
                var Open_Data_Text_Window = new OpenFileDialog
                {
                    InitialDirectory = NX_StarWave.Communication_Selected.folder_Directory,
                    FileName = "",
                    Multiselect = true,
                    Filter = "Text Files (*.txt)|*.txt;*.txt" +
                      "|All files (*.*)|*.*"
                };

                if (Open_Data_Text_Window.ShowDialog() is true)
                {
                    foreach (String file in Open_Data_Text_Window.FileNames)
                    {
                        try
                        {
                            Read_Reference_Waveform_Data_TEXT_File(file);
                        }
                        catch (Exception Ex)
                        {
                            Insert_Log(Ex.Message, 1);
                        }
                    }
                }
            }
            catch (Exception Ex)
            {
                Insert_Log(Ex.Message, 1);
            }
        }

        private void Read_Reference_Waveform_Data_TEXT_File(string File_Path)
        {
            using (TextReader Reference_Data = new StreamReader(File_Path))
            {
                Reference_Waveform Reference_Waveform_Data = JsonConvert.DeserializeObject<Reference_Waveform>(Reference_Data.ReadToEnd());
                double[] X_Values = Functions.Linspace(Reference_Waveform_Data.Start_Time, Reference_Waveform_Data.Stop_Time, Reference_Waveform_Data.Data_Points);

                Checked_ListBox_Plottable Waveform = new Checked_ListBox_Plottable(Reference_Waveform_Data.Channel_Info, true,
                    Graph.Plot.AddSignalXY(X_Values, Reference_Waveform_Data.Waveform_Y_Data,
                    color: System.Drawing.ColorTranslator.FromHtml(Reference_Waveform_Data.Waveform_Color),
                    Reference_Waveform_Data.Channel_Info), Reference_Waveform_Data.Total_Time,
                    Reference_Waveform_Data.Start_Time, Reference_Waveform_Data.Stop_Time, Reference_Waveform_Data.Data_Points,
                    Reference_Waveform_Data.Waveform_Color, Functions.Linspace(Reference_Waveform_Data.Start_Time,
                    Reference_Waveform_Data.Stop_Time, Reference_Waveform_Data.Data_Points),
                    Reference_Waveform_Data.Waveform_Y_Data);

                Checked_ListBox_Plottable_Table.Add(Waveform);
                Graph.Plot.AxisAuto();
                Graph.Refresh();
            }
        }
    }
}
