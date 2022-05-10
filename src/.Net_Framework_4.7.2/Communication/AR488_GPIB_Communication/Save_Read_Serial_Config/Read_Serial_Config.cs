using MahApps.Metro.Controls;
using System;
using System.IO;
using System.Linq;
using System.Reflection;

namespace NX_StarWave.Serial_Communication
{
    public partial class COM_Select_Window : MetroWindow
    {
        //COM Port Information, updated by GUI
        private string COM_Port_Name = "";
        private int COM_BaudRate_Value = 115200;
        private int COM_Parity_Value = 0;
        private int COM_StopBits_Value = 1;
        private int COM_DataBits_Value = 8;
        private int COM_Handshake_Value = 0;
        private int COM_WriteTimeout_Value = 2000;
        private int COM_ReadTimeout_Value = 2000;
        private bool COM_RtsEnable = false;
        private int COM_GPIB_Address_Value = 22;

        private bool COM_Config_Updater()
        {
            COM_Port_Name = COM_Port.Text.ToUpper().Trim();

            string BaudRate = COM_Bits.SelectedItem.ToString().Split(new string[] { ": " }, StringSplitOptions.None).Last();
            COM_BaudRate_Value = Int32.Parse(BaudRate);

            string DataBits = COM_DataBits.SelectedItem.ToString().Split(new string[] { ": " }, StringSplitOptions.None).Last();
            COM_DataBits_Value = Int32.Parse(DataBits);

            bool isNum = int.TryParse(COM_write_timeout.Text.Trim(), out int Value);
            if (isNum == true & Value > 0)
            {
                COM_WriteTimeout_Value = Value;
                COM_write_timeout.Text = Value.ToString();
            }
            else
            {
                COM_write_timeout.Text = "2000";
                insert_Log("Write Timeout must be a positive integer.", 1);
                return false;
            }

            isNum = int.TryParse(COM_read_timeout.Text.Trim(), out Value);
            if (isNum == true & Value > 0)
            {
                COM_ReadTimeout_Value = Value;
                COM_read_timeout.Text = Value.ToString();
            }
            else
            {
                COM_read_timeout.Text = "2000";
                insert_Log("Read Timeout must be a positive integer.", 1);
                return false;
            }

            isNum = int.TryParse(GPIB_Address.Text.Trim(), out Value);
            if (isNum == true & Value > 0)
            {
                COM_GPIB_Address_Value = Value;
                GPIB_Address.Text = Value.ToString();
            }
            else
            {
                GPIB_Address.Text = "1";
                insert_Log("GPIB Address must be a positive integer.", 1);
                return false;
            }

            string Parity = COM_Parity.SelectedItem.ToString().Split(new string[] { ": " }, StringSplitOptions.None).Last();
            switch (Parity)
            {
                case "Even":
                    COM_Parity_Value = 2;
                    break;
                case "Odd":
                    COM_Parity_Value = 1;
                    break;
                case "None":
                    COM_Parity_Value = 0;
                    break;
                case "Mark":
                    COM_Parity_Value = 3;
                    break;
                case "Space":
                    COM_Parity_Value = 4;
                    break;
                default:
                    COM_Parity_Value = 0;
                    break;
            }

            string StopBits = COM_Stop.SelectedItem.ToString().Split(new string[] { ": " }, StringSplitOptions.None).Last();
            switch (StopBits)
            {
                case "1":
                    COM_StopBits_Value = 1;
                    break;
                case "1.5":
                    COM_StopBits_Value = 3;
                    break;
                case "2":
                    COM_StopBits_Value = 2;
                    break;
                default:
                    COM_StopBits_Value = 1;
                    break;
            }

            string Flow = COM_Flow.SelectedItem.ToString().Split(new string[] { ": " }, StringSplitOptions.None).Last();
            switch (Flow)
            {
                case "Xon/Xoff":
                    COM_Handshake_Value = 1;
                    break;
                case "Hardware":
                    COM_Handshake_Value = 2;
                    break;
                case "None":
                    COM_Handshake_Value = 0;
                    break;
                default:
                    COM_Handshake_Value = 1;
                    break;
            }

            string rts = COM_rtsEnable.SelectedItem.ToString().Split(new string[] { ": " }, StringSplitOptions.None).Last();
            switch (rts)
            {
                case "True":
                    COM_RtsEnable = true;
                    break;
                case "False":
                    COM_RtsEnable = false;
                    break;
                default:
                    COM_RtsEnable = true;
                    break;
            }

            return true;
        }

