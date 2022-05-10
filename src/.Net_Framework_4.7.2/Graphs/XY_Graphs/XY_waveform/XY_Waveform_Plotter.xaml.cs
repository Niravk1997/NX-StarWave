using Axis_Scale_Config;
using MahApps.Metro.Controls;
using MathNet.Numerics.Statistics;
using NX_StarWave.Misc;
using NX_StarWave.Waveform_Model_Classes;
using ScottPlot;
using System;
using System.Collections.Concurrent;
using System.Windows.Threading;

namespace XY_Waveform
{
    public partial class XY_Waveform_Plotter : MetroWindow
    {
        //Waveform data is initially stored here unit it is removed, processed and displayed on the graph window
        public BlockingCollection<All_Channels_Data> All_Channels_Data_Queue = new BlockingCollection<All_Channels_Data>();

        //Waveform Curve
        private ScottPlot.Plottable.ScatterPlot Waveform_Curve;
        private ScottPlot.Plottable.SignalPlotXY Channel_1_Curve;
        private ScottPlot.Plottable.SignalPlotXY Channel_2_Curve;

        //Waveform Curve Initial X,Y Array
        private double[] CH1_X_Waveform_Values = new double[500];
        private double[] CH1_Y_Waveform_Values = new double[500];

        private double[] CH2_X_Waveform_Values = new double[500];
        private double[] CH2_Y_Waveform_Values = new double[500];

        //These timers periodically check for any data inserted into Data_Queue, and process it and inserts it into the graph
        private System.Timers.Timer Waveform_Data_Process;

        private Helpful_Functions Functions = new Helpful_Functions();
        private Axis_Config Axis_Scale_Config = new Axis_Config();

        private int Max_Data_Points_Allowed = 2001;

        public XY_Waveform_Plotter(string Title)
        {
            InitializeComponent();
            DataContext = this;
            Graph_RightClick_Menu();
            Initialize_Waveforms_Curve();
            Update_Window_Title(Title);
            Initialize_Timers();
        }

        private void Update_Window_Title(string Title)
        {
            Window_Title = Title;
        }

