using MahApps.Metro.Controls;
using NX_StarWave.Waveform_Model_Classes;
using Oscilloscope_Waveform_Data_Process;
using System;
using System.Collections.Concurrent;
using System.Timers;
using System.Windows.Threading;

namespace NX_StarWave
{
    public partial class NX_StarWave_Window : MetroWindow
    {
        private System.Timers.Timer DataProcess_Timer;

        private Tektronix_TDS_Waveform_Data_Process Waveform_Data = new Tektronix_TDS_Waveform_Data_Process();

        private BlockingCollection<All_Channels_Waveform_Data> Channels_Waveform_Data = new BlockingCollection<All_Channels_Waveform_Data>();

        private void Initialize_DataProcess_Timer()
        {
            DataProcess_Timer = new Timer();
            DataProcess_Timer.Interval = 1;
            DataProcess_Timer.Elapsed += DataProcess;
            DataProcess_Timer.AutoReset = false;
            DataProcess_Timer.Enabled = false;
        }

        private void DataProcess(Object source, ElapsedEventArgs e)
        {
            while (Channels_Waveform_Data.Count > 0)
            {
                All_Channels_Waveform_Data Channels_Data = Channels_Waveform_Data.Take();

                Channel_Waveform_Data CH1_Data = new Channel_Waveform_Data(false, new double[0], new double[0], 0, 0, 0, 0, "");
                Channel_Waveform_Data CH2_Data = new Channel_Waveform_Data(false, new double[0], new double[0], 0, 0, 0, 0, "");
                Channel_Waveform_Data CH3_Data = new Channel_Waveform_Data(false, new double[0], new double[0], 0, 0, 0, 0, "");
                Channel_Waveform_Data CH4_Data = new Channel_Waveform_Data(false, new double[0], new double[0], 0, 0, 0, 0, "");

                if (Channels_Data.CH1.data_valid)
                {
                    try
                    {
                        (CH1_Data.X_Data, CH1_Data.Y_Data, CH1_Data.Total_Time, CH1_Data.Start_Time, CH1_Data.Stop_Time, CH1_Data.Data_Points, CH1_Data.Channel_Info) = Waveform_Data.Process_Waveform_Data(Channels_Data.CH1.WFMPre, Channels_Data.CH1.Curve);
                    }
                    catch (Exception Ex) { CH1_Data.Valid = false; insert_Log("Could not process Channel 1 Waveform Data.", 1); insert_Log(Ex.Message, 1); }
                    if (CH1_Data.Data_Points >= 90)
                    {
                        CH1_Data.Valid = true;
                    }
                    else
                    {
                        CH1_Data.Valid = false;
                        insert_Log("Could not process Channel 1 Waveform Data.", 1);
                        insert_Log("Check Data Points Start & Stop Values are within Horizontal Record Length.", 2);
                    }
                }

                if (Channels_Data.CH2.data_valid)
                {
                    try
                    {
                        (CH2_Data.X_Data, CH2_Data.Y_Data, CH2_Data.Total_Time, CH2_Data.Start_Time, CH2_Data.Stop_Time, CH2_Data.Data_Points, CH2_Data.Channel_Info) = Waveform_Data.Process_Waveform_Data(Channels_Data.CH2.WFMPre, Channels_Data.CH2.Curve);
                    }
                    catch (Exception Ex) { CH2_Data.Valid = false; insert_Log("Could not process Channel 2 Waveform Data.", 1); insert_Log(Ex.Message, 1); }
                    if (CH2_Data.Data_Points >= 90)
                    {
                        CH2_Data.Valid = true;
                    }
                    else
                    {
                        CH2_Data.Valid = false;
                        insert_Log("Could not process Channel 2 Waveform Data.", 1);
                        insert_Log("Check Data Points Start & Stop Values are within Horizontal Record Length.", 2);
                    }
                }

                if (Channels_Data.CH3.data_valid)
                {
                    try
                    {
                        (CH3_Data.X_Data, CH3_Data.Y_Data, CH3_Data.Total_Time, CH3_Data.Start_Time, CH3_Data.Stop_Time, CH3_Data.Data_Points, CH3_Data.Channel_Info) = Waveform_Data.Process_Waveform_Data(Channels_Data.CH3.WFMPre, Channels_Data.CH3.Curve);
                    }
                    catch (Exception Ex) { CH3_Data.Valid = false; insert_Log("Could not process Channel 3 Waveform Data.", 1); insert_Log(Ex.Message, 1); }
                    if (CH3_Data.Data_Points >= 90)
                    {
                        CH3_Data.Valid = true;
                    }
                    else
                    {
                        CH3_Data.Valid = false;
                        insert_Log("Could not process Channel 3 Waveform Data.", 1);
                        insert_Log("Check Data Points Start & Stop Values are within Horizontal Record Length.", 2);
                    }
                }

                if (Channels_Data.CH4.data_valid)
                {
                    try
                    {
                        (CH4_Data.X_Data, CH4_Data.Y_Data, CH4_Data.Total_Time, CH4_Data.Start_Time, CH4_Data.Stop_Time, CH4_Data.Data_Points, CH4_Data.Channel_Info) = Waveform_Data.Process_Waveform_Data(Channels_Data.CH4.WFMPre, Channels_Data.CH4.Curve);
                    }
                    catch (Exception Ex) { CH4_Data.Valid = false; insert_Log("Could not process Channel 4 Waveform Data.", 1); insert_Log(Ex.Message, 1); }
                    if (CH4_Data.Data_Points >= 90)
                    {
                        CH4_Data.Valid = true;
                    }
                    else
                    {
                        CH4_Data.Valid = false;
                        insert_Log("Could not process Channel 4 Waveform Data.", 1);
                        insert_Log("Check Data Points Start & Stop Values are within Horizontal Record Length.", 2);
                    }
                }

                Insert_Data_into_Graphs(CH1_Data, CH2_Data, CH3_Data, CH4_Data);
                Waveform_Player_Data_Passthrough(CH1_Data, CH2_Data, CH3_Data, CH4_Data);
            }
        }

