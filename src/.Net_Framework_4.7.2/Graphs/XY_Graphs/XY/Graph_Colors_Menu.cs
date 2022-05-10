using MahApps.Metro.Controls;
using System.Windows;

namespace XY
{
    public partial class XY_Plotter : MetroWindow
    {
        //-----------------------Graph Colors-----------------------------------------------------

        //Background Color

        private void Green_Background_Click(object sender, RoutedEventArgs e)
        {
            Graph.Plot.Style(dataBackground: System.Drawing.ColorTranslator.FromHtml("#FFAAFFB2"));
            Graph.Render();
            Background_Color_Select(0);
        }

        private void Blue_Background_Click(object sender, RoutedEventArgs e)
        {
            Graph.Plot.Style(dataBackground: System.Drawing.ColorTranslator.FromHtml("#FFA1E7FF"));
            Graph.Render();
            Background_Color_Select(1);
        }

        private void Red_Background_Click(object sender, RoutedEventArgs e)
        {
            Graph.Plot.Style(dataBackground: System.Drawing.ColorTranslator.FromHtml("#FFFF8989"));
            Graph.Render();
            Background_Color_Select(2);
        }

        private void Yellow_Background_Click(object sender, RoutedEventArgs e)
        {
            Graph.Plot.Style(dataBackground: System.Drawing.ColorTranslator.FromHtml("#FFFFFF93"));
            Graph.Render();
            Background_Color_Select(3);
        }

        private void Orange_Background_Click(object sender, RoutedEventArgs e)
        {
            Graph.Plot.Style(dataBackground: System.Drawing.ColorTranslator.FromHtml("#FFFFCB8C"));
            Graph.Render();
            Background_Color_Select(4);
        }

        private void Black_Background_Click(object sender, RoutedEventArgs e)
        {
            Graph.Plot.Style(dataBackground: System.Drawing.ColorTranslator.FromHtml("#FF6E6E6E"));
            Graph.Render();
            Background_Color_Select(5);
        }

        private void Pink_Background_Click(object sender, RoutedEventArgs e)
        {
            Graph.Plot.Style(dataBackground: System.Drawing.ColorTranslator.FromHtml("#FFFF9ED2"));
            Graph.Render();
            Background_Color_Select(6);
        }

        private void Violet_Background_Click(object sender, RoutedEventArgs e)
        {
            Graph.Plot.Style(dataBackground: System.Drawing.ColorTranslator.FromHtml("#FFE6ACFF"));
            Graph.Render();
            Background_Color_Select(7);
        }

        private void White_Background_Click(object sender, RoutedEventArgs e)
        {
            Graph.Plot.Style(dataBackground: System.Drawing.ColorTranslator.FromHtml("#FFFFFFFF"));
            Graph.Render();
            Background_Color_Select(8);
        }

        private void Background_Color_Select(int Selected)
        {
            if (Selected == 0)
            {
                Green_Background.IsChecked = true;
            }
            else
            {
                Green_Background.IsChecked = false;
            }
            if (Selected == 1)
            {
                Blue_Background.IsChecked = true;
            }
            else
            {
                Blue_Background.IsChecked = false;
            }
            if (Selected == 2)
            {
                Red_Background.IsChecked = true;
            }
            else
            {
                Red_Background.IsChecked = false;
            }
            if (Selected == 3)
            {
                Yellow_Background.IsChecked = true;
            }
            else
            {
                Yellow_Background.IsChecked = false;
            }
            if (Selected == 4)
            {
                Orange_Background.IsChecked = true;
            }
            else
            {
                Orange_Background.IsChecked = false;
            }
            if (Selected == 5)
            {
                Black_Background.IsChecked = true;
            }
            else
            {
                Black_Background.IsChecked = false;
            }
            if (Selected == 6)
            {
                Pink_Background.IsChecked = true;
            }
            else
            {
                Pink_Background.IsChecked = false;
            }
            if (Selected == 7)
            {
                Violet_Background.IsChecked = true;
            }
            else
            {
                Violet_Background.IsChecked = false;
            }
            if (Selected == 8)
            {
                White_Background.IsChecked = true;
            }
            else
            {
                White_Background.IsChecked = false;
            }
        }


        //ForeGround Color
        private void Green_Foreground_Click(object sender, RoutedEventArgs e)
        {
            Graph.Plot.Style(figureBackground: System.Drawing.ColorTranslator.FromHtml("#FFAAFFB2"));
            Graph.Render();
            Foreground_Color_Select(0);
        }