        public void Initialize_Waveforms_Curve()
        {
            if (ControlzEx.Theming.ThemeManager.Current.DetectTheme().BaseColorScheme.Equals("Dark"))
            {
                Graph.Plot.Style(ScottPlot.Style.Black);
                Graph.Plot.YAxis.Color(color: System.Drawing.ColorTranslator.FromHtml("#FFFFFFFF"));
                Graph.Plot.XAxis.Color(color: System.Drawing.ColorTranslator.FromHtml("#FFFFFFFF"));

                Waveform_Graph.Plot.Style(ScottPlot.Style.Black);
                Waveform_Graph.Plot.YAxis.Color(color: System.Drawing.ColorTranslator.FromHtml("#FFFFFFFF"));
                Waveform_Graph.Plot.XAxis.Color(color: System.Drawing.ColorTranslator.FromHtml("#FFFFFFFF"));
            }
            Graph.Plot.XAxis.TickLabelFormat(Axis_Scale_Config.Y_Axis_SI_Prefix_Scale);
            Graph.Plot.YAxis.TickLabelFormat(Axis_Scale_Config.Y_Axis_SI_Prefix_Scale);
            Waveform_Curve = Graph.Plot.AddScatter(CH1_Y_Waveform_Values, CH2_Y_Waveform_Values, color: System.Drawing.ColorTranslator.FromHtml("#29a329"), markerShape: MarkerShape.none, label: "Lissajous Pattern");
            Waveform_Curve.MarkerSize = 1;
            Graph.Plot.XAxis.Label("CH1");
            Graph.Plot.YAxis.Label("CH2");

            Waveform_Graph.Plot.XAxis.TickLabelFormat(Axis_Scale_Config.X_Axis_Time_SI_Prefix_Scale);
            Waveform_Graph.Plot.YAxis.TickLabelFormat(Axis_Scale_Config.Y_Axis_SI_Prefix_Scale);
            Channel_1_Curve = Waveform_Graph.Plot.AddSignalXY(CH1_X_Waveform_Values, CH1_Y_Waveform_Values, color: System.Drawing.ColorTranslator.FromHtml("#0072BD"), label: "CH1");
            Channel_1_Curve.MarkerSize = 1;
            Channel_1_Curve.MaxRenderIndex = 0;
            Channel_2_Curve = Waveform_Graph.Plot.AddSignalXY(CH2_X_Waveform_Values, CH2_Y_Waveform_Values, color: System.Drawing.ColorTranslator.FromHtml("#FFFF8C00"), label: "CH2");
            Channel_2_Curve.MarkerSize = 1;
            Channel_2_Curve.MaxRenderIndex = 0;
            Waveform_Graph.Plot.XAxis.Label("Time (s)");
            Waveform_Graph.Plot.YAxis.Label("Channels (v)");

            Graph.Plot.Legend(true);
            Waveform_Graph.Plot.Legend(true);
            Graph.Render();
            Waveform_Graph.Render();
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
            while (All_Channels_Data_Queue.Count > 0)
            {

                (bool isValid, (double[] CH1_X_Data, double[] CH1_Y_Data, double CH1_Total_Time, double CH1_Start_Time, double CH1_Stop_Time, int CH1_Data_Points, string CH1_Info), (double[] CH2_X_Data, double[] CH2_Y_Data, double CH2_Total_Time, double CH2_Start_Time, double CH2_Stop_Time, int CH2_Data_Points, string CH2_Info)) = All_Channels_Queue_Take();
                if (isValid)
                {
                    try
                    {
                        (CH1_X_Waveform_Values, CH1_Y_Waveform_Values, this.CH1_Total_Time, this.CH1_Start_Time, this.CH1_Stop_Time, this.CH1_Data_Points, this.CH1_Channel_Info) = (CH1_X_Data, CH1_Y_Data, CH1_Total_Time, CH1_Start_Time, CH1_Stop_Time, CH1_Data_Points, CH1_Info);
                        (CH2_X_Waveform_Values, CH2_Y_Waveform_Values, this.CH2_Total_Time, this.CH2_Start_Time, this.CH2_Stop_Time, this.CH2_Data_Points, this.CH2_Channel_Info) = (CH2_X_Data, CH2_Y_Data, CH2_Total_Time, CH2_Start_Time, CH2_Stop_Time, CH2_Data_Points, CH2_Info);
                        Waveform_Measurements_Updater();
                        this.Dispatcher.Invoke(() =>
                        {
                            Graph_Render();
                        }, DispatcherPriority.Normal);
                    }
                    catch (Exception Ex)
                    {
                        Insert_Log(Ex.Message, 1);
                        Insert_Log("Waveform Data could not be processed.", 1);
                    }
                }
            }
            Waveform_Data_Process.Enabled = true;
        }

        private void Waveform_Measurements_Updater()
        {
            CH1_Wavefrom_Mean = ArrayStatistics.Mean(CH1_Y_Waveform_Values);
            CH1_Wavefrom_MAX = ArrayStatistics.Maximum(CH1_Y_Waveform_Values);
            CH1_Wavefrom_MIN = ArrayStatistics.Minimum(CH1_Y_Waveform_Values);
            CH1_Wavefrom_PKPK = CH1_Wavefrom_MAX - CH1_Wavefrom_MIN;
            CH1_Wavefrom_RMS = ArrayStatistics.RootMeanSquare(CH1_Y_Waveform_Values);

            CH2_Wavefrom_Mean = ArrayStatistics.Mean(CH2_Y_Waveform_Values);
            CH2_Wavefrom_MAX = ArrayStatistics.Maximum(CH2_Y_Waveform_Values);
            CH2_Wavefrom_MIN = ArrayStatistics.Minimum(CH2_Y_Waveform_Values);
            CH2_Wavefrom_PKPK = CH2_Wavefrom_MAX - CH2_Wavefrom_MIN;
            CH2_Wavefrom_RMS = ArrayStatistics.RootMeanSquare(CH2_Y_Waveform_Values);
        }

