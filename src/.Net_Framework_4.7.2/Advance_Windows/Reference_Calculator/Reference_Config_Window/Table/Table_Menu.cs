using MahApps.Metro.Controls;
using System;
using System.Linq;
using System.Windows;

namespace Reference_Calculator
{
    public partial class Reference_Config_Panel : MetroWindow
    {
        private void Plot_All_Selected_Expression_from_Table_Click(object sender, RoutedEventArgs e)
        {
            Plot_All_Selected_Expression_from_Table();
        }

        private void Plot_All_Selected_Expression_from_Table()
        {
            try
            {
                this.Expression_DataGrid.CommitEdit();
                this.Expression_DataGrid.CommitEdit();
                for (int i = 0; i < Expression_Data.Count; i++)
                {
                    Expression_Data expression = Expression_Data.ElementAt(i);
                    if (expression.Expression_Selected)
                    {
                        Math_Expressions_Stored.Add(expression);
                    }
                }
            }
            catch (Exception) { }
        }

        private void Clear_Table_Click(object sender, RoutedEventArgs e)
        {
            Clear_Table();
        }

        private void Clear_Table()
        {
            try
            {
                Expression_Data.Clear();
            }
            catch (Exception) { }
        }
    }
}
