using MahApps.Metro.Controls;
using System;
using System.IO;
using System.Reflection;

namespace NX_StarWave.VISA_GPIB_Communication
{
    public partial class VISA_GPIB_Select_Window : MetroWindow
    {
        private void Load_VISA_Config()
        {
            try
            {
                string Software_Location = System.IO.Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + @"\" + "NX_StarWave_VISA_Config.txt";
                using (var readFile = new StreamReader(Software_Location))
                {
                    string VISA_Config = readFile.ReadLine().Trim();
                    string[] VISA_Config_Parts = VISA_Config.Split(',');

                    VISA_GPIB_Port.Text = VISA_Config_Parts[0];
                    if (VISA_Config_Parts[1] == "0")
                    {
                        VISA_Access_Lock.SelectedIndex = 0;
                    }
                    else if (VISA_Config_Parts[1] == "1")
                    {
                        VISA_Access_Lock.SelectedIndex = 1;
                    }
                    else
                    {
                        VISA_Access_Lock.SelectedIndex = 0;
                    }

                    bool isValid_TimeoutValue = int.TryParse(VISA_Config_Parts[2], out int Timeout_Value);

                    if (isValid_TimeoutValue)
                    {
                        VISA_Timeout_Value_TextBox.Text = Timeout_Value.ToString();
                    }
                    else
                    {
                        VISA_Timeout_Value_TextBox.Text = "10";
                    }

                    if (VISA_Config_Parts[3].ToUpper() == "TRUE")
                    {
                        VISA_GPIB_Waveform_Capture_Method.IsOn = true;
                    }
                    else
                    {
                        VISA_GPIB_Waveform_Capture_Method.IsOn = false;
                    }

                    insert_Log("VISA GPIB Settings loaded.", 0);
                }
            }
            catch (Exception Ex)
            {
                insert_Log(Ex.Message, 1);
                insert_Log("Loading VISA GPIB Config file failed.", 1);
            }
        }
    }
}
