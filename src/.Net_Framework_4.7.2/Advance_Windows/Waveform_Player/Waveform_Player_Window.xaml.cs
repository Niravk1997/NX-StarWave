using MahApps.Metro.Controls;
using NX_StarWave;
using NX_StarWave.Misc;
using NX_StarWave.Waveform_Model_Classes;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Threading;

namespace Waveform_Player
{
    public partial class Waveform_Player_Window : MetroWindow
    {
        //Waveform data is initially stored here unitl it is removed, processed and stored inside the table
        public BlockingCollection<All_Channels_Data> All_Channels_Data_Queue = new BlockingCollection<All_Channels_Data>();

        //Waveforms placed inside this queue will be processed and saved into an SQLite database
        private BlockingCollection<Waveform_Store_Table_Model> Save_Waveforms_SQLite_DataBase_Queue = new BlockingCollection<Waveform_Store_Table_Model>();

        //Waveforms placed inside this queue wiil be processed and will be inserted into any graph window that is opened.
        private BlockingCollection<All_Channels_Data> Insert_Waveforms_Graph_Windows_Queue = new BlockingCollection<All_Channels_Data>();

        //Wavefroms read from an SQLite database will be stored here, for further processing
        private BlockingCollection<Waveform_Store_Table_Model> Read_Waveforms_SQLite_DataBase_Queue = new BlockingCollection<Waveform_Store_Table_Model>();

        //These timers periodically check for any data inserted into Data_Queue, and processs it and insert it into the graph
        private System.Timers.Timer Waveform_Data_Process;
        private System.Timers.Timer SQLite_Data_Process;
        private System.Timers.Timer SQLite_Read_Data_Process;

        SynchronizationContext SynchronizeContext = SynchronizationContext.Current;

        private Helpful_Functions Functions = new Helpful_Functions();

        private string Database_Name = "NX_StarWave_WFMs.sqlite";
        private string Database_FUllPath_Name;

        public Waveform_Player_Window()
        {
            InitializeComponent();
            DataContext = this;
            Initialize_Timers();
            Initialize_Waveform_Play_Mode_Timer();
            Initialize_Brush_Colors();
            Database_FUllPath_Name = Communication_Selected.folder_Directory + Database_Name;
            Test_SQLite_Connection(Database_FUllPath_Name);
        }

        private void Test_SQLite_Connection(string Database_FUllPath_Name)
        {
            try
            {
                SQLiteConnection SQLite_Connection = new SQLiteConnection("Data Source=" + Database_FUllPath_Name + ";Version=3;");
                SQLite_Connection.Open();

                string Get_Data_Command = "SELECT name, sql FROM sqlite_master WHERE type = 'table' ORDER BY name";
                SQLiteCommand command = new SQLiteCommand(Get_Data_Command, SQLite_Connection);

                SQLiteDataReader SQlite_Read_Data = command.ExecuteReader();
                if (SQlite_Read_Data.Read())
                {
                    Insert_Log(SQlite_Read_Data.GetString(1), 0);
                }
                else
                {
                    command = new SQLiteCommand(Waveform_Create_Table, SQLite_Connection);
                    command.ExecuteNonQuery();
                    Insert_Log("SQLite Database Waveform Table created.", 5);
                }

                SQlite_Read_Data.Close();
                command.Dispose();
                SQLite_Connection.Close();
                SQLite_Connection.Dispose();

                SQLite_Databse_Connect_Status = Color_Status_Success;
                Insert_Log("SQLite Database loaded: " + Database_Name, 5);
                Insert_Log("Full Path: " + Database_FUllPath_Name, 5);
                Insert_Log("SQLite Database Connected.", 0);
            }
            catch (Exception Ex)
            {
                Insert_Log(Ex.Message, 1);
                SQLite_Databse_Connect_Status = Color_Status_Error;
            }
        }

        private void Initialize_Timers()
        {
            Waveform_Data_Process = new System.Timers.Timer(50);
            Waveform_Data_Process.Elapsed += Waveform_Data_Process_Graph;
            Waveform_Data_Process.AutoReset = false;
            Waveform_Data_Process.Enabled = true;

            SQLite_Data_Process = new System.Timers.Timer(1000);
            SQLite_Data_Process.Elapsed += SQLite_Data_Process_Database;
            SQLite_Data_Process.AutoReset = false;
            SQLite_Data_Process.Enabled = true;

            SQLite_Read_Data_Process = new System.Timers.Timer(1000);
            SQLite_Read_Data_Process.Elapsed += Read_Data_from_SQLite_Database;
            SQLite_Read_Data_Process.AutoReset = false;
            SQLite_Read_Data_Process.Enabled = false;
        }