        private void Blue_Foreground_Click(object sender, RoutedEventArgs e)
        {
            Graph.Plot.Style(figureBackground: System.Drawing.ColorTranslator.FromHtml("#FFA1E7FF"));
            Graph.Render();
            Foreground_Color_Select(1);
        }

        private void Red_Foreground_Click(object sender, RoutedEventArgs e)
        {
            Graph.Plot.Style(figureBackground: System.Drawing.ColorTranslator.FromHtml("#FFFF8989"));
            Graph.Render();
            Foreground_Color_Select(2);
        }

        private void Yellow_Foreground_Click(object sender, RoutedEventArgs e)
        {
            Graph.Plot.Style(figureBackground: System.Drawing.ColorTranslator.FromHtml("#FFFFFF93"));
            Graph.Render();
            Foreground_Color_Select(3);
        }

        private void Orange_Foreground_Click(object sender, RoutedEventArgs e)
        {
            Graph.Plot.Style(figureBackground: System.Drawing.ColorTranslator.FromHtml("#FFFFCB8C"));
            Graph.Render();
            Foreground_Color_Select(4);
        }

        private void Black_Foreground_Click(object sender, RoutedEventArgs e)
        {
            Graph.Plot.Style(figureBackground: System.Drawing.ColorTranslator.FromHtml("#FF6E6E6E"));
            Graph.Render();
            Foreground_Color_Select(5);
        }

        private void Pink_Foreground_Click(object sender, RoutedEventArgs e)
        {
            Graph.Plot.Style(figureBackground: System.Drawing.ColorTranslator.FromHtml("#FFFF9ED2"));
            Graph.Render();
            Foreground_Color_Select(6);
        }

        private void Violet_Foreground_Click(object sender, RoutedEventArgs e)
        {
            Graph.Plot.Style(figureBackground: System.Drawing.ColorTranslator.FromHtml("#FFE6ACFF"));
            Graph.Render();
            Foreground_Color_Select(7);
        }

        private void White_Foreground_Click(object sender, RoutedEventArgs e)
        {
            Graph.Plot.Style(figureBackground: System.Drawing.ColorTranslator.FromHtml("#FFFFFFFF"));
            Graph.Render();
            Foreground_Color_Select(8);
        }

        private void Foreground_Color_Select(int Selected)
        {
            if (Selected == 0)
            {
                Green_Foreground.IsChecked = true;
            }
            else
            {
                Green_Foreground.IsChecked = false;
            }
            if (Selected == 1)
            {
                Blue_Foreground.IsChecked = true;
            }
            else
            {
                Blue_Foreground.IsChecked = false;
            }
            if (Selected == 2)
            {
                Red_Foreground.IsChecked = true;
            }
            else
            {
                Red_Foreground.IsChecked = false;
            }
            if (Selected == 3)
            {
                Yellow_Foreground.IsChecked = true;
            }
            else
            {
                Yellow_Foreground.IsChecked = false;
            }
            if (Selected == 4)
            {
                Orange_Foreground.IsChecked = true;
            }
            else
            {
                Orange_Foreground.IsChecked = false;
            }
            if (Selected == 5)
            {
                Black_Foreground.IsChecked = true;
            }
            else
            {
                Black_Foreground.IsChecked = false;
            }
            if (Selected == 6)
            {
                Pink_Foreground.IsChecked = true;
            }
            else
            {
                Pink_Foreground.IsChecked = false;
            }
            if (Selected == 7)
            {
                Violet_Foreground.IsChecked = true;
            }
            else
            {
                Violet_Foreground.IsChecked = false;
            }
            if (Selected == 8)
            {
                White_Foreground.IsChecked = true;
            }
            else
            {
                White_Foreground.IsChecked = false;
            }
        }

        //X-Axis Color
        private void Green_XAxis_Click(object sender, RoutedEventArgs e)
        {
            Graph.Plot.XAxis.Color(color: System.Drawing.ColorTranslator.FromHtml("#FF00FF17"));
            Graph.Render();
            XAxis_Color_Select(0);
        }

        private void Blue_XAxis_Click(object sender, RoutedEventArgs e)
        {
            Graph.Plot.XAxis.Color(color: System.Drawing.ColorTranslator.FromHtml("#FF00C0FF"));
            Graph.Render();
            XAxis_Color_Select(1);
        }

        private void Red_XAxis_Click(object sender, RoutedEventArgs e)
        {
            Graph.Plot.XAxis.Color(color: System.Drawing.ColorTranslator.FromHtml("#FFFF0000"));
            Graph.Render();
            XAxis_Color_Select(2);
        }

