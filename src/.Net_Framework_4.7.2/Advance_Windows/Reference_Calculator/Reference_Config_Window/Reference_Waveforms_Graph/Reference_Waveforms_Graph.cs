using MahApps.Metro.Controls;

namespace Reference_Calculator
{
    public partial class Reference_Config_Panel : MetroWindow
    {
        //Waveform Curves
        private ScottPlot.Plottable.SignalPlotXY Reference_1_Waveform;
        private ScottPlot.Plottable.SignalPlotXY Reference_2_Waveform;
        private ScottPlot.Plottable.SignalPlotXY Reference_3_Waveform;
        private ScottPlot.Plottable.SignalPlotXY Reference_4_Waveform;
        private ScottPlot.Plottable.SignalPlotXY Reference_5_Waveform;
        private ScottPlot.Plottable.SignalPlotXY Reference_6_Waveform;
        private ScottPlot.Plottable.SignalPlotXY Reference_7_Waveform;
        private ScottPlot.Plottable.SignalPlotXY Reference_8_Waveform;

        private void Initialize_Reference_Waveforms_Graph()
        {
            if (ControlzEx.Theming.ThemeManager.Current.DetectTheme().BaseColorScheme.Equals("Dark"))
            {
                Graph.Plot.Style(ScottPlot.Style.Black);
                Graph.Plot.YAxis.Color(color: System.Drawing.ColorTranslator.FromHtml("#FFFFFFFF"));
                Graph.Plot.XAxis.Color(color: System.Drawing.ColorTranslator.FromHtml("#FFFFFFFF"));
            }
            Graph.Plot.XAxis.TickLabelFormat(Axis_Scale_Config.X_Axis_Time_SI_Prefix_Scale);
            Graph.Plot.YAxis.TickLabelFormat(Axis_Scale_Config.Y_Axis_SI_Prefix_Scale);
            Graph.Plot.Legend(true);
            Graph.Plot.XAxis.Label("Time (s)");
            Graph.Render();
        }

        private void Plot_Reference_1_Waveform()
        {
            Graph.Plot.Remove(Reference_1_Waveform);
            Reference_1_Waveform = Graph.Plot.AddSignalXY(Reference_1_X_Values, Reference_1_Y_Values, color: System.Drawing.ColorTranslator.FromHtml(Reference_1_Waveform_Color), label: Reference_1_Channel_Info);
            Graph.Render();
        }

        private void Plot_Reference_2_Waveform()
        {
            Graph.Plot.Remove(Reference_2_Waveform);
            Reference_2_Waveform = Graph.Plot.AddSignalXY(Reference_2_X_Values, Reference_2_Y_Values, color: System.Drawing.ColorTranslator.FromHtml(Reference_2_Waveform_Color), label: Reference_2_Channel_Info);
            Graph.Render();
        }

        private void Plot_Reference_3_Waveform()
        {
            Graph.Plot.Remove(Reference_3_Waveform);
            Reference_3_Waveform = Graph.Plot.AddSignalXY(Reference_3_X_Values, Reference_3_Y_Values, color: System.Drawing.ColorTranslator.FromHtml(Reference_3_Waveform_Color), label: Reference_3_Channel_Info);
            Graph.Render();
        }

        private void Plot_Reference_4_Waveform()
        {
            Graph.Plot.Remove(Reference_4_Waveform);
            Reference_4_Waveform = Graph.Plot.AddSignalXY(Reference_4_X_Values, Reference_4_Y_Values, color: System.Drawing.ColorTranslator.FromHtml(Reference_4_Waveform_Color), label: Reference_4_Channel_Info);
            Graph.Render();
        }

        private void Plot_Reference_5_Waveform()
        {
            Graph.Plot.Remove(Reference_5_Waveform);
            Reference_5_Waveform = Graph.Plot.AddSignalXY(Reference_5_X_Values, Reference_5_Y_Values, color: System.Drawing.ColorTranslator.FromHtml(Reference_5_Waveform_Color), label: Reference_5_Channel_Info);
            Graph.Render();
        }

        private void Plot_Reference_6_Waveform()
        {
            Graph.Plot.Remove(Reference_6_Waveform);
            Reference_6_Waveform = Graph.Plot.AddSignalXY(Reference_6_X_Values, Reference_6_Y_Values, color: System.Drawing.ColorTranslator.FromHtml(Reference_6_Waveform_Color), label: Reference_6_Channel_Info);
            Graph.Render();
        }

        private void Plot_Reference_7_Waveform()
        {
            Graph.Plot.Remove(Reference_7_Waveform);
            Reference_7_Waveform = Graph.Plot.AddSignalXY(Reference_7_X_Values, Reference_7_Y_Values, color: System.Drawing.ColorTranslator.FromHtml(Reference_7_Waveform_Color), label: Reference_7_Channel_Info);
            Graph.Render();
        }

        private void Plot_Reference_8_Waveform()
        {
            Graph.Plot.Remove(Reference_8_Waveform);
            Reference_8_Waveform = Graph.Plot.AddSignalXY(Reference_8_X_Values, Reference_8_Y_Values, color: System.Drawing.ColorTranslator.FromHtml(Reference_8_Waveform_Color), label: Reference_8_Channel_Info);
            Graph.Render();
        }
    }
}
