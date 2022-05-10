using MahApps.Metro.Controls;
using org.mariuszgromada.math.mxparser;
using System.Collections.Generic;
using System.Linq;
using System.Windows;

namespace Reference_Calculator
{
    public partial class Reference_Config_Panel : MetroWindow
    {
        private void Math_Expression_Calculate_Click(object sender, RoutedEventArgs e)
        {
            string Expression_Wavefrom_Config = Show_Waveform + "," + Waveform_Color + "," + Waveform_YAXIS + "," + Waveform_YAXIS_Units + "," + Waveform_Title + "," + Waveform_Continuous;
            string Expression_Histogram_Config = Show_Histogram + "," + Histogram_Color + "," + Histogram_Buckets + "," + Histogram_Continuous;
            string Expression_FFT_Config = Show_FFT + "," + FFT_Color + "," + FFT_Units + "," + FFT_Window + "," + FFT_Phase + "," + FFT_Phase_Units + "," + FFT_Phase_Ignore + "," + FFT_Peaks + "," + FFT_Peaks_Reference + "," + FFT_Peaks_Size + "," + FFT_Interpolation_Enable + "," + FFT_Interpolation_Type_Selected + "," + FFT_Interpolation_Factor;
            Expression_Data expression = new Expression_Data(false, Expression_Name, Expression, Expression_Wavefrom_Config, Expression_Histogram_Config, Expression_FFT_Config);
            if (Verify_Math_Expression(expression))
            {
                Math_Expressions_Stored.Add(expression);
                if (Auto_Save)
                {
                    Save_Expression_to_Table();
                }
                if (Auto_Clear)
                {
                    Clear_Expression_Config();
                }
            }
            else
            {
                insert_Log("Expression cannot be calculated.", 1);
            }
        }

