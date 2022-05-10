using System;
using System.Windows;
using System.Windows.Controls;

namespace Waveform_Panel
{
    public partial class Waveform_Panel : UserControl
    {
        private ScottPlot.Plottable.VLine Vertical_Start_Marker;
        private ScottPlot.Plottable.VLine Vertical_Stop_Marker;
        private ScottPlot.Plottable.Annotation Vertical_Start_Marker_Annotation;
        private ScottPlot.Plottable.Annotation Vertical_Stop_Marker_Annotation;
        private ScottPlot.Plottable.Annotation Vertical_Marker_TimeDifference_Annotation;

        private ScottPlot.Plottable.HLine Horizontal_Start_Marker;
        private ScottPlot.Plottable.HLine Horizontal_Stop_Marker;
        private ScottPlot.Plottable.Annotation Horizontal_Start_Marker_Annotation;
        private ScottPlot.Plottable.Annotation Horizontal_Stop_Marker_Annotation;
        private ScottPlot.Plottable.Annotation Horizontal_Marker_VoltageDifference_Annotation;

        private void Add_Clear_Vertical_Markers()
        {
            if (Vertical_Markers_MenuItem.IsChecked == true)
            {
                (double X_MouseCoordinate, double Y_MouseCoordinate) = Graph.GetMouseCoordinates();
                Vertical_Start_Marker = Graph.Plot.AddVerticalLine(X_MouseCoordinate, color: System.Drawing.ColorTranslator.FromHtml("#FF00950E"), style: ScottPlot.LineStyle.DashDot, label: "V Marker");
                Vertical_Start_Marker.DragEnabled = true;
                Vertical_Start_Marker.Dragged += Vertical_Marker_Start_Dragged_Event;
                double Vertical_Start_Marker_Value = Vertical_Start_Marker.X;
                Vertical_Start_Marker_Annotation = Graph.Plot.AddAnnotation("V Marker: " + Axis_Scale_Config.Value_SI_Prefix(Vertical_Start_Marker_Value, 4) + X_Axis_units, 5, 20);
                Vertical_Start_Marker_Annotation.Font.Size = 14;
                Vertical_Start_Marker_Annotation.Shadow = false;
                Vertical_Start_Marker_Annotation.BackgroundColor = System.Drawing.ColorTranslator.FromHtml("#00FFFFFF");
                Vertical_Start_Marker_Annotation.BorderColor = System.Drawing.ColorTranslator.FromHtml("#00FFFFFF");
                Vertical_Start_Marker_Annotation.Font.Color = System.Drawing.ColorTranslator.FromHtml("#FF00950E");


                Vertical_Stop_Marker = Graph.Plot.AddVerticalLine(X_MouseCoordinate, color: System.Drawing.ColorTranslator.FromHtml("#FFFF0000"), style: ScottPlot.LineStyle.DashDot, label: "V Marker");
                Vertical_Stop_Marker.DragEnabled = true;
                Vertical_Stop_Marker.Dragged += Vertical_Marker_Stop_Dragged_Event;
                double Vertical_Stop_Marker_Value = Vertical_Stop_Marker.X;
                Vertical_Stop_Marker_Annotation = Graph.Plot.AddAnnotation("V Marker: " + Axis_Scale_Config.Value_SI_Prefix(Vertical_Stop_Marker_Value, 4) + X_Axis_units, 5, 35);
                Vertical_Stop_Marker_Annotation.Font.Size = 14;
                Vertical_Stop_Marker_Annotation.Shadow = false;
                Vertical_Stop_Marker_Annotation.BackgroundColor = System.Drawing.ColorTranslator.FromHtml("#00FFFFFF");
                Vertical_Stop_Marker_Annotation.BorderColor = System.Drawing.ColorTranslator.FromHtml("#00FFFFFF");
                Vertical_Stop_Marker_Annotation.Font.Color = System.Drawing.ColorTranslator.FromHtml("#FFFF0000");

                Vertical_Marker_TimeDifference_Annotation = Graph.Plot.AddAnnotation("∆ Time: " + Axis_Scale_Config.Value_SI_Prefix((Vertical_Stop_Marker_Value - Vertical_Start_Marker_Value), 4) + X_Axis_units, 5, 50);
                Vertical_Marker_TimeDifference_Annotation.Font.Size = 14;
                Vertical_Marker_TimeDifference_Annotation.Shadow = false;
                Vertical_Marker_TimeDifference_Annotation.BackgroundColor = System.Drawing.ColorTranslator.FromHtml("#00FFFFFF");
                Vertical_Marker_TimeDifference_Annotation.BorderColor = System.Drawing.ColorTranslator.FromHtml("#00FFFFFF");
                Vertical_Marker_TimeDifference_Annotation.Font.Color = System.Drawing.ColorTranslator.FromHtml("#FF1E90FF");
                Graph.Render();
            }
            else
            {
                Vertical_Markers_MenuItem.IsChecked = false;
                Graph.Plot.Remove(plottable: Vertical_Start_Marker);
                Graph.Plot.Remove(plottable: Vertical_Stop_Marker);
                Clear_Vertical_Annotations();
                Graph.Render();
            }
        }

