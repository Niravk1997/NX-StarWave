using MahApps.Metro.Controls;
using ScottPlot;
using System;
using System.Threading;
using System.Windows;

namespace Channel_DataLogger
{
    public partial class CH_DataLog_Graph_Window : MetroWindow
    {
        private void Force_Auto_Axis_Click(object sender, RoutedEventArgs e)
        {
            Graph.Plot.AxisAuto();
            Graph.Render();
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

        private void Title_Text_Button_Click(object sender, RoutedEventArgs e)
        {
            Graph.Plot.Title(Title_Set_Text.Text);
            Graph.Render();
            Insert_Log("Graph's Title Label changed to " + Title_Set_Text.Text, 0);
            Title_Set_Text.Text = string.Empty;
        }

        private void X_Axis_Text_Button_Click(object sender, RoutedEventArgs e)
        {
            Graph.Plot.XAxis.Label(X_Axis_Set_Text.Text);
            Graph.Render();
            Insert_Log("Graph's X-Axis Label changed to " + X_Axis_Set_Text.Text, 0);
            X_Axis_Set_Text.Text = string.Empty;
        }

        private void Y_Axis_Text_Button_Click(object sender, RoutedEventArgs e)
        {
            Graph.Plot.YAxis.Label(Y_Axis_Set_Text.Text);
            Graph.Render();
            Insert_Log("Graph's Y-Axis Label changed to " + Y_Axis_Set_Text.Text, 0);
            Y_Axis_Set_Text.Text = string.Empty;
        }

        private void X_Axis_Show_Click(object sender, RoutedEventArgs e)
        {
            if (X_Axis_Show.IsChecked == true)
            {
                Graph.Plot.XAxis.Ticks(true);
                Graph.Render();
                Insert_Log("Graph's X-Axis Ticks have been enabled.", 0);
            }
            else
            {
                Graph.Plot.XAxis.Ticks(false);
                Graph.Render();
                Insert_Log("Graph's X-Axis Ticks have been disabled.", 0);
            }
        }

        private void X_Axis_Default_Tick_Click(object sender, RoutedEventArgs e)
        {
            if (X_Axis_Default_Tick.IsChecked == true)
            {
                Graph.Plot.XAxis.ManualTickSpacing(0);
                Graph.Render();
                Insert_Log("Graph's X-Axis Ticks have been set to default.", 0);
            }
        }

        private void X_Axis_Custom_Set_Tick_Button_Click(object sender, RoutedEventArgs e)
        {
            (bool isValid, double Value) = Functions.Text_Num(X_Axis_Custom_Set_Tick.Text, false, true);
            if (isValid == true)
            {
                X_Axis_Default_Tick.IsChecked = false;
                Graph.Plot.XAxis.ManualTickSpacing(Value);
                Graph.Render();
                Insert_Log("Graph's X-Axis Ticks have been set to " + Value, 0);
                X_Axis_Custom_Set_Tick.Text = string.Empty;
            }
            else
            {
                X_Axis_Custom_Set_Tick.Text = string.Empty;
                Insert_Log("Graph's X-Axis Custom Tick value must be a number. No text or other characters are allowed.", 1);
            }

        }

        private void X_Axis_Tick_Rotation_0_Click(object sender, RoutedEventArgs e)
        {
            Graph.Plot.XAxis.TickLabelStyle(rotation: 0);
            Graph.Render();
            Insert_Log("Graph's X-Axis Ticks rotated to 0°", 0);
            X_Axis_Tick_Rotation_0.IsChecked = true;
            X_Axis_Tick_Rotation_45.IsChecked = false;
        }

        private void X_Axis_Tick_Rotation_45_Click(object sender, RoutedEventArgs e)
        {
            Graph.Plot.XAxis.TickLabelStyle(rotation: 45);
            Graph.Render();
            Insert_Log("Graph's X-Axis Ticks rotated to 45°", 0);
            X_Axis_Tick_Rotation_0.IsChecked = false;
            X_Axis_Tick_Rotation_45.IsChecked = true;
        }

        private void X_Axis_Minor_Grid_Click(object sender, RoutedEventArgs e)
        {
            if (X_Axis_Minor_Grid.IsChecked == true)
            {
                Graph.Plot.XAxis.MinorGrid(true);
                Graph.Render();
                Insert_Log("Graph's X-Axis Minor Grid is enabled.", 0);
            }
            else
            {
                Graph.Plot.XAxis.MinorGrid(false);
                Graph.Render();
                Insert_Log("Graph's X-Axis Minor Grid is disabled.", 0);
            }
        }

        private void X_Axis_Multiplier_Notation_Click(object sender, RoutedEventArgs e)
        {
            if (X_Axis_Multiplier_Notation.IsChecked == true)
            {
                Graph.Plot.XAxis.TickLabelNotation(multiplier: true);
                Graph.Render();
                Insert_Log("Graph's X-Axis Multiplier Notation is Enabled.", 0);
            }
            else
            {
                Graph.Plot.XAxis.TickLabelNotation(multiplier: false);
                Graph.Render();
                Insert_Log("Graph's X-Axis Multiplier Notation is Disabled.", 0);
            }
        }

        private void X_Axis_Tick_Ruler_Mode_Click(object sender, RoutedEventArgs e)
        {
            if (X_Axis_Tick_Ruler_Mode.IsChecked == true)
            {
                Graph.Plot.XAxis.RulerMode(true);
                Graph.Render();
                Insert_Log("Graph's X-Axis Ruler Mode is Enabled.", 0);
            }
            else
            {
                Graph.Plot.XAxis.RulerMode(false);
                Graph.Render();
                Insert_Log("Graph's X-Axis Ruler Mode is Disabled.", 0);
            }
        }

        private void Y_Axis_Show_Click(object sender, RoutedEventArgs e)
        {
            if (Y_Axis_Show.IsChecked == true)
            {
                Graph.Plot.YAxis.Ticks(true);
                Graph.Render();
                Insert_Log("Graph's Y-Axis Ticks have been enabled.", 0);
            }
            else
            {
                Graph.Plot.YAxis.Ticks(false);
                Graph.Render();
                Insert_Log("Graph's Y-Axis Ticks have been disabled.", 0);
            }
        }

        private void Y_Axis_Default_Tick_Click(object sender, RoutedEventArgs e)
        {
            if (Y_Axis_Default_Tick.IsChecked == true)
            {
                Graph.Plot.YAxis.ManualTickSpacing(0);
                Graph.Render();
                Insert_Log("Graph's Y-Axis Ticks have been set to default.", 0);
            }
        }

        private void Y_Axis_Custom_Set_Tick_Button_Click(object sender, RoutedEventArgs e)
        {
            (bool isValid, double Value) = Functions.Text_Num(Y_Axis_Custom_Set_Tick.Text, false, true);
            if (isValid == true)
            {
                Y_Axis_Default_Tick.IsChecked = false;
                Graph.Plot.YAxis.ManualTickSpacing(Value);
                Graph.Render();
                Insert_Log("Graph's Y-Axis Ticks have been set to " + Value, 0);
                Y_Axis_Custom_Set_Tick.Text = string.Empty;
            }
            else
            {
                Y_Axis_Custom_Set_Tick.Text = string.Empty;
                Insert_Log("Graph's Y-Axis Custom Tick value must be a number. No text or other characters are allowed.", 1);
            }
        }

        private void Y_Axis_Tick_Rotation_0_Click(object sender, RoutedEventArgs e)
        {
            Graph.Plot.YAxis.TickLabelStyle(rotation: 0);
            Graph.Render();
            Insert_Log("Graph's Y-Axis Ticks rotated to 0°", 0);
            Y_Axis_Tick_Rotation_0.IsChecked = true;
            Y_Axis_Tick_Rotation_45.IsChecked = false;
        }

        private void Y_Axis_Tick_Rotation_45_Click(object sender, RoutedEventArgs e)
        {
            Graph.Plot.YAxis.TickLabelStyle(rotation: 45);
            Graph.Render();
            Insert_Log("Graph's Y-Axis Ticks rotated to 45°", 0);
            Y_Axis_Tick_Rotation_0.IsChecked = false;
            Y_Axis_Tick_Rotation_45.IsChecked = true;
        }

        private void Y_Axis_Minor_Grid_Click(object sender, RoutedEventArgs e)
        {
            if (Y_Axis_Minor_Grid.IsChecked == true)
            {
                Graph.Plot.YAxis.MinorGrid(true);
                Graph.Render();
                Insert_Log("Graph's Y-Axis Minor Grid is enabled.", 0);
            }
            else
            {
                Graph.Plot.YAxis.MinorGrid(false);
                Graph.Render();
                Insert_Log("Graph's Y-Axis Minor Grid is disabled.", 0);
            }
        }

        private void Y_Axis_Multiplier_Notation_Click(object sender, RoutedEventArgs e)
        {
            if (Y_Axis_Multiplier_Notation.IsChecked == true)
            {
                Graph.Plot.YAxis.TickLabelNotation(multiplier: true);
                Graph.Render();
                Insert_Log("Graph's Y-Axis Multiplier Notation is Enabled.", 0);
            }
            else
            {
                Graph.Plot.YAxis.TickLabelNotation(multiplier: false);
                Graph.Render();
                Insert_Log("Graph's Y-Axis Multiplier Notation is Disabled.", 0);
            }
        }

        private void Y_Axis_Tick_Ruler_Mode_Click(object sender, RoutedEventArgs e)
        {
            if (Y_Axis_Tick_Ruler_Mode.IsChecked == true)
            {
                Graph.Plot.YAxis.RulerMode(true);
                Graph.Render();
                Insert_Log("Graph's Y-Axis Ruler Mode is Enabled.", 0);
            }
            else
            {
                Graph.Plot.YAxis.RulerMode(false);
                Graph.Render();
                Insert_Log("Graph's Y-Axis Ruler Mode is Disabled.", 0);
            }
        }

        //Font Size
        private void Font_Size_12_Click(object sender, RoutedEventArgs e)
        {
            Graph.Plot.XAxis.TickLabelStyle(fontSize: 12);
            Graph.Plot.YAxis.TickLabelStyle(fontSize: 12);
            Graph.Render();
            Insert_Log("Graph's Axis Font Size chnaged to 12.", 0);
            Font_12.IsChecked = true;
            Font_14.IsChecked = false;
            Font_16.IsChecked = false;
            Font_18.IsChecked = false;
        }

        private void Font_Size_14_Click(object sender, RoutedEventArgs e)
        {
            Graph.Plot.XAxis.TickLabelStyle(fontSize: 14);
            Graph.Plot.YAxis.TickLabelStyle(fontSize: 14);
            Graph.Render();
            Insert_Log("Graph's Axis Font Size chnaged to 14.", 0);
            Font_12.IsChecked = false;
            Font_14.IsChecked = true;
            Font_16.IsChecked = false;
            Font_18.IsChecked = false;
        }

        private void Font_Size_16_Click(object sender, RoutedEventArgs e)
        {
            Graph.Plot.XAxis.TickLabelStyle(fontSize: 16);
            Graph.Plot.YAxis.TickLabelStyle(fontSize: 16);
            Graph.Render();
            Insert_Log("Graph's Axis Font Size chnaged to 16.", 0);
            Font_12.IsChecked = false;
            Font_14.IsChecked = false;
            Font_16.IsChecked = true;
            Font_18.IsChecked = false;
        }

        private void Font_Size_18_Click(object sender, RoutedEventArgs e)
        {
            Graph.Plot.XAxis.TickLabelStyle(fontSize: 18);
            Graph.Plot.YAxis.TickLabelStyle(fontSize: 18);
            Graph.Render();
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
                Graph.Plot.XAxis.Grid(true);
                Graph.Render();
                Insert_Log("Graph's Vertical Grid is Enabled.", 0);
            }
            else
            {
                Graph.Plot.XAxis.Grid(false);
                Graph.Render();
                Insert_Log("Graph's Vertical Grid is Disabled.", 0);
            }
        }

