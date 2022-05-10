using MahApps.Metro.Controls;
using System;
using System.Collections.Generic;
using System.Windows;

namespace FFT_Waveform
{
    public partial class FFT_Waveform_Plotter : MetroWindow
    {
        private ScottPlot.Plottable.VLine Vertical_Start_Marker;
        private ScottPlot.Plottable.VLine Vertical_Stop_Marker;
        private ScottPlot.Plottable.Annotation Vertical_Start_Marker_Annotation;
        private ScottPlot.Plottable.Annotation Vertical_Stop_Marker_Annotation;
        private ScottPlot.Plottable.Annotation Vertical_Marker_FrequencyDifference_Annotation;

        private ScottPlot.Plottable.HLine Horizontal_Start_Marker;
        private ScottPlot.Plottable.HLine Horizontal_Stop_Marker;
        private ScottPlot.Plottable.Annotation Horizontal_Start_Marker_Annotation;
        private ScottPlot.Plottable.Annotation Horizontal_Stop_Marker_Annotation;
        private ScottPlot.Plottable.Annotation Horizontal_Marker_MagnitudeDifference_Annotation;

        private List<ScottPlot.Plottable.VLine> Vertical_Markers_Fixed = new List<ScottPlot.Plottable.VLine>();
        private List<ScottPlot.Plottable.HLine> Horizontal_Markers_Fixed = new List<ScottPlot.Plottable.HLine>();

        private void Draggable_Horizontal_Markers_Click(object sender, RoutedEventArgs e)
        {
            if (Draggable_Horizontal_Markers.IsChecked == true)
            {
                Horizontal_Markers_MenuItem.IsChecked = true;
                Add_Clear_Horizontal_Markers();
            }
            else
            {
                Horizontal_Markers_MenuItem.IsChecked = false;
                Add_Clear_Horizontal_Markers();
            }
        }

        private void Draggable_Vertical_Markers_Click(object sender, RoutedEventArgs e)
        {
            if (Draggable_Vertical_Markers.IsChecked == true)
            {
                Vertical_Markers_MenuItem.IsChecked = true;
                Add_Clear_Vertical_Markers();
            }
            else
            {
                Vertical_Markers_MenuItem.IsChecked = false;
                Add_Clear_Vertical_Markers();
            }
        }