        private void Waveform_Data_Process_Graph(object sender, EventArgs e)
        {
            int All_Channels_Data_Queue_Count = All_Channels_Data_Queue.Count;
            int Insert_Waveforms_Graph_Windows_Queue_Count = Insert_Waveforms_Graph_Windows_Queue.Count;
            int Read_Waveforms_SQLite_DataBase_Queue_Count = Read_Waveforms_SQLite_DataBase_Queue.Count;

            while (All_Channels_Data_Queue_Count > 0)
            {
                All_Channels_Data Channels_Data = All_Channels_Data_Queue.Take();
                SynchronizeContext.Send(x => Waveform_Data.Add(new Waveform_Store_Table_Model(Waveform_Name, DateTime.Now.ToString(), Channels_Data.CH1, Channels_Data.CH2, Channels_Data.CH3, Channels_Data.CH4)), null);

                if (SQLite_AutoSave)
                {
                    Save_Waveforms_SQLite_DataBase_Queue.Add(new Waveform_Store_Table_Model(Waveform_Name, DateTime.Now.ToString(), Channels_Data.CH1, Channels_Data.CH2, Channels_Data.CH3, Channels_Data.CH4));
                }

                All_Channels_Data_Queue_Count--;
            }
            while (Read_Waveforms_SQLite_DataBase_Queue_Count > 0)
            {
                SynchronizeContext.Send(x => Waveform_Data.Add(Read_Waveforms_SQLite_DataBase_Queue.Take()), null);
                Read_Waveforms_SQLite_DataBase_Queue_Count--;
            }
            while (Insert_Waveforms_Graph_Windows_Queue_Count > 0)
            {
                All_Channels_Data Channels_Data = Insert_Waveforms_Graph_Windows_Queue.Take();
                Graphs_Windows_Open_DataPassthrough(Channels_Data.CH1, Channels_Data.CH2, Channels_Data.CH3, Channels_Data.CH4);
                Insert_Waveforms_Graph_Windows_Queue_Count--;
            }
            Waveform_Data_Process.Enabled = true;
        }

        private void Graphs_Windows_Open_DataPassthrough(Channel_Waveform_Data CH1_Data, Channel_Waveform_Data CH2_Data, Channel_Waveform_Data CH3_Data, Channel_Waveform_Data CH4_Data)
        {
            this.Dispatcher.Invoke(() =>
            {
                ((NX_StarWave_Window)System.Windows.Application.Current.MainWindow).insert_Graph_Data_Passthrough_from_SQLTable(CH1_Data, CH2_Data, CH3_Data, CH4_Data);
            });
        }

