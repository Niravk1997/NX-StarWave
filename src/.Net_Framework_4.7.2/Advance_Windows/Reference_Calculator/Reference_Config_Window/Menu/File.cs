using MahApps.Metro.Controls;
using Microsoft.Win32;
using System;
using System.IO;
using System.Windows;

namespace Reference_Calculator
{
    public partial class Reference_Config_Panel : MetroWindow
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
                    FileName = "NX_StarWave_RefMath_Expressions.txt",
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
                            string Expression_Data = Expression.Expression_Selected + "╦" + Expression.Expression_Name + "╦" + Expression.Expression + "╦" + Expression.Expression_Waveform_Config + "╦" + Expression.Expression_Histogram_Config + "╦" + Expression.Expression_FFT_Config;
                            writetext.WriteLine(Expression_Data);
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
                    FileName = "NX_StarWave_RefMath_Expressions.txt",
                    Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*"
                };
                if (File_Dialog.ShowDialog() is true)
                {
                    var Lines = File.ReadLines(File_Dialog.FileName);
                    foreach (var Line in Lines)
                    {
                        string[] Expression = Line.Split('╦');
                        bool Expression_Selected = false;
                        if (Expression[0] == "True")
                        {
                            Expression_Selected = true;
                        }
                        string Expression_Name = Expression[1];
                        string Expression_Math = Expression[2];
                        string Expression_Waveform_Config = Expression[3];
                        string Expression_Histogram_Config = Expression[4];
                        string Expression_FFT_Config = Expression[5];
                        Expression_Data.Add(new Expression_Data(Expression_Selected, Expression_Name, Expression_Math, Expression_Waveform_Config, Expression_Histogram_Config, Expression_FFT_Config));
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
