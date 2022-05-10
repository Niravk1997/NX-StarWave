using MahApps.Metro.Controls;
using NX_StarWave.Waveform_Model_Classes;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Waveform_Calculator
{
    public partial class Calculator_Panel : MetroWindow
    {
        private List<Task> Histogram_Panels_Data_Pass_Task_List = new List<Task>();
        private void Pass_Data_to_Histogram_Panels(Processed_Channels_Data CH_Data)
        {
            Histogram_Panels_Data_Pass_Task_List.Clear();
            try
            {
                if (Histogram_Layout_1 != null & Histogram_Panel_1 != null)
                {
                    Task Task_1_Histogram = Task.Run(() =>
                    {
                        Histogram_Panel_1.Calculate_Math_Expression(CH_Data);
                    }); Histogram_Panels_Data_Pass_Task_List.Add(Task_1_Histogram);
                }
            }
            catch (Exception) { }
            try
            {
                if (Histogram_Layout_2 != null & Histogram_Panel_2 != null)
                {
                    Task Task_2_Histogram = Task.Run(() =>
                    {
                        Histogram_Panel_2.Calculate_Math_Expression(CH_Data);
                    }); Histogram_Panels_Data_Pass_Task_List.Add(Task_2_Histogram);
                }
            }
            catch (Exception) { }
            try
            {
                if (Histogram_Layout_3 != null & Histogram_Panel_3 != null)
                {
                    Task Task_3_Histogram = Task.Run(() =>
                    {
                        Histogram_Panel_3.Calculate_Math_Expression(CH_Data);
                    }); Histogram_Panels_Data_Pass_Task_List.Add(Task_3_Histogram);
                }
            }
            catch (Exception) { }
            try
            {
                if (Histogram_Layout_4 != null & Histogram_Panel_4 != null)
                {
                    Task Task_4_Histogram = Task.Run(() =>
                    {
                        Histogram_Panel_4.Calculate_Math_Expression(CH_Data);
                    }); Histogram_Panels_Data_Pass_Task_List.Add(Task_4_Histogram);
                }
            }
            catch (Exception) { }
            try
            {
                if (Histogram_Layout_5 != null & Histogram_Panel_5 != null)
                {
                    Task Task_5_Histogram = Task.Run(() =>
                    {
                        Histogram_Panel_5.Calculate_Math_Expression(CH_Data);
                    }); Histogram_Panels_Data_Pass_Task_List.Add(Task_5_Histogram);
                }
            }
            catch (Exception) { }
            Task.WaitAll(Histogram_Panels_Data_Pass_Task_List.ToArray());
        }
    }
}
