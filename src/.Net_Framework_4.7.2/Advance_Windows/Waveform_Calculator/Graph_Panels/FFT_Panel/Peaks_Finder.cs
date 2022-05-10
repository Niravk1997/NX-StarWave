using ScottPlot;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Controls;

namespace FFT_Panel
{
    public partial class FFT_Panel : UserControl
    {
        private int Total_Peaks_Found = 0;

        private double[] Peaks_X_Values = new double[10];
        private double[] Peaks_Y_Values = new double[10];

        private ScottPlot.Plottable.Text P1;
        private ScottPlot.Plottable.Text P2;
        private ScottPlot.Plottable.Text P3;
        private ScottPlot.Plottable.Text P4;
        private ScottPlot.Plottable.Text P5;
        private ScottPlot.Plottable.Text P6;
        private ScottPlot.Plottable.Text P7;
        private ScottPlot.Plottable.Text P8;
        private ScottPlot.Plottable.Text P9;
        private ScottPlot.Plottable.Text P10;

        private ScottPlot.Plottable.Annotation P1_Label;
        private ScottPlot.Plottable.Annotation P2_Label;
        private ScottPlot.Plottable.Annotation P3_Label;
        private ScottPlot.Plottable.Annotation P4_Label;
        private ScottPlot.Plottable.Annotation P5_Label;
        private ScottPlot.Plottable.Annotation P6_Label;
        private ScottPlot.Plottable.Annotation P7_Label;
        private ScottPlot.Plottable.Annotation P8_Label;
        private ScottPlot.Plottable.Annotation P9_Label;
        private ScottPlot.Plottable.Annotation P10_Label;

        private readonly int Frequency_Value_Round = 1;
        private readonly int Magnitude_Value_Round = 3;

        private double Peak_Label_Offset = -5;

        private ScottPlot.Plottable.HLine Peak_Reference_Level_Marker;
        private string Y_AXIS_Units = "";

        private void Peaks_Initialize()
        {
            Initialize_Peaks_Reference_Level();
            Initialize_Plottable_Peaks();
        }

        private void Initialize_Peaks_Reference_Level()
        {
            Peak_Reference_Level_Marker = Graph.Plot.AddHorizontalLine(Peaks_Ignore_value, color: System.Drawing.Color.Orange, style: LineStyle.Dash, label: "Peak Ref");
            Peak_Reference_Level_Marker.DragEnabled = true;
            Peak_Reference_Level_Marker.PositionLabel = true;
            Peak_Reference_Level_Marker.Dragged += Peaks_Reference_Level_Dragged_Event;
            Peak_Reference_Level_Marker.PositionLabelBackground = System.Drawing.Color.Orange;
        }

        private void Peaks_Reference_Level_Dragged_Event(object sender, EventArgs eventArgs)
        {
            Peaks_Ignore_value = Peak_Reference_Level_Marker.Y;
        }

