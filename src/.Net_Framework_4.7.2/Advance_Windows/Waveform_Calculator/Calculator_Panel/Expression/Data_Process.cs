using MahApps.Metro.Controls;
using NX_StarWave.Waveform_Model_Classes;
using System;
using System.Collections.Concurrent;
using System.Linq;
using System.Windows.Threading;

namespace Waveform_Calculator
{
    public partial class Calculator_Panel : MetroWindow
    {
        //Waveform data is initially stored here unitl it is removed, processed and displayed on the graph window
        public BlockingCollection<All_Channels_Data> All_Channels_Data_Queue = new BlockingCollection<All_Channels_Data>();

        private BlockingCollection<Expression_Data> Math_Expressions_Stored = new BlockingCollection<Expression_Data>();

        //These timers periodically check for any data inserted into Data_Queue, and processs it and insert it into the graph
        private System.Timers.Timer Waveform_Data_Process;
        private DispatcherTimer Math_Expression_Process;

        private void Initialize_Timers()
        {
            Waveform_Data_Process = new System.Timers.Timer(50);
            Waveform_Data_Process.Elapsed += Waveform_Data_Processor;
            Waveform_Data_Process.AutoReset = false;
            Waveform_Data_Process.Enabled = true;
            Waveform_Data_Process.Start();

            Math_Expression_Process = new DispatcherTimer(DispatcherPriority.Normal);
            Math_Expression_Process.Tick += Math_Expression_Processor;
            Math_Expression_Process.Interval = TimeSpan.FromMilliseconds(1000);
            Math_Expression_Process.Start();
        }

        private void Waveform_Data_Processor(object sender, EventArgs e)
        {
            while (All_Channels_Data_Queue.Count > 0)
            {
                All_Channels_Data Data = All_Channels_Data_Queue.Take();
                Processed_Channels_Data CH_Data = Channels_Data_process(Data);
                Pass_Data_to_Waveform_Panels(CH_Data);
                Pass_Data_to_Histogram_Panels(CH_Data);
                Pass_Data_to_FFT_Panels(CH_Data);
            }
            Waveform_Data_Process.Start();
        }

        private void Math_Expression_Processor(object sender, EventArgs e)
        {
            try
            {
                while (Math_Expressions_Stored.Count() > 0)
                {
                    int Panel_Open_Counter = 3;
                    Expression_Data Math_Expression = Math_Expressions_Stored.Take();
                    string[] Waveform_Config = Math_Expression.Expression_Waveform_Config.Split(',');
                    string[] Histogram_Config = Math_Expression.Expression_Histogram_Config.Split(',');
                    string[] FFT_Config = Math_Expression.Expression_FFT_Config.Split(',');
                    if (Waveform_Config[0] == "True")
                    {
                        Open_Waveform_Panel(Math_Expression);
                    }
                    else
                    {
                        Panel_Open_Counter--;
                    }
                    if (Histogram_Config[0] == "True")
                    {
                        Open_Histogram_Panel(Math_Expression);
                    }
                    else
                    {
                        Panel_Open_Counter--;
                    }
                    if (FFT_Config[0] == "True")
                    {
                        Open_FFT_Panel(Math_Expression);
                    }
                    else
                    {
                        Panel_Open_Counter--;
                    }
                    if (Panel_Open_Counter == 0)
                    {
                        insert_Log("Expression not graphed on any panels.", 2);
                    }
                }
            }
            catch (Exception Ex)
            {
                insert_Log(Ex.Message, 1);
            }
        }

        private Processed_Channels_Data Channels_Data_process(All_Channels_Data Channels_Data)
        {
            bool CH1_Valid = false;
            bool CH2_Valid = false;
            bool CH3_Valid = false;
            bool CH4_Valid = false;

            double[] Channel_1_Data = { 0 };
            double[] Channel_2_Data = { 0 };
            double[] Channel_3_Data = { 0 };
            double[] Channel_4_Data = { 0 };
            double[] Time_Data = { 0 };

            int Data_Points = 0;
            double Total_Time = 0;
            double Start_Time = 0;
            double Stop_Time = 0;
            string Channel_Info = "";

            Channel_Waveform_Data CH1 = Channels_Data.CH1;
            Channel_Waveform_Data CH2 = Channels_Data.CH2;
            Channel_Waveform_Data CH3 = Channels_Data.CH3;
            Channel_Waveform_Data CH4 = Channels_Data.CH4;

            if (CH1.Valid)
            {
                CH1_Valid = true; Channel_1_Data = CH1.Y_Data;
            }

            if (CH2.Valid)
            {
                CH2_Valid = true; Channel_2_Data = CH2.Y_Data;
            }

            if (CH3.Valid)
            {
                CH3_Valid = true; Channel_3_Data = CH3.Y_Data;
            }

            if (CH4.Valid)
            {
                CH4_Valid = true; Channel_4_Data = CH4.Y_Data;
            }

            if (CH1_Valid)
            {
                Total_Time = CH1.Total_Time; Start_Time = CH1.Start_Time; Stop_Time = CH1.Stop_Time; Data_Points = CH1.Data_Points; Channel_Info = CH1.Channel_Info;
                Time_Data = CH1.X_Data;
            }
            else if (CH2_Valid)
            {
                Total_Time = CH2.Total_Time; Start_Time = CH2.Start_Time; Stop_Time = CH2.Stop_Time; Data_Points = CH2.Data_Points; Channel_Info = CH2.Channel_Info;
                Time_Data = CH2.X_Data;
            }
            else if (CH3_Valid)
            {
                Total_Time = CH3.Total_Time; Start_Time = CH3.Start_Time; Stop_Time = CH3.Stop_Time; Data_Points = CH3.Data_Points; Channel_Info = CH3.Channel_Info;
                Time_Data = CH3.X_Data;
            }
            else if (CH4_Valid)
            {
                Total_Time = CH4.Total_Time; Start_Time = CH4.Start_Time; Stop_Time = CH4.Stop_Time; Data_Points = CH4.Data_Points; Channel_Info = CH4.Channel_Info;
                Time_Data = CH4.X_Data;
            }
            return new Processed_Channels_Data(CH1_Valid, CH2_Valid, CH3_Valid, CH4_Valid, Channel_1_Data, Channel_2_Data, Channel_3_Data, Channel_4_Data, Time_Data, Data_Points, Total_Time, Start_Time, Stop_Time, Channel_Info);
        }
    }
}