        private void Clear_Vertical_Annotations()
        {
            Graph.Plot.Remove(plottable: Vertical_Start_Marker_Annotation);
            Graph.Plot.Remove(plottable: Vertical_Stop_Marker_Annotation);
            Graph.Plot.Remove(plottable: Vertical_Marker_TimeDifference_Annotation);
        }

        private void Vertical_Marker_Start_Dragged_Event(object sender, EventArgs eventArgs)
        {
            double Vertical_Start_Marker_Value = Vertical_Start_Marker.X;
            Vertical_Start_Marker_Annotation.Label = "V Marker: " + Axis_Scale_Config.Value_SI_Prefix(Vertical_Start_Marker_Value, 6) + X_Axis_units;

            double Vertical_TimeDifference_Value = Math.Abs(Vertical_Stop_Marker.X - Vertical_Start_Marker_Value);
            Vertical_Marker_TimeDifference_Annotation.Label = "∆ Time: " + Axis_Scale_Config.Value_SI_Prefix(Vertical_TimeDifference_Value, 4) + X_Axis_units;
        }

        private void Vertical_Marker_Stop_Dragged_Event(object sender, EventArgs eventArgs)
        {
            double Vertical_Stop_Marker_Value = Vertical_Stop_Marker.X;
            Vertical_Stop_Marker_Annotation.Label = "V Marker: " + Axis_Scale_Config.Value_SI_Prefix(Vertical_Stop_Marker_Value, 6) + X_Axis_units;
            double Vertical_TimeDifference_Value = Math.Abs(Vertical_Stop_Marker_Value - Vertical_Start_Marker.X);
            Vertical_Marker_TimeDifference_Annotation.Label = "∆ Time: " + Axis_Scale_Config.Value_SI_Prefix(Vertical_TimeDifference_Value, 4) + X_Axis_units;
        }

        private void Add_Clear_Horizontal_Markers()
        {
            if (Horizontal_Markers_MenuItem.IsChecked == true)
            {
                (double X_MouseCoordinate, double Y_MouseCoordinate) = Graph.GetMouseCoordinates();
                Horizontal_Start_Marker = Graph.Plot.AddHorizontalLine(Y_MouseCoordinate, color: System.Drawing.ColorTranslator.FromHtml("#FF00950E"), style: ScottPlot.LineStyle.DashDot, label: "H Marker");
                Horizontal_Start_Marker.DragEnabled = true;
                Horizontal_Start_Marker.Dragged += Horizontal_Marker_Start_Dragged_Event;
                double Horizontal_Start_Marker_Value = Horizontal_Start_Marker.Y;
                Horizontal_Start_Marker_Annotation = Graph.Plot.AddAnnotation("H Marker: " + Axis_Scale_Config.Value_SI_Prefix(Horizontal_Start_Marker_Value, 4) + Y_Axis_Units, 5, 65);
                Horizontal_Start_Marker_Annotation.Font.Size = 14;
                Horizontal_Start_Marker_Annotation.Shadow = false;
                Horizontal_Start_Marker_Annotation.BackgroundColor = System.Drawing.ColorTranslator.FromHtml("#00FFFFFF");
                Horizontal_Start_Marker_Annotation.BorderColor = System.Drawing.ColorTranslator.FromHtml("#00FFFFFF");
                Horizontal_Start_Marker_Annotation.Font.Color = System.Drawing.ColorTranslator.FromHtml("#FF00950E");

                Horizontal_Stop_Marker = Graph.Plot.AddHorizontalLine(Y_MouseCoordinate, color: System.Drawing.ColorTranslator.FromHtml("#FFFF0000"), style: ScottPlot.LineStyle.DashDot, label: "H Marker");
                Horizontal_Stop_Marker.DragEnabled = true;
                Horizontal_Stop_Marker.Dragged += Horizontal_Marker_Stop_Dragged_Event;
                double Horizontal_Stop_Marker_Value = Horizontal_Stop_Marker.Y;
                Horizontal_Stop_Marker_Annotation = Graph.Plot.AddAnnotation("H Marker: " + Axis_Scale_Config.Value_SI_Prefix(Horizontal_Stop_Marker_Value, 4) + Y_Axis_Units, 5, 80);
                Horizontal_Stop_Marker_Annotation.Font.Size = 14;
                Horizontal_Stop_Marker_Annotation.Shadow = false;
                Horizontal_Stop_Marker_Annotation.BackgroundColor = System.Drawing.ColorTranslator.FromHtml("#00FFFFFF");
                Horizontal_Stop_Marker_Annotation.BorderColor = System.Drawing.ColorTranslator.FromHtml("#00FFFFFF");
                Horizontal_Stop_Marker_Annotation.Font.Color = System.Drawing.ColorTranslator.FromHtml("#FFFF0000");

                Horizontal_Marker_VoltageDifference_Annotation = Graph.Plot.AddAnnotation("∆ Markers: " + Axis_Scale_Config.Value_SI_Prefix((Horizontal_Stop_Marker_Value - Horizontal_Start_Marker_Value), 4) + Y_Axis_Units, 5, 95);
                Horizontal_Marker_VoltageDifference_Annotation.Font.Size = 14;
                Horizontal_Marker_VoltageDifference_Annotation.Shadow = false;
                Horizontal_Marker_VoltageDifference_Annotation.BackgroundColor = System.Drawing.ColorTranslator.FromHtml("#00FFFFFF");
                Horizontal_Marker_VoltageDifference_Annotation.BorderColor = System.Drawing.ColorTranslator.FromHtml("#00FFFFFF");
                Horizontal_Marker_VoltageDifference_Annotation.Font.Color = System.Drawing.ColorTranslator.FromHtml("#FF1E90FF");
                Graph.Render();
            }
            else
            {
                Horizontal_Markers_MenuItem.IsChecked = false;
                Graph.Plot.Remove(plottable: Horizontal_Start_Marker);
                Graph.Plot.Remove(plottable: Horizontal_Stop_Marker);
                Clear_Horizontal_Annotations();
                Graph.Render();
            }
        }

