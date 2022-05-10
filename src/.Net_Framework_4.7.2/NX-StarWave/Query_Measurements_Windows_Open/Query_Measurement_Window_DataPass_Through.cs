using MahApps.Metro.Controls;
using System;
using System.Threading.Tasks;

namespace NX_StarWave
{
    public partial class NX_StarWave_Window : MetroWindow
    {
        private async void Query_Measurement_Windows_Data_Passthrough(string Input_Query_String, string Output_Data)
        {
            await Task.Run(() =>
            {
                try
                {
                    string Query_String = Input_Query_String;
                    string Data = Output_Data;
                    string[] Query_Data = Query_String.Split(',');
                    int ID = int.Parse(Query_Data[1]);
                    switch (ID)
                    {
                        case 1:
                            if (Query_Measurement_Window_1 != null & Query_Measurement_Window_1_isOpen)
                            {
                                Query_Measurement_Window_1.SCPI_Measurement_Process(Data);
                            }
                            else
                            {
                                insert_Log("Query Measurement Window 1 is not open, could not pass data to it.", 2);
                            }
                            break;
                        case 2:
                            if (Query_Measurement_Window_2 != null & Query_Measurement_Window_2_isOpen)
                            {
                                Query_Measurement_Window_2.SCPI_Measurement_Process(Data);
                            }
                            else
                            {
                                insert_Log("Query Measurement Window 2 is not open, could not pass data to it.", 2);
                            }
                            break;
                        case 3:
                            if (Query_Measurement_Window_3 != null & Query_Measurement_Window_3_isOpen)
                            {
                                Query_Measurement_Window_3.SCPI_Measurement_Process(Data);
                            }
                            else
                            {
                                insert_Log("Query Measurement Window 3 is not open, could not pass data to it.", 2);
                            }
                            break;
                        case 4:
                            if (Query_Measurement_Window_4 != null & Query_Measurement_Window_4_isOpen)
                            {
                                Query_Measurement_Window_4.SCPI_Measurement_Process(Data);
                            }
                            else
                            {
                                insert_Log("Query Measurement Window 4 is not open, could not pass data to it.", 2);
                            }
                            break;
                        case 5:
                            if (Query_Measurement_Window_5 != null & Query_Measurement_Window_5_isOpen)
                            {
                                Query_Measurement_Window_5.SCPI_Measurement_Process(Data);
                            }
                            else
                            {
                                insert_Log("Query Measurement Window 5 is not open, could not pass data to it.", 2);
                            }
                            break;
                        case 6:
                            if (Query_Measurement_Window_6 != null & Query_Measurement_Window_6_isOpen)
                            {
                                Query_Measurement_Window_6.SCPI_Measurement_Process(Data);
                            }
                            else
                            {
                                insert_Log("Query Measurement Window 6 is not open, could not pass data to it.", 2);
                            }
                            break;
                        case 7:
                            if (Query_Measurement_Window_7 != null & Query_Measurement_Window_7_isOpen)
                            {
                                Query_Measurement_Window_7.SCPI_Measurement_Process(Data);
                            }
                            else
                            {
                                insert_Log("Query Measurement Window 7 is not open, could not pass data to it.", 2);
                            }
                            break;
                        case 8:
                            if (Query_Measurement_Window_8 != null & Query_Measurement_Window_8_isOpen)
                            {
                                Query_Measurement_Window_8.SCPI_Measurement_Process(Data);
                            }
                            else
                            {
                                insert_Log("Query Measurement Window 8 is not open, could not pass data to it.", 2);
                            }
                            break;
                        case 9:
                            if (Query_Measurement_Window_9 != null & Query_Measurement_Window_9_isOpen)
                            {
                                Query_Measurement_Window_9.SCPI_Measurement_Process(Data);
                            }
                            else
                            {
                                insert_Log("Query Measurement Window 9 is not open, could not pass data to it.", 2);
                            }
                            break;
                        case 10:
                            if (Query_Measurement_Window_10 != null & Query_Measurement_Window_10_isOpen)
                            {
                                Query_Measurement_Window_10.SCPI_Measurement_Process(Data);
                            }
                            else
                            {
                                insert_Log("Query Measurement Window 10 is not open, could not pass data to it.", 2);
                            }
                            break;
                        default:
                            break;
                    }
                }
                catch (Exception Ex)
                {
                    insert_Log(Ex.Message, 2);
                    insert_Log("Query Measurement Window DataPassthrough Error.", 2);
                }
            });
        }
    }
}
