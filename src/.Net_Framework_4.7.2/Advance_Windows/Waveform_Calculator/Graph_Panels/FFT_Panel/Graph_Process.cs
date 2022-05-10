using System;
using System.Windows.Controls;

namespace FFT_Panel
{
    public partial class FFT_Panel : UserControl
    {
        private ScottPlot.Plottable.SignalPlotXY Expression_FFT;
        private ScottPlot.Plottable.SignalPlotXY Expression_Phase;

        private void FFT_Plot_Initialize()
        {
            if (ControlzEx.Theming.ThemeManager.Current.DetectTheme().BaseColorScheme.Equals("Dark"))
            {
                Graph.Plot.Style(ScottPlot.Style.Black);
                Graph.Plot.YAxis.Color(color: System.Drawing.ColorTranslator.FromHtml("#FFFFFFFF"));
                Graph.Plot.XAxis.Color(color: System.Drawing.ColorTranslator.FromHtml("#FFFFFFFF"));
            }
            Graph.Plot.XAxis.TickLabelFormat(Axis_Scale_Config.X_Axis_Time_SI_Prefix_Scale); //X Axis
            Graph.Plot.YAxis.TickLabelFormat(Axis_Scale_Config.Y_Axis_SI_Prefix_Scale); //Y Axis
            Expression_FFT = Graph.Plot.AddSignalXY(Frequency, Magnitude, System.Drawing.ColorTranslator.FromHtml(FFT_Color), FFT_Title);
            Expression_FFT.MaxRenderIndex = 0;
            Graph.Plot.Title(FFT_Title);
            Graph.Plot.XAxis.Label("Frequency (Hz)");
            Axis_Scale_Config.X_Axis_Units = "Hz";
            if (FFT_Units_dB)
            {
                Graph.Plot.YAxis.Label("Magitude (dB) " + Y_Axis_Title);
                Axis_Scale_Config.Y_Axis_Units = "dB";
            }
            else
            {
                Graph.Plot.YAxis.Label("Magitude " + Y_Axis_Title);
                Axis_Scale_Config.Y_Axis_Units = Y_Axis_units;
            }
            if (Show_Phase)
            {
                Expression_Phase = Graph.Plot.AddSignalXY(Frequency, Phase, System.Drawing.ColorTranslator.FromHtml("#D95319"), "Phase");
                Expression_Phase.YAxisIndex = 1;
                Graph.Plot.YAxis2.Ticks(true);
                Expression_Phase.IsVisible = true;
                if (Phase_Units_Degree)
                {
                    Graph.Plot.YAxis2.Label("Phase (Degrees)");
                }
                else
                {
                    Graph.Plot.YAxis2.Label("Phase (Radians)");
                }
            }
            Initialize_Error_Annotation();
            Graph.Refresh();
        }

        private void Plot_FFT_Data()
        {
            try
            {
                Expression_FFT.MaxRenderIndex = 0;
                Expression_FFT.Xs = Frequency;
                Expression_FFT.Ys = Magnitude;
                Expression_FFT.MaxRenderIndex = Frequency.Length - 1;
                if (Show_Phase)
                {
                    Expression_Phase.MaxRenderIndex = 0;
                    Expression_Phase.Xs = Frequency;
                    Expression_Phase.Ys = Phase;
                    Expression_Phase.MaxRenderIndex = Frequency.Length - 1;
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
