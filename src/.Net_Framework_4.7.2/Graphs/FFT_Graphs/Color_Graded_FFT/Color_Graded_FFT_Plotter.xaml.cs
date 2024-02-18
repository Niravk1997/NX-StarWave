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

namespace Color_Graded_FFT
{
    public partial class Color_Graded_FFT_Plotter : MetroWindow
    {
        //Waveform data is initially stored here unit it is removed, processed and displayed on the graph window
        public BlockingCollection<Channel_Waveform_Data> Waveform_Data_Queue = new BlockingCollection<Channel_Waveform_Data>();

        //Color Graded FFT
        private ScottPlot.Plottable.Heatmap FFT_Hitmap;
        private ScottPlot.Plottable.Colorbar FFT_Hitmap_Colorbar;

        //Waveform Curve Initial X,Y Array
        private double[] X_Waveform_Values = new double[500];
        private double[] Y_Waveform_Values = new double[500];

        private bool Reinitialize_FFT_Hitmap = true;
        private double[] Magnitude = new double[500]; //Magnitude
        private double[] Frequency = new double[500]; //Frequency

        //FFT Hitmap Data Array
        private double?[,] FFT_Hitmap_Array;

        //These timers periodically check for any data inserted into Data_Queue, and processs it and insert it into the graph
        private System.Timers.Timer Waveform_Data_Process;

        //Currently selected Y axis units
        private string Y_AXIS_Units = "dB";
        private string Y_AXIS_Units_Custom = "V";
        private string Channel_Title = "";

        private Helpful_Functions Functions = new Helpful_Functions();
        private Normalized_Axis_Config X_Axis_Normalized_Scale = new Normalized_Axis_Config("Hz", 2);
        private Normalized_Axis_Config Y_Axis_Normalized_Scale = new Normalized_Axis_Config("dB", 2);
        private Axis_Config Axis_Scale_Config = new Axis_Config();

        public Color_Graded_FFT_Plotter(string Title, string Channel_Title, string Color, string Y_AXIS_Units_Custom = "V", Channel_Waveform_Data Initial_Waveform_Data = null)
        {
            InitializeComponent();
            DataContext = this;
            this.Channel_Title = Channel_Title;
            this.Y_AXIS_Units_Custom = Y_AXIS_Units_Custom;
            dB_Select_Menu_Header = "dB" + Y_AXIS_Units_Custom + " rms";
            Linear_Select_Menu_Header = "Linear " + Y_AXIS_Units_Custom + "rms";
            Initialize_FFT_Averaging();
            Graph_RightClick_Menu();
            Update_Window_Title(Title);
            Setup_Interpolation();
            Initialize_Timers();
            Initialize_Arrays(FFT_Size);
            Initialize_Waveform_Curve(Y_AXIS_Units_Custom);
            if (Initial_Waveform_Data != null)
            {
                Waveform_Data_Queue.Add(Initial_Waveform_Data);
            }
        }

        private void Update_Window_Title(string Title)
        {
            Window_Title = Title;
        }

        private void Initialize_Arrays(int Length)
        {
            FFT_Hitmap_Array = new double?[FFT_Maximum_Hitmap_Columns, Length];
        }

        public void Initialize_Waveform_Curve(string Y_AXIS_Units_Custom)
        {
            FFT_Hitmap = Graph.Plot.AddHeatmap(FFT_Hitmap_Array, ScottPlot.Drawing.Colormap.Plasma, false);
            FFT_Hitmap.FlipVertically = true;
            FFT_Hitmap.Interpolation = System.Drawing.Drawing2D.InterpolationMode.NearestNeighbor;
            //FFT_Hitmap.Smooth = true;
            FFT_Hitmap_Colorbar = Graph.Plot.AddColorbar(FFT_Hitmap);

            if (ControlzEx.Theming.ThemeManager.Current.DetectTheme().BaseColorScheme.Equals("Dark"))
            {
                Graph.Plot.Style(ScottPlot.Style.Black);
                Graph.Plot.YAxis.Color(color: System.Drawing.ColorTranslator.FromHtml("#FFFFFFFF"));
                Graph.Plot.YAxis2.Color(color: System.Drawing.ColorTranslator.FromHtml("#FFFFFFFF"));
                Graph.Plot.XAxis.Color(color: System.Drawing.ColorTranslator.FromHtml("#FFFFFFFF"));

                FFT_Hitmap_Colorbar.SetStyle(System.Drawing.ColorTranslator.FromHtml("#000000"), System.Drawing.ColorTranslator.FromHtml("#FFFFFFFF"));
            }

            Graph.Plot.XAxis.Label("Frequency (Hz)");
            Graph.Plot.YAxis.Label("Magnitude (dB" + Y_AXIS_Units_Custom + " rms)");

            Graph.Plot.XAxis.TickLabelFormat(X_Axis_Normalized_Scale.Axis_SI_Prefix_Scale);
            Graph.Plot.YAxis.TickLabelFormat(Y_Axis_Normalized_Scale.Axis_SI_Prefix_Scale);

            Graph.Render();
        }

