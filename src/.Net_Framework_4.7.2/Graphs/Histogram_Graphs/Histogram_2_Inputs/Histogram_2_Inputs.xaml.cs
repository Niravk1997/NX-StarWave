using Axis_Scale_Config;
using MahApps.Metro.Controls;
using NX_StarWave.Misc;
using NX_StarWave.Waveform_Model_Classes;
using System;
using System.Collections.Concurrent;
using System.Windows.Threading;

namespace Histogram_2_Input
{
    public partial class Histogram_2_Input_Window : MetroWindow
    {
        //Waveform data is initially stored here unit it is removed, processed and displayed on the graph window
        public BlockingCollection<Channel_Waveform_Data> Input_1_Data_Queue = new BlockingCollection<Channel_Waveform_Data>();
        public BlockingCollection<Channel_Waveform_Data> Input_2_Data_Queue = new BlockingCollection<Channel_Waveform_Data>();

        private double[] Input_1_X_Waveform_Values = new double[500];
        private double[] Input_1_Y_Waveform_Values = new double[500];

        private double[] Input_2_X_Waveform_Values = new double[500];
        private double[] Input_2_Y_Waveform_Values = new double[500];

        private ScottPlot.Plottable.BarPlot Histogram_Input_1;
        private MathNet.Numerics.Statistics.Histogram Histogram_Data_Input_1;
        private double[] Input_1_Histogram_Values;
        private double[] Input_1_Histogram_Positions;

        private ScottPlot.Plottable.BarPlot Histogram_Input_2;
        private MathNet.Numerics.Statistics.Histogram Histogram_Data_Input_2;
        private double[] Input_2_Histogram_Values;
        private double[] Input_2_Histogram_Positions;

        private string Y_AXIS_Units = "V";
        private string Y_AXIS_Title = "Voltage (V)";

        //These timers periodically check for any data inserted into Data_Queue, and processs it and insert it into the graph
        private System.Timers.Timer Waveform_Data_Process;

        private Helpful_Functions Functions = new Helpful_Functions();
        private Axis_Config Axis_Scale_Config = new Axis_Config();

        public Histogram_2_Input_Window(string Title, string Y_AXIS_Units, string Y_AXIS_Title, int Input_1_Bucket_Count, int Input_2_Bucket_Count, string Input_1_Title, string Input_2_Title, string Input_1_Color, string Input_2_Color, Channel_Waveform_Data Input_1_Data = null, Channel_Waveform_Data Input_2_Data = null)
        {
            InitializeComponent();
            DataContext = this;

            Window_Title = Title;
            this.Y_AXIS_Units = Y_AXIS_Units;
            this.Y_AXIS_Title = Y_AXIS_Title;

            this.Input_1_Title = Input_1_Title;
            this.Input_2_Title = Input_2_Title;

            this.Input_1_Histogram_Color = Input_1_Color;
            this.Input_2_Histogram_Color = Input_2_Color;

            this.Input_1_Bucket_Count = Input_1_Bucket_Count;
            this.Input_2_Bucket_Count = Input_2_Bucket_Count;

            Graph_RightClick_Menu();
            Initialize_Waveform_Curve();
            Initialize_Timers();

            if (Input_1_Data != null)
            {
                Input_1_Data_Queue.Add(Input_1_Data);
            }
            if (Input_2_Data != null)
            {
                Input_2_Data_Queue.Add(Input_2_Data);
            }
        }

        private void Initialize_Timers()
        {
            Waveform_Data_Process = new System.Timers.Timer(100);
            Waveform_Data_Process.Elapsed += Waveform_Data_Process_Graph;
            Waveform_Data_Process.AutoReset = false;
            Waveform_Data_Process.Enabled = true;
        }

        public void Initialize_Waveform_Curve()
        {
            if (ControlzEx.Theming.ThemeManager.Current.DetectTheme().BaseColorScheme.Equals("Dark"))
            {
                Graph.Plot.Style(ScottPlot.Style.Black);
                Graph.Plot.YAxis.Color(color: System.Drawing.ColorTranslator.FromHtml("#FFFFFFFF"));
                Graph.Plot.XAxis.Color(color: System.Drawing.ColorTranslator.FromHtml("#FFFFFFFF"));
            }

            Axis_Scale_Config.Y_Axis_Units = Y_AXIS_Units;
            Graph.Plot.XAxis.TickLabelFormat(Axis_Scale_Config.Y_Axis_SI_Prefix_Scale);

            Histogram_Input_1 = Graph.Plot.AddBar(Input_1_Y_Waveform_Values, color: System.Drawing.ColorTranslator.FromHtml(Input_1_Histogram_Color));
            Histogram_Input_1.Label = Input_1_Title;
            Histogram_Input_1.BorderColor = System.Drawing.Color.Transparent;
            Histogram_Input_1.BorderLineWidth = 0;
            Histogram_Input_1.ValueFormatter = x => Histogram_Value_above_Bars_Format(x);

            Histogram_Input_2 = Graph.Plot.AddBar(Input_2_Y_Waveform_Values, color: System.Drawing.ColorTranslator.FromHtml(Input_2_Histogram_Color));
            Histogram_Input_2.Label = Input_2_Title;
            Histogram_Input_2.BorderColor = System.Drawing.Color.Transparent;
            Histogram_Input_2.BorderLineWidth = 0;
            Histogram_Input_2.ValueFormatter = x => Histogram_Value_above_Bars_Format(x);

            Graph.Plot.Legend(true, ScottPlot.Alignment.LowerRight);
            Graph.Plot.XAxis.Label(Y_AXIS_Title);
            Graph.Plot.YAxis.Label("Count #");
            Graph.Render();
        }

