using MahApps.Metro.Controls;
using System;
using System.Windows;
using System.Windows.Data;

namespace SCPI_Communication
{
    public partial class SCPI_Communication_Window : MetroWindow
    {
        private void Save_Expression_to_Table_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (Expression_Verify(SCPI_Expression))
                {
                    Save_Expression_to_Table();
                }
            }
            catch (Exception Ex)
            {
                insert_Log(Ex.Message, 1);
            }
        }

        private void Save_Expression_to_Table()
        {
            SCPI_Expression_Table.Add(new SCPI_Expression_Data(false, SCPI_Expression_Description, SCPI_Expression));
        }

        private void Update_Selected_Expression_from_Table_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (Selected_SCPI_Expression_Data != null)
                {
                    if (Expression_Verify(SCPI_Expression, false))
                    {
                        Selected_SCPI_Expression_Data.SCPI_Expression = SCPI_Expression;
                        Selected_SCPI_Expression_Data.SCPI_Expression_Description = SCPI_Expression_Description;
                        CollectionViewSource.GetDefaultView(SCPI_Expression_Table).Refresh();
                    }
                    else
                    {
                        insert_Log("Could not update selected SCPI Expression.", 2);
                    }
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
            SCPI_Expression = string.Empty;
            SCPI_Expression_Description = string.Empty;
        }
    }
}
