using MahApps.Metro.Controls;
using System;
using System.Windows;

namespace SCPI_Communication
{
    public partial class SCPI_Communication_Window : MetroWindow
    {
        private void Expression_Verify_Click(object sender, RoutedEventArgs e)
        {
            Expression_Verify(SCPI_Expression);
        }

        private bool Expression_Verify(string SCPI_Expression, bool Output_Results = true)
        {
            try
            {
                if (SCPI_Expression.Trim() != string.Empty || SCPI_Expression.Trim() != "")
                {
                    if (SCPI_Expression.Contains("╦") == false)
                    {
                        if (SCPI_Expression.Contains("@"))
                        {
                            string[] SCPI_Commands = SCPI_Expression.Split('@');
                            int Total_Query_Commands = 0;
                            int Total_Write_Commands = 0;
                            for (int i = 0; i < SCPI_Commands.Length; i++)
                            {
                                if (SCPI_Commands[i].Contains("?"))
                                {
                                    Total_Query_Commands++;
                                }
                                else
                                {
                                    Total_Write_Commands++;
                                }
                                if (Output_Results)
                                {
                                    insert_Log(SCPI_Commands[i], 5);
                                }
                            }
                            if (Output_Results)
                            {
                                insert_Log("SCPI Expression has " + SCPI_Commands.Length + " SCPI commands.", 0);
                                insert_Log("SCPI Expression has " + Total_Query_Commands + " Query commands.", 0);
                                insert_Log("SCPI Expression has " + Total_Write_Commands + " Write commands.", 0);
                            }
                            return true;
                        }
                        else
                        {
                            if (Output_Results)
                            {
                                insert_Log("SCPI Expression has one SCPI command.", 0);
                                if (SCPI_Expression.Contains("?"))
                                {
                                    insert_Log("SCPI Expression has one Query command.", 0);
                                }
                                else
                                {
                                    insert_Log("SCPI Expression has one Write command.", 0);
                                }
                            }
                            return true;
                        }
                    }
                    else
                    {
                        insert_Log("SCPI Expression cannot contain \"╦\" character.", 2);
                        return false;
                    }
                }
                else
                {
                    insert_Log("SCPI Expression cannot be empty.", 2);
                    return false;
                }
            }
            catch (Exception Ex)
            {
                insert_Log(Ex.Message, 1);
                insert_Log("SCPI Expression Verify failed.", 1);
                return false;
            }
        }
    }
}
