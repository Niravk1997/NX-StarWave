using Custom_Math_Expression_Class;
using MahApps.Metro.Controls;
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
                        if (Math_Expression_Verify())
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

        private bool Math_Expression_Verify()
        {
            if (Fast_Expression_Parsing_Library)
            {
                if (Total_Input_Select_Index <= 3)
                {
                    Custom_Math_Expression_Parse Test_Case = null;
                    switch (Total_Input_Select_Index)
                    {
                        case 0:
                            Test_Case = new MathNET_Symbolics_Expression_Parser(Expression, Output_Text, Input_Text_1);
                            break;
                        case 1:
                            Test_Case = new MathNET_Symbolics_Expression_Parser(Expression, Output_Text, Input_Text_1, Input_Text_2);
                            break;
                        case 2:
                            Test_Case = new MathNET_Symbolics_Expression_Parser(Expression, Output_Text, Input_Text_1, Input_Text_2, Input_Text_3);
                            break;
                        case 3:
                            Test_Case = new MathNET_Symbolics_Expression_Parser(Expression, Output_Text, Input_Text_1, Input_Text_2, Input_Text_3, Input_Text_4);
                            break;
                        default:
                            break;
                    }
                    if (Test_Case != null)
                    {
                        (bool isValid, string Message_1, string Message_2, string Message_3) = Test_Case.Verify_Expression();
                        if (isValid)
                        {
                            insert_Log(Message_1, 0);
                            insert_Log(Message_2, 0);
                            insert_Log(Message_3, 0);
                            return true;
                        }
                        else
                        {
                            insert_Log(Message_1, 1);
                            insert_Log(Message_2, 1);
                            insert_Log(Message_3, 1);
                            return false;
                        }
                    }
                    else
                    {
                        insert_Log("Test case was null, this should not have happened, check source code.", 1);
                        return false;
                    }
                }
                else
                {
                    insert_Log("MathNET Symbolics Expression Parser only supports a maximum of 4 inputs.", 1);
                    return false;
                }
            }
            else
            {
                if (Total_Input_Select_Index <= 6)
                {
                    Custom_Math_Expression_Parse Test_Case = null;
                    switch (Total_Input_Select_Index)
                    {
                        case 0:
                            Test_Case = new mXparser_Expression_Parser(Expression, Output_Text, Input_Text_1);
                            break;
                        case 1:
                            Test_Case = new mXparser_Expression_Parser(Expression, Output_Text, Input_Text_1, Input_Text_2);
                            break;
                        case 2:
                            Test_Case = new mXparser_Expression_Parser(Expression, Output_Text, Input_Text_1, Input_Text_2, Input_Text_3);
                            break;
                        case 3:
                            Test_Case = new mXparser_Expression_Parser(Expression, Output_Text, Input_Text_1, Input_Text_2, Input_Text_3, Input_Text_4);
                            break;
                        case 4:
                            Test_Case = new mXparser_Expression_Parser(Expression, Output_Text, Input_Text_1, Input_Text_2, Input_Text_3, Input_Text_4, Input_Text_5);
                            break;
                        case 5:
                            Test_Case = new mXparser_Expression_Parser(Expression, Output_Text, Input_Text_1, Input_Text_2, Input_Text_3, Input_Text_4, Input_Text_5, Input_Text_6);
                            break;
                        case 6:
                            Test_Case = new mXparser_Expression_Parser(Expression, Output_Text, Input_Text_1, Input_Text_2, Input_Text_3, Input_Text_4, Input_Text_5, Input_Text_6, Input_Text_7);
                            break;
                        default:
                            break;
                    }
                    if (Test_Case != null)
                    {
                        (bool isValid, string Message_1, string Message_2, string Message_3) = Test_Case.Verify_Expression();
                        if (isValid)
                        {
                            insert_Log(Message_1, 0);
                            insert_Log(Message_2, 0);
                            insert_Log(Message_3, 0);
                            return true;
                        }
                        else
                        {
                            insert_Log(Message_1, 1);
                            insert_Log(Message_2, 1);
                            insert_Log(Message_3, 1);
                            return false;
                        }
                    }
                    else
                    {
                        insert_Log("Test case was null, this should not have happened, check source code.", 1);
                        return false;
                    }
                }
                else
                {
                    insert_Log("mXparser Expression Parser only supports a maximum of 7 inputs.", 1);
                    return false;
                }
            }
        }
    }
}
