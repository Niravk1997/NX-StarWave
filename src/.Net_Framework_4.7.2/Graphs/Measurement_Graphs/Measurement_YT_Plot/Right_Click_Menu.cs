using MahApps.Metro.Controls;
using Microsoft.Win32;
using System;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Media.Imaging;

namespace Measurement_Plot
{
    public partial class Measurement_Plot_Window : MetroWindow
    {
        private MenuItem AutoAxis_MenuItem;
        private MenuItem Vertical_Markers_MenuItem;
        private MenuItem Horizontal_Markers_MenuItem;

        private MenuItem File_Menu;
        private MenuItem addCopyImageMenuItem;
        private MenuItem addSaveImageMenuItem;

        private MenuItem Reference_Menu;
        private MenuItem addCopy_Reference_WaveformMenuItem;
        private MenuItem addSave_Reference_WaveformMenuItem;
        private MenuItem Reference_Waveform_0_Menu;
        private MenuItem addPaste_Reference_Waveform_0_MenuItem;
        private MenuItem addClear_Reference_Waveform_0_MenuItem;
        private MenuItem Reference_Waveform_1_Menu;
        private MenuItem addPaste_Reference_Waveform_1_MenuItem;
        private MenuItem addClear_Reference_Waveform_1_MenuItem;
        private MenuItem Reference_Waveform_2_Menu;
        private MenuItem addPaste_Reference_Waveform_2_MenuItem;
        private MenuItem addClear_Reference_Waveform_2_MenuItem;
        private MenuItem Reference_Waveform_3_Menu;
        private MenuItem addPaste_Reference_Waveform_3_MenuItem;
        private MenuItem addClear_Reference_Waveform_3_MenuItem;
        private MenuItem Reference_Waveform_4_Menu;
        private MenuItem addPaste_Reference_Waveform_4_MenuItem;
        private MenuItem addClear_Reference_Waveform_4_MenuItem;
        private MenuItem addClearAll_WaveformMenuItem;

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

            Binding Vertical_Markers_Active_Binding = new Binding();
            Vertical_Markers_Active_Binding.Source = this;
            Vertical_Markers_Active_Binding.Path = new PropertyPath("Vertical_Markers_Active");
            Vertical_Markers_Active_Binding.Mode = BindingMode.TwoWay;
            Vertical_Markers_Active_Binding.UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged;

            Vertical_Markers_MenuItem = new MenuItem() { Header = "Vertical Markers" };
            Vertical_Markers_MenuItem.Click += Right_Click_Enable_Vertical_Markers;
            Vertical_Markers_MenuItem.IsCheckable = true;
            Vertical_Markers_MenuItem.SetBinding(MenuItem.IsCheckedProperty, Vertical_Markers_Active_Binding);

            Binding Horizontal_Markers_Active_Binding = new Binding();
            Horizontal_Markers_Active_Binding.Source = this;
            Horizontal_Markers_Active_Binding.Path = new PropertyPath("Horizontal_Markers_Active");
            Horizontal_Markers_Active_Binding.Mode = BindingMode.TwoWay;
            Horizontal_Markers_Active_Binding.UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged;

            Horizontal_Markers_MenuItem = new MenuItem() { Header = "Horizontal Markers" };
            Horizontal_Markers_MenuItem.Click += Right_Click_Enable_Horizontal_Markers;
            Horizontal_Markers_MenuItem.IsCheckable = true;
            Horizontal_Markers_MenuItem.SetBinding(MenuItem.IsCheckedProperty, Horizontal_Markers_Active_Binding);

            addCopyImageMenuItem = new MenuItem() { Header = "Copy Image" };
            addCopyImageMenuItem.Click += RightClick_Copy_Graph_Image;
            addSaveImageMenuItem = new MenuItem() { Header = "Save Image" };
            addSaveImageMenuItem.Click += Right_ClickSave_Graph_Image;

            File_Menu = new MenuItem() { Header = "File", IsCheckable = false };
            File_Menu.Items.Add(addCopyImageMenuItem);
            File_Menu.Items.Add(addSaveImageMenuItem);

            addCopy_Reference_WaveformMenuItem = new MenuItem() { Header = "Copy Waveform" };
            addCopy_Reference_WaveformMenuItem.Click += AddCopy_Reference_WaveformMenuItem_Click;