        public void insert_Graph_Data_Passthrough_from_SQLTable(Channel_Waveform_Data CH1_Data, Channel_Waveform_Data CH2_Data, Channel_Waveform_Data CH3_Data, Channel_Waveform_Data CH4_Data)
        {
            if (Dispatcher.Thread == System.Threading.Thread.CurrentThread)
            {
                try
                {
                    Insert_Data_into_Graphs(CH1_Data, CH2_Data, CH3_Data, CH4_Data);
                }
                catch (Exception Ex)
                {
                    insert_Log(Ex.Message, 1);
                }
            }
            else
            {
                Dispatcher.Invoke(DispatcherPriority.Normal, (System.Threading.ThreadStart)(delegate
                {
                    try
                    {
                        Insert_Data_into_Graphs(CH1_Data, CH2_Data, CH3_Data, CH4_Data);
                    }
                    catch (Exception Ex)
                    {
                        insert_Log(Ex.Message, 1);
                    }
                }));
            }
        }

        private void Insert_Data_into_Graphs(Channel_Waveform_Data CH1_Data, Channel_Waveform_Data CH2_Data, Channel_Waveform_Data CH3_Data, Channel_Waveform_Data CH4_Data)
        {
            YT_Graphs_Data_Passthrough(CH1_Data, CH2_Data, CH3_Data, CH4_Data);
            XY_Graphs_Data_Passthrough(CH1_Data, CH2_Data, CH3_Data, CH4_Data);
            Single_Math_Graphs_Data_Passthrough(CH1_Data, CH2_Data, CH3_Data, CH4_Data);
            Dual_Math_Graphs_Data_Passthrough(CH1_Data, CH2_Data, CH3_Data, CH4_Data);
            Histogram_Graphs_Data_Passthrough(CH1_Data, CH2_Data, CH3_Data, CH4_Data);
            FFT_Graphs_Data_Passthrough(CH1_Data, CH2_Data, CH3_Data, CH4_Data);
            FFT_Waveform_Graphs_Data_Passthrough(CH1_Data, CH2_Data, CH3_Data, CH4_Data);
            FFT_Waterfall_Graphs_Data_Passthrough(CH1_Data, CH2_Data, CH3_Data, CH4_Data);
            Data_Log_Graphs_Data_Passthrough(CH1_Data, CH2_Data, CH3_Data, CH4_Data);
            Waveform_Calculator_Data_Passthrough(CH1_Data, CH2_Data, CH3_Data, CH4_Data);
            NodeNetwork_Calculator_Data_Passthrough(CH1_Data, CH2_Data, CH3_Data, CH4_Data);
            Web_Server_Data_Passthrough(CH1_Data, CH2_Data, CH3_Data, CH4_Data);
        }

