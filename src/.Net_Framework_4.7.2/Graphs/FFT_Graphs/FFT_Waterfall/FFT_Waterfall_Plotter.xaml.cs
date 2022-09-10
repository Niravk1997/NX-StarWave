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

namespace FFT_Waterfall
{
    public partial class FFT_Waterfall_Plotter : MetroWindow
    {
        //Waveform data is initially stored here unit it is removed, processed and displayed on the graph window
        public BlockingCollection<Channel_Waveform_Data> Waveform_Data_Queue = new BlockingCollection<Channel_Waveform_Data>();

        //FFT Curve
        private ScottPlot.Plottable.SignalPlotXY FFT_Waveform;

        //Phase Curve
        private ScottPlot.Plottable.SignalPlotXY Phase_Waveform;

        //Spectrogram
        private ScottPlot.Plottable.Heatmap Waterfall_Heatmap;
        private ScottPlot.Plottable.Colorbar Waterfall_Colorbar;

        //Waveform Curve Initial X,Y Array
        private double[] X_Waveform_Values = new double[500];
        private double[] Y_Waveform_Values = new double[500];

        private int FFT_Size = 250;
        private bool FFT_Size_Changed = false;
        private double[] Magnitude = new double[500]; //Magnitude
        private double[] Frequency = new double[500]; //Frequency
        private double[] Phase = new double[500]; //Phase

        //Spectrogram Data Array
        private readonly int Waterfall_History = 99;
        private double?[,] Waterfall_Buffer;
        private double?[,] Waterfall_PastFrame;

        //These timers periodically check for any data inserted into Data_Queue, and processs it and insert it into the graph
        private System.Timers.Timer Waveform_Data_Process;

        //Currently selected Y axis units
        private string Y_AXIS_Units = "dB";
        private string Y_AXIS_Units_Custom = "V";
        private string Channel_Title = "";

        private Helpful_Functions Functions = new Helpful_Functions();
        private Axis_Config Axis_Scale_Config = new Axis_Config();

        public FFT_Waterfall_Plotter(string Title, string Channel_Title, string Color, string Y_AXIS_Units_Custom = "V")
        {
            InitializeComponent();
            DataContext = this;
            this.Channel_Title = Channel_Title;
            this.Y_AXIS_Units_Custom = Y_AXIS_Units_Custom;
            dB_Select_Menu_Header = "dB" + Y_AXIS_Units_Custom + " rms";
            Linear_Select_Menu_Header = "Linear " + Y_AXIS_Units_Custom + "rms";
            Initialize_FFT_Averaging();
            Initialize_Arrays(FFT_Size);
            Graph_RightClick_Menu();
            Initialize_Waveform_Curve(Channel_Title, Color, Y_AXIS_Units_Custom);
            Initialize_Plottable_Peaks();
            Update_Window_Title(Title);
            Setup_Interpolation();
            Initialize_Timers();
        }

        private void Update_Window_Title(string Title)
        {
            Window_Title = Title;
        }

        public void Initialize_Waveform_Curve(string Label, string Color, string Y_AXIS_Units_Custom)
        {
            Axis_Scale_Config.X_Axis_Units = "Hz";
            Axis_Scale_Config.Y_Axis_Units = "dB";
            Graph.Plot.XAxis.TickLabelFormat(Axis_Scale_Config.X_Axis_Time_SI_Prefix_Scale);
            Graph.Plot.YAxis2.TickLabelFormat(Axis_Scale_Config.Y_Axis_SI_Prefix_Scale);
            Graph.Plot.YAxis2.Ticks(true);
            Graph.Plot.AxisAuto(0);
            FFT_Waveform = Graph.Plot.AddSignalXY(Frequency, Magnitude, color: System.Drawing.ColorTranslator.FromHtml(Color), label: Label + " FFT");
            FFT_Waveform.MarkerSize = 1;
            FFT_Waveform.MaxRenderIndex = 0;
            FFT_Waveform.YAxisIndex = 1;
            Graph.Plot.XAxis.Label("Frequency (Hz)");
            Graph.Plot.YAxis2.Label("Magnitude (dB" + Y_AXIS_Units_Custom + " rms)");

            Phase_Waveform = Graph.Plot.AddSignalXY(Frequency, Phase, color: System.Drawing.ColorTranslator.FromHtml("#D95319"), label: Label + " Phase");
            Phase_Waveform.MarkerSize = 1;
            Phase_Waveform.MaxRenderIndex = 0;
            Graph.Plot.YAxis.Ticks(false);
            Phase_Waveform.IsVisible = false;

            Graph.Plot.Layout(left: 0, right: 100, bottom: 0, top: 0, padding: 0);

            Waterfall_Heatmap = Waterfall.Plot.AddHeatmap(Waterfall_Buffer, ScottPlot.Drawing.Colormap.Plasma, false);
            Waterfall_Colorbar = Waterfall.Plot.AddColorbar(Waterfall_Heatmap);
            Waterfall.Plot.AxisAuto(0, 0);
            Waterfall.Plot.XAxis.Ticks(false);
            Waterfall.Plot.YAxis.Ticks(false);
            Waterfall.Plot.XAxis.Grid(false);
            Waterfall.Plot.YAxis.Grid(false);
            Waterfall.Plot.Layout(left: 0, bottom: 0, padding: 0);

            if (ControlzEx.Theming.ThemeManager.Current.DetectTheme().BaseColorScheme.Equals("Dark"))
            {
                Graph.Plot.Style(ScottPlot.Style.Black);
                Graph.Plot.YAxis.Color(color: System.Drawing.ColorTranslator.FromHtml("#FFFFFFFF"));
                Graph.Plot.YAxis2.Color(color: System.Drawing.ColorTranslator.FromHtml("#FFFFFFFF"));
                Graph.Plot.XAxis.Color(color: System.Drawing.ColorTranslator.FromHtml("#FFFFFFFF"));

                Waterfall.Plot.Style(ScottPlot.Style.Black);
                Waterfall_Colorbar.SetStyle(System.Drawing.ColorTranslator.FromHtml("#000000"), System.Drawing.ColorTranslator.FromHtml("#FFFFFFFF"));
            }

            Graph.Render();
            Waterfall.Render();
        }

