using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using MahApps.Metro.Controls;
using Oscilloscope_Channel_Node;
using Remote_Channels_Setup_Window_Config;

namespace NodeNetwork_Math
{
    public partial class NodeNetwork_Window : MetroWindow
    {
        public string Remote_Channels_FileName = "NX_StarWave_Remote_Channels.config";
        private char Remote_Channels_File_Split = '@';
        private Remote_Channels_Setup_Window Remote_Channels_Config_Window;
        private bool is_Remote_Channels_Config_Window_Open = false;

        private void Remote_Channels_Config_Window_Open_Click(object sender, RoutedEventArgs e)
        {
            if (Remote_Channels_Config_Window == null && is_Remote_Channels_Config_Window_Open == false)
            {
                is_Remote_Channels_Config_Window_Open = true;
                Remote_Channels_Config_Window = new Remote_Channels_Setup_Window(this);
                Remote_Channels_Config_Window.DataContext = this;

                Remote_Channels_Config_Window.Show();
                Remote_Channels_Config_Window.Closed += Remote_Channels_Config_Window_Closed_Event;
                Insert_Log("Remote Channels Config Window is open.", 0);
            }
            else
            {
                Insert_Log("Remote Channels Config Window is already open.", 2);
            }
        }

        private void Remote_Channels_Config_Window_Closed_Event(object sender, EventArgs e)
        {
            Remote_Channels_Config_Window.Closed -= Remote_Channels_Config_Window_Closed_Event;
            Remote_Channels_Config_Window = null;
            is_Remote_Channels_Config_Window_Open = false;
            Insert_Log("Remote Channels Config Window is closed.", 0);
        }

        private void Insert_Remote_Channel_Node_into_NodeList(int Remote_Channel)
        {
            switch (Remote_Channel)
            {
                case 5:
                    Dispatcher.BeginInvoke((Action)(() =>
                    {
                        ListViewModel.AddNodeType(() => new Channel_5_Node_ViewModel(this, Remote_CH_5_Name, true, NodeCategory.Oscilloscope_Channels, Remote_CH_5_Color, "#FFFFFF"));
                    }));
                    break;
                case 6:
                    Dispatcher.BeginInvoke((Action)(() =>
                    {
                        ListViewModel.AddNodeType(() => new Channel_6_Node_ViewModel(this, Remote_CH_6_Name, true, NodeCategory.Oscilloscope_Channels, Remote_CH_6_Color, "#FFFFFF"));
                    }));
                    break;
                case 7:
                    Dispatcher.BeginInvoke((Action)(() =>
                    {
                        ListViewModel.AddNodeType(() => new Channel_7_Node_ViewModel(this, Remote_CH_7_Name, true, NodeCategory.Oscilloscope_Channels, Remote_CH_7_Color, "#FFFFFF"));
                    }));
                    break;
                case 8:
                    Dispatcher.BeginInvoke((Action)(() =>
                    {
                        ListViewModel.AddNodeType(() => new Channel_8_Node_ViewModel(this, Remote_CH_8_Name, true, NodeCategory.Oscilloscope_Channels, Remote_CH_8_Color, "#FFFFFF"));
                    }));
                    break;
                case 9:
                    Dispatcher.BeginInvoke((Action)(() =>
                    {
                        ListViewModel.AddNodeType(() => new Channel_9_Node_ViewModel(this, Remote_CH_9_Name, true, NodeCategory.Oscilloscope_Channels, Remote_CH_9_Color, "#FFFFFF"));
                    }));
                    break;
                case 10:
                    Dispatcher.BeginInvoke((Action)(() =>
                    {
                        ListViewModel.AddNodeType(() => new Channel_10_Node_ViewModel(this, Remote_CH_10_Name, true, NodeCategory.Oscilloscope_Channels, Remote_CH_10_Color, "#FFFFFF"));
                    }));
                    break;
                case 11:
                    Dispatcher.BeginInvoke((Action)(() =>
                    {
                        ListViewModel.AddNodeType(() => new Channel_11_Node_ViewModel(this, Remote_CH_11_Name, true, NodeCategory.Oscilloscope_Channels, Remote_CH_11_Color, "#FFFFFF"));
                    }));
                    break;
                case 12:
                    Dispatcher.BeginInvoke((Action)(() =>
                    {
                        ListViewModel.AddNodeType(() => new Channel_12_Node_ViewModel(this, Remote_CH_12_Name, true, NodeCategory.Oscilloscope_Channels, Remote_CH_12_Color, "#FFFFFF"));
                    }));
                    break;
            }
        }