            addSave_Reference_WaveformMenuItem = new MenuItem() { Header = "Save Waveform" };
            addSave_Reference_WaveformMenuItem.Click += AddSave_Reference_WaveformMenuItem_Click;

            addClearAll_WaveformMenuItem = new MenuItem() { Header = "Clear All Waveforms" };
            addClearAll_WaveformMenuItem.Click += AddClearAll_WaveformMenuItem_Click; ;

            addPaste_Reference_Waveform_0_MenuItem = new MenuItem() { Header = "Paste" };
            addPaste_Reference_Waveform_0_MenuItem.Click += AddPaste_Reference_Waveform_0_MenuItem_Click;
            addClear_Reference_Waveform_0_MenuItem = new MenuItem() { Header = "Clear" };
            addClear_Reference_Waveform_0_MenuItem.Click += AddClear_Reference_Waveform_0_MenuItem_Click;
            Reference_Waveform_0_Menu = new MenuItem() { Header = "Reference 1", IsCheckable = false };
            Reference_Waveform_0_Menu.Items.Add(addPaste_Reference_Waveform_0_MenuItem);
            Reference_Waveform_0_Menu.Items.Add(addClear_Reference_Waveform_0_MenuItem);

            addPaste_Reference_Waveform_1_MenuItem = new MenuItem() { Header = "Paste" };
            addPaste_Reference_Waveform_1_MenuItem.Click += AddPaste_Reference_Waveform_1_MenuItem_Click;
            addClear_Reference_Waveform_1_MenuItem = new MenuItem() { Header = "Clear" };
            addClear_Reference_Waveform_1_MenuItem.Click += AddClear_Reference_Waveform_1_MenuItem_Click;
            Reference_Waveform_1_Menu = new MenuItem() { Header = "Reference 2", IsCheckable = false };
            Reference_Waveform_1_Menu.Items.Add(addPaste_Reference_Waveform_1_MenuItem);
            Reference_Waveform_1_Menu.Items.Add(addClear_Reference_Waveform_1_MenuItem);

            addPaste_Reference_Waveform_2_MenuItem = new MenuItem() { Header = "Paste" };
            addPaste_Reference_Waveform_2_MenuItem.Click += AddPaste_Reference_Waveform_2_MenuItem_Click;
            addClear_Reference_Waveform_2_MenuItem = new MenuItem() { Header = "Clear" };
            addClear_Reference_Waveform_2_MenuItem.Click += AddClear_Reference_Waveform_2_MenuItem_Click;
            Reference_Waveform_2_Menu = new MenuItem() { Header = "Reference 3", IsCheckable = false };
            Reference_Waveform_2_Menu.Items.Add(addPaste_Reference_Waveform_2_MenuItem);
            Reference_Waveform_2_Menu.Items.Add(addClear_Reference_Waveform_2_MenuItem);

            addPaste_Reference_Waveform_3_MenuItem = new MenuItem() { Header = "Paste" };
            addPaste_Reference_Waveform_3_MenuItem.Click += AddPaste_Reference_Waveform_3_MenuItem_Click;
            addClear_Reference_Waveform_3_MenuItem = new MenuItem() { Header = "Clear" };
            addClear_Reference_Waveform_3_MenuItem.Click += AddClear_Reference_Waveform_3_MenuItem_Click;
            Reference_Waveform_3_Menu = new MenuItem() { Header = "Reference 4", IsCheckable = false };
            Reference_Waveform_3_Menu.Items.Add(addPaste_Reference_Waveform_3_MenuItem);
            Reference_Waveform_3_Menu.Items.Add(addClear_Reference_Waveform_3_MenuItem);

            addPaste_Reference_Waveform_4_MenuItem = new MenuItem() { Header = "Paste" };
            addPaste_Reference_Waveform_4_MenuItem.Click += AddPaste_Reference_Waveform_4_MenuItem_Click;
            addClear_Reference_Waveform_4_MenuItem = new MenuItem() { Header = "Clear" };
            addClear_Reference_Waveform_4_MenuItem.Click += AddClear_Reference_Waveform_4_MenuItem_Click;
            Reference_Waveform_4_Menu = new MenuItem() { Header = "Reference 5", IsCheckable = false };
            Reference_Waveform_4_Menu.Items.Add(addPaste_Reference_Waveform_4_MenuItem);
            Reference_Waveform_4_Menu.Items.Add(addClear_Reference_Waveform_4_MenuItem);


