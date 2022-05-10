using MahApps.Metro.Controls;
using ScottPlot;
using System.Windows;
using System.Windows.Controls;

namespace AllChannels_YT_Stack
{
    public partial class AllChannels_YT_Stack_Plotter : MetroWindow
    {
        private void Graph_Orientation_1_Click(object sender, RoutedEventArgs e)
        {
            Graph_1.SetValue(Grid.RowProperty, 0);
            Graph_2.SetValue(Grid.RowProperty, 2);
            Graph_3.SetValue(Grid.RowProperty, 4);
            Graph_4.SetValue(Grid.RowProperty, 6);

            Graph_Orientation_1.IsChecked = true;
            Graph_Orientation_2.IsChecked = false;
        }

        private void Graph_Orientation_2_Click(object sender, RoutedEventArgs e)
        {
            Graph_1.SetValue(Grid.RowProperty, 6);
            Graph_2.SetValue(Grid.RowProperty, 4);
            Graph_3.SetValue(Grid.RowProperty, 2);
            Graph_4.SetValue(Grid.RowProperty, 0);

            Graph_Orientation_1.IsChecked = false;
            Graph_Orientation_2.IsChecked = true;
        }

        private void Force_Auto_Axis_Click(object sender, RoutedEventArgs e)
        {
            Graph_1.Plot.AxisAuto();
            Graph_1.Render();
            Graph_2.Plot.AxisAuto();
            Graph_2.Render();
            Graph_3.Plot.AxisAuto();
            Graph_3.Render();
            Graph_4.Plot.AxisAuto();
            Graph_4.Render();
            Insert_Log("Graph's Force Auto-Axis method called.", 0);
        }

        private void Auto_Axis_Enable_Click(object sender, RoutedEventArgs e)
        {
            if (Auto_Axis_Enable.IsChecked == true)
            {
                AutoAxis_MenuItem.IsChecked = true;
                Insert_Log("Graph's Auto-Axis feature is enabled.", 0);
            }
            else
            {
                AutoAxis_MenuItem.IsChecked = false;
                Insert_Log("Graph's Auto-Axis feature is disabled.", 2);
            }
        }

        private void Y_Axis_Text_Button_Click(object sender, RoutedEventArgs e)
        {
            Graph_1.Plot.YAxis.Label(Y_Axis_Set_Text.Text);
            Graph_1.Render();
            Insert_Log("Graph's Y-Axis Label changed to " + Y_Axis_Set_Text.Text, 0);
            Y_Axis_Set_Text.Text = string.Empty;
        }

        private void X_Axis_Minor_Grid_Click(object sender, RoutedEventArgs e)
        {
            if (X_Axis_Minor_Grid.IsChecked == true)
            {
                Graph_1.Plot.XAxis.MinorGrid(true);
                Graph_1.Render();
                Graph_2.Plot.XAxis.MinorGrid(true);
                Graph_2.Render();
                Graph_3.Plot.XAxis.MinorGrid(true);
                Graph_3.Render();
                Graph_4.Plot.XAxis.MinorGrid(true);
                Graph_4.Render();
                Insert_Log("Graph's X-Axis Minor Grid is enabled.", 0);
            }
            else
            {
                Graph_1.Plot.XAxis.MinorGrid(false);
                Graph_1.Render();
                Graph_2.Plot.XAxis.MinorGrid(false);
                Graph_2.Render();
                Graph_3.Plot.XAxis.MinorGrid(false);
                Graph_3.Render();
                Graph_4.Plot.XAxis.MinorGrid(false);
                Graph_4.Render();
                Insert_Log("Graph's X-Axis Minor Grid is disabled.", 0);
            }
        }

        private void X_Axis_Tick_Ruler_Mode_Click(object sender, RoutedEventArgs e)
        {
            if (X_Axis_Tick_Ruler_Mode.IsChecked == true)
            {
                Graph_1.Plot.XAxis.RulerMode(true);
                Graph_1.Render();
                Graph_2.Plot.XAxis.RulerMode(true);
                Graph_2.Render();
                Graph_3.Plot.XAxis.RulerMode(true);
                Graph_3.Render();
                Graph_4.Plot.XAxis.RulerMode(true);
                Graph_4.Render();
                Insert_Log("Graph's X-Axis Ruler Mode is Enabled.", 0);
            }
            else
            {
                Graph_1.Plot.XAxis.RulerMode(false);
                Graph_1.Render();
                Graph_2.Plot.XAxis.RulerMode(false);
                Graph_2.Render();
                Graph_3.Plot.XAxis.RulerMode(false);
                Graph_3.Render();
                Graph_4.Plot.XAxis.RulerMode(false);
                Graph_4.Render();
                Insert_Log("Graph's X-Axis Ruler Mode is Disabled.", 0);
            }
        }

