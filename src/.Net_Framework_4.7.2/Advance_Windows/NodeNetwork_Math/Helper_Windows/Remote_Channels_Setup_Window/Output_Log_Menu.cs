﻿using MahApps.Metro.Controls;
using Microsoft.Win32;
using System;
using System.IO;
using System.Linq;
using System.Threading;
using System.Windows;
using System.Windows.Documents;
using System.Windows.Media;
using System.Windows.Threading;

namespace Remote_Channels_Setup_Window_Config
{
    public partial class Remote_Channels_Setup_Window : MetroWindow
    {
        //Auto clear the output log after a specific amount of items inside the log has been reached.
        private int Auto_Clear_Output_Log_Count = 40; //This integer variable is thread safe, interlocked.exchange is used.

        //Inserts a message into the output log control
        private void Insert_Log(string Message, int Code)
        {
            string date = DateTime.Now.ToString("yyyy-MM-dd h:mm:ss tt");
            SolidColorBrush Color;
            this.Dispatcher.Invoke(DispatcherPriority.ContextIdle, new ThreadStart(delegate
            {
                if (Output_Log.Inlines.Count >= Auto_Clear_Output_Log_Count)
                {
                    Output_Log.Text = String.Empty;
                    Output_Log.Inlines.Clear();
                    Output_Log.Inlines.Add(new Run("[" + date + "]" + " " + "Output Log has been auto cleared. \n") { Foreground = Brushes.Green });
                }
            }));
            string Status = "";
            switch (Code)
            {
                case 0:
                    Status = "[Success]";
                    Color = Brushes.Green;
                    break;
                case 1:
                    Status = "[Error]";
                    Color = Brushes.Red;
                    break;
                case 2:
                    Status = "[Warning]";
                    Color = Brushes.Orange;
                    break;
                case 3:
                    Status = "[Statistics]";
                    Color = Brushes.DodgerBlue;
                    break;
                case 4:
                    Status = "[Math]";
                    Color = Brushes.BlueViolet;
                    break;
                case 5:
                    Status = "[Message]";
                    Color = Brushes.Black;
                    break;
                default:
                    Status = "";
                    Color = Brushes.Magenta;
                    break;
            }
            this.Dispatcher.Invoke(DispatcherPriority.Background, new ThreadStart(delegate
            {
                Output_Log.Inlines.Add(new Run("[" + date + "]" + " " + Status + " " + Message + "\n") { Foreground = Color });
                Output_Log_Scroll.ScrollToBottom();
            }));
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
                        datatotxt.WriteLine(String.Join(String.Empty, Output_Log.Inlines.Select(line => line.ContentStart.GetTextInRun(LogicalDirection.Forward))).ToString());
                    }
                }
            }
            catch (Exception Ex)
            {
                Insert_Log("Could not save Output Log to text file.", 1);
                Insert_Log(Ex.Message, 1);
            }
        }

        private void Clear_Log_Click(object sender, RoutedEventArgs e)
        {
            this.Dispatcher.Invoke(DispatcherPriority.Normal, new ThreadStart(delegate
            {
                Output_Log.Text = String.Empty;
                Output_Log.Inlines.Clear();
            }));
        }
    }
}
