using Auto_Measurements;
using Axis_Scale_Config;
using MahApps.Metro.Controls;
using NX_StarWave.Misc;
using NX_StarWave.Waveform_Model_Classes;
using ScottPlot;
using System;
using System.Collections.Concurrent;
using System.Windows.Threading;

namespace AllChannels_YT_Square
{
    public partial class AllChannels_YT_Square_Plotter : MetroWindow
    {
        //Waveform data is initially stored here unitl it is removed, processed and displayed on the graph window
        public BlockingCollection<All_Channels_Data> All_Channels_Data_Queue = new BlockingCollection<All_Channels_Data>();

        //Waveform Curve
        private ScottPlot.Plottable.SignalPlotXY Channel_1_Curve;
        private ScottPlot.Plottable.SignalPlotXY Channel_2_Curve;
        private ScottPlot.Plottable.SignalPlotXY Channel_3_Curve;
        private ScottPlot.Plottable.SignalPlotXY Channel_4_Curve;

        //Waveform Curve Initial X,Y Array
        private double[] CH1_X_Values = new double[500];
        private double[] CH1_Y_Values = new double[500];
        private bool CH1_Needs_Updating = false;

        private double[] CH2_X_Values = new double[500];
        private double[] CH2_Y_Values = new double[500];
        private bool CH2_Needs_Updating = false;

        private double[] CH3_X_Values = new double[500];
        private double[] CH3_Y_Values = new double[500];
        private bool CH3_Needs_Updating = false;

        private double[] CH4_X_Values = new double[500];
        private double[] CH4_Y_Values = new double[500];
        private bool CH4_Needs_Updating = false;

        //These timers periodically check for any data inserted into Data_Queue, and processs it and insert it into the graph
        private System.Timers.Timer Waveform_Data_Process;

        private Helpful_Functions Functions = new Helpful_Functions();
        private Axis_Config Axis_Scale_Config = new Axis_Config();
        private Automatic_Measurements Waveform_Measurements = new Automatic_Measurements();

        public AllChannels_YT_Square_Plotter(string Title, string Channel_1_Color, string Channel_2_Color, string Channel_3_Color, string Channel_4_Color)
        {
            InitializeComponent();
            DataContext = this;
            Graphs = new WpfPlot[] { Graph_1, Graph_2, Graph_3, Graph_4 };
            Graph_RightClick_Menu();
            Initialize_Waveform_Curve(Channel_1_Color, Channel_2_Color, Channel_3_Color, Channel_4_Color);
            Update_Window_Title(Title);
            Initialize_Timers();
        }

        private void Update_Window_Title(string Title)
        {
            Window_Title = Title;
        }