        private void Yellow_XAxis_Click(object sender, RoutedEventArgs e)
        {
            Graph.Plot.XAxis.Color(color: System.Drawing.ColorTranslator.FromHtml("#FFFFFF00"));
            Graph.Render();
            XAxis_Color_Select(3);
        }

        private void Orange_XAxis_Click(object sender, RoutedEventArgs e)
        {
            Graph.Plot.XAxis.Color(color: System.Drawing.ColorTranslator.FromHtml("#FFFF8C00"));
            Graph.Render();
            XAxis_Color_Select(4);
        }

        private void Black_XAxis_Click(object sender, RoutedEventArgs e)
        {
            Graph.Plot.XAxis.Color(color: System.Drawing.ColorTranslator.FromHtml("#FF000000"));
            Graph.Render();
            XAxis_Color_Select(5);
        }

        private void Pink_XAxis_Click(object sender, RoutedEventArgs e)
        {
            Graph.Plot.XAxis.Color(color: System.Drawing.ColorTranslator.FromHtml("#FFFF1493"));
            Graph.Render();
            XAxis_Color_Select(6);
        }

        private void Violet_XAxis_Click(object sender, RoutedEventArgs e)
        {
            Graph.Plot.XAxis.Color(color: System.Drawing.ColorTranslator.FromHtml("#FF9400D3"));
            Graph.Render();
            XAxis_Color_Select(7);
        }

        private void White_XAxis_Click(object sender, RoutedEventArgs e)
        {
            Graph.Plot.XAxis.Color(color: System.Drawing.ColorTranslator.FromHtml("#FFFFFFFF"));
            Graph.Render();
            XAxis_Color_Select(8);
        }

        private void XAxis_Color_Select(int Selected)
        {
            if (Selected == 0)
            {
                Green_XAxis.IsChecked = true;
            }
            else
            {
                Green_XAxis.IsChecked = false;
            }
            if (Selected == 1)
            {
                Blue_XAxis.IsChecked = true;
            }
            else
            {
                Blue_XAxis.IsChecked = false;
            }
            if (Selected == 2)
            {
                Red_XAxis.IsChecked = true;
            }
            else
            {
                Red_XAxis.IsChecked = false;
            }
            if (Selected == 3)
            {
                Yellow_XAxis.IsChecked = true;
            }
            else
            {
                Yellow_XAxis.IsChecked = false;
            }
            if (Selected == 4)
            {
                Orange_XAxis.IsChecked = true;
            }
            else
            {
                Orange_XAxis.IsChecked = false;
            }
            if (Selected == 5)
            {
                Black_XAxis.IsChecked = true;
            }
            else
            {
                Black_XAxis.IsChecked = false;
            }
            if (Selected == 6)
            {
                Pink_XAxis.IsChecked = true;
            }
            else
            {
                Pink_XAxis.IsChecked = false;
            }
            if (Selected == 7)
            {
                Violet_XAxis.IsChecked = true;
            }
            else
            {
                Violet_XAxis.IsChecked = false;
            }
            if (Selected == 8)
            {
                White_XAxis.IsChecked = true;
            }
            else
            {
                White_XAxis.IsChecked = false;
            }
        }

        //Y-Axis Color
        private void Green_YAxis_Click(object sender, RoutedEventArgs e)
        {
            Graph.Plot.YAxis.Color(color: System.Drawing.ColorTranslator.FromHtml("#FF00FF17"));
            Graph.Render();
            YAxis_Color_Select(0);
        }

        private void Blue_YAxis_Click(object sender, RoutedEventArgs e)
        {
            Graph.Plot.YAxis.Color(color: System.Drawing.ColorTranslator.FromHtml("#FF00C0FF"));
            Graph.Render();
            YAxis_Color_Select(1);
        }

        private void Red_YAxis_Click(object sender, RoutedEventArgs e)
        {
            Graph.Plot.YAxis.Color(color: System.Drawing.ColorTranslator.FromHtml("#FFFF0000"));
            Graph.Render();
            YAxis_Color_Select(2);
        }

        private void Yellow_YAxis_Click(object sender, RoutedEventArgs e)
        {
            Graph.Plot.YAxis.Color(color: System.Drawing.ColorTranslator.FromHtml("#FFFFFF00"));
            Graph.Render();
            YAxis_Color_Select(3);
        }

        private void Orange_YAxis_Click(object sender, RoutedEventArgs e)
        {
            Graph.Plot.YAxis.Color(color: System.Drawing.ColorTranslator.FromHtml("#FFFF8C00"));
            Graph.Render();
            YAxis_Color_Select(4);
        }

