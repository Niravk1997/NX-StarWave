using MahApps.Metro.Controls;
using Statistics_Table;
using System;
using System.Windows;

namespace YT
{
    public partial class YT_Plotter : MetroWindow
    {
        private bool Statistics_Table_IsOpen = false;

        private Statistics_Table_Window Statistics_Table;

        private double Statistics_Table_Panel_FloatingWidth = 705;
        private double Statistics_Table_Panel_FloatingHeight = 165;

        private void Open_Statistics_Table_Panel_Click(object sender, RoutedEventArgs e)
        {
            if (Statistics_OpenClose_MenuItem.IsChecked & Statistics_Table_IsOpen != true)
            {
                Open_Statistics_Table_Panel();
            }
            else
            {
                Close_Statistics_Table_Panel();
            }
        }

        private void Open_Statistics_Table_Panel()
        {
            if (Statistics_Table == null & Statistics_Table_IsOpen == false)
            {
                Statistics_Table = new Statistics_Table_Window(Channel_Title + " Statistics Table ", Channel_Title, Measurement_Unit, Waveform_Curve.Color, Statistics_Table_Panel_FloatingHeight, Statistics_Table_Panel_FloatingWidth, false, true);
                Statistics_Table.Show();
                Statistics_Table.Closed += Close_Statistics_Table_Panel_Event;
                Insert_Log("Statistics Table Opened", 5);
                Statistics_Table_IsOpen = true;
            }
        }

        private void Close_Statistics_Table_Panel_Event(object sender, EventArgs e)
        {
            try
            {
                Statistics_Table_IsOpen = false;
                Statistics_OpenClose_MenuItem.IsChecked = false;
                Statistics_Table = null;
                Insert_Log("Statistics Table Closed.", 5);
            }
            catch (Exception Ex)
            {
                Insert_Log(Ex.Message, 1);
            }
        }

        private void Close_Statistics_Table_Panel()
        {
            try
            {
                if (Statistics_Table != null & Statistics_Table_IsOpen)
                {
                    Statistics_Table.Close();
                    Statistics_OpenClose_MenuItem.IsChecked = false;
                    Statistics_Table = null;
                    Statistics_Table_IsOpen = false;
                    Insert_Log("Statistics Table Closed.", 5);
                }
            }
            catch (Exception Ex)
            {
                Statistics_OpenClose_MenuItem.IsChecked = false;
                Statistics_Table_IsOpen = false;
                Insert_Log(Ex.Message, 1);
            }

        }


    }
}