        private void Graph_Horizontal_Grid_Click(object sender, RoutedEventArgs e)
        {
            if (Graph_Horizontal_Grid.IsChecked == true)
            {
                Graph.Plot.YAxis.Grid(true);
                Graph.Render();
                Insert_Log("Graph's Horizontal Grid is Enabled.", 0);
            }
            else
            {
                Graph.Plot.YAxis.Grid(false);
                Graph.Render();
                Insert_Log("Graph's Horizontal Grid is Disabled.", 0);
            }
        }

        private void Grid_Style_Default_Click(object sender, RoutedEventArgs e)
        {
            Graph.Plot.Grid(lineStyle: LineStyle.Solid);
            Graph.Render();
            Insert_Log("Graph's Grid Style set to Default.", 0);
            Grid_Style_Default.IsChecked = true;
            Grid_Style_Dotted.IsChecked = false;
            Grid_Style_Dashed.IsChecked = false;
            Grid_Style_Dot_Dash.IsChecked = false;
        }

        private void Grid_Style_Dotted_Click(object sender, RoutedEventArgs e)
        {
            Graph.Plot.Grid(lineStyle: LineStyle.Dot);
            Graph.Render();
            Insert_Log("Graph's Grid Style set to Dotted.", 0);
            Grid_Style_Default.IsChecked = false;
            Grid_Style_Dotted.IsChecked = true;
            Grid_Style_Dashed.IsChecked = false;
            Grid_Style_Dot_Dash.IsChecked = false;
        }