        private void Y_Axis_Show_Click(object sender, RoutedEventArgs e)
        {
            if (Y_Axis_Show.IsChecked == true)
            {
                Graph_1.Plot.YAxis.Ticks(true);
                Graph_1.Render();
                Graph_2.Plot.YAxis.Ticks(true);
                Graph_2.Render();
                Graph_3.Plot.YAxis.Ticks(true);
                Graph_3.Render();
                Graph_4.Plot.YAxis.Ticks(true);
                Graph_4.Render();
                Insert_Log("Graph's Y-Axis Ticks have been enabled.", 0);
            }
            else
            {
                Graph_1.Plot.YAxis.Ticks(false);
                Graph_1.Render();
                Graph_2.Plot.YAxis.Ticks(false);
                Graph_2.Render();
                Graph_3.Plot.YAxis.Ticks(false);
                Graph_3.Render();
                Graph_4.Plot.YAxis.Ticks(false);
                Graph_4.Render();
                Insert_Log("Graph's Y-Axis Ticks have been disabled.", 0);
            }
        }

        private void Y_Axis_Tick_Rotation_0_Click(object sender, RoutedEventArgs e)
        {
            Graph_1.Plot.YAxis.TickLabelStyle(rotation: 0);
            Graph_1.Render();
            Graph_2.Plot.YAxis.TickLabelStyle(rotation: 0);
            Graph_2.Render();
            Graph_3.Plot.YAxis.TickLabelStyle(rotation: 0);
            Graph_3.Render();
            Graph_4.Plot.YAxis.TickLabelStyle(rotation: 0);
            Graph_4.Render();
            Insert_Log("Graph's Y-Axis Ticks rotated to 0°", 0);
            Y_Axis_Tick_Rotation_0.IsChecked = true;
            Y_Axis_Tick_Rotation_45.IsChecked = false;
        }

        private void Y_Axis_Tick_Rotation_45_Click(object sender, RoutedEventArgs e)
        {
            Graph_1.Plot.YAxis.TickLabelStyle(rotation: 45);
            Graph_1.Render();
            Graph_2.Plot.YAxis.TickLabelStyle(rotation: 45);
            Graph_2.Render();
            Graph_3.Plot.YAxis.TickLabelStyle(rotation: 45);
            Graph_3.Render();
            Graph_4.Plot.YAxis.TickLabelStyle(rotation: 45);
            Graph_4.Render();
            Insert_Log("Graph's Y-Axis Ticks rotated to 45°", 0);
            Y_Axis_Tick_Rotation_0.IsChecked = false;
            Y_Axis_Tick_Rotation_45.IsChecked = true;
        }

        private void Y_Axis_Tick_Rotation_90_Click(object sender, RoutedEventArgs e)
        {
            Graph_1.Plot.YAxis.TickLabelStyle(rotation: 90);
            Graph_1.Render();
            Graph_2.Plot.YAxis.TickLabelStyle(rotation: 90);
            Graph_2.Render();
            Graph_3.Plot.YAxis.TickLabelStyle(rotation: 90);
            Graph_3.Render();
            Graph_4.Plot.YAxis.TickLabelStyle(rotation: 90);
            Graph_4.Render();
            Insert_Log("Graph's Y-Axis Ticks rotated to 90°", 0);
            Y_Axis_Tick_Rotation_0.IsChecked = false;
            Y_Axis_Tick_Rotation_45.IsChecked = false;
        }

        private void Y_Axis_Tick_Rotation_135_Click(object sender, RoutedEventArgs e)
        {
            Graph_1.Plot.YAxis.TickLabelStyle(rotation: 135);
            Graph_1.Render();
            Graph_2.Plot.YAxis.TickLabelStyle(rotation: 135);
            Graph_2.Render();
            Graph_3.Plot.YAxis.TickLabelStyle(rotation: 135);
            Graph_3.Render();
            Graph_4.Plot.YAxis.TickLabelStyle(rotation: 135);
            Graph_4.Render();
            Insert_Log("Graph's Y-Axis Ticks rotated to 135°", 0);
            Y_Axis_Tick_Rotation_0.IsChecked = false;
            Y_Axis_Tick_Rotation_45.IsChecked = false;
        }

