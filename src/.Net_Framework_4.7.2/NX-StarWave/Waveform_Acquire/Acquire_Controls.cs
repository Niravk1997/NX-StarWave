using MahApps.Metro.Controls;
using System.Windows;

namespace NX_StarWave
{
    public partial class NX_StarWave_Window : MetroWindow
    {
        private void Acquire_Waveform_Disable_Click(object sender, RoutedEventArgs e)
        {
            Acquire_Waveform_Data = 0;
            Acquire_Waveform_Option_Selected(0);
        }

        private void Acquire_Waveform_Once_Click(object sender, RoutedEventArgs e)
        {
            Acquire_Waveform_Data = 1;
            Acquire_Waveform_Option_Selected(1);
        }

        private void Acquire_Waveform_Continuous_Click(object sender, RoutedEventArgs e)
        {
            Acquire_Waveform_Data = 2;
            Acquire_Waveform_Option_Selected(2);
        }

        private void Acquire_Waveform_Option_Selected(int Selected)
        {
            if (Selected == 0)
            {
                Acquire_Waveform_Disable_Button_BorderBrush = Color_Status_Success;
            }
            else
            {
                Acquire_Waveform_Disable_Button_BorderBrush = Color_Status_NotSelected;
            }
            if (Selected == 1)
            {
                Acquire_Waveform_Once_Button_BorderBrush = Color_Status_Success;
            }
            else
            {
                Acquire_Waveform_Once_Button_BorderBrush = Color_Status_NotSelected;
            }
            if (Selected == 2)
            {
                Acquire_Waveform_Continuous_Button_BorderBrush = Color_Status_Success;
            }
            else
            {
                Acquire_Waveform_Continuous_Button_BorderBrush = Color_Status_NotSelected;
            }
        }

        private void CH1_Acquire_ON_Click(object sender, RoutedEventArgs e)
        {
            Get_CH1_Data = 2;
        }

        private void CH1_Acquire_OFF_Click(object sender, RoutedEventArgs e)
        {
            Get_CH1_Data = 0;
        }

        private void CH1_Acquire_ONCE_Click(object sender, RoutedEventArgs e)
        {
            Get_CH1_Data = 1;
        }

        private void CH2_Acquire_ON_Click(object sender, RoutedEventArgs e)
        {
            Get_CH2_Data = 2;
        }

        private void CH2_Acquire_OFF_Click(object sender, RoutedEventArgs e)
        {
            Get_CH2_Data = 0;
        }

        private void CH2_Acquire_ONCE_Click(object sender, RoutedEventArgs e)
        {
            Get_CH2_Data = 1;
        }

        private void CH3_Acquire_ON_Click(object sender, RoutedEventArgs e)
        {
            Get_CH3_Data = 2;
        }

        private void CH3_Acquire_OFF_Click(object sender, RoutedEventArgs e)
        {
            Get_CH3_Data = 0;
        }

        private void CH3_Acquire_ONCE_Click(object sender, RoutedEventArgs e)
        {
            Get_CH3_Data = 1;
        }

        private void CH4_Acquire_ON_Click(object sender, RoutedEventArgs e)
        {
            Get_CH4_Data = 2;
        }

        private void CH4_Acquire_OFF_Click(object sender, RoutedEventArgs e)
        {
            Get_CH4_Data = 0;
        }

        private void CH4_Acquire_ONCE_Click(object sender, RoutedEventArgs e)
        {
            Get_CH4_Data = 1;
        }

        private void Acquire_StopRun_ToggleSwitch_Click(object sender, RoutedEventArgs e)
        {
            ToggleSwitch toggleSwitch = sender as ToggleSwitch;
            if (toggleSwitch != null)
            {
                if (toggleSwitch.IsOn == true)
                {
                    Acquire_Run_Stop = true;
                }
                else
                {
                    Acquire_Run_Stop = false;
                    Acquire_Run_Stop_Disabled = true;
                }
            }
        }

        private void Acquire_Timer_Default_Click(object sender, RoutedEventArgs e)
        {
            Acquire_Timer_Set_Value = 2;
        }

