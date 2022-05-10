using MahApps.Metro.Controls;

namespace FFT_Waterfall
{
    public partial class FFT_Waterfall_Plotter : MetroWindow
    {
        private double Total_Time;
        private double Start_Time;
        private double Stop_Time;
        private int Data_Points;
        private string Channel_Info;
        private double SampleRate;

        private double FFT_Max;
        private double FFT_Min;

        private void Information_Tab_Updater()
        {
            Total_Time_Label.Content = Axis_Scale_Config.Value_SI_Prefix(Total_Time, 4) + "s";
            Data_Points_Label.Content = Data_Points;
            Channel_Info_Label.Content = Channel_Info;
            Magnitude_Max_Label.Content = Axis_Scale_Config.Value_SI_Prefix(FFT_Max, 4) + Y_AXIS_Units;
            Magnitude_Min_Label.Content = Axis_Scale_Config.Value_SI_Prefix(FFT_Min, 4) + Y_AXIS_Units;
        }
    }
}
