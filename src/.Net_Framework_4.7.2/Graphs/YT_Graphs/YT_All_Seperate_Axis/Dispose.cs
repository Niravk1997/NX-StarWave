﻿using MahApps.Metro.Controls;
using System;

namespace YT_All_Seperate_Axis
{
    public partial class YT_All_Seperate_Axis_Plotter : MetroWindow
    {
        private void Window_Closed(object sender, EventArgs e)
        {
            try
            {
                All_Channels_Data_Queue.Dispose();
                Waveform_Data_Process.Dispose();
                Graph.Plot.Clear();
                Channel_1_Curve = null;
                Channel_2_Curve = null;
                Channel_3_Curve = null;
                Channel_4_Curve = null;
                CH1_X_Values = null;
                CH1_Y_Values = null;
                CH2_X_Values = null;
                CH2_Y_Values = null;
                CH3_X_Values = null;
                CH3_Y_Values = null;
                CH4_X_Values = null;
                CH4_Y_Values = null;
                Waveform_Data_Process = null;
                All_Channels_Data_Queue = null;
                this.Close();
            }
            catch (Exception)
            {

            }
        }
    }
}
