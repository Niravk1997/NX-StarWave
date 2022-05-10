using MahApps.Metro.Controls;
using System.Windows;


namespace AllChannels_YT_Stack
{
    public partial class AllChannels_YT_Stack_Plotter : MetroWindow
    {
        private void CH1_Visibility_Option_Click(object sender, RoutedEventArgs e)
        {
            if (CH1_Visibility_Option.IsChecked)
            {
                Channel_1_Curve.IsVisible = true;
                Graph_1.Render();
            }
            else
            {
                Channel_1_Curve.IsVisible = false;
                Graph_1.Render();
            }
        }

        private void CH2_Visibility_Option_Click(object sender, RoutedEventArgs e)
        {
            if (CH2_Visibility_Option.IsChecked)
            {
                Channel_2_Curve.IsVisible = true;
                Graph_2.Render();
            }
            else
            {
                Channel_2_Curve.IsVisible = false;
                Graph_2.Render();
            }
        }

        private void CH3_Visibility_Option_Click(object sender, RoutedEventArgs e)
        {
            if (CH3_Visibility_Option.IsChecked)
            {
                Channel_3_Curve.IsVisible = true;
                Graph_3.Render();
            }
            else
            {
                Channel_3_Curve.IsVisible = false;
                Graph_3.Render();
            }
        }

        private void CH4_Visibility_Option_Click(object sender, RoutedEventArgs e)
        {
            if (CH4_Visibility_Option.IsChecked)
            {
                Channel_4_Curve.IsVisible = true;
                Graph_4.Render();
            }
            else
            {
                Channel_4_Curve.IsVisible = false;
                Graph_4.Render();
            }
        }
        //CH1 Curve Color
        private void Green_CH1_Curve_Color_Click(object sender, RoutedEventArgs e)
        {
            Channel_1_Curve.Color = System.Drawing.ColorTranslator.FromHtml("#00b33c");
            Graph_1.Render();
            CH1_Curve_Color_Select(0);
        }

        private void Blue_CH1_Curve_Color_Click(object sender, RoutedEventArgs e)
        {
            Channel_1_Curve.Color = System.Drawing.ColorTranslator.FromHtml("#0072BD");
            Graph_1.Render();
            CH1_Curve_Color_Select(1);
        }

        private void Red_CH1_Curve_Color_Click(object sender, RoutedEventArgs e)
        {
            Channel_1_Curve.Color = System.Drawing.ColorTranslator.FromHtml("#FFFF0000");
            Graph_1.Render();
            CH1_Curve_Color_Select(2);
        }

        private void Yellow_CH1_Curve_Color_Click(object sender, RoutedEventArgs e)
        {
            Channel_1_Curve.Color = System.Drawing.ColorTranslator.FromHtml("#FFFFFF00");
            Graph_1.Render();
            CH1_Curve_Color_Select(3);
        }

        private void Orange_CH1_Curve_Color_Click(object sender, RoutedEventArgs e)
        {
            Channel_1_Curve.Color = System.Drawing.ColorTranslator.FromHtml("#FFFF8C00");
            Graph_1.Render();
            CH1_Curve_Color_Select(4);
        }

        private void Black_CH1_Curve_Color_Click(object sender, RoutedEventArgs e)
        {
            Channel_1_Curve.Color = System.Drawing.ColorTranslator.FromHtml("#FF000000");
            Graph_1.Render();
            CH1_Curve_Color_Select(5);
        }

        private void Pink_CH1_Curve_Color_Click(object sender, RoutedEventArgs e)
        {
            Channel_1_Curve.Color = System.Drawing.ColorTranslator.FromHtml("#FFFF1493");
            Graph_1.Render();
            CH1_Curve_Color_Select(6);
        }

        private void Violet_CH1_Curve_Color_Click(object sender, RoutedEventArgs e)
        {
            Channel_1_Curve.Color = System.Drawing.ColorTranslator.FromHtml("#FF9400D3");
            Graph_1.Render();
            CH1_Curve_Color_Select(7);
        }

