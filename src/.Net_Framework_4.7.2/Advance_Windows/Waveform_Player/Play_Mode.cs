using MahApps.Metro.Controls;
using NX_StarWave.Waveform_Model_Classes;
using System;
using System.Linq;
using System.Media;
using System.Threading;
using System.Windows;

namespace Waveform_Player
{
    public partial class Waveform_Player_Window : MetroWindow
    {
        private System.Timers.Timer Waveform_Play_Mode_Timer;

        private bool Is_Play_Mode_Running = false;

        private void Waveform_Play_Mode_Enable_Disable_Click(object sender, RoutedEventArgs e)
        {
            if (!Is_Play_Mode_Running)
            {
                Is_Play_Mode_Running = true;
                Waveform_Play_Repeat_Status_Color = Color_Status_Success;
                try
                {
                    Waveform_Play_Mode_Timer.Start();
                }
                catch (Exception Ex)
                {
                    Insert_Log(Ex.Message, 1);
                }
            }
            else
            {
                try
                {
                    Waveform_Play_Mode_Timer.Stop();
                    Is_Play_Mode_Running = false;
                    Waveform_Play_Repeat_Status_Color = Color_Status_Idle;
                }
                catch (Exception Ex)
                {
                    Insert_Log(Ex.Message, 1);
                }
            }
        }

        private void Initialize_Waveform_Play_Mode_Timer()
        {
            Waveform_Play_Mode_Timer = new System.Timers.Timer
            {
                Interval = 100,
                AutoReset = false,
                Enabled = false
            };
            Waveform_Play_Mode_Timer.Elapsed += Waveform_Play_Mode_Process;
        }

        private void Waveform_Play_Mode_Process(object sender, EventArgs e)
        {
            try
            {
                do
                {
                    int Waveform_Play_Start_Index = this.Waveform_Play_Start_Index;
                    int Waveform_Play_Stop_Index = this.Waveform_Play_Stop_Index;
                    for (int i = Waveform_Play_Start_Index; i <= Waveform_Play_Stop_Index; i++)
                    {
                        if (Is_Play_Mode_Running == false)
                        {
                            Insert_Log("Play Mode Cancelled.", 6);
                            break;
                        }
                        Thread.Sleep(Waveform_Play_Delay_Interval);
                        Waveform_Store_Table_Model Waveform = Waveform_Data.ElementAt(i);
                        Insert_Waveforms_Graph_Windows_Queue.Add(new All_Channels_Data(Waveform.CH1, Waveform.CH2, Waveform.CH3, Waveform.CH4));
                        Table_Selected_Index = i;
                    }
                } while (Waveform_Play_Repeat & Is_Play_Mode_Running);
            }
            catch (Exception Ex)
            {
                SystemSounds.Hand.Play();
                Insert_Log(Ex.Message, 1);
                Insert_Log("Error occured in Play Mode.", 1);
            }
            Is_Play_Mode_Running = false;
            Waveform_Play_Repeat_Status_Color = Color_Status_Idle;
        }

        private void Up_Insert_Select_Index_Table_Waveform_Click(object sender, RoutedEventArgs e)
        {
            if (Is_Play_Mode_Running == false)
            {
                try
                {
                    if ((Table_Selected_Index > 0) & (Table_Selected_Index < Waveform_Data.Count))
                    {
                        Table_Selected_Index--;
                    }
                    Waveform_Store_Table_Model Waveform = Selected_Waveform_Data;
                    Insert_Waveforms_Graph_Windows_Queue.Add(new All_Channels_Data(Waveform.CH1, Waveform.CH2, Waveform.CH3, Waveform.CH4));
                }
                catch (Exception Ex)
                {
                    Insert_Log(Ex.Message, 1);
                }
            }
            else
            {
                Insert_Log("Not available when Play Mode is active.", 2);
            }
        }

        private void Down_Insert_Select_Index_Table_Waveform_Click(object sender, RoutedEventArgs e)
        {
            if (Is_Play_Mode_Running == false)
            {
                try
                {
                    if ((Table_Selected_Index < (Waveform_Data.Count - 1)) & (Table_Selected_Index != Waveform_Data.Count))
                    {
                        Table_Selected_Index++;
                    }
                    Waveform_Store_Table_Model Waveform = Selected_Waveform_Data;
                    Insert_Waveforms_Graph_Windows_Queue.Add(new All_Channels_Data(Waveform.CH1, Waveform.CH2, Waveform.CH3, Waveform.CH4));
                }
                catch (Exception Ex)
                {
                    Insert_Log(Ex.Message, 1);
                }
            }
            else
            {
                Insert_Log("Not available when Play Mode is active.", 2);
            }
        }

        private void Table_Mouse_Double_Click_Event(object sender, RoutedEventArgs e)
        {
            if (Is_Play_Mode_Running == false)
            {
                try
                {
                    if (Selected_Waveform_Data != null)
                    {
                        Waveform_Store_Table_Model Waveform = Selected_Waveform_Data;
                        Insert_Waveforms_Graph_Windows_Queue.Add(new All_Channels_Data(Waveform.CH1, Waveform.CH2, Waveform.CH3, Waveform.CH4));
                    }
                }
                catch (Exception Ex)
                {
                    Insert_Log(Ex.Message, 1);
                }
            }
            else
            {
                Insert_Log("Not available when Play Mode is active.", 2);
            }
        }
    }
}
