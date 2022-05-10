using MahApps.Metro.Controls;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows;

namespace Query_Measurements_Config
{
    public partial class Query_Measurement_Config_Window : MetroWindow
    {
        private void Save_Commands_from_Table_to_Text_File_Click(object sender, RoutedEventArgs e)
        {
            this.Expression_DataGrid.CommitEdit();
            this.Expression_DataGrid.CommitEdit();
            Save_Commands_from_Table_to_Text_File(false);
        }

        private void Save_Commands_Append_from_Table_to_Text_File_Click(object sender, RoutedEventArgs e)
        {
            this.Expression_DataGrid.CommitEdit();
            this.Expression_DataGrid.CommitEdit();
            Save_Commands_from_Table_to_Text_File(true);
        }

        private void Save_Commands_from_Table_to_Text_File(bool Append)
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
                        foreach (SCPI_Command_Data Command in SCPI_Command_Table)
                        {
                            writetext.WriteLine(Command.SCPI_Command_Selected + "╦" + Command.SCPI_Command_Title + "╦" + Command.SCPI_Command + "╦" + Command.Result_Start_Cut_String + "╦" + Command.Result_Stop_Cut_String + "╦" + Command.Measurement_units + "╦" + Command.Query_Delay + "╦" + Command.Text_Color + "╦" + Command.isBackground_Transparent + "╦" + Command.Background_Color);
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

        private void Load_Commands_from_File_to_Table_Click(object sender, RoutedEventArgs e)
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
                    IEnumerable<string> Lines = File.ReadLines(File_Dialog.FileName);
                    Add_to_Table(Lines);
                }
            }
            catch (Exception Ex)
            {
                insert_Log(Ex.Message, 1);
            }
        }

        private void Add_to_Table(IEnumerable<string> Lines)
        {
            foreach (var Line in Lines)
            {
                try
                {
                    string[] Command = Line.Split('╦');

                    bool SCPI_Command_Selected = false;
                    if (Command[0] == "True")
                    {
                        SCPI_Command_Selected = true;
                    }

                    double Query_Delay = 1;
                    bool isQuery_Delay_Valid = double.TryParse(Command[6], out Query_Delay);
                    if (isQuery_Delay_Valid)
                    {
                        if (Query_Delay <= 0)
                        {
                            Query_Delay = 1;
                        }
                    }

                    bool isBackground_Transparent = false;
                    if (Command[8] == "True")
                    {
                        isBackground_Transparent = true;
                    }

                    SCPI_Command_Table.Add(new SCPI_Command_Data(SCPI_Command_Selected, Command[1], Command[2], Command[3], Command[4], Command[5], Query_Delay, Command[7], isBackground_Transparent, Command[9]));
                }
                catch (Exception Ex)
                {
                    insert_Log(Ex.Message, 1);
                    insert_Log("Failed to read an expression from the file.", 1);
                }
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
