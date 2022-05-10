using Axis_Scale_Config;
using MahApps.Metro.Controls;
using NX_StarWave.Misc;
using NX_StarWave.Waveform_Model_Classes;
using System;
using System.Collections.Concurrent;
using System.Windows;
using System.Windows.Threading;

namespace Histogram
{
    public partial class Histogram_Plotter : MetroWindow
    {
        //Waveform data is initially stored here unit it is removed, processed and displayed on the graph window
        public BlockingCollection<Channel_Waveform_Data> Waveform_Data_Queue = new BlockingCollection<Channel_Waveform_Data>();

        private double[] X_Waveform_Values = new double[500];
        private double[] Y_Waveform_Values = new double[500];

        //Waveform Curve
        private ScottPlot.Plottable.BarPlot Histogram;
        private MathNet.Numerics.Statistics.Histogram Histogram_Data;
        private int Histogram_Data_Counter = 0;

        //Histogram Values
        private int Histogram_Values_Size = 1_000_000;
        private double[] Histogram_Values = new double[1_000_000];
        private double[] values;
        private double[] positions;
        private bool Continuous_Histogram = false;
        private bool Clear_Continuous_Histogram = false;

        private string Y_AXIS_Units = "V";
        private string Y_AXIS_Title = "Voltage (V)";

        //These timers periodically check for any data inserted into Data_Queue, and processs it and insert it into the graph
        private System.Timers.Timer Waveform_Data_Process;

        private Helpful_Functions Functions = new Helpful_Functions();
        private Axis_Config Axis_Scale_Config = new Axis_Config();

        public Histogram_Plotter(string Title, string Channel_Title, string Color, string Y_AXIS_Units = "V", string Y_AXIS_Title = "Voltage (V)", Channel_Waveform_Data Initial_Waveform_Data = null, int Bucket_Count = 0)
        {
            InitializeComponent();
            DataContext = this;
            this.Y_AXIS_Units = Y_AXIS_Units;
            this.Y_AXIS_Title = Y_AXIS_Title;
            Graph_RightClick_Menu();
            Initialize_Waveform_Curve(Channel_Title, Color);
            Update_Window_Title(Title);

            if (Bucket_Count > 0)
            {
                Total_Bucket_Count = Bucket_Count;
            }

            Initialize_Timers();
            if (Initial_Waveform_Data != null)
            {
                Waveform_Data_Queue.Add(Initial_Waveform_Data);
            }
        }

        private void Update_Window_Title(string Title)
        {
            Window_Title = Title;
        }

        public void Initialize_Waveform_Curve(string Label, string Color)
        {
            if (ControlzEx.Theming.ThemeManager.Current.DetectTheme().BaseColorScheme.Equals("Dark"))
            {
                Graph.Plot.Style(ScottPlot.Style.Black);
                Graph.Plot.YAxis.Color(color: System.Drawing.ColorTranslator.FromHtml("#FFFFFFFF"));
                Graph.Plot.XAxis.Color(color: System.Drawing.ColorTranslator.FromHtml("#FFFFFFFF"));
            }

            Axis_Scale_Config.Y_Axis_Units = Y_AXIS_Units;
            Graph.Plot.XAxis.TickLabelFormat(Axis_Scale_Config.Y_Axis_SI_Prefix_Scale);

            Histogram = Graph.Plot.AddBar(Y_Waveform_Values, color: System.Drawing.ColorTranslator.FromHtml(Color));
            Histogram.BorderLineWidth = 0;
            Histogram.BorderColor = System.Drawing.Color.Transparent;
            Histogram.ValueFormatter = x => Histogram_Value_above_Bars_Format(x);

            Graph.Plot.XAxis.Label(Y_AXIS_Title);
            Graph.Plot.YAxis.Label("Count #");
            Graph.Render();
        }

        private void Initialize_Timers()
        {
            Waveform_Data_Process = new System.Timers.Timer(100);
            Waveform_Data_Process.Elapsed += Waveform_Data_Process_Graph;
            Waveform_Data_Process.AutoReset = false;
            Waveform_Data_Process.Enabled = true;
        }

