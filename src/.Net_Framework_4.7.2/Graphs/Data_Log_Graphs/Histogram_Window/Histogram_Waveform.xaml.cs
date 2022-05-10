using MahApps.Metro.Controls;
using MathNet.Numerics.Statistics;
using System;
using System.Linq;

namespace Channel_DataLogger
{
    /// <summary>
    /// Interaction logic for Histogram_Waveform.xaml
    /// </summary>
    public partial class Histogram_Waveform : MetroWindow
    {
        private double[] Measurement_Data;

        private int Measurement_Count;

        //determines the maximum and minimum histogram value, calculated from Measurement_Data array
        private double maxValue;
        private double minValue;

        public Histogram_Waveform(string Graph_Owner, string Window_Title, int Start_Sample, int End_Sample, string Graph_Title, string X_Axis_Label, int Red, int Green, int Blue, double[] Measurement_Data, int Measurement_Count, int Buckets, double BarWidth, float BarBorder, bool Curve)
        {
            InitializeComponent();
            Graph_RightClick_Menu();
            DataContext = this;
            this.Title = Graph_Owner + " " + Window_Title;
            this.Measurement_Data = Measurement_Data;
            this.Measurement_Count = Measurement_Count;
            maxValue = this.Measurement_Data.Maximum();
            minValue = this.Measurement_Data.Minimum();
            Graph.Plot.Title(Graph_Title);

            Add_Histogram(X_Axis_Label, Buckets, Red, Green, Blue, BarWidth, BarBorder, Curve, Measurement_Count, maxValue, minValue);

            Start_Sample_Label.Content = Start_Sample;
            End_Sample_Label.Content = End_Sample;
            Buckets_Label.Content = Buckets;
        }

        private void Add_Histogram(string X_Axis_Label, int Buckets, int Red, int Green, int Blue, double BarWidth, float BarBorder, bool Curve, int Measurement_Count, double maxValue, double minValue)
        {
            try
            {
                MathNet.Numerics.Statistics.Histogram Histogram_Data = new MathNet.Numerics.Statistics.Histogram(Measurement_Data, Buckets);
                double[] values = new double[Histogram_Data.BucketCount];
                double[] positions = new double[Histogram_Data.BucketCount];

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

                double Bucket_Count = Histogram_Data.BucketCount;
                double Data_Count = Histogram_Data.DataCount;
                double LowerBound = Histogram_Data.LowerBound;
                double UpperBound = Histogram_Data.UpperBound;

                ScottPlot.Plottable.BarPlot Histogram = Graph.Plot.AddBar(values, positions, color: System.Drawing.Color.FromArgb(Red, Green, Blue));

                if (double.IsInfinity(Histogram_Data[0].Width / 2) || double.IsNaN(Histogram_Data[0].Width / 2))
                {
                    Histogram.PositionOffset = 0;
                }
                else
                {
                    Histogram.PositionOffset = Histogram_Data[0].Width / 2;
                }

                Histogram.BarWidth = Histogram_Data[0].Width;

                if (BarWidth == 0)
                {
                    Histogram.BarWidth = Histogram_Data[0].Width;
                }
                else
                {
                    Histogram.BarWidth = BarWidth;
                }

                Histogram.BorderLineWidth = BarBorder;

                if (Curve == true)
                {
                    Graph.Plot.AddScatterLines(xs: positions, ys: values, color: System.Drawing.Color.Black, lineWidth: BarBorder, lineStyle: ScottPlot.LineStyle.Solid);
                }

                Total_Samples_Label.Content = this.Measurement_Count;
                Positive_Samples_Label.Content = this.Measurement_Data.Where(x => x >= 0).Count();
                Negative_Samples_Label.Content = this.Measurement_Data.Where(x => x < 0).Count();
                Sample_Average_Label.Content = (decimal)Math.Round(this.Measurement_Data.Mean(), 6);
                Max_Recorded_Sample_Label.Content = (decimal)maxValue;
                Min_Recorded_Sample_Label.Content = (decimal)minValue;
                if (ControlzEx.Theming.ThemeManager.Current.DetectTheme().BaseColorScheme.Equals("Dark"))
                {
                    Graph.Plot.Style(ScottPlot.Style.Black);
                    Graph.Plot.YAxis.Color(color: System.Drawing.ColorTranslator.FromHtml("#FFFFFFFF"));
                    Graph.Plot.XAxis.Color(color: System.Drawing.ColorTranslator.FromHtml("#FFFFFFFF"));
                }
                Graph.Plot.YAxis.Label("Count (#)");
                Graph.Plot.XAxis.Label(X_Axis_Label);
                Graph.Plot.SetAxisLimits(yMin: 0);
                Graph.Render();
            }
            catch (Exception Ex)
            {
                Graph.Plot.AddAnnotation(Ex.Message, -10, -10);
                Graph.Plot.AddText("Failed to create an Histogram, try again.", 5, 0, size: 20, color: System.Drawing.Color.Red);
                Graph.Plot.AxisAuto();
                Graph.Render();
            }
        }
    }
}
