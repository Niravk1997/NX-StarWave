using MahApps.Metro.Controls;
using NX_StarWave;
using System;
using System.Windows;
using System.Windows.Media;

namespace Query_Measurements_Config
{
    public partial class Query_Measurement_Config_Window : MetroWindow
    {
        private bool isBusy_Process_Query_measurement_Windows = false;

        private void Open_Query_Measurement_Click(object sender, RoutedEventArgs e)
        {
            if (isBusy_Process_Query_measurement_Windows == false)
            {
                isBusy_Process_Query_measurement_Windows = true;
                (bool isValid, string Window_Title, string SCPI_Command, string Output_Result_String_Cut_Start, string Output_Result_String_Cut_Stop, string Measurement_Units, double SCPI_Send_Delay, string Label_Colour, string Background_Color, bool isBackground_Transparent) = Query_Measurement_Window_Create_Parameters();
                if (isValid)
                {
                    if (Auto_Save)
                    {
                        try
                        {
                            Save_Expression_to_Table();
                        }
                        catch (Exception Ex)
                        {
                            insert_Log(Ex.Message, 2);
                            insert_Log("Could not Auto Save to the SCPI Commands Table.", 2);
                        }
                    }
                    ((NX_StarWave_Window)Application.Current.MainWindow).Open_Query_Measurement_Windows(Window_Title, SCPI_Command, Output_Result_String_Cut_Start, Output_Result_String_Cut_Stop, Measurement_Units, SCPI_Send_Delay, Label_Colour, Background_Color, isBackground_Transparent);
                    if (Auto_Clear)
                    {
                        Clear_Expression();
                    }
                }
                else
                {
                    insert_Log("Query Measurement Parameters are not valid.", 2);
                }
                isBusy_Process_Query_measurement_Windows = false;
            }
        }

        private (bool, string, string, string, string, string, double, string, string, bool) Query_Measurement_Window_Create_Parameters()
        {
            try
            {
                Brush Labels_Color = new SolidColorBrush((Color)ColorConverter.ConvertFromString(Query_Measurement_Window_Label_Color));
                Brush Background_Color = new SolidColorBrush((Color)ColorConverter.ConvertFromString(Query_Measurement_Window_Background_Color));

                if (Query_SCPI_Command == "" || Query_SCPI_Command == string.Empty)
                {
                    return (false, null, null, null, null, null, 0, null, null, false);
                }

                if (Query_SCPI_Delay <= 0)
                {
                    return (false, null, null, null, null, null, 0, null, null, false);
                }

                return (true, Query_Measurement_Window_Title, Query_SCPI_Command, Query_Result_Start_Cut_String, Query_Result_Stop_Cut_String, Query_SCPI_Measurement_Units, Query_SCPI_Delay, Query_Measurement_Window_Label_Color, Query_Measurement_Window_Background_Color, Query_Measurement_Window_isBackground_Transparent);
            }
            catch (Exception Ex)
            {
                insert_Log(Ex.Message, 1);
                insert_Log("Query Measurement invalid parameters.", 1);
                return (false, null, null, null, null, null, 0, null, null, false);
            }
        }
    }
}
