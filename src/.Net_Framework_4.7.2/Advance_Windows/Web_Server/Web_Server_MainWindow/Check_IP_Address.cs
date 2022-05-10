using MahApps.Metro.Controls;
using System;
using System.Net;
using System.Net.Sockets;
using System.Security.Principal;
using System.Text.RegularExpressions;

namespace Waveform_Web_Server
{
    public partial class Web_Server_MainWindow : MetroWindow
    {
        private void Detect_Local_IPv4_Address()
        {
            Dispatcher.BeginInvoke((Action)(() =>
            {
                if (IsAdministrator())
                {
                    try
                    {
                        string localIP;
                        using (Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, 0))
                        {
                            socket.Connect("8.8.8.8", 65530);
                            IPEndPoint endPoint = socket.LocalEndPoint as IPEndPoint;
                            localIP = endPoint.Address.ToString();
                        }

                        if (!string.IsNullOrEmpty(localIP))
                        {
                            insert_Log("Your IPv4 Address: " + localIP, 0);
                            IP_Address = localIP;
                        }
                    }
                    catch (Exception Ex)
                    {
                        insert_Log(Ex.Message, 1);
                        insert_Log("Unable to get your local IPv4 Address.", 1);
                    }
                }
                else
                {
                    insert_Log("You must start NX-StarWave with run as administrator to use a proper IPv4 Address.", 2);
                    insert_Log("For now it will only respond to requests received from within the local machine.", 2);
                    IP_Address = "127.0.0.1";
                }
            }));
        }

        private bool Is_IP_Address_Valid(string IP_Address)
        {
            if (Regex.IsMatch(IP_Address, "^((25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\\.){3}(25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)$"))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private bool Is_TCP_Port_Valid(int Port)
        {
            if (Port > 1024 & Port <= 65535)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool IsAdministrator()
        {
            return (new WindowsPrincipal(WindowsIdentity.GetCurrent()))
                      .IsInRole(WindowsBuiltInRole.Administrator);
        }
    }
}