        private void White_CH1_Curve_Color_Click(object sender, RoutedEventArgs e)
        {
            Channel_1_Curve.Color = System.Drawing.ColorTranslator.FromHtml("#FFFFFFFF");
            Graph_1.Render();
            CH1_Curve_Color_Select(8);
        }

        private void CH1_Curve_Color_Select(int Selected)
        {
            if (Selected == 0)
            {
                Green_CH1_Curve_Color.IsChecked = true;
            }
            else
            {
                Green_CH1_Curve_Color.IsChecked = false;
            }
            if (Selected == 1)
            {
                Blue_CH1_Curve_Color.IsChecked = true;
            }
            else
            {
                Blue_CH1_Curve_Color.IsChecked = false;
            }
            if (Selected == 2)
            {
                Red_CH1_Curve_Color.IsChecked = true;
            }
            else
            {
                Red_CH1_Curve_Color.IsChecked = false;
            }
            if (Selected == 3)
            {
                Yellow_CH1_Curve_Color.IsChecked = true;
            }
            else
            {
                Yellow_CH1_Curve_Color.IsChecked = false;
            }
            if (Selected == 4)
            {
                Orange_CH1_Curve_Color.IsChecked = true;
            }
            else
            {
                Orange_CH1_Curve_Color.IsChecked = false;
            }
            if (Selected == 5)
            {
                Black_CH1_Curve_Color.IsChecked = true;
            }
            else
            {
                Black_CH1_Curve_Color.IsChecked = false;
            }
            if (Selected == 6)
            {
                Pink_CH1_Curve_Color.IsChecked = true;
            }
            else
            {
                Pink_CH1_Curve_Color.IsChecked = false;
            }
            if (Selected == 7)
            {
                Violet_CH1_Curve_Color.IsChecked = true;
            }
            else
            {
                Violet_CH1_Curve_Color.IsChecked = false;
            }
            if (Selected == 8)
            {
                White_CH1_Curve_Color.IsChecked = true;
            }
            else
            {
                White_CH1_Curve_Color.IsChecked = false;
            }
        }

        //CH2 Curve Color
        private void Green_CH2_Curve_Color_Click(object sender, RoutedEventArgs e)
        {
            Channel_2_Curve.Color = System.Drawing.ColorTranslator.FromHtml("#00b33c");
            Graph_2.Render();
            CH2_Curve_Color_Select(0);
        }

        private void Blue_CH2_Curve_Color_Click(object sender, RoutedEventArgs e)
        {
            Channel_2_Curve.Color = System.Drawing.ColorTranslator.FromHtml("#0072BD");
            Graph_2.Render();
            CH2_Curve_Color_Select(1);
        }

        private void Red_CH2_Curve_Color_Click(object sender, RoutedEventArgs e)
        {
            Channel_2_Curve.Color = System.Drawing.ColorTranslator.FromHtml("#FFFF0000");
            Graph_2.Render();
            CH2_Curve_Color_Select(2);
        }

        private void Yellow_CH2_Curve_Color_Click(object sender, RoutedEventArgs e)
        {
            Channel_2_Curve.Color = System.Drawing.ColorTranslator.FromHtml("#FFFFFF00");
            Graph_2.Render();
            CH2_Curve_Color_Select(3);
        }

        private void Orange_CH2_Curve_Color_Click(object sender, RoutedEventArgs e)
        {
            Channel_2_Curve.Color = System.Drawing.ColorTranslator.FromHtml("#FFFF8C00");
            Graph_2.Render();
            CH2_Curve_Color_Select(4);
        }

        private void Black_CH2_Curve_Color_Click(object sender, RoutedEventArgs e)
        {
            Channel_2_Curve.Color = System.Drawing.ColorTranslator.FromHtml("#FF000000");
            Graph_2.Render();
            CH2_Curve_Color_Select(5);
        }

        private void Pink_CH2_Curve_Color_Click(object sender, RoutedEventArgs e)
        {
            Channel_2_Curve.Color = System.Drawing.ColorTranslator.FromHtml("#FFFF1493");
            Graph_2.Render();
            CH2_Curve_Color_Select(6);
        }

