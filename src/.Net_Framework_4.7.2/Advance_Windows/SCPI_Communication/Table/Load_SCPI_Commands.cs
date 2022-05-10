using MahApps.Metro.Controls;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace SCPI_Communication
{
    public partial class SCPI_Communication_Window : MetroWindow
    {
        private void SCPI_Expression_DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (Auto_Load)
            {
                try
                {
                    if (Selected_SCPI_Expression_Data != null)
                    {
                        SCPI_Expression = Selected_SCPI_Expression_Data.SCPI_Expression;
                        SCPI_Expression_Description = Selected_SCPI_Expression_Data.SCPI_Expression_Description;
                    }
                }
                catch (Exception Ex)
                {
                    insert_Log(Ex.Message, 1);
                }
            }
        }

        private void SCPI_Expression_Load_Selected_Mouse_Double_Click(object sender, MouseButtonEventArgs e)
        {
            try
            {
                if (Selected_SCPI_Expression_Data != null)
                {
                    SCPI_Expression = Selected_SCPI_Expression_Data.SCPI_Expression;
                    SCPI_Expression_Description = Selected_SCPI_Expression_Data.SCPI_Expression_Description;
                }
            }
            catch (Exception Ex)
            {
                insert_Log(Ex.Message, 1);
            }
        }

        private void Clear_Table_Click(object sender, RoutedEventArgs e)
        {
            Clear_Table();
        }

        private void Clear_Table()
        {
            try
            {
                SCPI_Expression_Table.Clear();
            }
            catch (Exception) { }
        }
    }
}
