using MahApps.Metro.Controls;
using Microsoft.Win32;
using System;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace FFT
{
    public partial class FFT_Plotter : MetroWindow
    {
        private MenuItem AutoAxis_MenuItem;
        private MenuItem Vertical_Markers_MenuItem;
        private MenuItem Horizontal_Markers_MenuItem;

        private MenuItem addCopyImageMenuItem;
        private MenuItem addSaveImageMenuItem;

        private MenuItem Gated_Peaks_EnableDisable_MenuItem;

        private MenuItem Gated_HighestPoints_EnableDisable_MenuItem;

        private ContextMenu rightClickMenu;

        private void Graph_RightClick_Menu()
        {
            Graph.RightClicked -= Graph.DefaultRightClickEvent;
            Graph.RightClicked += Graph_RightClick_Menu_Options;
            Initialize_Right_Click_Menu();
        }

        private void Initialize_Right_Click_Menu()
        {
            AutoAxis_MenuItem = new MenuItem() { Header = "Auto Axis" };
            AutoAxis_MenuItem.Click += Right_Click_AutoAxis;
            AutoAxis_MenuItem.IsCheckable = true;
            AutoAxis_MenuItem.IsChecked = true;

            Vertical_Markers_MenuItem = new MenuItem() { Header = "Vertical Markers" };
            Vertical_Markers_MenuItem.Click += Right_Click_Enable_Vertical_Markers;
            Vertical_Markers_MenuItem.IsCheckable = true;

            Horizontal_Markers_MenuItem = new MenuItem() { Header = "Horizontal Markers" };
            Horizontal_Markers_MenuItem.Click += Right_Click_Enable_Horizontal_Markers;
            Horizontal_Markers_MenuItem.IsCheckable = true;

            Gated_Peaks_EnableDisable_MenuItem = new MenuItem() { Header = "Gated Peaks" };
            Gated_Peaks_EnableDisable_MenuItem.IsCheckable = true;
            Gated_Peaks_EnableDisable_MenuItem.IsChecked = false;
            Gated_Peaks_EnableDisable_MenuItem.Click += Enable_Disable_Gated_Peaks_Click;

            Gated_HighestPoints_EnableDisable_MenuItem = new MenuItem() { Header = "Gated Highest Points" };
            Gated_HighestPoints_EnableDisable_MenuItem.IsCheckable = true;
            Gated_HighestPoints_EnableDisable_MenuItem.IsChecked = false;
            Gated_HighestPoints_EnableDisable_MenuItem.Click += Enable_Disable_Gated_HighestPoints_Click;

            addCopyImageMenuItem = new MenuItem() { Header = "Copy Image" };
            addCopyImageMenuItem.Click += RightClick_Copy_Graph_Image;
            addSaveImageMenuItem = new MenuItem() { Header = "Save Image" };
            addSaveImageMenuItem.Click += Right_ClickSave_Graph_Image;

            rightClickMenu = new ContextMenu();
            rightClickMenu.Items.Add(AutoAxis_MenuItem);
            rightClickMenu.Items.Add(Vertical_Markers_MenuItem);
            rightClickMenu.Items.Add(Horizontal_Markers_MenuItem);
            rightClickMenu.Items.Add(Gated_HighestPoints_EnableDisable_MenuItem);
            rightClickMenu.Items.Add(Gated_Peaks_EnableDisable_MenuItem);
            rightClickMenu.Items.Add(addCopyImageMenuItem);
            rightClickMenu.Items.Add(addSaveImageMenuItem);
        }

        private void Graph_RightClick_Menu_Options(object sender, EventArgs e)
        {
            rightClickMenu.IsOpen = true;
        }

        private void Right_Click_AutoAxis(object sender, EventArgs e)
        {
            if (AutoAxis_MenuItem.IsChecked == true)
            {
                Insert_Log("Graph's Auto-Axis feature is enabled.", 0);
                Auto_Axis_Enable.IsChecked = true;
            }
            else
            {
                Insert_Log("Graph's Auto-Axis feature is disabled.", 2);
                Auto_Axis_Enable.IsChecked = false;
            }
        }

        private void Right_Click_Enable_Vertical_Markers(object sender, EventArgs e)
        {
            if (Vertical_Markers_MenuItem.IsChecked == true)
            {
                Draggable_Vertical_Markers.IsChecked = true;
                Add_Clear_Vertical_Markers();
            }
            else
            {
                Draggable_Vertical_Markers.IsChecked = false;
                Add_Clear_Vertical_Markers();
            }
        }

        private void Right_Click_Enable_Horizontal_Markers(object sender, EventArgs e)
        {
            if (Horizontal_Markers_MenuItem.IsChecked == true)
            {
                Draggable_Horizontal_Markers.IsChecked = true;
                Add_Clear_Horizontal_Markers();
            }
            else
            {
                Draggable_Horizontal_Markers.IsChecked = false;
                Add_Clear_Horizontal_Markers();
            }
        }

        private void Right_ClickSave_Graph_Image(object sender, EventArgs e)
        {
            Save_Graph_to_Image();
        }

        private void Save_Graph_to_Image()
        {
            try
            {
                var Save_Image_Window = new SaveFileDialog
                {
                    FileName = "FFT_Waveform" + "_" + DateTime.Now.ToString("yyyy-MM-dd h-mm-ss tt") + ".png",
                    Filter = "PNG Files (*.png)|*.png;*.png" +
                      "|JPG Files (*.jpg, *.jpeg)|*.jpg;*.jpeg" +
                      "|BMP Files (*.bmp)|*.bmp;*.bmp" +
                      "|All files (*.*)|*.*"
                };

                if (Save_Image_Window.ShowDialog() is true)
                {
                    Graph.Plot.SaveFig(Save_Image_Window.FileName);
                }
            }
            catch (Exception Ex)
            {
                Insert_Log("Could not save Waveform Image.", 1);
                Insert_Log(Ex.Message, 1);
            }
        }

        private void RightClick_Copy_Graph_Image(object sender, RoutedEventArgs e)
        {
            System.Drawing.Bitmap Graph_Image = Graph.Plot.Render(); ;

            MemoryStream Image_Memory = new MemoryStream();
            Graph_Image.Save(Image_Memory, System.Drawing.Imaging.ImageFormat.Png);

            BitmapImage Graph_Bitmap = new BitmapImage();
            Graph_Bitmap.BeginInit();
            Graph_Bitmap.StreamSource = new MemoryStream(Image_Memory.ToArray());
            Graph_Bitmap.EndInit();

            Clipboard.SetImage(Graph_Bitmap);

            Graph_Image.Dispose();
            Image_Memory.Dispose();
            Graph_Bitmap.Freeze();

        }
    }
}
