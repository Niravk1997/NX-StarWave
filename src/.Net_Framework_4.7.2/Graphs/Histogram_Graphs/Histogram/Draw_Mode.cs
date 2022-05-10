using MahApps.Metro.Controls;
using Microsoft.Win32;
using System;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace Histogram
{
    public partial class Histogram_Plotter : MetroWindow
    {
        private InkCanvas Draw_Canvas = null;

        private bool Draw_Mode_Enabled = false;

        // 0 = Pen, 1 = Highlighter, 2 = Eraser
        private int Draw_Mode_Tool_Selection = 0;

        private string Draw_Mode_Pen_Color = "#FFFF0000";
        private string Draw_Mode_Highlighter_Color = "#80F3FF00";

        private double Draw_Mode_Pen_Size = 2;

        private double Draw_Mode_Highlighter_Size = 20;

        private MenuItem Draw_Mode_addCopyImageMenuItem;
        private MenuItem Draw_Mode_addSaveImageMenuItem;
        private ContextMenu Draw_Mode_rightClickMenu;

        private void Enable_Draw_Mode()
        {
            if (Draw_Canvas == null & Draw_Mode_Enabled == false)
            {
                Draw_Mode_addCopyImageMenuItem = new MenuItem() { Header = "Copy Image" };
                Draw_Mode_addCopyImageMenuItem.Click += Draw_Mode_Copy_Canvas_Image_Click;
                Draw_Mode_addSaveImageMenuItem = new MenuItem() { Header = "Save Image" };
                Draw_Mode_addSaveImageMenuItem.Click += Draw_Mode_Save_Canvas_Image_Click;

                Draw_Mode_rightClickMenu = new ContextMenu();
                Draw_Mode_rightClickMenu.Items.Add(Draw_Mode_addCopyImageMenuItem);
                Draw_Mode_rightClickMenu.Items.Add(Draw_Mode_addSaveImageMenuItem);

                Draw_Canvas = new InkCanvas();
                Draw_Canvas.Background = null;
                Draw_Canvas.ContextMenu = Draw_Mode_rightClickMenu;

                Histogram_Grid.Children.Add(Draw_Canvas);
                Draw_Canvas.SetValue(Grid.RowProperty, 1);
                Panel.SetZIndex(Draw_Canvas, 1);
                Draw_Mode_Enabled = true;
                Insert_Log("Draw Mode has been enabled.", 2);

                //Set Draw Tool to Pen
                Draw_Canvas.EditingMode = InkCanvasEditingMode.Ink;
                Draw_Mode_Tool_Selection = 0;
                Draw_Mode_Tool_Tip_Color_Set(Draw_Mode_Pen_Color);
                Draw_Canvas.DefaultDrawingAttributes.Width = Draw_Mode_Pen_Size;
                Draw_Canvas.DefaultDrawingAttributes.Height = Draw_Mode_Pen_Size;
                Draw_Mode_InkStroke_Size_Value.Text = Draw_Mode_Pen_Size.ToString();
            }
            else
            {
                Insert_Log("Draw Mode already enabled.", 2);
            }
        }

        private void Disable_Draw_Mode()
        {
            if (Draw_Canvas != null & Draw_Mode_Enabled == true)
            {
                Draw_Mode_Enabled = false;

                Draw_Canvas.ContextMenu = null;

                Draw_Mode_addCopyImageMenuItem.Click -= Draw_Mode_Copy_Canvas_Image_Click;
                Draw_Mode_addSaveImageMenuItem.Click -= Draw_Mode_Save_Canvas_Image_Click;
                Draw_Mode_addCopyImageMenuItem = null;
                Draw_Mode_addSaveImageMenuItem = null;
                Draw_Mode_rightClickMenu = null;

                Histogram_Grid.Children.Remove(Draw_Canvas);
                Draw_Canvas = null;
                Insert_Log("Draw Mode has been disabled.", 2);
            }
        }

        private void Draw_Mode_Toggled(object sender, RoutedEventArgs e)
        {
            if (Draw_Mode_Toggle_Button.IsOn)
            {
                Enable_Draw_Mode();
            }
            else
            {
                Disable_Draw_Mode();
            }
        }

        private void Draw_Mode_Select_Pen_Click(object sender, RoutedEventArgs e)
        {
            if (Draw_Canvas != null & Draw_Mode_Enabled == true)
            {
                Draw_Canvas.EditingMode = InkCanvasEditingMode.Ink;
                Draw_Mode_Tool_Selection = 0;
                Draw_Mode_Tool_Tip_Color_Set(Draw_Mode_Pen_Color);
                Draw_Canvas.DefaultDrawingAttributes.Width = Draw_Mode_Pen_Size;
                Draw_Canvas.DefaultDrawingAttributes.Height = Draw_Mode_Pen_Size;
                Draw_Mode_InkStroke_Size_Value.Text = Draw_Mode_Pen_Size.ToString();
            }
        }

        private void Draw_Mode_Select_Highlighter_Click(object sender, RoutedEventArgs e)
        {
            if (Draw_Canvas != null & Draw_Mode_Enabled == true)
            {
                Draw_Canvas.EditingMode = InkCanvasEditingMode.Ink;
                Draw_Mode_Tool_Selection = 1;
                Draw_Mode_Tool_Tip_Color_Set(Draw_Mode_Highlighter_Color);
                Draw_Canvas.DefaultDrawingAttributes.Width = Draw_Mode_Highlighter_Size;
                Draw_Canvas.DefaultDrawingAttributes.Height = Draw_Mode_Highlighter_Size;
                Draw_Mode_InkStroke_Size_Value.Text = Draw_Mode_Highlighter_Size.ToString();
            }
        }

        private void Draw_Mode_Select_Eraser_Click(object sender, RoutedEventArgs e)
        {
            if (Draw_Canvas != null & Draw_Mode_Enabled == true)
            {
                Draw_Canvas.EditingMode = InkCanvasEditingMode.EraseByStroke;
                Draw_Mode_Tool_Selection = 2;
                Draw_Mode_InkStroke_Size_Value.Text = "NaN";
            }
        }

        private void Draw_Mode_Tool_Tip_Color_Set(string Colour)
        {
            if (Draw_Canvas != null & Draw_Mode_Enabled == true)
            {
                if (Draw_Mode_Tool_Selection == 0)
                {
                    Draw_Canvas.DefaultDrawingAttributes.Color = (Color)ColorConverter.ConvertFromString(Colour);
                }
                else if (Draw_Mode_Tool_Selection == 1)
                {
                    Color color = (Color)ColorConverter.ConvertFromString(Colour);
                    if (color.A >= 110)
                    {
                        Draw_Canvas.DefaultDrawingAttributes.Color = Color.FromArgb(110, color.R, color.G, color.B);
                    }
                    else
                    {
                        Draw_Canvas.DefaultDrawingAttributes.Color = color;
                    }
                }
            }
        }

        private void Draw_Mode_Tool_Tip_Custom_Color_Set(string Colour)
        {
            if (Draw_Canvas != null & Draw_Mode_Enabled == true)
            {
                if (Draw_Mode_Tool_Selection == 0)
                {
                    Draw_Canvas.DefaultDrawingAttributes.Color = (Color)ColorConverter.ConvertFromString(Colour);
                    Draw_Mode_Pen_Color = Colour;
                }
                else if (Draw_Mode_Tool_Selection == 1)
                {
                    Draw_Canvas.DefaultDrawingAttributes.Color = (Color)ColorConverter.ConvertFromString(Colour);
                    Draw_Mode_Highlighter_Color = Colour;
                }
            }
        }

        private void Draw_Mode_Set_Predefined_Color_Red_Click(object sender, RoutedEventArgs e)
        {
            if (Draw_Mode_Tool_Selection == 0)
            {
                Draw_Mode_Pen_Color = "#FF0000";
                Draw_Mode_Tool_Tip_Color_Set(Draw_Mode_Pen_Color);
            }
            else if (Draw_Mode_Tool_Selection == 1)
            {
                Draw_Mode_Highlighter_Color = "#FF0000";
                Draw_Mode_Tool_Tip_Color_Set(Draw_Mode_Highlighter_Color);
            }
        }

        private void Draw_Mode_Set_Predefined_Color_Green_Click(object sender, RoutedEventArgs e)
        {
            if (Draw_Mode_Tool_Selection == 0)
            {
                Draw_Mode_Pen_Color = "#32CD32";
                Draw_Mode_Tool_Tip_Color_Set(Draw_Mode_Pen_Color);
            }
            else if (Draw_Mode_Tool_Selection == 1)
            {
                Draw_Mode_Highlighter_Color = "#32CD32";
                Draw_Mode_Tool_Tip_Color_Set(Draw_Mode_Highlighter_Color);
            }
        }

        private void Draw_Mode_Set_Predefined_Color_Blue_Click(object sender, RoutedEventArgs e)
        {
            if (Draw_Mode_Tool_Selection == 0)
            {
                Draw_Mode_Pen_Color = "#0000FF";
                Draw_Mode_Tool_Tip_Color_Set(Draw_Mode_Pen_Color);
            }
            else if (Draw_Mode_Tool_Selection == 1)
            {
                Draw_Mode_Highlighter_Color = "#0000FF";
                Draw_Mode_Tool_Tip_Color_Set(Draw_Mode_Highlighter_Color);
            }
        }

        private void Draw_Mode_Set_Predefined_Color_DogerBlue_Click(object sender, RoutedEventArgs e)
        {
            if (Draw_Mode_Tool_Selection == 0)
            {
                Draw_Mode_Pen_Color = "#1e90ff";
                Draw_Mode_Tool_Tip_Color_Set(Draw_Mode_Pen_Color);
            }
            else if (Draw_Mode_Tool_Selection == 1)
            {
                Draw_Mode_Highlighter_Color = "#1e90ff";
                Draw_Mode_Tool_Tip_Color_Set(Draw_Mode_Highlighter_Color);
            }
        }

        private void Draw_Mode_Set_Predefined_Color_Yellow_Click(object sender, RoutedEventArgs e)
        {
            if (Draw_Mode_Tool_Selection == 0)
            {
                Draw_Mode_Pen_Color = "#FFFF00";
                Draw_Mode_Tool_Tip_Color_Set(Draw_Mode_Pen_Color);
            }
            else if (Draw_Mode_Tool_Selection == 1)
            {
                Draw_Mode_Highlighter_Color = "#FFFF00";
                Draw_Mode_Tool_Tip_Color_Set(Draw_Mode_Highlighter_Color);
            }
        }
        private void Draw_Mode_Set_Predefined_Color_DeepPink_Click(object sender, RoutedEventArgs e)
        {
            if (Draw_Mode_Tool_Selection == 0)
            {
                Draw_Mode_Pen_Color = "#ff1493";
                Draw_Mode_Tool_Tip_Color_Set(Draw_Mode_Pen_Color);
            }
            else if (Draw_Mode_Tool_Selection == 1)
            {
                Draw_Mode_Highlighter_Color = "#ff1493";
                Draw_Mode_Tool_Tip_Color_Set(Draw_Mode_Highlighter_Color);
            }
        }

        private void Draw_Mode_Tool_Tip_SizeUp()
        {
            if (Draw_Mode_Tool_Selection == 0 || Draw_Mode_Tool_Selection == 1)
            {
                double Size;
                bool isValid = double.TryParse(Draw_Mode_InkStroke_Size_Value.Text, out Size);
                if (isValid)
                {
                    if (Size < 100)
                    {
                        Size++;
                        Draw_Mode_InkStroke_Size_Value.Text = Size.ToString();
                        Draw_Mode_Set_InkStroke_Size(Size);
                    }
                    else
                    {
                        Draw_Mode_Set_InkStroke_DefaultSize();
                    }
                }
                else
                {
                    Draw_Mode_Set_InkStroke_DefaultSize();
                }
            }
        }

        private void Draw_Mode_Tool_Tip_SizeDown()
        {
            if (Draw_Mode_Tool_Selection == 0 || Draw_Mode_Tool_Selection == 1)
            {
                double Size;
                bool isValid = double.TryParse(Draw_Mode_InkStroke_Size_Value.Text, out Size);
                if (isValid)
                {
                    if (Size > 1 & Size < 100)
                    {
                        Size--;
                        Draw_Mode_InkStroke_Size_Value.Text = Size.ToString();
                        Draw_Mode_Set_InkStroke_Size(Size);
                    }
                    else
                    {
                        Draw_Mode_Set_InkStroke_DefaultSize();
                    }
                }
                else
                {
                    Draw_Mode_Set_InkStroke_DefaultSize();
                }
            }
        }

        private void Draw_Mode_Tool_Tip_SizeUp_Click(object sender, RoutedEventArgs e)
        {
            Draw_Mode_Tool_Tip_SizeUp();
        }

        private void Draw_Mode_Tool_Tip_SizeDown_Click(object sender, RoutedEventArgs e)
        {
            Draw_Mode_Tool_Tip_SizeDown();
        }

        private void Draw_Mode_Set_InkStroke_Size(double Size)
        {
            if (Draw_Mode_Tool_Selection == 0)
            {
                Draw_Mode_Pen_Size = Size;
                if (Draw_Canvas != null & Draw_Mode_Enabled == true)
                {
                    Draw_Canvas.DefaultDrawingAttributes.Width = Size;
                    Draw_Canvas.DefaultDrawingAttributes.Height = Size;
                }
            }
            else if (Draw_Mode_Tool_Selection == 1)
            {
                Draw_Mode_Highlighter_Size = Size;
                if (Draw_Canvas != null & Draw_Mode_Enabled == true)
                {
                    Draw_Canvas.DefaultDrawingAttributes.Width = Size;
                    Draw_Canvas.DefaultDrawingAttributes.Height = Size;
                }
            }
        }

        private void Draw_Mode_Set_InkStroke_DefaultSize()
        {
            if (Draw_Mode_Tool_Selection == 0)
            {
                if (Draw_Canvas != null & Draw_Mode_Enabled == true)
                {
                    Draw_Canvas.DefaultDrawingAttributes.Width = 2;
                    Draw_Canvas.DefaultDrawingAttributes.Height = 2;
                }
                Draw_Mode_Pen_Size = 2;
                Draw_Mode_InkStroke_Size_Value.Text = "2";
            }
            else if (Draw_Mode_Tool_Selection == 1)
            {
                if (Draw_Canvas != null & Draw_Mode_Enabled == true)
                {
                    Draw_Canvas.DefaultDrawingAttributes.Width = 20;
                    Draw_Canvas.DefaultDrawingAttributes.Height = 20;
                }
                Draw_Mode_Highlighter_Size = 20;
                Draw_Mode_InkStroke_Size_Value.Text = "20";
            }
        }

        private void Draw_Mode_InkCanvas_Size_TextBox_MouseWheel(object sender, MouseWheelEventArgs e)
        {
            if (e.Delta > 0)
            {
                Draw_Mode_Tool_Tip_SizeUp();
            }
            else if (e.Delta < 0)
            {
                Draw_Mode_Tool_Tip_SizeDown();
            }
        }

        private void Draw_Mode_Save_Canvas_Image_Click(object sender, RoutedEventArgs e)
        {
            if (Draw_Canvas != null & Draw_Mode_Enabled == true)
            {
                Draw_Mode_Save_Canvas_Image();
            }
        }

        private void Draw_Mode_Copy_Canvas_Image_Click(object sender, RoutedEventArgs e)
        {
            if (Draw_Canvas != null & Draw_Mode_Enabled == true)
            {
                Draw_Mode_Copy_Canvas_Image();
            }
        }

        private System.Drawing.Bitmap MergedBitmaps(System.Drawing.Bitmap bmp1, System.Drawing.Bitmap bmp2)
        {
            System.Drawing.Bitmap result = new System.Drawing.Bitmap(bmp2.Width, bmp2.Height);
            using (System.Drawing.Graphics g = System.Drawing.Graphics.FromImage(result))
            {
                g.DrawImage(bmp2, System.Drawing.Point.Empty);
                g.DrawImage(bmp1, System.Drawing.Point.Empty);
            }
            return result;
        }

        private void Draw_Mode_Save_Canvas_Image()
        {
            Size Draw_Canvas_size = new Size(Draw_Canvas.ActualWidth, Draw_Canvas.ActualHeight);
            Draw_Canvas.Measure(Draw_Canvas_size);
            Draw_Canvas.Arrange(new Rect(Draw_Canvas_size));

            RenderTargetBitmap Canvas = new RenderTargetBitmap((int)Draw_Canvas_size.Width, (int)Draw_Canvas_size.Height, 96d, 96d, PixelFormats.Default);
            Canvas.Render(Draw_Canvas);

            MemoryStream stream = new MemoryStream();
            PngBitmapEncoder encoder = new PngBitmapEncoder();
            encoder.Frames.Add(BitmapFrame.Create(Canvas));
            encoder.Save(stream);

            System.Drawing.Bitmap Canvas_Bitmap = new System.Drawing.Bitmap(stream);
            System.Drawing.Bitmap Plot_Bitmap = Graph.Plot.GetBitmap();
            System.Drawing.Bitmap Screen_Shot = MergedBitmaps(Canvas_Bitmap, Plot_Bitmap);

            GridLength GridSplitter_Panel_Height = GridSplitter_Panel.Height;
            GridSplitter_Panel.Height = new GridLength(1);
            GridSplitter_Panel.Height = GridSplitter_Panel_Height;

            try
            {
                var Save_Image_Window = new SaveFileDialog
                {
                    FileName = "Draw_Canvas" + "_" + DateTime.Now.ToString("yyyy-MM-dd h-mm-ss tt") + ".png",
                    Filter = "PNG Files (*.png)|*.png;*.png" +
                      "|JPG Files (*.jpg, *.jpeg)|*.jpg;*.jpeg" +
                      "|BMP Files (*.bmp)|*.bmp;*.bmp" +
                      "|All files (*.*)|*.*"
                };

                if (Save_Image_Window.ShowDialog() is true)
                {
                    Screen_Shot.Save(Save_Image_Window.FileName);
                }
            }
            catch (Exception Ex)
            {
                Insert_Log("Could not save Waveform Image.", 1);
                Insert_Log(Ex.Message, 1);
            }

            Canvas.Freeze();
            stream.Dispose();
            Canvas_Bitmap.Dispose();
            Plot_Bitmap.Dispose();
            Screen_Shot.Dispose();
        }

        private void Draw_Mode_Copy_Canvas_Image()
        {
            Size Draw_Canvas_size = new Size(Draw_Canvas.ActualWidth, Draw_Canvas.ActualHeight);
            Draw_Canvas.Measure(Draw_Canvas_size);
            Draw_Canvas.Arrange(new Rect(Draw_Canvas_size));

            RenderTargetBitmap Canvas = new RenderTargetBitmap((int)Draw_Canvas_size.Width, (int)Draw_Canvas_size.Height, 96d, 96d, PixelFormats.Default);
            Canvas.Render(Draw_Canvas);

            MemoryStream stream = new MemoryStream();
            PngBitmapEncoder encoder = new PngBitmapEncoder();
            encoder.Frames.Add(BitmapFrame.Create(Canvas));
            encoder.Save(stream);

            System.Drawing.Bitmap Canvas_Bitmap = new System.Drawing.Bitmap(stream);
            System.Drawing.Bitmap Plot_Bitmap = Graph.Plot.GetBitmap();
            System.Drawing.Bitmap Screen_Shot = MergedBitmaps(Canvas_Bitmap, Plot_Bitmap);

            GridLength GridSplitter_Panel_Height = GridSplitter_Panel.Height;
            GridSplitter_Panel.Height = new GridLength(1);
            GridSplitter_Panel.Height = GridSplitter_Panel_Height;

            MemoryStream Image_Memory = new MemoryStream();
            Screen_Shot.Save(Image_Memory, System.Drawing.Imaging.ImageFormat.Png);

            BitmapImage Screen_Shot_Bitmap = new BitmapImage();
            Screen_Shot_Bitmap.BeginInit();
            Screen_Shot_Bitmap.StreamSource = new MemoryStream(Image_Memory.ToArray());
            Screen_Shot_Bitmap.EndInit();

            Clipboard.SetImage(Screen_Shot_Bitmap);

            Canvas.Freeze();
            stream.Dispose();
            Canvas_Bitmap.Dispose();
            Plot_Bitmap.Dispose();
            Screen_Shot.Dispose();
            Image_Memory.Dispose();
            Screen_Shot_Bitmap.Freeze();
        }

    }
}
