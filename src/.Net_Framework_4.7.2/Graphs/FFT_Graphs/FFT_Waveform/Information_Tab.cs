using MahApps.Metro.Controls;

namespace FFT_Waveform
{
    public partial class FFT_Waveform_Plotter : MetroWindow
    {
        private double Total_Time;
        private double Start_Time;
        private double Stop_Time;
        private int Data_Points;
        private string Channel_Info;
        private double SampleRate;

        private double FFT_Max;
        private double FFT_Min;

        private double Wavefrom_Mean;
        private double Wavefrom_PKPK;
        private double Wavefrom_RMS;
        private double Wavefrom_MAX;
        private double Wavefrom_MIN;

        private void Information_Tab_Updater()
        {
            Total_Time_Label.Content = Axis_Scale_Config.Value_SI_Prefix(Total_Time, 4) + "s";
            Data_Points_Label.Content = Data_Points;
            Channel_Info_Label.Content = Channel_Info;
            Magnitude_Max_Label.Content = Axis_Scale_Config.Value_SI_Prefix(FFT_Max, 4) + Y_AXIS_Units;
            Magnitude_Min_Label.Content = Axis_Scale_Config.Value_SI_Prefix(FFT_Min, 4) + Y_AXIS_Units;

            Start_Time_Label.Content = Axis_Scale_Config.Value_SI_Prefix(Start_Time, 4) + "s";
            Stop_Time_Label.Content = Axis_Scale_Config.Value_SI_Prefix(Stop_Time, 4) + "s";
            PKPK_Label.Content = Axis_Scale_Config.Value_SI_Prefix(Wavefrom_PKPK, 3) + "V";
            Mean_Label.Content = Axis_Scale_Config.Value_SI_Prefix(Wavefrom_Mean, 3) + "V";
            RMS_Label.Content = Axis_Scale_Config.Value_SI_Prefix(Wavefrom_RMS, 3) + "V";
            Max_Label.Content = Axis_Scale_Config.Value_SI_Prefix(Wavefrom_MAX, 3) + "V";
            Min_Label.Content = Axis_Scale_Config.Value_SI_Prefix(Wavefrom_MIN, 3) + "V";
        }
    }
}
