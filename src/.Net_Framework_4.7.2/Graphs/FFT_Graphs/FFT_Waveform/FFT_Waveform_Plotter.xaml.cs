using AvalonDock;
using Axis_Scale_Config;
using MahApps.Metro.Controls;
using MathNet.Numerics.IntegralTransforms;
using MathNet.Numerics.Statistics;
using NX_StarWave.Misc;
using NX_StarWave.Waveform_Model_Classes;
using System;
using System.Collections.Concurrent;
using System.Linq;
using System.Numerics;
using System.Windows.Threading;

namespace FFT_Waveform
{
    public partial class FFT_Waveform_Plotter : MetroWindow
    {
        //Waveform data is initially stored here unit it is removed, processed and displayed on the graph window
        public BlockingCollection<Channel_Waveform_Data> Waveform_Data_Queue = new BlockingCollection<Channel_Waveform_Data>();

        //FFT Curve
        private ScottPlot.Plottable.SignalPlotXY FFT_Waveform;

        //Waveform Curve
        private ScottPlot.Plottable.SignalPlotXY Waveform_Curve;

        //Phase Curve
        private ScottPlot.Plottable.SignalPlotXY Phase_Waveform;

        //Waveform Curve Initial X,Y Array
        private double[] X_Waveform_Values = new double[500];
        private double[] Y_Waveform_Values = new double[500];
        private double[] True_Y_Waveform_Values = new double[500];

        private double[] Magnitude = new double[500]; //Magnitude
        private double[] Frequency = new double[500]; //Frequency
        private double[] Phase = new double[500]; //Phase

        //These timers periodically check for any data inserted into Data_Queue, and processs it and insert it into the graph
        private System.Timers.Timer Waveform_Data_Process;

        private Helpful_Functions Functions = new Helpful_Functions();
        private Axis_Config Axis_Scale_Config = new Axis_Config();

        //Currently selected Y axis units
        private string Y_AXIS_Units = "dB";
        private string Channel_Title = "";

        public FFT_Waveform_Plotter(string Title, string Channel_Title, string Color)
        {
            InitializeComponent();
            DataContext = this;
            this.Channel_Title = Channel_Title;
            Initialize_FFT_Averaging();
            Graph_RightClick_Menu();
            Initialize_Waveform_Curve(Channel_Title, Color);
            Initialize_Plottable_Peaks();
            Update_Window_Title(Title);
            Initialize_Timers();
            Setup_Interpolation();
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
                Graph.Plot.YAxis2.Color(color: System.Drawing.ColorTranslator.FromHtml("#FFFFFFFF"));
                Graph.Plot.XAxis.Color(color: System.Drawing.ColorTranslator.FromHtml("#FFFFFFFF"));

                Waveform_Graph.Plot.Style(ScottPlot.Style.Black);
                Waveform_Graph.Plot.YAxis.Color(color: System.Drawing.ColorTranslator.FromHtml("#FFFFFFFF"));
                Waveform_Graph.Plot.XAxis.Color(color: System.Drawing.ColorTranslator.FromHtml("#FFFFFFFF"));
            }
            Axis_Scale_Config.X_Axis_Units = "Hz";
            Axis_Scale_Config.Y_Axis_Units = "dB";
            Graph.Plot.XAxis.TickLabelFormat(Axis_Scale_Config.X_Axis_Time_SI_Prefix_Scale);
            Graph.Plot.YAxis.TickLabelFormat(Axis_Scale_Config.Y_Axis_SI_Prefix_Scale);
            FFT_Waveform = Graph.Plot.AddSignalXY(Frequency, Magnitude, color: System.Drawing.ColorTranslator.FromHtml(Color), label: Label + " FFT");
            FFT_Waveform.MarkerSize = 1;
            FFT_Waveform.MaxRenderIndex = 0;
            Graph.Plot.XAxis.Label("Frequency (Hz)");
            Graph.Plot.YAxis.Label("Magnitude (dBV rms)");

            Phase_Waveform = Graph.Plot.AddSignalXY(Frequency, Phase, color: System.Drawing.ColorTranslator.FromHtml("#D95319"), label: Label + " Phase");
            Phase_Waveform.MarkerSize = 1;
            Phase_Waveform.MaxRenderIndex = 0;
            Phase_Waveform.YAxisIndex = 1;
            Graph.Plot.YAxis2.Ticks(false);
            Phase_Waveform.IsVisible = false;

            Waveform_Curve = Waveform_Graph.Plot.AddSignalXY(X_Waveform_Values, True_Y_Waveform_Values, color: System.Drawing.ColorTranslator.FromHtml(Color), label: Label);
            Waveform_Curve.MaxRenderIndex = 0;
            Waveform_Graph.Plot.XAxis.Label("Time (s)");
            Waveform_Graph.Plot.YAxis.Label("Voltage (V)");
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

                        True_Y_Waveform_Values = new double[Data_Points];
                        System.Array.Copy(Y_Waveform_Values, True_Y_Waveform_Values, Data_Points);

                        Waveform_Measurements_Updater();
                        FFT_Window_Apply();
                        FFT_Waveform_Updater();

                        if (FFT_Average_IsEnabled)
                        {
                            FFT_Average.Add_Waveform_to_Waveform_2D_Array(Frequency, Magnitude, Data_Points / 2, FFT_Average_Value);
                            (double[] Frequency_Average_Waveform, double[] Magnitude_Average_Waveform) = FFT_Average.Averaged_Waveform();
                            System.Array.Copy(Frequency_Average_Waveform, Frequency, Data_Points / 2);
                            System.Array.Copy(Magnitude_Average_Waveform, Magnitude, Data_Points / 2);
                        }