        public void Initialize_Waveform_Curve(string Channel_1_Color, string Channel_2_Color, string Channel_3_Color, string Channel_4_Color)
        {
            if (ControlzEx.Theming.ThemeManager.Current.DetectTheme().BaseColorScheme.Equals("Dark"))
            {
                Graph_1.Plot.Style(ScottPlot.Style.Black);
                Graph_1.Plot.YAxis.Color(color: System.Drawing.ColorTranslator.FromHtml("#FFFFFFFF"));
                Graph_1.Plot.XAxis.Color(color: System.Drawing.ColorTranslator.FromHtml("#FFFFFFFF"));

                Graph_2.Plot.Style(ScottPlot.Style.Black);
                Graph_2.Plot.YAxis.Color(color: System.Drawing.ColorTranslator.FromHtml("#FFFFFFFF"));
                Graph_2.Plot.XAxis.Color(color: System.Drawing.ColorTranslator.FromHtml("#FFFFFFFF"));

                Graph_3.Plot.Style(ScottPlot.Style.Black);
                Graph_3.Plot.YAxis.Color(color: System.Drawing.ColorTranslator.FromHtml("#FFFFFFFF"));
                Graph_3.Plot.XAxis.Color(color: System.Drawing.ColorTranslator.FromHtml("#FFFFFFFF"));

                Graph_4.Plot.Style(ScottPlot.Style.Black);
                Graph_4.Plot.YAxis.Color(color: System.Drawing.ColorTranslator.FromHtml("#FFFFFFFF"));
                Graph_4.Plot.XAxis.Color(color: System.Drawing.ColorTranslator.FromHtml("#FFFFFFFF"));
            }
            Graph_1.Plot.XAxis.TickLabelFormat(Axis_Scale_Config.X_Axis_Time_SI_Prefix_Scale);
            Graph_1.Plot.YAxis.TickLabelFormat(Axis_Scale_Config.Y_Axis_SI_Prefix_Scale);
            Graph_2.Plot.XAxis.TickLabelFormat(Axis_Scale_Config.X_Axis_Time_SI_Prefix_Scale);
            Graph_2.Plot.YAxis.TickLabelFormat(Axis_Scale_Config.Y_Axis_SI_Prefix_Scale);
            Graph_3.Plot.XAxis.TickLabelFormat(Axis_Scale_Config.X_Axis_Time_SI_Prefix_Scale);
            Graph_3.Plot.YAxis.TickLabelFormat(Axis_Scale_Config.Y_Axis_SI_Prefix_Scale);
            Graph_4.Plot.XAxis.TickLabelFormat(Axis_Scale_Config.X_Axis_Time_SI_Prefix_Scale);
            Graph_4.Plot.YAxis.TickLabelFormat(Axis_Scale_Config.Y_Axis_SI_Prefix_Scale);
            Channel_1_Curve = Graph_1.Plot.AddSignalXY(CH1_X_Values, CH1_Y_Values, color: System.Drawing.ColorTranslator.FromHtml(Channel_1_Color), label: "CH1");
            Channel_1_Curve.MarkerSize = 1;
            Channel_1_Curve.MaxRenderIndex = 0;
            Channel_2_Curve = Graph_2.Plot.AddSignalXY(CH2_X_Values, CH2_Y_Values, color: System.Drawing.ColorTranslator.FromHtml(Channel_2_Color), label: "CH2");
            Channel_2_Curve.MarkerSize = 1;
            Channel_2_Curve.MaxRenderIndex = 0;
            Channel_3_Curve = Graph_3.Plot.AddSignalXY(CH3_X_Values, CH3_Y_Values, color: System.Drawing.ColorTranslator.FromHtml(Channel_3_Color), label: "CH3");
            Channel_3_Curve.MarkerSize = 1;
            Channel_3_Curve.MaxRenderIndex = 0;
            Channel_4_Curve = Graph_4.Plot.AddSignalXY(CH4_X_Values, CH4_Y_Values, color: System.Drawing.ColorTranslator.FromHtml(Channel_4_Color), label: "CH4");
            Channel_4_Curve.MarkerSize = 1;
            Channel_4_Curve.MaxRenderIndex = 0;
            Graph_1.Plot.Legend(true);
            Graph_2.Plot.Legend(true);
            Graph_3.Plot.Legend(true);
            Graph_4.Plot.Legend(true);
            Graph_1.Render();
            Graph_2.Render();
            Graph_3.Render();
            Graph_4.Render();
        }

