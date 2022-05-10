using MahApps.Metro.Controls;
using System.Windows;

namespace FFT
{
    public partial class FFT_Plotter : MetroWindow
    {
        private double Phase_dB_Magnitude_suppression_Value = -35;
        private bool isPhase_Degrees = true;
        private string Phase_Y_AXIS_Label = "Phase (Degrees)";

        private void Show_Phase_Option_Click(object sender, RoutedEventArgs e)
        {
            if (Calculate_Phase)
            {
                Graph.Plot.YAxis2.Ticks(true);
                Graph.Plot.YAxis2.Label(Phase_Y_AXIS_Label);
                Phase_Waveform.IsVisible = true;
                Manual_Graph_Render();
            }
            else
            {
                Graph.Plot.YAxis2.Ticks(false);
                Graph.Plot.YAxis2.Label(string.Empty);
                Phase_Waveform.IsVisible = false;
                Manual_Graph_Render();
            }
        }

        private void Phase_Scale_Degrees_Option_Button_Click(object sender, RoutedEventArgs e)
        {
            if (Phase_Scale_Degrees_Option.IsChecked)
            {
                isPhase_Degrees = true;
                Phase_Scale_Radians_Option.IsChecked = false;
                Phase_Y_AXIS_Label = "Phase (Degrees)";
                if (Calculate_Phase)
                {
                    Graph.Plot.YAxis2.Label(Phase_Y_AXIS_Label);
                }
            }
            else
            {
                isPhase_Degrees = false;
                Phase_Scale_Radians_Option.IsChecked = true;
                Phase_Y_AXIS_Label = "Phase (Radians)";
                if (Calculate_Phase)
                {
                    Graph.Plot.YAxis2.Label(Phase_Y_AXIS_Label);
                }
            }
        }

        private void Phase_Scale_Radians_Option_Button_Click(object sender, RoutedEventArgs e)
        {
            if (Phase_Scale_Radians_Option.IsChecked)
            {
                isPhase_Degrees = false;
                Phase_Scale_Degrees_Option.IsChecked = false;
                Phase_Y_AXIS_Label = "Phase (Radians)";
                if (Calculate_Phase)
                {
                    Graph.Plot.YAxis2.Label(Phase_Y_AXIS_Label);
                }
            }
            else
            {
                isPhase_Degrees = true;
                Phase_Scale_Degrees_Option.IsChecked = true;
                Phase_Y_AXIS_Label = "Phase (Degrees)";
                if (Calculate_Phase)
                {
                    Graph.Plot.YAxis2.Label(Phase_Y_AXIS_Label);
                }
            }
        }

        private void Phase_Suppresion_SetValue_Button_Click(object sender, RoutedEventArgs e)
        {
            (bool isValid, double Value) = Functions.Text_Num(Phase_Suppresion_Value_Text.Text, true, false);
            if (isValid)
            {
                Phase_dB_Magnitude_suppression_Value = Value;
                Insert_Log("Phase Magnitude(dB) Suppression Value set to " + Phase_dB_Magnitude_suppression_Value, 0);
                Output_Log_Tab.IsSelected = true;
            }
            else
            {
                Insert_Log("Could not set Phase Suppression Magnitude(dB) Value. Try again.", 2);
                Insert_Log("Phase Suppression Magnitude(dB) Value must be a valid number.", 2);
                Output_Log_Tab.IsSelected = true;
            }
        }

        //Waveform Curve Color
        private void Phase_Green_Waveform_Curve_Color_Click(object sender, RoutedEventArgs e)
        {
            Phase_Waveform.Color = System.Drawing.ColorTranslator.FromHtml("#FF00FF17");
            Graph.Render();
            Phase_Waveform_Curve_Color_Select(0);
        }

        private void Phase_Blue_Waveform_Curve_Color_Click(object sender, RoutedEventArgs e)
        {
            Phase_Waveform.Color = System.Drawing.ColorTranslator.FromHtml("#0072BD");
            Graph.Render();
            Phase_Waveform_Curve_Color_Select(1);
        }

