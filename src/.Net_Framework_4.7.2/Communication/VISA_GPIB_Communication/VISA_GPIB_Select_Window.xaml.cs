using MahApps.Metro.Controls;
using System;
using System.Linq;
using System.Windows;

namespace NX_StarWave.VISA_GPIB_Communication
{

    public partial class VISA_GPIB_Select_Window : MetroWindow
    {
        private string Company_Name = "Unknown";
        private string Oscilloscope_Model = "Unknown";
        private string Firmware_Version = "Unknown";

        public VISA_GPIB_Select_Window()
        {
            InitializeComponent();
            getSoftwarePath();
            insert_Log("Make sure VISA GPIB Address is correct.", 5);
            insert_Log("Choose the correct VISA GPIB Device from the list.", 5);
            insert_Log("Click the Connect button when you are ready.", 5);
            GetVisaInfo();
            Get_VISA_Devices_List();
            Load_VISA_Config();
        }

        private void Verify_Oscilloscope_Click(object sender, RoutedEventArgs e)
        {
            (bool isGPIB_Address_Valid, string Device_Info) = GPIB_Query("*IDN?");
            if (isGPIB_Address_Valid)
            {
                if (Device_Info.Contains("TEKTRONIX") == true)
                {
                    insert_Log(Device_Info, 0);
                    insert_Log("Verify Successful.", 0);
                }
                else
                {
                    insert_Log("Tektronix string not found in device id.", 2);
                }
            }
            else
            {
                insert_Log("Verify Failed.", 1);
            }
        }

        private void Connect_Click(object sender, RoutedEventArgs e)
        {
            if (folderCreation(folder_Directory) == 0)
            {
                (bool isGPIB_Address_Valid, string Device_Info) = GPIB_Query("*IDN?");
                if (isGPIB_Address_Valid)
                {
                    if (Device_Info.ToUpper().Contains("TEKTRONIX") == true)
                    {
                        try
                        {
                            string[] Tektronix_IDN_Info = Device_Info.Split(',');
                            Company_Name = Tektronix_IDN_Info[0];
                            Oscilloscope_Model = Tektronix_IDN_Info[1];
                            Firmware_Version = Tektronix_IDN_Info[3];
                        }
                        catch (Exception)
                        {
                            Company_Name = "Unknown";
                            Oscilloscope_Model = "Unknown";
                            Firmware_Version = "Unknown";
                        }

                        insert_Log(Device_Info, 0);
                        Data_Updater();
                        insert_Log("Please wait....connecting soon", 0);
                        this.Close();
                    }
                    else
                    {
                        insert_Log(Device_Info, 2);
                        insert_Log("Tektronix string not found in device id.", 2);
                    }
                }
                else
                {
                    insert_Log("Verify Failed.", 1);
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
            VISA_GPIB_Info.GPIB_Address = VISA_GPIB_Port.Text;
            VISA_GPIB_Info.GPIB_Lock = int.Parse(VISA_Access_Lock.SelectedItem.ToString().Split(new string[] { ": " }, StringSplitOptions.None).Last());
            Communication_Selected.folder_Directory = folder_Directory + @"\";
            Communication_Selected.Company_Name = Company_Name;
            Communication_Selected.Oscilloscope_Model = Oscilloscope_Model;
            Communication_Selected.Firmware_Version = Firmware_Version;
            Communication_Selected.is_Communication_Selected = true;
            Communication_Selected.is_VISA_GPIB_Communication_Selected = true;

            if (VISA_GPIB_Waveform_Capture_Method.IsOn)
            {
                Communication_Selected.VISA_GPIB_WFMPre_Curve_Method = true;
            }

            bool isValid_GPIB_Timeout = int.TryParse(VISA_Timeout_Value_TextBox.Text, out int GPIB_TimeoutValue);
            if (isValid_GPIB_Timeout)
            {
                if (GPIB_TimeoutValue > 0 & GPIB_TimeoutValue < 50)
                {
                    VISA_GPIB_Info.GPIB_Timeout = (GPIB_TimeoutValue * 1000);
                }
                else
                {
                    VISA_GPIB_Info.GPIB_Timeout = 10000;
                }
            }
        }
    }
}