                        if (Apply_Interpolation)
                        {
                            Apply_Selected_Interploation_Data();
                        }
                        FFT_Min_Max_Updater();
                        if (Show_Peak_Feature)
                        {
                            Peak_Finder();
                        }

                        if (Gated_HighestPoints_IsEnabled)
                        {
                            Create_Gated_HighestPoints_Array(Frequency, Magnitude, Data_Points / 2);
                        }

                        if (Gated_Peaks_IsEnabled)
                        {
                            Create_Gated_Peaks_Array(Frequency, Magnitude, Data_Points / 2);
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
            Wavefrom_Mean = ArrayStatistics.Mean(Y_Waveform_Values);
            Wavefrom_MAX = ArrayStatistics.Maximum(Y_Waveform_Values);
            Wavefrom_MIN = ArrayStatistics.Minimum(Y_Waveform_Values);
            Wavefrom_PKPK = Wavefrom_MAX - Wavefrom_MIN;
            Wavefrom_RMS = ArrayStatistics.RootMeanSquare(Y_Waveform_Values);
        }

        private void FFT_Window_Apply()
        {
            (bool isWindow, double[] Window_data) = FFT_Window_Array_Generate();
            if (isWindow == true)
            {
                FFT_Window_Gain_Correction = Window_data.Length / Window_data.Sum();
                for (int i = 0; i < Y_Waveform_Values.Length; i++)
                {
                    Y_Waveform_Values[i] = Y_Waveform_Values[i] * Window_data[i];
                }
            }
            else
            {
                FFT_Window_Gain_Correction = 1;
            }
        }

        private void FFT_Waveform_Updater()
        {
            SampleRate = Data_Points / Total_Time;
            Complex[] Samples = new Complex[(int)Data_Points];
            for (int i = 0; i < Data_Points; i++)
            {
                Samples[i] = new Complex(Y_Waveform_Values[i], 0.0);
            }
            Fourier.Forward(Samples, options: FourierOptions.NoScaling);
            Magnitude = new double[Samples.Length / 2];
            Frequency = new double[Samples.Length / 2];
            Phase = new double[Samples.Length / 2];
            if (Magnitude_dBVrms == true)
            {
                for (int i = 0; i < (Samples.Length / 2); i++)
                {
                    double Magnitude = 20 * Math.Log10(((2.0 / Data_Points) * FFT_Window_Gain_Correction * Samples[i].Magnitude) / Math.Sqrt(2.0));
                    this.Magnitude[i] = Magnitude;
                    Frequency[i] = (SampleRate / Data_Points) * i;
                    if (Calculate_Phase)
                    {
                        if (Magnitude < Phase_dB_Magnitude_suppression_Value)
                        {
                            Phase[i] = 0;
                        }
                        else
                        {
                            if (isPhase_Degrees)
                            {
                                Phase[i] = Samples[i].Phase * (180.0 / Math.PI);
                            }
                            else
                            {
                                Phase[i] = Samples[i].Phase;
                            }
                        }
                    }
                }
            }
            else
            {
                for (int i = 0; i < (Samples.Length / 2); i++)
                {
                    Magnitude[i] = ((2.0 / Data_Points) * FFT_Window_Gain_Correction * Samples[i].Magnitude) / Math.Sqrt(2.0);
                    Frequency[i] = (SampleRate / Data_Points) * i;
                    if (Calculate_Phase)
                    {
                        double Magnitude = 20 * Math.Log10(((2.0 / Data_Points) * FFT_Window_Gain_Correction * Samples[i].Magnitude) / Math.Sqrt(2.0));
                        if (Magnitude < Phase_dB_Magnitude_suppression_Value)
                        {
                            Phase[i] = 0;
                        }
                        else
                        {
                            if (isPhase_Degrees)
                            {
                                Phase[i] = Samples[i].Phase * (180.0 / Math.PI);
                            }
                            else
                            {
                                Phase[i] = Samples[i].Phase;
                            }
                        }
                    }
                }
            }
        }

        private void FFT_Min_Max_Updater()
        {
            FFT_Max = Magnitude.Max();
            FFT_Min = Magnitude.Min();
        }

        private void Graph_Render()
        {
            FFT_Waveform.MaxRenderIndex = 0;
            FFT_Waveform.Xs = Frequency;
            FFT_Waveform.Ys = Magnitude;
            FFT_Waveform.MaxRenderIndex = Frequency.Length - 1;
            if (Show_Oscilloscope_Data == true)
            {
                Waveform_Curve.MaxRenderIndex = 0;
                Waveform_Curve.Xs = X_Waveform_Values;
                Waveform_Curve.Ys = True_Y_Waveform_Values;
                Waveform_Curve.MaxRenderIndex = X_Waveform_Values.Length - 1;
            }
            else
            {
                Waveform_Curve.MaxRenderIndex = 0;
                Waveform_Curve.Xs = X_Waveform_Values;
                Waveform_Curve.Ys = Y_Waveform_Values;
                Waveform_Curve.MaxRenderIndex = X_Waveform_Values.Length - 1;
            }
            if (Calculate_Phase)
            {
                Phase_Waveform.MaxRenderIndex = 0;
                Phase_Waveform.Xs = Frequency;
                Phase_Waveform.Ys = Phase;
                Phase_Waveform.MaxRenderIndex = Frequency.Length - 1;
            }
            Information_Tab_Updater();
            if (Show_Peak_Feature)
            {
                Update_Plottable_Peaks();
            }
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

        private void Manual_Graph_Render()
        {
            try
            {
                Graph.Refresh();
            }
            catch (Exception)
            {

            }
        }
    }
}
