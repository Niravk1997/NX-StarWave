using MahApps.Metro.Controls;
using System;
using System.Globalization;
using System.Threading;
using System.Windows.Threading;

namespace Reference_Calculator
{
    public partial class Reference_Config_Panel : MetroWindow
    {
        private void Initialize_Data_Anytime_Histogram_Window(string Title, string[] Histogram_Config, string[] Waveform_Config, double[] X_Waveform_Data, double[] Y_Waveform_Data, double Total_Time, double Start_Time, double Stop_Time, int Data_Points)
        {
            string Histogram_Color = Histogram_Config[1];
            int Histogram_Buckets = int.Parse(Histogram_Config[2]);

            string YAxis = Waveform_Config[2];
            string YAxis_Units = Waveform_Config[3];
            string Channel_Title = Waveform_Config[4];

            Create_Anytime_Histogram_Window(Title, Channel_Title, Histogram_Color, YAxis_Units, YAxis, X_Waveform_Data, Y_Waveform_Data, Total_Time, Start_Time, Stop_Time, Data_Points, Histogram_Buckets);
        }

        private void Create_Anytime_Histogram_Window(string Title, string Channel_Title, string Color, string YAxis_Units, string YAxis, double[] X_Waveform_Data, double[] Y_Waveform_Data, double Total_Time, double Start_Time, double Stop_Time, int Data_Points, int Histogram_Buckets)
        {
            try
            {
                Thread Waveform_Thread = new Thread(new ThreadStart(() =>
                {
                    Anytime_Histogram.Histogram Anytime_Histogram_Window = new Anytime_Histogram.Histogram(Title, Channel_Title, Color, YAxis_Units, YAxis, X_Waveform_Data, Y_Waveform_Data, Total_Time, Start_Time, Stop_Time, Data_Points, Histogram_Buckets);
                    Anytime_Histogram_Window.Show();
                    Anytime_Histogram_Window.Closed += (sender2, e2) => Anytime_Histogram_Window.Dispatcher.BeginInvokeShutdown(DispatcherPriority.Background);
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
                insert_Log("Anytime Waveform Window creation failed.", 1);
            }
        }
    }
}