        private void Load_COM_Config()
        {
            try
            {
                string Software_Location = System.IO.Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + @"\" + "NX_StarWave_Serial_Config.txt";
                using (var readFile = new StreamReader(Software_Location))
                {
                    string COM_Config = readFile.ReadLine().Trim();
                    Process_Config_File_Data(COM_Config);
                    insert_Log("COM Settings loaded.", 0);
                }
            }
            catch (Exception Ex)
            {
                insert_Log(Ex.Message, 1);
                insert_Log("Loading COM Config file failed.", 1);
            }
        }

        private void Process_Config_File_Data(string COM_Config_Data)
        {
            string[] COM_Config_Parts = COM_Config_Data.Split(',');

            string COM_Port_Name = COM_Config_Parts[0].ToUpper();
            int Bits_per_Seconds = int.Parse(COM_Config_Parts[1]);
            int Data_bits = int.Parse(COM_Config_Parts[2]);
            string Parity = COM_Config_Parts[3].ToUpper();
            int Stop_bits = int.Parse(COM_Config_Parts[4]);
            string Flow_control = COM_Config_Parts[5].ToUpper();
            int Write_Timeout = int.Parse(COM_Config_Parts[6]);
            int Read_Timeout = int.Parse(COM_Config_Parts[7]);
            string Request_to_Send = COM_Config_Parts[8].ToUpper();
            int COM_GPIB_Address = int.Parse(COM_Config_Parts[9]);

            if (COM_Port_Name.All(char.IsLetterOrDigit) && COM_Port_Name.Contains("COM") && COM_Port_Name.Length <= 6)
            {
                COM_Port.Text = COM_Port_Name;
            }
            else
            {
                insert_Log("Serial Config File: COM Port Name is invalid.", 1);
                COM_Port.Text = "COM22";
            }

            if (new int[] { 300, 600, 1200, 2400, 4800, 9600, 14400, 19200, 38400, 57600, 115200, 128000 }.Contains(Bits_per_Seconds))
            {
                switch (Bits_per_Seconds)
                {
                    case 300:
                        COM_Bits.SelectedIndex = 0;
                        break;
                    case 600:
                        COM_Bits.SelectedIndex = 1;
                        break;
                    case 1200:
                        COM_Bits.SelectedIndex = 2;
                        break;
                    case 2400:
                        COM_Bits.SelectedIndex = 3;
                        break;
                    case 4800:
                        COM_Bits.SelectedIndex = 4;
                        break;
                    case 9600:
                        COM_Bits.SelectedIndex = 5;
                        break;
                    case 14400:
                        COM_Bits.SelectedIndex = 6;
                        break;
                    case 19200:
                        COM_Bits.SelectedIndex = 7;
                        break;
                    case 38400:
                        COM_Bits.SelectedIndex = 8;
                        break;
                    case 57600:
                        COM_Bits.SelectedIndex = 9;
                        break;
                    case 115200:
                        COM_Bits.SelectedIndex = 10;
                        break;
                    case 128000:
                        COM_Bits.SelectedIndex = 11;
                        break;
                    default:
                        COM_Bits.SelectedIndex = 5;
                        break;
                }
            }
            else
            {
                insert_Log("Serial Config File: Bits per Second is invalid.", 1);
                COM_Bits.SelectedIndex = 10;
            }

            if (new int[] { 4, 5, 6, 7, 8 }.Contains(Data_bits))
            {
                switch (Data_bits)
                {
                    case 4:
                        COM_DataBits.SelectedIndex = 0;
                        break;
                    case 5:
                        COM_DataBits.SelectedIndex = 1;
                        break;
                    case 6:
                        COM_DataBits.SelectedIndex = 2;
                        break;
                    case 7:
                        COM_DataBits.SelectedIndex = 3;
                        break;
                    case 8:
                        COM_DataBits.SelectedIndex = 4;
                        break;
                    default:
                        COM_DataBits.SelectedIndex = 4;
                        break;
                }
            }
            else
            {
                insert_Log("Serial Config File: Data Bits is invalid.", 1);
                COM_DataBits.SelectedIndex = 4;
            }

            if (new string[] { "EVEN", "ODD", "NONE", "MARK", "SPACE" }.Contains(Parity))
            {
                switch (Parity)
                {
                    case "EVEN":
                        COM_Parity.SelectedIndex = 0;
                        break;
                    case "ODD":
                        COM_Parity.SelectedIndex = 1;
                        break;
                    case "NONE":
                        COM_Parity.SelectedIndex = 2;
                        break;
                    case "MARK":
                        COM_Parity.SelectedIndex = 3;
                        break;
                    case "SPACE":
                        COM_Parity.SelectedIndex = 4;
                        break;
                    default:
                        COM_Parity.SelectedIndex = 2;
                        break;
                }
            }
            else
            {
                insert_Log("Serial Config File:  is invalid.", 1);
                COM_Parity.SelectedIndex = 2;
            }

            if (new int[] { 1, 2, 3 }.Contains(Stop_bits))
            {
                switch (Stop_bits)
                {
                    case 1:
                        COM_Stop.SelectedIndex = 0;
                        break;
                    case 2:
                        COM_Stop.SelectedIndex = 2;
                        break;
                    case 3:
                        COM_Stop.SelectedIndex = 1;
                        break;
                    default:
                        COM_Stop.SelectedIndex = 0;
                        break;
                }
            }
            else
            {
                insert_Log("Serial Config File: Stop bits is invalid.", 1);
                COM_Stop.SelectedIndex = 0;
            }

            if (new string[] { "XON/XOFF", "HARDWARE", "NONE" }.Contains(Flow_control))
            {
                switch (Flow_control)
                {
                    case "XON/XOFF":
                        COM_Flow.SelectedIndex = 0;
                        break;
                    case "HARDWARE":
                        COM_Flow.SelectedIndex = 1;
                        break;
                    case "NONE":
                        COM_Flow.SelectedIndex = 2;
                        break;
                    default:
                        COM_Flow.SelectedIndex = 2;
                        break;
                }
            }
            else
            {
                insert_Log("Serial Config File: Flow control is invalid.", 1);
                COM_Flow.SelectedIndex = 2;
            }

            if (Write_Timeout >= 2000)
            {
                COM_write_timeout.Text = Write_Timeout.ToString();
            }
            else
            {
                insert_Log("Serial Config File: Write Timeout is invalid, must be 4000 or greater.", 1);
            }

            if (Read_Timeout >= 2000)
            {
                COM_read_timeout.Text = Read_Timeout.ToString();
            }
            else
            {
                insert_Log("Serial Config File: Read Timeout is invalid, must be 9000 or greater.", 1);
            }

            if (new string[] { "TRUE", "FALSE" }.Contains(Request_to_Send))
            {
                switch (Request_to_Send)
                {
                    case "TRUE":
                        COM_rtsEnable.SelectedIndex = 0;
                        break;
                    case "FALSE":
                        COM_rtsEnable.SelectedIndex = 1;
                        break;
                    default:
                        COM_rtsEnable.SelectedIndex = 0;
                        break;
                }
            }
            else
            {
                insert_Log("Serial Config File: Request to Send is invalid.", 1);
                COM_rtsEnable.SelectedIndex = 0;
            }

            if (COM_GPIB_Address >= 0 && COM_GPIB_Address <= 30)
            {
                GPIB_Address.Text = COM_GPIB_Address.ToString();
            }
            else
            {
                insert_Log("Serial Config File: GPIB Address is invalid, must be between 0 and 30.", 1);
                GPIB_Address.Text = "22";
            }
        }
    }
}
