using MahApps.Metro.Controls;
using org.mariuszgromada.math.mxparser;
using System;
using System.Windows;

namespace Create_Custom_Math_Expression_Node
{
    public partial class Create_Custom_Math_Expression_Window : MetroWindow
    {
        private void Expression_Verify_Click(object sender, RoutedEventArgs e)
        {
            Expression_Verify();
        }

        private bool Expression_Verify()
        {
            if (Expression_Verify_in_Progress == false)
            {
                Expression_Verify_in_Progress = true;
                try
                {
                    if (Check_if_Expression_contains_Proper_Inputs(Total_Input_Select_Index))
                    {
                        if (Math_Expression_Verify(Total_Input_Select_Index))
                        {

                            Expression_Verify_in_Progress = false;
                            return true;
                        }
                    }
                    else
                    {
                        insert_Log("Expression does not contain proper number of inputs or input names don't match input names in the expression.", 1);
                    }
                    Expression_Verify_in_Progress = false;
                    return false;
                }
                catch (Exception Ex)
                {
                    Expression_Verify_in_Progress = false;
                    insert_Log(Ex.Message, 1);
                    insert_Log("Expression Verify failed. Check Expression, Total Inputs and Input Names.", 1);
                    return false;
                }
            }
            else
            {
                insert_Log("Expression verification in progress, wait until it is finished.", 2);
                return false;
            }
        }

        private bool Math_Expression_Verify(int Total_Inputs)
        {
            double[] Dummy_Data = { 1, 2, 3 };
            double[] Results = new double[3];

            Argument[] argument = new Argument[Total_Inputs + 1];

            if (Total_Inputs >= 0)
            {
                argument[0] = new Argument(Input_Text_1, 0);
            }

            if (Total_Inputs >= 1)
            {
                argument[1] = new Argument(Input_Text_2, 0);
            }

            if (Total_Inputs >= 2)
            {
                argument[2] = new Argument(Input_Text_3, 0);
            }

            if (Total_Inputs >= 3)
            {
                argument[3] = new Argument(Input_Text_4, 0);
            }

            if (Total_Inputs >= 4)
            {
                argument[4] = new Argument(Input_Text_5, 0);
            }

            if (Total_Inputs >= 5)
            {
                argument[5] = new Argument(Input_Text_6, 0);
            }

            if (Total_Inputs >= 6)
            {
                argument[6] = new Argument(Input_Text_7, 0);
            }

            org.mariuszgromada.math.mxparser.Expression expression = new org.mariuszgromada.math.mxparser.Expression(Expression, argument);

            if (expression.checkSyntax())
            {
                insert_Log("Input Values: " + Dummy_Data[0] + ", " + Dummy_Data[1] + ", " + Dummy_Data[2], 5);
                for (int i = 0; i < 3; i++)
                {
                    if (Total_Inputs >= 0)
                    {
                        argument[0].setArgumentValue(Dummy_Data[i]);
                    }

                    if (Total_Inputs >= 1)
                    {
                        argument[1].setArgumentValue(Dummy_Data[i]);
                    }

                    if (Total_Inputs >= 2)
                    {
                        argument[2].setArgumentValue(Dummy_Data[i]);
                    }

                    if (Total_Inputs >= 3)
                    {
                        argument[3].setArgumentValue(Dummy_Data[i]);
                    }

                    if (Total_Inputs >= 4)
                    {
                        argument[4].setArgumentValue(Dummy_Data[i]);
                    }

                    if (Total_Inputs >= 5)
                    {
                        argument[5].setArgumentValue(Dummy_Data[i]);
                    }

                    if (Total_Inputs >= 6)
                    {
                        argument[6].setArgumentValue(Dummy_Data[i]);
                    }
                    Results[i] = expression.calculate();
                }
                for (int i = 0; i < 3; i++)
                {
                    if (double.IsNaN(Results[i]) || double.IsInfinity(Results[i]))
                    {
                        insert_Log("Output Values were not valid real numbers.", 1);
                        return false;
                    }
                }
                insert_Log("Output Values: " + Results[0] + ", " + Results[1] + ", " + Results[2], 5);
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
    }
}
