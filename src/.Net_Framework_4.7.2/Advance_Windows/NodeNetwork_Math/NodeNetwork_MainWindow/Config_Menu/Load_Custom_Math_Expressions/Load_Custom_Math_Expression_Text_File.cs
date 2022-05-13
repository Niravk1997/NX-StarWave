using Create_Custom_Math_Expression_Node;
using MahApps.Metro.Controls;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows;

namespace NodeNetwork_Math
{
    public partial class NodeNetwork_Window : MetroWindow
    {
        private string Node_Math_Custom_Expression_FileName = "NX_StarWave_NodeMath_Custom_Expressions.config";
        private readonly string Text_Split = "@@@";
        private readonly string[] Text_Split_Array = new string[] { "@@@" };

        private bool AutoLoad_isFile_Exists(string FileName)
        {
            return File.Exists(NX_StarWave.Communication_Selected.folder_Directory + FileName);
        }

        private void AutoLoad_Load_File()
        {
            try
            {
                Dispatcher.BeginInvoke((Action)(() =>
                {
                    if (AutoLoad_isFile_Exists(Node_Math_Custom_Expression_FileName))
                    {
                        IEnumerable<string> Lines = File.ReadLines(NX_StarWave.Communication_Selected.folder_Directory + Node_Math_Custom_Expression_FileName);
                        foreach (var Line in Lines)
                        {
                            try
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

                                Add_Custom_Math_Expression_Node_depending_on_Total_Inputs(new Custom_Math_Expression_Node_Data(Expression_Name, Expression, Using_Fast_Expression_Parsing_Library, Category, Units, Background, Foreground, Total_Inputs, Output, X1, X2, X3, X4, X5, X6, X7));
                            }
                            catch (Exception Ex)
                            {
                                Insert_Log("Something went wrong when auto loading Custom Math Expression Nodes to NodeList", 2);
                                Insert_Log("Check the NX_StarWave_NodeMath_Custom_Expressions file.", 2);
                                Insert_Log(Ex.Message, 1);
                            }
                        }
                        Insert_Log("Auto Loaded Custom Math Expression Nodes to NodeList.", 0);
                    }
                }));
            }
            catch (Exception Ex)
            {
                Insert_Log(Ex.Message, 1);
            }
        }

        private void Add_Custom_Math_Expressions_From_File_Click(object sender, RoutedEventArgs e)
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

                        Add_Custom_Math_Expression_Node_depending_on_Total_Inputs(new Custom_Math_Expression_Node_Data(Expression_Name, Expression, Using_Fast_Expression_Parsing_Library, Category, Units, Background, Foreground, Total_Inputs, Output, X1, X2, X3, X4, X5, X6, X7));
                    }
                    Insert_Log("Added Custom Math Expressions from the file.", 0);
                }
            }
            catch (Exception Ex)
            {
                Insert_Log(Ex.Message, 1);
                Insert_Log("Could not add Custom Math Expressions from the file.", 1);
            }
        }
    }
}