        private void Add_Clear_Vertical_Markers()
        {
            if (Vertical_Markers_MenuItem.IsChecked == true & Draggable_Vertical_Markers.IsChecked == true)
            {
                (double X_MouseCoordinate, double Y_MouseCoordinate) = Graph.GetMouseCoordinates();
                Vertical_Start_Marker = Graph.Plot.AddVerticalLine(X_MouseCoordinate, color: System.Drawing.ColorTranslator.FromHtml("#FF00950E"), style: ScottPlot.LineStyle.DashDot, label: "V Marker");
                Vertical_Start_Marker.DragEnabled = true;
                Vertical_Start_Marker.Dragged += Vertical_Marker_Start_Dragged_Event;
                double Vertical_Start_Marker_Value = Vertical_Start_Marker.X;
                Vertical_Start_Marker_Annotation = Graph.Plot.AddAnnotation("V Marker: " + Axis_Scale_Config.Value_SI_Prefix(Vertical_Start_Marker_Value, 4) + "Hz", 5, 5);
                Vertical_Start_Marker_Annotation.Font.Size = 14;
                Vertical_Start_Marker_Annotation.Shadow = false;
                Vertical_Start_Marker_Annotation.BackgroundColor = System.Drawing.ColorTranslator.FromHtml("#00FFFFFF");
                Vertical_Start_Marker_Annotation.BorderColor = System.Drawing.ColorTranslator.FromHtml("#00FFFFFF");
                Vertical_Start_Marker_Annotation.Font.Color = System.Drawing.ColorTranslator.FromHtml("#FF00950E");


                Vertical_Stop_Marker = Graph.Plot.AddVerticalLine(X_MouseCoordinate, color: System.Drawing.ColorTranslator.FromHtml("#FFFF0000"), style: ScottPlot.LineStyle.DashDot, label: "V Marker");
                Vertical_Stop_Marker.DragEnabled = true;
                Vertical_Stop_Marker.Dragged += Vertical_Marker_Stop_Dragged_Event;
                double Vertical_Stop_Marker_Value = Vertical_Stop_Marker.X;
                Vertical_Stop_Marker_Annotation = Graph.Plot.AddAnnotation("V Marker: " + Axis_Scale_Config.Value_SI_Prefix(Vertical_Stop_Marker_Value, 4) + "Hz", 5, 20);
                Vertical_Stop_Marker_Annotation.Font.Size = 14;
                Vertical_Stop_Marker_Annotation.Shadow = false;
                Vertical_Stop_Marker_Annotation.BackgroundColor = System.Drawing.ColorTranslator.FromHtml("#00FFFFFF");
                Vertical_Stop_Marker_Annotation.BorderColor = System.Drawing.ColorTranslator.FromHtml("#00FFFFFF");
                Vertical_Stop_Marker_Annotation.Font.Color = System.Drawing.ColorTranslator.FromHtml("#FFFF0000");

                Vertical_Marker_FrequencyDifference_Annotation = Graph.Plot.AddAnnotation("∆ Frequency: " + Axis_Scale_Config.Value_SI_Prefix((Vertical_Stop_Marker_Value - Vertical_Start_Marker_Value), 4) + "Hz", 5, 35);
                Vertical_Marker_FrequencyDifference_Annotation.Font.Size = 14;
                Vertical_Marker_FrequencyDifference_Annotation.Shadow = false;
                Vertical_Marker_FrequencyDifference_Annotation.BackgroundColor = System.Drawing.ColorTranslator.FromHtml("#00FFFFFF");
                Vertical_Marker_FrequencyDifference_Annotation.BorderColor = System.Drawing.ColorTranslator.FromHtml("#00FFFFFF");
                Vertical_Marker_FrequencyDifference_Annotation.Font.Color = System.Drawing.ColorTranslator.FromHtml("#FF1E90FF");
                TimeDifference_Label.Content = Axis_Scale_Config.Value_SI_Prefix(Math.Abs(Vertical_Stop_Marker_Value - Vertical_Start_Marker_Value), 4) + "Hz";

                Vertical_Frequency_Start_Label.Content = Axis_Scale_Config.Value_SI_Prefix(Vertical_Start_Marker_Value, 4) + "Hz";
                Vertical_Frequency_Stop_Label.Content = Axis_Scale_Config.Value_SI_Prefix(Vertical_Stop_Marker_Value, 4) + "Hz";
                Graph.Render();
            }
            else
            {
                Vertical_Markers_MenuItem.IsChecked = false;
                Draggable_Vertical_Markers.IsChecked = false;
                Graph.Plot.Remove(plottable: Vertical_Start_Marker);
                Graph.Plot.Remove(plottable: Vertical_Stop_Marker);
                Clear_Vertical_Annotations();
                Insert_Log("Vertical Draggable Markers have been removed.", 0);
                Graph.Render();
            }
        }

        private void Clear_Vertical_Annotations()
        {
            Graph.Plot.Remove(plottable: Vertical_Start_Marker_Annotation);
            Graph.Plot.Remove(plottable: Vertical_Stop_Marker_Annotation);
            Graph.Plot.Remove(plottable: Vertical_Marker_FrequencyDifference_Annotation);
            Vertical_Frequency_Start_Label.Content = "null";
            Vertical_Frequency_Stop_Label.Content = "null";
            TimeDifference_Label.Content = "null";
        }