        private void Waveform_Data_Process_Graph(object sender, EventArgs e)
        {
            while (Waveform_Data_Queue.Count > 0)
            {
                try
                {
                    Channel_Waveform_Data CH = Waveform_Data_Queue.Take();
                    if (CH.Valid)
                    {
                        (Total_Time, Start_Time, Stop_Time, Channel_Info) = (CH.Total_Time, CH.Start_Time, CH.Stop_Time, CH.Channel_Info);

                        if (Data_Points == CH.Data_Points)
                        {
                            System.Array.Copy(CH.X_Data, X_Waveform_Values, Data_Points);
                            System.Array.Copy(CH.Y_Data, Y_Waveform_Values, Data_Points);
                        }
                        else
                        {
                            Data_Points = CH.Data_Points;
                            X_Waveform_Values = new double[Data_Points];
                            Y_Waveform_Values = new double[Data_Points];
                            System.Array.Copy(CH.X_Data, X_Waveform_Values, Data_Points);
                            System.Array.Copy(CH.Y_Data, Y_Waveform_Values, Data_Points);
                        }

                        if (Clear_Continuous_Histogram)
                        {
                            Clear_Histogram_Continuous_Data();
                        }

                        if (Continuous_Histogram)
                        {
                            if ((Histogram_Data_Counter > Histogram_Values_Size) || ((Histogram_Values_Size - Histogram_Data_Counter) < Y_Waveform_Values.Length))
                            {
                                Histogram_Values_Size = Histogram_Values_Size + 1_000_000;
                                Array.Resize(ref Histogram_Values, Histogram_Values_Size);
                            }
                            for (int i = 0; i < Y_Waveform_Values.Length; i++)
                            {
                                Histogram_Values[Histogram_Data_Counter] = Y_Waveform_Values[i];
                                Histogram_Data_Counter++;
                            }
                            double[] Values = new double[Histogram_Data_Counter];
                            for (int i = 0; i < Histogram_Data_Counter; i++)
                            {
                                Values[i] = Histogram_Values[i];
                            }
                            Histogram_Data = new MathNet.Numerics.Statistics.Histogram(Values, Total_Bucket_Count);
                            Histogram_Create();
                        }
                        else
                        {
                            Histogram_Data = new MathNet.Numerics.Statistics.Histogram(Y_Waveform_Values, Total_Bucket_Count);
                            Histogram_Create();
                        }

                        this.Dispatcher.Invoke(() =>
                        {
                            Graph_Render();
                        }, DispatcherPriority.Normal);
                    }
                }
                catch (Exception Ex)
                {
                    Insert_Log(Ex.Message, 1);
                    Insert_Log("Waveform Data could not be processed.", 1);
                }
            }
            Waveform_Data_Process.Enabled = true;
        }

        private void Clear_Histogram_Continuous_Data()
        {
            Clear_Continuous_Histogram = false;
            Histogram_Values_Size = 1_000_000;
            Histogram_Data_Counter = 0;
            Histogram_Values = null;
            Histogram_Values = new double[Histogram_Values_Size];
        }

        private void Histogram_Create()
        {
            values = new double[Histogram_Data.BucketCount];
            positions = new double[Histogram_Data.BucketCount];
            for (int i = 0; i < Histogram_Data.BucketCount; i++)
            {
                values[i] = Histogram_Data[i].Count;
                positions[i] = Histogram_Data[i].LowerBound;
                if (double.IsNaN(values[i]) || double.IsInfinity(values[i]))
                {
                    values[i] = 0;
                }
                if (double.IsNaN(positions[i]) || double.IsInfinity(positions[i]))
                {
                    positions[i] = 0;
                }
            }
            Bucket_Count = Histogram_Data.BucketCount;
            Data_Count = Histogram_Data.DataCount;
            LowerBound = Histogram_Data.LowerBound;
            UpperBound = Histogram_Data.UpperBound;
        }

        private void Graph_Render()
        {
            Histogram_Updater();
            Information_Tab_Updater();
            Graph.Render();
        }

        private void Histogram_Updater()
        {
            Histogram.Values = values;
            Histogram.Positions = positions;
            Histogram.ValueErrors = ScottPlot.DataGen.Zeros(values.Length);
            Histogram.ValueOffsets = ScottPlot.DataGen.Zeros(values.Length);
            if (double.IsInfinity(Histogram_Data[0].Width / 2) || double.IsNaN(Histogram_Data[0].Width / 2))
            {
                Histogram.PositionOffset = 0;
            }
            else
            {
                Histogram.PositionOffset = Histogram_Data[0].Width / 2;
            }
            if (Histogram_Data[0].Width > 0.000000000001)
            {
                Histogram.BarWidth = Histogram_Data[0].Width;
            }
            else
            {
                Histogram.BarWidth = 0.01;
            }
            if (AutoAxis.IsChecked == true)
            {
                Graph.Plot.AxisAuto();
            }
            Graph.Refresh();
        }

        private void Continuous_Option_Click(object sender, RoutedEventArgs e)
        {
            if (Continuous_Option.IsChecked)
            {
                Continuous_Histogram = true;
            }
            else
            {
                Continuous_Histogram = false;
                Clear_Continuous_Histogram = true;
            }
        }

        private void Reset_Continuous_Click(object sender, RoutedEventArgs e)
        {
            Clear_Continuous_Histogram = true;
        }
    }
}
