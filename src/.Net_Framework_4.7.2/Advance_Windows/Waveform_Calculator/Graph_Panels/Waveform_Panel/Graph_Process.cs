using System;
using System.Windows.Controls;

namespace Waveform_Panel
{
    public partial class Waveform_Panel : UserControl
    {
        private ScottPlot.Plottable.SignalPlotXY Expression_Waveform;
        private ScottPlot.Plottable.SignalPlot Expression_Waveform_Continuous;

        private void Graph_Initialize()
        {
            if (ControlzEx.Theming.ThemeManager.Current.DetectTheme().BaseColorScheme.Equals("Dark"))
            {
                Graph.Plot.Style(ScottPlot.Style.Black);
                Graph.Plot.YAxis.Color(color: System.Drawing.ColorTranslator.FromHtml("#FFFFFFFF"));
                Graph.Plot.XAxis.Color(color: System.Drawing.ColorTranslator.FromHtml("#FFFFFFFF"));
            }
            Graph.Plot.XAxis.TickLabelFormat(Axis_Scale_Config.X_Axis_Time_SI_Prefix_Scale);
            Graph.Plot.YAxis.TickLabelFormat(Axis_Scale_Config.Y_Axis_SI_Prefix_Scale);
            if (isContinuous == true)
            {
                Y_Data = new double[1000000];
                X_Data = new double[1];
                Expression_Waveform_Continuous = Graph.Plot.AddSignal(Y_Data, color: System.Drawing.ColorTranslator.FromHtml(Waveform_Color), label: Waveform_Title);
                Expression_Waveform_Continuous.MaxRenderIndex = 0;
                Graph.Plot.XAxis.Label("N Samples");
            }
            else
            {
                Y_Data = new double[1];
                X_Data = new double[1];
                Expression_Waveform = Graph.Plot.AddSignalXY(X_Data, Y_Data, System.Drawing.ColorTranslator.FromHtml(Waveform_Color), Waveform_Title);
                Expression_Waveform.MaxRenderIndex = 0;
                Graph.Plot.XAxis.Label("Time (s)");
            }
            if (Waveform_Title != "" || Waveform_Title != string.Empty)
            {
                Graph.Plot.Title(Waveform_Title);
            }
            Graph.Plot.YAxis.Label(Y_Axis_Title);
            Initialize_Error_Annotation();
            Graph.Refresh();
        }

        private void Plot_Waveform_Data()
        {
            try
            {
                if (isContinuous == false)
                {
                    Expression_Waveform.MaxRenderIndex = 0;
                    Expression_Waveform.Xs = X_Data;
                    Expression_Waveform.Ys = Y_Data;
                    Expression_Waveform.MaxRenderIndex = Data_Points - 1;
                    Update_Statistics_Annotations();
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