        private void Acquire_Timer_Slow_Click(object sender, RoutedEventArgs e)
        {
            Acquire_Timer_Set_Value = 3;
        }

        private void Acquire_Timer_Fast_Click(object sender, RoutedEventArgs e)
        {
            Acquire_Timer_Set_Value = 0.3;
        }

        private void Acquire_Timer_Max_Click(object sender, RoutedEventArgs e)
        {
            Acquire_Timer_Set_Value = 0;
        }

        private void Apply_Acquire_Interval_Value(bool isValid, double Value)
        {
            if (isValid)
            {
                if (Value >= 0)
                {
                    Acquire_Interval_Value = Value * 1000;
                    Acquire_Interval_Value_Changed = true;
                    insert_Log("Acquire Interval value set to " + Value + " seconds.", 5);
                }
                else
                {
                    insert_Log("Acquire Set Interval value must be greater than or equal to 0.", 2);
                }
            }
            else
            {
                insert_Log("Acquire Set Interval value must be a positive number greater than or equal to 0.", 2);
            }
        }

        private void Set_Data_Start_Stop_Click(object sender, RoutedEventArgs e)
        {
            Set_Data_Start_Stop_Values();
        }

        private void Set_Data_Start_Stop_Values()
        {
            (bool isValid_Start, double Start_Value) = Functions.Text_Num(DataStart_string, false, true);
            (bool isValid_Stop, double Stop_Value) = Functions.Text_Num(DataStop_string, false, true);
            if (isValid_Start & isValid_Stop)
            {
                if ((Start_Value < Stop_Value) & Start_Value > 0)
                {
                    if (Communication_Selected.VISA_GPIB_WFMPre_Curve_Method)
                    {
                        if (((Stop_Value - Start_Value) <= 500000) & ((Stop_Value - Start_Value) >= 99))
                        {
                            Tektronix_SendCommands_Queue.Add("DATa:STARt " + (int)Start_Value);
                            Tektronix_SendCommands_Queue.Add("DATa:STOP " + (int)Stop_Value);
                        }
                        else
                        {
                            insert_Log("Start value and Stop value range must be within 100 and 500000.", 2);
                            if (Communication_Selected.VISA_GPIB_WFMPre_Curve_Method)
                            {
                                insert_Log("Waveform Capture Method 2 only allows capturing waveforms of size 500K or lower.", 2);
                            }
                        }
                    }
                    else
                    {
                        if (((Stop_Value - Start_Value) <= 8000000) & ((Stop_Value - Start_Value) >= 99))
                        {
                            Tektronix_SendCommands_Queue.Add("DATa:STARt " + (int)Start_Value);
                            Tektronix_SendCommands_Queue.Add("DATa:STOP " + (int)Stop_Value);
                        }
                        else
                        {
                            insert_Log("Start value and Stop value range must be within 100 and 8000000.", 2);
                        }
                    }
                }
                else
                {
                    insert_Log("Data Start value must be less than Stop Value, and greater than 0.", 2);
                }
            }
            else
            {
                if (!isValid_Start)
                {
                    insert_Log("Data Start value must be an integer >= to 1 and <= 500000", 2);
                }

                if (!isValid_Stop)
                {
                    insert_Log("Data Stop value must be an integer >= to 2 and <= 500000", 2);
                }
            }
        }

        private void DataWidth_ToggleSwitch_Click(object sender, RoutedEventArgs e)
        {
            ToggleSwitch toggleSwitch = sender as ToggleSwitch;
            if (toggleSwitch != null)
            {
                if (toggleSwitch.IsOn == true)
                {
                    Tektronix_SendCommands_Queue.Add("DATa:WIDth 2");
                    insert_Log("Data Width is 2 Bytes. Acquire Mode: Average, HiRes", 5);
                }
                else
                {
                    Tektronix_SendCommands_Queue.Add("DATa:WIDth 1");
                    insert_Log("Data Width is 1 Byte. Acquire Mode: Sample, Envolope, Peak Detect", 5);
                }
            }
        }
    }
}
