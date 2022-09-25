using AvalonDock;
using Axis_Scale_Config;
using MahApps.Metro.Controls;
using MathNet.Numerics.IntegralTransforms;
using NX_StarWave.Misc;
using NX_StarWave.Waveform_Model_Classes;
using System;
using System.Collections.Concurrent;
using System.Linq;
using System.Numerics;
using System.Windows.Threading;

namespace FFT
{
    public partial class FFT_Plotter : MetroWindow
    {
        //Waveform data is initially stored here unit it is removed, processed and displayed on the graph window
        public BlockingCollection<Channel_Waveform_Data> Waveform_Data_Queue = new BlockingCollection<Channel_Waveform_Data>();

        //FFT Curve
        private ScottPlot.Plottable.SignalPlotXY FFT_Waveform;

        //Phase Curve
        private ScottPlot.Plottable.SignalPlotXY Phase_Waveform;

        //Waveform Curve Initial X,Y Array
        private double[] X_Waveform_Values = new double[500];
        private double[] Y_Waveform_Values = new double[500];

        private double[] Magnitude = new double[500]; //Magnitude
        private double[] Frequency = new double[500]; //Frequency
        private double[] Phase = new double[500]; //Phase

        //These timers periodically check for any data inserted into Data_Queue, and processs it and insert it into the graph
        private System.Timers.Timer Waveform_Data_Process;

        //Currently selected Y axis units
        private string Y_AXIS_Units = "dB";
        private string Y_AXIS_Units_Custom = "V";
        private string Channel_Title = "";

        private Helpful_Functions Functions = new Helpful_Functions();
        private Axis_Config Axis_Scale_Config = new Axis_Config();

        public FFT_Plotter(string Title, string Channel_Title, string Color, string Y_AXIS_Units_Custom = "V", Channel_Waveform_Data Initial_Waveform_Data = null)
        {
            InitializeComponent();
            DataContext = this;
            this.Channel_Title = Channel_Title;
            this.Y_AXIS_Units_Custom = Y_AXIS_Units_Custom;
            dB_Select_Menu_Header = "dB" + Y_AXIS_Units_Custom + " rms";
            Linear_Select_Menu_Header = "Linear " + Y_AXIS_Units_Custom + "rms";
            Initialize_FFT_Averaging();
            Graph_RightClick_Menu();
            Initialize_Waveform_Curve(Channel_Title, Color, Y_AXIS_Units_Custom);
            Initialize_Plottable_Peaks();
            Update_Window_Title(Title);
            Setup_Interpolation();
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

        public void Initialize_Waveform_Curve(string Label, string Color, string Y_AXIS_Units_Custom)
        {
            if (ControlzEx.Theming.ThemeManager.Current.DetectTheme().BaseColorScheme.Equals("Dark"))
            {
                Graph.Plot.Style(ScottPlot.Style.Black);
                Graph.Plot.YAxis.Color(color: System.Drawing.ColorTranslator.FromHtml("#FFFFFFFF"));
                Graph.Plot.YAxis2.Color(color: System.Drawing.ColorTranslator.FromHtml("#FFFFFFFF"));
                Graph.Plot.XAxis.Color(color: System.Drawing.ColorTranslator.FromHtml("#FFFFFFFF"));
            }
            Axis_Scale_Config.X_Axis_Units = "Hz";
            Axis_Scale_Config.Y_Axis_Units = "dB";
            Graph.Plot.XAxis.TickLabelFormat(Axis_Scale_Config.X_Axis_Time_SI_Prefix_Scale);
            Graph.Plot.YAxis.TickLabelFormat(Axis_Scale_Config.Y_Axis_SI_Prefix_Scale);
            FFT_Waveform = Graph.Plot.AddSignalXY(Frequency, Magnitude, color: System.Drawing.ColorTranslator.FromHtml(Color), label: Label + " FFT");
            FFT_Waveform.MarkerSize = 1;
            FFT_Waveform.MaxRenderIndex = 0;
            Graph.Plot.XAxis.Label("Frequency (Hz)");
            Graph.Plot.YAxis.Label("Magnitude (dB" + Y_AXIS_Units_Custom + " rms)");

            Phase_Waveform = Graph.Plot.AddSignalXY(Frequency, Phase, color: System.Drawing.ColorTranslator.FromHtml("#D95319"), label: Label + " Phase");
            Phase_Waveform.MarkerSize = 1;
            Phase_Waveform.MaxRenderIndex = 0;
            Phase_Waveform.YAxisIndex = 1;
            Graph.Plot.YAxis2.Ticks(false);
            Phase_Waveform.IsVisible = false;
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
                            FFT_Size = Data_Points / 2;
                            X_Waveform_Values = new double[Data_Points];
                            Y_Waveform_Values = new double[Data_Points];
                            System.Array.Copy(CH.X_Data, X_Waveform_Values, Data_Points);
                            System.Array.Copy(CH.Y_Data, Y_Waveform_Values, Data_Points);
                        }

                        if (Interpolation_isDisabled) 
                        {
                            FFT_Size = Data_Points / 2;
                            Interpolation_isDisabled = false;
                        }

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
                            Create_Gated_HighestPoints_Array(Frequency, Magnitude, FFT_Size);
                        }

                        if (Gated_Peaks_IsEnabled)
                        {
                            Create_Gated_Peaks_Array(Frequency, Magnitude, FFT_Size);
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
                                Phase[i] = Samples[i].Phase * (180 / Math.PI);
                            }
                            else
                            {
                                Phase[i] = Samples[i].Phase;
                            }
                        }
                    }
                }
                Phase[0] = 0; //Initial Phase value is set to 0
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
                                Phase[i] = Samples[i].Phase * (180 / Math.PI);
                            }
                            else
                            {
                                Phase[i] = Samples[i].Phase;
                            }
                        }
                    }
                }
                Phase[0] = 0; //Initial Phase value is set to 0
            }
        }

        private void FFT_Min_Max_Updater()
        {
            FFT_Max = Magnitude.Max();
            FFT_Min = Magnitude.Min();
        }

        private void Update_FFT_Plot()
        {
            FFT_Waveform.MaxRenderIndex = 0;
            FFT_Waveform.Xs = Frequency;
            FFT_Waveform.Ys = Magnitude;
            FFT_Waveform.MaxRenderIndex = Frequency.Length - 1;
            if (Calculate_Phase)
            {
                Phase_Waveform.MaxRenderIndex = 0;
                Phase_Waveform.Xs = Frequency;
                Phase_Waveform.Ys = Phase;
                Phase_Waveform.MaxRenderIndex = Frequency.Length - 1;
            }
        }

        private void Graph_Render()
        {
            Update_FFT_Plot();
            Information_Tab_Updater();
            if (Show_Peak_Feature)
            {
                Update_Plottable_Peaks();
            }
            if (Auto_Axis_Enable.IsChecked)
            {
                Graph.Plot.AxisAuto();
            }
            Graph.Render();

            if (Zoom_Control_Window_IsEnabled)
            {
                Zoom_Waveform_Curve.MaxRenderIndex = 0;
                Zoom_Waveform_Curve.Xs = Frequency;
                Zoom_Waveform_Curve.Ys = Magnitude;
                Zoom_Waveform_Curve.MaxRenderIndex = Frequency.Length - 1;

                Zoom_Control_Plot.Plot.AxisAuto();
                Zoom_Control_Plot.Refresh();
            }
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
