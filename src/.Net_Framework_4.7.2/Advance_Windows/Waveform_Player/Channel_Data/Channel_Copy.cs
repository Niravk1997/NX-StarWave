using MahApps.Metro.Controls;
using Newtonsoft.Json;
using NX_StarWave.Waveform_Model_Classes;
using System;
using System.Windows;

namespace Waveform_Player
{
    public partial class Waveform_Player_Window : MetroWindow
    {
        private void CH1_Waveform_Copy_Click(object sender, RoutedEventArgs e)
        {
            Copy_Channel_Data(1);
        }

        private void CH2_Waveform_Copy_Click(object sender, RoutedEventArgs e)
        {
            Copy_Channel_Data(2);
        }

        private void CH3_Waveform_Copy_Click(object sender, RoutedEventArgs e)
        {
            Copy_Channel_Data(3);
        }

        private void CH4_Waveform_Copy_Click(object sender, RoutedEventArgs e)
        {
            Copy_Channel_Data(4);
        }

        private void Copy_Channel_Data(int Channel)
        {
            if (Is_Play_Mode_Running == false)
            {
                try
                {
                    switch (Channel)
                    {
                        case 1:
                            if (Selected_Waveform_Data.CH1_Valid)
                            {
                                Reference_Waveform CH1_Reference_Waveform = new Reference_Waveform(Selected_Waveform_Data.CH1.Y_Data, Selected_Waveform_Data.CH1.Data_Points, Selected_Waveform_Data.CH1.Total_Time, Selected_Waveform_Data.CH1.Start_Time, Selected_Waveform_Data.CH1.Stop_Time, Selected_Waveform_Data.CH1.Channel_Info, "#0072BD");
                                Copy_to_Clipboard(CH1_Reference_Waveform);
                            }
                            else
                            {
                                Insert_Log("Channel 1 data is empty. Could not copy channel data.", 2);
                            }
                            break;
                        case 2:
                            if (Selected_Waveform_Data.CH2_Valid)
                            {
                                Reference_Waveform CH2_Reference_Waveform = new Reference_Waveform(Selected_Waveform_Data.CH2.Y_Data, Selected_Waveform_Data.CH2.Data_Points, Selected_Waveform_Data.CH2.Total_Time, Selected_Waveform_Data.CH2.Start_Time, Selected_Waveform_Data.CH2.Stop_Time, Selected_Waveform_Data.CH2.Channel_Info, "#FFFF8C00");
                                Copy_to_Clipboard(CH2_Reference_Waveform);
                            }
                            else
                            {
                                Insert_Log("Channel 2 data is empty. Could not copy channel data.", 2);
                            }
                            break;
                        case 3:
                            if (Selected_Waveform_Data.CH3_Valid)
                            {
                                Reference_Waveform CH3_Reference_Waveform = new Reference_Waveform(Selected_Waveform_Data.CH3.Y_Data, Selected_Waveform_Data.CH3.Data_Points, Selected_Waveform_Data.CH3.Total_Time, Selected_Waveform_Data.CH3.Start_Time, Selected_Waveform_Data.CH3.Stop_Time, Selected_Waveform_Data.CH3.Channel_Info, "#FFFF1493");
                                Copy_to_Clipboard(CH3_Reference_Waveform);
                            }
                            else
                            {
                                Insert_Log("Channel 3 data is empty. Could not copy channel data.", 2);
                            }
                            break;
                        case 4:
                            if (Selected_Waveform_Data.CH4_Valid)
                            {
                                Reference_Waveform CH4_Reference_Waveform = new Reference_Waveform(Selected_Waveform_Data.CH4.Y_Data, Selected_Waveform_Data.CH4.Data_Points, Selected_Waveform_Data.CH4.Total_Time, Selected_Waveform_Data.CH4.Start_Time, Selected_Waveform_Data.CH4.Stop_Time, Selected_Waveform_Data.CH4.Channel_Info, "#00b33c");
                                Copy_to_Clipboard(CH4_Reference_Waveform);
                            }
                            else
                            {
                                Insert_Log("Channel 4 data is empty. Could not copy channel data.", 2);
                            }
                            break;
                        default:
                            Insert_Log("No Channel selected. No data copied.", 2);
                            break;
                    }
                }
                catch (Exception Ex)
                {
                    Insert_Log(Ex.Message, 1);
                }
            }
            else
            {
                Insert_Log("Cannot copy channel data when play mode is active.", 2);
            }
        }

        private void Copy_to_Clipboard(Reference_Waveform Reference_Waveform)
        {
            string CH_Data = JsonConvert.SerializeObject(Reference_Waveform);
            Clipboard.SetText(CH_Data);
        }
    }
}
