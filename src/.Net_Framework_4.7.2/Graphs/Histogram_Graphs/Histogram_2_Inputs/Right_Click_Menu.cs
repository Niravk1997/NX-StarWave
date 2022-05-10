﻿using MahApps.Metro.Controls;
using Microsoft.Win32;
using System;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Media.Imaging;

namespace Histogram_2_Input
{
    public partial class Histogram_2_Input_Window : MetroWindow
    {
        private MenuItem AutoAxis_MenuItem;

        private MenuItem addCopyImageMenuItem;
        private MenuItem addSaveImageMenuItem;
        private ContextMenu rightClickMenu;

        private void Graph_RightClick_Menu()
        {
            Graph.RightClicked -= Graph.DefaultRightClickEvent;
            Graph.RightClicked += Graph_RightClick_Menu_Options;
            Initialize_Right_Click_Menu();
        }

        private void Initialize_Right_Click_Menu()
        {
            Binding Auto_Axis_Binding = new Binding();
            Auto_Axis_Binding.Source = this;
            Auto_Axis_Binding.Path = new PropertyPath("Axis_Auto");
            Auto_Axis_Binding.Mode = BindingMode.TwoWay;
            Auto_Axis_Binding.UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged;

            AutoAxis_MenuItem = new MenuItem() { Header = "Auto Axis" };
            AutoAxis_MenuItem.IsCheckable = true;
            AutoAxis_MenuItem.SetBinding(MenuItem.IsCheckedProperty, Auto_Axis_Binding);

            addCopyImageMenuItem = new MenuItem() { Header = "Copy Image" };
            addCopyImageMenuItem.Click += RightClick_Copy_Graph_Image;
            addSaveImageMenuItem = new MenuItem() { Header = "Save Image" };
            addSaveImageMenuItem.Click += Right_ClickSave_Graph_Image;

            rightClickMenu = new ContextMenu();
            rightClickMenu.Items.Add(AutoAxis_MenuItem);
            rightClickMenu.Items.Add(addCopyImageMenuItem);
            rightClickMenu.Items.Add(addSaveImageMenuItem);
        }

        private void Graph_RightClick_Menu_Options(object sender, EventArgs e)
        {
            rightClickMenu.IsOpen = true;
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
                    FileName = "Waveform" + "_" + DateTime.Now.ToString("yyyy-MM-dd h-mm-ss tt") + ".png",
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