        private void Grid_Style_Dashed_Click(object sender, RoutedEventArgs e)
        {
            Graph.Plot.Grid(lineStyle: LineStyle.Dash);
            Graph.Render();
            Insert_Log("Graph's Grid Style set to Dashed.", 0);
            Grid_Style_Default.IsChecked = false;
            Grid_Style_Dotted.IsChecked = false;
            Grid_Style_Dashed.IsChecked = true;
            Grid_Style_Dot_Dash.IsChecked = false;
        }

        private void Grid_Style_Dot_Dash_Click(object sender, RoutedEventArgs e)
        {
            Graph.Plot.Grid(lineStyle: LineStyle.DashDot);
            Graph.Render();
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
                Graph.Plot.Legend(true);
                Graph.Render();
                Insert_Log("Graph's Legend is Enabled.", 0);
            }
            else
            {
                Graph.Plot.Legend(false);
                Graph.Render();
                Insert_Log("Graph's Legend is Disabled.", 0);
            }
        }

        private void Legend_TopLeft_Click(object sender, RoutedEventArgs e)
        {
            Show_legend.IsChecked = true;
            Graph.Plot.Legend(location: Alignment.UpperLeft);
            Graph.Render();
            Insert_Log("Graph's Legend is now located at Top Left Side.", 0);
            Legend_TopLeft.IsChecked = true;
            Legend_TopRight.IsChecked = false;
            Legend_BottomLeft.IsChecked = false;
            Legend_BottomRight.IsChecked = false;
        }

