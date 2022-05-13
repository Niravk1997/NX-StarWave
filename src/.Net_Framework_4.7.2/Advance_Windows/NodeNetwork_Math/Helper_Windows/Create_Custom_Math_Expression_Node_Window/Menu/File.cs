using MahApps.Metro.Controls;
using Microsoft.Win32;
using System;
using System.IO;
using System.Windows;

namespace Create_Custom_Math_Expression_Node
{
    public partial class Create_Custom_Math_Expression_Window : MetroWindow
    {
        private void Save_Expressions_from_Table_to_Text_File_Click(object sender, RoutedEventArgs e)
        {
            this.Expression_DataGrid.CommitEdit();
            this.Expression_DataGrid.CommitEdit();
            Save_Expressions_from_Table_to_Text_File(false);
        }

        private void Save_Expressions_Append_from_Table_to_Text_File_Click(object sender, RoutedEventArgs e)
        {
            this.Expression_DataGrid.CommitEdit();
            this.Expression_DataGrid.CommitEdit();
            Save_Expressions_from_Table_to_Text_File(true);
        }

        private void Save_Expressions_from_Table_to_Text_File(bool Append)
        {
            try
            {
                SaveFileDialog File_Dialog = new SaveFileDialog
                {
                    InitialDirectory = NX_StarWave.Communication_Selected.folder_Directory,
                    FileName = "NX_StarWave_NodeMath_Custom_Expressions.txt",
                    Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*"
                };
                if (Append == true)
                {
                    File_Dialog.OverwritePrompt = false;
                }
                else
                {
                    File_Dialog.OverwritePrompt = true;
                }
                if (File_Dialog.ShowDialog() is true)
                {
                    using (TextWriter writetext = new StreamWriter(File_Dialog.FileName, Append))
                    {
                        foreach (var Expression in Expression_Data)
                        {
                            string Custom_MathExpression =
                                Expression.Expression_Name + Text_Split
                              + Expression.Expression + Text_Split
                              + Expression.Using_Fast_Expression_Parsing_Library + Text_Split
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
                }
            }
            catch (Exception Ex)
            {
                insert_Log(Ex.Message, 1);
            }
        }

        private void Quick_Save_AutoLoad_File_Click(object sender, RoutedEventArgs e)
        {
            this.Expression_DataGrid.CommitEdit();
            this.Expression_DataGrid.CommitEdit();
            AutoLoad_Create_File();
        }

        private void Load_Expressions_from_File_to_Table_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                OpenFileDialog File_Dialog = new OpenFileDialog
                {
                    InitialDirectory = NX_StarWave.Communication_Selected.folder_Directory,
                    FileName = "NX_StarWave_NodeMath_Custom_Expressions.txt",
                    Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*",
                };
                if (File_Dialog.ShowDialog() is true)
                {
                    var Lines = File.ReadLines(File_Dialog.FileName);
                    foreach (var Line in Lines)
                    {
                        string[] Custom_MathExpression = Line.Split(Text_Split_Array, StringSplitOptions.None);

                        string Expression_Name = Custom_MathExpression[0];
                        string Expression = Custom_MathExpression[1];
                        bool Using_Fast_Expression_Parsing_Library = Custom_MathExpression[2].Equals("True") ? true : false;
                        int Category = int.Parse(Custom_MathExpression[3]);
                        string Units = Custom_MathExpression[4];
                        string Background = Custom_MathExpression[5];
                        string Foreground = Custom_MathExpression[6];
                        int Total_Inputs = int.Parse(Custom_MathExpression[7]);
                        string Output = Custom_MathExpression[8];
                        string X1 = Custom_MathExpression[9];
                        string X2 = Custom_MathExpression[10];
                        string X3 = Custom_MathExpression[11];
                        string X4 = Custom_MathExpression[12];
                        string X5 = Custom_MathExpression[13];
                        string X6 = Custom_MathExpression[14];
                        string X7 = Custom_MathExpression[15];

                        Expression_Data.Add(new Custom_Math_Expression_Node_Data(Expression_Name, Expression, Using_Fast_Expression_Parsing_Library, Category, Units, Background, Foreground, Total_Inputs, Output, X1, X2, X3, X4, X5, X6, X7));
                    }
                }
            }
            catch (Exception Ex)
            {
                insert_Log(Ex.Message, 1);
            }
        }

        private void Quick_Load_AutoLoad_File_Click(object sender, RoutedEventArgs e)
        {
            AutoLoad_Load_File();
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
