using Axis_Scale_Config;
using MahApps.Metro.Controls;
using NX_StarWave.Misc;
using System;
using System.Collections.Concurrent;
using System.Linq;
using System.Threading;
using System.Windows.Threading;

namespace Channel_DataLogger
{

    public partial class CH_DataLog_Graph_Window : MetroWindow
    {
        //Set Window Title, helps determine which instrument owns this Graph Window
        private string Graph_Owner = "";

        //These timers periodically check for any data inserted into Data_Queue, and processs it and insert it into the graph
        private System.Timers.Timer DataProcess;
        private DispatcherTimer GraphRender;

        //When this is set to true, the graph will be reset
        private bool Graph_Reset = false;

        //Data is initially stored in this queue before being processed and stored in the measurement array and date time array.
        //Each of the element stored inside the queue contains the measurement data and the date time data of when the measurement was captured.
        public BlockingCollection<double[]> Data_Queue = new BlockingCollection<double[]>();

        //Arrays are fixed sized, this variable determines the initial Array size. Its value will increase as Arrays get filled with measurement data
        private int Max_Allowed_Samples = 1_000_000;

        //All the processed measuremnt data is stored in this array and displayed on the GUI window.
        private double[] Measurement_Data = new double[1_000_000];

        // A counter that is incremented when a measurement is processed. Show how many measuremnet is displayed on the GUI window.
        private int Measurement_Count = 0; //For testing set

        // Measurement Units
        private readonly string Measurement_Unit = "V";
        private string Graph_Y_Axis_Label;

        //Measurement Plot, processed data is plotted onto the graph
        private ScottPlot.Plottable.SignalPlot Measurement_Plot;

        private Helpful_Functions Functions = new Helpful_Functions();
        private Axis_Config Axis_Scale_Config = new Axis_Config();

        public CH_DataLog_Graph_Window(string Graph_Y_Axis_Label, string Graph_Owner, string Color)
        {
            InitializeComponent();
            DataContext = this;
            this.Graph_Y_Axis_Label = Graph_Y_Axis_Label;
            this.Title = Graph_Owner + " Data Log";
            this.Graph_Owner = Graph_Owner;
            Add_Main_Plot(Graph_Y_Axis_Label);
            Initialize_Timers();
            Graph_RightClick_Menu();
            Set_Default_GraphColor_Math_AllSamples(Color);
            Set_Default_GraphColor_Math_NSamples(Color);
            Set_Default_Histogram_Color(Color);
        }

        private void Initialize_Timers()
        {
            DataProcess = new System.Timers.Timer(100);
            DataProcess.Elapsed += Data_Insert_Graph;
            DataProcess.AutoReset = false;
            DataProcess.Enabled = true;

            GraphRender = new DispatcherTimer();
            GraphRender.Tick += Graph_Renderer;
            GraphRender.Interval = TimeSpan.FromSeconds(1);
            GraphRender.Start();
        }

        private void Data_Insert_Graph(object sender, EventArgs e)
        {

            if (Graph_Reset == true)
            {
                Measurement_Count = 0;

                Total_Samples = 0;
                Positive_Samples = 0;
                Negative_Samples = 0;
                Latest_Sample = 0;
                Moving_Average = 0;
                Max_Recorded_Sample = double.MinValue;
                Min_Recorded_Sample = double.MaxValue;
                Moving_Average = 0;
                Moving_average_count = 0;

                Max_Allowed_Samples = 1_000_000;
                Array.Resize(ref Measurement_Data, Max_Allowed_Samples);
                Measurement_Plot.Ys = Measurement_Data;

                if (Zoom_Control_Window_IsEnabled)
                {
                    Zoom_Waveform_Curve.Ys = Measurement_Data;
                }

                Update_Measurement_Unit();
                while (Data_Queue.TryTake(out _)) { }

                Insert_Log("Graph has been reset.", 0);

                Graph_Reset = false;
            }

            while (Data_Queue.Count > 0)
            {
                double[] Measurements = Data_Queue.Take().ToArray();

                if ((Measurement_Count >= Max_Allowed_Samples) || (Max_Allowed_Samples - Measurement_Count < Measurements.Length))
                {
                    Max_Allowed_Samples = Max_Allowed_Samples + 1_000_000 + Measurements.Length;
                    Array.Resize(ref Measurement_Data, Max_Allowed_Samples);
                    Measurement_Plot.Ys = Measurement_Data;
                    Insert_Log("Graph Data Array has been resized to allow for more data.", 0);

                    if (Zoom_Control_Window_IsEnabled)
                    {
                        Zoom_Waveform_Curve.Ys = Measurement_Data;
                    }
                }

                for (int i = 0; i < Measurements.Length; i++)
                {
                    Measurement_Data[Measurement_Count] = Measurements[i];
                    Measurement_Plot.MaxRenderIndex = Measurement_Count;

                    if (Zoom_Control_Window_IsEnabled)
                    {
                        Zoom_Waveform_Curve.MaxRenderIndex = Measurement_Count;
                    }

                    Measurement_Count += 1;
                    ++Total_Samples;
                    Latest_Sample = Measurements[i];
                    if (Measurements[i] >= 0)
                    {
                        ++Positive_Samples;
                    }
                    else
                    {
                        ++Negative_Samples;
                    }
                    if (Measurements[i] > Max_Recorded_Sample)
                    {
                        Max_Recorded_Sample = Measurements[i];
                    }
                    if (Measurements[i] < Min_Recorded_Sample)
                    {
                        Min_Recorded_Sample = Measurements[i];
                    }
                    Calculate_Moving_Average(Measurements[i]);
                }
            }
            DataProcess.Enabled = true;
        }

