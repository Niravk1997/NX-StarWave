﻿using Histogram_2_Input;
using Node_Model_Classes;
using NodeNetwork_Math;
using NX_StarWave;
using NX_StarWave.Waveform_Model_Classes;
using ReactiveUI;
using System;
using System.Globalization;
using System.Media;
using System.Threading;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Threading;

namespace Histogram_Node
{
    public partial class Histogram_Inputs_2_ViewModel : Node_ViewModel
    {
        private Brush Histogram_Graph_ICON_Background_Color_ = Brushes.Transparent;
        public Brush Histogram_Graph_ICON_Background_Color
        {
            get => Histogram_Graph_ICON_Background_Color_;
            set => this.RaiseAndSetIfChanged(ref Histogram_Graph_ICON_Background_Color_, value);
        }
        public ICommand Open_Histogram_Graph_Window_Command { get; private set; }
        private Histogram_2_Input_Window Histogram_Graph_Window;
        private bool Is_Histogram_Graph_window_Open = false;

        private void Open_Histogram_Graph_Window()
        {
            if (Histogram_Graph_Window == null & Is_Histogram_Graph_window_Open == false)
            {
                Is_Histogram_Graph_window_Open = true;
                Histogram_Graph_ICON_Background_Color = Brushes.LimeGreen;

                Thread Window_Thread = new Thread(new ThreadStart(() =>
                {
                    Histogram_Graph_Window = new Histogram_2_Input_Window(Communication_Selected.Company_Name + " " + Communication_Selected.Oscilloscope_Model + " " + this.Name, Units, this.Name, Input_1_Bucket_Count, Input_2_Bucket_Count, Input_1_string, Input_2_string, Input_1_Color, Input_2_Color, Return_Current_Waveform_Data(0), Return_Current_Waveform_Data(1));
                    Histogram_Graph_Window.Show();
                    Histogram_Graph_Window.Closed += Histogram_Graph_Window_Close;
                    Dispatcher.Run();
                }));
                Window_Thread.CurrentCulture = CultureInfo.CreateSpecificCulture("en-US");
                Window_Thread.CurrentUICulture = CultureInfo.CreateSpecificCulture("en-US");
                Window_Thread.SetApartmentState(ApartmentState.STA);
                Window_Thread.IsBackground = true;
                Window_Thread.Start();
            }
            else
            {
                SystemSounds.Exclamation.Play();
            }
        }

        private void Histogram_Graph_Window_Close(object sender, EventArgs e)
        {
            Histogram_Graph_Window.Closed -= Histogram_Graph_Window_Close;
            Histogram_Graph_Window.Dispatcher.BeginInvokeShutdown(DispatcherPriority.Normal);
            Histogram_Graph_Window = null;
            Is_Histogram_Graph_window_Open = false;
            Histogram_Graph_ICON_Background_Color = Brushes.Transparent;
        }

        private void Insert_New_Results_into_Graph(int Input, Node_Waveform_Model Waveform_Data)
        {
            if (Is_Histogram_Graph_window_Open)
            {
                try
                {
                    if (Input == 0)
                    {
                        Histogram_Graph_Window.Input_1_Data_Queue.Add(new Channel_Waveform_Data(true, Waveform_Data.X_Values, Waveform_Data.Y_Values, Waveform_Data.Total_Time, Waveform_Data.Start_Time, Waveform_Data.Stop_Time, Waveform_Data.Data_points, Waveform_Data.Units));
                    }
                    else if (Input == 1)
                    {
                        Histogram_Graph_Window.Input_2_Data_Queue.Add(new Channel_Waveform_Data(true, Waveform_Data.X_Values, Waveform_Data.Y_Values, Waveform_Data.Total_Time, Waveform_Data.Start_Time, Waveform_Data.Stop_Time, Waveform_Data.Data_points, Waveform_Data.Units));
                    }
                }
                catch (Exception)
                {

                }
            }
        }
    }
}