        private void Phase_Red_Waveform_Curve_Color_Click(object sender, RoutedEventArgs e)
        {
            Phase_Waveform.Color = System.Drawing.ColorTranslator.FromHtml("#FFFF0000");
            Graph.Render();
            Phase_Waveform_Curve_Color_Select(2);
        }

        private void Phase_Yellow_Waveform_Curve_Color_Click(object sender, RoutedEventArgs e)
        {
            Phase_Waveform.Color = System.Drawing.ColorTranslator.FromHtml("#FFFFFF00");
            Graph.Render();
            Phase_Waveform_Curve_Color_Select(3);
        }

        private void Phase_Orange_Waveform_Curve_Color_Click(object sender, RoutedEventArgs e)
        {
            Phase_Waveform.Color = System.Drawing.ColorTranslator.FromHtml("#FFFF8C00");
            Graph.Render();
            Phase_Waveform_Curve_Color_Select(4);
        }

        private void Phase_Black_Waveform_Curve_Color_Click(object sender, RoutedEventArgs e)
        {
            Phase_Waveform.Color = System.Drawing.ColorTranslator.FromHtml("#FF000000");
            Graph.Render();
            Phase_Waveform_Curve_Color_Select(5);
        }

        private void Phase_Pink_Waveform_Curve_Color_Click(object sender, RoutedEventArgs e)
        {
            Phase_Waveform.Color = System.Drawing.ColorTranslator.FromHtml("#FFFF1493");
            Graph.Render();
            Phase_Waveform_Curve_Color_Select(6);
        }

        private void Phase_Violet_Waveform_Curve_Color_Click(object sender, RoutedEventArgs e)
        {
            Phase_Waveform.Color = System.Drawing.ColorTranslator.FromHtml("#FF9400D3");
            Graph.Render();
            Phase_Waveform_Curve_Color_Select(7);
        }

        private void Phase_White_Waveform_Curve_Color_Click(object sender, RoutedEventArgs e)
        {
            Phase_Waveform.Color = System.Drawing.ColorTranslator.FromHtml("#FFFFFFFF");
            Graph.Render();
            Phase_Waveform_Curve_Color_Select(8);
        }

        private void Phase_Waveform_Curve_Color_Select(int Selected)
        {
            if (Selected == 0)
            {
                Phase_Green_Waveform_Curve_Color.IsChecked = true;
            }
            else
            {
                Phase_Green_Waveform_Curve_Color.IsChecked = false;
            }
            if (Selected == 1)
            {
                Phase_Blue_Waveform_Curve_Color.IsChecked = true;
            }
            else
            {
                Phase_Blue_Waveform_Curve_Color.IsChecked = false;
            }
            if (Selected == 2)
            {
                Phase_Red_Waveform_Curve_Color.IsChecked = true;
            }
            else
            {
                Phase_Red_Waveform_Curve_Color.IsChecked = false;
            }
            if (Selected == 3)
            {
                Phase_Yellow_Waveform_Curve_Color.IsChecked = true;
            }
            else
            {
                Phase_Yellow_Waveform_Curve_Color.IsChecked = false;
            }
            if (Selected == 4)
            {
                Phase_Orange_Waveform_Curve_Color.IsChecked = true;
            }
            else
            {
                Phase_Orange_Waveform_Curve_Color.IsChecked = false;
            }
            if (Selected == 5)
            {
                Phase_Black_Waveform_Curve_Color.IsChecked = true;
            }
            else
            {
                Phase_Black_Waveform_Curve_Color.IsChecked = false;
            }
            if (Selected == 6)
            {
                Phase_Pink_Waveform_Curve_Color.IsChecked = true;
            }
            else
            {
                Phase_Pink_Waveform_Curve_Color.IsChecked = false;
            }
            if (Selected == 7)
            {
                Phase_Violet_Waveform_Curve_Color.IsChecked = true;
            }
            else
            {
                Phase_Violet_Waveform_Curve_Color.IsChecked = false;
            }
            if (Selected == 8)
            {
                Phase_White_Waveform_Curve_Color.IsChecked = true;
            }
            else
            {
                Phase_White_Waveform_Curve_Color.IsChecked = false;
            }
        }

