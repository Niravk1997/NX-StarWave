using MahApps.Metro.Controls;
using Newtonsoft.Json;
using NX_StarWave.Waveform_Model_Classes;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Timers;
using System.Windows;

namespace NX_StarWave
{
    public partial class NX_StarWave_Window : MetroWindow
    {
        //This File has the code for the Demo Mode
        //This mode will add dummy waveform data into the Channels_Waveform_Data collection and invoke DataProcess_Timer

        private Channel_Waveform_Data Channel_Dummy_Data_1;
        private Channel_Waveform_Data Channel_Dummy_Data_2;
        private Channel_Waveform_Data Channel_Dummy_Data_3;
        private Channel_Waveform_Data Channel_Dummy_Data_4;

        private System.Timers.Timer Demo_Mode_DataProcess_Timer;
        private Stopwatch Demo_Mode_Interval;

        private int Dummy_Counter = 0;

        private void Enable_Demo_Mode_Click(object sender, RoutedEventArgs e)
        {
            if (Demo_Mode_Enable)
            {
                Initialize_Demo_Mode();
            }
            else
            {
                try
                {
                    Demo_Mode_DataProcess_Timer.Stop();
                    Demo_Mode_DataProcess_Timer.Dispose();
                    Demo_Mode_Interval.Stop();
                    Demo_Mode_Interval = null;
                    insert_Log("Demo Mode Disabled.", 0);
                }
                catch (Exception) { }
            }
        }

        private void Initialize_Demo_Mode()
        {
            try
            {
                string Demo_Waveform_1 = File.ReadAllText("NX_StarWave_Demo_Waveform_1.txt");
                string Demo_Waveform_2 = File.ReadAllText("NX_StarWave_Demo_Waveform_2.txt");
                string Demo_Waveform_3 = File.ReadAllText("NX_StarWave_Demo_Waveform_3.txt");
                string Demo_Waveform_4 = File.ReadAllText("NX_StarWave_Demo_Waveform_4.txt");

                Reference_Waveform Dummy_Data_1 = JsonConvert.DeserializeObject<Reference_Waveform>(Demo_Waveform_1);
                Reference_Waveform Dummy_Data_2 = JsonConvert.DeserializeObject<Reference_Waveform>(Demo_Waveform_2);
                Reference_Waveform Dummy_Data_3 = JsonConvert.DeserializeObject<Reference_Waveform>(Demo_Waveform_3);
                Reference_Waveform Dummy_Data_4 = JsonConvert.DeserializeObject<Reference_Waveform>(Demo_Waveform_4);

                List<double> Data_Points_Match = new List<double>();
                Data_Points_Match.Add(Dummy_Data_1.Data_Points);
                Data_Points_Match.Add(Dummy_Data_2.Data_Points);
                Data_Points_Match.Add(Dummy_Data_3.Data_Points);
                Data_Points_Match.Add(Dummy_Data_4.Data_Points);

                if (!(Data_Points_Match.Any(o => o != Data_Points_Match[0])))
                {
                    Channel_Dummy_Data_1 = new Channel_Waveform_Data(true, Fuctions.Linspace(Dummy_Data_1.Start_Time, Dummy_Data_1.Stop_Time, Dummy_Data_1.Data_Points), Dummy_Data_1.Waveform_Y_Data.ToArray(), Dummy_Data_1.Total_Time, Dummy_Data_1.Start_Time, Dummy_Data_1.Stop_Time, Dummy_Data_1.Data_Points, Dummy_Data_1.Channel_Info);
                    Channel_Dummy_Data_2 = new Channel_Waveform_Data(true, Fuctions.Linspace(Dummy_Data_2.Start_Time, Dummy_Data_2.Stop_Time, Dummy_Data_2.Data_Points), Dummy_Data_2.Waveform_Y_Data.ToArray(), Dummy_Data_2.Total_Time, Dummy_Data_2.Start_Time, Dummy_Data_2.Stop_Time, Dummy_Data_2.Data_Points, Dummy_Data_2.Channel_Info);
                    Channel_Dummy_Data_3 = new Channel_Waveform_Data(true, Fuctions.Linspace(Dummy_Data_3.Start_Time, Dummy_Data_3.Stop_Time, Dummy_Data_3.Data_Points), Dummy_Data_3.Waveform_Y_Data.ToArray(), Dummy_Data_3.Total_Time, Dummy_Data_3.Start_Time, Dummy_Data_3.Stop_Time, Dummy_Data_3.Data_Points, Dummy_Data_3.Channel_Info);
                    Channel_Dummy_Data_4 = new Channel_Waveform_Data(true, Fuctions.Linspace(Dummy_Data_4.Start_Time, Dummy_Data_4.Stop_Time, Dummy_Data_4.Data_Points), Dummy_Data_4.Waveform_Y_Data.ToArray(), Dummy_Data_4.Total_Time, Dummy_Data_4.Start_Time, Dummy_Data_4.Stop_Time, Dummy_Data_4.Data_Points, Dummy_Data_4.Channel_Info);
                    Initialize_Demo_Mode_DataProcess_Timer();
                    insert_Log("Demo Mode Initialized.", 0);
                }
                else
                {
                    insert_Log("Total Data Points in each of the 4 Demo Waveforms must be the same.", 1);
                    insert_Log("Demo Mode failed to initialze.", 1);
                    Demo_Mode_Enable = false;
                }
            }
            catch (Exception Ex)
            {
                Demo_Mode_Enable = false;
                insert_Log(Ex.Message, 1);
                insert_Log("Demo Mode failed to initialze.", 1);
            }
        }

