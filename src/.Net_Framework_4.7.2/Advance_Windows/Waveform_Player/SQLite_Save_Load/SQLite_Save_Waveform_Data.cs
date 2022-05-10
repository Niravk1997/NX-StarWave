using MahApps.Metro.Controls;
using Microsoft.Win32;
using NX_StarWave;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Threading;
using System.Windows;

namespace Waveform_Player
{
    public partial class Waveform_Player_Window : MetroWindow
    {
        private bool Saving_to_SQLite_DataBase_Queue_InProgress = false;

        private bool OverWrite_Save_SQLite_DataBase = false;

        private void Save_Waveforms_From_Table_to_SQLite_DataBase_Queue_Click(object sender, RoutedEventArgs e)
        {
            if (Saving_to_SQLite_DataBase_Queue_InProgress == false)
            {
                try
                {
                    Saving_to_SQLite_DataBase_Queue_InProgress = true;
                    ThreadPool.QueueUserWorkItem(delegate
                    {
                        foreach (Waveform_Store_Table_Model Waveform in Waveform_Data)
                        {
                            Save_Waveforms_SQLite_DataBase_Queue.Add(Waveform);
                        }
                    }, null);
                }
                catch (Exception Ex)
                {
                    Saving_to_SQLite_DataBase_Queue_InProgress = false;
                    Insert_Log(Ex.Message, 1);
                }
            }
            else
            {
                Insert_Log("Saving is already in progress, wait for it to finish before issuing another save request.", 2);
            }
        }

        private void Overwrite_Save_Waveforms_From_Table_to_SQLite_DataBase_Queue_Click(object sender, RoutedEventArgs e)
        {
            if (Saving_to_SQLite_DataBase_Queue_InProgress == false & Reading_from_SQLite_DataBase_Queue_InProgress == false)
            {
                try
                {
                    OverWrite_Save_SQLite_DataBase = true;
                    Saving_to_SQLite_DataBase_Queue_InProgress = true;
                    ThreadPool.QueueUserWorkItem(delegate
                    {
                        foreach (Waveform_Store_Table_Model Waveform in Waveform_Data)
                        {
                            Save_Waveforms_SQLite_DataBase_Queue.Add(Waveform);
                        }
                    }, null);
                }
                catch (Exception Ex)
                {
                    Saving_to_SQLite_DataBase_Queue_InProgress = false;
                    Insert_Log(Ex.Message, 1);
                }
            }
            else
            {
                Insert_Log("Saving/Loading is in progress, wait for it to finish before issuing another save request.", 2);
            }
        }

