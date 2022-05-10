using MahApps.Metro.Controls;
using Microsoft.Win32;
using System;
using System.IO;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace NodeNetwork_Math
{
    public partial class NodeNetwork_Window : MetroWindow
    {
        private void Right_ClickSave_NodeNetwork_Image(object sender, EventArgs e)
        {
            Save_NodeNetwork_to_Image();
        }

        private void Save_NodeNetwork_to_Image()
        {
            try
            {
                Size NodeNetwork_Canvas_size = new Size(networkEditorView.ActualWidth, networkEditorView.ActualHeight);
                networkEditorView.Measure(NodeNetwork_Canvas_size);
                networkEditorView.Arrange(new Rect(NodeNetwork_Canvas_size));

                RenderTargetBitmap NodeNetwork_RenderBitmap = new RenderTargetBitmap((int)NodeNetwork_Canvas_size.Width, (int)NodeNetwork_Canvas_size.Height, 96d, 96d, PixelFormats.Default);
                NodeNetwork_RenderBitmap.Render(networkEditorView);

                MemoryStream NodeNetwork_stream = new MemoryStream();
                PngBitmapEncoder NodeNetwork_encoder = new PngBitmapEncoder();
                NodeNetwork_encoder.Frames.Add(BitmapFrame.Create(NodeNetwork_RenderBitmap));
                NodeNetwork_encoder.Save(NodeNetwork_stream);

                System.Drawing.Bitmap NodeNetwork_Bitmap = new System.Drawing.Bitmap(NodeNetwork_stream);

                GridLength GridSplitter_Panel_Height = GridSplitter_Panel.Height;
                GridSplitter_Panel.Height = new GridLength(1);
                GridSplitter_Panel.Height = GridSplitter_Panel_Height;

                var Save_Image_Window = new SaveFileDialog
                {
                    FileName = "NodeNetwork" + "_" + DateTime.Now.ToString("yyyy-MM-dd h-mm-ss tt") + ".png",
                    Filter = "PNG Files (*.png)|*.png;*.png" +
                      "|JPG Files (*.jpg, *.jpeg)|*.jpg;*.jpeg" +
                      "|BMP Files (*.bmp)|*.bmp;*.bmp" +
                      "|All files (*.*)|*.*"
                };

                if (Save_Image_Window.ShowDialog() is true)
                {
                    NodeNetwork_Bitmap.Save(Save_Image_Window.FileName);
                }

                NodeNetwork_RenderBitmap.Freeze();
                NodeNetwork_Bitmap.Dispose();
                NodeNetwork_stream.Dispose();
            }
            catch (Exception Ex)
            {
                Insert_Log("Could not save NodeNetwork Image.", 1);
                Insert_Log(Ex.Message, 1);
            }
        }

        private void RightClick_Copy_NodeNetwork_Image(object sender, RoutedEventArgs e)
        {
            try
            {
                Copy_NodeNetwork_to_Image();
            }
            catch (Exception Ex)
            {
                Insert_Log(Ex.Message, 1);
            }
        }

        private void Copy_NodeNetwork_to_Image()
        {
            Size NodeNetwork_Canvas_size = new Size(networkEditorView.ActualWidth, networkEditorView.ActualHeight);
            networkEditorView.Measure(NodeNetwork_Canvas_size);
            networkEditorView.Arrange(new Rect(NodeNetwork_Canvas_size));

            RenderTargetBitmap NodeNetwork_RenderBitmap = new RenderTargetBitmap((int)NodeNetwork_Canvas_size.Width, (int)NodeNetwork_Canvas_size.Height, 96d, 96d, PixelFormats.Default);
            NodeNetwork_RenderBitmap.Render(networkEditorView);

            MemoryStream NodeNetwork_stream = new MemoryStream();
            PngBitmapEncoder NodeNetwork_encoder = new PngBitmapEncoder();
            NodeNetwork_encoder.Frames.Add(BitmapFrame.Create(NodeNetwork_RenderBitmap));
            NodeNetwork_encoder.Save(NodeNetwork_stream);

            System.Drawing.Bitmap NodeNetwork_Bitmap = new System.Drawing.Bitmap(NodeNetwork_stream);

            GridLength GridSplitter_Panel_Height = GridSplitter_Panel.Height;
            GridSplitter_Panel.Height = new GridLength(1);
            GridSplitter_Panel.Height = GridSplitter_Panel_Height;

            MemoryStream Image_Memory = new MemoryStream();
            NodeNetwork_Bitmap.Save(Image_Memory, System.Drawing.Imaging.ImageFormat.Png);

            BitmapImage NodeNetwork_BitmapImage = new BitmapImage();
            NodeNetwork_BitmapImage.BeginInit();
            NodeNetwork_BitmapImage.StreamSource = new MemoryStream(Image_Memory.ToArray());
            NodeNetwork_BitmapImage.EndInit();

            Clipboard.SetImage(NodeNetwork_BitmapImage);

            NodeNetwork_BitmapImage.Freeze();
            NodeNetwork_RenderBitmap.Freeze();
            NodeNetwork_Bitmap.Dispose();
            NodeNetwork_stream.Dispose();
            Image_Memory.Dispose();
        }
    }
}
