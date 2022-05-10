using MahApps.Metro.Controls;
using ScottPlot;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows;

namespace FFT_Waveform
{
    public partial class FFT_Waveform_Plotter : MetroWindow
    {
        private int Total_Peaks = 1;
        private int Total_Peaks_Found = 0;
        private bool Show_Peak_Labels = true;

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

        private ScottPlot.Plottable.HLine Peak_Reference_Level_Marker;

        private readonly int Frequency_PlotLabel_Round_Value = 2;
        private readonly int Frequency_Label_Round_Value = 4;
        private readonly int Magnitude_PlotLabel_Round_Value = 2;
        private readonly int Magnitude_Label_Round_Value = 4;

        private void Initialize_Peaks_Reference_Level()
        {
            if (Peak_Reference_Level_Marker == null & Show_Peak_Feature)
            {
                Peak_Reference_Level_Marker = Graph.Plot.AddHorizontalLine(Peak_Reference_Level, color: Color.Orange, style: LineStyle.Dash, label: "Peak Ref");
                Peak_Reference_Level_Marker.DragEnabled = true;
                Peak_Reference_Level_Marker.PositionLabel = true;
                Peak_Reference_Level_Marker.IsVisible = Show_Peak_Reference_Level;
                Peak_Reference_Level_Marker.Dragged += Peaks_Reference_Level_Dragged_Event;
                Peak_Reference_Level_Marker.PositionLabelBackground = Color.Orange;
            }
        }

        private void Clear_Peaks_Reference_Level()
        {
            if (Peak_Reference_Level_Marker != null)
            {
                Peak_Reference_Level_Marker.Dragged -= Peaks_Reference_Level_Dragged_Event;
                Graph.Plot.Remove(Peak_Reference_Level_Marker);
                Peak_Reference_Level_Marker = null;
            }
        }

        private void Peaks_Reference_Level_Visibility()
        {
            if (Peak_Reference_Level_Marker != null)
            {
                Peak_Reference_Level_Marker.IsVisible = Show_Peak_Reference_Level;
            }
        }

        private void Peaks_Reference_Level_Dragged_Event(object sender, EventArgs eventArgs)
        {
            Peak_Reference_Level = Peak_Reference_Level_Marker.Y;
        }