        private void Vertical_Marker_Start_Dragged_Event(object sender, EventArgs eventArgs)
        {
            double Vertical_Start_Marker_Value = Vertical_Start_Marker.X;
            Vertical_Start_Marker_Annotation.Label = "V Marker: " + Axis_Scale_Config.Value_SI_Prefix(Vertical_Start_Marker_Value, 4) + "Hz";
            Vertical_Frequency_Start_Label.Content = Axis_Scale_Config.Value_SI_Prefix(Vertical_Start_Marker_Value, 4) + "Hz";

            double Vertical_TimeDifference_Value = Math.Abs(Vertical_Stop_Marker.X - Vertical_Start_Marker_Value);
            Vertical_Marker_FrequencyDifference_Annotation.Label = "∆ Frequency: " + Axis_Scale_Config.Value_SI_Prefix(Vertical_TimeDifference_Value, 4) + "Hz";
            TimeDifference_Label.Content = Axis_Scale_Config.Value_SI_Prefix(Vertical_TimeDifference_Value, 4) + "Hz";
        }

        private void Vertical_Marker_Stop_Dragged_Event(object sender, EventArgs eventArgs)
        {
            double Vertical_Stop_Marker_Value = Vertical_Stop_Marker.X;
            Vertical_Stop_Marker_Annotation.Label = "V Marker: " + Axis_Scale_Config.Value_SI_Prefix(Vertical_Stop_Marker_Value, 4) + "Hz";
            Vertical_Frequency_Stop_Label.Content = Axis_Scale_Config.Value_SI_Prefix(Vertical_Stop_Marker_Value, 4) + "Hz";

            double Vertical_TimeDifference_Value = Math.Abs(Vertical_Stop_Marker_Value - Vertical_Start_Marker.X);
            Vertical_Marker_FrequencyDifference_Annotation.Label = "∆ Frequency: " + Axis_Scale_Config.Value_SI_Prefix(Vertical_TimeDifference_Value, 4) + "Hz";
            TimeDifference_Label.Content = Axis_Scale_Config.Value_SI_Prefix(Vertical_TimeDifference_Value, 4) + "Hz";
        }

