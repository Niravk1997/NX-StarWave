using MahApps.Metro.Controls;

namespace Anytime_Waveform
{
    public partial class Waveform : MetroWindow
    {
        private double Total_Time;
        private double Start_Time;
        private double Stop_Time;
        private int Data_Points;
        private string Channel_Info;

        private double Waveform_Mean;
        private double Waveform_PKPK;
        private double Waveform_RMS;
        private double Waveform_MAX;
        private double Waveform_MIN;
        private double Waveform_Frequency;
        private double Waveform_Period;

        private string YAxis_Units;
        private string YAxis;

        private void Information_Tab_Updater()
        {
            Total_Time_Label = Axis_Scale_Config.Value_SI_Prefix(Total_Time, 4) + "s";
            Start_Time_Label = Axis_Scale_Config.Value_SI_Prefix(Start_Time, 4) + "s";
            Stop_Time_Label = Axis_Scale_Config.Value_SI_Prefix(Stop_Time, 4) + "s";
            Data_Points_Label = Data_Points;
            Channel_Info_Label = Channel_Info;

            PKPK_Label = Axis_Scale_Config.Value_SI_Prefix(Waveform_PKPK, 3) + YAxis_Units;
            Mean_Label = Axis_Scale_Config.Value_SI_Prefix(Waveform_Mean, 3) + YAxis_Units;
            RMS_Label = Axis_Scale_Config.Value_SI_Prefix(Waveform_RMS, 3) + YAxis_Units;
            Max_Label = Axis_Scale_Config.Value_SI_Prefix(Waveform_MAX, 3) + YAxis_Units;
            Min_Label = Axis_Scale_Config.Value_SI_Prefix(Waveform_MIN, 3) + YAxis_Units;

            Frequency_Label = Axis_Scale_Config.Value_SI_Prefix(Waveform_Frequency, 5) + "Hz";
            Period_Label = Axis_Scale_Config.Value_SI_Prefix(Waveform_Period, 5) + "s";
        }
    }
}
