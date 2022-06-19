using MahApps.Metro.Controls;
using ScottPlot;
using System;
using System.Windows;
using System.Windows.Controls;

namespace Channel_DataLogger
{
    public partial class CH_DataLog_Graph_Window : MetroWindow
    {
        private WpfPlot Zoom_Control_Plot = null;
        private ScottPlot.Plottable.Polygon Zoom_Window = null;
        private ScottPlot.Plottable.SignalPlot Zoom_Waveform_Curve = null;

        private ScottPlot.Plottable.VLine Zoom_Window_Draggable_Line_Left = null;
        private ScottPlot.Plottable.VLine Zoom_Window_Draggable_Line_Right = null;

        private bool Zoom_Control_Window_IsEnabled = false;

        private void Enable_Zoom_Control()
        {
            Zoom_Control_Plot = new WpfPlot();
            Zoom_Control_Plot.Plot.Frameless(true);
            Zoom_Control_Plot.RightClicked -= Zoom_Control_Plot.DefaultRightClickEvent;

            if (ControlzEx.Theming.ThemeManager.Current.DetectTheme().BaseColorScheme.Equals("Dark"))
            {
                Zoom_Control_Plot.Plot.Style(ScottPlot.Style.Black);
                Zoom_Control_Plot.Plot.YAxis.Color(color: System.Drawing.ColorTranslator.FromHtml("#FFFFFFFF"));
                Zoom_Control_Plot.Plot.XAxis.Color(color: System.Drawing.ColorTranslator.FromHtml("#FFFFFFFF"));
            }

            DataLog_Grid.Children.Add(Zoom_Control_Plot);
            Zoom_Control_Plot.SetValue(Grid.RowProperty, 1);
            Zoom_Control_Window.Height = new GridLength(0.3, GridUnitType.Star);
        }

        private void Disable_Zoom_Control()
        {
            Zoom_Window_Draggable_Line_Left.Dragged -= Zoom_Window_Draggable_Line_Dragged_Left;
            Zoom_Window_Draggable_Line_Right.Dragged -= Zoom_Window_Draggable_Line_Dragged_Right;
            Zoom_Control_Plot.Plot.Clear();

            DataLog_Grid.Children.Remove(Zoom_Control_Plot);
            Zoom_Control_Window.Height = new GridLength(0);
            Zoom_Window = null;
            Zoom_Waveform_Curve = null;
            Zoom_Control_Plot = null;
        }

        private void Initialize_Zoom_Window_Plot()
        {
            AxisLimits Graph_Axis_Limits = Graph.Plot.GetAxisLimits(0, 0);

            Zoom_Window = Zoom_Control_Plot.Plot.AddPolygon(new double[] { Graph_Axis_Limits.XMin, Graph_Axis_Limits.XMin, Graph_Axis_Limits.XMax, Graph_Axis_Limits.XMax }, new double[] { Graph_Axis_Limits.YMin, Graph_Axis_Limits.YMax, Graph_Axis_Limits.YMax, Graph_Axis_Limits.YMin });
            Zoom_Window.Fill = false;
            Zoom_Window.LineWidth = 2;
            Zoom_Window.LineColor = System.Drawing.Color.Red;

            Zoom_Window_Draggable_Line_Left = Zoom_Control_Plot.Plot.AddVerticalLine(Graph_Axis_Limits.XMin, width: 1, color: System.Drawing.Color.Transparent, style: LineStyle.None, label: null);
            Zoom_Window_Draggable_Line_Left.DragEnabled = true;
            Zoom_Window_Draggable_Line_Left.Dragged += Zoom_Window_Draggable_Line_Dragged_Left;

            Zoom_Window_Draggable_Line_Right = Zoom_Control_Plot.Plot.AddVerticalLine(Graph_Axis_Limits.XMax, width: 1, color: System.Drawing.Color.Transparent, style: LineStyle.None, label: null);
            Zoom_Window_Draggable_Line_Right.DragEnabled = true;
            Zoom_Window_Draggable_Line_Right.Dragged += Zoom_Window_Draggable_Line_Dragged_Right;
        }

