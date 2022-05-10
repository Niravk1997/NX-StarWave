using Auto_Measurements;
using Axis_Scale_Config;
using MahApps.Metro.Controls;
using NX_StarWave.Misc;
using System;
using System.Windows;

namespace Anytime_Waveform
{
    public partial class Waveform : MetroWindow
    {
        //Waveform Curve
        private ScottPlot.Plottable.SignalPlotXY Waveform_Curve;

        //Waveform Curve Initial X,Y Array
        private double[] X_Waveform_Values;
        private double[] Y_Waveform_Values;

        private Helpful_Functions Functions = new Helpful_Functions();
        private Axis_Config Axis_Scale_Config = new Axis_Config();
        private Automatic_Measurements Waveform_Measurements = new Automatic_Measurements();

        private string Channel_Title;

        public Waveform(string Title, string Channel_Title, string Color, string YAxis_Units, string YAxis, double[] X_Waveform_Data, double[] Y_Waveform_Data, double Total_Time, double Start_Time, double Stop_Time, int Data_Points)
        {
            InitializeComponent();
            DataContext = this;
            Graph_RightClick_Menu();
            this.Title = Title;
            this.Channel_Title = Title;
            Axis_Scale_Config.Y_Axis_Units = YAxis_Units;
            Update_Window_Title(Title);
            Setup_Interpolation();
            Set_Default_Anytime_FFT_Color(Color);
            X_Waveform_Values = Functions.Copy_Array(X_Waveform_Data, Data_Points);
            Y_Waveform_Values = Functions.Copy_Array(Y_Waveform_Data, Data_Points);
            this.Total_Time = Total_Time;
            this.Start_Time = Start_Time;
            this.Stop_Time = Stop_Time;
            this.Data_Points = Data_Points;
            this.Channel_Info = Title;
            this.YAxis_Units = YAxis_Units;
            this.YAxis = YAxis;
            Channel_Info = Channel_Title;
            Process_Waveform(Channel_Title, Color);
        }

        private void Update_Window_Title(string Title)
        {
            Window_Title = Title;
        }

        private void Process_Waveform(string Label, string Color)
        {
            try
            {
                Draw_Waveform_Curve(Label, Color);
                Waveform_Measurements_Updater();
                Measure_Frequency_Period();
                Information_Tab_Updater();
            }
            catch (Exception Ex)
            {
                Insert_Log(Ex.Message, 1);
                Graph.Plot.AddAnnotation(Ex.Message, -10, -10);
                Graph.Plot.AddText("Failed to create an Anytime Waveform, try again.", 5, 0, size: 20, color: System.Drawing.Color.Red);
                Graph.Plot.AxisAuto();
                Graph.Render();
            }
        }

        private void Draw_Waveform_Curve(string Label, string Color)
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
            Graph.Plot.XAxis.Label("Time (s)");
            Graph.Plot.YAxis.Label(YAxis);
            Graph.Render();
        }

        private void Update_Waveform_Curve()
        {
            Waveform_Curve.MaxRenderIndex = 0;
            Waveform_Curve.Xs = X_Waveform_Values;
            Waveform_Curve.Ys = Y_Waveform_Values;
            Waveform_Curve.MaxRenderIndex = X_Waveform_Values.Length - 1;
            Graph.Render();
        }

        private void Waveform_Measurements_Updater()
        {
            Waveform_Mean = Waveform_Measurements.Mean(Y_Waveform_Values);
            Waveform_MAX = Waveform_Measurements.Maximum(Y_Waveform_Values);
            Waveform_MIN = Waveform_Measurements.Minimum(Y_Waveform_Values);
            Waveform_PKPK = Waveform_Measurements.Peak_Peak(Waveform_MAX, Waveform_MIN);
            Waveform_RMS = Waveform_Measurements.RMS(Y_Waveform_Values);
        }

        private void Measure_Frequency_Period()
        {
            Waveform_Period = Waveform_Measurements.Period(X_Waveform_Values, Y_Waveform_Values, Data_Points, Waveform_MAX, Waveform_MIN);
            Waveform_Frequency = Waveform_Measurements.Frequency(Waveform_Period);
        }

        private void Measure_Frequency_Period_Click(object sender, RoutedEventArgs e)
        {
            Measure_Frequency_Period();

            Frequency_Label = Axis_Scale_Config.Value_SI_Prefix(Waveform_Frequency, 5) + "Hz";
            Period_Label = Axis_Scale_Config.Value_SI_Prefix(Waveform_Period, 5) + "s";
        }
    }
}