        private void Initialize_Plottable_Peaks()
        {
            if (FFT_Units_dB)
            {
                Y_AXIS_Units = "dB";
            }
            else
            {
                Y_AXIS_Units = "V";
            }
            P1 = Graph.Plot.AddText("P1", 0, 0, 12, color: System.Drawing.ColorTranslator.FromHtml("#ff0000"));
            P1.Alignment = Alignment.MiddleCenter;
            P1.IsVisible = false;

            P1_Label = Graph.Plot.AddAnnotation("P1: 0Hz, 0" + Y_AXIS_Units, Peak_Label_Offset, 0);
            P1_Label.Font.Size = 12;
            P1_Label.Shadow = false;
            P1_Label.BackgroundColor = System.Drawing.ColorTranslator.FromHtml("#00FFFFFF");
            P1_Label.BorderColor = System.Drawing.ColorTranslator.FromHtml("#00FFFFFF");
            P1_Label.Font.Color = System.Drawing.ColorTranslator.FromHtml("#ff0000");
            P1_Label.IsVisible = false;

            P2 = Graph.Plot.AddText("P2", 0, 0, 12, color: System.Drawing.ColorTranslator.FromHtml("#ff33cc"));
            P2.Alignment = Alignment.MiddleCenter;
            P2.IsVisible = false;

            P2_Label = Graph.Plot.AddAnnotation("P2: 0Hz, 0" + Y_AXIS_Units, Peak_Label_Offset, 15);
            P2_Label.Font.Size = 12;
            P2_Label.Shadow = false;
            P2_Label.BackgroundColor = System.Drawing.ColorTranslator.FromHtml("#00FFFFFF");
            P2_Label.BorderColor = System.Drawing.ColorTranslator.FromHtml("#00FFFFFF");
            P2_Label.Font.Color = System.Drawing.ColorTranslator.FromHtml("#ff33cc");
            P2_Label.IsVisible = false;

            P3 = Graph.Plot.AddText("P3", 0, 0, 12, color: System.Drawing.ColorTranslator.FromHtml("#f58231"));
            P3.Alignment = Alignment.MiddleCenter;
            P3.IsVisible = false;

            P3_Label = Graph.Plot.AddAnnotation("P3: 0Hz, 0" + Y_AXIS_Units, Peak_Label_Offset, 30);
            P3_Label.Font.Size = 12;
            P3_Label.Shadow = false;
            P3_Label.BackgroundColor = System.Drawing.ColorTranslator.FromHtml("#00FFFFFF");
            P3_Label.BorderColor = System.Drawing.ColorTranslator.FromHtml("#00FFFFFF");
            P3_Label.Font.Color = System.Drawing.ColorTranslator.FromHtml("#f58231");
            P3_Label.IsVisible = false;

            P4 = Graph.Plot.AddText("P4", 0, 0, 12, color: System.Drawing.ColorTranslator.FromHtml("#4363d8"));
            P4.Alignment = Alignment.MiddleCenter;
            P4.IsVisible = false;

            P4_Label = Graph.Plot.AddAnnotation("P4: 0Hz, 0" + Y_AXIS_Units, Peak_Label_Offset, 45);
            P4_Label.Font.Size = 12;
            P4_Label.Shadow = false;
            P4_Label.BackgroundColor = System.Drawing.ColorTranslator.FromHtml("#00FFFFFF");
            P4_Label.BorderColor = System.Drawing.ColorTranslator.FromHtml("#00FFFFFF");
            P4_Label.Font.Color = System.Drawing.ColorTranslator.FromHtml("#4363d8");
            P4_Label.IsVisible = false;

            P5 = Graph.Plot.AddText("P5", 0, 0, 12, color: System.Drawing.ColorTranslator.FromHtml("#3399ff"));
            P5.Alignment = Alignment.MiddleCenter;
            P5.IsVisible = false;

            P5_Label = Graph.Plot.AddAnnotation("P5: 0Hz, 0" + Y_AXIS_Units, Peak_Label_Offset, 60);
            P5_Label.Font.Size = 12;
            P5_Label.Shadow = false;
            P5_Label.BackgroundColor = System.Drawing.ColorTranslator.FromHtml("#00FFFFFF");
            P5_Label.BorderColor = System.Drawing.ColorTranslator.FromHtml("#00FFFFFF");
            P5_Label.Font.Color = System.Drawing.ColorTranslator.FromHtml("#3399ff");
            P5_Label.IsVisible = false;

            P6 = Graph.Plot.AddText("P6", 0, 0, 12, color: System.Drawing.ColorTranslator.FromHtml("#009900"));
            P6.Alignment = Alignment.MiddleCenter;
            P6.IsVisible = false;

            P6_Label = Graph.Plot.AddAnnotation("P6: 0Hz, 0" + Y_AXIS_Units, Peak_Label_Offset, 75);
            P6_Label.Font.Size = 12;
            P6_Label.Shadow = false;
            P6_Label.BackgroundColor = System.Drawing.ColorTranslator.FromHtml("#00FFFFFF");
            P6_Label.BorderColor = System.Drawing.ColorTranslator.FromHtml("#00FFFFFF");
            P6_Label.Font.Color = System.Drawing.ColorTranslator.FromHtml("#009900");
            P6_Label.IsVisible = false;

            P7 = Graph.Plot.AddText("P7", 0, 0, 12, color: System.Drawing.ColorTranslator.FromHtml("#b37700"));
            P7.Alignment = Alignment.MiddleCenter;
            P7.IsVisible = false;

            P7_Label = Graph.Plot.AddAnnotation("P7: 0Hz, 0" + Y_AXIS_Units, Peak_Label_Offset, 90);
            P7_Label.Font.Size = 12;
            P7_Label.Shadow = false;
            P7_Label.BackgroundColor = System.Drawing.ColorTranslator.FromHtml("#00FFFFFF");
            P7_Label.BorderColor = System.Drawing.ColorTranslator.FromHtml("#00FFFFFF");
            P7_Label.Font.Color = System.Drawing.ColorTranslator.FromHtml("#b37700");
            P7_Label.IsVisible = false;

            P8 = Graph.Plot.AddText("P8", 0, 0, 12, color: System.Drawing.ColorTranslator.FromHtml("#911eb4"));
            P8.Alignment = Alignment.MiddleCenter;
            P8.IsVisible = false;

            P8_Label = Graph.Plot.AddAnnotation("P8: 0Hz, 0" + Y_AXIS_Units, Peak_Label_Offset, 105);
            P8_Label.Font.Size = 12;
            P8_Label.Shadow = false;
            P8_Label.BackgroundColor = System.Drawing.ColorTranslator.FromHtml("#00FFFFFF");
            P8_Label.BorderColor = System.Drawing.ColorTranslator.FromHtml("#00FFFFFF");
            P8_Label.Font.Color = System.Drawing.ColorTranslator.FromHtml("#911eb4");
            P8_Label.IsVisible = false;

            P9 = Graph.Plot.AddText("P9", 0, 0, 12, color: System.Drawing.ColorTranslator.FromHtml("#00cc44"));
            P9.Alignment = Alignment.MiddleCenter;
            P9.IsVisible = false;

            P9_Label = Graph.Plot.AddAnnotation("P9: 0Hz, 0" + Y_AXIS_Units, Peak_Label_Offset, 120);
            P9_Label.Font.Size = 12;
            P9_Label.Shadow = false;
            P9_Label.BackgroundColor = System.Drawing.ColorTranslator.FromHtml("#00FFFFFF");
            P9_Label.BorderColor = System.Drawing.ColorTranslator.FromHtml("#00FFFFFF");
            P9_Label.Font.Color = System.Drawing.ColorTranslator.FromHtml("#00cc44");
            P9_Label.IsVisible = false;

            P10 = Graph.Plot.AddText("P10", 0, 0, 12, color: System.Drawing.ColorTranslator.FromHtml("#000080"));
            P10.Alignment = Alignment.MiddleCenter;
            P10.IsVisible = false;

            P10_Label = Graph.Plot.AddAnnotation("P10: 0Hz, 0" + Y_AXIS_Units, Peak_Label_Offset, 135);
            P10_Label.Font.Size = 12;
            P10_Label.Shadow = false;
            P10_Label.BackgroundColor = System.Drawing.ColorTranslator.FromHtml("#00FFFFFF");
            P10_Label.BorderColor = System.Drawing.ColorTranslator.FromHtml("#00FFFFFF");
            P10_Label.Font.Color = System.Drawing.ColorTranslator.FromHtml("#000080");
            P10_Label.IsVisible = false;
        }

