using Microsoft.Win32;
using System;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace Histogram_Panel
{
    public partial class Histogram_Panel : UserControl
    {
        private MenuItem AutoAxis_MenuItem;
        private MenuItem MouseTrackerMenuItem;
        private MenuItem File_Menu;
        private MenuItem addCopyImageMenuItem;
        private MenuItem addSaveImageMenuItem;
        private MenuItem addSaveDataMenuItem;

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

            MouseTrackerMenuItem = new MenuItem() { Header = "Mouse Tracker" };
            MouseTrackerMenuItem.IsCheckable = true;
            MouseTrackerMenuItem.IsChecked = false;
            MouseTrackerMenuItem.Click += MouseTrackerMenuItem_Click;

            addCopyImageMenuItem = new MenuItem() { Header = "Copy Image" };
            addCopyImageMenuItem.Click += RightClick_Copy_Graph_Image;
            addSaveImageMenuItem = new MenuItem() { Header = "Save Image" };
            addSaveImageMenuItem.Click += Right_ClickSave_Graph_Image;
            addSaveDataMenuItem = new MenuItem() { Header = "Save Data" };
            addSaveDataMenuItem.Click += AddDataSaveMenuItem_Click;

            File_Menu = new MenuItem() { Header = "File", IsCheckable = false };
            File_Menu.Items.Add(addCopyImageMenuItem);
            File_Menu.Items.Add(addSaveImageMenuItem);
            File_Menu.Items.Add(addSaveDataMenuItem);

            rightClickMenu = new ContextMenu();
            rightClickMenu.Items.Add(AutoAxis_MenuItem);
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
                double[] X_Values = new double[X_Data.Length];
                double[] Y_Values = new double[Y_Data.Length];
                Array.Copy(X_Data, X_Values, X_Data.Length);
                Array.Copy(Y_Data, Y_Values, Y_Data.Length);
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
                        if (isContinuous == false)
                        {
                            for (int i = 0; i < X_Values.Length; i++)
                            {
                                datatotxt.WriteLine(X_Values[i] + "," + Y_Values[i]);
                            }
                        }
                        else
                        {
                            for (int i = 0; i < Continuous_Counter; i++)
                            {
                                datatotxt.WriteLine(i + "," + Y_Values[i]);
                            }
                        }
                    }
                }
            }
            catch (Exception) { }
        }
    }
}