        private void Legend_TopRight_Click(object sender, RoutedEventArgs e)
        {
            Show_legend.IsChecked = true;
            Graph.Plot.Legend(location: Alignment.UpperRight);
            Graph.Render();
            Insert_Log("Graph's Legend is now located at Top Right Side.", 0);
            Legend_TopLeft.IsChecked = false;
            Legend_TopRight.IsChecked = true;
            Legend_BottomLeft.IsChecked = false;
            Legend_BottomRight.IsChecked = false;
        }

        private void Legend_BottomLeft_Click(object sender, RoutedEventArgs e)
        {
            Show_legend.IsChecked = true;
            Graph.Plot.Legend(location: Alignment.LowerLeft);
            Graph.Render();
            Insert_Log("Graph's Legend is now located at Bottom Left Side.", 0);
            Legend_TopLeft.IsChecked = false;
            Legend_TopRight.IsChecked = false;
            Legend_BottomLeft.IsChecked = true;
            Legend_BottomRight.IsChecked = false;
        }

        private void Legend_BottomRight_Click(object sender, RoutedEventArgs e)
        {
            Show_legend.IsChecked = true;
            Graph.Plot.Legend(location: Alignment.LowerRight);
            Graph.Render();
            Insert_Log("Graph's Legend is now located at Bottom Left Side.", 0);
            Legend_TopLeft.IsChecked = false;
            Legend_TopRight.IsChecked = false;
            Legend_BottomLeft.IsChecked = false;
            Legend_BottomRight.IsChecked = true;
        }