        private void Peak_Finder()
        {
            int Local_WindowSize = Peaks_Window_Size;
            double Local_Peak_Reference_Level = Peaks_Ignore_value;
            IEnumerable<Tuple<int, double>> Peaks = LocalMaxima(Magnitude, Local_WindowSize, Local_Peak_Reference_Level);
            Peaks.OrderByDescending(x => x.Item2);
            Total_Peaks_Found = Peaks.Count();

            int i = 0;
            foreach (Tuple<int, double> Value in Peaks)
            {
                Peaks_X_Values[i] = Frequency[Value.Item1];
                Peaks_Y_Values[i] = Value.Item2;
                i++;
                if (i >= Total_Peaks_Found || i == 10)
                {
                    break;
                }
            }
        }

        public IEnumerable<Tuple<int, double>> LocalMaxima(IEnumerable<double> source, int windowSize, double Reference_Level)
        {
            //https://stackoverflow.com/questions/5269000/finding-local-maxima-over-a-dynamic-range Jeroen Cranendonk
            // Round up to nearest odd value
            windowSize = windowSize - windowSize % 2 + 1;
            int halfWindow = windowSize / 2;

            int index = 0;
            var before = new Queue<double>(Enumerable.Repeat(double.NegativeInfinity, halfWindow));
            var after = new Queue<double>(source.Take(halfWindow + 1));

            foreach (double d in source.Skip(halfWindow + 1).Concat(Enumerable.Repeat(double.NegativeInfinity, halfWindow + 1)))
            {
                double curVal = after.Dequeue();
                if (before.All(x => curVal > x) && after.All(x => curVal >= x) && curVal >= Reference_Level)
                {
                    yield return Tuple.Create(index, curVal);
                }

                before.Enqueue(curVal);
                before.Dequeue();
                after.Enqueue(d);
                index++;
            }
        }