        private void Waveform_Data_Process_Graph(object sender, EventArgs e)
        {
            while (Input_1_Data_Queue.Count > 0 || Input_2_Data_Queue.Count > 0)
            {
                bool Histogram_1_needs_Updating = false;
                bool Histogram_2_needs_Updating = false;

                if (Input_1_Data_Queue.Count > 0)
                {
                    try
                    {
                        Channel_Waveform_Data Input_1_Data = Input_1_Data_Queue.Take();
                        (Input_1_Total_Time, Input_1_Start_Time, Input_1_Stop_Time, Input_1_Channel_Info) = (Input_1_Data.Total_Time, Input_1_Data.Start_Time, Input_1_Data.Stop_Time, Input_1_Data.Channel_Info);

                        if (Input_1_Data_Points == Input_1_Data.Data_Points)
                        {
                            System.Array.Copy(Input_1_Data.X_Data, Input_1_X_Waveform_Values, Input_1_Data_Points);
                            System.Array.Copy(Input_1_Data.Y_Data, Input_1_Y_Waveform_Values, Input_1_Data_Points);
                        }
                        else
                        {
                            Input_1_Data_Points = Input_1_Data.Data_Points;
                            Input_1_X_Waveform_Values = new double[Input_1_Data_Points];
                            Input_1_Y_Waveform_Values = new double[Input_1_Data_Points];
                            System.Array.Copy(Input_1_Data.X_Data, Input_1_X_Waveform_Values, Input_1_Data_Points);
                            System.Array.Copy(Input_1_Data.Y_Data, Input_1_Y_Waveform_Values, Input_1_Data_Points);
                        }

                        Histogram_Data_Input_1 = new MathNet.Numerics.Statistics.Histogram(Input_1_Y_Waveform_Values, Input_1_Bucket_Count);
                        Input_1_Histogram_Create();
                        Histogram_1_needs_Updating = true;
                    }
                    catch (Exception Ex)
                    {
                        Insert_Log(Ex.Message, 1);
                        Insert_Log("Input 1 Data could not be processed.", 1);
                    }
                }

                if (Input_2_Data_Queue.Count > 0)
                {
                    try
                    {
                        Channel_Waveform_Data Input_2_Data = Input_2_Data_Queue.Take();
                        (Input_2_Total_Time, Input_2_Start_Time, Input_2_Stop_Time, Input_2_Channel_Info) = (Input_2_Data.Total_Time, Input_2_Data.Start_Time, Input_2_Data.Stop_Time, Input_2_Data.Channel_Info);

                        if (Input_2_Data_Points == Input_2_Data.Data_Points)
                        {
                            System.Array.Copy(Input_2_Data.X_Data, Input_2_X_Waveform_Values, Input_2_Data_Points);
                            System.Array.Copy(Input_2_Data.Y_Data, Input_2_Y_Waveform_Values, Input_2_Data_Points);
                        }
                        else
                        {
                            Input_2_Data_Points = Input_2_Data.Data_Points;
                            Input_2_X_Waveform_Values = new double[Input_2_Data_Points];
                            Input_2_Y_Waveform_Values = new double[Input_2_Data_Points];
                            System.Array.Copy(Input_2_Data.X_Data, Input_2_X_Waveform_Values, Input_2_Data_Points);
                            System.Array.Copy(Input_2_Data.Y_Data, Input_2_Y_Waveform_Values, Input_2_Data_Points);
                        }

                        Histogram_Data_Input_2 = new MathNet.Numerics.Statistics.Histogram(Input_2_Y_Waveform_Values, Input_2_Bucket_Count);
                        Input_2_Histogram_Create();
                        Histogram_2_needs_Updating = true;
                    }
                    catch (Exception Ex)
                    {
                        Insert_Log(Ex.Message, 1);
                        Insert_Log("Input 2 Data could not be processed.", 1);
                    }
                }

                this.Dispatcher.Invoke(() =>
                {
                    Graph_Render(Histogram_1_needs_Updating, Histogram_2_needs_Updating);
                }, DispatcherPriority.Normal);
            }

            Waveform_Data_Process.Enabled = true;
        }

