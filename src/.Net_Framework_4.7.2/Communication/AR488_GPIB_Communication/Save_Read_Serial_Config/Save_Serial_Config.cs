using MahApps.Metro.Controls;
using System;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Windows;

namespace NX_StarWave.Serial_Communication
{
    public partial class COM_Select_Window : MetroWindow
    {
        private void COM_Config_Save_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string COM_Port_Number = COM_Port.Text.ToUpper().Trim();
                string BaudRate = COM_Bits.SelectedItem.ToString().Split(new string[] { ": " }, StringSplitOptions.None).Last();
                string DataBits = COM_DataBits.SelectedItem.ToString().Split(new string[] { ": " }, StringSplitOptions.None).Last();
                string Parity = COM_Parity.SelectedItem.ToString().Split(new string[] { ": " }, StringSplitOptions.None).Last();
                string StopBits = COM_Stop.SelectedItem.ToString().Split(new string[] { ": " }, StringSplitOptions.None).Last();
                if (StopBits == "1.5")
                {
                    StopBits = "3";
                }

                string Flow = COM_Flow.SelectedItem.ToString().Split(new string[] { ": " }, StringSplitOptions.None).Last();
                int Write_Timeout = int.Parse(COM_write_timeout.Text.Trim());
                int Read_Timeout = int.Parse(COM_read_timeout.Text.Trim());
                string rts = COM_rtsEnable.SelectedItem.ToString().Split(new string[] { ": " }, StringSplitOptions.None).Last();
                string gpib_address = GPIB_Address.Text.Trim();
                string Software_Location = System.IO.Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + @"\" + "NX_StarWave_Serial_Config.txt";

                string File_string = COM_Port_Number + "," + BaudRate + "," + DataBits + "," + Parity.ToUpper() + "," + StopBits + "," + Flow.ToUpper() + "," + Write_Timeout + "," + Read_Timeout + "," + rts.ToUpper() + "," + gpib_address;
                File.WriteAllText(Software_Location, File_string);
                insert_Log("AR488 COM settings saved.", 0);
            }
            catch (Exception Ex)
            {
                insert_Log(Ex.Message, 1);
                insert_Log("Failed to save COM config, try again.", 1);
            }
        }
    }
}