        private void Initialize_Timers()
        {
            Waveform_Data_Process = new System.Timers.Timer(100);
            Waveform_Data_Process.Elapsed += Waveform_Data_Process_Graph;
            Waveform_Data_Process.AutoReset = false;
            Waveform_Data_Process.Enabled = true;
        }

        private void Initialize_Arrays(int Length)
        {
            Waterfall_Buffer = new double?[(Waterfall_History + 1), Length];
            Waterfall_PastFrame = new double?[(Waterfall_History + 1), Length];
            //Fill_Arrays_DummyData();
        }

        private void Fill_Arrays_DummyData()
        {
            int Lenght = Waterfall_Buffer.GetLength(1);
            for (int x = 0; x < (Waterfall_History + 1); x++)
            {
                for (int y = 0; y < Lenght; y++)
                {
                    Waterfall_Buffer[x, y] = -300;
                    Waterfall_PastFrame[x, y] = -300;
                }
            }
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

                        if (FFT_Size != (int)(Data_Points / 2))
                        {
                            FFT_Size = (int)(Data_Points / 2);
                            Initialize_Arrays(FFT_Size);
                            FFT_Size_Changed = true;
                            Interpolation_Resample_Factor_PastValue = 0;
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

                        Update_Waterfall_Data(Magnitude);

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

        private void Update_Waterfall_Data(double[] Current_FFT_Data)
        {
            // Compute the new Waterfall frame
            for (int x = Waterfall_History; x >= 0; x--)
            {
                for (int y = 0; y < Current_FFT_Data.Length; y++)
                {
                    Waterfall_Buffer[x, y] = (x == Waterfall_History) ? Current_FFT_Data[y] : Waterfall_PastFrame[x + 1, y];
                }
            }

            // Preserve the past frame, as current Waterfall is computed based on last + Xy fft values
            Array.Copy(Waterfall_Buffer, Waterfall_PastFrame, Waterfall_Buffer.Length);
        }

        private void Update_Spectrogram_Plot()
        {
            if (AutoScale_HeatMap_ColorScale)
            {
                Waterfall_Heatmap.Update(Waterfall_Buffer, colormap: Spectrogram_Heatmap_Process_Config());
            }
            else
            {
                Waterfall_Heatmap.Update(Waterfall_Buffer, colormap: Spectrogram_Heatmap_Process_Config(), Minimum_HeatMap_ColorScale, Maximum_HeatMap_ColorScale);
            }
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
            Update_Spectrogram_Plot();
            Information_Tab_Updater();
            if (Show_Peak_Feature)
            {
                Update_Plottable_Peaks();
            }
            if (Auto_Axis_Enable.IsChecked)
            {
                Graph.Plot.AxisAuto();
            }
            if (FFT_Size_Changed)
            {
                Graph.Plot.AxisAuto();
                Waterfall.Plot.AxisAuto(0, 0);
                FFT_Size_Changed = false;
            }
            Graph.Render();
            Waterfall.Render();
        }

        private void Manual_Graph_Render()
        {
            try
            {
                Graph.Refresh();
                Waterfall.Refresh();
            }
            catch (Exception)
            {

            }
        }
    }
}
