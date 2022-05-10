using MahApps.Metro.Controls;
using System;
using System.Globalization;
using System.Threading;
using System.Windows.Threading;

namespace Reference_Calculator
{
    public partial class Reference_Config_Panel : MetroWindow
    {
        private void Initialize_Data_Anytime_FFT_Window(string Title, string Channel_Info, string Channel_Title, string[] FFT_Config, double[] X_Waveform_Data, double[] Y_Waveform_Data, double Total_Time, double Start_Time, double Stop_Time, int Data_Points)
        {
            string FFT_Color = FFT_Config[1];
            bool FFT_Units = false;
            if (FFT_Config[2] == "True") { FFT_Units = false; } else { FFT_Units = true; }
            int FFT_Window = int.Parse(FFT_Config[3]);
            bool FFT_Phase = false;
            if (FFT_Config[4] == "True") { FFT_Phase = true; } else { FFT_Phase = false; }
            bool FFT_Phase_Units = false;
            if (FFT_Config[5] == "True") { FFT_Phase_Units = true; } else { FFT_Phase_Units = false; }
            double FFT_Phase_Ignore = double.Parse(FFT_Config[6]);
            bool FFT_Peaks = false;
            if (FFT_Config[7] == "True") { FFT_Peaks = true; } else { FFT_Peaks = false; }
            double FFT_Peaks_Reference = double.Parse(FFT_Config[8]);
            int FFT_Peaks_Size = int.Parse(FFT_Config[9]);
            bool FFT_Interpolation_Enable = false;
            if (FFT_Config[10] == "True") { FFT_Interpolation_Enable = true; } else { FFT_Interpolation_Enable = false; }
            int FFT_Interpolation_Type_Selected = int.Parse(FFT_Config[11]);
            int FFT_Interpolation_Factor = int.Parse(FFT_Config[12]);

            Create_Anytime_FFT_Window(Title, Channel_Info, Channel_Title, FFT_Color, X_Waveform_Data, Y_Waveform_Data, Data_Points,
                        Total_Time, Start_Time, Stop_Time, FFT_Window, FFT_Units, FFT_Peaks, FFT_Peaks_Size, FFT_Peaks_Reference, FFT_Phase,
                        FFT_Phase_Units, FFT_Phase_Ignore, FFT_Interpolation_Enable, FFT_Interpolation_Type_Selected, FFT_Interpolation_Factor);
        }

        private void Create_Anytime_FFT_Window(string Title, string Channel_Info, string Channel_Title, string Color,
            double[] X_Waveform_Values, double[] Y_Waveform_Values, int Data_Points,
            double Total_Time, double Start_Time, double Stop_Time, int FFT_Window,
            bool Is_dBV, bool show_Peaks, int Peak_Window_Value, double Peak_Reference,
            bool show_Phase, bool Is_Phase_Degrees, double Phase_dB_Magnitude_suppression_Value,
            bool Apply_Interpolation, int Interpolation_Type, int Interpolation_Resample_Factor)
        {
            try
            {
                Thread Waveform_Thread = new Thread(new ThreadStart(() =>
                {
                    Anytime_FFT.FFT Anytime_FFT_Window = new Anytime_FFT.FFT(Title, Channel_Info, Channel_Title, Color,
                        X_Waveform_Values, Y_Waveform_Values, Data_Points, Total_Time, Start_Time, Stop_Time, FFT_Window,
                        Is_dBV, show_Peaks, Peak_Window_Value, Peak_Reference, show_Phase, Is_Phase_Degrees, Phase_dB_Magnitude_suppression_Value, Apply_Interpolation, Interpolation_Type, Interpolation_Resample_Factor);
                    Anytime_FFT_Window.Show();
                    Anytime_FFT_Window.Closed += (sender2, e2) => Anytime_FFT_Window.Dispatcher.BeginInvokeShutdown(DispatcherPriority.Background);
                    Dispatcher.Run();
                }));
                Waveform_Thread.CurrentCulture = CultureInfo.CreateSpecificCulture("en-US");
                Waveform_Thread.CurrentUICulture = CultureInfo.CreateSpecificCulture("en-US");
                Waveform_Thread.SetApartmentState(ApartmentState.STA);
                Waveform_Thread.IsBackground = true;
                Waveform_Thread.Start();
            }
            catch (Exception Ex)
            {
                insert_Log(Ex.Message, 1);
                insert_Log("Anytime FFT Window creation failed.", 1);
            }
        }
    }
}