        private void Y_Axis_Tick_Rotation_180_Click(object sender, RoutedEventArgs e)
        {
            Graph_1.Plot.YAxis.TickLabelStyle(rotation: 180);
            Graph_1.Render();
            Graph_2.Plot.YAxis.TickLabelStyle(rotation: 180);
            Graph_2.Render();
            Graph_3.Plot.YAxis.TickLabelStyle(rotation: 180);
            Graph_3.Render();
            Graph_4.Plot.YAxis.TickLabelStyle(rotation: 180);
            Graph_4.Render();
            Insert_Log("Graph's Y-Axis Ticks rotated to 180°", 0);
            Y_Axis_Tick_Rotation_0.IsChecked = false;
            Y_Axis_Tick_Rotation_45.IsChecked = false;
        }

        private void Y_Axis_Minor_Grid_Click(object sender, RoutedEventArgs e)
        {
            if (Y_Axis_Minor_Grid.IsChecked == true)
            {
                Graph_1.Plot.YAxis.MinorGrid(true);
                Graph_1.Render();
                Graph_2.Plot.YAxis.MinorGrid(true);
                Graph_2.Render();
                Graph_3.Plot.YAxis.MinorGrid(true);
                Graph_3.Render();
                Graph_4.Plot.YAxis.MinorGrid(true);
                Graph_4.Render();
                Insert_Log("Graph's Y-Axis Minor Grid is enabled.", 0);
            }
            else
            {
                Graph_1.Plot.YAxis.MinorGrid(false);
                Graph_1.Render();
                Graph_2.Plot.YAxis.MinorGrid(false);
                Graph_2.Render();
                Graph_3.Plot.YAxis.MinorGrid(false);
                Graph_3.Render();
                Graph_4.Plot.YAxis.MinorGrid(false);
                Graph_4.Render();
                Insert_Log("Graph's Y-Axis Minor Grid is disabled.", 0);
            }
        }

        private void Y_Axis_Tick_Ruler_Mode_Click(object sender, RoutedEventArgs e)
        {
            if (Y_Axis_Tick_Ruler_Mode.IsChecked == true)
            {
                Graph_1.Plot.YAxis.RulerMode(true);
                Graph_1.Render();
                Graph_2.Plot.YAxis.RulerMode(true);
                Graph_2.Render();
                Graph_3.Plot.YAxis.RulerMode(true);
                Graph_3.Render();
                Graph_4.Plot.YAxis.RulerMode(true);
                Graph_4.Render();
                Insert_Log("Graph's Y-Axis Ruler Mode is Enabled.", 0);
            }
            else
            {
                Graph_1.Plot.YAxis.RulerMode(false);
                Graph_1.Render();
                Graph_2.Plot.YAxis.RulerMode(false);
                Graph_2.Render();
                Graph_3.Plot.YAxis.RulerMode(false);
                Graph_3.Render();
                Graph_4.Plot.YAxis.RulerMode(false);
                Graph_4.Render();
                Insert_Log("Graph's Y-Axis Ruler Mode is Disabled.", 0);
            }
        }

        //Font Size
        private void Font_Size_12_Click(object sender, RoutedEventArgs e)
        {
            Graph_1.Plot.XAxis.TickLabelStyle(fontSize: 12);
            Graph_1.Plot.YAxis.TickLabelStyle(fontSize: 12);
            Graph_1.Render();
            Graph_2.Plot.XAxis.TickLabelStyle(fontSize: 12);
            Graph_2.Plot.YAxis.TickLabelStyle(fontSize: 12);
            Graph_2.Render();
            Graph_3.Plot.XAxis.TickLabelStyle(fontSize: 12);
            Graph_3.Plot.YAxis.TickLabelStyle(fontSize: 12);
            Graph_3.Render();
            Graph_4.Plot.XAxis.TickLabelStyle(fontSize: 12);
            Graph_4.Plot.YAxis.TickLabelStyle(fontSize: 12);
            Graph_4.Render();
            Insert_Log("Graph's Axis Font Size chnaged to 12.", 0);
            Font_12.IsChecked = true;
            Font_14.IsChecked = false;
            Font_16.IsChecked = false;
            Font_18.IsChecked = false;
        }