        private void Black_YAxis_Click(object sender, RoutedEventArgs e)
        {
            Graph.Plot.YAxis.Color(color: System.Drawing.ColorTranslator.FromHtml("#FF000000"));
            Graph.Render();
            YAxis_Color_Select(5);
        }

        private void Pink_YAxis_Click(object sender, RoutedEventArgs e)
        {
            Graph.Plot.YAxis.Color(color: System.Drawing.ColorTranslator.FromHtml("#FFFF1493"));
            Graph.Render();
            YAxis_Color_Select(6);
        }

        private void Violet_YAxis_Click(object sender, RoutedEventArgs e)
        {
            Graph.Plot.YAxis.Color(color: System.Drawing.ColorTranslator.FromHtml("#FF9400D3"));
            Graph.Render();
            YAxis_Color_Select(7);
        }

        private void White_YAxis_Click(object sender, RoutedEventArgs e)
        {
            Graph.Plot.YAxis.Color(color: System.Drawing.ColorTranslator.FromHtml("#FFFFFFFF"));
            Graph.Render();
            YAxis_Color_Select(8);
        }

        private void YAxis_Color_Select(int Selected)
        {
            if (Selected == 0)
            {
                Green_YAxis.IsChecked = true;
            }
            else
            {
                Green_YAxis.IsChecked = false;
            }
            if (Selected == 1)
            {
                Blue_YAxis.IsChecked = true;
            }
            else
            {
                Blue_YAxis.IsChecked = false;
            }
            if (Selected == 2)
            {
                Red_YAxis.IsChecked = true;
            }
            else
            {
                Red_YAxis.IsChecked = false;
            }
            if (Selected == 3)
            {
                Yellow_YAxis.IsChecked = true;
            }
            else
            {
                Yellow_YAxis.IsChecked = false;
            }
            if (Selected == 4)
            {
                Orange_YAxis.IsChecked = true;
            }
            else
            {
                Orange_YAxis.IsChecked = false;
            }
            if (Selected == 5)
            {
                Black_YAxis.IsChecked = true;
            }
            else
            {
                Black_YAxis.IsChecked = false;
            }
            if (Selected == 6)
            {
                Pink_YAxis.IsChecked = true;
            }
            else
            {
                Pink_YAxis.IsChecked = false;
            }
            if (Selected == 7)
            {
                Violet_YAxis.IsChecked = true;
            }
            else
            {
                Violet_YAxis.IsChecked = false;
            }
            if (Selected == 8)
            {
                White_YAxis.IsChecked = true;
            }
            else
            {
                White_YAxis.IsChecked = false;
            }
        }

        //Grid Color
        private void Gray_Grid_Click(object sender, RoutedEventArgs e)
        {
            Graph.Plot.Grid(color: System.Drawing.ColorTranslator.FromHtml("#59808080"));
            Graph.Render();
            Grid_Color_Select(0);
        }

        private void Green_Grid_Click(object sender, RoutedEventArgs e)
        {
            Graph.Plot.Grid(color: System.Drawing.ColorTranslator.FromHtml("#7F00FF17"));
            Graph.Render();
            Grid_Color_Select(1);
        }

        private void Blue_Grid_Click(object sender, RoutedEventArgs e)
        {
            Graph.Plot.Grid(color: System.Drawing.ColorTranslator.FromHtml("#7F00C0FF"));
            Graph.Render();
            Grid_Color_Select(2);
        }

        private void Red_Grid_Click(object sender, RoutedEventArgs e)
        {
            Graph.Plot.Grid(color: System.Drawing.ColorTranslator.FromHtml("#7FFF0000"));
            Graph.Render();
            Grid_Color_Select(3);
        }

        private void Yellow_Grid_Click(object sender, RoutedEventArgs e)
        {
            Graph.Plot.Grid(color: System.Drawing.ColorTranslator.FromHtml("#7FFFFF00"));
            Graph.Render();
            Grid_Color_Select(4);
        }

        private void Orange_Grid_Click(object sender, RoutedEventArgs e)
        {
            Graph.Plot.Grid(color: System.Drawing.ColorTranslator.FromHtml("#7FFF8C00"));
            Graph.Render();
            Grid_Color_Select(5);
        }

        private void Black_Grid_Click(object sender, RoutedEventArgs e)
        {
            Graph.Plot.Grid(color: System.Drawing.ColorTranslator.FromHtml("#7F000000"));
            Graph.Render();
            Grid_Color_Select(6);
        }

