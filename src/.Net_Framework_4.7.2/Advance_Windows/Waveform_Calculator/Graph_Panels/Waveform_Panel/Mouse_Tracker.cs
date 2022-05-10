using ScottPlot;
using System.Windows.Controls;
using System.Windows.Input;

namespace Waveform_Panel
{
    public partial class Waveform_Panel : UserControl
    {
        private ScottPlot.Plottable.Crosshair Mouse_Tracker;
        private ScottPlot.Plottable.Text MouseCoordinates;
        private bool ShowMouseTracker = false;

        private void Show_Mouse_Tracker()
        {
            if (MouseTrackerMenuItem.IsChecked)
            {
                Mouse_Tracker = Graph.Plot.AddCrosshair(0, 0);
                Mouse_Tracker.VerticalLine.PositionFormatter = x => Axis_Scale_Config.Value_SI_Prefix(x, 0) + X_Axis_units;
                Mouse_Tracker.HorizontalLine.PositionFormatter = y => Axis_Scale_Config.Value_SI_Prefix(y, 0) + Y_Axis_Units;

                (double X_MouseCoordinate, double Y_MouseCoordinate) = Graph.GetMouseCoordinates();
                MouseCoordinates = Graph.Plot.AddText("null, null", X_MouseCoordinate, Y_MouseCoordinate, color: System.Drawing.Color.Red);
                MouseCoordinates.Alignment = Alignment.LowerLeft;
                MouseCoordinates.FontSize = 16;

                ShowMouseTracker = true;
                Graph.Render();
            }
            else
            {
                ShowMouseTracker = false;
                Graph.Plot.Remove(plottable: Mouse_Tracker);
                Graph.Plot.Remove(plottable: MouseCoordinates);
                Graph.Render();
            }
        }

        private void Graph_MouseMove(object sender, MouseEventArgs e)
        {
            if (ShowMouseTracker == true)
            {
                (double X_MouseCoordinate, double Y_MouseCoordinate) = Graph.GetMouseCoordinates();

                Mouse_Tracker.X = X_MouseCoordinate;
                Mouse_Tracker.Y = Y_MouseCoordinate;

                MouseCoordinates.X = X_MouseCoordinate;
                MouseCoordinates.Y = Y_MouseCoordinate;
                MouseCoordinates.Label = Axis_Scale_Config.Value_SI_Prefix(X_MouseCoordinate, 3) + X_Axis_units + ", " + Axis_Scale_Config.Value_SI_Prefix(Y_MouseCoordinate, 3) + Y_Axis_Units;

                Graph.Render();
            }
        }
    }
}
