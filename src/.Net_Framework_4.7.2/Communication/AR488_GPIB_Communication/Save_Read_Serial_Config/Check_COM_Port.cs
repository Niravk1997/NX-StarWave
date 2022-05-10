using MahApps.Metro.Controls;
using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Management;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace NX_StarWave.Serial_Communication
{
    public partial class COM_Select_Window : MetroWindow
    {
        //List of COM Ports
        private List<string> portList;

        private void Get_COM_List()
        {
            using (var searcher = new ManagementObjectSearcher("SELECT * FROM Win32_PnPEntity WHERE Caption like '%(COM%'"))
            {
                var portnames = SerialPort.GetPortNames();
                var ports = searcher.Get().Cast<ManagementBaseObject>().ToList().Select(p => p["Caption"].ToString());
                portList = portnames.Select(n => n + " - " + ports.FirstOrDefault(s => s.Contains('(' + n + ')'))).ToList();
                foreach (string p in portList)
                {
                    updateList(p);
                }
            }
        }

        private void updateList(string data)
        {
            ListBoxItem COM_itm = new ListBoxItem();
            COM_itm.Content = data;
            COM_List.Items.Add(COM_itm);
        }

        private void COM_Refresh_Click(object sender, RoutedEventArgs e)
        {
            COM_List.Items.Clear();
            Get_COM_List();
        }

        private void COM_List_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            try
            {
                string temp = COM_List.SelectedItem.ToString().Split(new string[] { ": " }, StringSplitOptions.None).Last();
                string COM = temp.Substring(0, temp.IndexOf(" -"));
                COM_Port.Text = COM;
                COM_Open_Check();

            }
            catch (Exception)
            {
                insert_Log("Select a Valid COM Port.", 2);
            }
        }

        private bool COM_Open_Check()
        {
            try
            {
                using (var sp = new SerialPort(COM_Port.Text, 9600, System.IO.Ports.Parity.None, 8, System.IO.Ports.StopBits.One))
                {
                    sp.WriteTimeout = 500;
                    sp.ReadTimeout = 500;
                    sp.Handshake = Handshake.None;
                    sp.RtsEnable = true;
                    sp.Open();
                    System.Threading.Thread.Sleep(100);
                    sp.Close();
                    insert_Log(COM_Port.Text + " is open and ready for communication.", 0);
                }
            }
            catch (Exception Ex)
            {
                COM_Port.Text = string.Empty;
                insert_Log(Ex.ToString(), 1);
                insert_Log(COM_Port.Text + " is closed. Probably being used by a software.", 1);
                insert_Log("Try another COM Port or check if COM is already used by another software.", 3);
                return false;
            }
            return true;
        }

        private bool Set_COM_Open_Check()
        {
            try
            {
                using (var serial = new SerialPort(COM_Port_Name, COM_BaudRate_Value, (Parity)COM_Parity_Value, COM_DataBits_Value, (StopBits)COM_StopBits_Value))
                {
                    serial.WriteTimeout = COM_WriteTimeout_Value;
                    serial.ReadTimeout = COM_ReadTimeout_Value;
                    serial.RtsEnable = COM_RtsEnable;
                    serial.Handshake = (Handshake)COM_Handshake_Value;
                    serial.Open();
                    System.Threading.Thread.Sleep(100);
                    serial.Close();
                    return true;
                }
            }
            catch (Exception)
            {
                COM_Port.Text = string.Empty;
                insert_Log(COM_Port.Text + " is closed. Probably being used by a software.", 1);
                insert_Log("Try another COM Port or check if com is already used by another software.", 3);
            }
            return true;
        }
    }
}
