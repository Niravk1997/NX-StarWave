using MahApps.Metro.Controls;
using System;
using System.Collections.Generic;
using System.IO;

namespace Query_Measurements_Config
{
    public partial class Query_Measurement_Config_Window : MetroWindow
    {
        private string FileName = "NX_StarWave_User_Query_Measurements_List.config";
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
                        Add_to_Table(Lines);
                        AutoLoad_isBusy = false;
                        insert_Log("Auto Loaded SCPI Commands File.", 0);
                    }
                    else
                    {
                        if (AutoLoad_isBusy)
                        {
                            insert_Log("Auto Load is busy. Please Wait.", 2);
                        }
                        else
                        {
                            insert_Log("Auto Load SCPI Commands File failed. Could not find the file.", 2);
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
                                foreach (SCPI_Command_Data Command in SCPI_Command_Table)
                                {
                                    writetext.WriteLine(Command.SCPI_Command_Selected + "╦" + Command.SCPI_Command_Title + "╦" + Command.SCPI_Command + "╦" + Command.Result_Start_Cut_String + "╦" + Command.Result_Stop_Cut_String + "╦" + Command.Measurement_units + "╦" + Command.Query_Delay + "╦" + Command.Text_Color + "╦" + Command.isBackground_Transparent + "╦" + Command.Background_Color);
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
                insert_Log("Could not Quick Save SCPI Commands.", 1);
            }
        }
    }
}
