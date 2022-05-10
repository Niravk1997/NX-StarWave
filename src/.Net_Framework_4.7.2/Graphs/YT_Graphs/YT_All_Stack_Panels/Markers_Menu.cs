using MahApps.Metro.Controls;
using System;
using System.Collections.Generic;
using System.Windows;


namespace AllChannels_YT_Stack
{
    public partial class AllChannels_YT_Stack_Plotter : MetroWindow
    {
        //Graph 1
        private ScottPlot.Plottable.VLine Vertical_Start_Marker_1;
        private ScottPlot.Plottable.VLine Vertical_Stop_Marker_1;
        private ScottPlot.Plottable.Annotation Vertical_Start_Marker_1_Annotation;
        private ScottPlot.Plottable.Annotation Vertical_Stop_Marker_1_Annotation;
        private ScottPlot.Plottable.Annotation Vertical_Marker_1_TimeDifference_Annotation;
        //Graph 2
        private ScottPlot.Plottable.VLine Vertical_Start_Marker_2;
        private ScottPlot.Plottable.VLine Vertical_Stop_Marker_2;
        //Graph 3
        private ScottPlot.Plottable.VLine Vertical_Start_Marker_3;
        private ScottPlot.Plottable.VLine Vertical_Stop_Marker_3;
        //Graph 4
        private ScottPlot.Plottable.VLine Vertical_Start_Marker_4;
        private ScottPlot.Plottable.VLine Vertical_Stop_Marker_4;

        //Graph 1
        private ScottPlot.Plottable.HLine Horizontal_Start_Marker_1;
        private ScottPlot.Plottable.HLine Horizontal_Stop_Marker_1;
        private ScottPlot.Plottable.Annotation Horizontal_Start_Marker_1_Annotation;
        private ScottPlot.Plottable.Annotation Horizontal_Stop_Marker_1_Annotation;
        private ScottPlot.Plottable.Annotation Horizontal_Marker_1_VoltageDifference_Annotation;
        //Graph 2
        private ScottPlot.Plottable.HLine Horizontal_Start_Marker_2;
        private ScottPlot.Plottable.HLine Horizontal_Stop_Marker_2;
        //Graph 3
        private ScottPlot.Plottable.HLine Horizontal_Start_Marker_3;
        private ScottPlot.Plottable.HLine Horizontal_Stop_Marker_3;
        //Graph 4
        private ScottPlot.Plottable.HLine Horizontal_Start_Marker_4;
        private ScottPlot.Plottable.HLine Horizontal_Stop_Marker_4;

        private List<ScottPlot.Plottable.VLine> Graph_1_Vertical_Markers_Fixed = new List<ScottPlot.Plottable.VLine>();
        private List<ScottPlot.Plottable.HLine> Graph_1_Horizontal_Markers_Fixed = new List<ScottPlot.Plottable.HLine>();

        private List<ScottPlot.Plottable.VLine> Graph_2_Vertical_Markers_Fixed = new List<ScottPlot.Plottable.VLine>();
        private List<ScottPlot.Plottable.HLine> Graph_2_Horizontal_Markers_Fixed = new List<ScottPlot.Plottable.HLine>();

        private List<ScottPlot.Plottable.VLine> Graph_3_Vertical_Markers_Fixed = new List<ScottPlot.Plottable.VLine>();
        private List<ScottPlot.Plottable.HLine> Graph_3_Horizontal_Markers_Fixed = new List<ScottPlot.Plottable.HLine>();

        private List<ScottPlot.Plottable.VLine> Graph_4_Vertical_Markers_Fixed = new List<ScottPlot.Plottable.VLine>();
        private List<ScottPlot.Plottable.HLine> Graph_4_Horizontal_Markers_Fixed = new List<ScottPlot.Plottable.HLine>();

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
                (double X_MouseCoordinate, double Y_MouseCoordinate) = Graph_1.GetMouseCoordinates();

                if (Graph_2.IsMouseOver)
                {
                    (X_MouseCoordinate, Y_MouseCoordinate) = Graph_2.GetMouseCoordinates();
                }
                else if (Graph_3.IsMouseOver)
                {
                    (X_MouseCoordinate, Y_MouseCoordinate) = Graph_3.GetMouseCoordinates();
                }
                else if (Graph_4.IsMouseOver)
                {
                    (X_MouseCoordinate, Y_MouseCoordinate) = Graph_4.GetMouseCoordinates();
                }

                Vertical_Start_Marker_1 = Graph_1.Plot.AddVerticalLine(X_MouseCoordinate, color: System.Drawing.ColorTranslator.FromHtml("#FF00950E"), style: ScottPlot.LineStyle.DashDot, label: "V Marker");
                Vertical_Start_Marker_1.DragEnabled = true;
                Vertical_Start_Marker_1.Dragged += Vertical_Marker_Start_Dragged_Event;