        private void SQLite_Data_Process_Database(object sender, EventArgs e)
        {
            int Save_Waveforms_SQLite_DataBase_Queue_Count = Save_Waveforms_SQLite_DataBase_Queue.Count;
            if (Save_Waveforms_SQLite_DataBase_Queue_Count > 0)
            {
                SQLite_Databse_Read_Write_Status = Color_Status_Active;
                Queue<SQLite_Waveform_Data_Structure> Waveforms = new Queue<SQLite_Waveform_Data_Structure>();

                double Total_Time = 0;
                int Data_Points = 0;

                bool CH1_Valid;
                double CH1_Start_Time;
                double CH1_Stop_Time;
                string CH1_YValues;
                string CH1_Info;

                bool CH2_Valid;
                double CH2_Start_Time;
                double CH2_Stop_Time;
                string CH2_YValues;
                string CH2_Info;

                bool CH3_Valid;
                double CH3_Start_Time;
                double CH3_Stop_Time;
                string CH3_YValues;
                string CH3_Info;

                bool CH4_Valid;
                double CH4_Start_Time;
                double CH4_Stop_Time;
                string CH4_YValues;
                string CH4_Info;

                Waveform_Store_Table_Model Channels_Data;

                while (Save_Waveforms_SQLite_DataBase_Queue_Count > 0)
                {
                    Channels_Data = Save_Waveforms_SQLite_DataBase_Queue.Take();

                    Total_Time = 0;
                    Data_Points = 0;

                    if (Channels_Data.CH4_Valid)
                    {
                        Total_Time = Channels_Data.CH4.Total_Time;
                        Data_Points = Channels_Data.CH4.Data_Points;
                        CH4_Valid = true;
                        CH4_Start_Time = Channels_Data.CH4.Start_Time;
                        CH4_Stop_Time = Channels_Data.CH4.Stop_Time;
                        CH4_YValues = string.Join(",", Channels_Data.CH4.Y_Data);
                        CH4_Info = Channels_Data.CH4.Channel_Info;
                    }
                    else
                    {
                        CH4_Valid = false;
                        CH4_Start_Time = 0;
                        CH4_Stop_Time = 0;
                        CH4_YValues = "";
                        CH4_Info = "Empty";
                    }

                    if (Channels_Data.CH3_Valid)
                    {
                        Total_Time = Channels_Data.CH3.Total_Time;
                        Data_Points = Channels_Data.CH3.Data_Points;
                        CH3_Valid = true;
                        CH3_Start_Time = Channels_Data.CH3.Start_Time;
                        CH3_Stop_Time = Channels_Data.CH3.Stop_Time;
                        CH3_YValues = string.Join(",", Channels_Data.CH3.Y_Data);
                        CH3_Info = Channels_Data.CH3.Channel_Info;
                    }
                    else
                    {
                        CH3_Valid = false;
                        CH3_Start_Time = 0;
                        CH3_Stop_Time = 0;
                        CH3_YValues = "";
                        CH3_Info = "Empty";
                    }

                    if (Channels_Data.CH2_Valid)
                    {
                        Total_Time = Channels_Data.CH2.Total_Time;
                        Data_Points = Channels_Data.CH2.Data_Points;
                        CH2_Valid = true;
                        CH2_Start_Time = Channels_Data.CH2.Start_Time;
                        CH2_Stop_Time = Channels_Data.CH2.Stop_Time;
                        CH2_YValues = string.Join(",", Channels_Data.CH2.Y_Data);
                        CH2_Info = Channels_Data.CH2.Channel_Info;
                    }
                    else
                    {
                        CH2_Valid = false;
                        CH2_Start_Time = 0;
                        CH2_Stop_Time = 0;
                        CH2_YValues = "";
                        CH2_Info = "Empty";
                    }

                    if (Channels_Data.CH1_Valid)
                    {
                        Total_Time = Channels_Data.CH1.Total_Time;
                        Data_Points = Channels_Data.CH1.Data_Points;
                        CH1_Valid = true;
                        CH1_Start_Time = Channels_Data.CH1.Start_Time;
                        CH1_Stop_Time = Channels_Data.CH1.Stop_Time;
                        CH1_YValues = string.Join(",", Channels_Data.CH1.Y_Data);
                        CH1_Info = Channels_Data.CH1.Channel_Info;
                    }
                    else
                    {
                        CH1_Valid = false;
                        CH1_Start_Time = 0;
                        CH1_Stop_Time = 0;
                        CH1_YValues = "";
                        CH1_Info = "Empty";
                    }

                    Waveforms.Enqueue(new SQLite_Waveform_Data_Structure(Channels_Data.Name, Channels_Data.Date_Time, Total_Time, Data_Points, CH1_Valid, CH1_Start_Time, CH1_Stop_Time, CH1_YValues, CH1_Info, CH2_Valid, CH2_Start_Time, CH2_Stop_Time, CH2_YValues, CH2_Info, CH3_Valid, CH3_Start_Time, CH3_Stop_Time, CH3_YValues, CH3_Info, CH4_Valid, CH4_Start_Time, CH4_Stop_Time, CH4_YValues, CH4_Info));
                    Save_Waveforms_SQLite_DataBase_Queue_Count--;
                }
                try
                {
                    Insert_Data_into_Database(Waveforms);
                    Saving_to_SQLite_DataBase_Queue_InProgress = false;
                    SQLite_Databse_Read_Write_Status = Color_Status_Idle;
                }
                catch (Exception Ex)
                {
                    Insert_Log(Ex.Message, 1);
                    Saving_to_SQLite_DataBase_Queue_InProgress = false;
                    SQLite_Databse_Read_Write_Status = Color_Status_Idle;
                }
            }
            SQLite_Data_Process.Enabled = true;
        }
    }
}
