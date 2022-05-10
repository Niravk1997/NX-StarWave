using MahApps.Metro.Controls;
using Microsoft.Win32;
using System;
using System.IO;
using System.Linq;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Threading;

namespace Query_Measurements_Config
{
    public partial class Query_Measurement_Config_Window : MetroWindow
    {
        private int Auto_Clear_Output_Log_Count = 40;

        //inserts message to the output log
        internal void insert_Log(string Message, int Code)
        {
            string date = DateTime.Now.ToString("yyyy-MM-dd h:mm:ss tt");
            SolidColorBrush Color = Brushes.Black;
            string Status = "";
            if (Code == 1) //Error Message
            {
                Status = "[Error]";
                Color = Brushes.Red;
            }
            else if (Code == 0) //Success Message
            {
                Status = "[Success]";
                Color = Brushes.Green;
            }
            else if (Code == 2) //Warning Message
            {
                Status = "[Warning]";
                Color = Brushes.Orange;
            }
            else if (Code == 3) //Config Message
            {
                Status = "";
                Color = Brushes.Blue;
            }
            else if (Code == 4)//Standard Message
            {
                Status = "";
                Color = Brushes.Black;
            }
            else if (Code == 5) //Success Message (No label)
            {
                Status = "";
                Color = Brushes.Green;
            }
            else if (Code == 6) //Warning Message (No label)
            {
                Status = "";
                Color = Brushes.Orange;
            }
            else if (Code == 7) //SEND Message (No label)
            {
                Status = "";
                Color = Brushes.DodgerBlue;
            }
            else if (Code == 8) //RECEIVED Message (No label)
            {
                Status = "";
                Color = Brushes.DarkViolet;
            }
            else if (Code == 9) //Error Message (No label)
            {
                Status = "";
                Color = Brushes.Red;
            }
            this.Dispatcher.BeginInvoke(DispatcherPriority.Normal, new ThreadStart(delegate
            {
                if (Output_Log.Count >= Auto_Clear_Output_Log_Count)
                {
                    Output_Log.Clear();
                    TextBlock Output_Log_Cleared_Message = new TextBlock
                    {
                        Foreground = Brushes.Green,
                        Text = "Output Log cleared by Auto Clear Log."
                    };
                    Output_Log.Add(Output_Log_Cleared_Message);
                }
                TextBlock Output_Log_Text = new TextBlock
                {
                    Foreground = Color,
                    Text = "[" + date + "]" + " " + Status + " " + Message.Trim()
                };
                Output_Log.Add(Output_Log_Text);
                if (Auto_Scroll.IsChecked)
                {
                    Output_Log_Scroll.ScrollToBottom();
                }
            }));
        }

        private void Auto_Scroll_Click(object sender, RoutedEventArgs e)
        {
            if (Auto_Scroll.IsChecked == true)
            {
                insert_Log("Output Log Auto Scroll Enabled.", 0);
            }
            else
            {
                insert_Log("Output Log Auto Scroll Disabled.", 0);
            }
        }

        private void Auto_Clear_20_Click(object sender, RoutedEventArgs e)
        {
            Interlocked.Exchange(ref Auto_Clear_Output_Log_Count, 20);
            insert_Log("Output Log will be cleared after " + Auto_Clear_Output_Log_Count + " logs are inserted into it.", 0);
            Auto_Clear_20.IsChecked = true;
            Auto_Clear_40.IsChecked = false;
            Auto_Clear_80.IsChecked = false;
            Auto_Clear_100.IsChecked = false;
        }

        private void Auto_Clear_40_Click(object sender, RoutedEventArgs e)
        {
            Interlocked.Exchange(ref Auto_Clear_Output_Log_Count, 40);
            insert_Log("Output Log will be cleared after " + Auto_Clear_Output_Log_Count + " logs are inserted into it.", 0);
            Auto_Clear_20.IsChecked = false;
            Auto_Clear_40.IsChecked = true;
            Auto_Clear_80.IsChecked = false;
            Auto_Clear_100.IsChecked = false;
        }

        private void Auto_Clear_80_Click(object sender, RoutedEventArgs e)
        {
            Interlocked.Exchange(ref Auto_Clear_Output_Log_Count, 80);
            insert_Log("Output Log will be cleared after " + Auto_Clear_Output_Log_Count + " logs are inserted into it.", 0);
            Auto_Clear_20.IsChecked = false;
            Auto_Clear_40.IsChecked = false;
            Auto_Clear_80.IsChecked = true;
            Auto_Clear_100.IsChecked = false;
        }

        private void Auto_Clear_100_Click(object sender, RoutedEventArgs e)
        {
            Interlocked.Exchange(ref Auto_Clear_Output_Log_Count, 100);
            insert_Log("Output Log will be cleared after " + Auto_Clear_Output_Log_Count + " logs are inserted into it.", 0);
            Auto_Clear_20.IsChecked = false;
            Auto_Clear_40.IsChecked = false;
            Auto_Clear_80.IsChecked = false;
            Auto_Clear_100.IsChecked = true;
        }

        private void Save_Log_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var Save_Data_Text_Window = new SaveFileDialog
                {
                    FileName = "Output Log_" + DateTime.Now.ToString("yyyy-MM-dd h-mm-ss tt") + ".txt",
                    Filter = "Normal text Files (*.txt)|*.txt;*.txt" +
                      "|All files (*.*)|*.*"
                };

                if (Save_Data_Text_Window.ShowDialog() is true)
                {
                    using (TextWriter datatotxt = new StreamWriter(Save_Data_Text_Window.FileName, false))
                    {
                        for (int i = 0; i < Output_Log.Count; i++)
                        {
                            datatotxt.WriteLine(Output_Log.ElementAt(i).Text);
                        }
                    }
                }
            }
            catch (Exception Ex)
            {
                insert_Log("Could not save Output Log to text file.", 1);
                insert_Log(Ex.Message, 1);
            }
        }

        private void Clear_Log_Click(object sender, RoutedEventArgs e)
        {
            Output_Log.Clear();
        }
    }
}