        public void YT_Graphs_Data_Passthrough(Channel_Waveform_Data CH1_Data, Channel_Waveform_Data CH2_Data, Channel_Waveform_Data CH3_Data, Channel_Waveform_Data CH4_Data)
        {
            try { if (Channel_1_YT != null) { Channel_1_YT.Waveform_Data_Queue.Add(CH1_Data); } } catch (Exception) { } //Channel 1 Data Required
            try { if (Channel_2_YT != null) { Channel_2_YT.Waveform_Data_Queue.Add(CH2_Data); } } catch (Exception) { } //Channel 2 Data Required
            try { if (Channel_3_YT != null) { Channel_3_YT.Waveform_Data_Queue.Add(CH3_Data); } } catch (Exception) { } //Channel 3 Data Required
            try { if (Channel_4_YT != null) { Channel_4_YT.Waveform_Data_Queue.Add(CH4_Data); } } catch (Exception) { } //Channel 4 Data Required

            try { if (All_Channels_YT != null) { All_Channels_YT.All_Channels_Data_Queue.Add(new All_Channels_Data(CH1_Data, CH2_Data, CH3_Data, CH4_Data)); } } catch (Exception) { } //All Channels Data Required
            try { if (All_Channels_YT_Square != null) { All_Channels_YT_Square.All_Channels_Data_Queue.Add(new All_Channels_Data(CH1_Data, CH2_Data, CH3_Data, CH4_Data)); } } catch (Exception) { } //All Channels Data Required
            try { if (All_Channels_YT_Stack != null) { All_Channels_YT_Stack.All_Channels_Data_Queue.Add(new All_Channels_Data(CH1_Data, CH2_Data, CH3_Data, CH4_Data)); } } catch (Exception) { } //All Channels Data Required
            try { if (All_Channels_YT_Seperate != null) { All_Channels_YT_Seperate.All_Channels_Data_Queue.Add(new All_Channels_Data(CH1_Data, CH2_Data, CH3_Data, CH4_Data)); } } catch (Exception) { } //All Channels Data Required
        }

