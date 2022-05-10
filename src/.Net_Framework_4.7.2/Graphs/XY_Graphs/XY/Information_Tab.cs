using MahApps.Metro.Controls;

namespace XY
{
    public partial class XY_Plotter : MetroWindow
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
        }

        private void Channel_1_Label_Updater(string CH1)
        {
            CH_1_Total_Time_Header.Content = "CH" + CH1 + " Total Time (s): ";
            CH_1_Start_Time_Header.Content = "CH" + CH1 + " Start Time (s): ";
            CH_1_Stop_Time_Header.Content = "CH" + CH1 + " Stop Time (s): ";
            CH_1_Data_Points_Header.Content = "CH" + CH1 + " Data Points: ";
            CH_1_Channel_Info_Header.Content = "CH" + CH1 + " Channel Info: ";
            Graph.Plot.XAxis.Label("CH" + CH1);
        }

        private void Channel_2_Label_Updater(string CH2)
        {
            CH_2_Total_Time_Header.Content = "CH" + CH2 + " Total Time (s): ";
            CH_2_Start_Time_Header.Content = "CH" + CH2 + " Start Time (s): ";
            CH_2_Stop_Time_Header.Content = "CH" + CH2 + " Stop Time (s): ";
            CH_2_Data_Points_Header.Content = "CH" + CH2 + " Data Points: ";
            CH_2_Channel_Info_Header.Content = "CH" + CH2 + " Channel Info: ";
            Graph.Plot.YAxis.Label("CH" + CH2);
        }
    }
}
