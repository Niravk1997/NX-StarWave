using Axis_Scale_Config;
using Interpolations;
using MahApps.Metro.Controls;
using MathNet.Numerics.IntegralTransforms;
using NX_StarWave.Misc;
using System;
using System.Linq;
using System.Numerics;

namespace Anytime_FFT
{
    public partial class FFT : MetroWindow
    {
        //FFT Curve
        private ScottPlot.Plottable.SignalPlotXY FFT_Waveform;

        //Phase Curve
        private ScottPlot.Plottable.SignalPlotXY Phase_Waveform;

        //Waveform Curve Initial X,Y Array
        private double[] X_Waveform_Values;
        private double[] Y_Waveform_Values;

        private double[] Frequency; //Frequency
        private double[] Magnitude; //Magnitude
        private double[] Phase; //Phase

        //Currently selected Y axis units
        private string Y_AXIS_Units;

        private Helpful_Functions Functions = new Helpful_Functions();
        private Axis_Config Axis_Scale_Config = new Axis_Config();

        private double FFT_Max;
        private double FFT_Min;

        private bool show_Peaks_Window_Size_Change = false;

        public FFT(string Title, string Channel_Info, string Channel_Title, string Color,
            double[] X_Waveform_Values, double[] Y_Waveform_Values, int Data_Points,
            double Total_Time, double Start_Time, double Stop_Time, int FFT_Window,
            bool Is_dBV, bool show_Peaks, int Peak_Window_Value, double Peak_Reference, bool show_Phase, bool Is_Phase_Degrees, double Phase_dB_Magnitude_suppression_Value, bool Apply_Interpolation, int Interpolation_Type, int Interpolation_Resample_Factor)
        {
            InitializeComponent();
            try
            {
                show_Peaks_Window_Size_Change = show_Peaks;
                this.Total_Time = Total_Time;
                this.Start_Time = Start_Time;
                this.Stop_Time = Stop_Time;
                this.Data_Points = Data_Points;
                this.Channel_Info = Channel_Info;
                this.Show_Phase = show_Phase;
                Graph_RightClick_Menu();
                Update_Window_Title(Title, Is_dBV);
                Create_FFT(Functions.Copy_Array(X_Waveform_Values, Data_Points), Functions.Copy_Array(Y_Waveform_Values, Data_Points), Data_Points, FFT_Window, Is_dBV, show_Phase, Is_Phase_Degrees, Phase_dB_Magnitude_suppression_Value, Total_Time);
                if (Apply_Interpolation)
                {
                    double[] X_Local;
                    Waveform_Interpolations Interpolation = new Waveform_Interpolations(Interpolation_Type);
                    if (show_Phase)
                    {
                        (X_Local, Phase) = Interpolation.Interpolation_Results(Frequency, Phase, Interpolation_Resample_Factor, Frequency[0], Frequency[((int)Data_Points / 2) - 1], (int)Data_Points / 2);
                    }
                    (Frequency, Magnitude) = Interpolation.Interpolation_Results(Frequency, Magnitude, Interpolation_Resample_Factor, Frequency[0], Frequency[((int)Data_Points / 2) - 1], (int)Data_Points / 2);
                }
                FFT_Min_Max_Updater();
                Draw_Waveform_Curve(Channel_Title, Color, Is_dBV, show_Phase, Is_Phase_Degrees);
                Information_Tab_Updater(Total_Time, (int)Data_Points, Channel_Info, FFT_Window);
                Create_Peaks(show_Peaks, Peak_Window_Value, Peak_Reference);
            }
            catch (Exception Ex)
            {
                Insert_Log(Ex.Message, 1);
                Graph.Plot.AddAnnotation(Ex.Message, -10, -10);
                Graph.Plot.AddText("Failed to create an Anytime FFT, try again.", 5, 0, size: 20, color: System.Drawing.Color.Red);
                Graph.Plot.AxisAuto();
                Graph.Render();
            }
        }

        private void Update_Window_Title(string Title, bool Is_dBV)
        {
            this.Title = Title;
            if (Is_dBV)
            {
                Y_AXIS_Units = "dB";
            }
            else
            {
                Y_AXIS_Units = "V";
            }
        }