        private void Add_Clear_Horizontal_Markers()
        {
            if (Horizontal_Markers_MenuItem.IsChecked == true & Draggable_Horizontal_Markers.IsChecked == true)
            {
                (double X_MouseCoordinate, double Y_MouseCoordinate) = Graph.GetMouseCoordinates();
                Horizontal_Start_Marker = Graph.Plot.AddHorizontalLine(Y_MouseCoordinate, color: System.Drawing.ColorTranslator.FromHtml("#FF00950E"), style: ScottPlot.LineStyle.DashDot, label: "H Marker");
                Horizontal_Start_Marker.DragEnabled = true;
                Horizontal_Start_Marker.Dragged += Horizontal_Marker_Start_Dragged_Event;
                double Horizontal_Start_Marker_Value = Horizontal_Start_Marker.Y;
                Horizontal_Start_Marker_Annotation = Graph.Plot.AddAnnotation("H Marker: " + Math.Round(Horizontal_Start_Marker_Value, 4) + Y_AXIS_Units, 5, 55);
                Horizontal_Start_Marker_Annotation.Font.Size = 14;
                Horizontal_Start_Marker_Annotation.Shadow = false;
                Horizontal_Start_Marker_Annotation.BackgroundColor = System.Drawing.ColorTranslator.FromHtml("#00FFFFFF");
                Horizontal_Start_Marker_Annotation.BorderColor = System.Drawing.ColorTranslator.FromHtml("#00FFFFFF");
                Horizontal_Start_Marker_Annotation.Font.Color = System.Drawing.ColorTranslator.FromHtml("#FF00950E");

                Horizontal_Stop_Marker = Graph.Plot.AddHorizontalLine(Y_MouseCoordinate, color: System.Drawing.ColorTranslator.FromHtml("#FFFF0000"), style: ScottPlot.LineStyle.DashDot, label: "H Marker");
                Horizontal_Stop_Marker.DragEnabled = true;
                Horizontal_Stop_Marker.Dragged += Horizontal_Marker_Stop_Dragged_Event;
                double Horizontal_Stop_Marker_Value = Horizontal_Stop_Marker.Y;
                Horizontal_Stop_Marker_Annotation = Graph.Plot.AddAnnotation("H Marker: " + Math.Round(Horizontal_Stop_Marker_Value, 4) + Y_AXIS_Units, 5, 70);
                Horizontal_Stop_Marker_Annotation.Font.Size = 14;
                Horizontal_Stop_Marker_Annotation.Shadow = false;
                Horizontal_Stop_Marker_Annotation.BackgroundColor = System.Drawing.ColorTranslator.FromHtml("#00FFFFFF");
                Horizontal_Stop_Marker_Annotation.BorderColor = System.Drawing.ColorTranslator.FromHtml("#00FFFFFF");
                Horizontal_Stop_Marker_Annotation.Font.Color = System.Drawing.ColorTranslator.FromHtml("#FFFF0000");

                Horizontal_Marker_MagnitudeDifference_Annotation = Graph.Plot.AddAnnotation("∆ Magnitude: " + Math.Round(Horizontal_Stop_Marker_Value - Horizontal_Start_Marker_Value, 4) + Y_AXIS_Units, 5, 85);
                Horizontal_Marker_MagnitudeDifference_Annotation.Font.Size = 14;
                Horizontal_Marker_MagnitudeDifference_Annotation.Shadow = false;
                Horizontal_Marker_MagnitudeDifference_Annotation.BackgroundColor = System.Drawing.ColorTranslator.FromHtml("#00FFFFFF");
                Horizontal_Marker_MagnitudeDifference_Annotation.BorderColor = System.Drawing.ColorTranslator.FromHtml("#00FFFFFF");
                Horizontal_Marker_MagnitudeDifference_Annotation.Font.Color = System.Drawing.ColorTranslator.FromHtml("#FF1E90FF");
                Horizontal_MagnitudeDifference_Label.Content = Math.Round(Math.Abs(Horizontal_Stop_Marker_Value - Horizontal_Start_Marker_Value), 4) + Y_AXIS_Units;

                Horizontal_Green_Label.Content = Math.Round(Horizontal_Start_Marker.Y, 4) + Y_AXIS_Units;
                Horizontal_Red_Label.Content = Math.Round(Horizontal_Stop_Marker.Y, 4) + Y_AXIS_Units;
                Graph.Render();
            }
            else
            {
                Horizontal_Markers_MenuItem.IsChecked = false;
                Draggable_Horizontal_Markers.IsChecked = false;
                Graph.Plot.Remove(plottable: Horizontal_Start_Marker);
                Graph.Plot.Remove(plottable: Horizontal_Stop_Marker);
                Clear_Horizontal_Annotations();
                Insert_Log("Horizontal Draggable Markers have been removed.", 0);
                Graph.Render();
            }
        }

        private void Clear_Horizontal_Annotations()
        {
            Graph.Plot.Remove(plottable: Horizontal_Start_Marker_Annotation);
            Graph.Plot.Remove(plottable: Horizontal_Stop_Marker_Annotation);
            Graph.Plot.Remove(plottable: Horizontal_Marker_MagnitudeDifference_Annotation);
            Horizontal_Green_Label.Content = "null";
            Horizontal_Red_Label.Content = "null";
            Horizontal_MagnitudeDifference_Label.Content = "null";
        }

        private void Horizontal_Marker_Start_Dragged_Event(object sender, EventArgs eventArgs)
        {
            double Horizontal_Start_Marker_Value = Horizontal_Start_Marker.Y;
            Horizontal_Start_Marker_Annotation.Label = "H Marker: " + Math.Round(Horizontal_Start_Marker_Value, 4) + Y_AXIS_Units;
            Horizontal_Green_Label.Content = Math.Round(Horizontal_Start_Marker_Value, 4) + Y_AXIS_Units;

            double Horizontal_VoltageDifference_Value = Math.Abs(Horizontal_Stop_Marker.Y - Horizontal_Start_Marker_Value);
            Horizontal_MagnitudeDifference_Label.Content = Math.Round(Horizontal_VoltageDifference_Value, 4) + Y_AXIS_Units;
            Horizontal_Marker_MagnitudeDifference_Annotation.Label = "∆ Magnitude: " + Math.Round(Horizontal_VoltageDifference_Value, 4) + Y_AXIS_Units;
        }

