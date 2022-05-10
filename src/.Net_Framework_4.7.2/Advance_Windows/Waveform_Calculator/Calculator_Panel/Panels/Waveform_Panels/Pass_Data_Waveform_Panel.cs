using MahApps.Metro.Controls;
using NX_StarWave.Waveform_Model_Classes;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Waveform_Calculator
{
    public partial class Calculator_Panel : MetroWindow
    {
        private List<Task> Waveform_Panels_Data_Pass_Task_List = new List<Task>();
        private void Pass_Data_to_Waveform_Panels(Processed_Channels_Data CH_Data)
        {
            Waveform_Panels_Data_Pass_Task_List.Clear();
            try
            {
                if (Waveform_Layout_1 != null & Waveform_Panel_1 != null)
                {
                    Task Task_1_Waveform = Task.Run(() =>
                    {
                        Waveform_Panel_1.Calculate_Math_Expression(CH_Data);
                    }); Waveform_Panels_Data_Pass_Task_List.Add(Task_1_Waveform);
                }
            }
            catch (Exception) { }
            try
            {
                if (Waveform_Layout_2 != null & Waveform_Panel_2 != null)
                {
                    Task Task_2_Waveform = Task.Run(() =>
                    {
                        Waveform_Panel_2.Calculate_Math_Expression(CH_Data);
                    }); Waveform_Panels_Data_Pass_Task_List.Add(Task_2_Waveform);
                }
            }
            catch (Exception) { }
            try
            {
                if (Waveform_Layout_3 != null & Waveform_Panel_3 != null)
                {
                    Task Task_3_Waveform = Task.Run(() =>
                    {
                        Waveform_Panel_3.Calculate_Math_Expression(CH_Data);
                    }); Waveform_Panels_Data_Pass_Task_List.Add(Task_3_Waveform);
                }
            }
            catch (Exception) { }
            try
            {
                if (Waveform_Layout_4 != null & Waveform_Panel_4 != null)
                {
                    Task Task_4_Waveform = Task.Run(() =>
                    {
                        Waveform_Panel_4.Calculate_Math_Expression(CH_Data);
                    }); Waveform_Panels_Data_Pass_Task_List.Add(Task_4_Waveform);
                }
            }
            catch (Exception) { }
            try
            {
                if (Waveform_Layout_5 != null & Waveform_Panel_5 != null)
                {
                    Task Task_5_Waveform = Task.Run(() =>
                    {
                        Waveform_Panel_5.Calculate_Math_Expression(CH_Data);
                    }); Waveform_Panels_Data_Pass_Task_List.Add(Task_5_Waveform);
                }
            }
            catch (Exception) { }
            try
            {
                if (Waveform_Layout_6 != null & Waveform_Panel_6 != null)
                {
                    Task Task_6_Waveform = Task.Run(() =>
                    {
                        Waveform_Panel_6.Calculate_Math_Expression(CH_Data);
                    }); Waveform_Panels_Data_Pass_Task_List.Add(Task_6_Waveform);
                }
            }
            catch (Exception) { }
            try
            {
                if (Waveform_Layout_7 != null & Waveform_Panel_7 != null)
                {
                    Task Task_7_Waveform = Task.Run(() =>
                    {
                        Waveform_Panel_7.Calculate_Math_Expression(CH_Data);
                    }); Waveform_Panels_Data_Pass_Task_List.Add(Task_7_Waveform);
                }
            }
            catch (Exception) { }
            try
            {
                if (Waveform_Layout_8 != null & Waveform_Panel_8 != null)
                {
                    Task Task_8_Waveform = Task.Run(() =>
                    {
                        Waveform_Panel_8.Calculate_Math_Expression(CH_Data);
                    }); Waveform_Panels_Data_Pass_Task_List.Add(Task_8_Waveform);
                }
            }
            catch (Exception) { }
            try
            {
                if (Waveform_Layout_9 != null & Waveform_Panel_9 != null)
                {
                    Task Task_9_Waveform = Task.Run(() =>
                    {
                        Waveform_Panel_9.Calculate_Math_Expression(CH_Data);
                    }); Waveform_Panels_Data_Pass_Task_List.Add(Task_9_Waveform);
                }
            }
            catch (Exception) { }
            try
            {
                if (Waveform_Layout_10 != null & Waveform_Panel_10 != null)
                {
                    Task Task_10_Waveform = Task.Run(() =>
                    {
                        Waveform_Panel_10.Calculate_Math_Expression(CH_Data);
                    }); Waveform_Panels_Data_Pass_Task_List.Add(Task_10_Waveform);
                }
            }
            catch (Exception) { }
            Task.WaitAll(Waveform_Panels_Data_Pass_Task_List.ToArray());
        }
    }
}