        private void Violet_CH2_Curve_Color_Click(object sender, RoutedEventArgs e)
        {
            Channel_2_Curve.Color = System.Drawing.ColorTranslator.FromHtml("#FF9400D3");
            Graph_2.Render();
            CH2_Curve_Color_Select(7);
        }

        private void White_CH2_Curve_Color_Click(object sender, RoutedEventArgs e)
        {
            Channel_2_Curve.Color = System.Drawing.ColorTranslator.FromHtml("#FFFFFFFF");
            Graph_2.Render();
            CH2_Curve_Color_Select(8);
        }

        private void CH2_Curve_Color_Select(int Selected)
        {
            if (Selected == 0)
            {
                Green_CH2_Curve_Color.IsChecked = true;
            }
            else
            {
                Green_CH2_Curve_Color.IsChecked = false;
            }
            if (Selected == 1)
            {
                Blue_CH2_Curve_Color.IsChecked = true;
            }
            else
            {
                Blue_CH2_Curve_Color.IsChecked = false;
            }
            if (Selected == 2)
            {
                Red_CH2_Curve_Color.IsChecked = true;
            }
            else
            {
                Red_CH2_Curve_Color.IsChecked = false;
            }
            if (Selected == 3)
            {
                Yellow_CH2_Curve_Color.IsChecked = true;
            }
            else
            {
                Yellow_CH2_Curve_Color.IsChecked = false;
            }
            if (Selected == 4)
            {
                Orange_CH2_Curve_Color.IsChecked = true;
            }
            else
            {
                Orange_CH2_Curve_Color.IsChecked = false;
            }
            if (Selected == 5)
            {
                Black_CH2_Curve_Color.IsChecked = true;
            }
            else
            {
                Black_CH2_Curve_Color.IsChecked = false;
            }
            if (Selected == 6)
            {
                Pink_CH2_Curve_Color.IsChecked = true;
            }
            else
            {
                Pink_CH2_Curve_Color.IsChecked = false;
            }
            if (Selected == 7)
            {
                Violet_CH2_Curve_Color.IsChecked = true;
            }
            else
            {
                Violet_CH2_Curve_Color.IsChecked = false;
            }
            if (Selected == 8)
            {
                White_CH2_Curve_Color.IsChecked = true;
            }
            else
            {
                White_CH2_Curve_Color.IsChecked = false;
            }
        }

        //CH3 Curve Color
        private void Green_CH3_Curve_Color_Click(object sender, RoutedEventArgs e)
        {
            Channel_3_Curve.Color = System.Drawing.ColorTranslator.FromHtml("#00b33c");
            Graph_3.Render();
            CH3_Curve_Color_Select(0);
        }

        private void Blue_CH3_Curve_Color_Click(object sender, RoutedEventArgs e)
        {
            Channel_3_Curve.Color = System.Drawing.ColorTranslator.FromHtml("#0072BD");
            Graph_3.Render();
            CH3_Curve_Color_Select(1);
        }

        private void Red_CH3_Curve_Color_Click(object sender, RoutedEventArgs e)
        {
            Channel_3_Curve.Color = System.Drawing.ColorTranslator.FromHtml("#FFFF0000");
            Graph_3.Render();
            CH3_Curve_Color_Select(2);
        }

        private void Yellow_CH3_Curve_Color_Click(object sender, RoutedEventArgs e)
        {
            Channel_3_Curve.Color = System.Drawing.ColorTranslator.FromHtml("#FFFFFF00");
            Graph_3.Render();
            CH3_Curve_Color_Select(3);
        }

        private void Orange_CH3_Curve_Color_Click(object sender, RoutedEventArgs e)
        {
            Channel_3_Curve.Color = System.Drawing.ColorTranslator.FromHtml("#FFFF8C00");
            Graph_3.Render();
            CH3_Curve_Color_Select(4);
        }

