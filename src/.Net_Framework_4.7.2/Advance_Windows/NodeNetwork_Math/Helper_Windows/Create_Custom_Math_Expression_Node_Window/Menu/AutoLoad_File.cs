using MahApps.Metro.Controls;
using System;
using System.Collections.Generic;
using System.IO;

namespace Create_Custom_Math_Expression_Node
{
    public partial class Create_Custom_Math_Expression_Window : MetroWindow
    {
        private string FileName = "NX_StarWave_NodeMath_Custom_Expressions.config";
        private bool AutoLoad_isBusy = false;
        private char Text_Split = ',';

        private bool AutoLoad_isFile_Exists()
        {
            return File.Exists(NX_StarWave.Communication_Selected.folder_Directory + FileName);
        }

        private void AutoLoad_Load_File()
        {
            try
            {
                Dispatcher.BeginInvoke((Action)(() =>
                {
                    if (AutoLoad_isFile_Exists() & AutoLoad_isBusy == false)
                    {
                        AutoLoad_isBusy = true;
                        IEnumerable<string> Lines = File.ReadLines(NX_StarWave.Communication_Selected.folder_Directory + FileName);
                        foreach (var Line in Lines)
                        {
                            try
                            {
                                string[] Custom_MathExpression = Line.Split(Text_Split);

                                string Expression_Name = Custom_MathExpression[0];
                                string Expression = Custom_MathExpression[1];
                                int Category = int.Parse(Custom_MathExpression[2]);
                                string Units = Custom_MathExpression[3];
                                string Background = Custom_MathExpression[4];
                                string Foreground = Custom_MathExpression[5];
                                int Total_Inputs = int.Parse(Custom_MathExpression[6]);
                                string Output = Custom_MathExpression[7];
                                string X1 = Custom_MathExpression[8];
                                string X2 = Custom_MathExpression[9];
                                string X3 = Custom_MathExpression[10];
                                string X4 = Custom_MathExpression[11];
                                string X5 = Custom_MathExpression[12];
                                string X6 = Custom_MathExpression[13];
                                string X7 = Custom_MathExpression[14];

                                Expression_Data.Add(new Custom_Math_Expression_Node_Data(Expression_Name, Expression, Category, Units, Background, Foreground, Total_Inputs, Output, X1, X2, X3, X4, X5, X6, X7));
                            }
                            catch (Exception Ex)
                            {
                                insert_Log(Ex.Message, 1);
                                insert_Log("Failed to read an expression from the file.", 1);
                            }
                        }
                        AutoLoad_isBusy = false;
                        insert_Log("Auto Loaded Expression File.", 0);
                    }
                    else
                    {
                        if (AutoLoad_isBusy)
                        {
                            insert_Log("Auto Load is busy. Please Wait.", 2);
                        }
                        else
                        {
                            insert_Log("Auto Load Expression File failed. Could not find the file.", 2);
                        }
                    }
                }));
            }
            catch (Exception Ex)
            {
                AutoLoad_isBusy = false;
                insert_Log(Ex.Message, 1);
            }
        }

        private void AutoLoad_Create_File()
        {
            try
            {
                if (AutoLoad_isBusy == false)
                {
                    Dispatcher.BeginInvoke((Action)(() =>
                    {
                        try
                        {
                            AutoLoad_isBusy = true;
                            using (TextWriter writetext = new StreamWriter(NX_StarWave.Communication_Selected.folder_Directory + FileName))
                            {
                                foreach (var Expression in Expression_Data)
                                {
                                    string Custom_MathExpression =
                                      Expression.Expression_Name + Text_Split
                                    + Expression.Expression + Text_Split
                                    + Expression.Category + Text_Split
                                    + Expression.Units + Text_Split
                                    + Expression.Background + Text_Split
                                    + Expression.Foreground + Text_Split
                                    + Expression.Total_Inputs + Text_Split
                                    + Expression.Output + Text_Split
                                    + Expression.X1 + Text_Split
                                    + Expression.X2 + Text_Split
                                    + Expression.X3 + Text_Split
                                    + Expression.X4 + Text_Split
                                    + Expression.X5 + Text_Split
                                    + Expression.X6 + Text_Split
                                    + Expression.X7 + Text_Split;
                                    writetext.WriteLine(Custom_MathExpression);
                                }
                            }
                            AutoLoad_isBusy = false;
                        }
                        catch (Exception Ex)
                        {
                            AutoLoad_isBusy = false;
                            insert_Log(Ex.Message, 1);
                            insert_Log("Could not Quick Save Expressions.", 1);
                        }
                    }));
                }
            }
            catch (Exception Ex)
            {
                AutoLoad_isBusy = false;
                insert_Log(Ex.Message, 1);
                insert_Log("Could not Quick Save Expressions.", 1);
            }
        }
    }
}
