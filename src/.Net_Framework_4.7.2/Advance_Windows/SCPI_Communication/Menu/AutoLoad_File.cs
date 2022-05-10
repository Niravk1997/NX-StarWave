using MahApps.Metro.Controls;
using System;
using System.Collections.Generic;
using System.IO;

namespace SCPI_Communication
{
    public partial class SCPI_Communication_Window : MetroWindow
    {
        private string FileName = "NX_StarWave_User_SCPI_Expressions_List.config";
        private bool AutoLoad_isBusy = false;

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
                                for (int i = 0; i < SCPI_Expression_Table.Count; i++)
                                {
                                    string Expression_Data = SCPI_Expression_Table[i].SCPI_Expression_Selected + "╦" + SCPI_Expression_Table[i].SCPI_Expression_Description + "╦" + SCPI_Expression_Table[i].SCPI_Expression;
                                    writetext.WriteLine(Expression_Data);
                                }
                            }
                            AutoLoad_isBusy = false;
                        }
                        catch (Exception Ex)
                        {
                            AutoLoad_isBusy = false;
                            insert_Log(Ex.Message, 1);
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
