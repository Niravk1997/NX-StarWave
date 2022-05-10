using System;
using System.Windows.Controls;

namespace Histogram_Panel
{
    public partial class Histogram_Panel : UserControl
    {
        private ScottPlot.Plottable.BarPlot Histogram;
        private MathNet.Numerics.Statistics.Histogram Histogram_Data;

        private void Graph_Initialize()
        {
            if (ControlzEx.Theming.ThemeManager.Current.DetectTheme().BaseColorScheme.Equals("Dark"))
            {
                Graph.Plot.Style(ScottPlot.Style.Black);
                Graph.Plot.YAxis.Color(color: System.Drawing.ColorTranslator.FromHtml("#FFFFFFFF"));
                Graph.Plot.XAxis.Color(color: System.Drawing.ColorTranslator.FromHtml("#FFFFFFFF"));
            }
            Graph.Plot.XAxis.TickLabelFormat(Axis_Scale_Config.X_Axis_Time_SI_Prefix_Scale);
            if (isContinuous == true)
            {
                Y_Data = new double[1000000];
            }
            else
            {
                Y_Data = new double[1];
            }
            if (Histogram_Title != "" || Histogram_Title != string.Empty)
            {
                Graph.Plot.Title(Histogram_Title);
            }
            Histogram = Graph.Plot.AddBar(values, positions, color: System.Drawing.ColorTranslator.FromHtml(Histogram_Color));
            Graph.Plot.XAxis.Label(X_Axis_Title);
            Graph.Plot.YAxis.Label("Count #");
            Initialize_Error_Annotation();
            Graph.Refresh();
        }

        private void Plot_Waveform_Data()
        {
            try
            {
                Histogram.Values = values;
                Histogram.Positions = positions;
                Histogram.ValueErrors = ScottPlot.DataGen.Zeros(values.Length);
                Histogram.ValueOffsets = ScottPlot.DataGen.Zeros(values.Length);
                if (double.IsInfinity(Histogram_Data[0].Width / 2) || double.IsNaN(Histogram_Data[0].Width / 2))
                {
                    Histogram.PositionOffset = 0;
                }
                else
                {
                    Histogram.PositionOffset = Histogram_Data[0].Width / 2;
                }
                if (Histogram_Data[0].Width > 0.000000000001)
                {
                    Histogram.BarWidth = Histogram_Data[0].Width;
                }
                else
                {
                    Histogram.BarWidth = 0.01;
                }
                if (AutoAxis_MenuItem.IsChecked == true)
                {
                    Graph.Plot.AxisAuto();
                }
                Graph.Refresh();
            }
            catch (Exception)
            {

            }
        }
    }
}
