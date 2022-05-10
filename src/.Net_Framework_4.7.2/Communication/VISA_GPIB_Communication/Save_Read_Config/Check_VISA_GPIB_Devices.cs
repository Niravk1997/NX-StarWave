using Ivi.Visa;
using MahApps.Metro.Controls;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace NX_StarWave.VISA_GPIB_Communication
{
    public partial class VISA_GPIB_Select_Window : MetroWindow
    {
        //List of VISA GPIB Devices
        private List<string> VISA_Devices;

        private void GetVisaInfo()
        {
            try
            {
                Version VisaNetSharedComponentsVersion = typeof(GlobalResourceManager).Assembly.GetName().Version;
                insert_Log("Visa.NET info: " + VisaNetSharedComponentsVersion, 0);

                FileVersionInfo VisaSharedComponentsInfo;
                VisaSharedComponentsInfo = FileVersionInfo.GetVersionInfo(System.IO.Path.Combine(Environment.SystemDirectory, "visaConfMgr.dll"));
                insert_Log("VISA Shared Components Version: " + VisaSharedComponentsInfo.ProductVersion, 0);
            }
            catch (Exception Ex)
            {
                insert_Log(Ex.Message, 1);
                insert_Log("Error related to VISA.NET.", 1);
            }
        }

        private void Get_VISA_Devices_List()
        {
            try
            {
                VISA_Devices = GlobalResourceManager.Find("(GPIB|USB)?*").ToList();
                foreach (string Device_Address in VISA_Devices)
                {
                    updateList(Device_Address);
                }
            }
            catch (Exception Ex)
            {
                insert_Log(Ex.Message, 1);
                insert_Log("Failed to get List of GPIB Devices.", 1);
            }
        }

        private void updateList(string Device_Address)
        {
            ListBoxItem VISA_Devices = new ListBoxItem();
            VISA_Devices.Content = Device_Address;
            VISA_GPIB_List.Items.Add(VISA_Devices);
        }

        private void VISA_Refresh_Click(object sender, RoutedEventArgs e)
        {
            VISA_GPIB_List.Items.Clear();
            Get_VISA_Devices_List();
        }

        private void VISA_Device_List_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            try
            {
                string GPIB_Address_Selected = VISA_GPIB_List.SelectedItem.ToString().Split(new string[] { ": " }, StringSplitOptions.None).Last();
                VISA_GPIB_Port.Text = GPIB_Address_Selected;
                if (Is_GPIB_Address_In_Use() == true)
                {
                    insert_Log("GPIB Address is open and ready for communication.", 0);
                }
                else
                {
                    insert_Log("GPIB Address is not open.", 1);
                }
            }
            catch (Exception)
            {
                insert_Log("Select a Valid VISA GPIB Device.", 2);
            }
        }

        private bool Is_GPIB_Address_In_Use()
        {
            try
            {
                using (IVisaSession Instrument = GlobalResourceManager.Open(VISA_GPIB_Port.Text, AccessModes.None, 2000))
                {
                    Instrument.Dispose();
                }
                return true;
            }
            catch (Exception Ex)
            {
                insert_Log(Ex.Message, 1);
                return false;
            }
        }
    }
}