                Vertical_Start_Marker_2 = Graph_2.Plot.AddVerticalLine(X_MouseCoordinate, color: System.Drawing.ColorTranslator.FromHtml("#FF00950E"), style: ScottPlot.LineStyle.DashDot, label: "V Marker");
                Vertical_Start_Marker_2.DragEnabled = true;
                Vertical_Start_Marker_2.Dragged += Vertical_Marker_Start_Dragged_Event;

                Vertical_Start_Marker_3 = Graph_3.Plot.AddVerticalLine(X_MouseCoordinate, color: System.Drawing.ColorTranslator.FromHtml("#FF00950E"), style: ScottPlot.LineStyle.DashDot, label: "V Marker");
                Vertical_Start_Marker_3.DragEnabled = true;
                Vertical_Start_Marker_3.Dragged += Vertical_Marker_Start_Dragged_Event;

                Vertical_Start_Marker_4 = Graph_4.Plot.AddVerticalLine(X_MouseCoordinate, color: System.Drawing.ColorTranslator.FromHtml("#FF00950E"), style: ScottPlot.LineStyle.DashDot, label: "V Marker");
                Vertical_Start_Marker_4.DragEnabled = true;
                Vertical_Start_Marker_4.Dragged += Vertical_Marker_Start_Dragged_Event;


                double Vertical_Start_Marker_1_Value = Vertical_Start_Marker_1.X;
                Vertical_Start_Marker_1_Annotation = Graph_1.Plot.AddAnnotation("V Marker: " + Axis_Scale_Config.Value_SI_Prefix(Vertical_Start_Marker_1_Value, 4) + "s", 5, 5);
                Vertical_Start_Marker_1_Annotation.Font.Size = 14;
                Vertical_Start_Marker_1_Annotation.Shadow = false;
                Vertical_Start_Marker_1_Annotation.BackgroundColor = System.Drawing.ColorTranslator.FromHtml("#00FFFFFF");
                Vertical_Start_Marker_1_Annotation.BorderColor = System.Drawing.ColorTranslator.FromHtml("#00FFFFFF");
                Vertical_Start_Marker_1_Annotation.Font.Color = System.Drawing.ColorTranslator.FromHtml("#FF00950E");


                Vertical_Stop_Marker_1 = Graph_1.Plot.AddVerticalLine(X_MouseCoordinate, color: System.Drawing.ColorTranslator.FromHtml("#FFFF0000"), style: ScottPlot.LineStyle.DashDot, label: "V Marker");
                Vertical_Stop_Marker_1.DragEnabled = true;
                Vertical_Stop_Marker_1.Dragged += Vertical_Marker_Stop_Dragged_Event;

                Vertical_Stop_Marker_2 = Graph_2.Plot.AddVerticalLine(X_MouseCoordinate, color: System.Drawing.ColorTranslator.FromHtml("#FFFF0000"), style: ScottPlot.LineStyle.DashDot, label: "V Marker");
                Vertical_Stop_Marker_2.DragEnabled = true;
                Vertical_Stop_Marker_2.Dragged += Vertical_Marker_Stop_Dragged_Event;

                Vertical_Stop_Marker_3 = Graph_3.Plot.AddVerticalLine(X_MouseCoordinate, color: System.Drawing.ColorTranslator.FromHtml("#FFFF0000"), style: ScottPlot.LineStyle.DashDot, label: "V Marker");
                Vertical_Stop_Marker_3.DragEnabled = true;
                Vertical_Stop_Marker_3.Dragged += Vertical_Marker_Stop_Dragged_Event;

                Vertical_Stop_Marker_4 = Graph_4.Plot.AddVerticalLine(X_MouseCoordinate, color: System.Drawing.ColorTranslator.FromHtml("#FFFF0000"), style: ScottPlot.LineStyle.DashDot, label: "V Marker");
                Vertical_Stop_Marker_4.DragEnabled = true;
                Vertical_Stop_Marker_4.Dragged += Vertical_Marker_Stop_Dragged_Event;


                double Vertical_Stop_Marker_1_Value = Vertical_Stop_Marker_1.X;
                Vertical_Stop_Marker_1_Annotation = Graph_1.Plot.AddAnnotation("V Marker: " + Axis_Scale_Config.Value_SI_Prefix(Vertical_Stop_Marker_1_Value, 4) + "s", 5, 20);
                Vertical_Stop_Marker_1_Annotation.Font.Size = 14;
                Vertical_Stop_Marker_1_Annotation.Shadow = false;
                Vertical_Stop_Marker_1_Annotation.BackgroundColor = System.Drawing.ColorTranslator.FromHtml("#00FFFFFF");
                Vertical_Stop_Marker_1_Annotation.BorderColor = System.Drawing.ColorTranslator.FromHtml("#00FFFFFF");
                Vertical_Stop_Marker_1_Annotation.Font.Color = System.Drawing.ColorTranslator.FromHtml("#FFFF0000");

