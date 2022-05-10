using MahApps.Metro.Controls;
using System;
using System.Windows;

namespace AllChannels_YT
{
    public partial class AllChannels_YT_Plotter : MetroWindow
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

        private double CH3_Total_Time;
        private double CH3_Start_Time;
        private double CH3_Stop_Time;
        private int CH3_Data_Points;
        private string CH3_Channel_Info;

        private double CH4_Total_Time;
        private double CH4_Start_Time;
        private double CH4_Stop_Time;
        private int CH4_Data_Points;
        private string CH4_Channel_Info;

        private double CH1_Waveform_Frequency;
        private double CH1_Waveform_Period;
        private double CH1_Waveform_Mean;
        private double CH1_Waveform_PKPK;
        private double CH1_Waveform_RMS;
        private double CH1_Waveform_MAX;
        private double CH1_Waveform_MIN;

        private double CH2_Waveform_Frequency;
        private double CH2_Waveform_Period;
        private double CH2_Waveform_Mean;
        private double CH2_Waveform_PKPK;
        private double CH2_Waveform_RMS;
        private double CH2_Waveform_MAX;
        private double CH2_Waveform_MIN;

        private double CH3_Waveform_Frequency;
        private double CH3_Waveform_Period;
        private double CH3_Waveform_Mean;
        private double CH3_Waveform_PKPK;
        private double CH3_Waveform_RMS;
        private double CH3_Waveform_MAX;
        private double CH3_Waveform_MIN;

        private double CH4_Waveform_Frequency;
        private double CH4_Waveform_Period;
        private double CH4_Waveform_Mean;
        private double CH4_Waveform_PKPK;
        private double CH4_Waveform_RMS;
        private double CH4_Waveform_MAX;
        private double CH4_Waveform_MIN;

        private string CH1_Measurement_Unit = "V";
        private string CH2_Measurement_Unit = "V";
        private string CH3_Measurement_Unit = "V";
        private string CH4_Measurement_Unit = "V";

        private void Set_Measurement_Units_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                CH1_Measurement_Unit = CH1_Measurement_Units_TextBox.Text;
                Axis_Scale_Config.Y_Axis_Units = CH1_Measurement_Unit;

