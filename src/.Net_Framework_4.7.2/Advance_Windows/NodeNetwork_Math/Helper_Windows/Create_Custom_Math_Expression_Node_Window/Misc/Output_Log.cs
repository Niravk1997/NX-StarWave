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

namespace Create_Custom_Math_Expression_Node
{
    public partial class Create_Custom_Math_Expression_Window : MetroWindow
    {
        private int Auto_Clear_Output_Log_Count = 40;

        //inserts message to the output log
        private void insert_Log(string Message, int Code)
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
            else if (Code == 7) //Benchmark Message (No label)
            {
                Status = "";
                Color = Brushes.Violet;
            }
            else if (Code == 8) //Waveform Preamble Message (No label)
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
                Output_Log_Scroll.ScrollToBottom();
            }));
        }

        private void ClearOutputLog_Click(object sender, RoutedEventArgs e)
        {
            Output_Log.Clear();
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