        private void AVG_Factor_50_Click(object sender, RoutedEventArgs e)
        {
            Interlocked.Exchange(ref Moving_average_factor, 50);
            Insert_Log("Exponential Moving Average's factor set to " + Moving_average_factor + ".", 0);
            AVG_Factor_Selected();
        }

        private void AVG_Factor_100_Click(object sender, RoutedEventArgs e)
        {
            Interlocked.Exchange(ref Moving_average_factor, 100);
            Insert_Log("Exponential Moving Average's factor set to " + Moving_average_factor + ".", 0);
            AVG_Factor_Selected();
        }

        private void AVG_Factor_200_Click(object sender, RoutedEventArgs e)
        {
            Interlocked.Exchange(ref Moving_average_factor, 200);
            Insert_Log("Exponential Moving Average's factor set to " + Moving_average_factor + ".", 0);
            AVG_Factor_Selected();
        }

        private void AVG_Factor_400_Click(object sender, RoutedEventArgs e)
        {
            Interlocked.Exchange(ref Moving_average_factor, 400);
            Insert_Log("Exponential Moving Average's factor set to " + Moving_average_factor + ".", 0);
            AVG_Factor_Selected();
        }

        private void AVG_Factor_800_Click(object sender, RoutedEventArgs e)
        {
            Interlocked.Exchange(ref Moving_average_factor, 800);
            Insert_Log("Exponential Moving Average's factor set to " + Moving_average_factor + ".", 0);
            AVG_Factor_Selected();
        }

        private void AVG_Factor_1000_Click(object sender, RoutedEventArgs e)
        {
            Interlocked.Exchange(ref Moving_average_factor, 1000);
            Insert_Log("Exponential Moving Average's factor set to " + Moving_average_factor + ".", 0);
            AVG_Factor_Selected();
        }

        private void AVG_Factor_Selected()
        {
            if (Moving_average_factor == 50)
            {
                AVG_Factor_50.IsChecked = true;
            }
            else
            {
                AVG_Factor_50.IsChecked = false;
            }
            if (Moving_average_factor == 100)
            {
                AVG_Factor_100.IsChecked = true;
            }
            else
            {
                AVG_Factor_100.IsChecked = false;
            }
            if (Moving_average_factor == 200)
            {
                AVG_Factor_200.IsChecked = true;
            }
            else
            {
                AVG_Factor_200.IsChecked = false;
            }
            if (Moving_average_factor == 400)
            {
                AVG_Factor_400.IsChecked = true;
            }
            else
            {
                AVG_Factor_400.IsChecked = false;
            }
            if (Moving_average_factor == 800)
            {
                AVG_Factor_800.IsChecked = true;
            }
            else
            {
                AVG_Factor_800.IsChecked = false;
            }
            if (Moving_average_factor == 1000)
            {
                AVG_Factor_1000.IsChecked = true;
            }
            else
            {
                AVG_Factor_1000.IsChecked = false;
            }
        }

        private void AVG_Resolution_2_Click(object sender, RoutedEventArgs e)
        {
            Interlocked.Exchange(ref Moving_average_resolution, 2);
            Insert_Log("Exponential Moving Average's resolution set to " + Moving_average_resolution + ".", 0);
            AVG_Res_Selected();
        }

        private void AVG_Resolution_3_Click(object sender, RoutedEventArgs e)
        {
            Interlocked.Exchange(ref Moving_average_resolution, 3);
            Insert_Log("Exponential Moving Average's resolution set to " + Moving_average_resolution + ".", 0);
            AVG_Res_Selected();
        }