        private void Black_CH3_Curve_Color_Click(object sender, RoutedEventArgs e)
        {
            Channel_3_Curve.Color = System.Drawing.ColorTranslator.FromHtml("#FF000000");
            Graph_3.Render();
            CH3_Curve_Color_Select(5);
        }

        private void Pink_CH3_Curve_Color_Click(object sender, RoutedEventArgs e)
        {
            Channel_3_Curve.Color = System.Drawing.ColorTranslator.FromHtml("#FFFF1493");
            Graph_3.Render();
            CH3_Curve_Color_Select(6);
        }

        private void Violet_CH3_Curve_Color_Click(object sender, RoutedEventArgs e)
        {
            Channel_3_Curve.Color = System.Drawing.ColorTranslator.FromHtml("#FF9400D3");
            Graph_3.Render();
            CH3_Curve_Color_Select(7);
        }

        private void White_CH3_Curve_Color_Click(object sender, RoutedEventArgs e)
        {
            Channel_3_Curve.Color = System.Drawing.ColorTranslator.FromHtml("#FFFFFFFF");
            Graph_3.Render();
            CH3_Curve_Color_Select(8);
        }

        private void CH3_Curve_Color_Select(int Selected)
        {
            if (Selected == 0)
            {
                Green_CH3_Curve_Color.IsChecked = true;
            }
            else
            {
                Green_CH3_Curve_Color.IsChecked = false;
            }
            if (Selected == 1)
            {
                Blue_CH3_Curve_Color.IsChecked = true;
            }
            else
            {
                Blue_CH3_Curve_Color.IsChecked = false;
            }
            if (Selected == 2)
            {
                Red_CH3_Curve_Color.IsChecked = true;
            }
            else
            {
                Red_CH3_Curve_Color.IsChecked = false;
            }
            if (Selected == 3)
            {
                Yellow_CH3_Curve_Color.IsChecked = true;
            }
            else
            {
                Yellow_CH3_Curve_Color.IsChecked = false;
            }
            if (Selected == 4)
            {
                Orange_CH3_Curve_Color.IsChecked = true;
            }
            else
            {
                Orange_CH3_Curve_Color.IsChecked = false;
            }
            if (Selected == 5)
            {
                Black_CH3_Curve_Color.IsChecked = true;
            }
            else
            {
                Black_CH3_Curve_Color.IsChecked = false;
            }
            if (Selected == 6)
            {
                Pink_CH3_Curve_Color.IsChecked = true;
            }
            else
            {
                Pink_CH3_Curve_Color.IsChecked = false;
            }
            if (Selected == 7)
            {
                Violet_CH3_Curve_Color.IsChecked = true;
            }
            else
            {
                Violet_CH3_Curve_Color.IsChecked = false;
            }
            if (Selected == 8)
            {
                White_CH3_Curve_Color.IsChecked = true;
            }
            else
            {
                White_CH3_Curve_Color.IsChecked = false;
            }
        }

        //CH4 Curve Color
        private void Green_CH4_Curve_Color_Click(object sender, RoutedEventArgs e)
        {
            Channel_4_Curve.Color = System.Drawing.ColorTranslator.FromHtml("#00b33c");
            Graph_4.Render();
            CH4_Curve_Color_Select(0);
        }

        private void Blue_CH4_Curve_Color_Click(object sender, RoutedEventArgs e)
        {
            Channel_4_Curve.Color = System.Drawing.ColorTranslator.FromHtml("#0072BD");
            Graph_4.Render();
            CH4_Curve_Color_Select(1);
        }

        private void Red_CH4_Curve_Color_Click(object sender, RoutedEventArgs e)
        {
            Channel_4_Curve.Color = System.Drawing.ColorTranslator.FromHtml("#FFFF0000");
            Graph_4.Render();
            CH4_Curve_Color_Select(2);
        }

        private void Yellow_CH4_Curve_Color_Click(object sender, RoutedEventArgs e)
        {
            Channel_4_Curve.Color = System.Drawing.ColorTranslator.FromHtml("#FFFFFF00");
            Graph_4.Render();
            CH4_Curve_Color_Select(3);
        }

