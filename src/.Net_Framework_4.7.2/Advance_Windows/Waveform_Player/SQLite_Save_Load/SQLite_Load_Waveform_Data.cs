using MahApps.Metro.Controls;
using Microsoft.Win32;
using NX_StarWave;
using NX_StarWave.Waveform_Model_Classes;
using System;
using System.Data.SQLite;
using System.Linq;
using System.Windows;

namespace Waveform_Player
{
    public partial class Waveform_Player_Window : MetroWindow
    {
        private bool Reading_from_SQLite_DataBase_Queue_InProgress = false;

        private void Load_SQLite_Database_Click(object sender, RoutedEventArgs e)
        {
            if (Saving_to_SQLite_DataBase_Queue_InProgress == false & Reading_from_SQLite_DataBase_Queue_InProgress == false)
            {
                try
                {
                    OpenFileDialog Open_Data_Text_Window = new OpenFileDialog
                    {
                        InitialDirectory = Communication_Selected.folder_Directory,
                        FileName = "NX_StarWave_WFMs.sqlite",
                        Filter = "SQLite database file (*.sqlite)|*.sqlite"
                    };

                    if (Open_Data_Text_Window.ShowDialog() is true)
                    {
                        Test_SQLite_Connection(Open_Data_Text_Window.FileName);
                        Database_Name = Open_Data_Text_Window.SafeFileName;
                        Database_FUllPath_Name = Open_Data_Text_Window.FileName;
                    }
                }
                catch (Exception Ex)
                {
                    Insert_Log(Ex.Message, 1);
                }
            }
            else
            {
                Insert_Log("Cannot load another database while read/write operations are being performed on the currently loaded database.", 2);
            }
        }

        private void Read_Data_from_SQLite_Database_Click(object sender, RoutedEventArgs e)
        {
            if (Reading_from_SQLite_DataBase_Queue_InProgress == false)
            {
                try
                {
                    Reading_from_SQLite_DataBase_Queue_InProgress = true;
                    SQLite_Read_Data_Process.Start();
                }
                catch (Exception Ex)
                {
                    Insert_Log(Ex.Message, 1);
                    Reading_from_SQLite_DataBase_Queue_InProgress = false;
                }
            }
            else
            {
                Insert_Log("Reading from SQlite database is already in progress, wait for it to finish before issuing another read request.", 2);
            }
        }

