using MahApps.Metro.Controls;
using System.Windows;

namespace Measurement_Plot
{
    public partial class Measurement_Plot_Window : MetroWindow
    {
        //-----------------------Graph Colors-----------------------------------------------------

        //Themes
        private void Default_Theme_Click(object sender, RoutedEventArgs e)
        {
            Graph.Plot.Style(ScottPlot.Style.Default);
            Graph.Render();
            Theme_Select(0);
        }

        private void Black_Theme_Click(object sender, RoutedEventArgs e)
        {
            Graph.Plot.Style(ScottPlot.Style.Black);
            Graph.Plot.YAxis.Color(color: System.Drawing.ColorTranslator.FromHtml("#FFFFFFFF"));
            Graph.Plot.XAxis.Color(color: System.Drawing.ColorTranslator.FromHtml("#FFFFFFFF"));
            Graph.Render();
            Theme_Select(1);
        }

        private void Blue_Theme_Click(object sender, RoutedEventArgs e)
        {
            Graph.Plot.Style(ScottPlot.Style.Blue1);
            Graph.Render();
            Theme_Select(2);
        }

        private void Gray_Theme_Click(object sender, RoutedEventArgs e)
        {
            Graph.Plot.Style(ScottPlot.Style.Gray1);
            Graph.Render();
            Theme_Select(3);
        }

        private void GrayBlack_Theme_Click(object sender, RoutedEventArgs e)
        {
            Graph.Plot.Style(ScottPlot.Style.Gray2);
            Graph.Render();
            Theme_Select(4);
        }

        private void Theme_Select(int Selected)
        {
            if (Selected == 0)
            {
                Default_Theme.IsChecked = true;
            }
            else
            {
                Default_Theme.IsChecked = false;
            }
            if (Selected == 1)
            {
                Black_Theme.IsChecked = true;
            }
            else
            {
                Black_Theme.IsChecked = false;
            }
            if (Selected == 2)
            {
                Blue_Theme.IsChecked = true;
            }
            else
            {
                Blue_Theme.IsChecked = false;
            }
            if (Selected == 3)
            {
                Gray_Theme.IsChecked = true;
            }
            else
            {
                Gray_Theme.IsChecked = false;
            }
            if (Selected == 4)
            {
                GrayBlack_Theme.IsChecked = true;
            }
            else
            {
                GrayBlack_Theme.IsChecked = false;
            }
        }

        //-----------------------Graph Colors End-----------------------------------------------------
    }
}