        private void Create_FFT(double[] X_Waveform_Values_List, double[] Y_Waveform_Values_List,
            int Data_Points, int FFT_Window, bool Is_dBV, bool show_Phase, bool Is_Phase_Degrees,
            double Phase_dB_Magnitude_suppression_Value, double Total_Time)
        {
            X_Waveform_Values = X_Waveform_Values_List.ToArray();
            Y_Waveform_Values = Y_Waveform_Values_List.ToArray();

            if (FFT_Window > 0)
            {
                (bool isWindow, double[] Window_data) = FFT_Window_Array_Generate((int)Data_Points, FFT_Window);
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


            double SampleRate = Data_Points / Total_Time;
            Complex[] Samples = new Complex[(int)Data_Points];
            for (int i = 0; i < Data_Points; i++)
            {
                Samples[i] = new Complex(Y_Waveform_Values[i], 0.0);
            }
            Fourier.Forward(Samples, options: FourierOptions.NoScaling);

            Frequency = new double[Samples.Length / 2];
            Magnitude = new double[Samples.Length / 2];
            Phase = new double[Samples.Length / 2];
            if (Is_dBV == true)
            {
                for (int i = 0; i < (Samples.Length / 2); i++)
                {
                    double Magnitude = 20 * Math.Log10(((2.0 / Data_Points) * FFT_Window_Gain_Correction * Samples[i].Magnitude) / Math.Sqrt(2.0));
                    this.Magnitude[i] = Magnitude;
                    Frequency[i] = (SampleRate / Data_Points) * i;
                    if (show_Phase)
                    {
                        if (Magnitude < Phase_dB_Magnitude_suppression_Value)
                        {
                            Phase[i] = 0;
                        }
                        else
                        {
                            if (Is_Phase_Degrees)
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
                    this.Magnitude[i] = ((2.0 / Data_Points) * FFT_Window_Gain_Correction * Samples[i].Magnitude) / Math.Sqrt(2.0);
                    Frequency[i] = (SampleRate / Data_Points) * i;
                    if (show_Phase)
                    {
                        double Magnitude = 20 * Math.Log10(((2.0 / Data_Points) * FFT_Window_Gain_Correction * Samples[i].Magnitude) / Math.Sqrt(2.0));
                        if (Magnitude < Phase_dB_Magnitude_suppression_Value)
                        {
                            Phase[i] = 0;
                        }
                        else
                        {
                            if (Is_Phase_Degrees)
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
            FFT_Max = this.Magnitude.Max();
            FFT_Min = this.Magnitude.Min();
        }

        public void Draw_Waveform_Curve(string Label, string Color, bool Is_dBV, bool show_Phase, bool Is_Phase_Degrees)
        {
            if (ControlzEx.Theming.ThemeManager.Current.DetectTheme().BaseColorScheme.Equals("Dark"))
            {
                Graph.Plot.Style(ScottPlot.Style.Black);
                Graph.Plot.YAxis.Color(color: System.Drawing.ColorTranslator.FromHtml("#FFFFFFFF"));
                Graph.Plot.XAxis.Color(color: System.Drawing.ColorTranslator.FromHtml("#FFFFFFFF"));
            }
            Axis_Scale_Config.X_Axis_Units = "Hz";
            Graph.Plot.XAxis.TickLabelFormat(Axis_Scale_Config.X_Axis_Time_SI_Prefix_Scale);
            Graph.Plot.YAxis.TickLabelFormat(Axis_Scale_Config.Y_Axis_SI_Prefix_Scale);
            FFT_Waveform = Graph.Plot.AddSignalXY(Frequency, Magnitude, color: System.Drawing.ColorTranslator.FromHtml(Color), label: Label + " FFT");
            FFT_Waveform.MarkerSize = 1;
            Graph.Plot.XAxis.Label("Frequency (Hz)");
            if (Is_dBV)
            {
                Graph.Plot.YAxis.Label("Magnitude (dBV rms)");
                Axis_Scale_Config.Y_Axis_Units = "dB";
            }
            else
            {
                Graph.Plot.YAxis.Label("Magnitude (V rms)");
                Axis_Scale_Config.Y_Axis_Units = "V";
            }

            if (show_Phase)
            {
                Phase_Waveform = Graph.Plot.AddSignalXY(Frequency, Phase, color: System.Drawing.ColorTranslator.FromHtml("#D95319"), label: Label + " Phase");
                Phase_Waveform.MarkerSize = 1;
                Phase_Waveform.YAxisIndex = 1;
                Graph.Plot.YAxis2.Ticks(true);
                if (Is_Phase_Degrees)
                {
                    Graph.Plot.YAxis2.Label("Phase (Degrees)");
                }
                else
                {
                    Graph.Plot.YAxis2.Label("Phase (Radians)");
                }
            }
            Graph.Render();
        }

        private void Update_Peaks_Label_X_Coordiniates(double X_Coordinates)
        {
            if (Total_Peaks >= 1) { P1_Label.X = X_Coordinates; }
            if (Total_Peaks >= 2) { P2_Label.X = X_Coordinates; }
            if (Total_Peaks >= 3) { P3_Label.X = X_Coordinates; }
            if (Total_Peaks >= 4) { P4_Label.X = X_Coordinates; }
            if (Total_Peaks >= 5) { P5_Label.X = X_Coordinates; }
            if (Total_Peaks >= 6) { P6_Label.X = X_Coordinates; }
            if (Total_Peaks >= 7) { P7_Label.X = X_Coordinates; }
            if (Total_Peaks >= 8) { P8_Label.X = X_Coordinates; }
            if (Total_Peaks >= 9) { P9_Label.X = X_Coordinates; }
            if (Total_Peaks >= 10) { P10_Label.X = X_Coordinates; }
        }
    }
}
