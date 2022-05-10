using MahApps.Metro.Controls;
using System;
using System.Windows;

namespace YT
{
    public partial class YT_Plotter : MetroWindow
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

        private string Measurement_Unit = "V";

        private void Set_Measurement_Units_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Measurement_Unit = Measurement_Units_TextBox.Text;
                Axis_Scale_Config.Y_Axis_Units = Measurement_Unit;

                if (Statistics_Table != null)
                {
                    Statistics_Table.YAxis_Units = Measurement_Unit;
                }

                if (Gated_Peaks_Table != null)
                {
                    Gated_Peaks_Table.Y_Values_Units = Measurement_Unit;
                }

                if (Gated_Measurements_Table != null)
                {
                    Gated_Measurements_Table.YAxis_Units = Measurement_Unit;
                }

                if (Gated_HighestPoints_Table != null)
                {
                    Gated_HighestPoints_Table.Y_Values_Units = Measurement_Unit;
                }
            }
            catch (Exception Ex)
            {
                Insert_Log(Ex.Message, 1);
            }
        }

        private void Information_Tab_Updater()
        {
            Total_Time_Label = Axis_Scale_Config.Value_SI_Prefix(Total_Time, 4) + "s";
            Start_Time_Label = Axis_Scale_Config.Value_SI_Prefix(Start_Time, 4) + "s";
            Stop_Time_Label = Axis_Scale_Config.Value_SI_Prefix(Stop_Time, 4) + "s";
            Data_Points_Label = Data_Points;
            Channel_Info_Label = Channel_Info;

            if (Statistics_Table_IsOpen != true)
            {
                PKPK_Label = Axis_Scale_Config.Value_SI_Prefix(Waveform_PKPK, 3) + Measurement_Unit;
                Mean_Label = Axis_Scale_Config.Value_SI_Prefix(Waveform_Mean, 3) + Measurement_Unit;
                RMS_Label = Axis_Scale_Config.Value_SI_Prefix(Waveform_RMS, 3) + Measurement_Unit;
                Max_Label = Axis_Scale_Config.Value_SI_Prefix(Waveform_MAX, 3) + Measurement_Unit;
                Min_Label = Axis_Scale_Config.Value_SI_Prefix(Waveform_MIN, 3) + Measurement_Unit;
            }
            else
            {
                PKPK_Label = "null";
                Mean_Label = "null";
                RMS_Label = "null";
                Max_Label = "null";
                Min_Label = "null";
            }

            if (Vertical_Markers_Enable == false)
            {
                Frequency_Label = Axis_Scale_Config.Value_SI_Prefix(Waveform_Frequency, 5) + "Hz";
                Period_Label = Axis_Scale_Config.Value_SI_Prefix(Waveform_Period, 5) + "s";
            }

            if (Vertical_Markers_Enable == false & Statistics_Table_IsOpen == true)
            {
                Frequency_Label = "null";
                Period_Label = "null";
            }
        }
    }
}