        private void Initialize_Plottable_Peaks()
        {
            P1 = Graph.Plot.AddText("P1", 0, 0, 12, color: System.Drawing.ColorTranslator.FromHtml("#ff0000"));
            P1.Alignment = Alignment.MiddleCenter;
            P1.IsVisible = false;

            P1_Label = Graph.Plot.AddAnnotation("P1: 0Hz, 0" + Y_AXIS_Units, Peak_Plot_Labels_Coordinates_X, 0);
            P1_Label.Font.Size = 12;
            P1_Label.Shadow = false;
            P1_Label.BackgroundColor = System.Drawing.ColorTranslator.FromHtml("#00FFFFFF");
            P1_Label.BorderColor = System.Drawing.ColorTranslator.FromHtml("#00FFFFFF");
            P1_Label.Font.Color = System.Drawing.ColorTranslator.FromHtml("#ff0000");
            P1_Label.IsVisible = false;

            P2 = Graph.Plot.AddText("P2", 0, 0, 12, color: System.Drawing.ColorTranslator.FromHtml("#ff33cc"));
            P2.Alignment = Alignment.MiddleCenter;
            P2.IsVisible = false;

            P2_Label = Graph.Plot.AddAnnotation("P2: 0Hz, 0" + Y_AXIS_Units, Peak_Plot_Labels_Coordinates_X, 15);
            P2_Label.Font.Size = 12;
            P2_Label.Shadow = false;
            P2_Label.BackgroundColor = System.Drawing.ColorTranslator.FromHtml("#00FFFFFF");
            P2_Label.BorderColor = System.Drawing.ColorTranslator.FromHtml("#00FFFFFF");
            P2_Label.Font.Color = System.Drawing.ColorTranslator.FromHtml("#ff33cc");
            P2_Label.IsVisible = false;

            P3 = Graph.Plot.AddText("P3", 0, 0, 12, color: System.Drawing.ColorTranslator.FromHtml("#f58231"));
            P3.Alignment = Alignment.MiddleCenter;
            P3.IsVisible = false;

            P3_Label = Graph.Plot.AddAnnotation("P3: 0Hz, 0" + Y_AXIS_Units, Peak_Plot_Labels_Coordinates_X, 30);
            P3_Label.Font.Size = 12;
            P3_Label.Shadow = false;
            P3_Label.BackgroundColor = System.Drawing.ColorTranslator.FromHtml("#00FFFFFF");
            P3_Label.BorderColor = System.Drawing.ColorTranslator.FromHtml("#00FFFFFF");
            P3_Label.Font.Color = System.Drawing.ColorTranslator.FromHtml("#f58231");
            P3_Label.IsVisible = false;

            P4 = Graph.Plot.AddText("P4", 0, 0, 12, color: System.Drawing.ColorTranslator.FromHtml("#4363d8"));
            P4.Alignment = Alignment.MiddleCenter;
            P4.IsVisible = false;

            P4_Label = Graph.Plot.AddAnnotation("P4: 0Hz, 0" + Y_AXIS_Units, Peak_Plot_Labels_Coordinates_X, 45);
            P4_Label.Font.Size = 12;
            P4_Label.Shadow = false;
            P4_Label.BackgroundColor = System.Drawing.ColorTranslator.FromHtml("#00FFFFFF");
            P4_Label.BorderColor = System.Drawing.ColorTranslator.FromHtml("#00FFFFFF");
            P4_Label.Font.Color = System.Drawing.ColorTranslator.FromHtml("#4363d8");
            P4_Label.IsVisible = false;

            P5 = Graph.Plot.AddText("P5", 0, 0, 12, color: System.Drawing.ColorTranslator.FromHtml("#3399ff"));
            P5.Alignment = Alignment.MiddleCenter;
            P5.IsVisible = false;

            P5_Label = Graph.Plot.AddAnnotation("P5: 0Hz, 0" + Y_AXIS_Units, Peak_Plot_Labels_Coordinates_X, 60);
            P5_Label.Font.Size = 12;
            P5_Label.Shadow = false;
            P5_Label.BackgroundColor = System.Drawing.ColorTranslator.FromHtml("#00FFFFFF");
            P5_Label.BorderColor = System.Drawing.ColorTranslator.FromHtml("#00FFFFFF");
            P5_Label.Font.Color = System.Drawing.ColorTranslator.FromHtml("#3399ff");
            P5_Label.IsVisible = false;

            P6 = Graph.Plot.AddText("P6", 0, 0, 12, color: System.Drawing.ColorTranslator.FromHtml("#009900"));
            P6.Alignment = Alignment.MiddleCenter;
            P6.IsVisible = false;

            P6_Label = Graph.Plot.AddAnnotation("P6: 0Hz, 0" + Y_AXIS_Units, Peak_Plot_Labels_Coordinates_X, 75);
            P6_Label.Font.Size = 12;
            P6_Label.Shadow = false;
            P6_Label.BackgroundColor = System.Drawing.ColorTranslator.FromHtml("#00FFFFFF");
            P6_Label.BorderColor = System.Drawing.ColorTranslator.FromHtml("#00FFFFFF");
            P6_Label.Font.Color = System.Drawing.ColorTranslator.FromHtml("#009900");
            P6_Label.IsVisible = false;

            P7 = Graph.Plot.AddText("P7", 0, 0, 12, color: System.Drawing.ColorTranslator.FromHtml("#b37700"));
            P7.Alignment = Alignment.MiddleCenter;
            P7.IsVisible = false;

            P7_Label = Graph.Plot.AddAnnotation("P7: 0Hz, 0" + Y_AXIS_Units, Peak_Plot_Labels_Coordinates_X, 90);
            P7_Label.Font.Size = 12;
            P7_Label.Shadow = false;
            P7_Label.BackgroundColor = System.Drawing.ColorTranslator.FromHtml("#00FFFFFF");
            P7_Label.BorderColor = System.Drawing.ColorTranslator.FromHtml("#00FFFFFF");
            P7_Label.Font.Color = System.Drawing.ColorTranslator.FromHtml("#b37700");
            P7_Label.IsVisible = false;

            P8 = Graph.Plot.AddText("P8", 0, 0, 12, color: System.Drawing.ColorTranslator.FromHtml("#911eb4"));
            P8.Alignment = Alignment.MiddleCenter;
            P8.IsVisible = false;

            P8_Label = Graph.Plot.AddAnnotation("P8: 0Hz, 0" + Y_AXIS_Units, Peak_Plot_Labels_Coordinates_X, 105);
            P8_Label.Font.Size = 12;
            P8_Label.Shadow = false;
            P8_Label.BackgroundColor = System.Drawing.ColorTranslator.FromHtml("#00FFFFFF");
            P8_Label.BorderColor = System.Drawing.ColorTranslator.FromHtml("#00FFFFFF");
            P8_Label.Font.Color = System.Drawing.ColorTranslator.FromHtml("#911eb4");
            P8_Label.IsVisible = false;

            P9 = Graph.Plot.AddText("P9", 0, 0, 12, color: System.Drawing.ColorTranslator.FromHtml("#00cc44"));
            P9.Alignment = Alignment.MiddleCenter;
            P9.IsVisible = false;

            P9_Label = Graph.Plot.AddAnnotation("P9: 0Hz, 0" + Y_AXIS_Units, Peak_Plot_Labels_Coordinates_X, 120);
            P9_Label.Font.Size = 12;
            P9_Label.Shadow = false;
            P9_Label.BackgroundColor = System.Drawing.ColorTranslator.FromHtml("#00FFFFFF");
            P9_Label.BorderColor = System.Drawing.ColorTranslator.FromHtml("#00FFFFFF");
            P9_Label.Font.Color = System.Drawing.ColorTranslator.FromHtml("#00cc44");
            P9_Label.IsVisible = false;

            P10 = Graph.Plot.AddText("P10", 0, 0, 12, color: System.Drawing.ColorTranslator.FromHtml("#000080"));
            P10.Alignment = Alignment.MiddleCenter;
            P10.IsVisible = false;

            P10_Label = Graph.Plot.AddAnnotation("P10: 0Hz, 0" + Y_AXIS_Units, Peak_Plot_Labels_Coordinates_X, 135);
            P10_Label.Font.Size = 12;
            P10_Label.Shadow = false;
            P10_Label.BackgroundColor = System.Drawing.ColorTranslator.FromHtml("#00FFFFFF");
            P10_Label.BorderColor = System.Drawing.ColorTranslator.FromHtml("#00FFFFFF");
            P10_Label.Font.Color = System.Drawing.ColorTranslator.FromHtml("#000080");
            P10_Label.IsVisible = false;
        }

