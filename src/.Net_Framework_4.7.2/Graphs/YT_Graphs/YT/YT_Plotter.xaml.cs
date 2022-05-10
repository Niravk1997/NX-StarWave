using Auto_Measurements;
using Axis_Scale_Config;
using MahApps.Metro.Controls;
using NX_StarWave.Misc;
using NX_StarWave.Waveform_Model_Classes;
using System;
using System.Collections.Concurrent;
using System.Windows.Threading;

namespace YT
{
    public partial class YT_Plotter : MetroWindow
    {
        //Waveform data is initially stored here unit it is removed, processed and displayed on the graph window
        public BlockingCollection<Channel_Waveform_Data> Waveform_Data_Queue = new BlockingCollection<Channel_Waveform_Data>();

        //Waveform Curve
        private ScottPlot.Plottable.SignalPlotXY Waveform_Curve;

        //Waveform Curve Initial X,Y Array
        private double[] X_Waveform_Values = new double[500];
        private double[] Y_Waveform_Values = new double[500];

        //These timers periodically check for any data inserted into Data_Queue, and processs it and insert it into the graph
        private System.Timers.Timer Waveform_Data_Process;

        private Helpful_Functions Functions = new Helpful_Functions();
        private Axis_Config Axis_Scale_Config = new Axis_Config();
        private Automatic_Measurements Waveform_Measurements = new Automatic_Measurements();

        private string Channel_Title;

        public YT_Plotter(string Title, string Channel_Title, string Color, string Y_Axis_label = "Voltage (V)", string Units = "V", Channel_Waveform_Data Initial_Waveform_Data = null)
        {
            InitializeComponent();
            DataContext = this;
            Graph_RightClick_Menu();
            this.Title = Title;
            this.Channel_Title = Channel_Title;
            this.Measurement_Unit = Units;
            Initialize_Waveform_Curve(Channel_Title, Color, Y_Axis_label, Units);
            Update_Window_Title(Title);
            Initialize_Timers();
            Setup_Interpolation();
            Set_Default_Anytime_FFT_Color(Color);
            Set_Initial_Persistence_Color(Color);
            Initialize_Waveform_Averaging();
            if (Initial_Waveform_Data != null)
            {
                Waveform_Data_Queue.Add(Initial_Waveform_Data);
            }
        }

        private void Update_Window_Title(string Title)
        {
            Window_Title = Title;
        }

        public void Initialize_Waveform_Curve(string Label, string Color, string Y_Axis_label, string Units)
        {
            if (ControlzEx.Theming.ThemeManager.Current.DetectTheme().BaseColorScheme.Equals("Dark"))
            {
                Graph.Plot.Style(ScottPlot.Style.Black);
                Graph.Plot.YAxis.Color(color: System.Drawing.ColorTranslator.FromHtml("#FFFFFFFF"));
                Graph.Plot.XAxis.Color(color: System.Drawing.ColorTranslator.FromHtml("#FFFFFFFF"));
            }
            Graph.Plot.XAxis.TickLabelFormat(Axis_Scale_Config.X_Axis_Time_SI_Prefix_Scale);
            Graph.Plot.YAxis.TickLabelFormat(Axis_Scale_Config.Y_Axis_SI_Prefix_Scale);
            Waveform_Curve = Graph.Plot.AddSignalXY(X_Waveform_Values, Y_Waveform_Values, color: System.Drawing.ColorTranslator.FromHtml(Color), label: Label);
            Waveform_Curve.MarkerSize = 1;
            Waveform_Curve.MaxRenderIndex = 0;
            Graph.Plot.XAxis.Label("Time (s)");
            Graph.Plot.YAxis.Label(Y_Axis_label);
            Axis_Scale_Config.Y_Axis_Units = Units;
            Graph.Render();
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

                        if (Waveform_Average_IsEnabled)
                        {
                            Waveform_Average.Add_Waveform_to_Waveform_2D_Array(X_Waveform_Values, Y_Waveform_Values, Data_Points, Waveform_Average_Value);
                            (double[] X_Average_Waveform, double[] Y_Average_Waveform) = Waveform_Average.Averaged_Waveform();
                            System.Array.Copy(X_Average_Waveform, X_Waveform_Values, Data_Points);
                            System.Array.Copy(Y_Average_Waveform, Y_Waveform_Values, Data_Points);
                        }

                        if (Apply_Interpolation)
                        {
                            Apply_Selected_Interploation_Data();
                        }

                        if (Statistics_Table_IsOpen)
                        {
                            Statistics_Table.Statistics_Table_Process_Data(X_Waveform_Values, Y_Waveform_Values, Data_Points);
                        }
                        else
                        {
                            Waveform_Measurements_Updater();
                        }

                        if (Gated_Measurements_IsEnabled)
                        {
                            Create_Gated_Measurements_Array(X_Waveform_Values, Y_Waveform_Values, Data_Points);
                        }

                        if (Gated_HighestPoints_IsEnabled)
                        {
                            Create_Gated_HighestPoints_Array(X_Waveform_Values, Y_Waveform_Values, Data_Points);
                        }

                        if (Gated_Peaks_IsEnabled)
                        {
                            Create_Gated_Peaks_Array(X_Waveform_Values, Y_Waveform_Values, Data_Points);
                        }

                        Information_Tab_Updater();

                        if (Persistence_Waveform_Process_Ready)
                        {
                            Process_Persistence_Waveform_Data();
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

        private void Waveform_Measurements_Updater()
        {
            Waveform_Mean = Waveform_Measurements.Mean(Y_Waveform_Values);
            Waveform_MAX = Waveform_Measurements.Maximum(Y_Waveform_Values);
            Waveform_MIN = Waveform_Measurements.Minimum(Y_Waveform_Values);
            Waveform_PKPK = Waveform_Measurements.Peak_Peak(Waveform_MAX, Waveform_MIN);
            Waveform_RMS = Waveform_Measurements.RMS(Y_Waveform_Values);

            if (Vertical_Markers_Enable == false)
            {
                Waveform_Period = Waveform_Measurements.Period(X_Waveform_Values, Y_Waveform_Values, Data_Points, Waveform_MAX, Waveform_MIN);
                Waveform_Frequency = Waveform_Measurements.Frequency(Waveform_Period);
            }
        }

        private void Graph_Render()
        {
            Waveform_Curve.MaxRenderIndex = 0;
            Waveform_Curve.Xs = X_Waveform_Values;
            Waveform_Curve.Ys = Y_Waveform_Values;
            Waveform_Curve.MaxRenderIndex = Data_Points - 1;

            if (Persistence_Waveform_Process_Ready)
            {
                Update_Visible_Persistence_Waveforms();
            }

            if (Auto_Axis_Enable.IsChecked)
            {
                Graph.Plot.AxisAuto();
            }
            Graph.Render();

            if (Zoom_Control_Window_IsEnabled)
            {
                Zoom_Waveform_Curve.MaxRenderIndex = 0;
                Zoom_Waveform_Curve.Xs = X_Waveform_Values;
                Zoom_Waveform_Curve.Ys = Y_Waveform_Values;
                Zoom_Waveform_Curve.MaxRenderIndex = Data_Points - 1;

                Zoom_Control_Plot.Plot.AxisAuto();
                Zoom_Control_Plot.Refresh();
            }
        }
    }
}
