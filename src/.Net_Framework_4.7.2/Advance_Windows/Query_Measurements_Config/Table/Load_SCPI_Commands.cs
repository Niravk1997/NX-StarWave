using MahApps.Metro.Controls;
using System;
using System.Windows.Controls;
using System.Windows.Input;

namespace Query_Measurements_Config
{
    public partial class Query_Measurement_Config_Window : MetroWindow
    {
        private void SCPI_Command_DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (Auto_Load)
            {
                try
                {
                    if (Selected_SCPI_Command_Data != null)
                    {
                        Query_Measurement_Window_Title = Selected_SCPI_Command_Data.SCPI_Command_Title;
                        Query_SCPI_Command = Selected_SCPI_Command_Data.SCPI_Command;
                        Query_Result_Start_Cut_String = Selected_SCPI_Command_Data.Result_Start_Cut_String;
                        Query_Result_Stop_Cut_String = Selected_SCPI_Command_Data.Result_Stop_Cut_String;
                        Query_SCPI_Measurement_Units = Selected_SCPI_Command_Data.Measurement_units;
                        Query_SCPI_Delay = Selected_SCPI_Command_Data.Query_Delay;
                        Query_Measurement_Window_Label_Color = Selected_SCPI_Command_Data.Text_Color;
                        Query_Measurement_Window_isBackground_Transparent = Selected_SCPI_Command_Data.isBackground_Transparent;
                        Query_Measurement_Window_Background_Color = Selected_SCPI_Command_Data.Background_Color;
                    }
                }
                catch (Exception Ex)
                {
                    insert_Log(Ex.Message, 1);
                }
            }
        }

        private void SCPI_Command_Load_Selected_Mouse_Double_Click(object sender, MouseButtonEventArgs e)
        {
            try
            {
                if (Selected_SCPI_Command_Data != null)
                {
                    Query_Measurement_Window_Title = Selected_SCPI_Command_Data.SCPI_Command_Title;
                    Query_SCPI_Command = Selected_SCPI_Command_Data.SCPI_Command;

                    Query_SCPI_Measurement_Units = Selected_SCPI_Command_Data.Measurement_units;
                    Query_SCPI_Delay = Selected_SCPI_Command_Data.Query_Delay;
                    Query_Measurement_Window_Label_Color = Selected_SCPI_Command_Data.Text_Color;
                    Query_Measurement_Window_isBackground_Transparent = Selected_SCPI_Command_Data.isBackground_Transparent;
                    Query_Measurement_Window_Background_Color = Selected_SCPI_Command_Data.Background_Color;
                }
            }
            catch (Exception Ex)
            {
                insert_Log(Ex.Message, 1);
            }
        }
    }
}