        private void Input_1_Histogram_Create()
        {
            int Bucket_Count = Histogram_Data_Input_1.BucketCount;
            Input_1_Histogram_Values = new double[Bucket_Count];
            Input_1_Histogram_Positions = new double[Bucket_Count];
            for (int i = 0; i < Bucket_Count; i++)
            {
                Input_1_Histogram_Values[i] = Histogram_Data_Input_1[i].Count;
                Input_1_Histogram_Positions[i] = Histogram_Data_Input_1[i].LowerBound;
                if (double.IsNaN(Input_1_Histogram_Values[i]) || double.IsInfinity(Input_1_Histogram_Values[i]))
                {
                    Input_1_Histogram_Values[i] = 0;
                }
                if (double.IsNaN(Input_1_Histogram_Positions[i]) || double.IsInfinity(Input_1_Histogram_Positions[i]))
                {
                    Input_1_Histogram_Positions[i] = 0;
                }
            }
            Input_1_Lower_Bound_Text = Axis_Scale_Config.Value_SI_Prefix(Histogram_Data_Input_1.LowerBound, 4) + Y_AXIS_Units;
            Input_1_Upper_Bound_Text = Axis_Scale_Config.Value_SI_Prefix(Histogram_Data_Input_1.UpperBound, 4) + Y_AXIS_Units;
        }

        private void Input_1_Histogram_Updater()
        {
            Histogram_Input_1.Values = Input_1_Histogram_Values;
            Histogram_Input_1.Positions = Input_1_Histogram_Positions;
            Histogram_Input_1.ValueErrors = ScottPlot.DataGen.Zeros(Input_1_Histogram_Values.Length);
            Histogram_Input_1.ValueOffsets = ScottPlot.DataGen.Zeros(Input_1_Histogram_Values.Length);
            if (double.IsInfinity(Histogram_Data_Input_1[0].Width / 2) || double.IsNaN(Histogram_Data_Input_1[0].Width / 2))
            {
                Histogram_Input_1.PositionOffset = 0;
            }
            else
            {
                Histogram_Input_1.PositionOffset = Histogram_Data_Input_1[0].Width / 2;
            }
            if (Histogram_Data_Input_1[0].Width > 0.000000000001)
            {
                Histogram_Input_1.BarWidth = Histogram_Data_Input_1[0].Width;
            }
            else
            {
                Histogram_Input_1.BarWidth = 0.01;
            }
        }

        private void Input_2_Histogram_Create()
        {
            int Bucket_Count = Histogram_Data_Input_2.BucketCount;
            Input_2_Histogram_Values = new double[Bucket_Count];
            Input_2_Histogram_Positions = new double[Bucket_Count];
            for (int i = 0; i < Bucket_Count; i++)
            {
                Input_2_Histogram_Values[i] = Histogram_Data_Input_2[i].Count;
                Input_2_Histogram_Positions[i] = Histogram_Data_Input_2[i].LowerBound;
                if (double.IsNaN(Input_2_Histogram_Values[i]) || double.IsInfinity(Input_2_Histogram_Values[i]))
                {
                    Input_2_Histogram_Values[i] = 0;
                }
                if (double.IsNaN(Input_2_Histogram_Positions[i]) || double.IsInfinity(Input_2_Histogram_Positions[i]))
                {
                    Input_2_Histogram_Positions[i] = 0;
                }
            }
            Input_2_Lower_Bound_Text = Axis_Scale_Config.Value_SI_Prefix(Histogram_Data_Input_2.LowerBound, 4) + Y_AXIS_Units;
            Input_2_Upper_Bound_Text = Axis_Scale_Config.Value_SI_Prefix(Histogram_Data_Input_2.UpperBound, 4) + Y_AXIS_Units;
        }

        private void Input_2_Histogram_Updater()
        {
            Histogram_Input_2.Values = Input_2_Histogram_Values;
            Histogram_Input_2.Positions = Input_2_Histogram_Positions;
            Histogram_Input_2.ValueErrors = ScottPlot.DataGen.Zeros(Input_2_Histogram_Values.Length);
            Histogram_Input_2.ValueOffsets = ScottPlot.DataGen.Zeros(Input_2_Histogram_Values.Length);
            if (double.IsInfinity(Histogram_Data_Input_2[0].Width / 2) || double.IsNaN(Histogram_Data_Input_2[0].Width / 2))
            {
                Histogram_Input_2.PositionOffset = 0;
            }
            else
            {
                Histogram_Input_2.PositionOffset = Histogram_Data_Input_2[0].Width / 2;
            }
            if (Histogram_Data_Input_2[0].Width > 0.000000000001)
            {
                Histogram_Input_2.BarWidth = Histogram_Data_Input_2[0].Width;
            }
            else
            {
                Histogram_Input_2.BarWidth = 0.01;
            }
        }

        private void Graph_Render(bool Histogram_1_needs_Updating, bool Histogram_2_needs_Updating)
        {
            if (Histogram_1_needs_Updating)
            {
                Input_1_Histogram_Updater();
            }

            if (Histogram_2_needs_Updating)
            {
                Input_2_Histogram_Updater();
            }

            if (Axis_Auto)
            {
                Graph.Plot.AxisAuto();
            }

            Graph.Render();
        }
    }
}