        public void XY_Graphs_Data_Passthrough(Channel_Waveform_Data CH1_Data, Channel_Waveform_Data CH2_Data, Channel_Waveform_Data CH3_Data, Channel_Waveform_Data CH4_Data)
        {
            try { if (XY_Window_1 != null) { XY_Window_1.All_Channels_Data_Queue.Add(new All_Channels_Data(CH1_Data, CH2_Data, CH3_Data, CH4_Data)); } } catch (Exception) { } //All Channels Data Required
            try { if (XY_Window_2 != null) { XY_Window_2.All_Channels_Data_Queue.Add(new All_Channels_Data(CH1_Data, CH2_Data, CH3_Data, CH4_Data)); } } catch (Exception) { } //All Channels Data Required
            try { if (XY_Window_3 != null) { XY_Window_3.All_Channels_Data_Queue.Add(new All_Channels_Data(CH1_Data, CH2_Data, CH3_Data, CH4_Data)); } } catch (Exception) { } //All Channels Data Required
            try { if (XY_Window_4 != null) { XY_Window_4.All_Channels_Data_Queue.Add(new All_Channels_Data(CH1_Data, CH2_Data, CH3_Data, CH4_Data)); } } catch (Exception) { } //All Channels Data Required

            try { if (XY_Waveform_Window_1 != null) { XY_Waveform_Window_1.All_Channels_Data_Queue.Add(new All_Channels_Data(CH1_Data, CH2_Data, CH3_Data, CH4_Data)); } } catch (Exception) { } //All Channels Data Required
            try { if (XY_Waveform_Window_2 != null) { XY_Waveform_Window_2.All_Channels_Data_Queue.Add(new All_Channels_Data(CH1_Data, CH2_Data, CH3_Data, CH4_Data)); } } catch (Exception) { } //All Channels Data Required
            try { if (XY_Waveform_Window_3 != null) { XY_Waveform_Window_3.All_Channels_Data_Queue.Add(new All_Channels_Data(CH1_Data, CH2_Data, CH3_Data, CH4_Data)); } } catch (Exception) { } //All Channels Data Required
            try { if (XY_Waveform_Window_4 != null) { XY_Waveform_Window_4.All_Channels_Data_Queue.Add(new All_Channels_Data(CH1_Data, CH2_Data, CH3_Data, CH4_Data)); } } catch (Exception) { } //All Channels Data Required
        }

        public void Single_Math_Graphs_Data_Passthrough(Channel_Waveform_Data CH1_Data, Channel_Waveform_Data CH2_Data, Channel_Waveform_Data CH3_Data, Channel_Waveform_Data CH4_Data)
        {
            try { if (Math_YT_Window_1 != null) { Math_YT_Window_1.All_Channels_Data_Queue.Add(new All_Channels_Data(CH1_Data, CH2_Data, CH3_Data, CH4_Data)); } } catch (Exception) { } //All Channels Data Required
            try { if (Math_YT_Window_2 != null) { Math_YT_Window_2.All_Channels_Data_Queue.Add(new All_Channels_Data(CH1_Data, CH2_Data, CH3_Data, CH4_Data)); } } catch (Exception) { } //All Channels Data Required
            try { if (Math_YT_Window_3 != null) { Math_YT_Window_3.All_Channels_Data_Queue.Add(new All_Channels_Data(CH1_Data, CH2_Data, CH3_Data, CH4_Data)); } } catch (Exception) { } //All Channels Data Required
            try { if (Math_YT_Window_4 != null) { Math_YT_Window_4.All_Channels_Data_Queue.Add(new All_Channels_Data(CH1_Data, CH2_Data, CH3_Data, CH4_Data)); } } catch (Exception) { } //All Channels Data Required
        }

        public void Dual_Math_Graphs_Data_Passthrough(Channel_Waveform_Data CH1_Data, Channel_Waveform_Data CH2_Data, Channel_Waveform_Data CH3_Data, Channel_Waveform_Data CH4_Data)
        {
            try { if (Math_FFT_Window_1 != null) { Math_FFT_Window_1.All_Channels_Data_Queue.Add(new All_Channels_Data(CH1_Data, CH2_Data, CH3_Data, CH4_Data)); } } catch (Exception) { } //All Channels Data Required
            try { if (Math_FFT_Window_2 != null) { Math_FFT_Window_2.All_Channels_Data_Queue.Add(new All_Channels_Data(CH1_Data, CH2_Data, CH3_Data, CH4_Data)); } } catch (Exception) { } //All Channels Data Required
            try { if (Math_FFT_Window_3 != null) { Math_FFT_Window_3.All_Channels_Data_Queue.Add(new All_Channels_Data(CH1_Data, CH2_Data, CH3_Data, CH4_Data)); } } catch (Exception) { } //All Channels Data Required
            try { if (Math_FFT_Window_4 != null) { Math_FFT_Window_4.All_Channels_Data_Queue.Add(new All_Channels_Data(CH1_Data, CH2_Data, CH3_Data, CH4_Data)); } } catch (Exception) { } //All Channels Data Required
        }