        private void Orange_CH4_Curve_Color_Click(object sender, RoutedEventArgs e)
        {
            Channel_4_Curve.Color = System.Drawing.ColorTranslator.FromHtml("#FFFF8C00");
            Graph_4.Render();
            CH4_Curve_Color_Select(4);
        }

        private void Black_CH4_Curve_Color_Click(object sender, RoutedEventArgs e)
        {
            Channel_4_Curve.Color = System.Drawing.ColorTranslator.FromHtml("#FF000000");
            Graph_4.Render();
            CH4_Curve_Color_Select(5);
        }

        private void Pink_CH4_Curve_Color_Click(object sender, RoutedEventArgs e)
        {
            Channel_4_Curve.Color = System.Drawing.ColorTranslator.FromHtml("#FFFF1493");
            Graph_4.Render();
            CH4_Curve_Color_Select(6);
        }

        private void Violet_CH4_Curve_Color_Click(object sender, RoutedEventArgs e)
        {
            Channel_4_Curve.Color = System.Drawing.ColorTranslator.FromHtml("#FF9400D3");
            Graph_4.Render();
            CH4_Curve_Color_Select(7);
        }

        private void White_CH4_Curve_Color_Click(object sender, RoutedEventArgs e)
        {
            Channel_4_Curve.Color = System.Drawing.ColorTranslator.FromHtml("#FFFFFFFF");
            Graph_4.Render();
            CH4_Curve_Color_Select(8);
        }

        private void CH4_Curve_Color_Select(int Selected)
        {
            if (Selected == 0)
            {
                Green_CH4_Curve_Color.IsChecked = true;
            }
            else
            {
                Green_CH4_Curve_Color.IsChecked = false;
            }
            if (Selected == 1)
            {
                Blue_CH4_Curve_Color.IsChecked = true;
            }
            else
            {
                Blue_CH4_Curve_Color.IsChecked = false;
            }
            if (Selected == 2)
            {
                Red_CH4_Curve_Color.IsChecked = true;
            }
            else
            {
                Red_CH4_Curve_Color.IsChecked = false;
            }
            if (Selected == 3)
            {
                Yellow_CH4_Curve_Color.IsChecked = true;
            }
            else
            {
                Yellow_CH4_Curve_Color.IsChecked = false;
            }
            if (Selected == 4)
            {
                Orange_CH4_Curve_Color.IsChecked = true;
            }
            else
            {
                Orange_CH4_Curve_Color.IsChecked = false;
            }
            if (Selected == 5)
            {
                Black_CH4_Curve_Color.IsChecked = true;
            }
            else
            {
                Black_CH4_Curve_Color.IsChecked = false;
            }
            if (Selected == 6)
            {
                Pink_CH4_Curve_Color.IsChecked = true;
            }
            else
            {
                Pink_CH4_Curve_Color.IsChecked = false;
            }
            if (Selected == 7)
            {
                Violet_CH4_Curve_Color.IsChecked = true;
            }
            else
            {
                Violet_CH4_Curve_Color.IsChecked = false;
            }
            if (Selected == 8)
            {
                White_CH4_Curve_Color.IsChecked = true;
            }
            else
            {
                White_CH4_Curve_Color.IsChecked = false;
            }
        }

        //Waveform Marker Size
        private void Marker_Size_1_Click(object sender, RoutedEventArgs e)
        {
            Channel_1_Curve.MarkerSize = 1;
            Channel_2_Curve.MarkerSize = 1;
            Channel_3_Curve.MarkerSize = 1;
            Channel_4_Curve.MarkerSize = 1;
            Graph_1.Render();
            Graph_2.Render();
            Graph_3.Render();
            Graph_4.Render();
            Waveform_Marker_Size_Select(0);
        }

