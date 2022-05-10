using MahApps.Metro.Controls;
using System;

namespace Compare_YT
{
    public partial class Compare_YT_Plots : MetroWindow
    {
        private void Waveform_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            try
            {
                if (Selected_Checked_ListBox_Plottable_Data != null)
                {
                    Total_Time = Selected_Checked_ListBox_Plottable_Data.Total_Time;
                    Start_Time = Selected_Checked_ListBox_Plottable_Data.Start_Time;
                    Stop_Time = Selected_Checked_ListBox_Plottable_Data.Stop_Time;
                    Data_Points = Selected_Checked_ListBox_Plottable_Data.Data_Points;
                    Channel_Info = Selected_Checked_ListBox_Plottable_Data.Name;
                    Waveform_Color = Selected_Checked_ListBox_Plottable_Data.Waveform_Color;
                }
            }
            catch (Exception Ex)
            {
                Insert_Log(Ex.Message, 1);
            }
        }
    }
}
