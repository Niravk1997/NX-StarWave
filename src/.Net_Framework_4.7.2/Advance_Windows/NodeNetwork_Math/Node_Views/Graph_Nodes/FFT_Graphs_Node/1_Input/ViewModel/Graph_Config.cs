using FFT;
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

namespace FFT_Node
{
    public partial class FFT_Inputs_1_ViewModel : Node_ViewModel
    {
        private Brush FFT_Graph_ICON_Background_Color_ = Brushes.Transparent;
        public Brush FFT_Graph_ICON_Background_Color
        {
            get => FFT_Graph_ICON_Background_Color_;
            set => this.RaiseAndSetIfChanged(ref FFT_Graph_ICON_Background_Color_, value);
        }

        public ICommand Open_FFT_Graph_Window_Command { get; private set; }
        private FFT_Plotter FFT_Graph_Window;
        private bool Is_FFT_Graph_window_Open = false;

        private void Open_FFT_Graph_Window()
        {
            if (FFT_Graph_Window == null & Is_FFT_Graph_window_Open == false)
            {
                Is_FFT_Graph_window_Open = true;
                FFT_Graph_ICON_Background_Color = Brushes.LimeGreen;

                Thread Window_Thread = new Thread(new ThreadStart(() =>
                {
                    FFT_Graph_Window = new FFT_Plotter(Communication_Selected.Company_Name + " " + Communication_Selected.Oscilloscope_Model + "" + this.Name, this.Input_1.Name, Input_1_Color, Units, Return_Current_Waveform_Data());
                    FFT_Graph_Window.Show();
                    FFT_Graph_Window.Closed += FFT_Graph_Window_Close;
                    try
                    {
                        Dispatcher.Run();
                    }
                    catch (Exception Ex)
                    {
                        Is_FFT_Graph_window_Open = false;
                        FFT_Graph_Window.Closed -= FFT_Graph_Window_Close;
                        FFT_Graph_Window = null;
                        FFT_Graph_ICON_Background_Color = Brushes.Transparent;
                        NodeNetwork_MainWindow.Insert_Log(Ex.Message, 1);
                        NodeNetwork_MainWindow.Insert_Log("FFT Graph Crashed.", 1);
                    }
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

        private void FFT_Graph_Window_Close(object sender, EventArgs e)
        {
            FFT_Graph_Window.Closed -= FFT_Graph_Window_Close;
            FFT_Graph_Window.Dispatcher.BeginInvokeShutdown(DispatcherPriority.Normal);
            FFT_Graph_Window = null;
            Is_FFT_Graph_window_Open = false;
            FFT_Graph_ICON_Background_Color = Brushes.Transparent;
        }

        private void Insert_New_Results_into_Graph(Node_Waveform_Model Waveform_Data)
        {
            if (Is_FFT_Graph_window_Open)
            {
                try
                {
                    FFT_Graph_Window.Waveform_Data_Queue.Add(new Channel_Waveform_Data(true, Waveform_Data.X_Values, Waveform_Data.Y_Values, Waveform_Data.Total_Time, Waveform_Data.Start_Time, Waveform_Data.Stop_Time, Waveform_Data.Data_points, Waveform_Data.Units));
                }
                catch (Exception)
                {

                }
            }
        }
    }
}