        private (bool, double[], double[], double, double, double, int) Calculate_Math_Expression(Expression_Data Math_Expression)
        {
            double Max_Value_Allowed = 1E+9;
            double Min_Value_Allowed = -1E+9;

            bool Can_Math_Expression_Calculate = true;

            bool Is_x1_valid = false;
            bool Is_x2_valid = false;
            bool Is_x3_valid = false;
            bool Is_x4_valid = false;
            bool Is_x5_valid = false;
            bool Is_x6_valid = false;
            bool Is_x7_valid = false;
            bool Is_x8_valid = false;

            List<double> x_Data_Points_Compare = new List<double>();
            List<double> x_Total_Time_Compare = new List<double>();
            List<double> x_Start_Time_Compare = new List<double>();
            List<double> x_Stop_Time_Compare = new List<double>();

            if (Math_Expression.Expression.Contains("x1"))
            {
                if (Reference_1_Valid)
                {
                    Is_x1_valid = true;
                    x_Data_Points_Compare.Add(Reference_1_Data_Points);
                    x_Total_Time_Compare.Add(Reference_1_Total_Time);
                    x_Start_Time_Compare.Add(Reference_1_Start_Time);
                    x_Stop_Time_Compare.Add(Reference_1_Stop_Time);
                }
                else
                {
                    Can_Math_Expression_Calculate = false;
                }
            }
            if (Math_Expression.Expression.Contains("x2"))
            {
                if (Reference_2_Valid)
                {
                    Is_x2_valid = true;
                    x_Data_Points_Compare.Add(Reference_2_Data_Points);
                    x_Data_Points_Compare.Add(Reference_2_Data_Points);
                    x_Total_Time_Compare.Add(Reference_2_Total_Time);
                    x_Start_Time_Compare.Add(Reference_2_Start_Time);
                    x_Stop_Time_Compare.Add(Reference_2_Stop_Time);
                }
                else
                {
                    Can_Math_Expression_Calculate = false;
                }
            }
            if (Math_Expression.Expression.Contains("x3"))
            {
                if (Reference_3_Valid)
                {
                    Is_x3_valid = true;
                    x_Data_Points_Compare.Add(Reference_3_Data_Points);
                    x_Data_Points_Compare.Add(Reference_3_Data_Points);
                    x_Total_Time_Compare.Add(Reference_3_Total_Time);
                    x_Start_Time_Compare.Add(Reference_3_Start_Time);
                    x_Stop_Time_Compare.Add(Reference_3_Stop_Time);
                }
                else
                {
                    Can_Math_Expression_Calculate = false;
                }
            }
            if (Math_Expression.Expression.Contains("x4"))
            {
                if (Reference_4_Valid)
                {
                    Is_x4_valid = true;
                    x_Data_Points_Compare.Add(Reference_4_Data_Points);
                    x_Total_Time_Compare.Add(Reference_4_Total_Time);
                    x_Start_Time_Compare.Add(Reference_4_Start_Time);
                    x_Stop_Time_Compare.Add(Reference_4_Stop_Time);
                }
                else
                {
                    Can_Math_Expression_Calculate = false;
                }
            }
            if (Math_Expression.Expression.Contains("x5"))
            {
                if (Reference_5_Valid)
                {
                    Is_x5_valid = true;
                    x_Data_Points_Compare.Add(Reference_5_Data_Points);
                    x_Total_Time_Compare.Add(Reference_5_Total_Time);
                    x_Start_Time_Compare.Add(Reference_5_Start_Time);
                    x_Stop_Time_Compare.Add(Reference_5_Stop_Time);
                }
                else
                {
                    Can_Math_Expression_Calculate = false;
                }
            }
            if (Math_Expression.Expression.Contains("x6"))
            {
                if (Reference_6_Valid)
                {
                    Is_x6_valid = true;
                    x_Data_Points_Compare.Add(Reference_6_Data_Points);
                    x_Total_Time_Compare.Add(Reference_6_Total_Time);
                    x_Start_Time_Compare.Add(Reference_6_Start_Time);
                    x_Stop_Time_Compare.Add(Reference_6_Stop_Time);
                }
                else
                {
                    Can_Math_Expression_Calculate = false;
                }
            }
            if (Math_Expression.Expression.Contains("x7"))
            {
                if (Reference_7_Valid)
                {
                    Is_x7_valid = true;
                    x_Data_Points_Compare.Add(Reference_7_Data_Points);
                    x_Total_Time_Compare.Add(Reference_7_Total_Time);
                    x_Start_Time_Compare.Add(Reference_7_Start_Time);
                    x_Stop_Time_Compare.Add(Reference_7_Stop_Time);
                }
                else
                {
                    Can_Math_Expression_Calculate = false;
                }
            }
            if (Math_Expression.Expression.Contains("x8"))
            {
                if (Reference_8_Valid)
                {
                    Is_x8_valid = true;
                    x_Data_Points_Compare.Add(Reference_8_Data_Points);
                    x_Total_Time_Compare.Add(Reference_8_Total_Time);
                    x_Start_Time_Compare.Add(Reference_8_Start_Time);
                    x_Stop_Time_Compare.Add(Reference_8_Stop_Time);
                }
                else
                {
                    Can_Math_Expression_Calculate = false;
                }
            }

            if (Can_Math_Expression_Calculate == true)
            {
                if (x_Data_Points_Compare.Any(o => o != x_Data_Points_Compare[0]))
                {
                    insert_Log("References Data Points mismatch. They all must have the same number of data points.", 1);
                    insert_Log("Math Expression cannot be calculated.", 1);
                    return (false, null, null, 0, 0, 0, 0);
                }
                else if (x_Total_Time_Compare.Any(o => o != x_Total_Time_Compare[0]))
                {
                    insert_Log("References Total Time mismatch.", 2);
                    insert_Log("Math Expression cannot be calculated.", 1);
                    return (false, null, null, 0, 0, 0, 0);
                }
                else
                {
                    if (x_Start_Time_Compare.Any(o => o != x_Start_Time_Compare[0]))
                    {
                        insert_Log("References Start Time mismatch.", 2);
                    }
                    if (x_Stop_Time_Compare.Any(o => o != x_Stop_Time_Compare[0]))
                    {
                        insert_Log("References Stop Time mismatch.", 2);
                    }

                    int Total_Data_Points = (int)x_Data_Points_Compare.ElementAt(0);

                    double[] Calculate_Expression_Results = new double[Total_Data_Points];

                    Argument[] argument = new Argument[8];
                    argument[0] = new Argument("x1", 0);
                    argument[1] = new Argument("x2", 0);
                    argument[2] = new Argument("x3", 0);
                    argument[3] = new Argument("x4", 0);
                    argument[4] = new Argument("x5", 0);
                    argument[5] = new Argument("x6", 0);
                    argument[6] = new Argument("x7", 0);
                    argument[7] = new Argument("x8", 0);

                    org.mariuszgromada.math.mxparser.Expression expression = new org.mariuszgromada.math.mxparser.Expression(Math_Expression.Expression, argument);
                    for (int i = 0; i < Total_Data_Points; i++)
                    {
                        if (Is_x1_valid) { argument[0].setArgumentValue(Reference_1_Y_Values[i]); }
                        if (Is_x2_valid) { argument[1].setArgumentValue(Reference_2_Y_Values[i]); }
                        if (Is_x3_valid) { argument[2].setArgumentValue(Reference_3_Y_Values[i]); }
                        if (Is_x4_valid) { argument[3].setArgumentValue(Reference_4_Y_Values[i]); }
                        if (Is_x5_valid) { argument[4].setArgumentValue(Reference_5_Y_Values[i]); }
                        if (Is_x6_valid) { argument[5].setArgumentValue(Reference_6_Y_Values[i]); }
                        if (Is_x7_valid) { argument[6].setArgumentValue(Reference_7_Y_Values[i]); }
                        if (Is_x8_valid) { argument[7].setArgumentValue(Reference_8_Y_Values[i]); }
                        Calculate_Expression_Results[i] = expression.calculate();
                        if (double.IsNaN(Calculate_Expression_Results[i]) || double.IsInfinity(Calculate_Expression_Results[i]) || Calculate_Expression_Results[i] >= Max_Value_Allowed || Calculate_Expression_Results[i] <= Min_Value_Allowed)
                        {
                            Calculate_Expression_Results[i] = 0;
                        }
                    }

                    double[] X_Waveform_Data = null;
                    double Total_Time = 0;
                    double Start_Time = 0;
                    double Stop_Time = 0;
                    int Data_Points = 0;

                    if (Is_x1_valid)
                    {
                        X_Waveform_Data = Reference_1_X_Values;
                        Total_Time = Reference_1_Total_Time;
                        Start_Time = Reference_1_Start_Time;
                        Stop_Time = Reference_1_Stop_Time;
                        Data_Points = Reference_1_Data_Points;
                    }
                    else if (Is_x2_valid)
                    {
                        X_Waveform_Data = Reference_2_X_Values;
                        Total_Time = Reference_2_Total_Time;
                        Start_Time = Reference_2_Start_Time;
                        Stop_Time = Reference_2_Stop_Time;
                        Data_Points = Reference_2_Data_Points;
                    }
                    else if (Is_x3_valid)
                    {
                        X_Waveform_Data = Reference_3_X_Values;
                        Total_Time = Reference_3_Total_Time;
                        Start_Time = Reference_3_Start_Time;
                        Stop_Time = Reference_3_Stop_Time;
                        Data_Points = Reference_3_Data_Points;
                    }
                    else if (Is_x4_valid)
                    {
                        X_Waveform_Data = Reference_4_X_Values;
                        Total_Time = Reference_4_Total_Time;
                        Start_Time = Reference_4_Start_Time;
                        Stop_Time = Reference_4_Stop_Time;
                        Data_Points = Reference_4_Data_Points;
                    }
                    else if (Is_x5_valid)
                    {
                        X_Waveform_Data = Reference_5_X_Values;
                        Total_Time = Reference_5_Total_Time;
                        Start_Time = Reference_5_Start_Time;
                        Stop_Time = Reference_5_Stop_Time;
                        Data_Points = Reference_5_Data_Points;
                    }
                    else if (Is_x6_valid)
                    {
                        X_Waveform_Data = Reference_6_X_Values;
                        Total_Time = Reference_6_Total_Time;
                        Start_Time = Reference_6_Start_Time;
                        Stop_Time = Reference_6_Stop_Time;
                        Data_Points = Reference_6_Data_Points;
                    }
                    else if (Is_x7_valid)
                    {
                        X_Waveform_Data = Reference_7_X_Values;
                        Total_Time = Reference_7_Total_Time;
                        Start_Time = Reference_7_Start_Time;
                        Stop_Time = Reference_7_Stop_Time;
                        Data_Points = Reference_7_Data_Points;
                    }
                    else if (Is_x8_valid)
                    {
                        X_Waveform_Data = Reference_8_X_Values;
                        Total_Time = Reference_8_Total_Time;
                        Start_Time = Reference_8_Start_Time;
                        Stop_Time = Reference_8_Stop_Time;
                        Data_Points = Reference_8_Data_Points;
                    }

                    return (true, X_Waveform_Data, Calculate_Expression_Results, Total_Time, Start_Time, Stop_Time, Data_Points);
                }
            }
            else
            {
                insert_Log("Math Expression cannot be calculated.", 1);
                return (false, null, null, 0, 0, 0, 0);
            }
        }
    }
}
