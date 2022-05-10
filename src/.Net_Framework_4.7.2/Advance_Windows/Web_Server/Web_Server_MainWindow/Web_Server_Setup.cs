using MahApps.Metro.Controls;
using System;
using System.Windows;
using System.Windows.Media;
using WatsonWebserver;

namespace Waveform_Web_Server
{
    public partial class Web_Server_MainWindow : MetroWindow
    {
        private Server Waveform_Web_Server;
        private bool Is_Web_Server_Running = false;

        private void Start_Server_Click(object sender, RoutedEventArgs e)
        {
            if (Is_Web_Server_Running == false)
            {
                Is_Web_Server_Running = true;
                Read_Only_Input_TextFields = true;
                if (Is_IP_Address_Valid(IP_Address) & Is_TCP_Port_Valid(Port))
                {
                    Initialize_Waveform_Web_Server();
                }
                else
                {
                    insert_Log("IP Address may not be valid. Try again", 1);
                    insert_Log("Valid TCP port range: 1025 through 65535.", 1);
                    Is_Web_Server_Running = false;
                    Read_Only_Input_TextFields = false;
                }
            }
            else
            {
                Stop_Waveform_Web_Server();
            }
        }

        private void Initialize_Waveform_Web_Server()
        {
            try
            {
                Waveform_Web_Server = new Server(IP_Address, Port, false, DefaultRoute);
                Waveform_Web_Server.Start();
                Web_Server_Status_Brush = Brushes.LimeGreen;
                insert_Log("Waveform Web Server is running", 0);
                insert_Log("Try visiting: " + "http://" + IP_Address + ":" + Port + "/", 0);
                AutoSave_Web_Server_Config();
                Web_Server_Connect_Messages();
            }
            catch (Exception Ex)
            {
                Is_Web_Server_Running = false;
                Read_Only_Input_TextFields = false;
                insert_Log(Ex.Message, 1);
                insert_Log("Could not start the Web Server. Check config and try again.", 1);
            }
        }

        private void Stop_Waveform_Web_Server()
        {
            try
            {
                if (Waveform_Web_Server != null)
                {
                    Waveform_Web_Server.Stop();
                    Waveform_Web_Server.Dispose();
                    Waveform_Web_Server = null;
                    Web_Server_Status_Brush = Brushes.Red;
                    insert_Log("Waveform Web Server stopped running.", 0);
                    Is_Web_Server_Running = false;
                    Read_Only_Input_TextFields = false;
                }
                else
                {
                    Is_Web_Server_Running = false;
                    Read_Only_Input_TextFields = false;
                }
            }
            catch (Exception Ex)
            {
                Is_Web_Server_Running = false;
                Read_Only_Input_TextFields = false;
                Web_Server_Status_Brush = Brushes.Red;
                insert_Log(Ex.Message, 1);
                insert_Log("Could not stop the Waveform Web Server properly.", 1);
            }
        }

        private void Web_Server_Connect_Messages()
        {
            for (int i = 1; i <= 4; i++)
            {
                insert_Log("http://" + IP_Address + ":" + Port + "/" + $"CH{i}_Counter", 5);
                insert_Log("http://" + IP_Address + ":" + Port + "/" + $"CH{i}", 5);
            }
        }
    }
}
