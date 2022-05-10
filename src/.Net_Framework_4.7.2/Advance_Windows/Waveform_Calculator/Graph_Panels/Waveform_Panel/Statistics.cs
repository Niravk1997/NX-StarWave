using System.Windows.Controls;

namespace Waveform_Panel
{
    public partial class Waveform_Panel : UserControl
    {
        private ScottPlot.Plottable.Annotation Annotation_Statistics;
        private bool Statistics_Enabled = false;
        private bool Measure_Frequency_Period = true;

        private double Frequency = 0;
        private double Period = 0;
        private double PK_PK = 0;
        private double Mean = 0;
        private double RMS = 0;
        private double Max = 0;
        private double Min = 0;

        private void Initialize_Statistics_Annotations()
        {
            if (Voltage_Meas.IsChecked)
            {
                Annotation_Statistics = Graph.Plot.AddAnnotation("", 5, Annotation_Statistics_Placement_Offset());
                Annotation_Statistics.Font.Size = 14;
                Annotation_Statistics.Shadow = false;
                Annotation_Statistics.BackgroundColor = System.Drawing.ColorTranslator.FromHtml("#A3FFFFFF");
                Annotation_Statistics.BorderColor = System.Drawing.ColorTranslator.FromHtml("#00FFFFFF");
                Annotation_Statistics.Font.Color = System.Drawing.ColorTranslator.FromHtml("#FFFF0000");
                SizeChanged += Waveform_Panel_SizeChanged;
                Statistics_Enabled = true;
                Graph.Render();
            }
            else
            {
                SizeChanged -= Waveform_Panel_SizeChanged;
                Statistics_Enabled = false;
                Graph.Plot.Remove(plottable: Annotation_Statistics);
                Graph.Render();
            }
        }

        private void Calculate_Statistics()
        {
            if (Statistics_Enabled)
            {
                Mean = Waveform_Measurements.Mean(Y_Data);
                Max = Waveform_Measurements.Maximum(Y_Data);
                Min = Waveform_Measurements.Minimum(Y_Data);
                PK_PK = Waveform_Measurements.Peak_Peak(Max, Min);
                RMS = Waveform_Measurements.RMS(Y_Data);

                if (Measure_Frequency_Period)
                {
                    Period = Waveform_Measurements.Period(X_Data, Y_Data, Data_Points, Max, Min);
                    Frequency = Waveform_Measurements.Frequency(Period);
                }
            }
        }

        private void Update_Statistics_Annotations()
        {
            if (Statistics_Enabled)
            {
                if (Measure_Frequency_Period)
                {
                    Annotation_Statistics.Label = "Freq: " + Axis_Scale_Config.Value_SI_Prefix(Frequency, 5) + "Hz" + "\n"
                        + "Per: " + Axis_Scale_Config.Value_SI_Prefix(Period, 5) + "s" + "\n"
                        + "PK-PK: " + Axis_Scale_Config.Value_SI_Prefix(PK_PK, 3) + Y_Axis_Units + "\n"
                        + "Mean: " + Axis_Scale_Config.Value_SI_Prefix(Mean, 3) + Y_Axis_Units + "\n"
                        + "RMS: " + Axis_Scale_Config.Value_SI_Prefix(RMS, 3) + Y_Axis_Units + "\n"
                        + "Max: " + Axis_Scale_Config.Value_SI_Prefix(Max, 3) + Y_Axis_Units + "\n"
                        + "Min: " + Axis_Scale_Config.Value_SI_Prefix(Min, 3) + Y_Axis_Units;
                }
                else
                {
                    Annotation_Statistics.Label = "PK-PK: " + Axis_Scale_Config.Value_SI_Prefix(PK_PK, 3) + Y_Axis_Units + "\n"
                        + "Mean: " + Axis_Scale_Config.Value_SI_Prefix(Mean, 3) + Y_Axis_Units + "\n"
                        + "RMS: " + Axis_Scale_Config.Value_SI_Prefix(RMS, 3) + Y_Axis_Units + "\n"
                        + "Max: " + Axis_Scale_Config.Value_SI_Prefix(Max, 3) + Y_Axis_Units + "\n"
                        + "Min: " + Axis_Scale_Config.Value_SI_Prefix(Min, 3) + Y_Axis_Units;
                }
            }
        }
    }
}
