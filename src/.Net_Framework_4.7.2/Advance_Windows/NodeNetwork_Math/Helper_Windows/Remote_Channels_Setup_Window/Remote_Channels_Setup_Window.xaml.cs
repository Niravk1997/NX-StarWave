using MahApps.Metro.Controls;
using NodeNetwork_Math;
using System;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows;

namespace Remote_Channels_Setup_Window_Config
{
    public partial class Remote_Channels_Setup_Window : MetroWindow
    {
        private NodeNetwork_Window NodeNetwork_MainWindow { get; set; }

        private bool is_Remote_Channels_Config_Saving_in_Progress = false;
        // Used to seperate the inot in the NX_StarWave_Remote_Channels.config file.
        private char Split = '@';

        public Remote_Channels_Setup_Window(NodeNetwork_Window NodeNetwork_MainWindow)
        {
            InitializeComponent();
            this.NodeNetwork_MainWindow = NodeNetwork_MainWindow;
        }

        private void Remote_Channel_Connection_Test_Button_Click(object sender, RoutedEventArgs e)
        {
            FrameworkElement Control = e.Source as FrameworkElement;
            if (Control != null)
            {
                switch (Control.Name)
                {
                    case "RC5_Test_Button":
                        Remote_Channel_Connection_Test(NodeNetwork_MainWindow.Remote_CH_5_GetCounter_URL, NodeNetwork_MainWindow.Remote_CH_5_GetWaveform_URL);
                        break;
                    case "RC6_Test_Button":
                        Remote_Channel_Connection_Test(NodeNetwork_MainWindow.Remote_CH_6_GetCounter_URL, NodeNetwork_MainWindow.Remote_CH_6_GetWaveform_URL);
                        break;
                    case "RC7_Test_Button":
                        Remote_Channel_Connection_Test(NodeNetwork_MainWindow.Remote_CH_7_GetCounter_URL, NodeNetwork_MainWindow.Remote_CH_7_GetWaveform_URL);
                        break;
                    case "RC8_Test_Button":
                        Remote_Channel_Connection_Test(NodeNetwork_MainWindow.Remote_CH_8_GetCounter_URL, NodeNetwork_MainWindow.Remote_CH_8_GetWaveform_URL);
                        break;
                    case "RC9_Test_Button":
                        Remote_Channel_Connection_Test(NodeNetwork_MainWindow.Remote_CH_9_GetCounter_URL, NodeNetwork_MainWindow.Remote_CH_9_GetWaveform_URL);
                        break;
                    case "RC10_Test_Button":
                        Remote_Channel_Connection_Test(NodeNetwork_MainWindow.Remote_CH_10_GetCounter_URL, NodeNetwork_MainWindow.Remote_CH_10_GetWaveform_URL);
                        break;
                    case "RC11_Test_Button":
                        Remote_Channel_Connection_Test(NodeNetwork_MainWindow.Remote_CH_11_GetCounter_URL, NodeNetwork_MainWindow.Remote_CH_11_GetWaveform_URL);
                        break;
                    case "RC12_Test_Button":
                        Remote_Channel_Connection_Test(NodeNetwork_MainWindow.Remote_CH_12_GetCounter_URL, NodeNetwork_MainWindow.Remote_CH_12_GetWaveform_URL);
                        break;
                }
            }
        }

        private void Remote_Channel_Connection_Test(string Counter_URL, string Waveform_URL)
        {
            Task Remote_CH_5_Task = Task.Run(async () =>
            {
                try
                {
                    using (HttpClient Remote_Channels_Client = new HttpClient())
                    {
                        string Counter_Data = await Remote_Channels_Client.GetStringAsync(Counter_URL);
                        Insert_Log(Counter_Data, 0);
                        string Waveform_Data = await Remote_Channels_Client.GetStringAsync(Waveform_URL);
                        Insert_Log(Waveform_Data, 0);
                    }
                }
                catch (Exception Ex) { Insert_Log(Ex.Message, 1); }

            });
        }

        private void Remote_Channels_Config_Save_Click(object sender, RoutedEventArgs e)
        {
            Remote_Channels_Config_Save();
        }