        private void Create_New_Database_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (Saving_to_SQLite_DataBase_Queue_InProgress == false & Reading_from_SQLite_DataBase_Queue_InProgress == false)
                {
                    var Save_Data_Text_Window = new SaveFileDialog
                    {
                        InitialDirectory = Communication_Selected.folder_Directory,
                        FileName = "NX_StarWave_WFMs.sqlite",
                        Filter = "SQLite database file (*.sqlite)|*.sqlite",
                        OverwritePrompt = true
                    };

                    if (Save_Data_Text_Window.ShowDialog() is true)
                    {
                        Create_New_Database(Save_Data_Text_Window.FileName, Save_Data_Text_Window.SafeFileName);
                    }
                }
                else
                {
                    Insert_Log("Cannot create new database when data is being read/written from/to current SQlite database.", 1);
                }
            }
            catch (Exception Ex)
            {
                Insert_Log(Ex.Message, 1);
            }
        }

        private void Create_New_Database(string FullPath, string Database)
        {
            SQLiteConnection.CreateFile(FullPath);
            SQLiteConnection Database_Connection = new SQLiteConnection("Data Source=" + FullPath + ";Version=3;");
            Database_Connection.Open();
            SQLiteCommand command = new SQLiteCommand(Waveform_Create_Table, Database_Connection);
            command.ExecuteNonQuery();
            Database_Connection.Close();
            Database_Name = Database;
            Database_FUllPath_Name = FullPath;
            Insert_Log("SQLite Database loaded: " + Database_Name, 5);
            Insert_Log("Full Path: " + Database_FUllPath_Name, 5);
        }

        private void Clear_Database()
        {
            try
            {
                SQLiteConnection SQLite_Connection = new SQLiteConnection("Data Source=" + Database_FUllPath_Name + ";Version=3;");
                SQLiteCommand SQLite_Command = SQLite_Connection.CreateCommand();
                SQLite_Connection.Open();
                SQLiteTransaction SQLite_Transaction = SQLite_Connection.BeginTransaction();
                SQLite_Command.CommandText = "DELETE FROM Waveforms";
                SQLite_Command.ExecuteNonQuery();
                SQLite_Transaction.Commit();
                SQLite_Command.Dispose();
                SQLite_Connection.Close();
                SQLite_Connection.Dispose();
            }
            catch (Exception Ex)
            {
                Insert_Log(Ex.Message, 1);
                Insert_Log("Failed to clear the Database Waveform Table.", 1);
            }
        }

        private void Insert_Data_into_Database(Queue<SQLite_Waveform_Data_Structure> Waveforms)
        {
            if (OverWrite_Save_SQLite_DataBase)
            {
                Clear_Database();
                OverWrite_Save_SQLite_DataBase = false;
            }

            SQLiteConnection SQLite_Connection = new SQLiteConnection("Data Source=" + Database_FUllPath_Name + ";Version=3;");
            SQLiteCommand SQLite_Command = SQLite_Connection.CreateCommand();
            SQLite_Connection.Open();
            SQLiteTransaction SQLite_Transaction = SQLite_Connection.BeginTransaction();

            SQLite_Command.CommandText = "INSERT INTO Waveforms " +
                "(Name, Date_Time, Total_Time, Data_Points, CH1_Valid, CH1_Start_Time, CH1_Stop_Time, CH1_YValues, CH1_Info, CH2_Valid, CH2_Start_Time, CH2_Stop_Time, CH2_YValues, CH2_Info, CH3_Valid, CH3_Start_Time, CH3_Stop_Time, CH3_YValues, CH3_Info, CH4_Valid, CH4_Start_Time, CH4_Stop_Time, CH4_YValues, CH4_Info) "
                + "VALUES (@Name, @Date_Time, @Total_Time, @Data_Points, @CH1_Valid, @CH1_Start_Time, @CH1_Stop_Time, @CH1_YValues, @CH1_Info, @CH2_Valid, @CH2_Start_Time, @CH2_Stop_Time, @CH2_YValues, @CH2_Info, @CH3_Valid, @CH3_Start_Time, @CH3_Stop_Time, @CH3_YValues, @CH3_Info, @CH4_Valid, @CH4_Start_Time, @CH4_Stop_Time, @CH4_YValues, @CH4_Info)";

            SQLite_Command.Parameters.AddWithValue("@Name", "");
            SQLite_Command.Parameters.AddWithValue("@Date_Time", "");
            SQLite_Command.Parameters.AddWithValue("@Total_Time", "");
            SQLite_Command.Parameters.AddWithValue("@Data_Points", "");

            SQLite_Command.Parameters.AddWithValue("@CH1_Valid", "");
            SQLite_Command.Parameters.AddWithValue("@CH1_Start_Time", "");
            SQLite_Command.Parameters.AddWithValue("@CH1_Stop_Time", "");
            SQLite_Command.Parameters.AddWithValue("@CH1_YValues", "");
            SQLite_Command.Parameters.AddWithValue("@CH1_Info", "");

            SQLite_Command.Parameters.AddWithValue("@CH2_Valid", "");
            SQLite_Command.Parameters.AddWithValue("@CH2_Start_Time", "");
            SQLite_Command.Parameters.AddWithValue("@CH2_Stop_Time", "");
            SQLite_Command.Parameters.AddWithValue("@CH2_YValues", "");
            SQLite_Command.Parameters.AddWithValue("@CH2_Info", "");

            SQLite_Command.Parameters.AddWithValue("@CH3_Valid", "");
            SQLite_Command.Parameters.AddWithValue("@CH3_Start_Time", "");
            SQLite_Command.Parameters.AddWithValue("@CH3_Stop_Time", "");
            SQLite_Command.Parameters.AddWithValue("@CH3_YValues", "");
            SQLite_Command.Parameters.AddWithValue("@CH3_Info", "");

            SQLite_Command.Parameters.AddWithValue("@CH4_Valid", "");
            SQLite_Command.Parameters.AddWithValue("@CH4_Start_Time", "");
            SQLite_Command.Parameters.AddWithValue("@CH4_Stop_Time", "");
            SQLite_Command.Parameters.AddWithValue("@CH4_YValues", "");
            SQLite_Command.Parameters.AddWithValue("@CH4_Info", "");

            SQLite_Waveform_Data_Structure Channels_Data;

            int Count = Waveforms.Count;
            for (int i = 0; i < Count; i++)
            {
                Channels_Data = Waveforms.Dequeue();
                Insert_Each_Waveform(Channels_Data.Name, Channels_Data.Date_Time, Channels_Data.Total_Time, Channels_Data.Data_Points
                    , Channels_Data.CH1_Valid, Channels_Data.CH1_Start_Time, Channels_Data.CH1_Stop_Time, Channels_Data.CH1_YValues, Channels_Data.CH1_Info
                    , Channels_Data.CH2_Valid, Channels_Data.CH2_Start_Time, Channels_Data.CH2_Stop_Time, Channels_Data.CH2_YValues, Channels_Data.CH2_Info
                    , Channels_Data.CH3_Valid, Channels_Data.CH3_Start_Time, Channels_Data.CH3_Stop_Time, Channels_Data.CH3_YValues, Channels_Data.CH3_Info
                    , Channels_Data.CH4_Valid, Channels_Data.CH4_Start_Time, Channels_Data.CH4_Stop_Time, Channels_Data.CH4_YValues, Channels_Data.CH4_Info, SQLite_Command);
            }

            SQLite_Transaction.Commit();
            SQLite_Command.Dispose();
            SQLite_Connection.Close();
            SQLite_Connection.Dispose();
        }

        public int Insert_Each_Waveform(string Name, string Date_Time, double Total_Time, int Data_Points, bool CH1_Valid, double CH1_Start_Time, double CH1_Stop_Time, string CH1_YValues, string CH1_Info, bool CH2_Valid, double CH2_Start_Time, double CH2_Stop_Time, string CH2_YValues, string CH2_Info, bool CH3_Valid, double CH3_Start_Time, double CH3_Stop_Time, string CH3_YValues, string CH3_Info, bool CH4_Valid, double CH4_Start_Time, double CH4_Stop_Time, string CH4_YValues, string CH4_Info, SQLiteCommand SQLite_Command)
        {
            SQLite_Command.Parameters["@Name"].Value = Name;
            SQLite_Command.Parameters["@Date_Time"].Value = Date_Time;
            SQLite_Command.Parameters["@Total_Time"].Value = Total_Time;
            SQLite_Command.Parameters["@Data_Points"].Value = Data_Points;

            SQLite_Command.Parameters["@CH1_Valid"].Value = CH1_Valid;
            SQLite_Command.Parameters["@CH1_Start_Time"].Value = CH1_Start_Time;
            SQLite_Command.Parameters["@CH1_Stop_Time"].Value = CH1_Stop_Time;
            SQLite_Command.Parameters["@CH1_YValues"].Value = CH1_YValues;
            SQLite_Command.Parameters["@CH1_Info"].Value = CH1_Info;

            SQLite_Command.Parameters["@CH2_Valid"].Value = CH2_Valid;
            SQLite_Command.Parameters["@CH2_Start_Time"].Value = CH2_Start_Time;
            SQLite_Command.Parameters["@CH2_Stop_Time"].Value = CH2_Stop_Time;
            SQLite_Command.Parameters["@CH2_YValues"].Value = CH2_YValues;
            SQLite_Command.Parameters["@CH2_Info"].Value = CH2_Info;

            SQLite_Command.Parameters["@CH3_Valid"].Value = CH3_Valid;
            SQLite_Command.Parameters["@CH3_Start_Time"].Value = CH3_Start_Time;
            SQLite_Command.Parameters["@CH3_Stop_Time"].Value = CH3_Stop_Time;
            SQLite_Command.Parameters["@CH3_YValues"].Value = CH3_YValues;
            SQLite_Command.Parameters["@CH3_Info"].Value = CH3_Info;

            SQLite_Command.Parameters["@CH4_Valid"].Value = CH4_Valid;
            SQLite_Command.Parameters["@CH4_Start_Time"].Value = CH4_Start_Time;
            SQLite_Command.Parameters["@CH4_Stop_Time"].Value = CH4_Stop_Time;
            SQLite_Command.Parameters["@CH4_YValues"].Value = CH4_YValues;
            SQLite_Command.Parameters["@CH4_Info"].Value = CH4_Info;

            return SQLite_Command.ExecuteNonQuery();
        }
    }
}