        private void Initialize_Timers()
        {
            Waveform_Data_Process = new System.Timers.Timer(50);
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

                    if (Channels_Data.CH1.Valid)
                    {
                        (CH1_Total_Time, CH1_Start_Time, CH1_Stop_Time, CH1_Channel_Info) = (Channels_Data.CH1.Total_Time, Channels_Data.CH1.Start_Time, Channels_Data.CH1.Stop_Time, Channels_Data.CH1.Channel_Info);

                        if (CH1_Data_Points == Channels_Data.CH1.Data_Points)
                        {
                            System.Array.Copy(Channels_Data.CH1.X_Data, CH1_X_Values, CH1_Data_Points);
                            System.Array.Copy(Channels_Data.CH1.Y_Data, CH1_Y_Values, CH1_Data_Points);
                        }
                        else
                        {
                            CH1_Data_Points = Channels_Data.CH1.Data_Points;
                            CH1_X_Values = new double[CH1_Data_Points];
                            CH1_Y_Values = new double[CH1_Data_Points];
                            System.Array.Copy(Channels_Data.CH1.X_Data, CH1_X_Values, CH1_Data_Points);
                            System.Array.Copy(Channels_Data.CH1.Y_Data, CH1_Y_Values, CH1_Data_Points);
                        }

                        CH1_Waveform_Measurements_Updater();
                        CH1_Needs_Updating = true;
                    }

                    if (Channels_Data.CH2.Valid)
                    {
                        (CH2_Total_Time, CH2_Start_Time, CH2_Stop_Time, CH2_Channel_Info) = (Channels_Data.CH2.Total_Time, Channels_Data.CH2.Start_Time, Channels_Data.CH2.Stop_Time, Channels_Data.CH2.Channel_Info);

                        if (CH2_Data_Points == Channels_Data.CH2.Data_Points)
                        {
                            System.Array.Copy(Channels_Data.CH2.X_Data, CH2_X_Values, CH2_Data_Points);
                            System.Array.Copy(Channels_Data.CH2.Y_Data, CH2_Y_Values, CH2_Data_Points);
                        }
                        else
                        {
                            CH2_Data_Points = Channels_Data.CH2.Data_Points;
                            CH2_X_Values = new double[CH2_Data_Points];
                            CH2_Y_Values = new double[CH2_Data_Points];
                            System.Array.Copy(Channels_Data.CH2.X_Data, CH2_X_Values, CH2_Data_Points);
                            System.Array.Copy(Channels_Data.CH2.Y_Data, CH2_Y_Values, CH2_Data_Points);
                        }

                        CH2_Waveform_Measurements_Updater();
                        CH2_Needs_Updating = true;
                    }

                    if (Channels_Data.CH3.Valid)
                    {
                        (CH3_Total_Time, CH3_Start_Time, CH3_Stop_Time, CH3_Channel_Info) = (Channels_Data.CH3.Total_Time, Channels_Data.CH3.Start_Time, Channels_Data.CH3.Stop_Time, Channels_Data.CH3.Channel_Info);

                        if (CH3_Data_Points == Channels_Data.CH3.Data_Points)
                        {
                            System.Array.Copy(Channels_Data.CH3.X_Data, CH3_X_Values, CH3_Data_Points);
                            System.Array.Copy(Channels_Data.CH3.Y_Data, CH3_Y_Values, CH3_Data_Points);
                        }
                        else
                        {
                            CH3_Data_Points = Channels_Data.CH3.Data_Points;
                            CH3_X_Values = new double[CH3_Data_Points];
                            CH3_Y_Values = new double[CH3_Data_Points];
                            System.Array.Copy(Channels_Data.CH3.X_Data, CH3_X_Values, CH3_Data_Points);
                            System.Array.Copy(Channels_Data.CH3.Y_Data, CH3_Y_Values, CH3_Data_Points);
                        }

                        CH3_Waveform_Measurements_Updater();
                        CH3_Needs_Updating = true;
                    }

                    if (Channels_Data.CH4.Valid)
                    {
                        (CH4_Total_Time, CH4_Start_Time, CH4_Stop_Time, CH4_Channel_Info) = (Channels_Data.CH4.Total_Time, Channels_Data.CH4.Start_Time, Channels_Data.CH4.Stop_Time, Channels_Data.CH4.Channel_Info);

                        if (CH4_Data_Points == Channels_Data.CH4.Data_Points)
                        {
                            System.Array.Copy(Channels_Data.CH4.X_Data, CH4_X_Values, CH4_Data_Points);
                            System.Array.Copy(Channels_Data.CH4.Y_Data, CH4_Y_Values, CH4_Data_Points);
                        }
                        else
                        {
                            CH4_Data_Points = Channels_Data.CH4.Data_Points;
                            CH4_X_Values = new double[CH4_Data_Points];
                            CH4_Y_Values = new double[CH4_Data_Points];
                            System.Array.Copy(Channels_Data.CH4.X_Data, CH4_X_Values, CH4_Data_Points);
                            System.Array.Copy(Channels_Data.CH4.Y_Data, CH4_Y_Values, CH4_Data_Points);
                        }

                        CH4_Waveform_Measurements_Updater();
                        CH4_Needs_Updating = true;
                    }

                    if (CH1_Needs_Updating || CH2_Needs_Updating || CH3_Needs_Updating || CH4_Needs_Updating)
                    {
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

        private void CH1_Waveform_Measurements_Updater()
        {
            CH1_Waveform_Mean = Waveform_Measurements.Mean(CH1_Y_Values);
            CH1_Waveform_MAX = Waveform_Measurements.Maximum(CH1_Y_Values);
            CH1_Waveform_MIN = Waveform_Measurements.Minimum(CH1_Y_Values);
            CH1_Waveform_PKPK = Waveform_Measurements.Peak_Peak(CH1_Waveform_MAX, CH1_Waveform_MIN);
            CH1_Waveform_RMS = Waveform_Measurements.RMS(CH1_Y_Values);

            CH1_Waveform_Period = Waveform_Measurements.Period(CH1_X_Values, CH1_Y_Values, CH1_Data_Points, CH1_Waveform_MAX, CH1_Waveform_MIN);
            CH1_Waveform_Frequency = Waveform_Measurements.Frequency(CH1_Waveform_Period);

            Frequency_CH1 = Axis_Scale_Config.Value_SI_Prefix(CH1_Waveform_Frequency, 5) + "Hz";
            Period_CH1 = Axis_Scale_Config.Value_SI_Prefix(CH1_Waveform_Period, 5) + "s";
        }

        private void CH2_Waveform_Measurements_Updater()
        {
            CH2_Waveform_Mean = Waveform_Measurements.Mean(CH2_Y_Values);
            CH2_Waveform_MAX = Waveform_Measurements.Maximum(CH2_Y_Values);
            CH2_Waveform_MIN = Waveform_Measurements.Minimum(CH2_Y_Values);
            CH2_Waveform_PKPK = Waveform_Measurements.Peak_Peak(CH2_Waveform_MAX, CH2_Waveform_MIN);
            CH2_Waveform_RMS = Waveform_Measurements.RMS(CH2_Y_Values);

            CH2_Waveform_Period = Waveform_Measurements.Period(CH2_X_Values, CH2_Y_Values, CH2_Data_Points, CH2_Waveform_MAX, CH2_Waveform_MIN);
            CH2_Waveform_Frequency = Waveform_Measurements.Frequency(CH2_Waveform_Period);

            Frequency_CH2 = Axis_Scale_Config.Value_SI_Prefix(CH2_Waveform_Frequency, 5) + "Hz";
            Period_CH2 = Axis_Scale_Config.Value_SI_Prefix(CH2_Waveform_Period, 5) + "s";
        }

        private void CH3_Waveform_Measurements_Updater()
        {
            CH3_Waveform_Mean = Waveform_Measurements.Mean(CH3_Y_Values);
            CH3_Waveform_MAX = Waveform_Measurements.Maximum(CH3_Y_Values);
            CH3_Waveform_MIN = Waveform_Measurements.Minimum(CH3_Y_Values);
            CH3_Waveform_PKPK = Waveform_Measurements.Peak_Peak(CH3_Waveform_MAX, CH3_Waveform_MIN);
            CH3_Waveform_RMS = Waveform_Measurements.RMS(CH3_Y_Values);

            CH3_Waveform_Period = Waveform_Measurements.Period(CH3_X_Values, CH3_Y_Values, CH3_Data_Points, CH3_Waveform_MAX, CH3_Waveform_MIN);
            CH3_Waveform_Frequency = Waveform_Measurements.Frequency(CH3_Waveform_Period);

            Frequency_CH3 = Axis_Scale_Config.Value_SI_Prefix(CH3_Waveform_Frequency, 5) + "Hz";
            Period_CH3 = Axis_Scale_Config.Value_SI_Prefix(CH3_Waveform_Period, 5) + "s";
        }

        private void CH4_Waveform_Measurements_Updater()
        {
            CH4_Waveform_Mean = Waveform_Measurements.Mean(CH4_Y_Values);
            CH4_Waveform_MAX = Waveform_Measurements.Maximum(CH4_Y_Values);
            CH4_Waveform_MIN = Waveform_Measurements.Minimum(CH4_Y_Values);
            CH4_Waveform_PKPK = Waveform_Measurements.Peak_Peak(CH4_Waveform_MAX, CH4_Waveform_MIN);
            CH4_Waveform_RMS = Waveform_Measurements.RMS(CH4_Y_Values);

            CH4_Waveform_Period = Waveform_Measurements.Period(CH4_X_Values, CH4_Y_Values, CH4_Data_Points, CH4_Waveform_MAX, CH4_Waveform_MIN);
            CH4_Waveform_Frequency = Waveform_Measurements.Frequency(CH4_Waveform_Period);

            Frequency_CH4 = Axis_Scale_Config.Value_SI_Prefix(CH4_Waveform_Frequency, 5) + "Hz";
            Period_CH4 = Axis_Scale_Config.Value_SI_Prefix(CH4_Waveform_Period, 5) + "s";
        }

        private void Graph_Render()
        {
            if (CH1_Needs_Updating)
            {
                Channel_1_Curve.MaxRenderIndex = 0;
                Channel_1_Curve.Xs = CH1_X_Values;
                Channel_1_Curve.Ys = CH1_Y_Values;
                Channel_1_Curve.MaxRenderIndex = CH1_X_Values.Length - 1;
                CH1_Information_Tab_Updater();
                CH1_Needs_Updating = false;
                Graph_1.Render();
            }
            if (CH2_Needs_Updating)
            {
                Channel_2_Curve.MaxRenderIndex = 0;
                Channel_2_Curve.Xs = CH2_X_Values;
                Channel_2_Curve.Ys = CH2_Y_Values;
                Channel_2_Curve.MaxRenderIndex = CH2_X_Values.Length - 1;
                CH2_Information_Tab_Updater();
                CH2_Needs_Updating = false;
                Graph_2.Render();
            }
            if (CH3_Needs_Updating)
            {
                Channel_3_Curve.MaxRenderIndex = 0;
                Channel_3_Curve.Xs = CH3_X_Values;
                Channel_3_Curve.Ys = CH3_Y_Values;
                Channel_3_Curve.MaxRenderIndex = CH3_X_Values.Length - 1;
                CH3_Information_Tab_Updater();
                CH3_Needs_Updating = false;
                Graph_3.Render();
            }
            if (CH4_Needs_Updating)
            {
                Channel_4_Curve.MaxRenderIndex = 0;
                Channel_4_Curve.Xs = CH4_X_Values;
                Channel_4_Curve.Ys = CH4_Y_Values;
                Channel_4_Curve.MaxRenderIndex = CH4_X_Values.Length - 1;
                CH4_Information_Tab_Updater();
                CH4_Needs_Updating = false;
                Graph_4.Render();
            }
            if (Auto_Axis_Enable.IsChecked)
            {
                Graph_1.Plot.AxisAuto();
                Graph_2.Plot.AxisAuto();
                Graph_3.Plot.AxisAuto();
                Graph_4.Plot.AxisAuto();
            }
        }
    }
}
