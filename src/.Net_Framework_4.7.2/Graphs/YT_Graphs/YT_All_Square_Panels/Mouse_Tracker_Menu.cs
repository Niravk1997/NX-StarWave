using MahApps.Metro.Controls;
using ScottPlot;
using System.Windows;
using System.Windows.Input;


namespace AllChannels_YT_Square
{
    public partial class AllChannels_YT_Square_Plotter : MetroWindow
    {
        private ScottPlot.Plottable.Crosshair Mouse_Tracker_1;
        private ScottPlot.Plottable.Text MouseCoordinates_1;

        private ScottPlot.Plottable.Crosshair Mouse_Tracker_2;
        private ScottPlot.Plottable.Text MouseCoordinates_2;

        private ScottPlot.Plottable.Crosshair Mouse_Tracker_3;
        private ScottPlot.Plottable.Text MouseCoordinates_3;

        private ScottPlot.Plottable.Crosshair Mouse_Tracker_4;
        private ScottPlot.Plottable.Text MouseCoordinates_4;


        private bool ShowMouseTracker = false;
        private bool ShowMouseCoordinates = false;

        private void Show_Tracker_Click(object sender, RoutedEventArgs e)
        {
            if (Show_Tracker.IsChecked == true)
            {
                Mouse_Tracker_1 = Graph_1.Plot.AddCrosshair(0, 0);
                Mouse_Tracker_1.VerticalLine.PositionFormatter = x => Axis_Scale_Config.Value_SI_Prefix(x, 0) + "s";
                Mouse_Tracker_1.HorizontalLine.PositionFormatter = y => Axis_Scale_Config.Value_SI_Prefix(y, 0) + CH1_Measurement_Unit;

                Mouse_Tracker_2 = Graph_2.Plot.AddCrosshair(0, 0);
                Mouse_Tracker_2.VerticalLine.PositionFormatter = x => Axis_Scale_Config.Value_SI_Prefix(x, 0) + "s";
                Mouse_Tracker_2.HorizontalLine.PositionFormatter = y => Axis_Scale_Config.Value_SI_Prefix(y, 0) + CH1_Measurement_Unit;

                Mouse_Tracker_3 = Graph_3.Plot.AddCrosshair(0, 0);
                Mouse_Tracker_3.VerticalLine.PositionFormatter = x => Axis_Scale_Config.Value_SI_Prefix(x, 0) + "s";
                Mouse_Tracker_3.HorizontalLine.PositionFormatter = y => Axis_Scale_Config.Value_SI_Prefix(y, 0) + CH1_Measurement_Unit;

                Mouse_Tracker_4 = Graph_4.Plot.AddCrosshair(0, 0);
                Mouse_Tracker_4.VerticalLine.PositionFormatter = x => Axis_Scale_Config.Value_SI_Prefix(x, 0) + "s";
                Mouse_Tracker_4.HorizontalLine.PositionFormatter = y => Axis_Scale_Config.Value_SI_Prefix(y, 0) + CH1_Measurement_Unit;

                Tracker_Color_Selector(2);
                Tracker_Style_Selector(1);
                ShowMouseTracker = true;
                Show_XY_Coordinates_Tracker.IsChecked = true;
                Enable_XY_Coordinates_Tracker();
                Auto_Axis_Enable.IsChecked = false;
                AutoAxis_MenuItem.IsChecked = false;
                Insert_Log("Mouser Tracker has been enabled. Auto Axis is disabled.", 0);
            }
            else
            {
                ShowMouseTracker = false;
                Graph_1.Plot.Remove(plottable: Mouse_Tracker_1);
                Graph_2.Plot.Remove(plottable: Mouse_Tracker_2);
                Graph_3.Plot.Remove(plottable: Mouse_Tracker_3);
                Graph_4.Plot.Remove(plottable: Mouse_Tracker_4);
                if (ShowMouseCoordinates == true)
                {
                    ShowMouseCoordinates = false;
                    Show_XY_Coordinates_Tracker.IsChecked = false;
                    Graph_1.Plot.Remove(plottable: MouseCoordinates_1);
                    Graph_2.Plot.Remove(plottable: MouseCoordinates_2);
                    Graph_3.Plot.Remove(plottable: MouseCoordinates_3);
                    Graph_4.Plot.Remove(plottable: MouseCoordinates_4);
                }
                Auto_Axis_Enable.IsChecked = true;
                AutoAxis_MenuItem.IsChecked = true;
                Insert_Log("Mouser Tracker has been disabled. Auto Axis is enabled.", 0);
            }
            Graph_1.Render();
            Graph_2.Render();
            Graph_3.Render();
            Graph_4.Render();
        }