        private void Calculate_Moving_Average(double measurement)
        {
            Moving_average_count += 1;
            Moving_Average = Moving_Average + (measurement - Moving_Average) / Math.Min(Moving_average_count, Moving_average_factor);
        }

        private void Graph_Renderer(object sender, EventArgs e)
        {
            try
            {
                if (Measurement_Count > 0)
                {
                    Total_Samples_Label.Content = Total_Samples;
                    Positive_Samples_Label.Content = Positive_Samples;
                    Negative_Samples_Label.Content = Negative_Samples;
                    Latest_Sample_Label.Content = (decimal)Latest_Sample;
                    Max_Recorded_Sample_Label.Content = (decimal)Max_Recorded_Sample;
                    Min_Recorded_Sample_Label.Content = (decimal)Min_Recorded_Sample;
                    Moving_Average_Label.Content = (decimal)Math.Round(Moving_Average, Moving_average_resolution);

                    if (Auto_Axis_Enable.IsChecked == true)
                    {
                        Graph.Plot.AxisAuto();
                    }

                    Graph.Render();

                    if (Zoom_Control_Window_IsEnabled)
                    {
                        Zoom_Control_Plot.Plot.AxisAuto();
                        Zoom_Control_Plot.Refresh();
                    }
                }
            }
            catch (Exception Ex)
            {
                Insert_Log(Ex.Message, 1);
                Insert_Log("Graph Renderer Failed. Don't worry, trying again.", 1);
            }
        }

        private void Add_Main_Plot(string Graph_Y_Axis_Label)
        {
            if (ControlzEx.Theming.ThemeManager.Current.DetectTheme().BaseColorScheme.Equals("Dark"))
            {
                Graph.Plot.Style(ScottPlot.Style.Black);
                Graph.Plot.YAxis.Color(color: System.Drawing.ColorTranslator.FromHtml("#FFFFFFFF"));
                Graph.Plot.XAxis.Color(color: System.Drawing.ColorTranslator.FromHtml("#FFFFFFFF"));
            }
            Axis_Scale_Config.X_Axis_Units = "#";
            Graph.Plot.XAxis.TickLabelFormat(Axis_Scale_Config.X_Axis_Time_SI_Prefix_Scale);
            Graph.Plot.YAxis.TickLabelFormat(Axis_Scale_Config.Y_Axis_SI_Prefix_Scale);
            Measurement_Plot = Graph.Plot.AddSignal(Measurement_Data, label: Graph_Y_Axis_Label);
            Measurement_Plot.UseParallel = true;
            Measurement_Plot.MarkerSize = 1;
            Graph.Plot.XLabel("N Samples (#)");
            Graph.Plot.YLabel(Graph_Y_Axis_Label);
            Measurement_Plot.MaxRenderIndex = 0;
            Update_Measurement_Unit();
            Graph.Render();
        }

        private void Update_Measurement_Unit()
        {
            this.Dispatcher.Invoke(DispatcherPriority.ContextIdle, new ThreadStart(delegate
            {
                Max_Recorded_Sample_Label_Unit.Content = Measurement_Unit;
                Min_Recorded_Sample_Label_Unit.Content = Measurement_Unit;
                Latest_Sample_Label_Unit.Content = Measurement_Unit;
                Moving_Average_Label_Unit.Content = Measurement_Unit;
                Graph.Plot.YLabel(Graph_Y_Axis_Label);
                Measurement_Plot.Label = Measurement_Unit;
            }));
        }
    }
}
