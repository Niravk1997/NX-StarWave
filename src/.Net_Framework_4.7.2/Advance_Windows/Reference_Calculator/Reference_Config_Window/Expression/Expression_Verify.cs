using MahApps.Metro.Controls;
using org.mariuszgromada.math.mxparser;
using System;
using System.Linq;
using System.Windows;
using Expression = org.mariuszgromada.math.mxparser.Expression;

namespace Reference_Calculator
{
    public partial class Reference_Config_Panel : MetroWindow
    {
        private void Expression_Verify_Click(object sender, RoutedEventArgs e)
        {
            Expression_Verify();
        }

        private bool Expression_Verify()
        {
            string Expression_Wavefrom_Config = Show_Waveform + "," + Waveform_Color + "," + Waveform_YAXIS + "," + Waveform_YAXIS_Units + "," + Waveform_Title + "," + Waveform_Continuous;
            string Expression_Histogram_Config = Show_Histogram + "," + Histogram_Color + "," + Histogram_Buckets + "," + Histogram_Continuous;
            string Expression_FFT_Config = Show_FFT + "," + FFT_Color + "," + FFT_Units + "," + FFT_Window + "," + FFT_Phase + "," + FFT_Phase_Units + "," + FFT_Phase_Ignore + "," + FFT_Peaks + "," + FFT_Peaks_Reference + "," + FFT_Peaks_Size;
            return Verify_Math_Expression(new Expression_Data(false, Expression_Name, Expression, Expression_Wavefrom_Config, Expression_Histogram_Config, Expression_FFT_Config));
        }

        private bool Verify_Math_Expression(Expression_Data expression_unverified)
        {
            try
            {
                if (new[] { "x1", "x2", "x3", "x4", "x5", "x6", "x7", "x8" }.Any(c => expression_unverified.Expression.Contains(c)))
                {
                    double[] Dummy_Data = { 1, 2, 3, 4, 5 };
                    double[] Results = new double[5];

                    Argument[] argument = new Argument[8];
                    argument[0] = new Argument("x1", 0);
                    argument[1] = new Argument("x2", 0);
                    argument[2] = new Argument("x3", 0);
                    argument[3] = new Argument("x4", 0);
                    argument[4] = new Argument("x5", 0);
                    argument[5] = new Argument("x6", 0);
                    argument[6] = new Argument("x7", 0);
                    argument[7] = new Argument("x8", 0);

                    Expression expression = new Expression(expression_unverified.Expression, argument);

                    if (expression.checkSyntax())
                    {
                        insert_Log("Input Values: " + Dummy_Data[0] + ", " + Dummy_Data[1] + ", " + Dummy_Data[2] + ", " + Dummy_Data[3] + ", " + Dummy_Data[4], 0);
                        for (int i = 0; i < 5; i++)
                        {
                            argument[0].setArgumentValue(Dummy_Data[i]);
                            argument[1].setArgumentValue(Dummy_Data[i]);
                            argument[2].setArgumentValue(Dummy_Data[i]);
                            argument[3].setArgumentValue(Dummy_Data[i]);
                            argument[4].setArgumentValue(Dummy_Data[i]);
                            argument[5].setArgumentValue(Dummy_Data[i]);
                            argument[6].setArgumentValue(Dummy_Data[i]);
                            argument[7].setArgumentValue(Dummy_Data[i]);
                            Results[i] = expression.calculate();
                        }
                        insert_Log("Output Values: " + Results[0] + ", " + Results[1] + ", " + Results[2] + ", " + Results[3] + ", " + Results[4], 0);
                        insert_Log("Expression Syntax Check Passed.", 0);
                        return true;
                    }
                    else
                    {
                        string Expression_Error_Message = expression.getErrorMessage();
                        insert_Log(Expression_Error_Message, 1);
                        return false;
                    }
                }
                else
                {
                    insert_Log("No Reference parameters (x1, x2, x3, x4, x5, x6, x7, x8) found in the math expression.", 2);
                    if (string.IsNullOrEmpty(expression_unverified.Expression))
                    {
                        insert_Log("Input Math Expression field is empty or null.", 2);
                        return false;
                    }
                    else
                    {
                        Expression expression = new Expression(expression_unverified.Expression);
                        if (expression.checkSyntax())
                        {
                            var Results = expression.calculate();
                            insert_Log(Results + ", Expression: " + expression.getExpressionString(), 5);
                            return false;
                        }
                        else
                        {
                            string Expression_Error_Message = expression.getErrorMessage();
                            insert_Log(Expression_Error_Message, 1);
                            return false;
                        }
                    }
                }
            }
            catch (Exception Ex)
            {
                insert_Log(Ex.Message, 1);
                return false;
            }
        }
    }
}