        private void Show_XY_Coordinates_Tracker_Click(object sender, RoutedEventArgs e)
        {
            Enable_XY_Coordinates_Tracker();
        }

        private void Enable_XY_Coordinates_Tracker()
        {
            if (Show_XY_Coordinates_Tracker.IsChecked == true & ShowMouseTracker == true)
            {
                (double X_MouseCoordinate, double Y_MouseCoordinate) = Graph_1.GetMouseCoordinates();
                MouseCoordinates_1 = Graph_1.Plot.AddText("null, null", X_MouseCoordinate, Y_MouseCoordinate, color: Mouse_Tracker_1.HorizontalLine.Color);
                MouseCoordinates_1.Alignment = Alignment.UpperRight;
                MouseCoordinates_1.FontSize = 16;

                (X_MouseCoordinate, Y_MouseCoordinate) = Graph_2.GetMouseCoordinates();
                MouseCoordinates_2 = Graph_2.Plot.AddText("null, null", X_MouseCoordinate, Y_MouseCoordinate, color: Mouse_Tracker_2.HorizontalLine.Color);
                MouseCoordinates_2.Alignment = Alignment.UpperRight;
                MouseCoordinates_2.FontSize = 16;

                (X_MouseCoordinate, Y_MouseCoordinate) = Graph_3.GetMouseCoordinates();
                MouseCoordinates_3 = Graph_3.Plot.AddText("null, null", X_MouseCoordinate, Y_MouseCoordinate, color: Mouse_Tracker_3.HorizontalLine.Color);
                MouseCoordinates_3.Alignment = Alignment.UpperRight;
                MouseCoordinates_3.FontSize = 16;

                (X_MouseCoordinate, Y_MouseCoordinate) = Graph_4.GetMouseCoordinates();
                MouseCoordinates_4 = Graph_4.Plot.AddText("null, null", X_MouseCoordinate, Y_MouseCoordinate, color: Mouse_Tracker_4.HorizontalLine.Color);
                MouseCoordinates_4.Alignment = Alignment.UpperRight;
                MouseCoordinates_4.FontSize = 16;

                ShowMouseCoordinates = true;
            }
            else
            {
                ShowMouseCoordinates = false;
                Show_XY_Coordinates_Tracker.IsChecked = false;
                Graph_1.Plot.Remove(plottable: MouseCoordinates_1);
                Graph_2.Plot.Remove(plottable: MouseCoordinates_2);
                Graph_3.Plot.Remove(plottable: MouseCoordinates_3);
                Graph_4.Plot.Remove(plottable: MouseCoordinates_4);
            }
            Graph_1.Render();
            Graph_2.Render();
            Graph_3.Render();
            Graph_4.Render();
        }

        private void Graph_MouseMove_1(object sender, MouseEventArgs e)
        {
            if (ShowMouseTracker == true)
            {
                (double X_MouseCoordinate, double Y_MouseCoordinate) = Graph_1.GetMouseCoordinates();

                Mouse_Tracker_1.X = X_MouseCoordinate;
                Mouse_Tracker_1.Y = Y_MouseCoordinate;

                if (ShowMouseCoordinates == true)
                {
                    MouseCoordinates_1.Label = Axis_Scale_Config.Value_SI_Prefix(X_MouseCoordinate, 4) + "s, " + Axis_Scale_Config.Value_SI_Prefix(Y_MouseCoordinate, 4) + CH1_Measurement_Unit;
                    MouseCoordinates_1.X = X_MouseCoordinate;
                    MouseCoordinates_1.Y = Y_MouseCoordinate;
                }
                Graph_1.Render();
            }
        }

        private void Graph_MouseMove_2(object sender, MouseEventArgs e)
        {
            if (ShowMouseTracker == true)
            {
                (double X_MouseCoordinate, double Y_MouseCoordinate) = Graph_2.GetMouseCoordinates();

                Mouse_Tracker_2.X = X_MouseCoordinate;
                Mouse_Tracker_2.Y = Y_MouseCoordinate;

                if (ShowMouseCoordinates == true)
                {
                    MouseCoordinates_2.Label = Axis_Scale_Config.Value_SI_Prefix(X_MouseCoordinate, 4) + "s, " + Axis_Scale_Config.Value_SI_Prefix(Y_MouseCoordinate, 4) + CH1_Measurement_Unit;
                    MouseCoordinates_2.X = X_MouseCoordinate;
                    MouseCoordinates_2.Y = Y_MouseCoordinate;
                }

                Graph_2.Render();
            }
        }

