using MahApps.Metro.Controls;
using System.Windows;

namespace XY_Waveform
{
    public partial class XY_Waveform_Plotter : MetroWindow
    {
        private string CH1_Units = "V";
        private string CH2_Units = "V";
        private string Math_Units = "V";

        private void CH2_Select_YAXIS_1(object sender, RoutedEventArgs e)
        {
            Waveform_Graph.Plot.YAxis2.Ticks(false);
            Waveform_Graph.Plot.YAxis2.Label("");
            Channel_2_Curve.YAxisIndex = 0;
            Waveform_Graph.Render();
            CH2_YAXIS_1_Option.IsChecked = true;
            CH2_YAXIS_2_Option.IsChecked = false;
        }

        private void CH2_Select_YAXIS_2(object sender, RoutedEventArgs e)
        {
            Waveform_Graph.Plot.YAxis2.Ticks(true);
            Waveform_Graph.Plot.YAxis2.Label("CH" + Channel_2_Selected_String);
            Channel_2_Curve.YAxisIndex = 1;
            Waveform_Graph.Render();
            CH2_YAXIS_1_Option.IsChecked = false;
            CH2_YAXIS_2_Option.IsChecked = true;
        }
    }
}