        //Waveform Marker Size
        private void Phase_Marker_Size_1_Click(object sender, RoutedEventArgs e)
        {
            Phase_Waveform.MarkerSize = 1;
            Graph.Render();
            Phase_Waveform_Marker_Size_Select(0);
        }

        private void Phase_Marker_Size_2_Click(object sender, RoutedEventArgs e)
        {
            Phase_Waveform.MarkerSize = 2;
            Graph.Render();
            Phase_Waveform_Marker_Size_Select(1);
        }

        private void Phase_Marker_Size_3_Click(object sender, RoutedEventArgs e)
        {
            Phase_Waveform.MarkerSize = 3;
            Graph.Render();
            Phase_Waveform_Marker_Size_Select(2);
        }

        private void Phase_Marker_Size_4_Click(object sender, RoutedEventArgs e)
        {
            Phase_Waveform.MarkerSize = 4;
            Graph.Render();
            Phase_Waveform_Marker_Size_Select(3);
        }

        private void Phase_Marker_Size_5_Click(object sender, RoutedEventArgs e)
        {
            Phase_Waveform.MarkerSize = 5;
            Graph.Render();
            Phase_Waveform_Marker_Size_Select(4);
        }

        private void Phase_Marker_Size_6_Click(object sender, RoutedEventArgs e)
        {
            Phase_Waveform.MarkerSize = 6;
            Graph.Render();
            Phase_Waveform_Marker_Size_Select(5);
        }

        private void Phase_Marker_Size_7_Click(object sender, RoutedEventArgs e)
        {
            Phase_Waveform.MarkerSize = 7;
            Graph.Render();
            Phase_Waveform_Marker_Size_Select(6);
        }

        private void Phase_Marker_Size_8_Click(object sender, RoutedEventArgs e)
        {
            Phase_Waveform.MarkerSize = 8;
            Graph.Render();
            Phase_Waveform_Marker_Size_Select(7);
        }

        private void Phase_Waveform_Marker_Size_Select(int Selected)
        {
            if (Selected == 0)
            {
                Phase_Marker_Size_1.IsChecked = true;
            }
            else
            {
                Phase_Marker_Size_1.IsChecked = false;
            }
            if (Selected == 1)
            {
                Phase_Marker_Size_2.IsChecked = true;
            }
            else
            {
                Phase_Marker_Size_2.IsChecked = false;
            }
            if (Selected == 2)
            {
                Phase_Marker_Size_3.IsChecked = true;
            }
            else
            {
                Phase_Marker_Size_3.IsChecked = false;
            }
            if (Selected == 3)
            {
                Phase_Marker_Size_4.IsChecked = true;
            }
            else
            {
                Phase_Marker_Size_4.IsChecked = false;
            }
            if (Selected == 4)
            {
                Phase_Marker_Size_5.IsChecked = true;
            }
            else
            {
                Phase_Marker_Size_5.IsChecked = false;
            }
            if (Selected == 5)
            {
                Phase_Marker_Size_6.IsChecked = true;
            }
            else
            {
                Phase_Marker_Size_6.IsChecked = false;
            }
            if (Selected == 6)
            {
                Phase_Marker_Size_7.IsChecked = true;
            }
            else
            {
                Phase_Marker_Size_7.IsChecked = false;
            }
            if (Selected == 7)
            {
                Phase_Marker_Size_8.IsChecked = true;
            }
            else
            {
                Phase_Marker_Size_8.IsChecked = false;
            }
        }

        //Waveform Line Style
        private void Phase_Line_Style_Solid_Click(object sender, RoutedEventArgs e)
        {
            Phase_Waveform.LineStyle = ScottPlot.LineStyle.Solid;
            Graph.Render();
            Phase_Line_Style_Select(0);
        }

        private void Phase_Line_Style_Dotted_Click(object sender, RoutedEventArgs e)
        {
            Phase_Waveform.LineStyle = ScottPlot.LineStyle.Dot;
            Graph.Render();
            Phase_Line_Style_Select(1);
        }