        private void Clear_Horizontal_Annotations()
        {
            Graph.Plot.Remove(plottable: Horizontal_Start_Marker_Annotation);
            Graph.Plot.Remove(plottable: Horizontal_Stop_Marker_Annotation);
            Graph.Plot.Remove(plottable: Horizontal_Marker_VoltageDifference_Annotation);
        }

        private void Horizontal_Marker_Start_Dragged_Event(object sender, EventArgs eventArgs)
        {
            double Horizontal_Start_Marker_Value = Horizontal_Start_Marker.Y;
            Horizontal_Start_Marker_Annotation.Label = "H Marker: " + Axis_Scale_Config.Value_SI_Prefix(Horizontal_Start_Marker_Value, 4) + Y_Axis_Units;
            double Horizontal_VoltageDifference_Value = Math.Abs(Horizontal_Stop_Marker.Y - Horizontal_Start_Marker_Value);
            Horizontal_Marker_VoltageDifference_Annotation.Label = "∆ Markers: " + Axis_Scale_Config.Value_SI_Prefix(Horizontal_VoltageDifference_Value, 4) + Y_Axis_Units;
        }

        private void Horizontal_Marker_Stop_Dragged_Event(object sender, EventArgs eventArgs)
        {
            double Horizontal_Stop_Marker_Value = Horizontal_Stop_Marker.Y;
            Horizontal_Stop_Marker_Annotation.Label = "H Marker: " + Axis_Scale_Config.Value_SI_Prefix(Horizontal_Stop_Marker.Y, 4) + Y_Axis_Units;
            double Horizontal_VoltageDifference_Value = Math.Abs(Horizontal_Stop_Marker_Value - Horizontal_Start_Marker.Y);
            Horizontal_Marker_VoltageDifference_Annotation.Label = "∆ Markers: " + Axis_Scale_Config.Value_SI_Prefix(Horizontal_VoltageDifference_Value, 4) + Y_Axis_Units;
        }

        private void Clear_Horizontal_Markers_Click(object sender, RoutedEventArgs e)
        {
            Clear_All_Horizontal_Markers();
        }

        private void Clear_All_Horizontal_Markers()
        {
            Clear_Horizontal_Annotations();
            Horizontal_Markers_MenuItem.IsChecked = false;
            Graph.Plot.Clear(typeof(ScottPlot.Plottable.HLine));
            Graph.Render();
        }

        private void Clear_Vertical_Markers_Click(object sender, RoutedEventArgs e)
        {
            Clear_All_Vertical_Markers();
        }

        private void Clear_All_Vertical_Markers()
        {
            Clear_Vertical_Annotations();
            Vertical_Markers_MenuItem.IsChecked = false;
            Graph.Plot.Clear(typeof(ScottPlot.Plottable.VLine));
            Graph.Render();
        }

        private void Clear_All_Markers_Click(object sender, RoutedEventArgs e)
        {
            Clear_All_Horizontal_Markers();
            Clear_All_Vertical_Markers();
        }
    }
}