        private void Font_Size_14_Click(object sender, RoutedEventArgs e)
        {
            Graph_1.Plot.XAxis.TickLabelStyle(fontSize: 14);
            Graph_1.Plot.YAxis.TickLabelStyle(fontSize: 14);
            Graph_1.Render();
            Graph_2.Plot.XAxis.TickLabelStyle(fontSize: 14);
            Graph_2.Plot.YAxis.TickLabelStyle(fontSize: 14);
            Graph_2.Render();
            Graph_3.Plot.XAxis.TickLabelStyle(fontSize: 14);
            Graph_3.Plot.YAxis.TickLabelStyle(fontSize: 14);
            Graph_3.Render();
            Graph_4.Plot.XAxis.TickLabelStyle(fontSize: 14);
            Graph_4.Plot.YAxis.TickLabelStyle(fontSize: 14);
            Graph_4.Render();
            Insert_Log("Graph's Axis Font Size chnaged to 14.", 0);
            Font_12.IsChecked = false;
            Font_14.IsChecked = true;
            Font_16.IsChecked = false;
            Font_18.IsChecked = false;
        }

        private void Font_Size_16_Click(object sender, RoutedEventArgs e)
        {
            Graph_1.Plot.XAxis.TickLabelStyle(fontSize: 16);
            Graph_1.Plot.YAxis.TickLabelStyle(fontSize: 16);
            Graph_1.Render();
            Graph_2.Plot.XAxis.TickLabelStyle(fontSize: 16);
            Graph_2.Plot.YAxis.TickLabelStyle(fontSize: 16);
            Graph_2.Render();
            Graph_3.Plot.XAxis.TickLabelStyle(fontSize: 16);
            Graph_3.Plot.YAxis.TickLabelStyle(fontSize: 16);
            Graph_3.Render();
            Graph_4.Plot.XAxis.TickLabelStyle(fontSize: 16);
            Graph_4.Plot.YAxis.TickLabelStyle(fontSize: 16);
            Graph_4.Render();
            Insert_Log("Graph's Axis Font Size chnaged to 16.", 0);
            Font_12.IsChecked = false;
            Font_14.IsChecked = false;
            Font_16.IsChecked = true;
            Font_18.IsChecked = false;
        }

        private void Font_Size_18_Click(object sender, RoutedEventArgs e)
        {
            Graph_1.Plot.XAxis.TickLabelStyle(fontSize: 18);
            Graph_1.Plot.YAxis.TickLabelStyle(fontSize: 18);
            Graph_1.Render();
            Graph_2.Plot.XAxis.TickLabelStyle(fontSize: 18);
            Graph_2.Plot.YAxis.TickLabelStyle(fontSize: 18);
            Graph_2.Render();
            Graph_3.Plot.XAxis.TickLabelStyle(fontSize: 18);
            Graph_3.Plot.YAxis.TickLabelStyle(fontSize: 18);
            Graph_3.Render();
            Graph_4.Plot.XAxis.TickLabelStyle(fontSize: 18);
            Graph_4.Plot.YAxis.TickLabelStyle(fontSize: 18);
            Graph_4.Render();
            Insert_Log("Graph's Axis Font Size chnaged to 18.", 0);
            Font_12.IsChecked = false;
            Font_14.IsChecked = false;
            Font_16.IsChecked = false;
            Font_18.IsChecked = true;
        }

        private void Graph_Vertical_Grid_Click(object sender, RoutedEventArgs e)
        {
            if (Graph_Vertical_Grid.IsChecked == true)
            {
                Graph_1.Plot.XAxis.Grid(true);
                Graph_1.Render();
                Graph_2.Plot.XAxis.Grid(true);
                Graph_2.Render();
                Graph_3.Plot.XAxis.Grid(true);
                Graph_3.Render();
                Graph_4.Plot.XAxis.Grid(true);
                Graph_4.Render();
                Insert_Log("Graph's Vertical Grid is Enabled.", 0);
            }
            else
            {
                Graph_1.Plot.XAxis.Grid(false);
                Graph_1.Render();
                Graph_2.Plot.XAxis.Grid(false);
                Graph_2.Render();
                Graph_3.Plot.XAxis.Grid(false);
                Graph_3.Render();
                Graph_4.Plot.XAxis.Grid(false);
                Graph_4.Render();
                Insert_Log("Graph's Vertical Grid is Disabled.", 0);
            }
        }

