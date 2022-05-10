using Axis_Scale_Config;
using MahApps.Metro.Controls;
using NX_StarWave.Misc;
using System;

namespace Anytime_Histogram
{
    public partial class Histogram : MetroWindow
    {
        private double[] X_Waveform_Values;
        private double[] Y_Waveform_Values;

        //Waveform Curve
        private ScottPlot.Plottable.BarPlot Histogram_Plot;
        private MathNet.Numerics.Statistics.Histogram Histogram_Data;

        //Histogram Values
        private double[] values;
        private double[] positions;

        private Helpful_Functions Functions = new Helpful_Functions();
        private Axis_Config Axis_Scale_Config = new Axis_Config();

        public Histogram(string Title, string Channel_Title, string Color, string YAxis_Units, string YAxis, double[] X_Waveform_Data, double[] Y_Waveform_Data, double Total_Time, double Start_Time, double Stop_Time, int Data_Points, int Total_Buckets)
        {
            InitializeComponent();
            DataContext = this;
            Graph_RightClick_Menu();
            Update_Window_Title(Title);
            Axis_Scale_Config.Y_Axis_Units = YAxis_Units;
            X_Waveform_Values = Functions.Copy_Array(X_Waveform_Data, Data_Points);
            Y_Waveform_Values = Functions.Copy_Array(Y_Waveform_Data, Data_Points);
            this.Total_Time = Total_Time;
            this.Start_Time = Start_Time;
            this.Stop_Time = Stop_Time;
            this.Data_Points = Data_Points;
            this.Channel_Info = Title;
            this.YAxis_Units = YAxis_Units;
            this.YAxis = YAxis;
            Bucket_Count = Total_Buckets;
            Channel_Info = Channel_Title;
            Try_Creating_Histogram_Plot(Channel_Title, Color);
        }

        private void Update_Window_Title(string Title)
        {
            Window_Title = Title;
        }

        private void Try_Creating_Histogram_Plot(string Channel_Title, string Color)
        {
            try
            {
                Process_Histogram_Data();
                Plot_Histogram_Curve(Channel_Title, Color);
                Information_Tab_Updater();
            }
            catch (Exception Ex)
            {
                Insert_Log(Ex.Message, 1);
            }
        }

        private void Process_Histogram_Data()
        {
            Histogram_Data = new MathNet.Numerics.Statistics.Histogram(Y_Waveform_Values, Bucket_Count);

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

        private void Plot_Histogram_Curve(string Channel_Title, string Color)
        {
            if (ControlzEx.Theming.ThemeManager.Current.DetectTheme().BaseColorScheme.Equals("Dark"))
            {
                Graph.Plot.Style(ScottPlot.Style.Black);
                Graph.Plot.YAxis.Color(color: System.Drawing.ColorTranslator.FromHtml("#FFFFFFFF"));
                Graph.Plot.XAxis.Color(color: System.Drawing.ColorTranslator.FromHtml("#FFFFFFFF"));
            }
            Graph.Plot.XAxis.TickLabelFormat(Axis_Scale_Config.Y_Axis_SI_Prefix_Scale);
            Graph.Plot.XAxis.Label(YAxis);
            Graph.Plot.YAxis.Label("Count (#)");
            Histogram_Plot = Graph.Plot.AddBar(values, positions, color: System.Drawing.ColorTranslator.FromHtml(Color));
            Histogram_Plot.Label = Channel_Title;

            if (double.IsInfinity(Histogram_Data[0].Width / 2) || double.IsNaN(Histogram_Data[0].Width / 2))
            {
                Histogram_Plot.PositionOffset = 0;
            }
            else
            {
                Histogram_Plot.PositionOffset = Histogram_Data[0].Width / 2;
            }
            if (Histogram_Data[0].Width > 0.000000000001)
            {
                Histogram_Plot.BarWidth = Histogram_Data[0].Width;
            }
            else
            {
                Histogram_Plot.BarWidth = 0.01;
            }
            Graph.Refresh();
        }
    }
}
