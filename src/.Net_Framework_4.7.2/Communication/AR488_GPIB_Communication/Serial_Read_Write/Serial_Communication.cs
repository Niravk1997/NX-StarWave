using MahApps.Metro.Controls;
using System;
using System.IO.Ports;

namespace NX_StarWave.Serial_Communication
{
    public partial class COM_Select_Window : MetroWindow
    {
        private string Company_Name = "Unknown";
        private string Oscilloscope_Model = "Unknown";
        private string Firmware_Version = "Unknown";

        private (bool, string) Serial_Query_AR488(string command)
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
                    serial.WriteLine("++addr " + COM_GPIB_Address_Value);
                    serial.WriteLine(command);
                    string data = serial.ReadLine();
                    serial.Close();
                    return (true, data);
                }
            }
            catch (Exception)
            {
                insert_Log("Serial Query Failed, check COM settings or connection.", 1);
                return (false, "");
            }
        }

        private bool Serial_Write(string command)
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
                    serial.WriteLine(command);
                    serial.Close();
                    return true;
                }
            }
            catch (Exception)
            {
                insert_Log("Serial Write Failed, check COM settings or connection.", 1);
                return false;
            }
        }

        private (bool, string) Serial_Query_Tektronix(string command)
        {
            try
            {
                using (var serial = new SerialPort(COM_Port_Name, COM_BaudRate_Value, (Parity)COM_Parity_Value, COM_DataBits_Value, (StopBits)COM_StopBits_Value))
                {
                    serial.WriteTimeout = COM_WriteTimeout_Value;
                    serial.ReadTimeout = COM_ReadTimeout_Value;
                    serial.RtsEnable = COM_RtsEnable;
                    serial.DtrEnable = true;
                    serial.Handshake = (Handshake)COM_Handshake_Value;
                    serial.Encoding = System.Text.Encoding.GetEncoding(28591);
                    serial.Open();
                    serial.WriteLine("++addr " + COM_GPIB_Address_Value);
                    serial.WriteLine("++eor 7");
                    serial.WriteLine("++eoi 1");
                    serial.WriteLine(command);
                    serial.WriteLine("++read");
                    string data = serial.ReadLine();
                    serial.Close();
                    return (true, data);
                }
            }
            catch (Exception)
            {
                insert_Log("Serial Query Failed, check COM settings or connection.", 1);
                return (false, "");
            }
        }

        private bool Connect_verify_Oscilloscope()
        {
            try
            {
                using (var serial = new SerialPort(COM_Port_Name, COM_BaudRate_Value, (Parity)COM_Parity_Value, COM_DataBits_Value, (StopBits)COM_StopBits_Value))
                {
                    serial.WriteTimeout = COM_WriteTimeout_Value;
                    serial.ReadTimeout = COM_ReadTimeout_Value;
                    serial.RtsEnable = COM_RtsEnable;
                    serial.DtrEnable = true;
                    serial.Handshake = (Handshake)COM_Handshake_Value;
                    serial.Encoding = System.Text.Encoding.GetEncoding(28591);
                    serial.Open();
                    serial.WriteLine("++addr " + COM_GPIB_Address_Value);
                    serial.WriteLine("++eor 7");
                    serial.WriteLine("++eoi 1");
                    serial.WriteLine("*IDN?");
                    serial.WriteLine("++read");
                    string data = serial.ReadLine();
                    serial.Close();
                    if (data.ToUpper().Contains("TEKTRONIX") == true)
                    {
                        try
                        {
                            string[] Tektronix_IDN_Info = data.Split(',');
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
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            catch (Exception)
            {
                insert_Log("Serial Query Failed, check COM settings or connection.", 1);
                return false;
            }
        }
    }
}