        public void Histogram_Graphs_Data_Passthrough(Channel_Waveform_Data CH1_Data, Channel_Waveform_Data CH2_Data, Channel_Waveform_Data CH3_Data, Channel_Waveform_Data CH4_Data)
        {
            try { if (Channel_1_Histogram != null) { Channel_1_Histogram.Waveform_Data_Queue.Add(CH1_Data); } } catch (Exception) { } //Channel 1 Data Required
            try { if (Channel_2_Histogram != null) { Channel_2_Histogram.Waveform_Data_Queue.Add(CH2_Data); } } catch (Exception) { } //Channel 2 Data Required
            try { if (Channel_3_Histogram != null) { Channel_3_Histogram.Waveform_Data_Queue.Add(CH3_Data); } } catch (Exception) { } //Channel 3 Data Required
            try { if (Channel_4_Histogram != null) { Channel_4_Histogram.Waveform_Data_Queue.Add(CH4_Data); } } catch (Exception) { } //Channel 4 Data Required
        }

        public void FFT_Graphs_Data_Passthrough(Channel_Waveform_Data CH1_Data, Channel_Waveform_Data CH2_Data, Channel_Waveform_Data CH3_Data, Channel_Waveform_Data CH4_Data)
        {
            try { if (FFT_Channel_1 != null) { FFT_Channel_1.Waveform_Data_Queue.Add(CH1_Data); } } catch (Exception) { } //Channel 1 Data Required
            try { if (FFT_Channel_2 != null) { FFT_Channel_2.Waveform_Data_Queue.Add(CH2_Data); } } catch (Exception) { } //Channel 2 Data Required
            try { if (FFT_Channel_3 != null) { FFT_Channel_3.Waveform_Data_Queue.Add(CH3_Data); } } catch (Exception) { } //Channel 3 Data Required
            try { if (FFT_Channel_4 != null) { FFT_Channel_4.Waveform_Data_Queue.Add(CH4_Data); } } catch (Exception) { } //Channel 4 Data Required
        }

        public void FFT_Waveform_Graphs_Data_Passthrough(Channel_Waveform_Data CH1_Data, Channel_Waveform_Data CH2_Data, Channel_Waveform_Data CH3_Data, Channel_Waveform_Data CH4_Data)
        {
            try { if (FFT_Waveform_Channel_1 != null) { FFT_Waveform_Channel_1.Waveform_Data_Queue.Add(CH1_Data); } } catch (Exception) { } //Channel 1 Data Required
            try { if (FFT_Waveform_Channel_2 != null) { FFT_Waveform_Channel_2.Waveform_Data_Queue.Add(CH2_Data); } } catch (Exception) { } //Channel 2 Data Required
            try { if (FFT_Waveform_Channel_3 != null) { FFT_Waveform_Channel_3.Waveform_Data_Queue.Add(CH3_Data); } } catch (Exception) { } //Channel 3 Data Required
            try { if (FFT_Waveform_Channel_4 != null) { FFT_Waveform_Channel_4.Waveform_Data_Queue.Add(CH4_Data); } } catch (Exception) { } //Channel 4 Data Required
        }