        private void AVG_Resolution_4_Click(object sender, RoutedEventArgs e)
        {
            Interlocked.Exchange(ref Moving_average_resolution, 4);
            Insert_Log("Exponential Moving Average's resolution set to " + Moving_average_resolution + ".", 0);
            AVG_Res_Selected();
        }

        private void AVG_Resolution_5_Click(object sender, RoutedEventArgs e)
        {
            Interlocked.Exchange(ref Moving_average_resolution, 5);
            Insert_Log("Exponential Moving Average's resolution set to " + Moving_average_resolution + ".", 0);
            AVG_Res_Selected();
        }

        private void AVG_Resolution_6_Click(object sender, RoutedEventArgs e)
        {
            Interlocked.Exchange(ref Moving_average_resolution, 6);
            Insert_Log("Exponential Moving Average's resolution set to " + Moving_average_resolution + ".", 0);
            AVG_Res_Selected();
        }

        private void AVG_Resolution_7_Click(object sender, RoutedEventArgs e)
        {
            Interlocked.Exchange(ref Moving_average_resolution, 7);
            Insert_Log("Exponential Moving Average's resolution set to " + Moving_average_resolution + ".", 0);
            AVG_Res_Selected();
        }

        private void AVG_Resolution_8_Click(object sender, RoutedEventArgs e)
        {
            Interlocked.Exchange(ref Moving_average_resolution, 8);
            Insert_Log("Exponential Moving Average's resolution set to " + Moving_average_resolution + ".", 0);
            AVG_Res_Selected();
        }

        private void AVG_Res_Selected()
        {
            if (Moving_average_resolution == 2)
            {
                AVG_Resolution_2.IsChecked = true;
            }
            else
            {
                AVG_Resolution_2.IsChecked = false;
            }
            if (Moving_average_resolution == 3)
            {
                AVG_Resolution_3.IsChecked = true;
            }
            else
            {
                AVG_Resolution_3.IsChecked = false;
            }
            if (Moving_average_resolution == 4)
            {
                AVG_Resolution_4.IsChecked = true;
            }
            else
            {
                AVG_Resolution_4.IsChecked = false;
            }
            if (Moving_average_resolution == 5)
            {
                AVG_Resolution_5.IsChecked = true;
            }
            else
            {
                AVG_Resolution_5.IsChecked = false;
            }
            if (Moving_average_resolution == 6)
            {
                AVG_Resolution_6.IsChecked = true;
            }
            else
            {
                AVG_Resolution_6.IsChecked = false;
            }
            if (Moving_average_resolution == 7)
            {
                AVG_Resolution_7.IsChecked = true;
            }
            else
            {
                AVG_Resolution_7.IsChecked = false;
            }
            if (Moving_average_resolution == 8)
            {
                AVG_Resolution_8.IsChecked = true;
            }
            else
            {
                AVG_Resolution_8.IsChecked = false;
            }
        }

        private void RefreshRate_1ms_Click(object sender, RoutedEventArgs e)
        {
            RefreshRate_Select(9);
            GraphRender.Interval = TimeSpan.FromMilliseconds(1);
            DataProcess.Interval = 0.05;
            Insert_Log("Graph's Refresh Rate is set to 1ms.", 0);
        }

        private void RefreshRate_5ms_Click(object sender, RoutedEventArgs e)
        {
            RefreshRate_Select(8);
            GraphRender.Interval = TimeSpan.FromMilliseconds(5);
            DataProcess.Interval = 2;
            Insert_Log("Graph's Refresh Rate is set to 5ms.", 0);
        }

        private void RefreshRate_10ms_Click(object sender, RoutedEventArgs e)
        {
            RefreshRate_Select(0);
            GraphRender.Interval = TimeSpan.FromMilliseconds(10);
            DataProcess.Interval = 5;
            Insert_Log("Graph's Refresh Rate is set to 10ms.", 0);
        }

        private void RefreshRate_50ms_Click(object sender, RoutedEventArgs e)
        {
            RefreshRate_Select(1);
            GraphRender.Interval = TimeSpan.FromMilliseconds(50);
            DataProcess.Interval = 25;
            Insert_Log("Graph's Refresh Rate is set to 50ms.", 0);
        }