        private void AutoLoad_Remote_Channels_Config()
        {
            Dispatcher.BeginInvoke((Action)(() =>
            {
                try
                {
                    if (AutoLoad_isFile_Exists(Remote_Channels_FileName))
                    {
                        string[] Lines = File.ReadLines(NX_StarWave.Communication_Selected.folder_Directory + Remote_Channels_FileName).ToArray();

                        string[] RC5_Config = Lines[1].Split(Remote_Channels_File_Split);
                        Remote_CH_5_Name = RC5_Config[0];
                        Remote_CH_5_Color = RC5_Config[2];
                        Remote_CH_5_GetCounter_URL = RC5_Config[3];
                        Remote_CH_5_GetWaveform_URL = RC5_Config[4];
                        if (RC5_Config[1].Equals("True"))
                        {
                            Remote_CH_5_Enable = true;
                        }

                        string[] RC6_Config = Lines[2].Split(Remote_Channels_File_Split);
                        Remote_CH_6_Name = RC6_Config[0];
                        Remote_CH_6_Color = RC6_Config[2];
                        Remote_CH_6_GetCounter_URL = RC6_Config[3];
                        Remote_CH_6_GetWaveform_URL = RC6_Config[4];
                        if (RC6_Config[1].Equals("True"))
                        {
                            Remote_CH_6_Enable = true;
                        }

                        string[] RC7_Config = Lines[3].Split(Remote_Channels_File_Split);
                        Remote_CH_7_Name = RC7_Config[0];
                        Remote_CH_7_Color = RC7_Config[2];
                        Remote_CH_7_GetCounter_URL = RC7_Config[3];
                        Remote_CH_7_GetWaveform_URL = RC7_Config[4];
                        if (RC7_Config[1].Equals("True"))
                        {
                            Remote_CH_7_Enable = true;
                        }

                        string[] RC8_Config = Lines[4].Split(Remote_Channels_File_Split);
                        Remote_CH_8_Name = RC8_Config[0];
                        Remote_CH_8_Color = RC8_Config[2];
                        Remote_CH_8_GetCounter_URL = RC8_Config[3];
                        Remote_CH_8_GetWaveform_URL = RC8_Config[4];
                        if (RC8_Config[1].Equals("True"))
                        {
                            Remote_CH_8_Enable = true;
                        }

                        string[] RC9_Config = Lines[5].Split(Remote_Channels_File_Split);
                        Remote_CH_9_Name = RC9_Config[0];
                        Remote_CH_9_Color = RC9_Config[2];
                        Remote_CH_9_GetCounter_URL = RC9_Config[3];
                        Remote_CH_9_GetWaveform_URL = RC9_Config[4];
                        if (RC9_Config[1].Equals("True"))
                        {
                            Remote_CH_9_Enable = true;
                        }

                        string[] RC10_Config = Lines[6].Split(Remote_Channels_File_Split);
                        Remote_CH_10_Name = RC10_Config[0];
                        Remote_CH_10_Color = RC10_Config[2];
                        Remote_CH_10_GetCounter_URL = RC10_Config[3];
                        Remote_CH_10_GetWaveform_URL = RC10_Config[4];
                        if (RC10_Config[1].Equals("True"))
                        {
                            Remote_CH_10_Enable = true;
                        }

                        string[] RC11_Config = Lines[7].Split(Remote_Channels_File_Split);
                        Remote_CH_11_Name = RC11_Config[0];
                        Remote_CH_11_Color = RC11_Config[2];
                        Remote_CH_11_GetCounter_URL = RC11_Config[3];
                        Remote_CH_11_GetWaveform_URL = RC11_Config[4];
                        if (RC11_Config[1].Equals("True"))
                        {
                            Remote_CH_11_Enable = true;
                        }

                        string[] RC12_Config = Lines[8].Split(Remote_Channels_File_Split);
                        Remote_CH_12_Name = RC12_Config[0];
                        Remote_CH_12_Color = RC12_Config[2];
                        Remote_CH_12_GetCounter_URL = RC12_Config[3];
                        Remote_CH_12_GetWaveform_URL = RC12_Config[4];
                        if (RC12_Config[1].Equals("True"))
                        {
                            Remote_CH_12_Enable = true;
                        }

                    }
                }
                catch (Exception Ex)
                {
                    Insert_Log(Ex.Message, 1);
                    Insert_Log("Failed to load Remote Channels Config from the file.", 1);
                }
            }));
        }
    }
}