        public void FFT_Waterfall_Graphs_Data_Passthrough(Channel_Waveform_Data CH1_Data, Channel_Waveform_Data CH2_Data, Channel_Waveform_Data CH3_Data, Channel_Waveform_Data CH4_Data)
        {
            try { if (FFT_Waterfall_Channel_1 != null) { FFT_Waterfall_Channel_1.Waveform_Data_Queue.Add(CH1_Data); } } catch (Exception) { } //Channel 1 Data Required
            try { if (FFT_Waterfall_Channel_2 != null) { FFT_Waterfall_Channel_2.Waveform_Data_Queue.Add(CH2_Data); } } catch (Exception) { } //Channel 2 Data Required
            try { if (FFT_Waterfall_Channel_3 != null) { FFT_Waterfall_Channel_3.Waveform_Data_Queue.Add(CH3_Data); } } catch (Exception) { } //Channel 3 Data Required
            try { if (FFT_Waterfall_Channel_4 != null) { FFT_Waterfall_Channel_4.Waveform_Data_Queue.Add(CH4_Data); } } catch (Exception) { } //Channel 4 Data Required
        }

        public void Data_Log_Graphs_Data_Passthrough(Channel_Waveform_Data CH1_Data, Channel_Waveform_Data CH2_Data, Channel_Waveform_Data CH3_Data, Channel_Waveform_Data CH4_Data)
        {
            try { if (Channel_1_DataLog != null) { Channel_1_DataLog.Data_Queue.Add(CH1_Data.Y_Data); } } catch (Exception) { } //Channel 1 Data Required
            try { if (Channel_2_DataLog != null) { Channel_2_DataLog.Data_Queue.Add(CH2_Data.Y_Data); } } catch (Exception) { } //Channel 2 Data Required
            try { if (Channel_3_DataLog != null) { Channel_3_DataLog.Data_Queue.Add(CH3_Data.Y_Data); } } catch (Exception) { } //Channel 3 Data Required
            try { if (Channel_4_DataLog != null) { Channel_4_DataLog.Data_Queue.Add(CH4_Data.Y_Data); } } catch (Exception) { } //Channel 4 Data Required
        }

        public void Waveform_Calculator_Data_Passthrough(Channel_Waveform_Data CH1_Data, Channel_Waveform_Data CH2_Data, Channel_Waveform_Data CH3_Data, Channel_Waveform_Data CH4_Data)
        {
            try { if (Waveform_Calculator_Window != null) { Waveform_Calculator_Window.All_Channels_Data_Queue.Add(new All_Channels_Data(CH1_Data, CH2_Data, CH3_Data, CH4_Data)); } } catch (Exception) { } //All Channels Data Required
        }

        public void NodeNetwork_Calculator_Data_Passthrough(Channel_Waveform_Data CH1_Data, Channel_Waveform_Data CH2_Data, Channel_Waveform_Data CH3_Data, Channel_Waveform_Data CH4_Data)
        {
            try { if (NodeNetwork_Calculator_Window != null) { NodeNetwork_Calculator_Window.All_Channels_Data_Queue.Add(new All_Channels_Data(CH1_Data, CH2_Data, CH3_Data, CH4_Data)); } } catch (Exception) { } //All Channels Data Required
        }

        public void Waveform_Player_Data_Passthrough(Channel_Waveform_Data CH1_Data, Channel_Waveform_Data CH2_Data, Channel_Waveform_Data CH3_Data, Channel_Waveform_Data CH4_Data)
        {
            try { if (Waveform_Player_Window != null) { Waveform_Player_Window.All_Channels_Data_Queue.Add(new All_Channels_Data(CH1_Data, CH2_Data, CH3_Data, CH4_Data)); } } catch (Exception) { } //All Channels Data Required
        }

        public void Web_Server_Data_Passthrough(Channel_Waveform_Data CH1_Data, Channel_Waveform_Data CH2_Data, Channel_Waveform_Data CH3_Data, Channel_Waveform_Data CH4_Data)
        {
            try { if (Waveform_Web_Server != null) { Waveform_Web_Server.All_Channels_Data_Queue.Add(new All_Channels_Data(CH1_Data, CH2_Data, CH3_Data, CH4_Data)); } } catch (Exception) { } //All Channels Data Required
        }
    }
}