        private void Pink_Grid_Click(object sender, RoutedEventArgs e)
        {
            Graph.Plot.Grid(color: System.Drawing.ColorTranslator.FromHtml("#7FFF1493"));
            Graph.Render();
            Grid_Color_Select(7);
        }

        private void Violet_Grid_Click(object sender, RoutedEventArgs e)
        {
            Graph.Plot.Grid(color: System.Drawing.ColorTranslator.FromHtml("#7F9400D3"));
            Graph.Render();
            Grid_Color_Select(8);
        }

        private void White_Grid_Click(object sender, RoutedEventArgs e)
        {
            Graph.Plot.Grid(color: System.Drawing.ColorTranslator.FromHtml("#7FFFFFFF"));
            Graph.Render();
            Grid_Color_Select(9);
        }

        private void Grid_Color_Select(int Selected)
        {
            if (Selected == 0)
            {
                Gray_Grid.IsChecked = true;
            }
            else
            {
                Gray_Grid.IsChecked = false;
            }
            if (Selected == 1)
            {
                Green_Grid.IsChecked = true;
            }
            else
            {
                Green_Grid.IsChecked = false;
            }
            if (Selected == 2)
            {
                Blue_Grid.IsChecked = true;
            }
            else
            {
                Blue_Grid.IsChecked = false;
            }
            if (Selected == 3)
            {
                Red_Grid.IsChecked = true;
            }
            else
            {
                Red_Grid.IsChecked = false;
            }
            if (Selected == 4)
            {
                Yellow_Grid.IsChecked = true;
            }
            else
            {
                Yellow_Grid.IsChecked = false;
            }
            if (Selected == 5)
            {
                Orange_Grid.IsChecked = true;
            }
            else
            {
                Orange_Grid.IsChecked = false;
            }
            if (Selected == 6)
            {
                Black_Grid.IsChecked = true;
            }
            else
            {
                Black_Grid.IsChecked = false;
            }
            if (Selected == 7)
            {
                Pink_Grid.IsChecked = true;
            }
            else
            {
                Pink_Grid.IsChecked = false;
            }
            if (Selected == 8)
            {
                Violet_Grid.IsChecked = true;
            }
            else
            {
                Violet_Grid.IsChecked = false;
            }
            if (Selected == 9)
            {
                White_Grid.IsChecked = true;
            }
            else
            {
                White_Grid.IsChecked = false;
            }
        }

        //Themes
        private void Default_Theme_Click(object sender, RoutedEventArgs e)
        {
            Graph.Plot.Style(ScottPlot.Style.Default);
            Graph.Render();
            Theme_Select(0);
            Grid_Color_Select(99);
            YAxis_Color_Select(99);
            XAxis_Color_Select(99);
            Foreground_Color_Select(99);
            Background_Color_Select(99);
        }

        private void Black_Theme_Click(object sender, RoutedEventArgs e)
        {
            Graph.Plot.Style(ScottPlot.Style.Black);
            Graph.Plot.YAxis.Color(color: System.Drawing.ColorTranslator.FromHtml("#FFFFFFFF"));
            Graph.Plot.XAxis.Color(color: System.Drawing.ColorTranslator.FromHtml("#FFFFFFFF"));
            Graph.Render();
            Theme_Select(1);
            Grid_Color_Select(99);
            YAxis_Color_Select(99);
            XAxis_Color_Select(99);
            Foreground_Color_Select(99);
            Background_Color_Select(99);
        }

        private void Blue_Theme_Click(object sender, RoutedEventArgs e)
        {
            Graph.Plot.Style(ScottPlot.Style.Blue1);
            Graph.Render();
            Theme_Select(2);
            Grid_Color_Select(99);
            YAxis_Color_Select(99);
            XAxis_Color_Select(99);
            Foreground_Color_Select(99);
            Background_Color_Select(99);
        }

        private void Gray_Theme_Click(object sender, RoutedEventArgs e)
        {
            Graph.Plot.Style(ScottPlot.Style.Gray1);
            Graph.Render();
            Theme_Select(3);
            Grid_Color_Select(99);
            YAxis_Color_Select(99);
            XAxis_Color_Select(99);
            Foreground_Color_Select(99);
            Background_Color_Select(99);
        }

        private void GrayBlack_Theme_Click(object sender, RoutedEventArgs e)
        {
            Graph.Plot.Style(ScottPlot.Style.Gray2);
            Graph.Render();
            Theme_Select(4);
            Grid_Color_Select(99);
            YAxis_Color_Select(99);
            XAxis_Color_Select(99);
            Foreground_Color_Select(99);
            Background_Color_Select(99);
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
