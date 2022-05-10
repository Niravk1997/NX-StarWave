using MahApps.Metro.Controls;
using System;
using System.Collections.Concurrent;
using System.Windows.Threading;

namespace Measurement_Plot
{
    public partial class Measurement_Plot_Window : MetroWindow
    {
        //Measurement data is initially stored here unit it is removed, processed and displayed on the graph window
        public BlockingCollection<(double, double)> Measurement_Data_Queue = new BlockingCollection<(double, double)>();

        private System.Timers.Timer Measurement_Data_Timer;
        private DispatcherTimer GraphRender;

        public bool Measurement_Plot_Reset_Request = false;

        private void Initialize_Timers()
        {
            Measurement_Data_Timer = new System.Timers.Timer();
            Measurement_Data_Timer.Interval = 1000;
            Measurement_Data_Timer.Elapsed += Measurement_Data_Process;
            Measurement_Data_Timer.AutoReset = false;
            Measurement_Data_Timer.Enabled = true;

            GraphRender = new DispatcherTimer();
            GraphRender.Tick += Graph_Renderer;
            GraphRender.Interval = TimeSpan.FromSeconds(1);
            GraphRender.Start();
        }

        private void Measurement_Data_Process(object sender, EventArgs e)
        {
            while (Measurement_Data_Queue.Count > 0)
            {
                try
                {
                    if (Measurement_Plot_Reset_Request)
                    {
                        Measurement_Data_Count = 0;
                        Max_Allowed_Samples = 1_000_000;
                        Array.Resize(ref Measurement_Data, Max_Allowed_Samples);
                        Array.Resize(ref Date_Time, Max_Allowed_Samples);
                        for (int i = 0; i < Max_Allowed_Samples; i++)
                        {
                            Date_Time[i] = double.MaxValue;
                        }
                        Measurement_Plot.Xs = Date_Time;
                        Measurement_Plot.Ys = Measurement_Data;
                        Measurement_Min = double.MaxValue;
                        Measurement_Max = double.MinValue;
                        Measurement_Plot_Reset_Request = false;
                        Insert_Log("Measurement Plot has been reset.", 0);
                    }

                    (double Measurement_Date_Time, double Measurement) = Measurement_Data_Queue.Take();

                    if (Measurement_Data_Count >= Max_Allowed_Samples)
                    {
                        Max_Allowed_Samples = Max_Allowed_Samples + 1_000_000;
                        Array.Resize(ref Measurement_Data, Max_Allowed_Samples);
                        Array.Resize(ref Date_Time, Max_Allowed_Samples);
                        for (int i = Measurement_Data_Count; i < Max_Allowed_Samples; i++)
                        {
                            Date_Time[i] = double.MaxValue;
                        }
                        Measurement_Plot.Xs = Date_Time;
                        Measurement_Plot.Ys = Measurement_Data;
                        Insert_Log("Graph Data Array has been resized to allow for more data.", 0);
                    }

                    Measurement_Data[Measurement_Data_Count] = Measurement;
                    Date_Time[Measurement_Data_Count] = Measurement_Date_Time;
                    Measurement_Plot.MaxRenderIndex = Measurement_Data_Count;
                    Measurement_Data_Count += 1;

                    if (Measurement < Measurement_Min)
                    {
                        Measurement_Min = Measurement;
                    }
                    if (Measurement > Measurement_Max)
                    {
                        Measurement_Max = Measurement;
                    }
                }
                catch (Exception Ex)
                {
                    Insert_Log(Ex.Message, 1);
                }
            }
            Measurement_Data_Timer.Enabled = true;
        }

        private void Graph_Renderer(object sender, EventArgs e)
        {
            try
            {
                if (AutoAxis_MenuItem.IsChecked)
                {
                    Graph.Plot.AxisAuto();
                }
                Graph.Refresh();
            }
            catch (Exception Ex)
            {
                Insert_Log(Ex.Message, 1);
                Insert_Log("Graph Renderer Failed. Don't worry, trying again.", 1);
            }
        }
    }
}
