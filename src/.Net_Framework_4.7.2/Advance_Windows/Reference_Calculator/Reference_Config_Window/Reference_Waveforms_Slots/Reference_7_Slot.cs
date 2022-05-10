using MahApps.Metro.Controls;
using Microsoft.Win32;
using Newtonsoft.Json;
using NX_StarWave.Waveform_Model_Classes;
using System;
using System.IO;
using System.Windows;

namespace Reference_Calculator
{
    public partial class Reference_Config_Panel : MetroWindow
    {
        private double[] Reference_7_X_Values;
        private double[] Reference_7_Y_Values;
        private string Reference_7_Waveform_Color = "";

        private void Reference_7_Browse_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                OpenFileDialog File_Dialog = new OpenFileDialog
                {
                    FileName = "",
                    Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*"
                };
                if (File_Dialog.ShowDialog() == true)
                {
                    string Reference_String = File.ReadAllText(File_Dialog.FileName);
                    Reference_Waveform Reference_Waveform_Data = JsonConvert.DeserializeObject<Reference_Waveform>(Reference_String);
                    Set_Reference_7_Waveform_Data(Reference_Waveform_Data);
                }
            }
            catch (Exception Ex)
            {
                insert_Log(Ex.Message, 1);
            }
        }

        private void Reference_7_Paste_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string Reference_Data = Clipboard.GetText();
                Reference_Waveform Reference_Waveform_Data = JsonConvert.DeserializeObject<Reference_Waveform>(Reference_Data);
                Set_Reference_7_Waveform_Data(Reference_Waveform_Data);
            }
            catch (Exception Ex)
            {
                insert_Log(Ex.Message, 1);
            }
        }

        private void Set_Reference_7_Waveform_Data(Reference_Waveform Reference_Waveform_Data)
        {
            Reference_7_X_Values = Functions.Linspace(Reference_Waveform_Data.Start_Time, Reference_Waveform_Data.Stop_Time, Reference_Waveform_Data.Data_Points);
            Reference_7_Y_Values = Reference_Waveform_Data.Waveform_Y_Data;
            Reference_7_Data_Points = Reference_Waveform_Data.Data_Points;
            Reference_7_Total_Time = Reference_Waveform_Data.Total_Time;
            Reference_7_Start_Time = Reference_Waveform_Data.Start_Time;
            Reference_7_Stop_Time = Reference_Waveform_Data.Stop_Time;
            Reference_7_Channel_Info = Reference_Waveform_Data.Channel_Info;
            Reference_7_Waveform_Color = Reference_Waveform_Data.Waveform_Color;
            Reference_7_Valid = true;
            Reference_7_Status = Reference_Slot_Status_Valid;
            Plot_Reference_7_Waveform();
        }

        private void Reference_7_Copy_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (Reference_7_Valid == true)
                {
                    Reference_Waveform Reference_Waveform = new Reference_Waveform(Reference_7_Y_Values, (int)Reference_7_Data_Points, Reference_7_Total_Time, Reference_7_Start_Time, Reference_7_Stop_Time, Reference_7_Channel_Info, Reference_7_Waveform_Color);
                    string output = JsonConvert.SerializeObject(Reference_Waveform);
                    Clipboard.SetText(output);
                }
                else
                {
                    insert_Log("Reference 7 Waveform is invalid.", 2);
                }
            }
            catch (Exception Ex)
            {
                insert_Log(Ex.Message, 1);
            }
        }

        private void Reference_7_Show_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (Reference_7_Valid == true)
                {
                    Initialize_Data_Anytime_Waveform_Window(Reference_7_Channel_Info, new string[] { "", Reference_7_Waveform_Color, "Voltage (V)", "V", "Reference Waveform: X1" }, Reference_7_X_Values, Reference_7_Y_Values, Reference_7_Total_Time, Reference_7_Start_Time, Reference_7_Stop_Time, Reference_7_Data_Points);

                }
                else
                {
                    insert_Log("Reference 7 Waveform is invalid.", 2);
                }
            }
            catch (Exception Ex)
            {
                insert_Log(Ex.Message, 1);
            }
        }
    }
}
