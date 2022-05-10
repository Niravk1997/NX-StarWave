using MahApps.Metro.Controls;
using System.Windows;

namespace XY
{
    public partial class XY_Plotter : MetroWindow
    {
        //Waveform Curve Color
        private void Green_Waveform_Curve_Color_Click(object sender, RoutedEventArgs e)
        {
            Waveform_Curve.Color = System.Drawing.ColorTranslator.FromHtml("#29a329");
            Graph.Render();
            Waveform_Curve_Color_Select(0);
        }

        private void Blue_Waveform_Curve_Color_Click(object sender, RoutedEventArgs e)
        {
            Waveform_Curve.Color = System.Drawing.ColorTranslator.FromHtml("#0072BD");
            Graph.Render();
            Waveform_Curve_Color_Select(1);
        }

        private void Red_Waveform_Curve_Color_Click(object sender, RoutedEventArgs e)
        {
            Waveform_Curve.Color = System.Drawing.ColorTranslator.FromHtml("#FFFF0000");
            Graph.Render();
            Waveform_Curve_Color_Select(2);
        }

        private void Yellow_Waveform_Curve_Color_Click(object sender, RoutedEventArgs e)
        {
            Waveform_Curve.Color = System.Drawing.ColorTranslator.FromHtml("#FFFFFF00");
            Graph.Render();
            Waveform_Curve_Color_Select(3);
        }

        private void Orange_Waveform_Curve_Color_Click(object sender, RoutedEventArgs e)
        {
            Waveform_Curve.Color = System.Drawing.ColorTranslator.FromHtml("#FFFF8C00");
            Graph.Render();
            Waveform_Curve_Color_Select(4);
        }

        private void Black_Waveform_Curve_Color_Click(object sender, RoutedEventArgs e)
        {
            Waveform_Curve.Color = System.Drawing.ColorTranslator.FromHtml("#FF000000");
            Graph.Render();
            Waveform_Curve_Color_Select(5);
        }

        private void Pink_Waveform_Curve_Color_Click(object sender, RoutedEventArgs e)
        {
            Waveform_Curve.Color = System.Drawing.ColorTranslator.FromHtml("#FFFF1493");
            Graph.Render();
            Waveform_Curve_Color_Select(6);
        }

        private void Violet_Waveform_Curve_Color_Click(object sender, RoutedEventArgs e)
        {
            Waveform_Curve.Color = System.Drawing.ColorTranslator.FromHtml("#FF9400D3");
            Graph.Render();
            Waveform_Curve_Color_Select(7);
        }

        private void White_Waveform_Curve_Color_Click(object sender, RoutedEventArgs e)
        {
            Waveform_Curve.Color = System.Drawing.ColorTranslator.FromHtml("#FFFFFFFF");
            Graph.Render();
            Waveform_Curve_Color_Select(8);
        }

        private void Waveform_Curve_Color_Select(int Selected)
        {
            if (Selected == 0)
            {
                Green_Waveform_Curve_Color.IsChecked = true;
            }
            else
            {
                Green_Waveform_Curve_Color.IsChecked = false;
            }
            if (Selected == 1)
            {
                Blue_Waveform_Curve_Color.IsChecked = true;
            }
            else
            {
                Blue_Waveform_Curve_Color.IsChecked = false;
            }
            if (Selected == 2)
            {
                Red_Waveform_Curve_Color.IsChecked = true;
            }
            else
            {
                Red_Waveform_Curve_Color.IsChecked = false;
            }
            if (Selected == 3)
            {
                Yellow_Waveform_Curve_Color.IsChecked = true;
            }
            else
            {
                Yellow_Waveform_Curve_Color.IsChecked = false;
            }
            if (Selected == 4)
            {
                Orange_Waveform_Curve_Color.IsChecked = true;
            }
            else
            {
                Orange_Waveform_Curve_Color.IsChecked = false;
            }
            if (Selected == 5)
            {
                Black_Waveform_Curve_Color.IsChecked = true;
            }
            else
            {
                Black_Waveform_Curve_Color.IsChecked = false;
            }
            if (Selected == 6)
            {
                Pink_Waveform_Curve_Color.IsChecked = true;
            }
            else
            {
                Pink_Waveform_Curve_Color.IsChecked = false;
            }
            if (Selected == 7)
            {
                Violet_Waveform_Curve_Color.IsChecked = true;
            }
            else
            {
                Violet_Waveform_Curve_Color.IsChecked = false;
            }
            if (Selected == 8)
            {
                White_Waveform_Curve_Color.IsChecked = true;
            }
            else
            {
                White_Waveform_Curve_Color.IsChecked = false;
            }
        }