        private void Graph_Horizontal_Grid_Click(object sender, RoutedEventArgs e)
        {
            if (Graph_Horizontal_Grid.IsChecked == true)
            {
                Graph_1.Plot.YAxis.Grid(true);
                Graph_1.Render();
                Graph_2.Plot.YAxis.Grid(true);
                Graph_2.Render();
                Graph_3.Plot.YAxis.Grid(true);
                Graph_3.Render();
                Graph_4.Plot.YAxis.Grid(true);
                Graph_4.Render();
                Insert_Log("Graph's Horizontal Grid is Enabled.", 0);
            }
            else
            {
                Graph_1.Plot.YAxis.Grid(false);
                Graph_1.Render();
                Graph_2.Plot.YAxis.Grid(false);
                Graph_2.Render();
                Graph_3.Plot.YAxis.Grid(false);
                Graph_3.Render();
                Graph_4.Plot.YAxis.Grid(false);
                Graph_4.Render();
                Insert_Log("Graph's Horizontal Grid is Disabled.", 0);
            }
        }

        private void Grid_Style_Default_Click(object sender, RoutedEventArgs e)
        {
            Graph_1.Plot.Grid(lineStyle: LineStyle.Solid);
            Graph_1.Render();
            Graph_2.Plot.Grid(lineStyle: LineStyle.Solid);
            Graph_2.Render();
            Graph_3.Plot.Grid(lineStyle: LineStyle.Solid);
            Graph_3.Render();
            Graph_4.Plot.Grid(lineStyle: LineStyle.Solid);
            Graph_4.Render();
            Insert_Log("Graph's Grid Style set to Default.", 0);
            Grid_Style_Default.IsChecked = true;
            Grid_Style_Dotted.IsChecked = false;
            Grid_Style_Dashed.IsChecked = false;
            Grid_Style_Dot_Dash.IsChecked = false;
        }

        private void Grid_Style_Dotted_Click(object sender, RoutedEventArgs e)
        {
            Graph_1.Plot.Grid(lineStyle: LineStyle.Dot);
            Graph_1.Render();
            Graph_2.Plot.Grid(lineStyle: LineStyle.Dot);
            Graph_2.Render();
            Graph_3.Plot.Grid(lineStyle: LineStyle.Dot);
            Graph_3.Render();
            Graph_4.Plot.Grid(lineStyle: LineStyle.Dot);
            Graph_4.Render();
            Insert_Log("Graph's Grid Style set to Dotted.", 0);
            Grid_Style_Default.IsChecked = false;
            Grid_Style_Dotted.IsChecked = true;
            Grid_Style_Dashed.IsChecked = false;
            Grid_Style_Dot_Dash.IsChecked = false;
        }

        private void Grid_Style_Dashed_Click(object sender, RoutedEventArgs e)
        {
            Graph_1.Plot.Grid(lineStyle: LineStyle.Dash);
            Graph_1.Render();
            Graph_2.Plot.Grid(lineStyle: LineStyle.Dash);
            Graph_2.Render();
            Graph_3.Plot.Grid(lineStyle: LineStyle.Dash);
            Graph_3.Render();
            Graph_4.Plot.Grid(lineStyle: LineStyle.Dash);
            Graph_4.Render();
            Insert_Log("Graph's Grid Style set to Dashed.", 0);
            Grid_Style_Default.IsChecked = false;
            Grid_Style_Dotted.IsChecked = false;
            Grid_Style_Dashed.IsChecked = true;
            Grid_Style_Dot_Dash.IsChecked = false;
        }

        private void Grid_Style_Dot_Dash_Click(object sender, RoutedEventArgs e)
        {
            Graph_1.Plot.Grid(lineStyle: LineStyle.DashDot);
            Graph_1.Render();
            Graph_2.Plot.Grid(lineStyle: LineStyle.DashDot);
            Graph_2.Render();
            Graph_3.Plot.Grid(lineStyle: LineStyle.DashDot);
            Graph_3.Render();
            Graph_4.Plot.Grid(lineStyle: LineStyle.DashDot);
            Graph_4.Render();
            Insert_Log("Graph's Grid Style set to Dot Dashed.", 0);
            Grid_Style_Default.IsChecked = false;
            Grid_Style_Dotted.IsChecked = false;
            Grid_Style_Dashed.IsChecked = false;
            Grid_Style_Dot_Dash.IsChecked = true;
        }