                Vertical_Marker_1_TimeDifference_Annotation = Graph_1.Plot.AddAnnotation("∆ Time: " + Axis_Scale_Config.Value_SI_Prefix((Vertical_Stop_Marker_1_Value - Vertical_Start_Marker_1_Value), 4) + "s", 5, 35);
                Vertical_Marker_1_TimeDifference_Annotation.Font.Size = 14;
                Vertical_Marker_1_TimeDifference_Annotation.Shadow = false;
                Vertical_Marker_1_TimeDifference_Annotation.BackgroundColor = System.Drawing.ColorTranslator.FromHtml("#00FFFFFF");
                Vertical_Marker_1_TimeDifference_Annotation.BorderColor = System.Drawing.ColorTranslator.FromHtml("#00FFFFFF");
                Vertical_Marker_1_TimeDifference_Annotation.Font.Color = System.Drawing.ColorTranslator.FromHtml("#FF1E90FF");
                TimeDifference_Label.Content = Axis_Scale_Config.Value_SI_Prefix(Math.Abs(Vertical_Stop_Marker_1_Value - Vertical_Start_Marker_1_Value), 4) + "s";

                Vertical_StartTime_Label.Content = Axis_Scale_Config.Value_SI_Prefix(Vertical_Start_Marker_1_Value, 6) + "s";
                Vertical_StopTime_Label.Content = Axis_Scale_Config.Value_SI_Prefix(Vertical_Stop_Marker_1_Value, 6) + "s";

                Period_Label.Content = Axis_Scale_Config.Value_SI_Prefix(Math.Abs(Vertical_Stop_Marker_1_Value - Vertical_Start_Marker_1_Value), 4) + "s";
                Frequency_Label.Content = Axis_Scale_Config.Value_SI_Prefix(1 / Math.Abs(Vertical_Stop_Marker_1_Value - Vertical_Start_Marker_1_Value), 4) + "Hz";