        //Waveform Marker Type
        private void None_Marker_Type_Click(object sender, RoutedEventArgs e)
        {
            Waveform_Curve.MarkerShape = ScottPlot.MarkerShape.none;
            Graph.Render();
            Waveform_Marker_Type_Select(0);
        }

        private void Circle_Marker_Type_Click(object sender, RoutedEventArgs e)
        {
            Waveform_Curve.MarkerShape = ScottPlot.MarkerShape.filledCircle;
            Graph.Render();
            Waveform_Marker_Type_Select(1);
        }

        private void Square_Marker_Type_Click(object sender, RoutedEventArgs e)
        {
            Waveform_Curve.MarkerShape = ScottPlot.MarkerShape.filledSquare;
            Graph.Render();
            Waveform_Marker_Type_Select(2);
        }

        private void Diamond_Marker_Type_Click(object sender, RoutedEventArgs e)
        {
            Waveform_Curve.MarkerShape = ScottPlot.MarkerShape.filledDiamond;
            Graph.Render();
            Waveform_Marker_Type_Select(3);
        }

        private void Cross_Marker_Type_Click(object sender, RoutedEventArgs e)
        {
            Waveform_Curve.MarkerShape = ScottPlot.MarkerShape.eks;
            Graph.Render();
            Waveform_Marker_Type_Select(4);
        }

        private void VerticalBar_Marker_Type_Click(object sender, RoutedEventArgs e)
        {
            Waveform_Curve.MarkerShape = ScottPlot.MarkerShape.verticalBar;
            Graph.Render();
            Waveform_Marker_Type_Select(5);
        }

        private void TriUp_Marker_Type_Click(object sender, RoutedEventArgs e)
        {
            Waveform_Curve.MarkerShape = ScottPlot.MarkerShape.triUp;
            Graph.Render();
            Waveform_Marker_Type_Select(6);
        }

        private void TriDown_Marker_Type_Click(object sender, RoutedEventArgs e)
        {
            Waveform_Curve.MarkerShape = ScottPlot.MarkerShape.triDown;
            Graph.Render();
            Waveform_Marker_Type_Select(7);
        }

        private void Waveform_Marker_Type_Select(int Selected)
        {
            if (Selected == 0)
            {
                None_Marker_Type.IsChecked = true;
            }
            else
            {
                None_Marker_Type.IsChecked = false;
            }
            if (Selected == 1)
            {
                Circle_Marker_Type.IsChecked = true;
            }
            else
            {
                Circle_Marker_Type.IsChecked = false;
            }
            if (Selected == 2)
            {
                Square_Marker_Type.IsChecked = true;
            }
            else
            {
                Square_Marker_Type.IsChecked = false;
            }
            if (Selected == 3)
            {
                Diamond_Marker_Type.IsChecked = true;
            }
            else
            {
                Diamond_Marker_Type.IsChecked = false;
            }
            if (Selected == 4)
            {
                Cross_Marker_Type.IsChecked = true;
            }
            else
            {
                Cross_Marker_Type.IsChecked = false;
            }
            if (Selected == 5)
            {
                VerticalBar_Marker_Type.IsChecked = true;
            }
            else
            {
                VerticalBar_Marker_Type.IsChecked = false;
            }
            if (Selected == 6)
            {
                TriUp_Marker_Type.IsChecked = true;
            }
            else
            {
                TriUp_Marker_Type.IsChecked = false;
            }
            if (Selected == 7)
            {
                TriDown_Marker_Type.IsChecked = true;
            }
            else
            {
                TriDown_Marker_Type.IsChecked = false;
            }
        }

        //Waveform Marker Size
        private void Marker_Size_1_Click(object sender, RoutedEventArgs e)
        {
            Waveform_Curve.MarkerSize = 1;
            Graph.Render();
            Waveform_Marker_Size_Select(0);
        }

        private void Marker_Size_2_Click(object sender, RoutedEventArgs e)
        {
            Waveform_Curve.MarkerSize = 2;
            Graph.Render();
            Waveform_Marker_Size_Select(1);
        }

