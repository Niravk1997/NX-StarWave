using MahApps.Metro.Controls;
using System;
using System.Windows;

namespace Measurement_Plot
{
    public partial class Measurement_Plot_Window : MetroWindow
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

        private int Min_DateTime_Value = -647412;
        private int Max_DateTime_Value = 2593105;
        private int DateTime_Round_Value = 4;

        private void Add_Clear_Vertical_Markers()
        {
            if (Vertical_Markers_MenuItem.IsChecked == true)
            {
                (double X_MouseCoordinate, double Y_MouseCoordinate) = Graph.GetMouseCoordinates();
                Vertical_Start_Marker = Graph.Plot.AddVerticalLine(X_MouseCoordinate, color: System.Drawing.ColorTranslator.FromHtml("#FF00950E"), style: ScottPlot.LineStyle.DashDot, label: "V Marker");
                Vertical_Start_Marker.DragEnabled = true;
                Vertical_Start_Marker.Dragged += Vertical_Marker_Start_Dragged_Event;

                double Vertical_Start_Marker_Value = Vertical_Start_Marker.X;
                string DateTime_Vertical_Start_Marker_Value = "Limit Reached";
                if (Vertical_Start_Marker_Value > Min_DateTime_Value & Vertical_Start_Marker_Value < Max_DateTime_Value)
                {
                    DateTime_Vertical_Start_Marker_Value = DateTime.FromOADate(Vertical_Start_Marker_Value).ToString("yyyy-MM-dd h:mm:ss.fff tt");
                }
                Vertical_Start_Marker_Annotation = Graph.Plot.AddAnnotation("V Marker: " + DateTime_Vertical_Start_Marker_Value, 5, 5);
                Vertical_Start_Marker_Annotation.Font.Size = 14;
                Vertical_Start_Marker_Annotation.Shadow = false;
                Vertical_Start_Marker_Annotation.BackgroundColor = System.Drawing.ColorTranslator.FromHtml("#00FFFFFF");
                Vertical_Start_Marker_Annotation.BorderColor = System.Drawing.ColorTranslator.FromHtml("#00FFFFFF");
                Vertical_Start_Marker_Annotation.Font.Color = System.Drawing.ColorTranslator.FromHtml("#FF00950E");


                Vertical_Stop_Marker = Graph.Plot.AddVerticalLine(X_MouseCoordinate, color: System.Drawing.ColorTranslator.FromHtml("#FFFF0000"), style: ScottPlot.LineStyle.DashDot, label: "V Marker");
                Vertical_Stop_Marker.DragEnabled = true;
                Vertical_Stop_Marker.Dragged += Vertical_Marker_Stop_Dragged_Event;
                double Vertical_Stop_Marker_Value = Vertical_Stop_Marker.X;
                string DateTime_Vertical_Stop_Marker_Value = "Limit Reached";
                if (Vertical_Stop_Marker_Value > Min_DateTime_Value & Vertical_Stop_Marker_Value < Max_DateTime_Value)
                {
                    DateTime_Vertical_Stop_Marker_Value = DateTime.FromOADate(Vertical_Stop_Marker_Value).ToString("yyyy-MM-dd h:mm:ss.fff tt");
                }
                Vertical_Stop_Marker_Annotation = Graph.Plot.AddAnnotation("V Marker: " + DateTime_Vertical_Stop_Marker_Value, 5, 20);
                Vertical_Stop_Marker_Annotation.Font.Size = 14;
                Vertical_Stop_Marker_Annotation.Shadow = false;
                Vertical_Stop_Marker_Annotation.BackgroundColor = System.Drawing.ColorTranslator.FromHtml("#00FFFFFF");
                Vertical_Stop_Marker_Annotation.BorderColor = System.Drawing.ColorTranslator.FromHtml("#00FFFFFF");
                Vertical_Stop_Marker_Annotation.Font.Color = System.Drawing.ColorTranslator.FromHtml("#FFFF0000");

                Vertical_Marker_TimeDifference_Annotation = Graph.Plot.AddAnnotation("∆ Time: " + Axis_Scale_Config.Value_SI_Prefix((Vertical_Stop_Marker_Value - Vertical_Start_Marker_Value), 4) + "seconds", 5, 35);
                Vertical_Marker_TimeDifference_Annotation.Font.Size = 14;
                Vertical_Marker_TimeDifference_Annotation.Shadow = false;
                Vertical_Marker_TimeDifference_Annotation.BackgroundColor = System.Drawing.ColorTranslator.FromHtml("#00FFFFFF");
                Vertical_Marker_TimeDifference_Annotation.BorderColor = System.Drawing.ColorTranslator.FromHtml("#00FFFFFF");
                Vertical_Marker_TimeDifference_Annotation.Font.Color = System.Drawing.ColorTranslator.FromHtml("#FF1E90FF");
                TimeDifference_Label.Content = Axis_Scale_Config.Value_SI_Prefix(Math.Abs(Vertical_Stop_Marker_Value - Vertical_Start_Marker_Value), 4) + "seconds";

                Vertical_StartTime_Label.Content = DateTime_Vertical_Start_Marker_Value;
                Vertical_StopTime_Label.Content = DateTime_Vertical_Stop_Marker_Value;

                Graph.Render();
            }
            else
            {
                Vertical_Markers_MenuItem.IsChecked = false;
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
            Graph.Plot.Remove(plottable: Vertical_Marker_TimeDifference_Annotation);
            Vertical_StartTime_Label.Content = "null";
            Vertical_StopTime_Label.Content = "null";
            TimeDifference_Label.Content = "null";
        }

        private void Vertical_Marker_Start_Dragged_Event(object sender, EventArgs eventArgs)
        {
            double Vertical_Start_Marker_Value = Vertical_Start_Marker.X;
            double Vertical_Stop_Marker_Value = Vertical_Stop_Marker.X;
            if ((Vertical_Start_Marker_Value > Min_DateTime_Value & Vertical_Start_Marker_Value < Max_DateTime_Value) & (Vertical_Stop_Marker_Value > Min_DateTime_Value & Vertical_Stop_Marker_Value < Max_DateTime_Value))
            {
                DateTime Vertical_Start_DateTime = DateTime.FromOADate(Vertical_Start_Marker_Value);
                DateTime Vertical_Stop_DateTime = DateTime.FromOADate(Vertical_Stop_Marker_Value);
                TimeSpan Duration = Vertical_Stop_DateTime.Subtract(Vertical_Start_DateTime);

                string Vertical_Start_DateTime_string = Vertical_Start_DateTime.ToString("yyyy-MM-dd h:mm:ss.fff tt");
                Vertical_Start_Marker_Annotation.Label = "V Marker: " + Vertical_Start_DateTime_string;
                Vertical_StartTime_Label.Content = Vertical_Start_DateTime_string;

                if (Duration.TotalSeconds >= -60 & Duration.TotalSeconds <= 60)
                {
                    string Value = Math.Round(Math.Abs(Duration.TotalSeconds), DateTime_Round_Value).ToString();
                    Vertical_Marker_TimeDifference_Annotation.Label = "∆ Time: " + Value + " seconds";
                    TimeDifference_Label.Content = Value + " seconds";
                }
                else if (Duration.TotalMinutes >= -60 & Duration.TotalMinutes <= 60)
                {
                    string Value = Math.Round(Math.Abs(Duration.TotalMinutes), DateTime_Round_Value).ToString();
                    Vertical_Marker_TimeDifference_Annotation.Label = "∆ Time: " + Value + " minutes";
                    TimeDifference_Label.Content = Value + " minutes";
                }
                else if (Duration.TotalHours >= -24 & Duration.TotalHours <= 24)
                {
                    string Value = Math.Round(Math.Abs(Duration.TotalHours), DateTime_Round_Value).ToString();
                    Vertical_Marker_TimeDifference_Annotation.Label = "∆ Time: " + Value + " hours";
                    TimeDifference_Label.Content = Value + " hours";
                }
                else
                {
                    string Value = Math.Round(Math.Abs(Duration.TotalDays), DateTime_Round_Value).ToString();
                    Vertical_Marker_TimeDifference_Annotation.Label = "∆ Time: " + Value + " days";
                    TimeDifference_Label.Content = Value + " days";
                }
            }
            else
            {
                Vertical_Start_Marker_Annotation.Label = "V Marker: " + "Limit Reached";
                Vertical_StartTime_Label.Content = "Limit Reached";

                Vertical_Marker_TimeDifference_Annotation.Label = "∆ Time: " + "Limit Reached";
                TimeDifference_Label.Content = "Limit Reached";
            }
        }

        private void Vertical_Marker_Stop_Dragged_Event(object sender, EventArgs eventArgs)
        {
            double Vertical_Start_Marker_Value = Vertical_Start_Marker.X;
            double Vertical_Stop_Marker_Value = Vertical_Stop_Marker.X;
            if ((Vertical_Start_Marker_Value > Min_DateTime_Value & Vertical_Start_Marker_Value < Max_DateTime_Value) & (Vertical_Stop_Marker_Value > Min_DateTime_Value & Vertical_Stop_Marker_Value < Max_DateTime_Value))
            {
                DateTime Vertical_Start_DateTime = DateTime.FromOADate(Vertical_Start_Marker_Value);
                DateTime Vertical_Stop_DateTime = DateTime.FromOADate(Vertical_Stop_Marker_Value);
                TimeSpan Duration = Vertical_Stop_DateTime.Subtract(Vertical_Start_DateTime);

                string Vertical_Stop_DateTime_string = Vertical_Stop_DateTime.ToString("yyyy-MM-dd h:mm:ss.fff tt");
                Vertical_Stop_Marker_Annotation.Label = "V Marker: " + Vertical_Stop_DateTime_string;
                Vertical_StopTime_Label.Content = Vertical_Stop_DateTime_string;

                if (Duration.TotalSeconds >= -60 & Duration.TotalSeconds <= 60)
                {
                    string Value = Math.Round(Math.Abs(Duration.TotalSeconds), DateTime_Round_Value).ToString();
                    Vertical_Marker_TimeDifference_Annotation.Label = "∆ Time: " + Value + " seconds";
                    TimeDifference_Label.Content = Value + " seconds";
                }
                else if (Duration.TotalMinutes >= -60 & Duration.TotalMinutes <= 60)
                {
                    string Value = Math.Round(Math.Abs(Duration.TotalMinutes), DateTime_Round_Value).ToString();
                    Vertical_Marker_TimeDifference_Annotation.Label = "∆ Time: " + Value + " minutes";
                    TimeDifference_Label.Content = Value + " minutes";
                }
                else if (Duration.TotalHours >= -24 & Duration.TotalHours <= 24)
                {
                    string Value = Math.Round(Math.Abs(Duration.TotalHours), DateTime_Round_Value).ToString();
                    Vertical_Marker_TimeDifference_Annotation.Label = "∆ Time: " + Value + " hours";
                    TimeDifference_Label.Content = Value + " hours";
                }
                else
                {
                    string Value = Math.Round(Math.Abs(Duration.TotalDays), DateTime_Round_Value).ToString();
                    Vertical_Marker_TimeDifference_Annotation.Label = "∆ Time: " + Value + " days";
                    TimeDifference_Label.Content = Value + " days";
                }
            }
            else
            {
                Vertical_Stop_Marker_Annotation.Label = "V Marker: " + "Limit Reached";
                Vertical_StopTime_Label.Content = "Limit Reached";

                Vertical_Marker_TimeDifference_Annotation.Label = "∆ Time: " + "Limit Reached";
                TimeDifference_Label.Content = "Limit Reached";
            }
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
                Horizontal_Start_Marker_Annotation = Graph.Plot.AddAnnotation("H Marker: " + Axis_Scale_Config.Value_SI_Prefix(Horizontal_Start_Marker_Value, 4) + Measurement_Unit, 5, 55);
                Horizontal_Start_Marker_Annotation.Font.Size = 14;
                Horizontal_Start_Marker_Annotation.Shadow = false;
                Horizontal_Start_Marker_Annotation.BackgroundColor = System.Drawing.ColorTranslator.FromHtml("#00FFFFFF");
                Horizontal_Start_Marker_Annotation.BorderColor = System.Drawing.ColorTranslator.FromHtml("#00FFFFFF");
                Horizontal_Start_Marker_Annotation.Font.Color = System.Drawing.ColorTranslator.FromHtml("#FF00950E");

                Horizontal_Stop_Marker = Graph.Plot.AddHorizontalLine(Y_MouseCoordinate, color: System.Drawing.ColorTranslator.FromHtml("#FFFF0000"), style: ScottPlot.LineStyle.DashDot, label: "H Marker");
                Horizontal_Stop_Marker.DragEnabled = true;
                Horizontal_Stop_Marker.Dragged += Horizontal_Marker_Stop_Dragged_Event;
                double Horizontal_Stop_Marker_Value = Horizontal_Stop_Marker.Y;
                Horizontal_Stop_Marker_Annotation = Graph.Plot.AddAnnotation("H Marker: " + Axis_Scale_Config.Value_SI_Prefix(Horizontal_Stop_Marker_Value, 4) + Measurement_Unit, 5, 70);
                Horizontal_Stop_Marker_Annotation.Font.Size = 14;
                Horizontal_Stop_Marker_Annotation.Shadow = false;
                Horizontal_Stop_Marker_Annotation.BackgroundColor = System.Drawing.ColorTranslator.FromHtml("#00FFFFFF");
                Horizontal_Stop_Marker_Annotation.BorderColor = System.Drawing.ColorTranslator.FromHtml("#00FFFFFF");
                Horizontal_Stop_Marker_Annotation.Font.Color = System.Drawing.ColorTranslator.FromHtml("#FFFF0000");

                Horizontal_Marker_VoltageDifference_Annotation = Graph.Plot.AddAnnotation("∆ Marker: " + Axis_Scale_Config.Value_SI_Prefix((Horizontal_Stop_Marker_Value - Horizontal_Start_Marker_Value), 4) + Measurement_Unit, 5, 85);
                Horizontal_Marker_VoltageDifference_Annotation.Font.Size = 14;
                Horizontal_Marker_VoltageDifference_Annotation.Shadow = false;
                Horizontal_Marker_VoltageDifference_Annotation.BackgroundColor = System.Drawing.ColorTranslator.FromHtml("#00FFFFFF");
                Horizontal_Marker_VoltageDifference_Annotation.BorderColor = System.Drawing.ColorTranslator.FromHtml("#00FFFFFF");
                Horizontal_Marker_VoltageDifference_Annotation.Font.Color = System.Drawing.ColorTranslator.FromHtml("#FF1E90FF");
                Horizontal_VoltageDifference_Label.Content = Axis_Scale_Config.Value_SI_Prefix(Math.Abs(Horizontal_Stop_Marker_Value - Horizontal_Start_Marker_Value), 4) + Measurement_Unit;

                Horizontal_Green_Label.Content = Axis_Scale_Config.Value_SI_Prefix(Horizontal_Start_Marker.Y, 4) + Measurement_Unit;
                Horizontal_Red_Label.Content = Axis_Scale_Config.Value_SI_Prefix(Horizontal_Stop_Marker.Y, 4) + Measurement_Unit;
                Graph.Render();
            }
            else
            {
                Horizontal_Markers_MenuItem.IsChecked = false;
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
            Graph.Plot.Remove(plottable: Horizontal_Marker_VoltageDifference_Annotation);
            Horizontal_Green_Label.Content = "null";
            Horizontal_Red_Label.Content = "null";
            Horizontal_VoltageDifference_Label.Content = "null";
        }

        private void Horizontal_Marker_Start_Dragged_Event(object sender, EventArgs eventArgs)
        {
            double Horizontal_Start_Marker_Value = Horizontal_Start_Marker.Y;
            Horizontal_Start_Marker_Annotation.Label = "H Marker: " + Axis_Scale_Config.Value_SI_Prefix(Horizontal_Start_Marker_Value, 4) + Measurement_Unit;
            Horizontal_Green_Label.Content = Axis_Scale_Config.Value_SI_Prefix(Horizontal_Start_Marker_Value, 4) + Measurement_Unit;

            double Horizontal_VoltageDifference_Value = Math.Abs(Horizontal_Stop_Marker.Y - Horizontal_Start_Marker_Value);
            Horizontal_VoltageDifference_Label.Content = Axis_Scale_Config.Value_SI_Prefix(Horizontal_VoltageDifference_Value, 4) + Measurement_Unit;
            Horizontal_Marker_VoltageDifference_Annotation.Label = "∆ Marker: " + Axis_Scale_Config.Value_SI_Prefix(Horizontal_VoltageDifference_Value, 4) + Measurement_Unit;
        }

        private void Horizontal_Marker_Stop_Dragged_Event(object sender, EventArgs eventArgs)
        {
            double Horizontal_Stop_Marker_Value = Horizontal_Stop_Marker.Y;
            Horizontal_Stop_Marker_Annotation.Label = "H Marker: " + Axis_Scale_Config.Value_SI_Prefix(Horizontal_Stop_Marker.Y, 4) + Measurement_Unit;
            Horizontal_Red_Label.Content = Axis_Scale_Config.Value_SI_Prefix(Horizontal_Stop_Marker_Value, 4) + Measurement_Unit;

            double Horizontal_VoltageDifference_Value = Math.Abs(Horizontal_Stop_Marker_Value - Horizontal_Start_Marker.Y);
            Horizontal_VoltageDifference_Label.Content = Axis_Scale_Config.Value_SI_Prefix(Horizontal_VoltageDifference_Value, 4) + Measurement_Unit;
            Horizontal_Marker_VoltageDifference_Annotation.Label = "∆ Marker: " + Axis_Scale_Config.Value_SI_Prefix(Horizontal_VoltageDifference_Value, 4) + Measurement_Unit;
        }

        private void Clear_Horizontal_Markers_Click(object sender, RoutedEventArgs e)
        {
            Clear_All_Horizontal_Markers();
            Insert_Log("All Horizontal Markers have been cleared.", 0);
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
            Insert_Log("All Vertical Markers have been cleared.", 0);
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
            Insert_Log("All Markers have been cleared.", 0);
        }
    }
}