        private void Graph_MouseMove_3(object sender, MouseEventArgs e)
        {
            if (ShowMouseTracker == true)
            {
                (double X_MouseCoordinate, double Y_MouseCoordinate) = Graph_3.GetMouseCoordinates();

                Mouse_Tracker_3.X = X_MouseCoordinate;
                Mouse_Tracker_3.Y = Y_MouseCoordinate;

                if (ShowMouseCoordinates == true)
                {
                    MouseCoordinates_3.Label = Axis_Scale_Config.Value_SI_Prefix(X_MouseCoordinate, 4) + "s, " + Axis_Scale_Config.Value_SI_Prefix(Y_MouseCoordinate, 4) + CH1_Measurement_Unit;
                    MouseCoordinates_3.X = X_MouseCoordinate;
                    MouseCoordinates_3.Y = Y_MouseCoordinate;
                }

                Graph_3.Render();
            }
        }

        private void Graph_MouseMove_4(object sender, MouseEventArgs e)
        {
            if (ShowMouseTracker == true)
            {
                (double X_MouseCoordinate, double Y_MouseCoordinate) = Graph_4.GetMouseCoordinates();

                Mouse_Tracker_4.X = X_MouseCoordinate;
                Mouse_Tracker_4.Y = Y_MouseCoordinate;

                if (ShowMouseCoordinates == true)
                {
                    MouseCoordinates_4.Label = Axis_Scale_Config.Value_SI_Prefix(X_MouseCoordinate, 4) + "s, " + Axis_Scale_Config.Value_SI_Prefix(Y_MouseCoordinate, 4) + CH1_Measurement_Unit;
                    MouseCoordinates_4.X = X_MouseCoordinate;
                    MouseCoordinates_4.Y = Y_MouseCoordinate;
                }

                Graph_4.Render();
            }
        }

        private void Set_Tracker_Color(string Color, string ColorName, int ColorNum)
        {
            if (ShowMouseTracker == true)
            {
                Mouse_Tracker_1.Color = System.Drawing.ColorTranslator.FromHtml(Color);
                Mouse_Tracker_2.Color = System.Drawing.ColorTranslator.FromHtml(Color);
                Mouse_Tracker_3.Color = System.Drawing.ColorTranslator.FromHtml(Color);
                Mouse_Tracker_4.Color = System.Drawing.ColorTranslator.FromHtml(Color);

                if (ShowMouseCoordinates == true)
                {
                    MouseCoordinates_1.Color = System.Drawing.ColorTranslator.FromHtml(Color);
                    MouseCoordinates_2.Color = System.Drawing.ColorTranslator.FromHtml(Color);
                    MouseCoordinates_3.Color = System.Drawing.ColorTranslator.FromHtml(Color);
                    MouseCoordinates_4.Color = System.Drawing.ColorTranslator.FromHtml(Color);
                }
                Graph_1.Render();
                Graph_2.Render();
                Graph_3.Render();
                Graph_4.Render();
                Insert_Log("Mouse Tracker Color set to " + ColorName + ".", 0);
                Tracker_Color_Selector(ColorNum);
            }
            else
            {
                Tracker_Color_Selector(9);
                Insert_Log("Cannot change Mouse Tracker Color. Mouse Tracker is not enabled.", 1);
            }
            Graph_1.Render();
            Graph_2.Render();
            Graph_3.Render();
            Graph_4.Render();
        }

        private void Green_Tracker_Click(object sender, RoutedEventArgs e)
        {
            Set_Tracker_Color("#FF00FF17", "Green", 0);
        }

        private void Blue_Tracker_Click(object sender, RoutedEventArgs e)
        {
            Set_Tracker_Color("#FF00C0FF", "Blue", 1);
        }

        private void Red_Tracker_Click(object sender, RoutedEventArgs e)
        {
            Set_Tracker_Color("#FFFF0000", "Red", 2);
        }

        private void Yellow_Tracker_Click(object sender, RoutedEventArgs e)
        {
            Set_Tracker_Color("#FFFFFF00", "Yellow", 3);
        }

        private void Orange_Tracker_Click(object sender, RoutedEventArgs e)
        {
            Set_Tracker_Color("#FFFF8C00", "Orange", 4);
        }

        private void Black_Tracker_Click(object sender, RoutedEventArgs e)
        {
            Set_Tracker_Color("#FF000000", "Black", 5);
        }

        private void Pink_Tracker_Click(object sender, RoutedEventArgs e)
        {
            Set_Tracker_Color("#FFFF1493", "Pink", 6);
        }

        private void Violet_Tracker_Click(object sender, RoutedEventArgs e)
        {
            Set_Tracker_Color("#FF9400D3", "Violet", 7);
        }

        private void White_Tracker_Click(object sender, RoutedEventArgs e)
        {
            Set_Tracker_Color("#FFFFFFFF", "White", 8);
        }