                CH2_Measurement_Unit = CH2_Measurement_Units_TextBox.Text;
                CH3_Measurement_Unit = CH3_Measurement_Units_TextBox.Text;
                CH4_Measurement_Unit = CH4_Measurement_Units_TextBox.Text;
            }
            catch (Exception Ex)
            {
                Insert_Log(Ex.Message, 1);
            }
        }

        private void CH1_Information_Tab_Updater()
        {
            CH1_Total_Time_Label.Content = Axis_Scale_Config.Value_SI_Prefix(CH1_Total_Time, 4) + "s";
            CH1_Start_Time_Label.Content = Axis_Scale_Config.Value_SI_Prefix(CH1_Start_Time, 4) + "s";
            CH1_Stop_Time_Label.Content = Axis_Scale_Config.Value_SI_Prefix(CH1_Stop_Time, 4) + "s";
            CH1_Data_Points_Label.Content = CH1_Data_Points;
            CH1_Channel_Info_Label.Content = CH1_Channel_Info;

            CH1_PKPK_Label.Content = Axis_Scale_Config.Value_SI_Prefix(CH1_Waveform_PKPK, 3) + CH1_Measurement_Unit;
            CH1_Mean_Label.Content = Axis_Scale_Config.Value_SI_Prefix(CH1_Waveform_Mean, 3) + CH1_Measurement_Unit;
            CH1_RMS_Label.Content = Axis_Scale_Config.Value_SI_Prefix(CH1_Waveform_RMS, 3) + CH1_Measurement_Unit;
            CH1_Max_Label.Content = Axis_Scale_Config.Value_SI_Prefix(CH1_Waveform_MAX, 3) + CH1_Measurement_Unit;
            CH1_Min_Label.Content = Axis_Scale_Config.Value_SI_Prefix(CH1_Waveform_MIN, 3) + CH1_Measurement_Unit;
        }

        private void CH2_Information_Tab_Updater()
        {
            CH2_Total_Time_Label.Content = Axis_Scale_Config.Value_SI_Prefix(CH2_Total_Time, 4) + "s";
            CH2_Start_Time_Label.Content = Axis_Scale_Config.Value_SI_Prefix(CH2_Start_Time, 4) + "s";
            CH2_Stop_Time_Label.Content = Axis_Scale_Config.Value_SI_Prefix(CH2_Stop_Time, 4) + "s";
            CH2_Data_Points_Label.Content = CH2_Data_Points;
            CH2_Channel_Info_Label.Content = CH2_Channel_Info;

            CH2_PKPK_Label.Content = Axis_Scale_Config.Value_SI_Prefix(CH2_Waveform_PKPK, 3) + CH2_Measurement_Unit;
            CH2_Mean_Label.Content = Axis_Scale_Config.Value_SI_Prefix(CH2_Waveform_Mean, 3) + CH2_Measurement_Unit;
            CH2_RMS_Label.Content = Axis_Scale_Config.Value_SI_Prefix(CH2_Waveform_RMS, 3) + CH2_Measurement_Unit;
            CH2_Max_Label.Content = Axis_Scale_Config.Value_SI_Prefix(CH2_Waveform_MAX, 3) + CH2_Measurement_Unit;
            CH2_Min_Label.Content = Axis_Scale_Config.Value_SI_Prefix(CH2_Waveform_MIN, 3) + CH2_Measurement_Unit;
        }

        private void CH3_Information_Tab_Updater()
        {
            CH3_Total_Time_Label.Content = Axis_Scale_Config.Value_SI_Prefix(CH3_Total_Time, 4) + "s";
            CH3_Start_Time_Label.Content = Axis_Scale_Config.Value_SI_Prefix(CH3_Start_Time, 4) + "s";
            CH3_Stop_Time_Label.Content = Axis_Scale_Config.Value_SI_Prefix(CH3_Stop_Time, 4) + "s";
            CH3_Data_Points_Label.Content = CH3_Data_Points;
            CH3_Channel_Info_Label.Content = CH3_Channel_Info;

            CH3_PKPK_Label.Content = Axis_Scale_Config.Value_SI_Prefix(CH3_Waveform_PKPK, 3) + CH3_Measurement_Unit;
            CH3_Mean_Label.Content = Axis_Scale_Config.Value_SI_Prefix(CH3_Waveform_Mean, 3) + CH3_Measurement_Unit;
            CH3_RMS_Label.Content = Axis_Scale_Config.Value_SI_Prefix(CH3_Waveform_RMS, 3) + CH3_Measurement_Unit;
            CH3_Max_Label.Content = Axis_Scale_Config.Value_SI_Prefix(CH3_Waveform_MAX, 3) + CH3_Measurement_Unit;
            CH3_Min_Label.Content = Axis_Scale_Config.Value_SI_Prefix(CH3_Waveform_MIN, 3) + CH3_Measurement_Unit;
        }

        private void CH4_Information_Tab_Updater()
        {
            CH4_Total_Time_Label.Content = Axis_Scale_Config.Value_SI_Prefix(CH4_Total_Time, 4) + "s";
            CH4_Start_Time_Label.Content = Axis_Scale_Config.Value_SI_Prefix(CH4_Start_Time, 4) + "s";
            CH4_Stop_Time_Label.Content = Axis_Scale_Config.Value_SI_Prefix(CH4_Stop_Time, 4) + "s";
            CH4_Data_Points_Label.Content = CH4_Data_Points;
            CH4_Channel_Info_Label.Content = CH4_Channel_Info;

            CH4_PKPK_Label.Content = Axis_Scale_Config.Value_SI_Prefix(CH4_Waveform_PKPK, 3) + CH4_Measurement_Unit;
            CH4_Mean_Label.Content = Axis_Scale_Config.Value_SI_Prefix(CH4_Waveform_Mean, 3) + CH4_Measurement_Unit;
            CH4_RMS_Label.Content = Axis_Scale_Config.Value_SI_Prefix(CH4_Waveform_RMS, 3) + CH4_Measurement_Unit;
            CH4_Max_Label.Content = Axis_Scale_Config.Value_SI_Prefix(CH4_Waveform_MAX, 3) + CH4_Measurement_Unit;
            CH4_Min_Label.Content = Axis_Scale_Config.Value_SI_Prefix(CH4_Waveform_MIN, 3) + CH4_Measurement_Unit;
        }
    }
}