        private void Show_legend_Click(object sender, RoutedEventArgs e)
        {
            if (Show_legend.IsChecked == true)
            {
                Graph_1.Plot.Legend(true);
                Graph_1.Render();
                Graph_2.Plot.Legend(true);
                Graph_2.Render();
                Graph_3.Plot.Legend(true);
                Graph_3.Render();
                Graph_4.Plot.Legend(true);
                Graph_4.Render();
                Insert_Log("Graph's Legend is Enabled.", 0);
            }
            else
            {
                Graph_1.Plot.Legend(false);
                Graph_1.Render();
                Graph_2.Plot.Legend(false);
                Graph_2.Render();
                Graph_3.Plot.Legend(false);
                Graph_3.Render();
                Graph_4.Plot.Legend(false);
                Graph_4.Render();
                Insert_Log("Graph's Legend is Disabled.", 0);
            }
        }

        private void Legend_TopLeft_Click(object sender, RoutedEventArgs e)
        {
            Show_legend.IsChecked = true;
            Graph_1.Plot.Legend(location: Alignment.UpperLeft);
            Graph_1.Render();
            Graph_2.Plot.Legend(location: Alignment.UpperLeft);
            Graph_2.Render();
            Graph_3.Plot.Legend(location: Alignment.UpperLeft);
            Graph_3.Render();
            Graph_4.Plot.Legend(location: Alignment.UpperLeft);
            Graph_4.Render();
            Insert_Log("Graph's Legend is now located at Top Left Side.", 0);
            Legend_TopLeft.IsChecked = true;
            Legend_TopRight.IsChecked = false;
            Legend_BottomLeft.IsChecked = false;
            Legend_BottomRight.IsChecked = false;
        }

        private void Legend_TopRight_Click(object sender, RoutedEventArgs e)
        {
            Show_legend.IsChecked = true;
            Graph_1.Plot.Legend(location: Alignment.UpperRight);
            Graph_1.Render();
            Graph_2.Plot.Legend(location: Alignment.UpperRight);
            Graph_2.Render();
            Graph_3.Plot.Legend(location: Alignment.UpperRight);
            Graph_3.Render();
            Graph_4.Plot.Legend(location: Alignment.UpperRight);
            Graph_4.Render();
            Insert_Log("Graph's Legend is now located at Top Right Side.", 0);
            Legend_TopLeft.IsChecked = false;
            Legend_TopRight.IsChecked = true;
            Legend_BottomLeft.IsChecked = false;
            Legend_BottomRight.IsChecked = false;
        }

        private void Legend_BottomLeft_Click(object sender, RoutedEventArgs e)
        {
            Show_legend.IsChecked = true;
            Graph_1.Plot.Legend(location: Alignment.LowerLeft);
            Graph_1.Render();
            Graph_2.Plot.Legend(location: Alignment.LowerLeft);
            Graph_2.Render();
            Graph_3.Plot.Legend(location: Alignment.LowerLeft);
            Graph_3.Render();
            Graph_4.Plot.Legend(location: Alignment.LowerLeft);
            Graph_4.Render();
            Insert_Log("Graph's Legend is now located at Bottom Left Side.", 0);
            Legend_TopLeft.IsChecked = false;
            Legend_TopRight.IsChecked = false;
            Legend_BottomLeft.IsChecked = true;
            Legend_BottomRight.IsChecked = false;
        }

        private void Legend_BottomRight_Click(object sender, RoutedEventArgs e)
        {
            Show_legend.IsChecked = true;
            Graph_1.Plot.Legend(location: Alignment.LowerRight);
            Graph_1.Render();
            Graph_2.Plot.Legend(location: Alignment.LowerRight);
            Graph_2.Render();
            Graph_3.Plot.Legend(location: Alignment.LowerRight);
            Graph_3.Render();
            Graph_4.Plot.Legend(location: Alignment.LowerRight);
            Graph_4.Render();
            Insert_Log("Graph's Legend is now located at Bottom Left Side.", 0);
            Legend_TopLeft.IsChecked = false;
            Legend_TopRight.IsChecked = false;
            Legend_BottomLeft.IsChecked = false;
            Legend_BottomRight.IsChecked = true;
        }
    }
}