        private void Enable_Peaks_Option_Click(object sender, RoutedEventArgs e)
        {
            if (Enable_Peaks_Option.IsChecked)
            {
                Show_Peak_Feature = true;
                Visible_Peaks(Total_Peaks);
                Visible_Peaks_Labels(Total_Peaks);
            }
            else
            {
                Visible_Peaks(0);
                Visible_Peaks_Labels(0);
                Show_Peak_Feature = false;
                Disable_All_Peaks_Label();
            }
        }

        private void Disable_All_Peaks_Label()
        {
            try
            {
                Peak_1_Label.Content = "null";
                Peak_2_Label.Content = "null";
                Peak_3_Label.Content = "null";
                Peak_4_Label.Content = "null";
                Peak_5_Label.Content = "null";
                Peak_6_Label.Content = "null";
                Peak_7_Label.Content = "null";
                Peak_8_Label.Content = "null";
                Peak_9_Label.Content = "null";
                Peak_10_Label.Content = "null";
            }
            catch (Exception)
            {

            }
        }

        private void Enable_1_Peaks_Click(object sender, RoutedEventArgs e)
        {
            Total_Peaks = 1;
            Visible_Peaks(Total_Peaks);
            Visible_Peaks_Labels(Total_Peaks);
            Enable_Peaks_Selected(1);
        }

        private void Enable_2_Peaks_Click(object sender, RoutedEventArgs e)
        {
            Total_Peaks = 2;
            Visible_Peaks(Total_Peaks);
            Visible_Peaks_Labels(Total_Peaks);
            Enable_Peaks_Selected(2);
        }

        private void Enable_3_Peaks_Click(object sender, RoutedEventArgs e)
        {
            Total_Peaks = 3;
            Visible_Peaks(Total_Peaks);
            Visible_Peaks_Labels(Total_Peaks);
            Enable_Peaks_Selected(3);
        }

        private void Enable_4_Peaks_Click(object sender, RoutedEventArgs e)
        {
            Total_Peaks = 4;
            Visible_Peaks(Total_Peaks);
            Visible_Peaks_Labels(Total_Peaks);
            Enable_Peaks_Selected(4);
        }

        private void Enable_5_Peaks_Click(object sender, RoutedEventArgs e)
        {
            Total_Peaks = 5;
            Visible_Peaks(Total_Peaks);
            Visible_Peaks_Labels(Total_Peaks);
            Enable_Peaks_Selected(5);
        }

        private void Enable_6_Peaks_Click(object sender, RoutedEventArgs e)
        {
            Total_Peaks = 6;
            Visible_Peaks(Total_Peaks);
            Visible_Peaks_Labels(Total_Peaks);
            Enable_Peaks_Selected(6);
        }

        private void Enable_7_Peaks_Click(object sender, RoutedEventArgs e)
        {
            Total_Peaks = 7;
            Visible_Peaks(Total_Peaks);
            Visible_Peaks_Labels(Total_Peaks);
            Enable_Peaks_Selected(7);
        }

        private void Enable_8_Peaks_Click(object sender, RoutedEventArgs e)
        {
            Total_Peaks = 8;
            Visible_Peaks(Total_Peaks);
            Visible_Peaks_Labels(Total_Peaks);
            Enable_Peaks_Selected(8);
        }

        private void Enable_9_Peaks_Click(object sender, RoutedEventArgs e)
        {
            Total_Peaks = 9;
            Visible_Peaks(Total_Peaks);
            Visible_Peaks_Labels(Total_Peaks);
            Enable_Peaks_Selected(9);
        }

        private void Enable_10_Peaks_Click(object sender, RoutedEventArgs e)
        {
            Total_Peaks = 10;
            Visible_Peaks(Total_Peaks);
            Visible_Peaks_Labels(Total_Peaks);
            Enable_Peaks_Selected(10);
        }

        private void Enable_Peaks_Selected(int Selected)
        {
            if (Selected == 1)
            {
                Enable_1_Peaks.IsChecked = true;
            }
            else
            {
                Enable_1_Peaks.IsChecked = false;
            }
            if (Selected == 2)
            {
                Enable_2_Peaks.IsChecked = true;
            }
            else
            {
                Enable_2_Peaks.IsChecked = false;
            }
            if (Selected == 3)
            {
                Enable_3_Peaks.IsChecked = true;
            }
            else
            {
                Enable_3_Peaks.IsChecked = false;
            }
            if (Selected == 4)
            {
                Enable_4_Peaks.IsChecked = true;
            }
            else
            {
                Enable_4_Peaks.IsChecked = false;
            }
            if (Selected == 5)
            {
                Enable_5_Peaks.IsChecked = true;
            }
            else
            {
                Enable_5_Peaks.IsChecked = false;
            }
            if (Selected == 6)
            {
                Enable_6_Peaks.IsChecked = true;
            }
            else
            {
                Enable_6_Peaks.IsChecked = false;
            }
            if (Selected == 7)
            {
                Enable_7_Peaks.IsChecked = true;
            }
            else
            {
                Enable_7_Peaks.IsChecked = false;
            }
            if (Selected == 8)
            {
                Enable_8_Peaks.IsChecked = true;
            }
            else
            {
                Enable_8_Peaks.IsChecked = false;
            }
            if (Selected == 9)
            {
                Enable_9_Peaks.IsChecked = true;
            }
            else
            {
                Enable_9_Peaks.IsChecked = false;
            }
            if (Selected == 10)
            {
                Enable_10_Peaks.IsChecked = true;
            }
            else
            {
                Enable_10_Peaks.IsChecked = false;
            }
        }

