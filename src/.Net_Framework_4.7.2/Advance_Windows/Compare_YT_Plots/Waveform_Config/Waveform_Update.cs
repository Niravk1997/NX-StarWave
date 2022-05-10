using MahApps.Metro.Controls;
using System;
using System.Windows;

namespace Compare_YT
{
    public partial class Compare_YT_Plots : MetroWindow
    {
        private void Update_Selected_Waveform_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (Selected_Checked_ListBox_Plottable_Data != null)
                {
                    bool Waveform_Checked = Selected_Checked_ListBox_Plottable_Data.IsChecked;
                    Selected_Checked_ListBox_Plottable_Data.IsChecked = false;
                    Selected_Checked_ListBox_Plottable_Data.Total_Time = Total_Time;
                    Selected_Checked_ListBox_Plottable_Data.Start_Time = Start_Time;
                    Selected_Checked_ListBox_Plottable_Data.Stop_Time = Stop_Time;
                    Selected_Checked_ListBox_Plottable_Data.Data_Points = Data_Points;
                    Selected_Checked_ListBox_Plottable_Data.Name = Channel_Info;
                    Selected_Checked_ListBox_Plottable_Data.Waveform_Color = Waveform_Color;
                    Selected_Checked_ListBox_Plottable_Data.Plottable = Graph.Plot.AddSignalXY(Selected_Checked_ListBox_Plottable_Data.X_Values, Selected_Checked_ListBox_Plottable_Data.Y_Values,
                    color: System.Drawing.ColorTranslator.FromHtml(Waveform_Color), label: Channel_Info);
                    Selected_Checked_ListBox_Plottable_Data.IsChecked = Waveform_Checked;
                    Graph.Plot.AxisAuto();
                    Graph.Refresh();

                    Waveform_ListBox.Items.Refresh();
                }
            }
            catch (Exception Ex)
            {
                Insert_Log(Ex.Message, 1);
            }
        }
    }
}