        private void Remote_Channels_Config_Save()
        {
            if (is_Remote_Channels_Config_Saving_in_Progress == false)
            {
                try
                {
                    is_Remote_Channels_Config_Saving_in_Progress = true;

                    using (TextWriter writetext = new StreamWriter(NX_StarWave.Communication_Selected.folder_Directory + NodeNetwork_MainWindow.Remote_Channels_FileName))
                    {
                        writetext.WriteLine("Remote Channels Acquire" + Split + NodeNetwork_MainWindow.Get_Remote_Channels_Data);
                        writetext.WriteLine(NodeNetwork_MainWindow.Remote_CH_5_Name + Split + NodeNetwork_MainWindow.Remote_CH_5_Enable + Split + NodeNetwork_MainWindow.Remote_CH_5_Color + Split + NodeNetwork_MainWindow.Remote_CH_5_GetCounter_URL + Split + NodeNetwork_MainWindow.Remote_CH_5_GetWaveform_URL);
                        writetext.WriteLine(NodeNetwork_MainWindow.Remote_CH_6_Name + Split + NodeNetwork_MainWindow.Remote_CH_6_Enable + Split + NodeNetwork_MainWindow.Remote_CH_6_Color + Split + NodeNetwork_MainWindow.Remote_CH_6_GetCounter_URL + Split + NodeNetwork_MainWindow.Remote_CH_6_GetWaveform_URL);
                        writetext.WriteLine(NodeNetwork_MainWindow.Remote_CH_7_Name + Split + NodeNetwork_MainWindow.Remote_CH_7_Enable + Split + NodeNetwork_MainWindow.Remote_CH_7_Color + Split + NodeNetwork_MainWindow.Remote_CH_7_GetCounter_URL + Split + NodeNetwork_MainWindow.Remote_CH_7_GetWaveform_URL);
                        writetext.WriteLine(NodeNetwork_MainWindow.Remote_CH_8_Name + Split + NodeNetwork_MainWindow.Remote_CH_8_Enable + Split + NodeNetwork_MainWindow.Remote_CH_8_Color + Split + NodeNetwork_MainWindow.Remote_CH_8_GetCounter_URL + Split + NodeNetwork_MainWindow.Remote_CH_8_GetWaveform_URL);
                        writetext.WriteLine(NodeNetwork_MainWindow.Remote_CH_9_Name + Split + NodeNetwork_MainWindow.Remote_CH_9_Enable + Split + NodeNetwork_MainWindow.Remote_CH_9_Color + Split + NodeNetwork_MainWindow.Remote_CH_9_GetCounter_URL + Split + NodeNetwork_MainWindow.Remote_CH_9_GetWaveform_URL);
                        writetext.WriteLine(NodeNetwork_MainWindow.Remote_CH_10_Name + Split + NodeNetwork_MainWindow.Remote_CH_10_Enable + Split + NodeNetwork_MainWindow.Remote_CH_10_Color + Split + NodeNetwork_MainWindow.Remote_CH_10_GetCounter_URL + Split + NodeNetwork_MainWindow.Remote_CH_10_GetWaveform_URL);
                        writetext.WriteLine(NodeNetwork_MainWindow.Remote_CH_11_Name + Split + NodeNetwork_MainWindow.Remote_CH_11_Enable + Split + NodeNetwork_MainWindow.Remote_CH_11_Color + Split + NodeNetwork_MainWindow.Remote_CH_11_GetCounter_URL + Split + NodeNetwork_MainWindow.Remote_CH_11_GetWaveform_URL);
                        writetext.WriteLine(NodeNetwork_MainWindow.Remote_CH_12_Name + Split + NodeNetwork_MainWindow.Remote_CH_12_Enable + Split + NodeNetwork_MainWindow.Remote_CH_12_Color + Split + NodeNetwork_MainWindow.Remote_CH_12_GetCounter_URL + Split + NodeNetwork_MainWindow.Remote_CH_12_GetWaveform_URL);
                    }

                    Insert_Log("Saved Remote Channels Config to a file.", 0);
                    Insert_Log("Saved to " + NX_StarWave.Communication_Selected.folder_Directory + NodeNetwork_MainWindow.Remote_Channels_FileName, 0);
                }
                catch (Exception Ex)
                {
                    Insert_Log(Ex.Message, 2);
                    Insert_Log("Could not save Remote Channels Config to a file. Try again.", 2);
                }
            }
            else
            {
                Insert_Log("Saving Remote Channels config to a file in progress. Please wait.", 2);
            }
        }
    }
}