        private void Marker_Size_3_Click(object sender, RoutedEventArgs e)
        {
            Waveform_Curve.MarkerSize = 3;
            Graph.Render();
            Waveform_Marker_Size_Select(2);
        }

        private void Marker_Size_4_Click(object sender, RoutedEventArgs e)
        {
            Waveform_Curve.MarkerSize = 4;
            Graph.Render();
            Waveform_Marker_Size_Select(3);
        }

        private void Marker_Size_5_Click(object sender, RoutedEventArgs e)
        {
            Waveform_Curve.MarkerSize = 5;
            Graph.Render();
            Waveform_Marker_Size_Select(4);
        }

        private void Marker_Size_6_Click(object sender, RoutedEventArgs e)
        {
            Waveform_Curve.MarkerSize = 6;
            Graph.Render();
            Waveform_Marker_Size_Select(5);
        }

        private void Marker_Size_7_Click(object sender, RoutedEventArgs e)
        {
            Waveform_Curve.MarkerSize = 7;
            Graph.Render();
            Waveform_Marker_Size_Select(6);
        }

        private void Marker_Size_8_Click(object sender, RoutedEventArgs e)
        {
            Waveform_Curve.MarkerSize = 8;
            Graph.Render();
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
            Waveform_Curve.LineStyle = ScottPlot.LineStyle.Solid;
            Graph.Render();
            Line_Style_Select(0);
        }

        private void Line_Style_Dotted_Click(object sender, RoutedEventArgs e)
        {
            Waveform_Curve.LineStyle = ScottPlot.LineStyle.Dot;
            Graph.Render();
            Line_Style_Select(1);
        }

        private void Line_Style_DashDot_Click(object sender, RoutedEventArgs e)
        {
            Waveform_Curve.LineStyle = ScottPlot.LineStyle.DashDot;
            Graph.Render();
            Line_Style_Select(2);
        }

        private void Line_Style_None_Click(object sender, RoutedEventArgs e)
        {
            Waveform_Curve.LineStyle = ScottPlot.LineStyle.None;
            Graph.Render();
            Line_Style_Select(3);
        }

        private void Line_Style_Dash_Click(object sender, RoutedEventArgs e)
        {
            Waveform_Curve.LineStyle = ScottPlot.LineStyle.Dash;
            Graph.Render();
            Line_Style_Select(4);
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
                Line_Style_None.IsChecked = true;
            }
            else
            {
                Line_Style_None.IsChecked = false;
            }
            if (Selected == 4)
            {
                Line_Style_Dash.IsChecked = true;
            }
            else
            {
                Line_Style_Dash.IsChecked = false;
            }
        }

        //Waveform Line Size
        private void Line_Width_0_Click(object sender, RoutedEventArgs e)
        {
            Waveform_Curve.LineWidth = 0;
            Graph.Render();
            Line_Width_Select(0);
        }

        private void Line_Width_1_Click(object sender, RoutedEventArgs e)
        {
            Waveform_Curve.LineWidth = 1;
            Graph.Render();
            Line_Width_Select(1);
        }

        private void Line_Width_2_Click(object sender, RoutedEventArgs e)
        {
            Waveform_Curve.LineWidth = 2;
            Graph.Render();
            Line_Width_Select(2);
        }

        private void Line_Width_3_Click(object sender, RoutedEventArgs e)
        {
            Waveform_Curve.LineWidth = 3;
            Graph.Render();
            Line_Width_Select(3);
        }

        private void Line_Width_4_Click(object sender, RoutedEventArgs e)
        {
            Waveform_Curve.LineWidth = 4;
            Graph.Render();
            Line_Width_Select(4);
        }

        private void Line_Width_5_Click(object sender, RoutedEventArgs e)
        {
            Waveform_Curve.LineWidth = 5;
            Graph.Render();
            Line_Width_Select(5);
        }

        private void Line_Width_6_Click(object sender, RoutedEventArgs e)
        {
            Waveform_Curve.LineWidth = 6;
            Graph.Render();
            Line_Width_Select(6);
        }

        private void Line_Width_7_Click(object sender, RoutedEventArgs e)
        {
            Waveform_Curve.LineWidth = 7;
            Graph.Render();
            Line_Width_Select(7);
        }

        private void Line_Width_Select(int Selected)
        {
            if (Selected == 0)
            {
                Line_Width_0.IsChecked = true;
            }
            else
            {
                Line_Width_0.IsChecked = false;
            }
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