        private void Marker_Size_2_Click(object sender, RoutedEventArgs e)
        {
            Channel_1_Curve.MarkerSize = 2;
            Channel_2_Curve.MarkerSize = 2;
            Channel_3_Curve.MarkerSize = 2;
            Channel_4_Curve.MarkerSize = 2;
            Graph_1.Render();
            Graph_2.Render();
            Graph_3.Render();
            Graph_4.Render();
            Waveform_Marker_Size_Select(1);
        }

        private void Marker_Size_3_Click(object sender, RoutedEventArgs e)
        {
            Channel_1_Curve.MarkerSize = 3;
            Channel_2_Curve.MarkerSize = 3;
            Channel_3_Curve.MarkerSize = 3;
            Channel_4_Curve.MarkerSize = 3;
            Graph_1.Render();
            Graph_2.Render();
            Graph_3.Render();
            Graph_4.Render();
            Waveform_Marker_Size_Select(2);
        }

        private void Marker_Size_4_Click(object sender, RoutedEventArgs e)
        {
            Channel_1_Curve.MarkerSize = 4;
            Channel_2_Curve.MarkerSize = 4;
            Channel_3_Curve.MarkerSize = 4;
            Channel_4_Curve.MarkerSize = 4;
            Graph_1.Render();
            Graph_2.Render();
            Graph_3.Render();
            Graph_4.Render();
            Waveform_Marker_Size_Select(3);
        }

        private void Marker_Size_5_Click(object sender, RoutedEventArgs e)
        {
            Channel_1_Curve.MarkerSize = 5;
            Channel_2_Curve.MarkerSize = 5;
            Channel_3_Curve.MarkerSize = 5;
            Channel_4_Curve.MarkerSize = 5;
            Graph_1.Render();
            Graph_2.Render();
            Graph_3.Render();
            Graph_4.Render();
            Waveform_Marker_Size_Select(4);
        }

        private void Marker_Size_6_Click(object sender, RoutedEventArgs e)
        {
            Channel_1_Curve.MarkerSize = 6;
            Channel_2_Curve.MarkerSize = 6;
            Channel_3_Curve.MarkerSize = 6;
            Channel_4_Curve.MarkerSize = 6;
            Graph_1.Render();
            Graph_2.Render();
            Graph_3.Render();
            Graph_4.Render();
            Waveform_Marker_Size_Select(5);
        }

        private void Marker_Size_7_Click(object sender, RoutedEventArgs e)
        {
            Channel_1_Curve.MarkerSize = 7;
            Channel_2_Curve.MarkerSize = 7;
            Channel_3_Curve.MarkerSize = 7;
            Channel_4_Curve.MarkerSize = 7;
            Graph_1.Render();
            Graph_2.Render();
            Graph_3.Render();
            Graph_4.Render();
            Waveform_Marker_Size_Select(6);
        }

        private void Marker_Size_8_Click(object sender, RoutedEventArgs e)
        {
            Channel_1_Curve.MarkerSize = 8;
            Channel_2_Curve.MarkerSize = 8;
            Channel_3_Curve.MarkerSize = 8;
            Channel_4_Curve.MarkerSize = 8;
            Graph_1.Render();
            Graph_2.Render();
            Graph_3.Render();
            Graph_4.Render();
            Waveform_Marker_Size_Select(7);
        }

        private void Waveform_Marker_Size_Select(int Selected)
        {
            if (Selected == 0)
            {
                Marker_Size_1.IsChecked = true;
            }
            else
            {
                Marker_Size_1.IsChecked = false;
            }
            if (Selected == 1)
            {
                Marker_Size_2.IsChecked = true;
            }
            else
            {
                Marker_Size_2.IsChecked = false;
            }
            if (Selected == 2)
            {
                Marker_Size_3.IsChecked = true;
            }
            else
            {
                Marker_Size_3.IsChecked = false;
            }
            if (Selected == 3)
            {
                Marker_Size_4.IsChecked = true;
            }
            else
            {
                Marker_Size_4.IsChecked = false;
            }
            if (Selected == 4)
            {
                Marker_Size_5.IsChecked = true;
            }
            else
            {
                Marker_Size_5.IsChecked = false;
            }
            if (Selected == 5)
            {
                Marker_Size_6.IsChecked = true;
            }
            else
            {
                Marker_Size_6.IsChecked = false;
            }
            if (Selected == 6)
            {
                Marker_Size_7.IsChecked = true;
            }
            else
            {
                Marker_Size_7.IsChecked = false;
            }
            if (Selected == 7)
            {
                Marker_Size_8.IsChecked = true;
            }
            else
            {
                Marker_Size_8.IsChecked = false;
            }
        }