        private void Visible_Peaks(int Selected)
        {
            if (Show_Peak_Feature)
            {
                if (Selected >= 1)
                {
                    P1.IsVisible = true;
                }
                else
                {
                    P1.IsVisible = false;
                }
                if (Selected >= 2)
                {
                    P2.IsVisible = true;
                }
                else
                {
                    P2.IsVisible = false;
                }
                if (Selected >= 3)
                {
                    P3.IsVisible = true;
                }
                else
                {
                    P3.IsVisible = false;
                }
                if (Selected >= 4)
                {
                    P4.IsVisible = true;
                }
                else
                {
                    P4.IsVisible = false;
                }
                if (Selected >= 5)
                {
                    P5.IsVisible = true;
                }
                else
                {
                    P5.IsVisible = false;
                }
                if (Selected >= 6)
                {
                    P6.IsVisible = true;
                }
                else
                {
                    P6.IsVisible = false;
                }
                if (Selected >= 7)
                {
                    P7.IsVisible = true;
                }
                else
                {
                    P7.IsVisible = false;
                }
                if (Selected >= 8)
                {
                    P8.IsVisible = true;
                }
                else
                {
                    P8.IsVisible = false;
                }
                if (Selected >= 9)
                {
                    P9.IsVisible = true;
                }
                else
                {
                    P9.IsVisible = false;
                }
                if (Selected >= 10)
                {
                    P10.IsVisible = true;
                }
                else
                {
                    P10.IsVisible = false;
                }
            }
        }

        private void Visible_Peaks_Labels(int Selected)
        {
            if (Show_Peak_Feature)
            {
                if (Selected >= 1)
                {
                    P1_Label.IsVisible = true;
                }
                else
                {
                    P1_Label.IsVisible = false;
                }
                if (Selected >= 2)
                {
                    P2_Label.IsVisible = true;
                }
                else
                {
                    P2_Label.IsVisible = false;
                }
                if (Selected >= 3)
                {
                    P3_Label.IsVisible = true;
                }
                else
                {
                    P3_Label.IsVisible = false;
                }
                if (Selected >= 4)
                {
                    P4_Label.IsVisible = true;
                }
                else
                {
                    P4_Label.IsVisible = false;
                }
                if (Selected >= 5)
                {
                    P5_Label.IsVisible = true;
                }
                else
                {
                    P5_Label.IsVisible = false;
                }
                if (Selected >= 6)
                {
                    P6_Label.IsVisible = true;
                }
                else
                {
                    P6_Label.IsVisible = false;
                }
                if (Selected >= 7)
                {
                    P7_Label.IsVisible = true;
                }
                else
                {
                    P7_Label.IsVisible = false;
                }
                if (Selected >= 8)
                {
                    P8_Label.IsVisible = true;
                }
                else
                {
                    P8_Label.IsVisible = false;
                }
                if (Selected >= 9)
                {
                    P9_Label.IsVisible = true;
                }
                else
                {
                    P9_Label.IsVisible = false;
                }
                if (Selected >= 10)
                {
                    P10_Label.IsVisible = true;
                }
                else
                {
                    P10_Label.IsVisible = false;
                }
            }
        }

