using MahApps.Metro.Controls;

namespace Anytime_FFT
{
    public partial class FFT : MetroWindow
    {
        private double Total_Time;
        private double Start_Time;
        private double Stop_Time;
        private int Data_Points;
        private string Channel_Info;
        private bool Show_Phase = false;

        private void Information_Tab_Updater(double Total_Time, int Data_Points, string Channel_Info, int FFT_Window)
        {
            Total_Time_Label.Content = Axis_Scale_Config.Value_SI_Prefix(Total_Time, 4) + "s";
            Data_Points_Label.Content = Data_Points;
            Channel_Info_Label.Content = Channel_Info;
            Magnitude_Max_Label.Content = Axis_Scale_Config.Value_SI_Prefix(FFT_Max, 4) + Y_AXIS_Units;
            Magnitude_Min_Label.Content = Axis_Scale_Config.Value_SI_Prefix(FFT_Min, 4) + Y_AXIS_Units;
            Window_Type_Label.Content = FFT_Window_Selected_Title(FFT_Window);
        }

        private string FFT_Window_Selected_Title(int FFT_Window_Type)
        {
            switch (FFT_Window_Type)
            {
                case 0:
                    return "Rectangular";
                case 1:
                    return "Hamming";
                case 2:
                    return "HammingPeriodic";
                case 3:
                    return "Hanning";
                case 4:
                    return "Hanning Periodic";
                case 5:
                    return "Blackman Harris";
                case 6:
                    return "Blackman Nuttall";
                case 7:
                    return "Lanczos";
                case 8:
                    return "Lanczos Periodic";
                case 9:
                    return "Cosine";
                case 10:
                    return "Cosine Periodic";
                case 11:
                    return "Triangular";
                default:
                    return "Unknown";
            }
        }
    }
}
