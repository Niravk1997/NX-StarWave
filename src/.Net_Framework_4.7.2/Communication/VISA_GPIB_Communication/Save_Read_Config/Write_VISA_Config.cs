using MahApps.Metro.Controls;
using System;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Windows;

namespace NX_StarWave.VISA_GPIB_Communication
{
    public partial class VISA_GPIB_Select_Window : MetroWindow
    {
        private void VISA_Config_Save_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string GPIB_Address = VISA_GPIB_Port.Text;
                string Access_Lock = VISA_Access_Lock.SelectedItem.ToString().Split(new string[] { ": " }, StringSplitOptions.None).Last();
                string VISA_Timeout_Value = VISA_Timeout_Value_TextBox.Text;
                bool Waveform_Capture_Method_2 = VISA_GPIB_Waveform_Capture_Method.IsOn;

                string Software_Location = System.IO.Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + @"\" + "NX_StarWave_VISA_Config.txt";
                string File_string = GPIB_Address + "," + Access_Lock + "," + VISA_Timeout_Value + "," + Waveform_Capture_Method_2;
                File.WriteAllText(Software_Location, File_string);
                insert_Log("VISA GPIB settings saved.", 0);
            }
            catch (Exception Ex)
            {
                insert_Log(Ex.Message, 1);
                insert_Log("Failed to save VISA GPIB config, try again.", 1);
            }
        }
    }
}