        private void Tracker_Color_Selector(int Tracker_Color)
        {
            if (Tracker_Color == 0)
            {
                Green_Tracker.IsChecked = true;
            }
            else
            {
                Green_Tracker.IsChecked = false;
            }
            if (Tracker_Color == 1)
            {
                Blue_Tracker.IsChecked = true;
            }
            else
            {
                Blue_Tracker.IsChecked = false;
            }
            if (Tracker_Color == 2)
            {
                Red_Tracker.IsChecked = true;
            }
            else
            {
                Red_Tracker.IsChecked = false;
            }
            if (Tracker_Color == 3)
            {
                Yellow_Tracker.IsChecked = true;
            }
            else
            {
                Yellow_Tracker.IsChecked = false;
            }
            if (Tracker_Color == 4)
            {
                Orange_Tracker.IsChecked = true;
            }
            else
            {
                Orange_Tracker.IsChecked = false;
            }
            if (Tracker_Color == 5)
            {
                Black_Tracker.IsChecked = true;
            }
            else
            {
                Black_Tracker.IsChecked = false;
            }
            if (Tracker_Color == 6)
            {
                Pink_Tracker.IsChecked = true;
            }
            else
            {
                Pink_Tracker.IsChecked = false;
            }
            if (Tracker_Color == 7)
            {
                Violet_Tracker.IsChecked = true;
            }
            else
            {
                Violet_Tracker.IsChecked = false;
            }
            if (Tracker_Color == 8)
            {
                White_Tracker.IsChecked = true;
            }
            else
            {
                White_Tracker.IsChecked = false;
            }
        }

        private void Tracker_Style_Dotted_Click(object sender, RoutedEventArgs e)
        {
            if (ShowMouseTracker == true)
            {
                Mouse_Tracker_1.LineStyle = LineStyle.Dot;
                Mouse_Tracker_2.LineStyle = LineStyle.Dot;
                Mouse_Tracker_3.LineStyle = LineStyle.Dot;
                Mouse_Tracker_4.LineStyle = LineStyle.Dot;
                Insert_Log("Mouse Tracker Style set to Dotted.", 0);
                Tracker_Style_Selector(0);
                Graph_1.Render();
                Graph_2.Render();
                Graph_3.Render();
                Graph_4.Render();
            }
            else
            {
                Insert_Log("Cannot set Mouse Tracker Style. Mouse Tracker not enabled.", 2);
            }
        }

        private void Tracker_Style_Dot_Dash_Click(object sender, RoutedEventArgs e)
        {
            if (ShowMouseTracker == true)
            {
                Mouse_Tracker_1.LineStyle = LineStyle.DashDot;
                Mouse_Tracker_2.LineStyle = LineStyle.DashDot;
                Mouse_Tracker_3.LineStyle = LineStyle.DashDot;
                Mouse_Tracker_4.LineStyle = LineStyle.DashDot;
                Insert_Log("Mouse Tracker Style set to Dot Dash.", 0);
                Tracker_Style_Selector(1);
                Graph_1.Render();
                Graph_2.Render();
                Graph_3.Render();
                Graph_4.Render();
            }
            else
            {
                Insert_Log("Cannot set Mouse Tracker Style. Mouse Tracker not enabled.", 2);
            }
        }

        private void Tracker_Style_Solid_Click(object sender, RoutedEventArgs e)
        {
            if (ShowMouseTracker == true)
            {
                Mouse_Tracker_1.LineStyle = LineStyle.Solid;
                Mouse_Tracker_2.LineStyle = LineStyle.Solid;
                Mouse_Tracker_3.LineStyle = LineStyle.Solid;
                Mouse_Tracker_4.LineStyle = LineStyle.Solid;
                Insert_Log("Mouse Tracker Style set to Solid.", 0);
                Tracker_Style_Selector(2);
                Graph_1.Render();
                Graph_2.Render();
                Graph_3.Render();
                Graph_4.Render();
            }
            else
            {
                Insert_Log("Cannot set Mouse Tracker Style. Mouse Tracker not enabled.", 2);
            }
        }

        private void Tracker_Style_Selector(int Style)
        {
            if (Style == 0)
            {
                Tracker_Style_Dotted.IsChecked = true;
            }
            else
            {
                Tracker_Style_Dotted.IsChecked = false;
            }
            if (Style == 1)
            {
                Tracker_Style_Dot_Dash.IsChecked = true;
            }
            else
            {
                Tracker_Style_Dot_Dash.IsChecked = false;
            }
            if (Style == 2)
            {
                Tracker_Style_Solid.IsChecked = true;
            }
            else
            {
                Tracker_Style_Solid.IsChecked = false;
            }
        }
    }
}