        private void Graph_Render()
        {
            if (CH1_Data_Points < Max_Data_Points_Allowed)
            {
                Waveform_Curve.Update(CH1_Y_Waveform_Values, CH2_Y_Waveform_Values);
            }
            else
            {
                Insert_Log("XY Plot cannot be plotted when Waveform Data Points exceed 2K.", 1);
            }
            Channel_1_Curve.MaxRenderIndex = 0;
            Channel_1_Curve.Xs = CH1_X_Waveform_Values;
            Channel_1_Curve.Ys = CH1_Y_Waveform_Values;
            Channel_1_Curve.MaxRenderIndex = CH1_X_Waveform_Values.Length - 1;
            Channel_2_Curve.MaxRenderIndex = 0;
            Channel_2_Curve.Xs = CH2_X_Waveform_Values;
            Channel_2_Curve.Ys = CH2_Y_Waveform_Values;
            Channel_2_Curve.MaxRenderIndex = CH2_X_Waveform_Values.Length - 1;
            Information_Tab_Updater();
            if (Auto_Axis_Enable.IsChecked)
            {
                Graph.Plot.AxisAuto();
            }
            if (Waveform_Auto_Axis)
            {
                Waveform_Graph.Plot.AxisAuto();
            }
            Waveform_Graph.Render();
            Graph.Render();
        }