        private void Zoom_Window_Draggable_Line_Dragged_Left(object sender, EventArgs e)
        {
            AxisLimits Graph_Axis_Limits = Graph.Plot.GetAxisLimits(0, 0);
            double Left_Zoom_Value = Zoom_Window_Draggable_Line_Left.X;
            double Right_Zoom_Value = Zoom_Window_Draggable_Line_Right.X;
            if (Left_Zoom_Value < Right_Zoom_Value)
            {
                Graph.Plot.SetAxisLimitsX(xMin: Left_Zoom_Value, Graph_Axis_Limits.XMax);
            }
            else
            {
                Zoom_Window_Draggable_Line_Left.X = Graph_Axis_Limits.XMin;
            }
            Graph.Refresh();
        }

        private void Zoom_Window_Draggable_Line_Dragged_Right(object sender, EventArgs e)
        {
            AxisLimits Graph_Axis_Limits = Graph.Plot.GetAxisLimits(0, 0);
            double Left_Zoom_Value = Zoom_Window_Draggable_Line_Left.X;
            double Right_Zoom_Value = Zoom_Window_Draggable_Line_Right.X;
            if (Right_Zoom_Value > Left_Zoom_Value)
            {
                Graph.Plot.SetAxisLimitsX(xMax: Right_Zoom_Value, xMin: Graph_Axis_Limits.XMin);
            }
            else
            {
                Zoom_Window_Draggable_Line_Right.X = Graph_Axis_Limits.XMax;
            }
            Graph.Refresh();
        }

        private void Initialize_Zoom_Waveform_Curve()
        {
            Zoom_Waveform_Curve = Zoom_Control_Plot.Plot.AddSignal(Measurement_Data, color: Measurement_Plot.Color, label: null);
            Zoom_Waveform_Curve.MarkerSize = 0;
            Zoom_Waveform_Curve.MaxRenderIndex = Measurement_Count;
        }

        private void Enable_Zoom_Window_Control_Click(object sender, RoutedEventArgs e)
        {
            if (Zoom_Control_Window_MenuItem_IsEnabled)
            {
                Enable_Zoom_Control();
                Initialize_Zoom_Waveform_Curve();
                Initialize_Zoom_Window_Plot();
                Zoom_Control_Plot.Plot.AxisAuto();
                Zoom_Control_Plot.Refresh();
                Zoom_Control_Window_IsEnabled = true;
            }
            else
            {
                Zoom_Control_Window_IsEnabled = false;
                Disable_Zoom_Control();
            }
        }

        private void Graph_AxesChanged_Event(object sender, EventArgs e)
        {
            if (Zoom_Control_Window_IsEnabled)
            {
                AxisLimits Graph_Axis_Limits = Graph.Plot.GetAxisLimits(0, 0);

                Zoom_Window.Xs = new double[] { Graph_Axis_Limits.XMin, Graph_Axis_Limits.XMin, Graph_Axis_Limits.XMax, Graph_Axis_Limits.XMax };
                Zoom_Window.Ys = new double[] { Graph_Axis_Limits.YMin, Graph_Axis_Limits.YMax, Graph_Axis_Limits.YMax, Graph_Axis_Limits.YMin };
                Zoom_Window_Draggable_Line_Left.X = Graph_Axis_Limits.XMin;
                Zoom_Window_Draggable_Line_Right.X = Graph_Axis_Limits.XMax;
                Zoom_Control_Plot.Plot.AxisAuto();
                Zoom_Control_Plot.Refresh();
            }
        }

        private void Set_Zoom_Waveform_Color()
        {
            if (Zoom_Waveform_Curve != null & Zoom_Control_Window_IsEnabled)
            {
                Zoom_Waveform_Curve.Color = Measurement_Plot.Color;
                Zoom_Control_Plot.Refresh();
            }
        }
    }
}
