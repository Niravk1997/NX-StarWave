using MahApps.Metro.Controls;
using System;

namespace FFT_Waterfall
{
    public partial class FFT_Waterfall_Plotter : MetroWindow
    {
        private bool Is_Axis_Match = true;

        private void Right_Click_AxisMatch(object sender, EventArgs e)
        {
            if (AxisMatch_MenuItem.IsChecked == true)
            {
                Is_Axis_Match = true;
            }
            else
            {
                Is_Axis_Match = false;
            }
        }

        private void FFT_Graph_AxesChanged(object sender, EventArgs e)
        {
            try
            {
                if (Is_Axis_Match)
                {
                    Waterfall.Configuration.AxesChangedEventEnabled = false;
                    Graph.Configuration.AxesChangedEventEnabled = false;

                    ScottPlot.AxisLimits FFT_Graph_Limits = Graph.Plot.GetAxisLimits(0, 1);

                    double Waterfall_Graph_Max_X_Axis_Limit = Normalize_Value(FFT_Graph_Limits.XMax, Frequency[0], Frequency[FFT_Size - 1], 0, FFT_Size);
                    double Waterfall_Graph_Min_X_Axis_Limit = Normalize_Value(FFT_Graph_Limits.XMin, Frequency[0], Frequency[FFT_Size - 1], 0, FFT_Size);

                    Waterfall.Plot.SetAxisLimitsX(Waterfall_Graph_Min_X_Axis_Limit, Waterfall_Graph_Max_X_Axis_Limit);
                    Waterfall.Refresh();

                    Waterfall.Configuration.AxesChangedEventEnabled = true;
                    Graph.Configuration.AxesChangedEventEnabled = true;
                }
            }
            catch (Exception) { }
        }

        private void Waterfall_Graph_AxesChanged(object sender, EventArgs e)
        {
            try
            {
                if (Is_Axis_Match)
                {
                    Waterfall.Configuration.AxesChangedEventEnabled = false;
                    Graph.Configuration.AxesChangedEventEnabled = false;

                    ScottPlot.AxisLimits Waterfall_Graph_Limits = Waterfall.Plot.GetAxisLimits(0, 1);

                    double FFT_Graph_Max_X_Axis_Limit = Normalize_Value(Waterfall_Graph_Limits.XMax, 0, FFT_Size, Frequency[0], Frequency[FFT_Size - 1]);
                    double FFT_Graph_Min_X_Axis_Limit = Normalize_Value(Waterfall_Graph_Limits.XMin, 0, FFT_Size, Frequency[0], Frequency[FFT_Size - 1]);

                    Graph.Plot.SetAxisLimitsX(FFT_Graph_Min_X_Axis_Limit, FFT_Graph_Max_X_Axis_Limit);
                    Graph.Refresh();

                    Waterfall.Configuration.AxesChangedEventEnabled = true;
                    Graph.Configuration.AxesChangedEventEnabled = true;
                }
            }
            catch (Exception) { }
        }

        private double Normalize_Value(double Value, double Value_Minimum, double Value_Maximum, double Minimum, double Maximum)
        {
            return (((Value - Value_Minimum) / (Value_Maximum - Value_Minimum)) * (Maximum - Minimum)) + Minimum;
        }
    }
}
