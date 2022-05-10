using MahApps.Metro.Controls;
using ScottPlot;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Anytime_FFT
{
    public partial class FFT : MetroWindow
    {
        private double[] Peak_1 = new double[2];
        private double[] Peak_2 = new double[2];
        private double[] Peak_3 = new double[2];
        private double[] Peak_4 = new double[2];
        private double[] Peak_5 = new double[2];
        private double[] Peak_6 = new double[2];
        private double[] Peak_7 = new double[2];
        private double[] Peak_8 = new double[2];
        private double[] Peak_9 = new double[2];
        private double[] Peak_10 = new double[2];

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

        private double Peak_Label_Offset = -5;

        private int Total_Peaks = 0;

        private readonly int Frequency_PlotLabel_Round_Value = 2;
        private readonly int Frequency_Label_Round_Value = 4;
        private readonly int Magnitude_PlotLabel_Round_Value = 2;
        private readonly int Magnitude_Label_Round_Value = 4;

        private void Create_Peaks(bool show_Peaks, int Peak_Window_Value, double Peak_Reference)
        {
            if (show_Peaks)
            {
                int Total_Peaks_Found = Peak_Finder(Peak_Window_Value, Peak_Reference);
                Update_Plottable_Peaks(Total_Peaks_Found);
            }
        }

        private int Peak_Finder(int Peak_Window_Size, double Peak_Reference_Level)
        {
            int Local_WindowSize = Peak_Window_Size;
            double Local_Peak_Reference_Level = Peak_Reference_Level;
            IEnumerable<Tuple<int, double>> Peaks = LocalMaxima(Magnitude, Local_WindowSize, Local_Peak_Reference_Level);
            Peaks.OrderByDescending(x => x.Item2);
            int Total_Peaks_Found = Peaks.Count();
            Total_Peaks = Total_Peaks_Found;

            if (Total_Peaks_Found >= 1)
            {
                Peak_1[0] = Frequency[Peaks.ElementAt(0).Item1]; //Frequency Value
                Peak_1[1] = Peaks.ElementAt(0).Item2; //Y Value
            }
            if (Total_Peaks_Found >= 2)
            {
                Peak_2[0] = Frequency[Peaks.ElementAt(1).Item1]; //Frequency Value
                Peak_2[1] = Peaks.ElementAt(1).Item2; //Y Value
            }
            if (Total_Peaks_Found >= 3)
            {
                Peak_3[0] = Frequency[Peaks.ElementAt(2).Item1]; //Frequency Value
                Peak_3[1] = Peaks.ElementAt(2).Item2; //Y Value
            }
            if (Total_Peaks_Found >= 4)
            {
                Peak_4[0] = Frequency[Peaks.ElementAt(3).Item1]; //Frequency Value
                Peak_4[1] = Peaks.ElementAt(3).Item2; //Y Value
            }
            if (Total_Peaks_Found >= 5)
            {
                Peak_5[0] = Frequency[Peaks.ElementAt(4).Item1]; //Frequency Value
                Peak_5[1] = Peaks.ElementAt(4).Item2; //Y Value
            }
            if (Total_Peaks_Found >= 6)
            {
                Peak_6[0] = Frequency[Peaks.ElementAt(5).Item1]; //Frequency Value
                Peak_6[1] = Peaks.ElementAt(5).Item2; //Y Value
            }
            if (Total_Peaks_Found >= 7)
            {
                Peak_7[0] = Frequency[Peaks.ElementAt(6).Item1]; //Frequency Value
                Peak_7[1] = Peaks.ElementAt(6).Item2; //Y Value
            }
            if (Total_Peaks_Found >= 8)
            {
                Peak_8[0] = Frequency[Peaks.ElementAt(7).Item1]; //Frequency Value
                Peak_8[1] = Peaks.ElementAt(7).Item2; //Y Value
            }
            if (Total_Peaks_Found >= 9)
            {
                Peak_9[0] = Frequency[Peaks.ElementAt(8).Item1]; //Frequency Value
                Peak_9[1] = Peaks.ElementAt(8).Item2; //Y Value
            }
            if (Total_Peaks_Found >= 10)
            {
                Peak_10[0] = Frequency[Peaks.ElementAt(9).Item1]; //Frequency Value
                Peak_10[1] = Peaks.ElementAt(9).Item2; //Y Value
            }
            return Total_Peaks_Found;
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

        private void Update_Plottable_Peaks(int Total_Peaks_Found)
        {
            if (Total_Peaks_Found >= 1)
            {
                P1 = Graph.Plot.AddText("P1", Peak_1[0], Peak_1[1], 12, color: System.Drawing.ColorTranslator.FromHtml("#ff0000"));
                P1.Alignment = Alignment.MiddleCenter;

                P1_Label = Graph.Plot.AddAnnotation("P1: " + Axis_Scale_Config.Value_SI_Prefix(Peak_1[0], Frequency_PlotLabel_Round_Value) + "Hz, " + Axis_Scale_Config.Value_SI_Prefix(Peak_1[1], Magnitude_PlotLabel_Round_Value) + Y_AXIS_Units, Peak_Label_Offset, 0);
                P1_Label.Font.Size = 12;
                P1_Label.Shadow = false;
                P1_Label.BackgroundColor = System.Drawing.ColorTranslator.FromHtml("#00FFFFFF");
                P1_Label.BorderColor = System.Drawing.ColorTranslator.FromHtml("#00FFFFFF");
                P1_Label.Font.Color = System.Drawing.ColorTranslator.FromHtml("#ff0000");

                Peak_1_Label.Content = Axis_Scale_Config.Value_SI_Prefix(Peak_1[0], Frequency_Label_Round_Value) + "Hz, " + Axis_Scale_Config.Value_SI_Prefix(Peak_1[1], Magnitude_Label_Round_Value) + Y_AXIS_Units;
            }

            if (Total_Peaks_Found >= 2)
            {
                P2 = Graph.Plot.AddText("P2", Peak_2[0], Peak_2[1], 12, color: System.Drawing.ColorTranslator.FromHtml("#ff33cc"));
                P2.Alignment = Alignment.MiddleCenter;

                P2_Label = Graph.Plot.AddAnnotation("P2: " + Axis_Scale_Config.Value_SI_Prefix(Peak_2[0], Frequency_PlotLabel_Round_Value) + "Hz, " + Axis_Scale_Config.Value_SI_Prefix(Peak_2[1], Magnitude_PlotLabel_Round_Value) + Y_AXIS_Units, Peak_Label_Offset, 15);
                P2_Label.Font.Size = 12;
                P2_Label.Shadow = false;
                P2_Label.BackgroundColor = System.Drawing.ColorTranslator.FromHtml("#00FFFFFF");
                P2_Label.BorderColor = System.Drawing.ColorTranslator.FromHtml("#00FFFFFF");
                P2_Label.Font.Color = System.Drawing.ColorTranslator.FromHtml("#ff33cc");

                Peak_2_Label.Content = Axis_Scale_Config.Value_SI_Prefix(Peak_2[0], Frequency_Label_Round_Value) + "Hz, " + Axis_Scale_Config.Value_SI_Prefix(Peak_2[1], Magnitude_Label_Round_Value) + Y_AXIS_Units;
            }

            if (Total_Peaks_Found >= 3)
            {
                P3 = Graph.Plot.AddText("P3", Peak_3[0], Peak_3[1], 12, color: System.Drawing.ColorTranslator.FromHtml("#f58231"));
                P3.Alignment = Alignment.MiddleCenter;

                P3_Label = Graph.Plot.AddAnnotation("P3: " + Axis_Scale_Config.Value_SI_Prefix(Peak_3[0], Frequency_PlotLabel_Round_Value) + "Hz, " + Axis_Scale_Config.Value_SI_Prefix(Peak_3[1], Magnitude_PlotLabel_Round_Value) + Y_AXIS_Units, Peak_Label_Offset, 30);
                P3_Label.Font.Size = 12;
                P3_Label.Shadow = false;
                P3_Label.BackgroundColor = System.Drawing.ColorTranslator.FromHtml("#00FFFFFF");
                P3_Label.BorderColor = System.Drawing.ColorTranslator.FromHtml("#00FFFFFF");
                P3_Label.Font.Color = System.Drawing.ColorTranslator.FromHtml("#f58231");

                Peak_3_Label.Content = Axis_Scale_Config.Value_SI_Prefix(Peak_3[0], Frequency_Label_Round_Value) + "Hz, " + Axis_Scale_Config.Value_SI_Prefix(Peak_3[1], Magnitude_Label_Round_Value) + Y_AXIS_Units;
            }

            if (Total_Peaks_Found >= 4)
            {
                P4 = Graph.Plot.AddText("P4", Peak_4[0], Peak_4[1], 12, color: System.Drawing.ColorTranslator.FromHtml("#4363d8"));
                P4.Alignment = Alignment.MiddleCenter;

                P4_Label = Graph.Plot.AddAnnotation("P4: " + Axis_Scale_Config.Value_SI_Prefix(Peak_4[0], Frequency_PlotLabel_Round_Value) + "Hz, " + Axis_Scale_Config.Value_SI_Prefix(Peak_4[1], Magnitude_PlotLabel_Round_Value) + Y_AXIS_Units, Peak_Label_Offset, 45);
                P4_Label.Font.Size = 12;
                P4_Label.Shadow = false;
                P4_Label.BackgroundColor = System.Drawing.ColorTranslator.FromHtml("#00FFFFFF");
                P4_Label.BorderColor = System.Drawing.ColorTranslator.FromHtml("#00FFFFFF");
                P4_Label.Font.Color = System.Drawing.ColorTranslator.FromHtml("#4363d8");

                Peak_4_Label.Content = Axis_Scale_Config.Value_SI_Prefix(Peak_4[0], Frequency_Label_Round_Value) + "Hz, " + Axis_Scale_Config.Value_SI_Prefix(Peak_4[1], Magnitude_Label_Round_Value) + Y_AXIS_Units;
            }

            if (Total_Peaks_Found >= 5)
            {
                P5 = Graph.Plot.AddText("P5", Peak_5[0], Peak_5[1], 12, color: System.Drawing.ColorTranslator.FromHtml("#3399ff"));
                P5.Alignment = Alignment.MiddleCenter;

                P5_Label = Graph.Plot.AddAnnotation("P5: " + Axis_Scale_Config.Value_SI_Prefix(Peak_5[0], Frequency_PlotLabel_Round_Value) + "Hz, " + Axis_Scale_Config.Value_SI_Prefix(Peak_5[1], Magnitude_PlotLabel_Round_Value) + Y_AXIS_Units, Peak_Label_Offset, 60);
                P5_Label.Font.Size = 12;
                P5_Label.Shadow = false;
                P5_Label.BackgroundColor = System.Drawing.ColorTranslator.FromHtml("#00FFFFFF");
                P5_Label.BorderColor = System.Drawing.ColorTranslator.FromHtml("#00FFFFFF");
                P5_Label.Font.Color = System.Drawing.ColorTranslator.FromHtml("#3399ff");

                Peak_5_Label.Content = Axis_Scale_Config.Value_SI_Prefix(Peak_5[0], Frequency_Label_Round_Value) + "Hz, " + Axis_Scale_Config.Value_SI_Prefix(Peak_5[1], Magnitude_Label_Round_Value) + Y_AXIS_Units;
            }

            if (Total_Peaks_Found >= 6)
            {
                P6 = Graph.Plot.AddText("P6", Peak_6[0], Peak_6[1], 12, color: System.Drawing.ColorTranslator.FromHtml("#009900"));
                P6.Alignment = Alignment.MiddleCenter;

                P6_Label = Graph.Plot.AddAnnotation("P6: " + Axis_Scale_Config.Value_SI_Prefix(Peak_6[0], Frequency_PlotLabel_Round_Value) + "Hz, " + Axis_Scale_Config.Value_SI_Prefix(Peak_6[1], Magnitude_PlotLabel_Round_Value) + Y_AXIS_Units, Peak_Label_Offset, 75);
                P6_Label.Font.Size = 12;
                P6_Label.Shadow = false;
                P6_Label.BackgroundColor = System.Drawing.ColorTranslator.FromHtml("#00FFFFFF");
                P6_Label.BorderColor = System.Drawing.ColorTranslator.FromHtml("#00FFFFFF");
                P6_Label.Font.Color = System.Drawing.ColorTranslator.FromHtml("#009900");

                Peak_6_Label.Content = Axis_Scale_Config.Value_SI_Prefix(Peak_6[0], Frequency_Label_Round_Value) + "Hz, " + Axis_Scale_Config.Value_SI_Prefix(Peak_6[1], Magnitude_Label_Round_Value) + Y_AXIS_Units;
            }

            if (Total_Peaks_Found >= 7)
            {
                P7 = Graph.Plot.AddText("P7", Peak_7[0], Peak_7[1], 12, color: System.Drawing.ColorTranslator.FromHtml("#b37700"));
                P7.Alignment = Alignment.MiddleCenter;

                P7_Label = Graph.Plot.AddAnnotation("P7: " + Axis_Scale_Config.Value_SI_Prefix(Peak_7[0], Frequency_PlotLabel_Round_Value) + "Hz, " + Axis_Scale_Config.Value_SI_Prefix(Peak_7[1], Magnitude_PlotLabel_Round_Value) + Y_AXIS_Units, Peak_Label_Offset, 90);
                P7_Label.Font.Size = 12;
                P7_Label.Shadow = false;
                P7_Label.BackgroundColor = System.Drawing.ColorTranslator.FromHtml("#00FFFFFF");
                P7_Label.BorderColor = System.Drawing.ColorTranslator.FromHtml("#00FFFFFF");
                P7_Label.Font.Color = System.Drawing.ColorTranslator.FromHtml("#b37700");

                Peak_7_Label.Content = Axis_Scale_Config.Value_SI_Prefix(Peak_7[0], Frequency_Label_Round_Value) + "Hz, " + Axis_Scale_Config.Value_SI_Prefix(Peak_7[1], Magnitude_Label_Round_Value) + Y_AXIS_Units;
            }

            if (Total_Peaks_Found >= 8)
            {
                P8 = Graph.Plot.AddText("P8", Peak_8[0], Peak_8[1], 12, color: System.Drawing.ColorTranslator.FromHtml("#911eb4"));
                P8.Alignment = Alignment.MiddleCenter;

                P8_Label = Graph.Plot.AddAnnotation("P8: " + Axis_Scale_Config.Value_SI_Prefix(Peak_8[0], Frequency_PlotLabel_Round_Value) + "Hz, " + Axis_Scale_Config.Value_SI_Prefix(Peak_8[1], Magnitude_PlotLabel_Round_Value) + Y_AXIS_Units, Peak_Label_Offset, 105);
                P8_Label.Font.Size = 12;
                P8_Label.Shadow = false;
                P8_Label.BackgroundColor = System.Drawing.ColorTranslator.FromHtml("#00FFFFFF");
                P8_Label.BorderColor = System.Drawing.ColorTranslator.FromHtml("#00FFFFFF");
                P8_Label.Font.Color = System.Drawing.ColorTranslator.FromHtml("#911eb4");

                Peak_8_Label.Content = Axis_Scale_Config.Value_SI_Prefix(Peak_8[0], Frequency_Label_Round_Value) + "Hz, " + Axis_Scale_Config.Value_SI_Prefix(Peak_8[1], Magnitude_Label_Round_Value) + Y_AXIS_Units;
            }

            if (Total_Peaks_Found >= 9)
            {
                P9 = Graph.Plot.AddText("P9", Peak_9[0], Peak_9[1], 12, color: System.Drawing.ColorTranslator.FromHtml("#00cc44"));
                P9.Alignment = Alignment.MiddleCenter;

                P9_Label = Graph.Plot.AddAnnotation("P9: " + Axis_Scale_Config.Value_SI_Prefix(Peak_9[0], Frequency_PlotLabel_Round_Value) + "Hz, " + Axis_Scale_Config.Value_SI_Prefix(Peak_9[1], Magnitude_PlotLabel_Round_Value) + Y_AXIS_Units, Peak_Label_Offset, 120);
                P9_Label.Font.Size = 12;
                P9_Label.Shadow = false;
                P9_Label.BackgroundColor = System.Drawing.ColorTranslator.FromHtml("#00FFFFFF");
                P9_Label.BorderColor = System.Drawing.ColorTranslator.FromHtml("#00FFFFFF");
                P9_Label.Font.Color = System.Drawing.ColorTranslator.FromHtml("#00cc44");

                Peak_9_Label.Content = Axis_Scale_Config.Value_SI_Prefix(Peak_9[0], Frequency_Label_Round_Value) + "Hz, " + Axis_Scale_Config.Value_SI_Prefix(Peak_9[1], Magnitude_Label_Round_Value) + Y_AXIS_Units;
            }

            if (Total_Peaks_Found >= 10)
            {
                P10 = Graph.Plot.AddText("P10", Peak_10[0], Peak_10[1], 12, color: System.Drawing.ColorTranslator.FromHtml("#000080"));
                P10.Alignment = Alignment.MiddleCenter;

                P10_Label = Graph.Plot.AddAnnotation("P10: " + Axis_Scale_Config.Value_SI_Prefix(Peak_10[0], Frequency_PlotLabel_Round_Value) + "Hz, " + Axis_Scale_Config.Value_SI_Prefix(Peak_10[1], Magnitude_PlotLabel_Round_Value) + Y_AXIS_Units, Peak_Label_Offset, 135);
                P10_Label.Font.Size = 12;
                P10_Label.Shadow = false;
                P10_Label.BackgroundColor = System.Drawing.ColorTranslator.FromHtml("#00FFFFFF");
                P10_Label.BorderColor = System.Drawing.ColorTranslator.FromHtml("#00FFFFFF");
                P10_Label.Font.Color = System.Drawing.ColorTranslator.FromHtml("#000080");

                Peak_10_Label.Content = Axis_Scale_Config.Value_SI_Prefix(Peak_10[0], Frequency_Label_Round_Value) + "Hz, " + Axis_Scale_Config.Value_SI_Prefix(Peak_10[1], Magnitude_Label_Round_Value) + Y_AXIS_Units;
            }
        }
    }
}