        private void Phase_Line_Style_DashDot_Click(object sender, RoutedEventArgs e)
        {
            Phase_Waveform.LineStyle = ScottPlot.LineStyle.DashDot;
            Graph.Render();
            Phase_Line_Style_Select(2);
        }

        private void Phase_Line_Style_Dash_Click(object sender, RoutedEventArgs e)
        {
            Phase_Waveform.LineStyle = ScottPlot.LineStyle.Dash;
            Graph.Render();
            Phase_Line_Style_Select(4);
        }

        private void Phase_Line_Style_Select(int Selected)
        {
            if (Selected == 0)
            {
                Phase_Line_Style_Solid.IsChecked = true;
            }
            else
            {
                Phase_Line_Style_Solid.IsChecked = false;
            }
            if (Selected == 1)
            {
                Phase_Line_Style_Dotted.IsChecked = true;
            }
            else
            {
                Phase_Line_Style_Dotted.IsChecked = false;
            }
            if (Selected == 2)
            {
                Phase_Line_Style_DashDot.IsChecked = true;
            }
            else
            {
                Phase_Line_Style_DashDot.IsChecked = false;
            }

            if (Selected == 4)
            {
                Phase_Line_Style_Dash.IsChecked = true;
            }
            else
            {
                Phase_Line_Style_Dash.IsChecked = false;
            }
        }

        //Waveform Line Size

        private void Phase_Line_Width_1_Click(object sender, RoutedEventArgs e)
        {
            Phase_Waveform.LineWidth = 1;
            Graph.Render();
            Phase_Line_Width_Select(1);
        }

        private void Phase_Line_Width_2_Click(object sender, RoutedEventArgs e)
        {
            Phase_Waveform.LineWidth = 2;
            Graph.Render();
            Phase_Line_Width_Select(2);
        }

        private void Phase_Line_Width_3_Click(object sender, RoutedEventArgs e)
        {
            Phase_Waveform.LineWidth = 3;
            Graph.Render();
            Phase_Line_Width_Select(3);
        }

        private void Phase_Line_Width_4_Click(object sender, RoutedEventArgs e)
        {
            Phase_Waveform.LineWidth = 4;
            Graph.Render();
            Phase_Line_Width_Select(4);
        }

        private void Phase_Line_Width_5_Click(object sender, RoutedEventArgs e)
        {
            Phase_Waveform.LineWidth = 5;
            Graph.Render();
            Phase_Line_Width_Select(5);
        }

        private void Phase_Line_Width_6_Click(object sender, RoutedEventArgs e)
        {
            Phase_Waveform.LineWidth = 6;
            Graph.Render();
            Phase_Line_Width_Select(6);
        }

        private void Phase_Line_Width_7_Click(object sender, RoutedEventArgs e)
        {
            Phase_Waveform.LineWidth = 7;
            Graph.Render();
            Phase_Line_Width_Select(7);
        }

        private void Phase_Line_Width_Select(int Selected)
        {
            if (Selected == 1)
            {
                Phase_Line_Width_1.IsChecked = true;
            }
            else
            {
                Phase_Line_Width_1.IsChecked = false;
            }
            if (Selected == 2)
            {
                Phase_Line_Width_2.IsChecked = true;
            }
            else
            {
                Phase_Line_Width_2.IsChecked = false;
            }
            if (Selected == 3)
            {
                Phase_Line_Width_3.IsChecked = true;
            }
            else
            {
                Phase_Line_Width_3.IsChecked = false;
            }
            if (Selected == 4)
            {
                Phase_Line_Width_4.IsChecked = true;
            }
            else
            {
                Phase_Line_Width_4.IsChecked = false;
            }
            if (Selected == 5)
            {
                Phase_Line_Width_5.IsChecked = true;
            }
            else
            {
                Phase_Line_Width_5.IsChecked = false;
            }
            if (Selected == 6)
            {
                Phase_Line_Width_6.IsChecked = true;
            }
            else
            {
                Phase_Line_Width_6.IsChecked = false;
            }
            if (Selected == 7)
            {
                Phase_Line_Width_7.IsChecked = true;
            }
            else
            {
                Phase_Line_Width_7.IsChecked = false;
            }
        }

    }
}