        private void Initialize_Demo_Mode_DataProcess_Timer()
        {
            Demo_Mode_Interval = new Stopwatch();
            Demo_Mode_Interval.Start();

            Demo_Mode_DataProcess_Timer = new Timer();
            Demo_Mode_DataProcess_Timer.Interval = 1;
            Demo_Mode_DataProcess_Timer.Elapsed += Demo_Mode_Add_Data_Collection;
            Demo_Mode_DataProcess_Timer.AutoReset = false;
            Demo_Mode_DataProcess_Timer.Enabled = true;
        }

        private void Demo_Mode_Add_Data_Collection(Object source, ElapsedEventArgs e)
        {
            if (Demo_Mode_Interval.Elapsed.TotalMilliseconds >= Demo_Mode_Speed_Value_ms)
            {
                Channel_Waveform_Data Dummy_Data = null;
                if (Dummy_Counter == 0)
                {
                    Dummy_Data = Channel_Dummy_Data_1;
                }
                else if (Dummy_Counter == 1)
                {
                    Dummy_Data = Channel_Dummy_Data_2;
                }
                else if (Dummy_Counter == 2)
                {
                    Dummy_Data = Channel_Dummy_Data_3;
                }
                else
                {
                    Dummy_Data = Channel_Dummy_Data_4;
                    Dummy_Counter = 0;
                }

                Dummy_Counter++;

                YT_Graphs_Data_Passthrough(Dummy_Data, Dummy_Data, Dummy_Data, Dummy_Data);
                XY_Graphs_Data_Passthrough(Dummy_Data, Dummy_Data, Dummy_Data, Dummy_Data);
                Single_Math_Graphs_Data_Passthrough(Dummy_Data, Dummy_Data, Dummy_Data, Dummy_Data);
                Dual_Math_Graphs_Data_Passthrough(Dummy_Data, Dummy_Data, Dummy_Data, Dummy_Data);
                Histogram_Graphs_Data_Passthrough(Dummy_Data, Dummy_Data, Dummy_Data, Dummy_Data);
                FFT_Graphs_Data_Passthrough(Dummy_Data, Dummy_Data, Dummy_Data, Dummy_Data);
                FFT_Waveform_Graphs_Data_Passthrough(Dummy_Data, Dummy_Data, Dummy_Data, Dummy_Data);
                FFT_Waterfall_Graphs_Data_Passthrough(Dummy_Data, Dummy_Data, Dummy_Data, Dummy_Data);
                Data_Log_Graphs_Data_Passthrough(Dummy_Data, Dummy_Data, Dummy_Data, Dummy_Data);
                Waveform_Calculator_Data_Passthrough(Dummy_Data, Dummy_Data, Dummy_Data, Dummy_Data);
                Waveform_Player_Data_Passthrough(Dummy_Data, Dummy_Data, Dummy_Data, Dummy_Data);
                Demo_Mode_Interval.Restart();
            }
            Demo_Mode_DataProcess_Timer.Enabled = true;
        }
    }
}