        private void Update_Plottable_Peaks()
        {
            if (Total_Peaks_Found >= 1 & Total_Peaks >= 1)
            {
                P1.X = Peaks_X_Values[0];
                P1.Y = Peaks_Y_Values[0];
                P1.IsVisible = true;
                Peak_1_Label.Content = Axis_Scale_Config.Value_SI_Prefix(Peaks_X_Values[0], Frequency_Label_Round_Value) + "Hz, " + Axis_Scale_Config.Value_SI_Prefix(Peaks_Y_Values[0], Magnitude_Label_Round_Value) + Y_AXIS_Units;
                if (Show_Peak_Labels)
                {
                    P1_Label.Label = "P1: " + Axis_Scale_Config.Value_SI_Prefix(Peaks_X_Values[0], Frequency_PlotLabel_Round_Value) + "Hz, " + Axis_Scale_Config.Value_SI_Prefix(Peaks_Y_Values[0], Magnitude_PlotLabel_Round_Value) + Y_AXIS_Units;
                    P1_Label.IsVisible = true;
                }
                else
                {
                    P1_Label.IsVisible = false;
                }
            }
            else
            {
                Peak_1_Label.Content = "null";
                P1.IsVisible = false;
                P1_Label.IsVisible = false;
            }
            if (Total_Peaks_Found >= 2 & Total_Peaks >= 2)
            {
                P2.X = Peaks_X_Values[1];
                P2.Y = Peaks_Y_Values[1];
                P2.IsVisible = true;
                Peak_2_Label.Content = Axis_Scale_Config.Value_SI_Prefix(Peaks_X_Values[1], Frequency_Label_Round_Value) + "Hz, " + Axis_Scale_Config.Value_SI_Prefix(Peaks_Y_Values[1], Magnitude_Label_Round_Value) + Y_AXIS_Units;
                if (Show_Peak_Labels)
                {
                    P2_Label.Label = "P2: " + Axis_Scale_Config.Value_SI_Prefix(Peaks_X_Values[1], Frequency_PlotLabel_Round_Value) + "Hz, " + Axis_Scale_Config.Value_SI_Prefix(Peaks_Y_Values[1], Magnitude_PlotLabel_Round_Value) + Y_AXIS_Units;
                    P2_Label.IsVisible = true;
                }
                else
                {
                    P2_Label.IsVisible = false;
                }
            }
            else
            {
                Peak_2_Label.Content = "null";
                P2.IsVisible = false;
                P2_Label.IsVisible = false;
            }
            if (Total_Peaks_Found >= 3 & Total_Peaks >= 3)
            {
                P3.X = Peaks_X_Values[2];
                P3.Y = Peaks_Y_Values[2];
                P3.IsVisible = true;
                Peak_3_Label.Content = Axis_Scale_Config.Value_SI_Prefix(Peaks_X_Values[2], Frequency_Label_Round_Value) + "Hz, " + Axis_Scale_Config.Value_SI_Prefix(Peaks_Y_Values[2], Magnitude_Label_Round_Value) + Y_AXIS_Units;
                if (Show_Peak_Labels)
                {
                    P3_Label.Label = "P3: " + Axis_Scale_Config.Value_SI_Prefix(Peaks_X_Values[2], Frequency_PlotLabel_Round_Value) + "Hz, " + Axis_Scale_Config.Value_SI_Prefix(Peaks_Y_Values[2], Magnitude_PlotLabel_Round_Value) + Y_AXIS_Units;
                    P3_Label.IsVisible = true;
                }
                else
                {
                    P3_Label.IsVisible = false;
                }
            }
            else
            {
                Peak_3_Label.Content = "null";
                P3.IsVisible = false;
                P3_Label.IsVisible = false;
            }
            if (Total_Peaks_Found >= 4 & Total_Peaks >= 4)
            {
                P4.X = Peaks_X_Values[3];
                P4.Y = Peaks_Y_Values[3];
                P4.IsVisible = true;
                Peak_4_Label.Content = Axis_Scale_Config.Value_SI_Prefix(Peaks_X_Values[3], Frequency_Label_Round_Value) + "Hz, " + Axis_Scale_Config.Value_SI_Prefix(Peaks_Y_Values[3], Magnitude_Label_Round_Value) + Y_AXIS_Units;
                if (Show_Peak_Labels)
                {
                    P4_Label.Label = "P4: " + Axis_Scale_Config.Value_SI_Prefix(Peaks_X_Values[3], Frequency_PlotLabel_Round_Value) + "Hz, " + Axis_Scale_Config.Value_SI_Prefix(Peaks_Y_Values[3], Magnitude_PlotLabel_Round_Value) + Y_AXIS_Units;
                    P4_Label.IsVisible = true;
                }
                else
                {
                    P4_Label.IsVisible = false;
                }
            }
            else
            {
                Peak_4_Label.Content = "null";
                P4.IsVisible = false;
                P4_Label.IsVisible = false;
            }
            if (Total_Peaks_Found >= 5 & Total_Peaks >= 5)
            {
                P5.X = Peaks_X_Values[4];
                P5.Y = Peaks_Y_Values[4];
                P5.IsVisible = true;
                Peak_5_Label.Content = Axis_Scale_Config.Value_SI_Prefix(Peaks_X_Values[4], Frequency_Label_Round_Value) + "Hz, " + Axis_Scale_Config.Value_SI_Prefix(Peaks_Y_Values[4], Magnitude_Label_Round_Value) + Y_AXIS_Units;
                if (Show_Peak_Labels)
                {
                    P5_Label.Label = "P5: " + Axis_Scale_Config.Value_SI_Prefix(Peaks_X_Values[4], Frequency_PlotLabel_Round_Value) + "Hz, " + Axis_Scale_Config.Value_SI_Prefix(Peaks_Y_Values[4], Magnitude_PlotLabel_Round_Value) + Y_AXIS_Units;
                    P5_Label.IsVisible = true;
                }
                else
                {
                    P5_Label.IsVisible = false;
                }
            }
            else
            {
                Peak_5_Label.Content = "null";
                P5.IsVisible = false;
                P5_Label.IsVisible = false;
            }
            if (Total_Peaks_Found >= 6 & Total_Peaks >= 6)
            {
                P6.X = Peaks_X_Values[5];
                P6.Y = Peaks_Y_Values[5];
                P6.IsVisible = true;
                Peak_6_Label.Content = Axis_Scale_Config.Value_SI_Prefix(Peaks_X_Values[5], Frequency_Label_Round_Value) + "Hz, " + Axis_Scale_Config.Value_SI_Prefix(Peaks_Y_Values[5], Magnitude_Label_Round_Value) + Y_AXIS_Units;
                if (Show_Peak_Labels)
                {
                    P6_Label.Label = "P6: " + Axis_Scale_Config.Value_SI_Prefix(Peaks_X_Values[5], Frequency_PlotLabel_Round_Value) + "Hz, " + Axis_Scale_Config.Value_SI_Prefix(Peaks_Y_Values[5], Magnitude_PlotLabel_Round_Value) + Y_AXIS_Units;
                    P6_Label.IsVisible = true;
                }
                else
                {
                    P6_Label.IsVisible = false;
                }
            }
            else
            {
                Peak_6_Label.Content = "null";
                P6.IsVisible = false;
                P6_Label.IsVisible = false;
            }
            if (Total_Peaks_Found >= 7 & Total_Peaks >= 7)
            {
                P7.X = Peaks_X_Values[6];
                P7.Y = Peaks_Y_Values[6];
                P7.IsVisible = true;
                Peak_7_Label.Content = Axis_Scale_Config.Value_SI_Prefix(Peaks_X_Values[6], Frequency_Label_Round_Value) + "Hz, " + Axis_Scale_Config.Value_SI_Prefix(Peaks_Y_Values[6], Magnitude_Label_Round_Value) + Y_AXIS_Units;
                if (Show_Peak_Labels)
                {
                    P7_Label.Label = "P7: " + Axis_Scale_Config.Value_SI_Prefix(Peaks_X_Values[6], Frequency_PlotLabel_Round_Value) + "Hz, " + Axis_Scale_Config.Value_SI_Prefix(Peaks_Y_Values[6], Magnitude_PlotLabel_Round_Value) + Y_AXIS_Units;
                    P7_Label.IsVisible = true;
                }
                else
                {
                    P7_Label.IsVisible = false;
                }
            }
            else
            {
                Peak_7_Label.Content = "null";
                P7.IsVisible = false;
                P7_Label.IsVisible = false;
            }
            if (Total_Peaks_Found >= 8 & Total_Peaks >= 8)
            {
                P8.X = Peaks_X_Values[7];
                P8.Y = Peaks_Y_Values[7];
                P8.IsVisible = true;
                Peak_8_Label.Content = Axis_Scale_Config.Value_SI_Prefix(Peaks_X_Values[7], Frequency_Label_Round_Value) + "Hz, " + Axis_Scale_Config.Value_SI_Prefix(Peaks_Y_Values[7], Magnitude_Label_Round_Value) + Y_AXIS_Units;
                if (Show_Peak_Labels)
                {
                    P8_Label.Label = "P8: " + Axis_Scale_Config.Value_SI_Prefix(Peaks_X_Values[7], Frequency_PlotLabel_Round_Value) + "Hz, " + Axis_Scale_Config.Value_SI_Prefix(Peaks_Y_Values[7], Magnitude_PlotLabel_Round_Value) + Y_AXIS_Units;
                    P8_Label.IsVisible = true;
                }
                else
                {
                    P8_Label.IsVisible = false;
                }
            }
            else
            {
                Peak_8_Label.Content = "null";
                P8.IsVisible = false;
                P8_Label.IsVisible = false;
            }
            if (Total_Peaks_Found >= 9 & Total_Peaks >= 9)
            {
                P9.X = Peaks_X_Values[8];
                P9.Y = Peaks_Y_Values[8];
                P9.IsVisible = true;
                Peak_9_Label.Content = Axis_Scale_Config.Value_SI_Prefix(Peaks_X_Values[8], Frequency_Label_Round_Value) + "Hz, " + Axis_Scale_Config.Value_SI_Prefix(Peaks_Y_Values[8], Magnitude_Label_Round_Value) + Y_AXIS_Units;
                if (Show_Peak_Labels)
                {
                    P9_Label.Label = "P9: " + Axis_Scale_Config.Value_SI_Prefix(Peaks_X_Values[8], Frequency_PlotLabel_Round_Value) + "Hz, " + Axis_Scale_Config.Value_SI_Prefix(Peaks_Y_Values[8], Magnitude_PlotLabel_Round_Value) + Y_AXIS_Units;
                    P9_Label.IsVisible = true;
                }
                else
                {
                    P9_Label.IsVisible = false;
                }
            }
            else
            {
                Peak_9_Label.Content = "null";
                P9.IsVisible = false;
                P9_Label.IsVisible = false;
            }
            if (Total_Peaks_Found >= 10 & Total_Peaks >= 10)
            {
                P10.X = Peaks_X_Values[9];
                P10.Y = Peaks_Y_Values[9];
                P10.IsVisible = true;
                Peak_10_Label.Content = Axis_Scale_Config.Value_SI_Prefix(Peaks_X_Values[9], Frequency_Label_Round_Value) + "Hz, " + Axis_Scale_Config.Value_SI_Prefix(Peaks_Y_Values[9], Magnitude_Label_Round_Value) + Y_AXIS_Units;
                if (Show_Peak_Labels)
                {
                    P10_Label.Label = "P10: " + Axis_Scale_Config.Value_SI_Prefix(Peaks_X_Values[9], Frequency_PlotLabel_Round_Value) + "Hz, " + Axis_Scale_Config.Value_SI_Prefix(Peaks_Y_Values[9], Magnitude_PlotLabel_Round_Value) + Y_AXIS_Units;
                    P10_Label.IsVisible = true;
                }
                else
                {
                    P10_Label.IsVisible = false;
                }
            }
            else
            {
                Peak_10_Label.Content = "null";
                P10.IsVisible = false;
                P10_Label.IsVisible = false;
            }
        }