        private void RefreshRate_100ms_Click(object sender, RoutedEventArgs e)
        {
            RefreshRate_Select(2);
            GraphRender.Interval = TimeSpan.FromMilliseconds(100);
            DataProcess.Interval = 50;
            Insert_Log("Graph's Refresh Rate is set to 100ms.", 0);
        }

        private void RefreshRate_200ms_Click(object sender, RoutedEventArgs e)
        {
            RefreshRate_Select(3);
            GraphRender.Interval = TimeSpan.FromMilliseconds(200);
            DataProcess.Interval = 100;
            Insert_Log("Graph's Refresh Rate is set to 200ms.", 0);
        }

        private void RefreshRate_500ms_Click(object sender, RoutedEventArgs e)
        {
            RefreshRate_Select(4);
            GraphRender.Interval = TimeSpan.FromMilliseconds(500);
            DataProcess.Interval = 250;
            Insert_Log("Graph's Refresh Rate is set to 500ms.", 0);
        }

        private void RefreshRate_1s_Click(object sender, RoutedEventArgs e)
        {
            RefreshRate_Select(5);
            GraphRender.Interval = TimeSpan.FromSeconds(1);
            DataProcess.Interval = 500;
            Insert_Log("Graph's Refresh Rate is set to 1s.", 0);
        }

        private void RefreshRate_2s_Click(object sender, RoutedEventArgs e)
        {
            RefreshRate_Select(6);
            GraphRender.Interval = TimeSpan.FromSeconds(2);
            DataProcess.Interval = 1000;
            Insert_Log("Graph's Refresh Rate is set to 2s.", 0);
        }

        private void RefreshRate_5s_Click(object sender, RoutedEventArgs e)
        {
            RefreshRate_Select(7);
            GraphRender.Interval = TimeSpan.FromSeconds(5);
            DataProcess.Interval = 2500;
            Insert_Log("Graph's Refresh Rate is set to 5s.", 0);
        }

        private void RefreshRate_Select(int Selected)
        {
            if (Selected == 0)
            {
                RefreshRate_10ms.IsChecked = true;
            }
            else
            {
                RefreshRate_10ms.IsChecked = false;
            }
            if (Selected == 1)
            {
                RefreshRate_50ms.IsChecked = true;
            }
            else
            {
                RefreshRate_50ms.IsChecked = false;
            }
            if (Selected == 2)
            {
                RefreshRate_100ms.IsChecked = true;
            }
            else
            {
                RefreshRate_100ms.IsChecked = false;
            }
            if (Selected == 3)
            {
                RefreshRate_200ms.IsChecked = true;
            }
            else
            {
                RefreshRate_200ms.IsChecked = false;
            }
            if (Selected == 4)
            {
                RefreshRate_500ms.IsChecked = true;
            }
            else
            {
                RefreshRate_500ms.IsChecked = false;
            }
            if (Selected == 5)
            {
                RefreshRate_1s.IsChecked = true;
            }
            else
            {
                RefreshRate_1s.IsChecked = false;
            }
            if (Selected == 6)
            {
                RefreshRate_2s.IsChecked = true;
            }
            else
            {
                RefreshRate_2s.IsChecked = false;
            }
            if (Selected == 7)
            {
                RefreshRate_5s.IsChecked = true;
            }
            else
            {
                RefreshRate_5s.IsChecked = false;
            }
            if (Selected == 8)
            {
                RefreshRate_5ms.IsChecked = true;
            }
            else
            {
                RefreshRate_5ms.IsChecked = false;
            }
            if (Selected == 9)
            {
                RefreshRate_1ms.IsChecked = true;
            }
            else
            {
                RefreshRate_1ms.IsChecked = false;
            }
        }

        private void Reset_Graph_Click(object sender, RoutedEventArgs e)
        {
            Graph_Reset = true;
            Insert_Log("Graph Reset Command has been send.", 0);
        }
    }
}