        private (bool, (double[], double[], double, double, double, int, string), (double[], double[], double, double, double, int, string)) All_Channels_Queue_Take()
        {
            All_Channels_Data Channels_Data = All_Channels_Data_Queue.Take();

            (double[] N1, double[] N2, double N3, double N4, double N5, int N6, string N7) Empty_Tuple = (new double[5], new double[5], 0, 0, 0, 0, "");

            bool Channel_1_Data_Valid = false;
            (double[] N1, double[] N2, double N3, double N4, double N5, int N6, string N7) Channel_1_Data = Empty_Tuple;

            bool Channel_2_Data_Valid = false;
            (double[] N1, double[] N2, double N3, double N4, double N5, int N6, string N7) Channel_2_Data = Empty_Tuple;

            switch (Channel_1_Selected)
            {
                //Channel 1
                case 0:
                    if (Channels_Data.CH1.Valid)
                    {
                        Channel_1_Data_Valid = true;
                        if (Channels_Data.CH1.Data_Points <= Max_Data_Points_Allowed)
                        {
                            Channel_1_Data = (Copy_Array(Channels_Data.CH1.X_Data, Channels_Data.CH1.Data_Points), Copy_Array(Channels_Data.CH1.Y_Data, Channels_Data.CH1.Data_Points), Channels_Data.CH1.Total_Time, Channels_Data.CH1.Start_Time, Channels_Data.CH1.Stop_Time, Channels_Data.CH1.Data_Points, Channels_Data.CH1.Channel_Info);
                        }
                    }
                    break;
                //Channel 2
                case 1:
                    if (Channels_Data.CH2.Valid)
                    {
                        Channel_1_Data_Valid = true;
                        if (Channels_Data.CH2.Data_Points <= Max_Data_Points_Allowed)
                        {
                            Channel_1_Data = (Copy_Array(Channels_Data.CH2.X_Data, Channels_Data.CH2.Data_Points), Copy_Array(Channels_Data.CH2.Y_Data, Channels_Data.CH2.Data_Points), Channels_Data.CH2.Total_Time, Channels_Data.CH2.Start_Time, Channels_Data.CH2.Stop_Time, Channels_Data.CH2.Data_Points, Channels_Data.CH2.Channel_Info);
                        }
                    }
                    break;
                //Channel 3
                case 2:
                    if (Channels_Data.CH3.Valid)
                    {
                        Channel_1_Data_Valid = true;
                        if (Channels_Data.CH3.Data_Points <= Max_Data_Points_Allowed)
                        {
                            Channel_1_Data = (Copy_Array(Channels_Data.CH3.X_Data, Channels_Data.CH3.Data_Points), Copy_Array(Channels_Data.CH3.Y_Data, Channels_Data.CH3.Data_Points), Channels_Data.CH3.Total_Time, Channels_Data.CH3.Start_Time, Channels_Data.CH3.Stop_Time, Channels_Data.CH3.Data_Points, Channels_Data.CH3.Channel_Info);
                        }
                    }
                    break;
                //Channel 4
                case 3:
                    if (Channels_Data.CH4.Valid)
                    {
                        Channel_1_Data_Valid = true;
                        if (Channels_Data.CH4.Data_Points <= Max_Data_Points_Allowed)
                        {
                            Channel_1_Data = (Copy_Array(Channels_Data.CH4.X_Data, Channels_Data.CH4.Data_Points), Copy_Array(Channels_Data.CH4.Y_Data, Channels_Data.CH4.Data_Points), Channels_Data.CH4.Total_Time, Channels_Data.CH4.Start_Time, Channels_Data.CH4.Stop_Time, Channels_Data.CH4.Data_Points, Channels_Data.CH4.Channel_Info);
                        }
                    }
                    break;
                default:
                    break;
            }

            switch (Channel_2_Selected)
            {
                //Channel 1
                case 0:
                    if (Channels_Data.CH1.Valid)
                    {
                        Channel_2_Data_Valid = true;
                        if (Channels_Data.CH1.Data_Points <= Max_Data_Points_Allowed)
                        {
                            Channel_2_Data = (Copy_Array(Channels_Data.CH1.X_Data, Channels_Data.CH1.Data_Points), Copy_Array(Channels_Data.CH1.Y_Data, Channels_Data.CH1.Data_Points), Channels_Data.CH1.Total_Time, Channels_Data.CH1.Start_Time, Channels_Data.CH1.Stop_Time, Channels_Data.CH1.Data_Points, Channels_Data.CH1.Channel_Info);
                        }
                    }
                    break;
                //Channel 2
                case 1:
                    if (Channels_Data.CH2.Valid)
                    {
                        Channel_2_Data_Valid = true;
                        if (Channels_Data.CH2.Data_Points <= Max_Data_Points_Allowed)
                        {
                            Channel_2_Data = (Copy_Array(Channels_Data.CH2.X_Data, Channels_Data.CH2.Data_Points), Copy_Array(Channels_Data.CH2.Y_Data, Channels_Data.CH2.Data_Points), Channels_Data.CH2.Total_Time, Channels_Data.CH2.Start_Time, Channels_Data.CH2.Stop_Time, Channels_Data.CH2.Data_Points, Channels_Data.CH2.Channel_Info);
                        }
                    }
                    break;
                //Channel 3
                case 2:
                    if (Channels_Data.CH3.Valid)
                    {
                        Channel_2_Data_Valid = true;
                        if (Channels_Data.CH3.Data_Points <= Max_Data_Points_Allowed)
                        {
                            Channel_2_Data = (Copy_Array(Channels_Data.CH3.X_Data, Channels_Data.CH3.Data_Points), Copy_Array(Channels_Data.CH3.Y_Data, Channels_Data.CH3.Data_Points), Channels_Data.CH3.Total_Time, Channels_Data.CH3.Start_Time, Channels_Data.CH3.Stop_Time, Channels_Data.CH3.Data_Points, Channels_Data.CH3.Channel_Info);
                        }
                    }
                    break;
                //Channel 4
                case 3:
                    if (Channels_Data.CH4.Valid)
                    {
                        Channel_2_Data_Valid = true;
                        if (Channels_Data.CH4.Data_Points <= Max_Data_Points_Allowed)
                        {
                            Channel_2_Data = (Copy_Array(Channels_Data.CH4.X_Data, Channels_Data.CH4.Data_Points), Copy_Array(Channels_Data.CH4.Y_Data, Channels_Data.CH4.Data_Points), Channels_Data.CH4.Total_Time, Channels_Data.CH4.Start_Time, Channels_Data.CH4.Stop_Time, Channels_Data.CH4.Data_Points, Channels_Data.CH4.Channel_Info);
                        }
                    }
                    break;
                default:
                    break;
            }

            if (Channel_1_Data_Valid & Channel_2_Data_Valid)
            {

                return (true, Channel_1_Data, Channel_2_Data);
            }
            else
            {
                return (false, Empty_Tuple, Empty_Tuple);
            }
        }

        private double[] Copy_Array(double[] Old_Array, int Length)
        {
            double[] New_Array = new double[Length];
            System.Array.Copy(Old_Array, New_Array, Length);
            return New_Array;
        }
    }
}
