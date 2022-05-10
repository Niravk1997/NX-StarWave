using MahApps.Metro.Controls;
using NX_StarWave.Waveform_Model_Classes;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Waveform_Calculator
{
    public partial class Calculator_Panel : MetroWindow
    {
        private List<Task> FFT_Panels_Data_Pass_Task_List = new List<Task>();
        private void Pass_Data_to_FFT_Panels(Processed_Channels_Data CH_Data)
        {
            FFT_Panels_Data_Pass_Task_List.Clear();
            try
            {
                if (FFT_Layout_1 != null & FFT_Panel_1 != null)
                {
                    Task Task_1_FFT = Task.Run(() =>
                    {
                        FFT_Panel_1.Calculate_Math_Expression(CH_Data);
                    }); FFT_Panels_Data_Pass_Task_List.Add(Task_1_FFT);
                }
            }
            catch (Exception) { }
            try
            {
                if (FFT_Layout_2 != null & FFT_Panel_2 != null)
                {
                    Task Task_2_FFT = Task.Run(() =>
                    {
                        FFT_Panel_2.Calculate_Math_Expression(CH_Data);
                    }); FFT_Panels_Data_Pass_Task_List.Add(Task_2_FFT);
                }
            }
            catch (Exception) { }
            try
            {
                if (FFT_Layout_3 != null & FFT_Panel_3 != null)
                {
                    Task Task_3_FFT = Task.Run(() =>
                    {
                        FFT_Panel_3.Calculate_Math_Expression(CH_Data);
                    }); FFT_Panels_Data_Pass_Task_List.Add(Task_3_FFT);
                }
            }
            catch (Exception) { }
            try
            {
                if (FFT_Layout_4 != null & FFT_Panel_4 != null)
                {
                    Task Task_4_FFT = Task.Run(() =>
                    {
                        FFT_Panel_4.Calculate_Math_Expression(CH_Data);
                    }); FFT_Panels_Data_Pass_Task_List.Add(Task_4_FFT);
                }
            }
            catch (Exception) { }
            try
            {
                if (FFT_Layout_5 != null & FFT_Panel_5 != null)
                {
                    Task Task_5_FFT = Task.Run(() =>
                    {
                        FFT_Panel_5.Calculate_Math_Expression(CH_Data);
                    }); FFT_Panels_Data_Pass_Task_List.Add(Task_5_FFT);
                }
            }
            catch (Exception) { }
            Task.WaitAll(FFT_Panels_Data_Pass_Task_List.ToArray());
        }
    }
}
