using MahApps.Metro.Controls;
using Microsoft.Win32;
using System;
using System.Windows;

namespace HardCopy
{
    public partial class HardCopy_Window : MetroWindow
    {
        private void Save_HardCopy_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (Draw_Canvas != null & Draw_Mode_Enabled == true)
                {
                    Draw_Mode_Save_Canvas_Image();
                }
                else
                {
                    Save_HardCopy_Only();
                }
            }
            catch (Exception)
            {

            }
        }

        private void Save_HardCopy_Only()
        {
            SaveFileDialog Save_Image_Window = new SaveFileDialog
            {
                FileName = "HardCopy" + "_" + DateTime.Now.ToString("yyyy-MM-dd h-mm-ss tt") + ".png",
                Filter = "PNG Files (*.png)|*.png;*.png" +
                      "|JPG Files (*.jpg, *.jpeg)|*.jpg;*.jpeg" +
                      "|BMP Files (*.bmp)|*.bmp;*.bmp" +
                      "|All files (*.*)|*.*"
            };

            if (Save_Image_Window.ShowDialog() is true)
            {
                BitmapImage2Bitmap(HardCopy_Bitmap_Image).Save(Save_Image_Window.FileName);
            }
        }

        private void Copy_HardCopy_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (Draw_Canvas != null & Draw_Mode_Enabled == true)
                {
                    Draw_Mode_Copy_Canvas_Image();
                }
                else
                {
                    Copy_HardCopy_Only();
                }
            }
            catch (Exception)
            {

            }
        }

        private void Copy_HardCopy_Only()
        {
            Clipboard.SetImage(HardCopy_Bitmap_Image);
        }
    }
}