        private void Initialize_Timers()
        {
            Waveform_Data_Process = new System.Timers.Timer(1);
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
                            Reinitialize_FFT_Hitmap = true;
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

                        if (Frequency[FFT_Size - 1] != FFT_Maximum_Frequency)
                        {
                            Reinitialize_FFT_Hitmap = true;
                            FFT_Maximum_Frequency = Frequency[FFT_Size - 1];
                            Insert_Log("Maximum Frequency Changed.", 2);
                        }

                        if (Reinitialize_FFT_Hitmap)
                        {
                            Initialize_Arrays(FFT_Size);

                            X_Axis_Normalized_Scale.Original_Data_Range_Minimum_Value = 0;
                            X_Axis_Normalized_Scale.Original_Data_Range_Maximum_Value = Frequency[FFT_Size - 1];
                            X_Axis_Normalized_Scale.Normalized_Data_Range_Minimum_Value = 0;
                            X_Axis_Normalized_Scale.Normalized_Data_Range_Maximum_Value = FFT_Size;

                            if (Allow_Custom_FFT_Maximum_Magnitude_Value)
                            {
                                Y_Axis_Normalized_Scale.Original_Data_Range_Maximum_Value = FFT_Maximum_Magnitude_Value;
                            }
                            else
                            {
                                double Expected_FFT_Maximum_Magnitude = (Math.Abs(FFT_Max) * 0.3) + FFT_Max;
                                Y_Axis_Normalized_Scale.Original_Data_Range_Maximum_Value = Expected_FFT_Maximum_Magnitude;
                                FFT_Maximum_Magnitude_Value = Expected_FFT_Maximum_Magnitude;
                            }

                            if (Allow_Custom_FFT_Minimum_Magnitude_Value)
                            {
                                Y_Axis_Normalized_Scale.Original_Data_Range_Minimum_Value = FFT_Minimum_Magnitude_Value;
                            }
                            else
                            {
                                double Expected_FFT_Minimum_Magnitude = (-1 * Math.Abs(FFT_Min) * 0.3) + FFT_Min;
                                Y_Axis_Normalized_Scale.Original_Data_Range_Minimum_Value = Expected_FFT_Minimum_Magnitude;
                                FFT_Minimum_Magnitude_Value = Expected_FFT_Minimum_Magnitude;
                            }

                            Y_Axis_Normalized_Scale.Normalized_Data_Range_Minimum_Value = 0;
                            Y_Axis_Normalized_Scale.Normalized_Data_Range_Maximum_Value = FFT_Maximum_Hitmap_Columns;

                            Reinitialize_FFT_Hitmap = false;
                        }

                        for (int i = 0; i < FFT_Size; i++)
                        {
                            int Value = (int)Y_Axis_Normalized_Scale.Original_Value_to_Normalize_Value(Magnitude[i]);
                            if (Value >= 0 && Value < FFT_Maximum_Hitmap_Columns)
                            {
                                if (FFT_Hitmap_Array[Value, i] != null)
                                {
                                    FFT_Hitmap_Array[Value, i]++;
                                }
                                else
                                {
                                    FFT_Hitmap_Array[Value, i] = 1;
                                }
                            }
                            else
                            {
                                Insert_Log("Magnitude Value is outside the range of expected Magnitude Range", 1);
                            }
                        }

                        if (Decay_Interval_Enable)
                        {
                            if (Decay_Interval.Elapsed.TotalSeconds > Decay_Interval_Value_s)
                            {
                                for (int i = 0; i < FFT_Size; i++)
                                {
                                    for (int j = 0; j < FFT_Maximum_Hitmap_Columns; j++)
                                    {
                                        FFT_Hitmap_Array[j, i] = FFT_Hitmap_Array[j, i] * Decay_Factor;
                                        if (Allow_Null_FFT_HitMap_Value_below && FFT_Hitmap_Array[j, i] < Null_FFT_HitMap_Value_below)
                                        {
                                            FFT_Hitmap_Array[j, i] = null;
                                        }
                                    }
                                }
                                Decay_Interval.Restart();
                            }
                        }

                        this.Dispatcher.Invoke(() =>
                        {
                            Graph_Render();
                        }, DispatcherPriority.Normal);

                    }
                }
                catch (Exception Ex)
                {
                    Reinitialize_FFT_Hitmap = true;
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
            if (Magnitude_dBVrms == true)
            {
                for (int i = 0; i < (Samples.Length / 2); i++)
                {
                    double Magnitude = 20 * Math.Log10(((2.0 / Data_Points) * FFT_Window_Gain_Correction * Samples[i].Magnitude) / Math.Sqrt(2.0));
                    this.Magnitude[i] = Magnitude;
                    Frequency[i] = (SampleRate / Data_Points) * i;
                }
            }
            else
            {
                for (int i = 0; i < (Samples.Length / 2); i++)
                {
                    Magnitude[i] = ((2.0 / Data_Points) * FFT_Window_Gain_Correction * Samples[i].Magnitude) / Math.Sqrt(2.0);
                    Frequency[i] = (SampleRate / Data_Points) * i;
                }
            }
        }

        private void FFT_Min_Max_Updater()
        {
            FFT_Max = Magnitude.Max();
            FFT_Min = Magnitude.Min();
        }

        private void Update_Color_Graded_FFT_Plot()
        {
            if (Enable_Color_Grade_Clipping)
            {
                FFT_Hitmap.Update(FFT_Hitmap_Array, colormap: Spectrogram_Heatmap_Process_Config(), Color_Grade_Clipping_Min_Value, Color_Grade_Clipping_Max_Value);
            }
            else
            {
                FFT_Hitmap.Update(FFT_Hitmap_Array, colormap: Spectrogram_Heatmap_Process_Config());
            }
        }

        private void Graph_Render()
        {
            Update_Color_Graded_FFT_Plot();
            Information_Tab_Updater();
            if (Auto_Axis_Enable.IsChecked)
            {
                Graph.Plot.AxisAuto();
            }
            Graph.Render();
        }
    }
}
