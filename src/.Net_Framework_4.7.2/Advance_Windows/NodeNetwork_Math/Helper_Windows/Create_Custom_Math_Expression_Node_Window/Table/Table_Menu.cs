using MahApps.Metro.Controls;
using System;
using System.Windows;

namespace Create_Custom_Math_Expression_Node
{
    public partial class Create_Custom_Math_Expression_Window : MetroWindow
    {
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