        private void Peak_Finder()
        {
            int Local_WindowSize = Peak_Window_Size;
            double Local_Peak_Reference_Level = Peak_Reference_Level;
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

        private void Update_Peaks_Label_X_Coordiniates(double X_Coordinates)
        {
            P1_Label.X = X_Coordinates;
            P2_Label.X = X_Coordinates;
            P3_Label.X = X_Coordinates;
            P4_Label.X = X_Coordinates;
            P5_Label.X = X_Coordinates;
            P6_Label.X = X_Coordinates;
            P7_Label.X = X_Coordinates;
            P8_Label.X = X_Coordinates;
            P9_Label.X = X_Coordinates;
            P10_Label.X = X_Coordinates;
        }

        private void Peaks_Color_Distinct1_Palette_Click(object sender, RoutedEventArgs e)
        {
            Color_Palette_Selected(0);
            P1.Color = System.Drawing.ColorTranslator.FromHtml("#ff0000");
            P1_Label.Font.Color = System.Drawing.ColorTranslator.FromHtml("#ff0000");
            P2.Color = System.Drawing.ColorTranslator.FromHtml("#ff33cc");
            P2_Label.Font.Color = System.Drawing.ColorTranslator.FromHtml("#ff33cc");
            P3.Color = System.Drawing.ColorTranslator.FromHtml("#f58231");
            P3_Label.Font.Color = System.Drawing.ColorTranslator.FromHtml("#f58231");
            P4.Color = System.Drawing.ColorTranslator.FromHtml("#4363d8");
            P4_Label.Font.Color = System.Drawing.ColorTranslator.FromHtml("#4363d8");
            P5.Color = System.Drawing.ColorTranslator.FromHtml("#3399ff");
            P5_Label.Font.Color = System.Drawing.ColorTranslator.FromHtml("#3399ff");
            P6.Color = System.Drawing.ColorTranslator.FromHtml("#009900");
            P6_Label.Font.Color = System.Drawing.ColorTranslator.FromHtml("#009900");
            P7.Color = System.Drawing.ColorTranslator.FromHtml("#b37700");
            P7_Label.Font.Color = System.Drawing.ColorTranslator.FromHtml("#b37700");
            P8.Color = System.Drawing.ColorTranslator.FromHtml("#911eb4");
            P8_Label.Font.Color = System.Drawing.ColorTranslator.FromHtml("#911eb4");
            P9.Color = System.Drawing.ColorTranslator.FromHtml("#00cc44");
            P9_Label.Font.Color = System.Drawing.ColorTranslator.FromHtml("#00cc44");
            P10.Color = System.Drawing.ColorTranslator.FromHtml("#000080");
            P10_Label.Font.Color = System.Drawing.ColorTranslator.FromHtml("#000080");
        }

        private void Peaks_Color_Distinct2_Palette_Click(object sender, RoutedEventArgs e)
        {
            Color_Palette_Selected(1);
            P1.Color = System.Drawing.ColorTranslator.FromHtml("#FF0018");
            P1_Label.Font.Color = System.Drawing.ColorTranslator.FromHtml("#FF0018");
            P2.Color = System.Drawing.ColorTranslator.FromHtml("#FFA52C");
            P2_Label.Font.Color = System.Drawing.ColorTranslator.FromHtml("#FFA52C");
            P3.Color = System.Drawing.ColorTranslator.FromHtml("#e6e600");
            P3_Label.Font.Color = System.Drawing.ColorTranslator.FromHtml("#e6e600");
            P4.Color = System.Drawing.ColorTranslator.FromHtml("#008018");
            P4_Label.Font.Color = System.Drawing.ColorTranslator.FromHtml("#008018");
            P5.Color = System.Drawing.ColorTranslator.FromHtml("#0000F9");
            P5_Label.Font.Color = System.Drawing.ColorTranslator.FromHtml("#0000F9");
            P6.Color = System.Drawing.ColorTranslator.FromHtml("#86007D");
            P6_Label.Font.Color = System.Drawing.ColorTranslator.FromHtml("#86007D");
            P7.Color = System.Drawing.ColorTranslator.FromHtml("#F88BC2");
            P7_Label.Font.Color = System.Drawing.ColorTranslator.FromHtml("#F88BC2");
            P8.Color = System.Drawing.ColorTranslator.FromHtml("#47A9FA");
            P8_Label.Font.Color = System.Drawing.ColorTranslator.FromHtml("#47A9FA");
            P9.Color = System.Drawing.ColorTranslator.FromHtml("#b37700");
            P9_Label.Font.Color = System.Drawing.ColorTranslator.FromHtml("#b37700");
            P10.Color = System.Drawing.ColorTranslator.FromHtml("#00cc44");
            P10_Label.Font.Color = System.Drawing.ColorTranslator.FromHtml("#00cc44");
        }

        private void Peaks_Color_Red_Palette_Click(object sender, RoutedEventArgs e)
        {
            Color_Palette_Selected(2);
            System.Drawing.Color color = System.Drawing.ColorTranslator.FromHtml("#ff0000");
            P1.Color = color;
            P1_Label.Font.Color = color;
            P2.Color = color;
            P2_Label.Font.Color = color;
            P3.Color = color;
            P3_Label.Font.Color = color;
            P4.Color = color;
            P4_Label.Font.Color = color;
            P5.Color = color;
            P5_Label.Font.Color = color;
            P6.Color = color;
            P6_Label.Font.Color = color;
            P7.Color = color;
            P7_Label.Font.Color = color;
            P8.Color = color;
            P8_Label.Font.Color = color;
            P9.Color = color;
            P9_Label.Font.Color = color;
            P10.Color = color;
            P10_Label.Font.Color = color;
        }

        private void Peaks_Color_Blue_Palette_Click(object sender, RoutedEventArgs e)
        {
            Color_Palette_Selected(3);
            System.Drawing.Color color = System.Drawing.ColorTranslator.FromHtml("#00c0ff");
            P1.Color = color;
            P1_Label.Font.Color = color;
            P2.Color = color;
            P2_Label.Font.Color = color;
            P3.Color = color;
            P3_Label.Font.Color = color;
            P4.Color = color;
            P4_Label.Font.Color = color;
            P5.Color = color;
            P5_Label.Font.Color = color;
            P6.Color = color;
            P6_Label.Font.Color = color;
            P7.Color = color;
            P7_Label.Font.Color = color;
            P8.Color = color;
            P8_Label.Font.Color = color;
            P9.Color = color;
            P9_Label.Font.Color = color;
            P10.Color = color;
            P10_Label.Font.Color = color;
        }

        private void Peaks_Color_Pink_Palette_Click(object sender, RoutedEventArgs e)
        {
            Color_Palette_Selected(4);
            System.Drawing.Color color = System.Drawing.ColorTranslator.FromHtml("#ff1493");
            P1.Color = color;
            P1_Label.Font.Color = color;
            P2.Color = color;
            P2_Label.Font.Color = color;
            P3.Color = color;
            P3_Label.Font.Color = color;
            P4.Color = color;
            P4_Label.Font.Color = color;
            P5.Color = color;
            P5_Label.Font.Color = color;
            P6.Color = color;
            P6_Label.Font.Color = color;
            P7.Color = color;
            P7_Label.Font.Color = color;
            P8.Color = color;
            P8_Label.Font.Color = color;
            P9.Color = color;
            P9_Label.Font.Color = color;
            P10.Color = color;
            P10_Label.Font.Color = color;
        }

        private void Peaks_Color_Violet_Palette_Click(object sender, RoutedEventArgs e)
        {
            Color_Palette_Selected(5);
            System.Drawing.Color color = System.Drawing.ColorTranslator.FromHtml("#9400d3");
            P1.Color = color;
            P1_Label.Font.Color = color;
            P2.Color = color;
            P2_Label.Font.Color = color;
            P3.Color = color;
            P3_Label.Font.Color = color;
            P4.Color = color;
            P4_Label.Font.Color = color;
            P5.Color = color;
            P5_Label.Font.Color = color;
            P6.Color = color;
            P6_Label.Font.Color = color;
            P7.Color = color;
            P7_Label.Font.Color = color;
            P8.Color = color;
            P8_Label.Font.Color = color;
            P9.Color = color;
            P9_Label.Font.Color = color;
            P10.Color = color;
            P10_Label.Font.Color = color;
        }

        private void Peaks_Color_Black_Palette_Click(object sender, RoutedEventArgs e)
        {
            Color_Palette_Selected(6);
            System.Drawing.Color color = System.Drawing.ColorTranslator.FromHtml("#000000");
            P1.Color = color;
            P1_Label.Font.Color = color;
            P2.Color = color;
            P2_Label.Font.Color = color;
            P3.Color = color;
            P3_Label.Font.Color = color;
            P4.Color = color;
            P4_Label.Font.Color = color;
            P5.Color = color;
            P5_Label.Font.Color = color;
            P6.Color = color;
            P6_Label.Font.Color = color;
            P7.Color = color;
            P7_Label.Font.Color = color;
            P8.Color = color;
            P8_Label.Font.Color = color;
            P9.Color = color;
            P9_Label.Font.Color = color;
            P10.Color = color;
            P10_Label.Font.Color = color;
        }

        private void Color_Palette_Selected(int Select)
        {
            if (Select == 0)
            {
                Peaks_Color_Distinct1_Palette.IsChecked = true;
            }
            else
            {
                Peaks_Color_Distinct1_Palette.IsChecked = false;
            }
            if (Select == 1)
            {
                Peaks_Color_Distinct2_Palette.IsChecked = true;
            }
            else
            {
                Peaks_Color_Distinct2_Palette.IsChecked = false;
            }
            if (Select == 2)
            {
                Peaks_Color_Red_Palette.IsChecked = true;
            }
            else
            {
                Peaks_Color_Red_Palette.IsChecked = false;
            }
            if (Select == 3)
            {
                Peaks_Color_Blue_Palette.IsChecked = true;
            }
            else
            {
                Peaks_Color_Blue_Palette.IsChecked = false;
            }
            if (Select == 4)
            {
                Peaks_Color_Pink_Palette.IsChecked = true;
            }
            else
            {
                Peaks_Color_Pink_Palette.IsChecked = false;
            }
            if (Select == 5)
            {
                Peaks_Color_Violet_Palette.IsChecked = true;
            }
            else
            {
                Peaks_Color_Violet_Palette.IsChecked = false;
            }
            if (Select == 6)
            {
                Peaks_Color_Black_Palette.IsChecked = true;
            }
            else
            {
                Peaks_Color_Black_Palette.IsChecked = false;
            }
        }

        private void Show_Peaks_Labels_Click(object sender, RoutedEventArgs e)
        {
            if (Show_Peaks_Labels.IsChecked)
            {
                Show_Peak_Labels = true;
                Visible_Peaks_Labels(Total_Peaks);
            }
            else
            {
                Visible_Peaks_Labels(0);
                Show_Peak_Labels = false;
            }
        }
    }
}