        //Waveform Line Style
        private void Line_Style_Solid_Click(object sender, RoutedEventArgs e)
        {
            Channel_1_Curve.LineStyle = ScottPlot.LineStyle.Solid;
            Channel_2_Curve.LineStyle = ScottPlot.LineStyle.Solid;
            Channel_3_Curve.LineStyle = ScottPlot.LineStyle.Solid;
            Channel_4_Curve.LineStyle = ScottPlot.LineStyle.Solid;
            Graph_1.Render();
            Graph_2.Render();
            Graph_3.Render();
            Graph_4.Render();
            Line_Style_Select(0);
        }

        private void Line_Style_Dotted_Click(object sender, RoutedEventArgs e)
        {
            Channel_1_Curve.LineStyle = ScottPlot.LineStyle.Dot;
            Channel_2_Curve.LineStyle = ScottPlot.LineStyle.Dot;
            Channel_3_Curve.LineStyle = ScottPlot.LineStyle.Dot;
            Channel_4_Curve.LineStyle = ScottPlot.LineStyle.Dot;
            Graph_1.Render();
            Graph_2.Render();
            Graph_3.Render();
            Graph_4.Render();
            Line_Style_Select(1);
        }

        private void Line_Style_DashDot_Click(object sender, RoutedEventArgs e)
        {
            Channel_1_Curve.LineStyle = ScottPlot.LineStyle.DashDot;
            Channel_2_Curve.LineStyle = ScottPlot.LineStyle.DashDot;
            Channel_3_Curve.LineStyle = ScottPlot.LineStyle.DashDot;
            Channel_4_Curve.LineStyle = ScottPlot.LineStyle.DashDot;
            Graph_1.Render();
            Graph_2.Render();
            Graph_3.Render();
            Graph_4.Render();
            Line_Style_Select(2);
        }

        private void Line_Style_Dash_Click(object sender, RoutedEventArgs e)
        {
            Channel_1_Curve.LineStyle = ScottPlot.LineStyle.Dash;
            Channel_2_Curve.LineStyle = ScottPlot.LineStyle.Dash;
            Channel_3_Curve.LineStyle = ScottPlot.LineStyle.Dash;
            Channel_4_Curve.LineStyle = ScottPlot.LineStyle.Dash;
            Graph_1.Render();
            Graph_2.Render();
            Graph_3.Render();
            Graph_4.Render();
            Line_Style_Select(3);
        }

        private void Line_Style_Select(int Selected)
        {
            if (Selected == 0)
            {
                Line_Style_Solid.IsChecked = true;
            }
            else
            {
                Line_Style_Solid.IsChecked = false;
            }
            if (Selected == 1)
            {
                Line_Style_Dotted.IsChecked = true;
            }
            else
            {
                Line_Style_Dotted.IsChecked = false;
            }
            if (Selected == 2)
            {
                Line_Style_DashDot.IsChecked = true;
            }
            else
            {
                Line_Style_DashDot.IsChecked = false;
            }
            if (Selected == 3)
            {
                Line_Style_Dash.IsChecked = true;
            }
            else
            {
                Line_Style_Dash.IsChecked = false;
            }
        }

        //Waveform Line Size
        private void Line_Width_1_Click(object sender, RoutedEventArgs e)
        {
            Channel_1_Curve.LineWidth = 1;
            Channel_2_Curve.LineWidth = 1;
            Channel_3_Curve.LineWidth = 1;
            Channel_4_Curve.LineWidth = 1;
            Graph_1.Render();
            Graph_2.Render();
            Graph_3.Render();
            Graph_4.Render();
            Line_Width_Select(1);
        }

