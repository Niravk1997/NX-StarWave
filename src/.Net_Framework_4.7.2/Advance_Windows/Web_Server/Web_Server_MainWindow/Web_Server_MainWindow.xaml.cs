using MahApps.Metro.Controls;
using Newtonsoft.Json;
using NX_StarWave.Waveform_Model_Classes;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Waveform_Web_Server
{
    public partial class Web_Server_MainWindow : MetroWindow
    {
        //Waveform data is initially stored here unitl it is removed, processed and displayed on the graph window
        public BlockingCollection<All_Channels_Data> All_Channels_Data_Queue = new BlockingCollection<All_Channels_Data>();

        //These timers periodically check for any data inserted into Data_Queue, and processs it
        private System.Timers.Timer Waveform_Data_Process;

        private List<Task> Channels_Data_Process_Task_List = new List<Task>();

        public Web_Server_MainWindow()
        {
            InitializeComponent();
            DataContext = this;
            AutoLoad_Load_Web_Server_Config_File();
            Detect_Local_IPv4_Address();
            Initialize_Timers();
        }

        private void Initialize_Timers()
        {
            Waveform_Data_Process = new System.Timers.Timer(20);
            Waveform_Data_Process.Elapsed += Waveform_Data_Process_Graph;
            Waveform_Data_Process.AutoReset = false;
            Waveform_Data_Process.Enabled = true;
        }

        private void Waveform_Data_Process_Graph(object sender, EventArgs e)
        {
            while (All_Channels_Data_Queue.Count > 0)
            {

                try
                {
                    All_Channels_Data Channels_Data = All_Channels_Data_Queue.Take();

                    Channels_Data_Process_Task_List.Clear();

                    if (Channels_Data.CH1.Valid)
                    {
                        Task CH1_Waveform_Task = Task.Run(() =>
                        {
                            int Local_CH1_Counter = CH1_Counter + 1;
                            CH1_Waveform = JsonConvert.SerializeObject(new Wavefrom_Web_Server_Model_Class(true, Local_CH1_Counter, Channels_Data.CH1.Data_Points, Channels_Data.CH1.Total_Time, Channels_Data.CH1.Start_Time, Channels_Data.CH1.Stop_Time, Channels_Data.CH1.Channel_Info, Channels_Data.CH1.Y_Data));
                            CH1_Counter = Local_CH1_Counter;
                        }); Channels_Data_Process_Task_List.Add(CH1_Waveform_Task);
                    }

                    if (Channels_Data.CH2.Valid)
                    {
                        Task CH2_Waveform_Task = Task.Run(() =>
                        {
                            int Local_CH2_Counter = CH2_Counter + 1;
                            CH2_Waveform = JsonConvert.SerializeObject(new Wavefrom_Web_Server_Model_Class(true, Local_CH2_Counter, Channels_Data.CH2.Data_Points, Channels_Data.CH2.Total_Time, Channels_Data.CH2.Start_Time, Channels_Data.CH2.Stop_Time, Channels_Data.CH2.Channel_Info, Channels_Data.CH2.Y_Data));
                            CH2_Counter = Local_CH2_Counter;
                        }); Channels_Data_Process_Task_List.Add(CH2_Waveform_Task);
                    }

                    if (Channels_Data.CH3.Valid)
                    {
                        Task CH3_Waveform_Task = Task.Run(() =>
                        {
                            int Local_CH3_Counter = CH3_Counter + 1;
                            CH3_Waveform = JsonConvert.SerializeObject(new Wavefrom_Web_Server_Model_Class(true, Local_CH3_Counter, Channels_Data.CH3.Data_Points, Channels_Data.CH3.Total_Time, Channels_Data.CH3.Start_Time, Channels_Data.CH3.Stop_Time, Channels_Data.CH3.Channel_Info, Channels_Data.CH3.Y_Data));
                            CH3_Counter = Local_CH3_Counter;
                        }); Channels_Data_Process_Task_List.Add(CH3_Waveform_Task);
                    }

                    if (Channels_Data.CH4.Valid)
                    {
                        Task CH4_Waveform_Task = Task.Run(() =>
                        {
                            int Local_CH4_Counter = CH4_Counter + 1;
                            CH4_Waveform = JsonConvert.SerializeObject(new Wavefrom_Web_Server_Model_Class(true, Local_CH4_Counter, Channels_Data.CH4.Data_Points, Channels_Data.CH4.Total_Time, Channels_Data.CH4.Start_Time, Channels_Data.CH4.Stop_Time, Channels_Data.CH4.Channel_Info, Channels_Data.CH4.Y_Data));
                            CH4_Counter = Local_CH4_Counter;
                        }); Channels_Data_Process_Task_List.Add(CH4_Waveform_Task);
                    }

                    Task.WaitAll(Channels_Data_Process_Task_List.ToArray());
                }
                catch (Exception Ex)
                {
                    insert_Log(Ex.Message, 1);
                    insert_Log("Waveform Data could not be processed.", 1);
                }
            }
            Waveform_Data_Process.Enabled = true;
        }
    }
}
