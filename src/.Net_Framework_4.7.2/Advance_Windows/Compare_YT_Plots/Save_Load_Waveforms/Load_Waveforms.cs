using MahApps.Metro.Controls;
using Microsoft.Win32;
using System;
using System.IO;
using System.Windows;

namespace Compare_YT
{
    public partial class Compare_YT_Plots : MetroWindow
    {
        private void Load_Waveform_Click(object sender, RoutedEventArgs e)
        {
            Load_Waveform();
        }

        private void Load_Waveform()
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
                            Read_Waveform_Data_TEXT_File(file);
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

        private void Read_Waveform_Data_TEXT_File(string File_Path)
        {
            using (TextReader Waveform_Data = new StreamReader(File_Path))
            {

                string[] Waveform_Preamble = Waveform_Data.ReadLine().Split(',');
                double Total_Time = double.Parse(Waveform_Preamble[0]);
                double Start_Time = double.Parse(Waveform_Preamble[1]);
                double Stop_Time = double.Parse(Waveform_Preamble[2]);
                int Data_Points = int.Parse(Waveform_Preamble[3]);


                string Wavefrom_Name = "";
                if (Waveform_Preamble.Length > 4)
                {
                    Wavefrom_Name = Waveform_Preamble[4];
                }
                else
                {
                    Wavefrom_Name = "Unknown";
                }

                double[] X_Values = new double[Data_Points];
                double[] Y_Values = new double[Data_Points];

                for (int i = 0; i < Data_Points; i++)
                {
                    string[] Values = Waveform_Data.ReadLine().Split(',');
                    X_Values[i] = double.Parse(Values[0]);
                    Y_Values[i] = double.Parse(Values[1]);
                }

                string Color = Get_Random_Color();

                Checked_ListBox_Plottable Waveform = new Checked_ListBox_Plottable(Wavefrom_Name, true,
                    Graph.Plot.AddSignalXY(X_Values, Y_Values, color: System.Drawing.ColorTranslator.FromHtml(Color),
                    Wavefrom_Name), Total_Time, Start_Time, Stop_Time, Data_Points, Color, X_Values, Y_Values);

                Checked_ListBox_Plottable_Table.Add(Waveform);
                Graph.Plot.AxisAuto();
                Graph.Refresh();
            }
        }

        private string Get_Random_Color()
        {
            try
            {
                Random RGB_Value = new Random();
                int Value_Red = RGB_Value.Next(0, 255);
                int Value_Green = RGB_Value.Next(0, 255);
                int Value_Blue = RGB_Value.Next(0, 255);
                System.Windows.Media.Color Random_Color = System.Windows.Media.Color.FromArgb(255, (byte)(Value_Red), (byte)(Value_Green), (byte)(Value_Blue));
                return Random_Color.ToString();
            }
            catch (Exception Ex)
            {
                Insert_Log(Ex.Message, 1);
                return "#0072BD";
            }
        }
    }
}
