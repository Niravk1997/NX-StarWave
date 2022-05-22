using MahApps.Metro.Controls;
using Newtonsoft.Json;
using NX_StarWave.Waveform_Model_Classes;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace NodeNetwork_Math
{
    public partial class NodeNetwork_Window : MetroWindow
    {
        //These timers periodically check for any data inserted into Data_Queue, and processs it
        private System.Timers.Timer Remote_Channels_Data_Process;

        private List<Task> Remote_Channels_GetStringAsync_Task_List = new List<Task>();

        private HttpClient Remote_Channels_Client = new HttpClient();

        private void Initialize_Remote_Channels_Timers()
        {
            Remote_Channels_Data_Process = new System.Timers.Timer(10);
            Remote_Channels_Data_Process.Elapsed += Remote_Channels_Waveform_Data_Process_NodeNetwork;
            Remote_Channels_Data_Process.AutoReset = false;
            Remote_Channels_Data_Process.Enabled = true;
        }

        private void Remote_Channels_Waveform_Data_Process_NodeNetwork(object sender, EventArgs e)
        {
            if (Get_Remote_Channels_Data)
            {
                Remote_Channels_GetStringAsync_Task_List.Clear();

                if (Remote_CH_5_Enable)
                {
                    Task Remote_CH_5_Task = Task.Run(async () =>
                    {
                        try
                        {
                            string Counter = await Remote_Channels_Client.GetStringAsync(Remote_CH_5_GetCounter_URL);
                            if (Remote_CH_5_Counter_String.Equals(Counter) == false)
                            {
                                Remote_CH_5_Counter_String = Counter;
                                string Data = await Remote_Channels_Client.GetStringAsync(Remote_CH_5_GetWaveform_URL);
                                RChannels_Waveform_Data_Process(5, Data);
                            }
                        }
                        catch (Exception Ex) { Insert_Log("Remote_CH_5: " + Ex.Message, 1); }

                    }); Remote_Channels_GetStringAsync_Task_List.Add(Remote_CH_5_Task);
                }

                if (Remote_CH_6_Enable)
                {
                    Task Remote_CH_6_Task = Task.Run(async () =>
                    {
                        try
                        {
                            string Counter = await Remote_Channels_Client.GetStringAsync(Remote_CH_6_GetCounter_URL);
                            if (Remote_CH_6_Counter_String.Equals(Counter) == false)
                            {
                                Remote_CH_6_Counter_String = Counter;
                                string Data = await Remote_Channels_Client.GetStringAsync(Remote_CH_6_GetWaveform_URL);
                                RChannels_Waveform_Data_Process(6, Data);
                            }
                        }
                        catch (Exception Ex) { Insert_Log("Remote_CH_6: " + Ex.Message, 1); }

                    }); Remote_Channels_GetStringAsync_Task_List.Add(Remote_CH_6_Task);
                }

                if (Remote_CH_7_Enable)
                {
                    Task Remote_CH_7_Task = Task.Run(async () =>
                    {
                        try
                        {
                            string Counter = await Remote_Channels_Client.GetStringAsync(Remote_CH_7_GetCounter_URL);
                            if (Remote_CH_7_Counter_String.Equals(Counter) == false)
                            {
                                Remote_CH_7_Counter_String = Counter;
                                string Data = await Remote_Channels_Client.GetStringAsync(Remote_CH_7_GetWaveform_URL);
                                RChannels_Waveform_Data_Process(7, Data);
                            }
                        }
                        catch (Exception Ex) { Insert_Log("Remote_CH_7: " + Ex.Message, 1); }

                    }); Remote_Channels_GetStringAsync_Task_List.Add(Remote_CH_7_Task);
                }

                if (Remote_CH_8_Enable)
                {
                    Task Remote_CH_8_Task = Task.Run(async () =>
                    {
                        try
                        {
                            string Counter = await Remote_Channels_Client.GetStringAsync(Remote_CH_8_GetCounter_URL);
                            if (Remote_CH_8_Counter_String.Equals(Counter) == false)
                            {
                                Remote_CH_8_Counter_String = Counter;
                                string Data = await Remote_Channels_Client.GetStringAsync(Remote_CH_8_GetWaveform_URL);
                                RChannels_Waveform_Data_Process(8, Data);
                            }
                        }
                        catch (Exception Ex) { Insert_Log("Remote_CH_8: " + Ex.Message, 1); }

                    }); Remote_Channels_GetStringAsync_Task_List.Add(Remote_CH_8_Task);
                }

                if (Remote_CH_9_Enable)
                {
                    Task Remote_CH_9_Task = Task.Run(async () =>
                    {
                        try
                        {
                            string Counter = await Remote_Channels_Client.GetStringAsync(Remote_CH_9_GetCounter_URL);
                            if (Remote_CH_9_Counter_String.Equals(Counter) == false)
                            {
                                Remote_CH_9_Counter_String = Counter;
                                string Data = await Remote_Channels_Client.GetStringAsync(Remote_CH_9_GetWaveform_URL);
                                RChannels_Waveform_Data_Process(9, Data);
                            }
                        }
                        catch (Exception Ex) { Insert_Log("Remote_CH_9: " + Ex.Message, 1); }

                    }); Remote_Channels_GetStringAsync_Task_List.Add(Remote_CH_9_Task);
                }

                if (Remote_CH_10_Enable)
                {
                    Task Remote_CH_10_Task = Task.Run(async () =>
                    {
                        try
                        {
                            string Counter = await Remote_Channels_Client.GetStringAsync(Remote_CH_10_GetCounter_URL);
                            if (Remote_CH_10_Counter_String.Equals(Counter) == false)
                            {
                                Remote_CH_10_Counter_String = Counter;
                                string Data = await Remote_Channels_Client.GetStringAsync(Remote_CH_10_GetWaveform_URL);
                                RChannels_Waveform_Data_Process(10, Data);
                            }
                        }
                        catch (Exception Ex) { Insert_Log("Remote_CH_10: " + Ex.Message, 1); }

                    }); Remote_Channels_GetStringAsync_Task_List.Add(Remote_CH_10_Task);
                }

                if (Remote_CH_11_Enable)
                {
                    Task Remote_CH_11_Task = Task.Run(async () =>
                    {
                        try
                        {
                            string Counter = await Remote_Channels_Client.GetStringAsync(Remote_CH_11_GetCounter_URL);
                            if (Remote_CH_11_Counter_String.Equals(Counter) == false)
                            {
                                Remote_CH_11_Counter_String = Counter;
                                string Data = await Remote_Channels_Client.GetStringAsync(Remote_CH_11_GetWaveform_URL);
                                RChannels_Waveform_Data_Process(11, Data);
                            }
                        }
                        catch (Exception Ex) { Insert_Log("Remote_CH_11: " + Ex.Message, 1); }

                    }); Remote_Channels_GetStringAsync_Task_List.Add(Remote_CH_11_Task);
                }

                if (Remote_CH_12_Enable)
                {
                    Task Remote_CH_12_Task = Task.Run(async () =>
                    {
                        try
                        {
                            string Counter = await Remote_Channels_Client.GetStringAsync(Remote_CH_12_GetCounter_URL);
                            if (Remote_CH_12_Counter_String.Equals(Counter) == false)
                            {
                                Remote_CH_12_Counter_String = Counter;
                                string Data = await Remote_Channels_Client.GetStringAsync(Remote_CH_12_GetWaveform_URL);
                                RChannels_Waveform_Data_Process(12, Data);
                            }
                        }
                        catch (Exception Ex) { Insert_Log("Remote_CH_12: " + Ex.Message, 1); }

                    }); Remote_Channels_GetStringAsync_Task_List.Add(Remote_CH_12_Task);
                }

                Task.WaitAll(Remote_Channels_GetStringAsync_Task_List.ToArray());
            }
            Remote_Channels_Data_Process.Enabled = true;
        }

        private void RChannels_Waveform_Data_Process(int RChannel, string Data)
        {
            Wavefrom_Web_Server_Model_Class Web_Server_Data = JsonConvert.DeserializeObject<Wavefrom_Web_Server_Model_Class>(Data);
            Remote_Channel_Waveform_Model_Class Waveform_Data = new Remote_Channel_Waveform_Model_Class(RChannel, Web_Server_Data.Total_Time, Web_Server_Data.Start_Time, Web_Server_Data.Stop_Time, Web_Server_Data.Data_Points, Web_Server_Data.Channel_Info, Functions.Linspace(Web_Server_Data.Start_Time, Web_Server_Data.Stop_Time, Web_Server_Data.Data_Points), Web_Server_Data.Waveform_Y_Data);
            Remote_Channels_Data_Queue.Add(Waveform_Data);
        }
    }
}