        private void Read_Data_from_SQLite_Database(object sender, EventArgs e)
        {
            try
            {
                SQLite_Databse_Read_Write_Status = Color_Status_Active;
                SQLiteConnection SQLite_Connection = new SQLiteConnection("Data Source=" + Database_FUllPath_Name + ";Version=3;");
                SQLite_Connection.Open();

                string Get_all_Waveforms_Command = "SELECT * FROM Waveforms";
                SQLiteCommand command = new SQLiteCommand(Get_all_Waveforms_Command, SQLite_Connection);

                SQLiteDataReader SQlite_Read_Waveform = command.ExecuteReader();

                Waveform_Store_Table_Model Waveforms;

                Channel_Waveform_Data CH1_Data;
                Channel_Waveform_Data CH2_Data;
                Channel_Waveform_Data CH3_Data;
                Channel_Waveform_Data CH4_Data;

                string Name = "";
                string DateTime = "";

                double Total_Time = 0;
                int Data_points = 0;

                bool CH1_Valid = false;
                double[] CH1_XValues = new double[0];
                double[] CH1_YValues = new double[0];
                double CH1_Start_Time = 0;
                double CH1_Stop_Time = 0;
                string CH1_Channel_info;

                bool CH2_Valid = false;
                double[] CH2_XValues = new double[0];
                double[] CH2_YValues = new double[0];
                double CH2_Start_Time = 0;
                double CH2_Stop_Time = 0;
                string CH2_Channel_info;

                bool CH3_Valid = false;
                double[] CH3_XValues = new double[0];
                double[] CH3_YValues = new double[0];
                double CH3_Start_Time = 0;
                double CH3_Stop_Time = 0;
                string CH3_Channel_info;

                bool CH4_Valid = false;
                double[] CH4_XValues = new double[0];
                double[] CH4_YValues = new double[0];
                double CH4_Start_Time = 0;
                double CH4_Stop_Time = 0;
                string CH4_Channel_info;

                while (SQlite_Read_Waveform.Read())
                {
                    Name = SQlite_Read_Waveform.GetString(0);
                    DateTime = SQlite_Read_Waveform.GetString(1);
                    Total_Time = SQlite_Read_Waveform.GetDouble(2);
                    Data_points = SQlite_Read_Waveform.GetInt32(3);

                    if (SQlite_Read_Waveform.GetString(4) == "True")
                    {
                        CH1_Valid = true;
                        CH1_Start_Time = SQlite_Read_Waveform.GetDouble(5);
                        CH1_Stop_Time = SQlite_Read_Waveform.GetDouble(6);
                        CH1_XValues = Functions.Linspace(CH1_Start_Time, CH1_Stop_Time, Data_points);
                        CH1_YValues = SQlite_Read_Waveform.GetString(7).Split(',').Select(double.Parse).ToArray();
                        CH1_Channel_info = SQlite_Read_Waveform.GetString(8);
                    }
                    else
                    {
                        CH1_Valid = false;
                        CH1_Start_Time = 0;
                        CH1_Stop_Time = 0;
                        CH1_XValues = new double[0];
                        CH1_YValues = new double[0];
                        CH1_Channel_info = "Empty";
                    }
                    CH1_Data = new Channel_Waveform_Data(CH1_Valid, CH1_XValues, CH1_YValues, Total_Time, CH1_Start_Time, CH1_Stop_Time, Data_points, CH1_Channel_info);

                    if (SQlite_Read_Waveform.GetString(9) == "True")
                    {
                        CH2_Valid = true;
                        CH2_Start_Time = SQlite_Read_Waveform.GetDouble(10);
                        CH2_Stop_Time = SQlite_Read_Waveform.GetDouble(11);
                        CH2_XValues = Functions.Linspace(CH2_Start_Time, CH2_Stop_Time, Data_points);
                        CH2_YValues = SQlite_Read_Waveform.GetString(12).Split(',').Select(double.Parse).ToArray();
                        CH2_Channel_info = SQlite_Read_Waveform.GetString(13);
                    }
                    else
                    {
                        CH2_Valid = false;
                        CH2_Start_Time = 0;
                        CH2_Stop_Time = 0;
                        CH2_XValues = new double[0];
                        CH2_YValues = new double[0];
                        CH2_Channel_info = "Empty";
                    }
                    CH2_Data = new Channel_Waveform_Data(CH2_Valid, CH2_XValues, CH2_YValues, Total_Time, CH2_Start_Time, CH2_Stop_Time, Data_points, CH2_Channel_info);

                    if (SQlite_Read_Waveform.GetString(14) == "True")
                    {
                        CH3_Valid = true;
                        CH3_Start_Time = SQlite_Read_Waveform.GetDouble(15);
                        CH3_Stop_Time = SQlite_Read_Waveform.GetDouble(16);
                        CH3_XValues = Functions.Linspace(CH3_Start_Time, CH3_Stop_Time, Data_points);
                        CH3_YValues = SQlite_Read_Waveform.GetString(17).Split(',').Select(double.Parse).ToArray();
                        CH3_Channel_info = SQlite_Read_Waveform.GetString(18);
                    }
                    else
                    {
                        CH3_Valid = false;
                        CH3_Start_Time = 0;
                        CH3_Stop_Time = 0;
                        CH3_XValues = new double[0];
                        CH3_YValues = new double[0];
                        CH3_Channel_info = "Empty";
                    }
                    CH3_Data = new Channel_Waveform_Data(CH3_Valid, CH3_XValues, CH3_YValues, Total_Time, CH3_Start_Time, CH3_Stop_Time, Data_points, CH3_Channel_info);

                    if (SQlite_Read_Waveform.GetString(19) == "True")
                    {
                        CH4_Valid = true;
                        CH4_Start_Time = SQlite_Read_Waveform.GetDouble(20);
                        CH4_Stop_Time = SQlite_Read_Waveform.GetDouble(21);
                        CH4_XValues = Functions.Linspace(CH4_Start_Time, CH4_Stop_Time, Data_points);
                        CH4_YValues = SQlite_Read_Waveform.GetString(22).Split(',').Select(double.Parse).ToArray();
                        CH4_Channel_info = SQlite_Read_Waveform.GetString(23);
                    }
                    else
                    {
                        CH4_Valid = false;
                        CH4_Start_Time = 0;
                        CH4_Stop_Time = 0;
                        CH4_XValues = new double[0];
                        CH4_YValues = new double[0];
                        CH4_Channel_info = "Empty";
                    }
                    CH4_Data = new Channel_Waveform_Data(CH4_Valid, CH4_XValues, CH4_YValues, Total_Time, CH4_Start_Time, CH4_Stop_Time, Data_points, CH4_Channel_info);

                    Waveforms = new Waveform_Store_Table_Model(Name, DateTime, CH1_Data, CH2_Data, CH3_Data, CH4_Data);
                    Read_Waveforms_SQLite_DataBase_Queue.Add(Waveforms);
                }

                SQlite_Read_Waveform.Close();
                command.Dispose();
                SQLite_Connection.Close();
                SQLite_Connection.Dispose();
                Reading_from_SQLite_DataBase_Queue_InProgress = false;
                SQLite_Databse_Read_Write_Status = Color_Status_Idle;
            }
            catch (Exception Ex)
            {
                Insert_Log(Ex.Message, 1);
                Reading_from_SQLite_DataBase_Queue_InProgress = false;
                SQLite_Databse_Read_Write_Status = Color_Status_Idle;
            }
        }
    }
}
