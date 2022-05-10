using MahApps.Metro.Controls;
using Microsoft.Win32;
using System;
using System.IO;
using System.Windows;

namespace SCPI_Communication
{
    public partial class SCPI_Communication_Window : MetroWindow
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
                    FileName = this.FileName,
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
                        for (int i = 0; i < SCPI_Expression_Table.Count; i++)
                        {
                            string Expression_Data = SCPI_Expression_Table[i].SCPI_Expression_Selected + "╦" + SCPI_Expression_Table[i].SCPI_Expression_Description + "╦" + SCPI_Expression_Table[i].SCPI_Expression;
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
                    FileName = this.FileName,
                    Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*"
                };
                if (File_Dialog.ShowDialog() is true)
                {
                    var Lines = File.ReadLines(File_Dialog.FileName);
                    foreach (var Line in Lines)
                    {
                        string[] Expression_Data = Line.Split('╦');
                        if (Expression_Data[0] == "True")
                        {
                            SCPI_Expression_Table.Add(new SCPI_Expression_Data(true, Expression_Data[1], Expression_Data[2]));
                        }
                        else
                        {
                            SCPI_Expression_Table.Add(new SCPI_Expression_Data(false, Expression_Data[1], Expression_Data[2]));
                        }
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
