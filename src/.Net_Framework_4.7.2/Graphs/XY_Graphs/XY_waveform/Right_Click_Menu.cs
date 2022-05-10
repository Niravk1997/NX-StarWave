using MahApps.Metro.Controls;
using Microsoft.Win32;
using System;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace XY_Waveform
{
    public partial class XY_Waveform_Plotter : MetroWindow
    {
        private MenuItem AutoAxis_MenuItem;
        private MenuItem Vertical_Markers_MenuItem;
        private MenuItem Horizontal_Markers_MenuItem;
        private MenuItem addCopyImageMenuItem;
        private MenuItem addSaveImageMenuItem;
        private ContextMenu rightClickMenu;

        private MenuItem Waveform_AutoAxis_MenuItem;
        private MenuItem Waveform_addCopyImageMenuItem;
        private MenuItem Waveform_addSaveImageMenuItem;
        private ContextMenu Waveform_rightClickMenu;

        private bool Waveform_Auto_Axis = true;

        private void Graph_RightClick_Menu()
        {
            Graph.RightClicked -= Graph.DefaultRightClickEvent;
            Graph.RightClicked += Graph_RightClick_Menu_Options;

            Waveform_Graph.RightClicked -= Waveform_Graph.DefaultRightClickEvent;
            Waveform_Graph.RightClicked += Waveform_Graph_RightClick_Menu_Options;

            Initialize_Right_Click_Menu();
            Waveform_Initialize_Right_Click_Menu();
        }

        private void Waveform_Initialize_Right_Click_Menu()
        {
            Waveform_AutoAxis_MenuItem = new MenuItem() { Header = "Auto Axis" };
            Waveform_AutoAxis_MenuItem.Click += Waveform_Right_Click_AutoAxis;
            Waveform_AutoAxis_MenuItem.IsCheckable = true;
            Waveform_AutoAxis_MenuItem.IsChecked = true;

            Waveform_addCopyImageMenuItem = new MenuItem() { Header = "Copy Image" };
            Waveform_addCopyImageMenuItem.Click += Waveform_RightClick_Copy_Graph_Image;
            Waveform_addSaveImageMenuItem = new MenuItem() { Header = "Save Image" };
            Waveform_addSaveImageMenuItem.Click += Waveform_Right_ClickSave_Graph_Image;

            Waveform_rightClickMenu = new ContextMenu();
            Waveform_rightClickMenu.Items.Add(Waveform_AutoAxis_MenuItem);
            Waveform_rightClickMenu.Items.Add(Waveform_addCopyImageMenuItem);
            Waveform_rightClickMenu.Items.Add(Waveform_addSaveImageMenuItem);
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

            addCopyImageMenuItem = new MenuItem() { Header = "Copy Image" };
            addCopyImageMenuItem.Click += RightClick_Copy_Graph_Image;
            addSaveImageMenuItem = new MenuItem() { Header = "Save Image" };
            addSaveImageMenuItem.Click += Right_ClickSave_Graph_Image;

            rightClickMenu = new ContextMenu();
            rightClickMenu.Items.Add(AutoAxis_MenuItem);
            rightClickMenu.Items.Add(Vertical_Markers_MenuItem);
            rightClickMenu.Items.Add(Horizontal_Markers_MenuItem);
            rightClickMenu.Items.Add(addCopyImageMenuItem);
            rightClickMenu.Items.Add(addSaveImageMenuItem);
        }

        private void Waveform_Graph_RightClick_Menu_Options(object sender, EventArgs e)
        {
            Waveform_rightClickMenu.IsOpen = true;
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
                    FileName = "XY_Plot" + "_" + DateTime.Now.ToString("yyyy-MM-dd h-mm-ss tt") + ".png",
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
                Insert_Log("Could not save XY Waveform Image.", 1);
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

        private void Waveform_Right_Click_AutoAxis(object sender, EventArgs e)
        {
            if (Waveform_AutoAxis_MenuItem.IsChecked == true)
            {
                Waveform_Auto_Axis = true;
            }
            else
            {
                Waveform_Auto_Axis = false;
            }
        }

        private void Waveform_Right_ClickSave_Graph_Image(object sender, EventArgs e)
        {
            Waveform_Save_Graph_to_Image();
        }

        private void Waveform_Save_Graph_to_Image()
        {
            try
            {
                var Save_Image_Window = new SaveFileDialog
                {
                    FileName = "Waveform" + "_" + DateTime.Now.ToString("yyyy-MM-dd h-mm-ss tt") + ".png",
                    Filter = "PNG Files (*.png)|*.png;*.png" +
                      "|JPG Files (*.jpg, *.jpeg)|*.jpg;*.jpeg" +
                      "|BMP Files (*.bmp)|*.bmp;*.bmp" +
                      "|All files (*.*)|*.*"
                };

                if (Save_Image_Window.ShowDialog() is true)
                {
                    Waveform_Graph.Plot.SaveFig(Save_Image_Window.FileName);
                }
            }
            catch (Exception Ex)
            {
                Insert_Log("Could not save Waveform Image.", 1);
                Insert_Log(Ex.Message, 1);
            }
        }

        private void Waveform_RightClick_Copy_Graph_Image(object sender, RoutedEventArgs e)
        {
            System.Drawing.Bitmap Graph_Image = Waveform_Graph.Plot.Render(); ;

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
