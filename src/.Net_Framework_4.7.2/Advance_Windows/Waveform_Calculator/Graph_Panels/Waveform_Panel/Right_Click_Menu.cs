using Microsoft.Win32;
using System;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace Waveform_Panel
{
    public partial class Waveform_Panel : UserControl
    {
        private MenuItem AutoAxis_MenuItem;
        private MenuItem Vertical_Markers_MenuItem;
        private MenuItem Horizontal_Markers_MenuItem;
        private MenuItem MouseTrackerMenuItem;

        private MenuItem Voltage_Meas;
        private MenuItem Time_Meas;
        private MenuItem StatisticsMenuItem;

        private MenuItem File_Menu;
        private MenuItem addCopyImageMenuItem;
        private MenuItem addSaveImageMenuItem;
        private MenuItem addDataSaveMenuItem;

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

            if (isContinuous == false)
            {
                Voltage_Meas = new MenuItem() { Header = "Voltage" };
                Voltage_Meas.IsCheckable = true;
                Voltage_Meas.Click += StatisticsMenuItem_Click;

                Time_Meas = new MenuItem() { Header = "Time" };
                Time_Meas.IsCheckable = true;
                Time_Meas.IsChecked = true;
                Time_Meas.Click += Time_Meas_MenuItem_Click;

                StatisticsMenuItem = new MenuItem() { Header = "Statistics", IsCheckable = false };
                StatisticsMenuItem.Items.Add(Voltage_Meas);
                StatisticsMenuItem.Items.Add(Time_Meas);
            }

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

            if (isContinuous == false)
            {
                addCopy_Reference_WaveformMenuItem = new MenuItem() { Header = "Copy Waveform" };
                addCopy_Reference_WaveformMenuItem.Click += AddCopy_Reference_WaveformMenuItem_Click;

                addSave_Reference_WaveformMenuItem = new MenuItem() { Header = "Save Waveform" };
                addSave_Reference_WaveformMenuItem.Click += AddSave_Reference_WaveformMenuItem_Click;
            }

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
            if (isContinuous == false)
            {
                Reference_Menu.Items.Add(addCopy_Reference_WaveformMenuItem);
                Reference_Menu.Items.Add(addSave_Reference_WaveformMenuItem);
            }
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
            rightClickMenu.Items.Add(MouseTrackerMenuItem);
            if (isContinuous == false)
            {
                rightClickMenu.Items.Add(StatisticsMenuItem);
            }
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

        private void StatisticsMenuItem_Click(object sender, RoutedEventArgs e)
        {
            Initialize_Statistics_Annotations();
        }

        private void Time_Meas_MenuItem_Click(object sender, RoutedEventArgs e)
        {
            if (Time_Meas.IsChecked)
            {
                Measure_Frequency_Period = true;
            }
            else
            {
                Measure_Frequency_Period = false;
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
