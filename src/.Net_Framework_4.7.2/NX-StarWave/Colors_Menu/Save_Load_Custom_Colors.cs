using ControlzEx.Theming;
using MahApps.Metro.Controls;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows;

namespace NX_StarWave
{
    public partial class NX_StarWave_Window : MetroWindow
    {
        private string Custom_Wavefrom_Colors_FileName = "NX_StarWave_Custom_Colors.config";

        private bool AutoLoad_Selected_Waveform_Colors_isFile_Exists()
        {
            return File.Exists(NX_StarWave.Communication_Selected.folder_Directory + Custom_Wavefrom_Colors_FileName);
        }

        private void AutoLoad_Selected_Waveform_Colors_File()
        {
            Dispatcher.BeginInvoke((Action)(() =>
            {
                try
                {
                    if (AutoLoad_Selected_Waveform_Colors_isFile_Exists())
                    {
                        IEnumerable<string> Lines = File.ReadLines(NX_StarWave.Communication_Selected.folder_Directory + Custom_Wavefrom_Colors_FileName);

                        try
                        {
                            string[] Theme_Name = Lines.ElementAt(0).Split(',');
                            Apply_Custom_Theme_Settings(Theme_Name[1]);

                            string[] Channel_1_Color = Lines.ElementAt(1).Split(',');
                            string[] Channel_2_Color = Lines.ElementAt(2).Split(',');
                            string[] Channel_3_Color = Lines.ElementAt(3).Split(',');
                            string[] Channel_4_Color = Lines.ElementAt(4).Split(',');

                            Channel_1_Color_String = Channel_1_Color[1];
                            Channel_2_Color_String = Channel_2_Color[1];
                            Channel_3_Color_String = Channel_3_Color[1];
                            Channel_4_Color_String = Channel_4_Color[1];

                            string[] Math_YT_Window_1_Color = Lines.ElementAt(5).Split(',');
                            string[] Math_YT_Window_2_Color = Lines.ElementAt(6).Split(',');
                            string[] Math_YT_Window_3_Color = Lines.ElementAt(7).Split(',');
                            string[] Math_YT_Window_4_Color = Lines.ElementAt(8).Split(',');

                            Math_YT_Window_1_Color_String = Math_YT_Window_1_Color[1];
                            Math_YT_Window_2_Color_String = Math_YT_Window_2_Color[1];
                            Math_YT_Window_3_Color_String = Math_YT_Window_3_Color[1];
                            Math_YT_Window_4_Color_String = Math_YT_Window_4_Color[1];

                            string[] Math_FFT_Window_1_Color = Lines.ElementAt(9).Split(',');
                            string[] Math_FFT_Window_2_Color = Lines.ElementAt(10).Split(',');
                            string[] Math_FFT_Window_3_Color = Lines.ElementAt(11).Split(',');
                            string[] Math_FFT_Window_4_Color = Lines.ElementAt(12).Split(',');

                            Math_FFT_Window_1_Color_String = Math_FFT_Window_1_Color[1];
                            Math_FFT_Window_2_Color_String = Math_FFT_Window_2_Color[1];
                            Math_FFT_Window_3_Color_String = Math_FFT_Window_3_Color[1];
                            Math_FFT_Window_4_Color_String = Math_FFT_Window_4_Color[1];

                            insert_Log("Custom Waveform Colors and Theme settings loaded.", 0);
                        }
                        catch (Exception Ex)
                        {
                            insert_Log(Ex.Message, 1);
                            insert_Log("Failed to read the Custom Waveform Colors and Theme config file.", 1);
                        }

                    }
                }
                catch (Exception Ex)
                {
                    insert_Log(Ex.Message, 1);
                }
            }));
        }

        private void Apply_Custom_Theme_Settings(string Theme_Name)
        {
            try
            {
                ThemeManager.Current.ChangeTheme(Application.Current, Theme_Name);
            }
            catch (Exception)
            {

            }
        }

        private void Save_Selected_Waveform_Colors()
        {
            Dispatcher.BeginInvoke((Action)(() =>
            {
                try
                {
                    using (TextWriter writetext = new StreamWriter(NX_StarWave.Communication_Selected.folder_Directory + Custom_Wavefrom_Colors_FileName))
                    {
                        writetext.WriteLine("Theme," + ThemeManager.Current.DetectTheme().Name.ToString());
                        writetext.WriteLine("Channel_1_Color," + Channel_1_Color.ToString());
                        writetext.WriteLine("Channel_2_Color," + Channel_2_Color.ToString());
                        writetext.WriteLine("Channel_3_Color," + Channel_3_Color.ToString());
                        writetext.WriteLine("Channel_4_Color," + Channel_4_Color.ToString());

                        writetext.WriteLine("Math_YT_Window_1_Color," + Math_YT_Window_1_Color.ToString());
                        writetext.WriteLine("Math_YT_Window_2_Color," + Math_YT_Window_2_Color.ToString());
                        writetext.WriteLine("Math_YT_Window_3_Color," + Math_YT_Window_3_Color.ToString());
                        writetext.WriteLine("Math_YT_Window_4_Color," + Math_YT_Window_4_Color.ToString());

                        writetext.WriteLine("Math_FFT_Window_1_Color," + Math_FFT_Window_1_Color.ToString());
                        writetext.WriteLine("Math_FFT_Window_2_Color," + Math_FFT_Window_2_Color.ToString());
                        writetext.WriteLine("Math_FFT_Window_3_Color," + Math_FFT_Window_3_Color.ToString());
                        writetext.WriteLine("Math_FFT_Window_4_Color," + Math_FFT_Window_4_Color.ToString());
                    }

                    insert_Log("Saved Custom Waveform Colors and Theme settings to a config file. This file will automatically be loaded during startup.", 0);
                }
                catch (Exception Ex)
                {
                    insert_Log(Ex.Message, 1);
                }
            }));
        }
    }
}