        private void Update_Plottable_Peaks()
        {
            if (Total_Peaks_Found >= 1)
            {
                P1.X = Peaks_X_Values[0];
                P1.Y = Peaks_Y_Values[0];
                P1.IsVisible = true;
                P1_Label.Label = "P1: " + Axis_Scale_Config.Value_SI_Prefix(Peaks_X_Values[0], Frequency_Value_Round) + "Hz, " + Axis_Scale_Config.Value_SI_Prefix(Peaks_Y_Values[0], Magnitude_Value_Round) + Y_AXIS_Units;
                P1_Label.IsVisible = true;
            }
            else
            {
                P1.IsVisible = false;
                P1_Label.IsVisible = false;
            }
            if (Total_Peaks_Found >= 2)
            {
                P2.X = Peaks_X_Values[1];
                P2.Y = Peaks_Y_Values[1];
                P2.IsVisible = true;
                P2_Label.Label = "P2: " + Axis_Scale_Config.Value_SI_Prefix(Peaks_X_Values[1], Frequency_Value_Round) + "Hz, " + Axis_Scale_Config.Value_SI_Prefix(Peaks_Y_Values[1], Magnitude_Value_Round) + Y_AXIS_Units;
                P2_Label.IsVisible = true;

            }
            else
            {
                P2.IsVisible = false;
                P2_Label.IsVisible = false;
            }
            if (Total_Peaks_Found >= 3)
            {
                P3.X = Peaks_X_Values[2];
                P3.Y = Peaks_Y_Values[2];
                P3.IsVisible = true;
                P3_Label.Label = "P3: " + Axis_Scale_Config.Value_SI_Prefix(Peaks_X_Values[2], Frequency_Value_Round) + "Hz, " + Axis_Scale_Config.Value_SI_Prefix(Peaks_Y_Values[2], Magnitude_Value_Round) + Y_AXIS_Units;
                P3_Label.IsVisible = true;

            }
            else
            {
                P3.IsVisible = false;
                P3_Label.IsVisible = false;
            }
            if (Total_Peaks_Found >= 4)
            {
                P4.X = Peaks_X_Values[3];
                P4.Y = Peaks_Y_Values[3];
                P4.IsVisible = true;
                P4_Label.Label = "P4: " + Axis_Scale_Config.Value_SI_Prefix(Peaks_X_Values[3], Frequency_Value_Round) + "Hz, " + Axis_Scale_Config.Value_SI_Prefix(Peaks_Y_Values[3], Magnitude_Value_Round) + Y_AXIS_Units;
                P4_Label.IsVisible = true;

            }
            else
            {
                P4.IsVisible = false;
                P4_Label.IsVisible = false;
            }
            if (Total_Peaks_Found >= 5)
            {
                P5.X = Peaks_X_Values[4];
                P5.Y = Peaks_Y_Values[4];
                P5.IsVisible = true;
                P5_Label.Label = "P5: " + Axis_Scale_Config.Value_SI_Prefix(Peaks_X_Values[4], Frequency_Value_Round) + "Hz, " + Axis_Scale_Config.Value_SI_Prefix(Peaks_Y_Values[4], Magnitude_Value_Round) + Y_AXIS_Units;
                P5_Label.IsVisible = true;

            }
            else
            {
                P5.IsVisible = false;
                P5_Label.IsVisible = false;
            }
            if (Total_Peaks_Found >= 6)
            {
                P6.X = Peaks_X_Values[5];
                P6.Y = Peaks_Y_Values[5];
                P6.IsVisible = true;
                P6_Label.Label = "P6: " + Axis_Scale_Config.Value_SI_Prefix(Peaks_X_Values[5], Frequency_Value_Round) + "Hz, " + Axis_Scale_Config.Value_SI_Prefix(Peaks_Y_Values[5], Magnitude_Value_Round) + Y_AXIS_Units;
                P6_Label.IsVisible = true;
            }
            else
            {
                P6.IsVisible = false;
                P6_Label.IsVisible = false;
            }
            if (Total_Peaks_Found >= 7)
            {
                P7.X = Peaks_X_Values[6];
                P7.Y = Peaks_Y_Values[6];
                P7.IsVisible = true;
                P7_Label.Label = "P7: " + Axis_Scale_Config.Value_SI_Prefix(Peaks_X_Values[6], Frequency_Value_Round) + "Hz, " + Axis_Scale_Config.Value_SI_Prefix(Peaks_Y_Values[6], Magnitude_Value_Round) + Y_AXIS_Units;
                P7_Label.IsVisible = true;
            }
            else
            {
                P7.IsVisible = false;
                P7_Label.IsVisible = false;
            }
            if (Total_Peaks_Found >= 8)
            {
                P8.X = Peaks_X_Values[7];
                P8.Y = Peaks_Y_Values[7];
                P8.IsVisible = true;
                P8_Label.Label = "P8: " + Axis_Scale_Config.Value_SI_Prefix(Peaks_X_Values[7], Frequency_Value_Round) + "Hz, " + Axis_Scale_Config.Value_SI_Prefix(Peaks_Y_Values[7], Magnitude_Value_Round) + Y_AXIS_Units;
                P8_Label.IsVisible = true;

            }
            else
            {
                P8.IsVisible = false;
                P8_Label.IsVisible = false;
            }
            if (Total_Peaks_Found >= 9)
            {
                P9.X = Peaks_X_Values[8];
                P9.Y = Peaks_Y_Values[8];
                P9.IsVisible = true;
                P9_Label.Label = "P9: " + Axis_Scale_Config.Value_SI_Prefix(Peaks_X_Values[8], Frequency_Value_Round) + "Hz, " + Axis_Scale_Config.Value_SI_Prefix(Peaks_Y_Values[8], Magnitude_Value_Round) + Y_AXIS_Units;
                P9_Label.IsVisible = true;

            }
            else
            {
                P9.IsVisible = false;
                P9_Label.IsVisible = false;
            }
            if (Total_Peaks_Found >= 10)
            {
                P10.X = Peaks_X_Values[9];
                P10.Y = Peaks_Y_Values[9];
                P10.IsVisible = true;
                P10_Label.Label = "P10: " + Axis_Scale_Config.Value_SI_Prefix(Peaks_X_Values[9], Frequency_Value_Round) + "Hz, " + Axis_Scale_Config.Value_SI_Prefix(Peaks_Y_Values[9], Magnitude_Value_Round) + Y_AXIS_Units;
                P10_Label.IsVisible = true;

            }
            else
            {
                P10.IsVisible = false;
                P10_Label.IsVisible = false;
            }
        }
    }
}
