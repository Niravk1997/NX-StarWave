using MahApps.Metro.Controls;
using System;
using System.Globalization;
using System.Threading;
using System.Windows;
using System.Windows.Threading;

namespace YT
{
    public partial class YT_Plotter : MetroWindow
    {
        private void Create_Anytime_FFT_Click(object sender, RoutedEventArgs e)
        {
            this.Dispatcher.BeginInvoke(DispatcherPriority.Loaded, (Action)(() =>
            {
                (bool isValid, string Color) = GraphColor_AnytimeFFT_Check();
                (bool isValid_Peak_Reference, double Peak_Reference_Level) = Functions.Text_Num(AnytimeFFT_Peaks_Reference_Textbox.Text, true, false);
                (bool isValid_Peak_Window_Size, double Peak_Window_Size) = Functions.Text_Num(AnytimeFFT_Peaks_Window_Size_Textbox.Text, false, true);
                (bool isValid_Phase_Suppression_Value, double Phase_Suppression_Value) = Functions.Text_Num(AnytimeFFT_Peaks_Suppression_Value_Textbox.Text, true, false);
                try
                {
                    if (isValid & isValid_Peak_Reference & isValid_Peak_Window_Size & isValid_Phase_Suppression_Value)
                    {
                        string Title = AnytimeFFT_Title_Textbox.Text;
                        string Channel_Info = this.Channel_Info;
                        string Channel_Title = this.Channel_Title;
                        string Plot_Color = Color;
                        int Data_Points = this.Data_Points;
                        double Total_Time = this.Total_Time;
                        double Start_Time = this.Start_Time;
                        double Stop_Time = this.Stop_Time;
                        int FFT_Window = AnytimeFFT_Window_ComboBox.SelectedIndex;
                        bool Is_dBV = !AnytimeFFT_FFT_Units.IsOn;
                        bool show_Peaks = AnytimeFFT_Show_Peaks.IsOn;
                        int Peak_Window_Value = (int)Peak_Window_Size;
                        double Peak_Reference = Peak_Reference_Level;
                        bool show_Phase = AnytimeFFT_Show_Phase.IsOn;
                        bool Is_Phase_Degrees = !AnytimeFFT_Phase_Units.IsOn;
                        double Phase_dB_Magnitude_suppression_Value = Phase_Suppression_Value;
                        bool FFT_Interpolation_Apply = Apply_Interpolation_FFT_Results.IsOn;
                        int FFT_Interpolation_Factor_Value = FFT_Interpolation_Factor;
                        Create_Anytime_FFT_Window(Title, Channel_Info, Channel_Title, Plot_Color, X_Waveform_Values, Y_Waveform_Values, Data_Points,
                        Total_Time, Start_Time, Stop_Time, FFT_Window, Is_dBV, show_Peaks, Peak_Window_Value, Peak_Reference, show_Phase,
                        Is_Phase_Degrees, Phase_dB_Magnitude_suppression_Value, FFT_Interpolation_Apply, FFT_Interpolation_Type_Selected, FFT_Interpolation_Factor_Value);

                    }
                    else
                    {
                        if (isValid)
                        {
                            Insert_Log("Anytime FFT color values must be between 0 and 255, integers only.", 2);
                        }
                        if (isValid_Peak_Reference)
                        {
                            Insert_Log("Anytime FFT Peak Reference Value must be a real number.", 2);
                        }
                        if (isValid_Peak_Window_Size)
                        {
                            Insert_Log("Anytime FFT Peak Window Size must be an integre value greater that 2.", 2);
                        }
                        if (isValid_Phase_Suppression_Value)
                        {
                            Insert_Log("Anytime FFT Phase Suppression Value must be a real number.", 2);
                        }
                    }
                }
                catch (Exception Ex)
                {
                    Insert_Log(Ex.Message, 0);
                }
            }));
        }

        //Creates Math Waveform Windows
        private void Create_Anytime_FFT_Window(string Title, string Channel_Info, string Channel_Title, string Color,
            double[] X_Waveform_Values, double[] Y_Waveform_Values, int Data_Points,
            double Total_Time, double Start_Time, double Stop_Time, int FFT_Window,
            bool Is_dBV, bool show_Peaks, int Peak_Window_Value, double Peak_Reference, bool show_Phase, bool Is_Phase_Degrees, double Phase_dB_Magnitude_suppression_Value, bool Apply_Interpolation, int Interpolation_Type, int Interpolation_Resample_Factor)
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
                Insert_Log(Ex.Message, 1);
                Insert_Log("Anytime FFT Window creation failed.", 1);
            }
        }

        private void Set_Default_Anytime_FFT_Color(string Color)
        {
            GraphColor_AnytimeFFT.SelectedColor = (System.Windows.Media.Color)System.Windows.Media.ColorConverter.ConvertFromString(Color);
        }

        private (bool, string) GraphColor_AnytimeFFT_Check()
        {
            try
            {
                System.Windows.Media.Color color = GraphColor_AnytimeFFT.SelectedColor;
                return (true, color.ToString());
            }
            catch (Exception Ex)
            {
                Insert_Log(Ex.Message, 1);
                return (false, "#0072BD");
            }
        }

        private void GraphColor_RandomizeButton_AnytimeFFT_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Random RGB_Value = new Random();
                int Value_Red = RGB_Value.Next(0, 255);
                int Value_Green = RGB_Value.Next(0, 255);
                int Value_Blue = RGB_Value.Next(0, 255);
                GraphColor_AnytimeFFT.SelectedColor = System.Windows.Media.Color.FromArgb(255, (byte)(Value_Red), (byte)(Value_Green), (byte)(Value_Blue));
            }
            catch (Exception Ex)
            {
                Insert_Log(Ex.Message, 1);
            }
        }
    }
}