            Reference_Menu = new MenuItem() { Header = "Reference", IsCheckable = false };
            Reference_Menu.Items.Add(addCopy_Reference_WaveformMenuItem);
            Reference_Menu.Items.Add(addSave_Reference_WaveformMenuItem);
            Reference_Menu.Items.Add(Reference_Waveform_0_Menu);
            Reference_Menu.Items.Add(Reference_Waveform_1_Menu);
            Reference_Menu.Items.Add(Reference_Waveform_2_Menu);
            Reference_Menu.Items.Add(Reference_Waveform_3_Menu);
            Reference_Menu.Items.Add(Reference_Waveform_4_Menu);
            Reference_Menu.Items.Add(addClearAll_WaveformMenuItem);

            rightClickMenu = new ContextMenu();
            rightClickMenu.Items.Add(AutoAxis_MenuItem);
            rightClickMenu.Items.Add(Vertical_Markers_MenuItem);
            rightClickMenu.Items.Add(Horizontal_Markers_MenuItem);
            rightClickMenu.Items.Add(Reference_Menu);
            rightClickMenu.Items.Add(File_Menu);
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
            }
            else
            {
                Insert_Log("Graph's Auto-Axis feature is disabled.", 2);
            }
        }

        private void Right_Click_Enable_Vertical_Markers(object sender, EventArgs e)
        {
            Add_Clear_Vertical_Markers();
        }

        private void Right_Click_Enable_Horizontal_Markers(object sender, EventArgs e)
        {
            Add_Clear_Horizontal_Markers();
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
            try
            {
                Copy_Graph_to_Image();
            }
            catch (Exception Ex)
            {
                Insert_Log(Ex.Message, 1);
            }

        }

        private void Copy_Graph_to_Image()
        {
            System.Drawing.Bitmap Graph_Image = Graph.Plot.Render();

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

        private void AddCopy_Reference_WaveformMenuItem_Click(object sender, RoutedEventArgs e)
        {
            Copy_Reference_Data_Clipboard();
        }

        private void AddSave_Reference_WaveformMenuItem_Click(object sender, RoutedEventArgs e)
        {
            Save_Reference_Data_File();
        }

        private void AddClear_Reference_Waveform_0_MenuItem_Click(object sender, RoutedEventArgs e)
        {
            Clear_Reference_Waveform(0);
        }

        private void AddPaste_Reference_Waveform_0_MenuItem_Click(object sender, RoutedEventArgs e)
        {
            Paste_Data_Clipboard(0);
        }

        private void AddClear_Reference_Waveform_1_MenuItem_Click(object sender, RoutedEventArgs e)
        {
            Clear_Reference_Waveform(1);
        }

        private void AddPaste_Reference_Waveform_1_MenuItem_Click(object sender, RoutedEventArgs e)
        {
            Paste_Data_Clipboard(1);
        }

        private void AddClear_Reference_Waveform_2_MenuItem_Click(object sender, RoutedEventArgs e)
        {
            Clear_Reference_Waveform(2);
        }

        private void AddPaste_Reference_Waveform_2_MenuItem_Click(object sender, RoutedEventArgs e)
        {
            Paste_Data_Clipboard(2);
        }

        private void AddClear_Reference_Waveform_3_MenuItem_Click(object sender, RoutedEventArgs e)
        {
            Clear_Reference_Waveform(3);
        }

        private void AddPaste_Reference_Waveform_3_MenuItem_Click(object sender, RoutedEventArgs e)
        {
            Paste_Data_Clipboard(3);
        }

        private void AddClear_Reference_Waveform_4_MenuItem_Click(object sender, RoutedEventArgs e)
        {
            Clear_Reference_Waveform(4);
        }

        private void AddPaste_Reference_Waveform_4_MenuItem_Click(object sender, RoutedEventArgs e)
        {
            Paste_Data_Clipboard(4);
        }

        private void AddClearAll_WaveformMenuItem_Click(object sender, RoutedEventArgs e)
        {
            Clear_Reference_Waveform(10);
        }
    }
}