                Graph_1.Render();
                Graph_2.Render();
                Graph_3.Render();
                Graph_4.Render();
            }
            else
            {
                Vertical_Markers_MenuItem.IsChecked = false;
                Draggable_Vertical_Markers.IsChecked = false;

                Graph_1.Plot.Remove(plottable: Vertical_Start_Marker_1);
                Graph_1.Plot.Remove(plottable: Vertical_Stop_Marker_1);

                Graph_2.Plot.Remove(plottable: Vertical_Start_Marker_2);
                Graph_2.Plot.Remove(plottable: Vertical_Stop_Marker_2);

                Graph_3.Plot.Remove(plottable: Vertical_Start_Marker_3);
                Graph_3.Plot.Remove(plottable: Vertical_Stop_Marker_3);

                Graph_4.Plot.Remove(plottable: Vertical_Start_Marker_4);
                Graph_4.Plot.Remove(plottable: Vertical_Stop_Marker_4);

                Clear_Vertical_Annotations();
                Insert_Log("Vertical Draggable Markers have been removed.", 0);

                Graph_1.Render();
                Graph_2.Render();
                Graph_3.Render();
                Graph_4.Render();
            }
        }

        private void Clear_Vertical_Annotations()
        {
            Graph_1.Plot.Remove(plottable: Vertical_Start_Marker_1_Annotation);
            Graph_1.Plot.Remove(plottable: Vertical_Stop_Marker_1_Annotation);
            Graph_1.Plot.Remove(plottable: Vertical_Marker_1_TimeDifference_Annotation);
            Vertical_StartTime_Label.Content = "null";
            Vertical_StopTime_Label.Content = "null";
            TimeDifference_Label.Content = "null";
            Period_Label.Content = "null";
            Frequency_Label.Content = "null";
        }

        private void Vertical_Marker_Start_Dragged_Event(object sender, EventArgs eventArgs)
        {
            double Vertical_Start_Marker_Value = Vertical_Start_Marker_1.X;

            if (Graph_2.IsMouseOver)
            {
                Vertical_Start_Marker_Value = Vertical_Start_Marker_2.X;
            }
            else if (Graph_3.IsMouseOver)
            {
                Vertical_Start_Marker_Value = Vertical_Start_Marker_3.X;
            }
            else if (Graph_4.IsMouseOver)
            {
                Vertical_Start_Marker_Value = Vertical_Start_Marker_4.X;
            }

            Vertical_Start_Marker_1_Annotation.Label = "V Marker: " + Axis_Scale_Config.Value_SI_Prefix(Vertical_Start_Marker_Value, 6) + "s";
            Vertical_StartTime_Label.Content = Axis_Scale_Config.Value_SI_Prefix(Vertical_Start_Marker_Value, 6) + "s";

            double Vertical_TimeDifference_Value = Math.Abs(Vertical_Stop_Marker_1.X - Vertical_Start_Marker_Value);
            Vertical_Marker_1_TimeDifference_Annotation.Label = "∆ Time: " + Axis_Scale_Config.Value_SI_Prefix(Vertical_TimeDifference_Value, 4) + "s";
            TimeDifference_Label.Content = Axis_Scale_Config.Value_SI_Prefix(Vertical_TimeDifference_Value, 4) + "s";

            Period_Label.Content = Axis_Scale_Config.Value_SI_Prefix(Vertical_TimeDifference_Value, 4) + "s";
            Frequency_Label.Content = Axis_Scale_Config.Value_SI_Prefix(1 / Vertical_TimeDifference_Value, 4) + "Hz";

            Vertical_Start_Marker_1.X = Vertical_Start_Marker_Value;
            Graph_1.Render();

            Vertical_Start_Marker_2.X = Vertical_Start_Marker_Value;
            Graph_2.Render();

            Vertical_Start_Marker_3.X = Vertical_Start_Marker_Value;
            Graph_3.Render();

            Vertical_Start_Marker_4.X = Vertical_Start_Marker_Value;
            Graph_4.Render();
        }

        private void Vertical_Marker_Stop_Dragged_Event(object sender, EventArgs eventArgs)
        {
            double Vertical_Stop_Marker_Value = Vertical_Stop_Marker_1.X;

            if (Graph_2.IsMouseOver)
            {
                Vertical_Stop_Marker_Value = Vertical_Stop_Marker_2.X;
            }
            else if (Graph_3.IsMouseOver)
            {
                Vertical_Stop_Marker_Value = Vertical_Stop_Marker_3.X;
            }
            else if (Graph_4.IsMouseOver)
            {
                Vertical_Stop_Marker_Value = Vertical_Stop_Marker_4.X;
            }

            Vertical_Stop_Marker_1_Annotation.Label = "V Marker: " + Axis_Scale_Config.Value_SI_Prefix(Vertical_Stop_Marker_Value, 6) + "s";
            Vertical_StopTime_Label.Content = Axis_Scale_Config.Value_SI_Prefix(Vertical_Stop_Marker_Value, 6) + "s";

            double Vertical_TimeDifference_Value = Math.Abs(Vertical_Stop_Marker_Value - Vertical_Start_Marker_1.X);
            Vertical_Marker_1_TimeDifference_Annotation.Label = "∆ Time: " + Axis_Scale_Config.Value_SI_Prefix(Vertical_TimeDifference_Value, 4) + "s";
            TimeDifference_Label.Content = Axis_Scale_Config.Value_SI_Prefix(Vertical_TimeDifference_Value, 4) + "s";

            Period_Label.Content = Axis_Scale_Config.Value_SI_Prefix(Vertical_TimeDifference_Value, 4) + "s";
            Frequency_Label.Content = Axis_Scale_Config.Value_SI_Prefix(1 / Vertical_TimeDifference_Value, 4) + "Hz";

            Vertical_Stop_Marker_1.X = Vertical_Stop_Marker_Value;
            Graph_1.Render();

            Vertical_Stop_Marker_2.X = Vertical_Stop_Marker_Value;
            Graph_2.Render();

            Vertical_Stop_Marker_3.X = Vertical_Stop_Marker_Value;
            Graph_3.Render();

            Vertical_Stop_Marker_4.X = Vertical_Stop_Marker_Value;
            Graph_4.Render();
        }

        private void Add_Clear_Horizontal_Markers()
        {
            if (Horizontal_Markers_MenuItem.IsChecked == true & Draggable_Horizontal_Markers.IsChecked == true)
            {
                (double X_MouseCoordinate, double Y_MouseCoordinate) = Graph_1.GetMouseCoordinates();

                if (Graph_2.IsMouseOver)
                {
                    (X_MouseCoordinate, Y_MouseCoordinate) = Graph_2.GetMouseCoordinates();
                }
                else if (Graph_3.IsMouseOver)
                {
                    (X_MouseCoordinate, Y_MouseCoordinate) = Graph_3.GetMouseCoordinates();
                }
                else if (Graph_4.IsMouseOver)
                {
                    (X_MouseCoordinate, Y_MouseCoordinate) = Graph_4.GetMouseCoordinates();
                }

                Horizontal_Start_Marker_1 = Graph_1.Plot.AddHorizontalLine(Y_MouseCoordinate, color: System.Drawing.ColorTranslator.FromHtml("#FF00950E"), style: ScottPlot.LineStyle.DashDot, label: "H Marker");
                Horizontal_Start_Marker_1.DragEnabled = true;
                Horizontal_Start_Marker_1.Dragged += Horizontal_Marker_Start_Dragged_Event;

                Horizontal_Start_Marker_2 = Graph_2.Plot.AddHorizontalLine(Y_MouseCoordinate, color: System.Drawing.ColorTranslator.FromHtml("#FF00950E"), style: ScottPlot.LineStyle.DashDot, label: "H Marker");
                Horizontal_Start_Marker_2.DragEnabled = true;
                Horizontal_Start_Marker_2.Dragged += Horizontal_Marker_Start_Dragged_Event;

                Horizontal_Start_Marker_3 = Graph_3.Plot.AddHorizontalLine(Y_MouseCoordinate, color: System.Drawing.ColorTranslator.FromHtml("#FF00950E"), style: ScottPlot.LineStyle.DashDot, label: "H Marker");
                Horizontal_Start_Marker_3.DragEnabled = true;
                Horizontal_Start_Marker_3.Dragged += Horizontal_Marker_Start_Dragged_Event;

                Horizontal_Start_Marker_4 = Graph_4.Plot.AddHorizontalLine(Y_MouseCoordinate, color: System.Drawing.ColorTranslator.FromHtml("#FF00950E"), style: ScottPlot.LineStyle.DashDot, label: "H Marker");
                Horizontal_Start_Marker_4.DragEnabled = true;
                Horizontal_Start_Marker_4.Dragged += Horizontal_Marker_Start_Dragged_Event;



                double Horizontal_Start_Marker_1_Value = Horizontal_Start_Marker_1.Y;
                Horizontal_Start_Marker_1_Annotation = Graph_1.Plot.AddAnnotation("H Marker: " + Axis_Scale_Config.Value_SI_Prefix(Horizontal_Start_Marker_1_Value, 4) + CH1_Measurement_Unit, 5, 55);
                Horizontal_Start_Marker_1_Annotation.Font.Size = 14;
                Horizontal_Start_Marker_1_Annotation.Shadow = false;
                Horizontal_Start_Marker_1_Annotation.BackgroundColor = System.Drawing.ColorTranslator.FromHtml("#00FFFFFF");
                Horizontal_Start_Marker_1_Annotation.BorderColor = System.Drawing.ColorTranslator.FromHtml("#00FFFFFF");
                Horizontal_Start_Marker_1_Annotation.Font.Color = System.Drawing.ColorTranslator.FromHtml("#FF00950E");

                Horizontal_Stop_Marker_1 = Graph_1.Plot.AddHorizontalLine(Y_MouseCoordinate, color: System.Drawing.ColorTranslator.FromHtml("#FFFF0000"), style: ScottPlot.LineStyle.DashDot, label: "H Marker");
                Horizontal_Stop_Marker_1.DragEnabled = true;
                Horizontal_Stop_Marker_1.Dragged += Horizontal_Marker_Stop_Dragged_Event;

                Horizontal_Stop_Marker_2 = Graph_2.Plot.AddHorizontalLine(Y_MouseCoordinate, color: System.Drawing.ColorTranslator.FromHtml("#FFFF0000"), style: ScottPlot.LineStyle.DashDot, label: "H Marker");
                Horizontal_Stop_Marker_2.DragEnabled = true;
                Horizontal_Stop_Marker_2.Dragged += Horizontal_Marker_Stop_Dragged_Event;

                Horizontal_Stop_Marker_3 = Graph_3.Plot.AddHorizontalLine(Y_MouseCoordinate, color: System.Drawing.ColorTranslator.FromHtml("#FFFF0000"), style: ScottPlot.LineStyle.DashDot, label: "H Marker");
                Horizontal_Stop_Marker_3.DragEnabled = true;
                Horizontal_Stop_Marker_3.Dragged += Horizontal_Marker_Stop_Dragged_Event;

                Horizontal_Stop_Marker_4 = Graph_4.Plot.AddHorizontalLine(Y_MouseCoordinate, color: System.Drawing.ColorTranslator.FromHtml("#FFFF0000"), style: ScottPlot.LineStyle.DashDot, label: "H Marker");
                Horizontal_Stop_Marker_4.DragEnabled = true;
                Horizontal_Stop_Marker_4.Dragged += Horizontal_Marker_Stop_Dragged_Event;


                double Horizontal_Stop_Marker_1_Value = Horizontal_Stop_Marker_1.Y;
                Horizontal_Stop_Marker_1_Annotation = Graph_1.Plot.AddAnnotation("H Marker: " + Axis_Scale_Config.Value_SI_Prefix(Horizontal_Stop_Marker_1_Value, 4) + CH1_Measurement_Unit, 5, 70);
                Horizontal_Stop_Marker_1_Annotation.Font.Size = 14;
                Horizontal_Stop_Marker_1_Annotation.Shadow = false;
                Horizontal_Stop_Marker_1_Annotation.BackgroundColor = System.Drawing.ColorTranslator.FromHtml("#00FFFFFF");
                Horizontal_Stop_Marker_1_Annotation.BorderColor = System.Drawing.ColorTranslator.FromHtml("#00FFFFFF");
                Horizontal_Stop_Marker_1_Annotation.Font.Color = System.Drawing.ColorTranslator.FromHtml("#FFFF0000");

                Horizontal_Marker_1_VoltageDifference_Annotation = Graph_1.Plot.AddAnnotation("∆ Marker: " + Axis_Scale_Config.Value_SI_Prefix((Horizontal_Stop_Marker_1_Value - Horizontal_Start_Marker_1_Value), 4) + CH1_Measurement_Unit, 5, 85);
                Horizontal_Marker_1_VoltageDifference_Annotation.Font.Size = 14;
                Horizontal_Marker_1_VoltageDifference_Annotation.Shadow = false;
                Horizontal_Marker_1_VoltageDifference_Annotation.BackgroundColor = System.Drawing.ColorTranslator.FromHtml("#00FFFFFF");
                Horizontal_Marker_1_VoltageDifference_Annotation.BorderColor = System.Drawing.ColorTranslator.FromHtml("#00FFFFFF");
                Horizontal_Marker_1_VoltageDifference_Annotation.Font.Color = System.Drawing.ColorTranslator.FromHtml("#FF1E90FF");
                Horizontal_VoltageDifference_Label.Content = Axis_Scale_Config.Value_SI_Prefix(Math.Abs(Horizontal_Stop_Marker_1_Value - Horizontal_Start_Marker_1_Value), 4) + CH1_Measurement_Unit;

                Horizontal_Green_Label.Content = Axis_Scale_Config.Value_SI_Prefix(Horizontal_Start_Marker_1.Y, 4) + CH1_Measurement_Unit;
                Horizontal_Red_Label.Content = Axis_Scale_Config.Value_SI_Prefix(Horizontal_Stop_Marker_1.Y, 4) + CH1_Measurement_Unit;
                Graph_1.Render();
                Graph_2.Render();
                Graph_3.Render();
                Graph_4.Render();
            }
            else
            {
                Horizontal_Markers_MenuItem.IsChecked = false;
                Draggable_Horizontal_Markers.IsChecked = false;

                Graph_1.Plot.Remove(plottable: Horizontal_Start_Marker_1);
                Graph_1.Plot.Remove(plottable: Horizontal_Stop_Marker_1);

                Graph_2.Plot.Remove(plottable: Horizontal_Start_Marker_2);
                Graph_2.Plot.Remove(plottable: Horizontal_Stop_Marker_2);

                Graph_3.Plot.Remove(plottable: Horizontal_Start_Marker_3);
                Graph_3.Plot.Remove(plottable: Horizontal_Stop_Marker_3);

                Graph_4.Plot.Remove(plottable: Horizontal_Start_Marker_4);
                Graph_4.Plot.Remove(plottable: Horizontal_Stop_Marker_4);

                Clear_Horizontal_Annotations();
                Insert_Log("Horizontal Draggable Markers have been removed.", 0);
                Graph_1.Render();
                Graph_2.Render();
                Graph_3.Render();
                Graph_4.Render();
            }
        }

        private void Clear_Horizontal_Annotations()
        {
            Graph_1.Plot.Remove(plottable: Horizontal_Start_Marker_1_Annotation);
            Graph_1.Plot.Remove(plottable: Horizontal_Stop_Marker_1_Annotation);
            Graph_1.Plot.Remove(plottable: Horizontal_Marker_1_VoltageDifference_Annotation);
            Horizontal_Green_Label.Content = "null";
            Horizontal_Red_Label.Content = "null";
            Horizontal_VoltageDifference_Label.Content = "null";
        }

        private void Horizontal_Marker_Start_Dragged_Event(object sender, EventArgs eventArgs)
        {
            double Horizontal_Start_Marker_Value = Horizontal_Start_Marker_1.Y;

            if (Graph_2.IsMouseOver)
            {
                Horizontal_Start_Marker_Value = Horizontal_Start_Marker_2.Y;
            }
            else if (Graph_3.IsMouseOver)
            {
                Horizontal_Start_Marker_Value = Horizontal_Start_Marker_3.Y;
            }
            else if (Graph_4.IsMouseOver)
            {
                Horizontal_Start_Marker_Value = Horizontal_Start_Marker_4.Y;
            }

            Horizontal_Start_Marker_1_Annotation.Label = "H Marker: " + Axis_Scale_Config.Value_SI_Prefix(Horizontal_Start_Marker_Value, 4) + CH1_Measurement_Unit;
            Horizontal_Green_Label.Content = Axis_Scale_Config.Value_SI_Prefix(Horizontal_Start_Marker_Value, 4) + CH1_Measurement_Unit;

            double Horizontal_VoltageDifference_Value = Math.Abs(Horizontal_Stop_Marker_1.Y - Horizontal_Start_Marker_Value);
            Horizontal_VoltageDifference_Label.Content = Axis_Scale_Config.Value_SI_Prefix(Horizontal_VoltageDifference_Value, 4) + CH1_Measurement_Unit;
            Horizontal_Marker_1_VoltageDifference_Annotation.Label = "∆ Marker: " + Axis_Scale_Config.Value_SI_Prefix(Horizontal_VoltageDifference_Value, 4) + CH1_Measurement_Unit;

            Horizontal_Start_Marker_1.Y = Horizontal_Start_Marker_Value;
            Graph_1.Render();

            Horizontal_Start_Marker_2.Y = Horizontal_Start_Marker_Value;
            Graph_2.Render();

            Horizontal_Start_Marker_3.Y = Horizontal_Start_Marker_Value;
            Graph_3.Render();

            Horizontal_Start_Marker_4.Y = Horizontal_Start_Marker_Value;
            Graph_4.Render();
        }

        private void Horizontal_Marker_Stop_Dragged_Event(object sender, EventArgs eventArgs)
        {
            double Horizontal_Stop_Marker_Value = Horizontal_Stop_Marker_1.Y;

            if (Graph_2.IsMouseOver)
            {
                Horizontal_Stop_Marker_Value = Horizontal_Stop_Marker_2.Y;
            }
            else if (Graph_3.IsMouseOver)
            {
                Horizontal_Stop_Marker_Value = Horizontal_Stop_Marker_3.Y;
            }
            else if (Graph_4.IsMouseOver)
            {
                Horizontal_Stop_Marker_Value = Horizontal_Stop_Marker_4.Y;
            }

            Horizontal_Stop_Marker_1_Annotation.Label = "H Marker: " + Axis_Scale_Config.Value_SI_Prefix(Horizontal_Stop_Marker_1.Y, 4) + CH1_Measurement_Unit;
            Horizontal_Red_Label.Content = Axis_Scale_Config.Value_SI_Prefix(Horizontal_Stop_Marker_Value, 4) + CH1_Measurement_Unit;

            double Horizontal_VoltageDifference_Value = Math.Abs(Horizontal_Stop_Marker_Value - Horizontal_Start_Marker_1.Y);
            Horizontal_VoltageDifference_Label.Content = Axis_Scale_Config.Value_SI_Prefix(Horizontal_VoltageDifference_Value, 4) + CH1_Measurement_Unit;
            Horizontal_Marker_1_VoltageDifference_Annotation.Label = "∆ Marker: " + Axis_Scale_Config.Value_SI_Prefix(Horizontal_VoltageDifference_Value, 4) + CH1_Measurement_Unit;

            Horizontal_Stop_Marker_1.Y = Horizontal_Stop_Marker_Value;
            Graph_1.Render();

            Horizontal_Stop_Marker_2.Y = Horizontal_Stop_Marker_Value;
            Graph_2.Render();

            Horizontal_Stop_Marker_3.Y = Horizontal_Stop_Marker_Value;
            Graph_3.Render();

            Horizontal_Stop_Marker_4.Y = Horizontal_Stop_Marker_Value;
            Graph_4.Render();
        }

        private void Add_H_Marker_Click(object sender, RoutedEventArgs e)
        {
            (bool isNum, double value) = Functions.Text_Num(H_Marker_Number.Text, true, false);
            if (isNum == true)
            {
                ScottPlot.Plottable.HLine H_Marker_1 = Graph_1.Plot.AddHorizontalLine(value, label: "H Marker " + Math.Round(value, 2));
                ScottPlot.Plottable.HLine H_Marker_2 = Graph_2.Plot.AddHorizontalLine(value, label: "H Marker " + Math.Round(value, 2));
                ScottPlot.Plottable.HLine H_Marker_3 = Graph_3.Plot.AddHorizontalLine(value, label: "H Marker " + Math.Round(value, 2));
                ScottPlot.Plottable.HLine H_Marker_4 = Graph_4.Plot.AddHorizontalLine(value, label: "H Marker " + Math.Round(value, 2));
                H_Marker_Number.Text = string.Empty;
                Graph_1.Render();
                Graph_2.Render();
                Graph_3.Render();
                Graph_4.Render();

                Graph_1_Horizontal_Markers_Fixed.Add(H_Marker_1);
                Graph_2_Horizontal_Markers_Fixed.Add(H_Marker_2);
                Graph_3_Horizontal_Markers_Fixed.Add(H_Marker_3);
                Graph_4_Horizontal_Markers_Fixed.Add(H_Marker_4);
            }
            else
            {
                H_Marker_Number.Text = string.Empty;
                Insert_Log("Adding a Fixed Horizontal marker failed. Marker value must be a real number.", 1);
            }
        }

        private void Add_V_Marker_Click(object sender, RoutedEventArgs e)
        {
            (bool isNum, double value) = Functions.Text_Num(V_Marker_Number.Text, true, false);
            if (isNum == true)
            {
                ScottPlot.Plottable.VLine V_Marker_1 = Graph_1.Plot.AddVerticalLine(value, label: "V Marker " + Math.Round(value, 2));
                ScottPlot.Plottable.VLine V_Marker_2 = Graph_2.Plot.AddVerticalLine(value, label: "V Marker " + Math.Round(value, 2));
                ScottPlot.Plottable.VLine V_Marker_3 = Graph_3.Plot.AddVerticalLine(value, label: "V Marker " + Math.Round(value, 2));
                ScottPlot.Plottable.VLine V_Marker_4 = Graph_4.Plot.AddVerticalLine(value, label: "V Marker " + Math.Round(value, 2));
                V_Marker_Number.Text = string.Empty;
                Graph_1.Render();
                Graph_2.Render();
                Graph_3.Render();
                Graph_4.Render();

                Graph_1_Vertical_Markers_Fixed.Add(V_Marker_1);
                Graph_2_Vertical_Markers_Fixed.Add(V_Marker_2);
                Graph_3_Vertical_Markers_Fixed.Add(V_Marker_3);
                Graph_4_Vertical_Markers_Fixed.Add(V_Marker_4);
            }
            else
            {
                V_Marker_Number.Text = string.Empty;
                Insert_Log("Adding a Fixed Vertical marker failed. Marker value must be a real number.", 1);
            }
        }

        private void Clear_Horizontal_Markers_Click(object sender, RoutedEventArgs e)
        {
            Clear_All_Horizontal_Markers();
            Insert_Log("All Horizontal Markers have been cleared.", 0);
        }

        private void Clear_All_Horizontal_Markers()
        {
            for (int i = 0; i < Graph_1_Vertical_Markers_Fixed.Count; i++)
            {
                Graph_1.Plot.Remove(plottable: Graph_1_Vertical_Markers_Fixed[i]);
                Graph_2.Plot.Remove(plottable: Graph_2_Vertical_Markers_Fixed[i]);
                Graph_3.Plot.Remove(plottable: Graph_3_Vertical_Markers_Fixed[i]);
                Graph_4.Plot.Remove(plottable: Graph_4_Vertical_Markers_Fixed[i]);
            }
            Graph_1_Vertical_Markers_Fixed.Clear();
            Graph_2_Vertical_Markers_Fixed.Clear();
            Graph_3_Vertical_Markers_Fixed.Clear();
            Graph_4_Vertical_Markers_Fixed.Clear();

            Graph_1.Render();
            Graph_2.Render();
            Graph_3.Render();
            Graph_4.Render();
        }

        private void Clear_Vertical_Markers_Click(object sender, RoutedEventArgs e)
        {
            Clear_All_Vertical_Markers();
            Insert_Log("All Vertical Markers have been cleared.", 0);
        }

        private void Clear_All_Vertical_Markers()
        {
            for (int i = 0; i < Graph_1_Horizontal_Markers_Fixed.Count; i++)
            {
                Graph_1.Plot.Remove(plottable: Graph_1_Horizontal_Markers_Fixed[i]);
                Graph_2.Plot.Remove(plottable: Graph_2_Horizontal_Markers_Fixed[i]);
                Graph_3.Plot.Remove(plottable: Graph_3_Horizontal_Markers_Fixed[i]);
                Graph_4.Plot.Remove(plottable: Graph_4_Horizontal_Markers_Fixed[i]);
            }
            Graph_1_Horizontal_Markers_Fixed.Clear();
            Graph_2_Horizontal_Markers_Fixed.Clear();
            Graph_3_Horizontal_Markers_Fixed.Clear();
            Graph_4_Horizontal_Markers_Fixed.Clear();

            Graph_1.Render();
            Graph_2.Render();
            Graph_3.Render();
            Graph_4.Render();
        }

        private void Clear_All_Markers_Click(object sender, RoutedEventArgs e)
        {
            Clear_All_Horizontal_Markers();
            Clear_All_Vertical_Markers();
            Insert_Log("All Markers have been cleared.", 0);
        }
    }
}
