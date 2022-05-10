using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MahApps.Metro.Controls;

namespace Waveform_Web_Server
{
    public partial class Web_Server_MainWindow : MetroWindow
    {
        private string FileName = "NX_StarWave_Web_Server.config";

        private bool AutoLoad_isFile_Exists()
        {
            return File.Exists(NX_StarWave.Communication_Selected.folder_Directory + FileName);
        }

        private void AutoLoad_Load_Web_Server_Config_File()
        {
            try
            {
                Dispatcher.BeginInvoke((Action)(() =>
                {
                    try
                    {
                        if (AutoLoad_isFile_Exists())
                        {
                            string[] Web_Server_Config = File.ReadLines(NX_StarWave.Communication_Selected.folder_Directory + FileName).First().Split(',');
                            IP_Address = Web_Server_Config[0];
                            int TCP_Port = int.Parse(Web_Server_Config[1]);
                            insert_Log("Auto Loaded Web Server Config File.", 0);
                        }
                    }
                    catch (Exception Ex)
                    {
                        insert_Log(Ex.Message, 1);
                        insert_Log("Failed to read Web Server Config file.", 1);
                    }
                }));
            }
            catch (Exception Ex)
            {
                insert_Log(Ex.Message, 1);
            }
        }

        private void AutoSave_Web_Server_Config()
        {
            try
            {
                Dispatcher.BeginInvoke((Action)(() =>
                {
                    try
                    {
                        using (TextWriter writetext = new StreamWriter(NX_StarWave.Communication_Selected.folder_Directory + FileName))
                        {
                            writetext.WriteLine(IP_Address + "," + Port);
                        }
                    }
                    catch (Exception Ex)
                    {
                        insert_Log(Ex.Message, 1);
                        insert_Log("Could not Save Web Server Config File.", 1);
                    }
                }));
            }
            catch (Exception)
            {

            }
        }
    }
}
