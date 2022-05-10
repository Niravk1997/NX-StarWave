using MahApps.Metro.Controls;
using System;
using System.Collections.Concurrent;
using System.Linq;

namespace Reference_Calculator
{
    public partial class Reference_Config_Panel : MetroWindow
    {
        private BlockingCollection<Expression_Data> Math_Expressions_Stored = new BlockingCollection<Expression_Data>();

        private System.Timers.Timer Math_Expression_Process;

        private void Initialize_Timers()
        {
            Math_Expression_Process = new System.Timers.Timer();
            Math_Expression_Process.Interval = 1500;
            Math_Expression_Process.Elapsed += Math_Expression_Processor;
            Math_Expression_Process.AutoReset = false;
            Math_Expression_Process.Enabled = true;
            Math_Expression_Process.Start();
        }

        private void Math_Expression_Processor(object sender, EventArgs e)
        {
            try
            {
                while (Math_Expressions_Stored.Count() > 0)
                {
                    int Panel_Open_Counter = 3;
                    Expression_Data Math_Expression = Math_Expressions_Stored.Take();
                    string[] Waveform_Config = Math_Expression.Expression_Waveform_Config.Split(',');
                    string[] Histogram_Config = Math_Expression.Expression_Histogram_Config.Split(',');
                    string[] FFT_Config = Math_Expression.Expression_FFT_Config.Split(',');
                    (bool isValid, double[] X_Waveform_Data, double[] Y_Waveform_Data, double Total_Time, double Start_Time, double Stop_Time, int Data_Points) = Calculate_Math_Expression(Math_Expression);
                    if (isValid)
                    {
                        if (Waveform_Config[0] == "True")
                        {
                            Initialize_Data_Anytime_Waveform_Window(Math_Expression.Expression_Name, Waveform_Config, X_Waveform_Data, Y_Waveform_Data, Total_Time, Start_Time, Stop_Time, Data_Points);
                        }
                        else
                        {
                            Panel_Open_Counter--;
                        }
                        if (Histogram_Config[0] == "True")
                        {
                            Initialize_Data_Anytime_Histogram_Window(Math_Expression.Expression_Name, Histogram_Config, Waveform_Config, X_Waveform_Data, Y_Waveform_Data, Total_Time, Start_Time, Stop_Time, Data_Points);
                        }
                        else
                        {
                            Panel_Open_Counter--;
                        }
                        if (FFT_Config[0] == "True")
                        {
                            Initialize_Data_Anytime_FFT_Window(Math_Expression.Expression_Name, Math_Expression.Expression_Name, Math_Expression.Expression_Name, FFT_Config, X_Waveform_Data, Y_Waveform_Data, Total_Time, Start_Time, Stop_Time, Data_Points);
                        }
                        else
                        {
                            Panel_Open_Counter--;
                        }
                        if (Panel_Open_Counter == 0)
                        {
                            insert_Log("Expression not graphed on any panels.", 2);
                        }
                    }
                    else
                    {
                        insert_Log("Calculating Math Expression generated errors.", 1);
                        insert_Log("Expression not graphed on any panels.", 2);
                    }
                }
                Math_Expression_Process.Start();
            }
            catch (Exception Ex)
            {
                insert_Log(Ex.Message, 1);
                Math_Expression_Process.Start();
            }
        }
    }
}
