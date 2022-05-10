using Microsoft.Win32;
using System;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace FFT_Panel
{
    public partial class FFT_Panel : UserControl
    {
        private MenuItem AutoAxis_MenuItem;
        private MenuItem Vertical_Markers_MenuItem;
        private MenuItem Horizontal_Markers_MenuItem;
        private MenuItem MouseTrackerMenuItem;
        private MenuItem File_Menu;
        private MenuItem addCopyImageMenuItem;
        private MenuItem addSaveImageMenuItem;
        private MenuItem addDataSaveMenuItem;

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

            MouseTrackerMenuItem = new MenuItem() { Header = "Mouse Tracker" };
            MouseTrackerMenuItem.Click += MouseTrackerMenuItem_Click;
            MouseTrackerMenuItem.IsCheckable = true;

            addCopyImageMenuItem = new MenuItem() { Header = "Copy Image" };
            addCopyImageMenuItem.Click += RightClick_Copy_Graph_Image;
            addSaveImageMenuItem = new MenuItem() { Header = "Save Image" };
            addSaveImageMenuItem.Click += Right_ClickSave_Graph_Image;
            addDataSaveMenuItem = new MenuItem() { Header = "Save Data" };
            addDataSaveMenuItem.Click += AddDataSaveMenuItem_Click;

            File_Menu = new MenuItem() { Header = "File", IsCheckable = false };
            File_Menu.Items.Add(addCopyImageMenuItem);
            File_Menu.Items.Add(addSaveImageMenuItem);
            File_Menu.Items.Add(addDataSaveMenuItem);

            rightClickMenu = new ContextMenu();
            rightClickMenu.Items.Add(AutoAxis_MenuItem);
            rightClickMenu.Items.Add(Vertical_Markers_MenuItem);
            rightClickMenu.Items.Add(Horizontal_Markers_MenuItem);
            rightClickMenu.Items.Add(MouseTrackerMenuItem);
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

            }
            else
            {

            }
        }

        private void Right_Click_Enable_Vertical_Markers(object sender, EventArgs e)
        {
            if (Vertical_Markers_MenuItem.IsChecked == true)
            {
                Add_Clear_Vertical_Markers();
            }
            else
            {
                Add_Clear_Vertical_Markers();
            }
        }

        private void Right_Click_Enable_Horizontal_Markers(object sender, EventArgs e)
        {
            if (Horizontal_Markers_MenuItem.IsChecked == true)
            {
                Add_Clear_Horizontal_Markers();
            }
            else
            {
                Add_Clear_Horizontal_Markers();
            }
        }

        private void MouseTrackerMenuItem_Click(object sender, RoutedEventArgs e)
        {
            Show_Mouse_Tracker();
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
            catch (Exception)
            {

            }
        }

        private void RightClick_Copy_Graph_Image(object sender, RoutedEventArgs e)
        {
            try
            {
                Copy_Graph_to_Image();
            }
            catch (Exception)
            {

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

        private void AddDataSaveMenuItem_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                double[] Frequency = new double[this.Frequency.Length];
                double[] Magnitude = new double[this.Magnitude.Length];
                double[] Phase = new double[this.Phase.Length];
                Array.Copy(this.Frequency, Frequency, this.Frequency.Length);
                Array.Copy(this.Magnitude, Magnitude, this.Magnitude.Length);
                Array.Copy(this.Phase, Phase, this.Phase.Length);
                double Total_Time = this.Total_Time;
                double Start_Time = this.Start_Time;
                double Stop_Time = this.Stop_Time;
                int Data_Points = this.Data_Points;
                string Channel_Info = this.Channel_Info;
                var Save_Data_Text_Window = new SaveFileDialog
                {
                    FileName = "Waveform Data" + "_" + DateTime.Now.ToString("yyyy-MM-dd h-mm-ss tt") + ".txt",
                    Filter = "Normal text Files (*.txt)|*.txt;*.txt" +
                   "|All files (*.*)|*.*"
                };
                if (Save_Data_Text_Window.ShowDialog() is true)
                {
                    using (TextWriter datatotxt = new StreamWriter(Save_Data_Text_Window.FileName, false))
                    {
                        datatotxt.WriteLine(Total_Time + "," + Start_Time + "," + Stop_Time + "," + Data_Points + "," + Channel_Info);
                        if (Show_Phase == false)
                        {
                            for (int i = 0; i < Frequency.Length; i++)
                            {
                                datatotxt.WriteLine(Frequency[i] + "," + Magnitude[i]);
                            }
                        }
                        else
                        {
                            for (int i = 0; i < Frequency.Length; i++)
                            {
                                datatotxt.WriteLine(Frequency[i] + "," + Magnitude[i] + "," + Phase[i]);
                            }
                        }
                    }
                }
            }
            catch (Exception) { }
        }
    }
}