        private void Horizontal_Marker_Stop_Dragged_Event(object sender, EventArgs eventArgs)
        {
            double Horizontal_Stop_Marker_Value = Horizontal_Stop_Marker.Y;
            Horizontal_Stop_Marker_Annotation.Label = "H Marker: " + Math.Round(Horizontal_Stop_Marker.Y, 4) + Y_AXIS_Units;
            Horizontal_Red_Label.Content = Math.Round(Horizontal_Stop_Marker_Value, 4) + Y_AXIS_Units;

            double Horizontal_VoltageDifference_Value = Math.Abs(Horizontal_Stop_Marker_Value - Horizontal_Start_Marker.Y);
            Horizontal_MagnitudeDifference_Label.Content = Math.Round(Horizontal_VoltageDifference_Value, 4) + Y_AXIS_Units;
            Horizontal_Marker_MagnitudeDifference_Annotation.Label = "∆ Magnitude: " + Math.Round(Horizontal_VoltageDifference_Value, 4) + Y_AXIS_Units;
        }

        private void Add_H_Marker_Click(object sender, RoutedEventArgs e)
        {
            (bool isNum, double value) = Functions.Text_Num(H_Marker_Number.Text, true, false);
            if (isNum == true)
            {
                ScottPlot.Plottable.HLine H_Marker = Graph.Plot.AddHorizontalLine(value, label: "H Marker " + Math.Round(value, 2));
                H_Marker_Number.Text = string.Empty;
                Graph.Render();

                Horizontal_Markers_Fixed.Add(H_Marker);
            }
            else
            {
                H_Marker_Number.Text = string.Empty;
                Insert_Log("Adding a Fixed Horizontal marker failed. Marker value must be a real number.", 1);
                Graph.Render();
            }
        }

        private void Add_V_Marker_Click(object sender, RoutedEventArgs e)
        {
            (bool isNum, double value) = Functions.Text_Num(V_Marker_Number.Text, true, false);
            if (isNum == true)
            {
                ScottPlot.Plottable.VLine V_Marker = Graph.Plot.AddVerticalLine(value, label: "V Marker " + Math.Round(value, 2));
                V_Marker_Number.Text = string.Empty;
                Graph.Render();

                Vertical_Markers_Fixed.Add(V_Marker);
            }
            else
            {
                V_Marker_Number.Text = string.Empty;
                Insert_Log("Adding a Fixed Vertical marker failed. Marker value must be a real number.", 1);
                Graph.Render();
            }
        }

        private void Clear_Horizontal_Markers_Click(object sender, RoutedEventArgs e)
        {
            Clear_All_Horizontal_Markers();
            Insert_Log("All Horizontal Markers have been cleared.", 0);
        }

        private void Clear_All_Horizontal_Markers()
        {
            for (int i = 0; i < Horizontal_Markers_Fixed.Count; i++)
            {
                Graph.Plot.Remove(plottable: Horizontal_Markers_Fixed[i]);
            }
            Horizontal_Markers_Fixed.Clear();
            Graph.Render();
        }

        private void Clear_Vertical_Markers_Click(object sender, RoutedEventArgs e)
        {
            Clear_All_Vertical_Markers();
            Insert_Log("All Vertical Markers have been cleared.", 0);
        }

        private void Clear_All_Vertical_Markers()
        {
            for (int i = 0; i < Vertical_Markers_Fixed.Count; i++)
            {
                Graph.Plot.Remove(plottable: Vertical_Markers_Fixed[i]);
            }
            Vertical_Markers_Fixed.Clear();
            Graph.Render();
        }

        private void Clear_All_Markers_Click(object sender, RoutedEventArgs e)
        {
            Clear_All_Horizontal_Markers();
            Clear_All_Vertical_Markers();
            Insert_Log("All Markers have been cleared.", 0);
        }
    }
}
