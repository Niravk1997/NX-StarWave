using MahApps.Metro.Controls;
using System.Windows;

namespace Histogram
{
    public partial class Histogram_Plotter : MetroWindow
    {
        //Waveform Curve Color
        private void Green_Waveform_Curve_Color_Click(object sender, RoutedEventArgs e)
        {
            Histogram.FillColor = System.Drawing.ColorTranslator.FromHtml("#FF00FF17");
            Graph.Render();
            Waveform_Curve_Color_Select(0);
        }

        private void Blue_Waveform_Curve_Color_Click(object sender, RoutedEventArgs e)
        {
            Histogram.FillColor = System.Drawing.ColorTranslator.FromHtml("#0072BD");
            Graph.Render();
            Waveform_Curve_Color_Select(1);
        }

        private void Red_Waveform_Curve_Color_Click(object sender, RoutedEventArgs e)
        {
            Histogram.FillColor = System.Drawing.ColorTranslator.FromHtml("#FFFF0000");
            Graph.Render();
            Waveform_Curve_Color_Select(2);
        }

        private void Yellow_Waveform_Curve_Color_Click(object sender, RoutedEventArgs e)
        {
            Histogram.FillColor = System.Drawing.ColorTranslator.FromHtml("#FFFFFF00");
            Graph.Render();
            Waveform_Curve_Color_Select(3);
        }

        private void Orange_Waveform_Curve_Color_Click(object sender, RoutedEventArgs e)
        {
            Histogram.FillColor = System.Drawing.ColorTranslator.FromHtml("#FFFF8C00");
            Graph.Render();
            Waveform_Curve_Color_Select(4);
        }

        private void Black_Waveform_Curve_Color_Click(object sender, RoutedEventArgs e)
        {
            Histogram.FillColor = System.Drawing.ColorTranslator.FromHtml("#FF000000");
            Graph.Render();
            Waveform_Curve_Color_Select(5);
        }

        private void Pink_Waveform_Curve_Color_Click(object sender, RoutedEventArgs e)
        {
            Histogram.FillColor = System.Drawing.ColorTranslator.FromHtml("#FFFF1493");
            Graph.Render();
            Waveform_Curve_Color_Select(6);
        }

        private void Violet_Waveform_Curve_Color_Click(object sender, RoutedEventArgs e)
        {
            Histogram.FillColor = System.Drawing.ColorTranslator.FromHtml("#FF9400D3");
            Graph.Render();
            Waveform_Curve_Color_Select(7);
        }

        private void White_Waveform_Curve_Color_Click(object sender, RoutedEventArgs e)
        {
            Histogram.FillColor = System.Drawing.ColorTranslator.FromHtml("#FFFFFFFF");
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
    }
}
