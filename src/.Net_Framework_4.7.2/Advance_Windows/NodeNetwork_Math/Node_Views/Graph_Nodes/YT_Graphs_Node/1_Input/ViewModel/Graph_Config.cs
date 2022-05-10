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
using YT;

namespace YT_Node
{
    public partial class YT_Inputs_1_ViewModel : Node_ViewModel
    {
        private Brush YT_Graph_ICON_Background_Color_ = Brushes.Transparent;
        public Brush YT_Graph_ICON_Background_Color
        {
            get => YT_Graph_ICON_Background_Color_;
            set => this.RaiseAndSetIfChanged(ref YT_Graph_ICON_Background_Color_, value);
        }
        public ICommand Open_YT_Graph_Window_Command { get; private set; }
        private YT_Plotter YT_Graph_Window;
        private bool Is_YT_Graph_window_Open = false;

        private void Open_YT_Graph_Window()
        {
            if (YT_Graph_Window == null & Is_YT_Graph_window_Open == false)
            {
                Is_YT_Graph_window_Open = true;
                YT_Graph_ICON_Background_Color = Brushes.LimeGreen;

                Thread Window_Thread = new Thread(new ThreadStart(() =>
                {
                    YT_Graph_Window = new YT_Plotter(Communication_Selected.Company_Name + " " + Communication_Selected.Oscilloscope_Model + "" + this.Name, this.Input_1.Name, Input_1_Color, this.Input_1.Name, Units, Return_Current_Waveform_Data());
                    YT_Graph_Window.Show();
                    YT_Graph_Window.Closed += YT_Graph_Window_Close;
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

        private void YT_Graph_Window_Close(object sender, EventArgs e)
        {
            YT_Graph_Window.Closed -= YT_Graph_Window_Close;
            YT_Graph_Window.Dispatcher.BeginInvokeShutdown(DispatcherPriority.Normal);
            YT_Graph_Window = null;
            Is_YT_Graph_window_Open = false;
            YT_Graph_ICON_Background_Color = Brushes.Transparent;
        }

        private void Insert_New_Results_into_Graph(Node_Waveform_Model Waveform_Data)
        {
            if (Is_YT_Graph_window_Open)
            {
                try
                {
                    YT_Graph_Window.Waveform_Data_Queue.Add(new Channel_Waveform_Data(true, Waveform_Data.X_Values, Waveform_Data.Y_Values, Waveform_Data.Total_Time, Waveform_Data.Start_Time, Waveform_Data.Stop_Time, Waveform_Data.Data_points, Waveform_Data.Units));
                }
                catch (Exception)
                {

                }
            }
        }
    }
}
