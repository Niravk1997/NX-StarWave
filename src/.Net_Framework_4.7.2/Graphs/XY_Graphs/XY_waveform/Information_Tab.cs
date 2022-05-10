using MahApps.Metro.Controls;

namespace XY_Waveform
{
    public partial class XY_Waveform_Plotter : MetroWindow
    {
        private double CH1_Total_Time;
        private double CH1_Start_Time;
        private double CH1_Stop_Time;
        private int CH1_Data_Points;
        private string CH1_Channel_Info;

        private double CH2_Total_Time;
        private double CH2_Start_Time;
        private double CH2_Stop_Time;
        private int CH2_Data_Points;
        private string CH2_Channel_Info;

        private double CH1_Wavefrom_Mean;
        private double CH1_Wavefrom_PKPK;
        private double CH1_Wavefrom_RMS;
        private double CH1_Wavefrom_MAX;
        private double CH1_Wavefrom_MIN;

        private double CH2_Wavefrom_Mean;
        private double CH2_Wavefrom_PKPK;
        private double CH2_Wavefrom_RMS;
        private double CH2_Wavefrom_MAX;
        private double CH2_Wavefrom_MIN;

        private void Information_Tab_Updater()
        {
            CH_1_Total_Time_Label.Content = Axis_Scale_Config.Value_SI_Prefix(CH1_Total_Time, 4) + "s";
            CH_1_Start_Time_Label.Content = Axis_Scale_Config.Value_SI_Prefix(CH1_Start_Time, 4) + "s";
            CH_1_Stop_Time_Label.Content = Axis_Scale_Config.Value_SI_Prefix(CH1_Stop_Time, 4) + "s";
            CH_1_Data_Points_Label.Content = CH1_Data_Points;
            CH_1_Channel_Info_Label.Content = CH1_Channel_Info;

            CH_2_Total_Time_Label.Content = Axis_Scale_Config.Value_SI_Prefix(CH2_Total_Time, 4) + "s";
            CH_2_Start_Time_Label.Content = Axis_Scale_Config.Value_SI_Prefix(CH2_Start_Time, 4) + "s";
            CH_2_Stop_Time_Label.Content = Axis_Scale_Config.Value_SI_Prefix(CH2_Stop_Time, 4) + "s";
            CH_2_Data_Points_Label.Content = CH2_Data_Points;
            CH_2_Channel_Info_Label.Content = CH2_Channel_Info;

            CH_1_PKPK_Label.Content = Axis_Scale_Config.Value_SI_Prefix(CH1_Wavefrom_PKPK, 3) + CH1_Units;
            CH_1_Mean_Label.Content = Axis_Scale_Config.Value_SI_Prefix(CH1_Wavefrom_Mean, 3) + CH1_Units;
            CH_1_RMS_Label.Content = Axis_Scale_Config.Value_SI_Prefix(CH1_Wavefrom_RMS, 3) + CH1_Units;
            CH_1_Max_Label.Content = Axis_Scale_Config.Value_SI_Prefix(CH1_Wavefrom_MAX, 3) + CH1_Units;
            CH_1_Min_Label.Content = Axis_Scale_Config.Value_SI_Prefix(CH1_Wavefrom_MIN, 3) + CH1_Units;

            CH_2_PKPK_Label.Content = Axis_Scale_Config.Value_SI_Prefix(CH2_Wavefrom_PKPK, 3) + CH2_Units;
            CH_2_Mean_Label.Content = Axis_Scale_Config.Value_SI_Prefix(CH2_Wavefrom_Mean, 3) + CH2_Units;
            CH_2_RMS_Label.Content = Axis_Scale_Config.Value_SI_Prefix(CH2_Wavefrom_RMS, 3) + CH2_Units;
            CH_2_Max_Label.Content = Axis_Scale_Config.Value_SI_Prefix(CH2_Wavefrom_MAX, 3) + CH2_Units;
            CH_2_Min_Label.Content = Axis_Scale_Config.Value_SI_Prefix(CH2_Wavefrom_MIN, 3) + CH2_Units;
        }

        private void Channel_1_Label_Updater(string CH1)
        {
            CH_1_Menu_Header.Header = "CH" + CH1 + " Color";
            CH_1_PKPK_Header.Content = "PK-PK (" + CH1 + "): ";
            CH_1_Mean_Header.Content = "Mean (" + CH1 + "): ";
            CH_1_RMS_Header.Content = "RMS (" + CH1 + "): ";
            CH_1_Max_Header.Content = "Max (" + CH1 + "): ";
            CH_1_Min_Header.Content = "Min (" + CH1 + "): ";
            CH_1_Total_Time_Header.Content = "CH" + CH1 + " Total Time (s): ";
            CH_1_Start_Time_Header.Content = "CH" + CH1 + " Start Time (s): ";
            CH_1_Stop_Time_Header.Content = "CH" + CH1 + " Stop Time (s): ";
            CH_1_Data_Points_Header.Content = "CH" + CH1 + " Data Points: ";
            CH_1_Channel_Info_Header.Content = "CH" + CH1 + " Channel Info: ";
            Channel_1_Curve.Label = "CH" + CH1;
            Graph.Plot.XAxis.Label("CH" + CH1);
        }

        private void Channel_2_Label_Updater(string CH2)
        {
            CH_2_Menu_Header.Header = "CH" + CH2 + " Color";

            CH_2_PKPK_Header.Content = "PK-PK (" + CH2 + "): ";
            CH_2_Mean_Header.Content = "Mean (" + CH2 + "): ";
            CH_2_RMS_Header.Content = "RMS (" + CH2 + "): ";
            CH_2_Max_Header.Content = "Max (" + CH2 + "): ";
            CH_2_Min_Header.Content = "Min (" + CH2 + "): ";
            CH_2_Total_Time_Header.Content = "CH" + CH2 + " Total Time (s): ";
            CH_2_Start_Time_Header.Content = "CH" + CH2 + " Start Time (s): ";
            CH_2_Stop_Time_Header.Content = "CH" + CH2 + " Stop Time (s): ";
            CH_2_Data_Points_Header.Content = "CH" + CH2 + " Data Points: ";
            CH_2_Channel_Info_Header.Content = "CH" + CH2 + " Channel Info: ";
            Channel_2_Curve.Label = "CH" + CH2;
            CH2_YAXIS_Header.Header = "CH" + CH2 + " Y-AXIS";
            if (Channel_2_Curve.YAxisIndex == 1)
            {
                Waveform_Graph.Plot.YAxis2.Label("CH" + Channel_2_Selected_String);
            }
            Graph.Plot.YAxis.Label("CH" + CH2);
        }
    }
}
