using MahApps.Metro.Controls;
using System.Windows;

namespace NX_StarWave.Serial_Communication
{
    public partial class COM_Select_Window : MetroWindow
    {
        public COM_Select_Window()
        {
            InitializeComponent();
            Get_COM_List();
            getSoftwarePath();
            insert_Log("Tested with AR488 Arduino Pro Micro Adapter.", 5);
            insert_Log("Connect Adapter only to one instrument.", 5);
            insert_Log("Adapter must have default settings.", 5);
            insert_Log("Try AR488 ++rst button to reset the Adapter.", 5);
            insert_Log("Make sure GPIB Address is correct.", 5);
            insert_Log("Choose the correct COM port from the list.", 5);
            insert_Log("Click the Connect button when you are ready.", 5);
            Load_COM_Config();
        }

        private void AR488_Version_Click(object sender, RoutedEventArgs e)
        {
            if (COM_Config_Updater() == true)
            {
                (bool check, string return_data) = Serial_Query_AR488("++ver");
                if (check == true)
                {
                    insert_Log(return_data, 0);
                }
            }
            else
            {
                insert_Log("COM Info is invalid. Correct any errors and try again.", 1);
            }
        }

        private void AR488_Reset_Click(object sender, RoutedEventArgs e)
        {
            if (COM_Config_Updater() == true)
            {
                if (Serial_Write("++rst") == true)
                {
                    insert_Log("Reset command was send successfully.", 0);
                }
            }
        }

        private void AR488_GPIB_Address_Click(object sender, RoutedEventArgs e)
        {
            if (COM_Config_Updater() == true)
            {
                (bool check, string return_data) = Serial_Query_AR488("++addr");
                if (check == true)
                {
                    insert_Log("Current GPIB Address: " + return_data, 0);
                }
            }
            else
            {
                insert_Log("COM Info is invalid. Correct any errors and try again.", 1);
            }
        }

        private void Verify_Oscilloscope_Click(object sender, RoutedEventArgs e)
        {
            if (COM_Config_Updater() == true)
            {
                (bool check, string return_data) = Serial_Query_Tektronix("*IDN?");
                if (check == true)
                {
                    insert_Log(return_data, 0);
                    if (return_data.Contains("TEKTRONIX") == true)
                    {
                        insert_Log("Verify Successful.", 0);
                    }
                    else
                    {
                        insert_Log("Verify Failed. Expected *IDN? query is TEKTRONIX TDS.", 1);
                        insert_Log("Try Again.", 1);
                    }
                }
            }
            else
            {
                insert_Log("COM Info is invalid. Correct any errors and try again.", 1);
            }
        }

        private void Connect_Click(object sender, RoutedEventArgs e)
        {
            if (folderCreation(folder_Directory) == 0)
            {
                if (COM_Config_Updater() == true)
                {
                    if (Set_COM_Open_Check() == true)
                    {
                        if (Connect_verify_Oscilloscope() == true)
                        {
                            Serial_Write("++read_tmo_ms 20000");
                            Data_Updater();
                            insert_Log("Please wait....connecting soon", 0);
                            this.Close();
                        }
                        else
                        {
                            insert_Log("Verify Failed. Try Again.", 1);
                        }
                    }
                    else
                    {
                        insert_Log("COM Port is not open. Check if COM Port is in use.", 1);
                        insert_Log("Connect Failed.", 1);
                    }
                }
                else
                {
                    insert_Log("COM Info is invalid. Correct any errors and try again.", 1);
                    insert_Log("Connect Failed.", 1);
                }
            }
            else
            {
                insert_Log("Log Data Directory cannot be created on the selected path.", 1);
                insert_Log("Choose another path by clicking the select button.", 1);
            }
        }

        private void Data_Updater()
        {
            AR488_GPIB_Info.COM_Port = COM_Port_Name;
            AR488_GPIB_Info.COM_BaudRate = COM_BaudRate_Value;
            AR488_GPIB_Info.COM_Parity = COM_Parity_Value;
            AR488_GPIB_Info.COM_StopBits = COM_StopBits_Value;
            AR488_GPIB_Info.COM_DataBits = COM_DataBits_Value;
            AR488_GPIB_Info.COM_Handshake = COM_Handshake_Value;
            AR488_GPIB_Info.COM_WriteTimeout = COM_WriteTimeout_Value;
            AR488_GPIB_Info.COM_ReadTimeout = COM_ReadTimeout_Value;
            AR488_GPIB_Info.COM_RtsEnable = COM_RtsEnable;
            AR488_GPIB_Info.GPIB_Address = COM_GPIB_Address_Value;
            Communication_Selected.folder_Directory = folder_Directory + @"\";
            Communication_Selected.Company_Name = Company_Name;
            Communication_Selected.Oscilloscope_Model = Oscilloscope_Model;
            Communication_Selected.Firmware_Version = Firmware_Version;
            Communication_Selected.is_Communication_Selected = true;
            Communication_Selected.is_AR488_Communication_Selected = true;
        }
    }
}