        private void Line_Width_2_Click(object sender, RoutedEventArgs e)
        {
            Channel_1_Curve.LineWidth = 2;
            Channel_2_Curve.LineWidth = 2;
            Channel_3_Curve.LineWidth = 2;
            Channel_4_Curve.LineWidth = 2;
            Graph_1.Render();
            Graph_2.Render();
            Graph_3.Render();
            Graph_4.Render();
            Line_Width_Select(2);
        }

        private void Line_Width_3_Click(object sender, RoutedEventArgs e)
        {
            Channel_1_Curve.LineWidth = 3;
            Channel_2_Curve.LineWidth = 3;
            Channel_3_Curve.LineWidth = 3;
            Channel_4_Curve.LineWidth = 3;
            Graph_1.Render();
            Graph_2.Render();
            Graph_3.Render();
            Graph_4.Render();
            Line_Width_Select(3);
        }

        private void Line_Width_4_Click(object sender, RoutedEventArgs e)
        {
            Channel_1_Curve.LineWidth = 4;
            Channel_2_Curve.LineWidth = 4;
            Channel_3_Curve.LineWidth = 4;
            Channel_4_Curve.LineWidth = 4;
            Graph_1.Render();
            Graph_2.Render();
            Graph_3.Render();
            Graph_4.Render();
            Line_Width_Select(4);
        }

        private void Line_Width_5_Click(object sender, RoutedEventArgs e)
        {
            Channel_1_Curve.LineWidth = 5;
            Channel_2_Curve.LineWidth = 5;
            Channel_3_Curve.LineWidth = 5;
            Channel_4_Curve.LineWidth = 5;
            Graph_1.Render();
            Graph_2.Render();
            Graph_3.Render();
            Graph_4.Render();
            Line_Width_Select(5);
        }

        private void Line_Width_6_Click(object sender, RoutedEventArgs e)
        {
            Channel_1_Curve.LineWidth = 6;
            Channel_2_Curve.LineWidth = 6;
            Channel_3_Curve.LineWidth = 6;
            Channel_4_Curve.LineWidth = 6;
            Graph_1.Render();
            Graph_2.Render();
            Graph_3.Render();
            Graph_4.Render();
            Line_Width_Select(6);
        }

        private void Line_Width_7_Click(object sender, RoutedEventArgs e)
        {
            Channel_1_Curve.LineWidth = 7;
            Channel_2_Curve.LineWidth = 7;
            Channel_3_Curve.LineWidth = 7;
            Channel_4_Curve.LineWidth = 7;
            Graph_1.Render();
            Graph_2.Render();
            Graph_3.Render();
            Graph_4.Render();
            Line_Width_Select(7);
        }

        private void Line_Width_Select(int Selected)
        {
            if (Selected == 1)
            {
                Line_Width_1.IsChecked = true;
            }
            else
            {
                Line_Width_1.IsChecked = false;
            }
            if (Selected == 2)
            {
                Line_Width_2.IsChecked = true;
            }
            else
            {
                Line_Width_2.IsChecked = false;
            }
            if (Selected == 3)
            {
                Line_Width_3.IsChecked = true;
            }
            else
            {
                Line_Width_3.IsChecked = false;
            }
            if (Selected == 4)
            {
                Line_Width_4.IsChecked = true;
            }
            else
            {
                Line_Width_4.IsChecked = false;
            }
            if (Selected == 5)
            {
                Line_Width_5.IsChecked = true;
            }
            else
            {
                Line_Width_5.IsChecked = false;
            }
            if (Selected == 6)
            {
                Line_Width_6.IsChecked = true;
            }
            else
            {
                Line_Width_6.IsChecked = false;
            }
            if (Selected == 7)
            {
                Line_Width_7.IsChecked = true;
            }
            else
            {
                Line_Width_7.IsChecked = false;
            }
        }
    }
}
