using MahApps.Metro.Controls;
using System;
using System.IO;
using System.Windows.Media.Imaging;

namespace HardCopy
{
    public partial class HardCopy_Window : MetroWindow
    {
        private BitmapImage HardCopy_Bitmap_Image;

        public HardCopy_Window(byte[] imageData)
        {
            InitializeComponent();
            Convert_to_Image(imageData);
        }

        private void Convert_to_Image(byte[] imageData)
        {
            try
            {
                HardCopy_Bitmap_Image = new BitmapImage();
                using (MemoryStream mem = new MemoryStream(imageData))
                {
                    mem.Position = 0;
                    HardCopy_Bitmap_Image.BeginInit();
                    HardCopy_Bitmap_Image.CreateOptions = BitmapCreateOptions.PreservePixelFormat;
                    HardCopy_Bitmap_Image.CacheOption = BitmapCacheOption.OnLoad;
                    HardCopy_Bitmap_Image.UriSource = null;
                    HardCopy_Bitmap_Image.StreamSource = mem;
                    HardCopy_Bitmap_Image.EndInit();
                    mem.Close();
                    mem.Dispose();
                }
                HardCopy_Bitmap_Image.Freeze();
                HardCopy_Image.Source = HardCopy_Bitmap_Image;
            }
            catch (Exception)
            {
                this.Close();
            }
        }
    }
}
