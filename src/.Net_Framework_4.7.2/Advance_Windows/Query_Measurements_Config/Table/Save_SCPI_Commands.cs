using MahApps.Metro.Controls;
using System;
using System.Windows;
using System.Windows.Data;

namespace Query_Measurements_Config
{
    public partial class Query_Measurement_Config_Window : MetroWindow
    {
        private void Save_Expression_to_Table_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Save_Expression_to_Table();
            }
            catch (Exception Ex)
            {
                insert_Log(Ex.Message, 1);
            }
        }

        private void Save_Expression_to_Table()
        {
            SCPI_Command_Table.Add(new SCPI_Command_Data(false, Query_Measurement_Window_Title, Query_SCPI_Command, Query_Result_Start_Cut_String, Query_Result_Stop_Cut_String, Query_SCPI_Measurement_Units, Query_SCPI_Delay, Query_Measurement_Window_Label_Color, Query_Measurement_Window_isBackground_Transparent, Query_Measurement_Window_Background_Color));
        }

        private void Update_Selected_Expression_from_Table_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (Selected_SCPI_Command_Data != null)
                {
                    Selected_SCPI_Command_Data.SCPI_Command_Title = Query_Measurement_Window_Title;
                    Selected_SCPI_Command_Data.SCPI_Command = Query_SCPI_Command;
                    Selected_SCPI_Command_Data.Result_Start_Cut_String = Query_Result_Start_Cut_String;
                    Selected_SCPI_Command_Data.Result_Stop_Cut_String = Query_Result_Stop_Cut_String;
                    Selected_SCPI_Command_Data.Measurement_units = Query_SCPI_Measurement_Units;
                    Selected_SCPI_Command_Data.Query_Delay = Query_SCPI_Delay;
                    Selected_SCPI_Command_Data.Text_Color = Query_Measurement_Window_Label_Color;
                    Selected_SCPI_Command_Data.isBackground_Transparent = Query_Measurement_Window_isBackground_Transparent;
                    Selected_SCPI_Command_Data.Background_Color = Query_Measurement_Window_Background_Color;
                    CollectionViewSource.GetDefaultView(SCPI_Command_Table).Refresh();
                }
            }
            catch (Exception Ex)
            {
                insert_Log(Ex.Message, 1);
            }
        }

        private void Clear_Expression_Click(object sender, RoutedEventArgs e)
        {
            Clear_Expression();
        }

        private void Clear_Expression()
        {
            Query_Measurement_Window_Title = "";
            Query_SCPI_Command = "";
            Query_Result_Start_Cut_String = "";
            Query_Result_Stop_Cut_String = "";
            Query_SCPI_Measurement_Units = "";
            Query_SCPI_Delay = 1;
            Query_Measurement_Window_Label_Color = "#FF1E90FF";
            Query_Measurement_Window_isBackground_Transparent = false;
            Query_Measurement_Window_Background_Color = "#FFFFFFFF";
        }
    }
}
